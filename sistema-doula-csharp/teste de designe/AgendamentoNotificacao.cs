using System;
using System.Collections.Generic;
using System.Text;

namespace teste_de_designe
{
    public class AgendamentoNotificacao
    {
            public int Id { get; set; }
            public DateTime Data { get; set; }
            public string Horarios { get; set; }
            public string Servicos { get; set; }
            public string Status { get; set; }

            public string EmailCliente { get; set; }
            public string TelefoneCliente { get; set; }

            public string NomePrestador { get; set; }
            public string EmailPrestador { get; set; }
            public string TelefonePrestador { get; set; }

            public bool Notificacao24hEnviada { get; set; }
            public bool Notificacao1hEnviada { get; set; }
    }
}
