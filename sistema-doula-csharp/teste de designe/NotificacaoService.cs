using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;



namespace teste_de_designe
{
    public class NotificacaoService
    {
        private readonly EmailService emailService;



        public NotificacaoService(EmailService emailService)
        {
            this.emailService = emailService;
        }



        public void ProcessarNotificacoes24h()
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();



                string sql = @"
SELECT Id, EmailCliente, EmailPrestador, Data, Horarios, Servicos, ValorTotal, Status
FROM Agendamentos
WHERE Status = 'Ativo'
AND EmailCliente IS NOT NULL
AND TRIM(EmailCliente) <> ''
AND IFNULL(Notificacao24hEnviada, 0) = 0";



                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    DataTable tabela = new DataTable();
                    tabela.Load(dr);



                    foreach (DataRow row in tabela.Rows)
                    {
                        int id = Convert.ToInt32(row["Id"]);



                        string emailCliente = row["EmailCliente"]?.ToString() ?? "";
                        string emailPrestador = row["EmailPrestador"]?.ToString() ?? "";



                        DateTime data = Convert.ToDateTime(row["Data"]);
                        string horarios = row["Horarios"]?.ToString() ?? "";
                        string servicos = row["Servicos"]?.ToString() ?? "";



                        decimal valorTotal =
                        row["ValorTotal"] == DBNull.Value
                        ? 0
                        : Convert.ToDecimal(row["ValorTotal"]);



                        DateTime? primeiroHorario =
                        ObterPrimeiraDataHoraAgendamento(data, horarios);



                        if (!primeiroHorario.HasValue)
                            continue;



                        TimeSpan diferenca = primeiroHorario.Value - DateTime.Now;



                        if (diferenca.TotalHours <= 24 && diferenca.TotalHours > 23)
                        {
                            string assuntoCliente = "Lembrete: seu agendamento é amanhã";
                            string corpoCliente = $@"Olá!

 

Este é um lembrete do seu agendamento.

 

Data: {data:dd/MM/yyyy}
Horário(s): {horarios}
Serviço(s): {servicos}
Valor total: R$ {valorTotal:N2}

 

Aguardamos você.
Sistema Doula";



                            string assuntoPrestador = "Lembrete: atendimento agendado para amanhã";
                            string corpoPrestador = $@"Olá!

 

Este é um lembrete de atendimento agendado para amanhã.

 

Data: {data:dd/MM/yyyy}
Horário(s): {horarios}
Serviço(s): {servicos}
Valor total: R$ {valorTotal:N2}

 

Verifique sua agenda.
Sistema Doula";



                            try
                            {
                                if (!string.IsNullOrWhiteSpace(emailCliente))
                                {
                                    emailService.EnviarEmail(
                                    emailCliente,
                                    assuntoCliente,
                                    corpoCliente
                                    );
                                }



                                if (!string.IsNullOrWhiteSpace(emailPrestador))
                                {
                                    emailService.EnviarEmail(
                                    emailPrestador,
                                    assuntoPrestador,
                                    corpoPrestador
                                    );
                                }



                                MarcarNotificacao24hComoEnviada(id);
                            }
                            catch
                            {
                                // evita travar o sistema se falhar envio
                            }
                        }
                    }
                }
            }
        }



        public void ProcessarNotificacoes1h()
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();



                string sql = @"
SELECT Id, EmailCliente, EmailPrestador, Data, Horarios, Servicos, ValorTotal, Status
FROM Agendamentos
WHERE Status = 'Ativo'
AND EmailCliente IS NOT NULL
AND TRIM(EmailCliente) <> ''
AND IFNULL(Notificacao1hEnviada, 0) = 0";



                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    DataTable tabela = new DataTable();
                    tabela.Load(dr);



                    foreach (DataRow row in tabela.Rows)
                    {
                        int id = Convert.ToInt32(row["Id"]);



                        string emailCliente = row["EmailCliente"]?.ToString() ?? "";
                        string emailPrestador = row["EmailPrestador"]?.ToString() ?? "";



                        DateTime data = Convert.ToDateTime(row["Data"]);
                        string horarios = row["Horarios"]?.ToString() ?? "";
                        string servicos = row["Servicos"]?.ToString() ?? "";



                        decimal valorTotal =
                        row["ValorTotal"] == DBNull.Value
                        ? 0
                        : Convert.ToDecimal(row["ValorTotal"]);



                        DateTime? primeiroHorario =
                        ObterPrimeiraDataHoraAgendamento(data, horarios);



                        if (!primeiroHorario.HasValue)
                            continue;



                        TimeSpan diferenca = primeiroHorario.Value - DateTime.Now;



                        if (diferenca.TotalMinutes <= 60 && diferenca.TotalMinutes > 0)
                        {
                            string assuntoCliente = "Lembrete: seu agendamento começa em breve";
                            string corpoCliente = $@"Olá!

 

Seu agendamento está próximo.

 

Data: {data:dd/MM/yyyy}
Horário(s): {horarios}
Serviço(s): {servicos}
Valor total: R$ {valorTotal:N2}

 

Nos vemos em breve!
Sistema Doula";



                            string assuntoPrestador = "Lembrete: atendimento começa em breve";
                            string corpoPrestador = $@"Olá!

 

O atendimento agendado começará em breve.

 

Data: {data:dd/MM/yyyy}
Horário(s): {horarios}
Serviço(s): {servicos}
Valor total: R$ {valorTotal:N2}

 

Prepare-se para o atendimento.
Sistema Doula";



                            try
                            {
                                if (!string.IsNullOrWhiteSpace(emailCliente))
                                {
                                    emailService.EnviarEmail(
                                    emailCliente,
                                    assuntoCliente,
                                    corpoCliente
                                    );
                                }



                                if (!string.IsNullOrWhiteSpace(emailPrestador))
                                {
                                    emailService.EnviarEmail(
                                    emailPrestador,
                                    assuntoPrestador,
                                    corpoPrestador
                                    );
                                }



                                MarcarNotificacao1hComoEnviada(id);
                            }
                            catch
                            {
                                // evita travar o sistema se falhar envio
                            }
                        }
                    }
                }
            }
        }



        private DateTime? ObterPrimeiraDataHoraAgendamento(DateTime data, string horarios)
        {
            if (string.IsNullOrWhiteSpace(horarios))
                return null;



            List<TimeSpan> listaHorarios = new List<TimeSpan>();



            string[] partes = horarios.Split(',');



            foreach (string parte in partes)
            {
                string horarioLimpo = parte.Trim();



                if (TimeSpan.TryParse(horarioLimpo, out TimeSpan hora))
                {
                    listaHorarios.Add(hora);
                }
            }



            if (listaHorarios.Count == 0)
                return null;



            TimeSpan menorHorario = listaHorarios.Min();
            return data.Date.Add(menorHorario);
        }



        private void MarcarNotificacao24hComoEnviada(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();



                string sql = @"
UPDATE Agendamentos
SET Notificacao24hEnviada = 1
WHERE Id = @Id";



                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private void MarcarNotificacao1hComoEnviada(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(Conexao.StringConexao))
            {
                conn.Open();



                string sql = @"
UPDATE Agendamentos
SET Notificacao1hEnviada = 1
WHERE Id = @Id";



                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}