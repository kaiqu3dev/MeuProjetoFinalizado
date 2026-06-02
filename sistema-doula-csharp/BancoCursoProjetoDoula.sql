-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bancocursoprojetodoula
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `agendamentos`
--

DROP TABLE IF EXISTS `agendamentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agendamentos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Data` date NOT NULL,
  `ValorTotal` decimal(10,2) NOT NULL DEFAULT 0.00,
  `QuantidadePessoas` int(11) NOT NULL DEFAULT 0,
  `NomeCompanheiro` varchar(150) DEFAULT NULL,
  `NomeBebe` varchar(150) DEFAULT NULL,
  `LocalParto` varchar(150) DEFAULT NULL,
  `DPP` date DEFAULT NULL,
  `EquipeMedica` varchar(200) DEFAULT NULL,
  `Status` varchar(50) NOT NULL DEFAULT 'Ativo',
  `Email` varchar(150) NOT NULL,
  `Horarios` varchar(255) DEFAULT NULL,
  `Servicos` varchar(255) DEFAULT NULL,
  `EmailCliente` varchar(150) DEFAULT NULL,
  `TelefoneCliente` varchar(25) DEFAULT NULL,
  `NomePrestador` varchar(150) DEFAULT NULL,
  `EmailPrestador` varchar(150) DEFAULT NULL,
  `TelefonePrestador` varchar(25) DEFAULT NULL,
  `Notificacao24hEnviada` tinyint(1) DEFAULT 0,
  `Notificacao1hEnviada` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`Id`),
  KEY `FK_Agendamentos_Usuarios_Email` (`Email`),
  CONSTRAINT `FK_Agendamentos_Usuarios_Email` FOREIGN KEY (`Email`) REFERENCES `usuarios` (`Email`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendamentos`
--

LOCK TABLES `agendamentos` WRITE;
/*!40000 ALTER TABLE `agendamentos` DISABLE KEYS */;
INSERT INTO `agendamentos` VALUES (1,'2026-04-10',150.00,1,NULL,NULL,NULL,NULL,NULL,'Ativo','kaiqueziin@outlook.com','15:00','Ouro','kaiqueziin@outlook.com','11999999999','Doula Responsável','projetodoulaefuro01@gmail.com','11999999999',0,1);
/*!40000 ALTER TABLE `agendamentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agendamentoservicos`
--

DROP TABLE IF EXISTS `agendamentoservicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agendamentoservicos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AgendamentoId` int(11) NOT NULL,
  `Data` date NOT NULL,
  `Tipo` varchar(50) NOT NULL,
  `Horario` varchar(10) NOT NULL,
  `Servico` varchar(150) NOT NULL,
  `Status` varchar(50) NOT NULL DEFAULT 'Ativo',
  `Valor` decimal(10,2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (`Id`),
  KEY `FK_AgendamentoServicos_Agendamentos` (`AgendamentoId`),
  CONSTRAINT `FK_AgendamentoServicos_Agendamentos` FOREIGN KEY (`AgendamentoId`) REFERENCES `agendamentos` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendamentoservicos`
--

LOCK TABLES `agendamentoservicos` WRITE;
/*!40000 ALTER TABLE `agendamentoservicos` DISABLE KEYS */;
INSERT INTO `agendamentoservicos` VALUES (1,1,'2026-04-24','Furo','09:00','Ouro','Ativo',150.00);
/*!40000 ALTER TABLE `agendamentoservicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(150) NOT NULL,
  `Idade` int(11) DEFAULT NULL,
  `Sexualidade` varchar(50) DEFAULT NULL,
  `CPF` varchar(20) DEFAULT NULL,
  `Telefone` varchar(25) DEFAULT NULL,
  `Naturalidade` varchar(100) DEFAULT NULL,
  `EstadoCivil` varchar(50) DEFAULT NULL,
  `Endereco` varchar(200) DEFAULT NULL,
  `CEP` varchar(20) DEFAULT NULL,
  `Email` varchar(150) NOT NULL,
  `Senha` varchar(150) NOT NULL,
  `TipoUsuario` varchar(50) NOT NULL DEFAULT 'Cliente',
  `Status` varchar(50) NOT NULL DEFAULT 'Ativo',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UK_Usuarios_Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Administrador',30,'Não informado','000.000.000-00','(11)94442-8702','São Paulo','Não informado','Endereço admin','00000-000','070624@gmail.com','12345678a','Admin','Ativo'),(3,'ka',38,'Heterossexual','00000000001','(11)9 2525-3030','Brasil','Casado','judiai','04830-310','kaiqueziin@outlook.com','123456a','Cliente','Ativo');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-10 14:43:50
