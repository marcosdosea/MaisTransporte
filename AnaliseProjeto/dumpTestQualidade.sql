CREATE DATABASE  IF NOT EXISTS `modelomaistransporte` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_bin */;
USE `modelomaistransporte`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: modelomaistransporte
-- ------------------------------------------------------
-- Server version	5.7.42-log

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
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `id` varchar(255) COLLATE latin1_bin NOT NULL,
  `email` varchar(256) COLLATE latin1_bin NOT NULL,
  `password` varchar(255) COLLATE latin1_bin NOT NULL,
  `confirmPassword` varchar(255) COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('1','gilmario@gmail.com','qwe123','qwe123'),('10','nataliacosta196@gmail.com','1234','1234'),('11','Alesandro','1234','1234'),('12',' edantas241@gmail.com','123456','123456'),('2','andreza@gmail.com','qwe123','qwe123'),('3','mariaclara@gmail.com','qwe123','qwe123'),('4','joaodossantos@gmail.com','qwe123','qwe123'),('6','rosa@gmail.com','qwe123','qwe123'),('7','anamaria@gmail.com','qwe123','qwe123'),('8','jessica@gmail.com','qwe123','qwe123'),('9','jessica@gmail.com','qwe123','qwe123');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `avaliacao`
--

DROP TABLE IF EXISTS `avaliacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avaliacao` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nota` int(11) NOT NULL,
  `comentario` varchar(200) COLLATE latin1_bin DEFAULT NULL,
  `idPassageiro` int(11) NOT NULL,
  `idViagem` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Avaliacao_Passageiro1_idx` (`idPassageiro`),
  KEY `fk_Avaliacao_Viagem1_idx` (`idViagem`),
  CONSTRAINT `fk_Avaliacao_Passageiro1` FOREIGN KEY (`idPassageiro`) REFERENCES `passageiro` (`id`),
  CONSTRAINT `fk_Avaliacao_Viagem1` FOREIGN KEY (`idViagem`) REFERENCES `viagem` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avaliacao`
--

LOCK TABLES `avaliacao` WRITE;
/*!40000 ALTER TABLE `avaliacao` DISABLE KEYS */;
INSERT INTO `avaliacao` VALUES (1,5,'Sem sugestão',4,1);
/*!40000 ALTER TABLE `avaliacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motorista`
--

DROP TABLE IF EXISTS `motorista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motorista` (
  `idPassageiro` int(11) NOT NULL,
  `numeroDocumento` varchar(15) COLLATE latin1_bin NOT NULL,
  `dataEmissao` datetime NOT NULL,
  `expeditor` varchar(5) COLLATE latin1_bin NOT NULL,
  `estado` varchar(2) COLLATE latin1_bin NOT NULL,
  `dataValidacao` datetime NOT NULL,
  `status` enum('Solicitado','Ativo','Inativo') COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`idPassageiro`),
  KEY `fk_Motorista_Passageiro1_idx` (`idPassageiro`),
  CONSTRAINT `fk_Motorista_Passageiro1` FOREIGN KEY (`idPassageiro`) REFERENCES `passageiro` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motorista`
--

LOCK TABLES `motorista` WRITE;
/*!40000 ALTER TABLE `motorista` DISABLE KEYS */;
INSERT INTO `motorista` VALUES (1,'12235415488','2023-09-23 14:30:00','SSP','SE','2024-09-13 14:30:00','Ativo'),(2,'12235415489','2023-09-13 14:30:00','SSP','SE','2023-09-13 14:30:00','Ativo'),(6,'33235415488','2022-09-23 14:30:00','SSP','SE','2024-09-13 14:30:00','Ativo');
/*!40000 ALTER TABLE `motorista` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passageiro`
--

DROP TABLE IF EXISTS `passageiro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `passageiro` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) COLLATE latin1_bin NOT NULL,
  `email` varchar(50) COLLATE latin1_bin NOT NULL,
  `cpf` varchar(15) COLLATE latin1_bin NOT NULL,
  `dataNascimento` datetime NOT NULL,
  `telefone` varchar(15) COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  KEY `idx_cpf` (`cpf`),
  KEY `idx_nome` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passageiro`
--

LOCK TABLES `passageiro` WRITE;
/*!40000 ALTER TABLE `passageiro` DISABLE KEYS */;
INSERT INTO `passageiro` VALUES (1,'GILMARIO DOS SANTOS','GILMARIO@GMAIL.COM','36506677031','2000-09-13 00:00:00','79999995544'),(2,'Andreza Santos Lima','andreza@gmail.com','64712298014','1999-09-13 00:00:00','79999995544'),(3,'Maria Clara dos Santos','mariaclara@gmail.com','06218512053','1997-09-14 00:00:00','79999995544'),(4,'João dos Santos Azevedo','joaodossantos@gmail.com','22222233322','1999-01-01 00:00:00','79999999999'),(6,'Rosa Maria','rosa@gmail.com','75472086060','2001-01-13 00:00:00','79999995644'),(7,'Ana Maria dos Santos','anamaria@gmail.com','88417303073','2001-09-14 00:00:00','79999995654'),(8,'Jessica Santos Silva','jessica@gmail.com','74030422047','2002-09-14 00:00:00','79999997788'),(9,'Andrea Nunes Silva','andrea@gmail.com','42617866050','2003-09-14 00:00:00','79999997789');
/*!40000 ALTER TABLE `passageiro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passageirosugestaoviagem`
--

DROP TABLE IF EXISTS `passageirosugestaoviagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `passageirosugestaoviagem` (
  `idPassageiro` int(11) NOT NULL AUTO_INCREMENT,
  `idSugestaoViagem` int(11) NOT NULL,
  PRIMARY KEY (`idPassageiro`,`idSugestaoViagem`),
  KEY `fk_Passageiro_has_SugestaoViagem_SugestaoViagem1_idx` (`idSugestaoViagem`),
  KEY `fk_Passageiro_has_SugestaoViagem_Passageiro1_idx` (`idPassageiro`),
  CONSTRAINT `fk_PassageiroSugestaoViagem_Passageiro1` FOREIGN KEY (`idPassageiro`) REFERENCES `passageiro` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_PassageiroSugestaoViagem_SugestaoViagem1` FOREIGN KEY (`idSugestaoViagem`) REFERENCES `sugestaoviagem` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passageirosugestaoviagem`
--

LOCK TABLES `passageirosugestaoviagem` WRITE;
/*!40000 ALTER TABLE `passageirosugestaoviagem` DISABLE KEYS */;
/*!40000 ALTER TABLE `passageirosugestaoviagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passageiroviagem`
--

DROP TABLE IF EXISTS `passageiroviagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `passageiroviagem` (
  `idPassageiro` int(11) NOT NULL,
  `idViagem` int(11) NOT NULL,
  PRIMARY KEY (`idPassageiro`,`idViagem`),
  KEY `fk_Passageiro_has_Viagem_Viagem1_idx` (`idViagem`),
  KEY `fk_Passageiro_has_Viagem_Passageiro1_idx` (`idPassageiro`),
  CONSTRAINT `fk_PassageiroViagem_Passageiro1` FOREIGN KEY (`idPassageiro`) REFERENCES `passageiro` (`id`),
  CONSTRAINT `fk_PassageiroViagem_Viagem1` FOREIGN KEY (`idViagem`) REFERENCES `viagem` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passageiroviagem`
--

LOCK TABLES `passageiroviagem` WRITE;
/*!40000 ALTER TABLE `passageiroviagem` DISABLE KEYS */;
/*!40000 ALTER TABLE `passageiroviagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reembolso`
--

DROP TABLE IF EXISTS `reembolso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reembolso` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `valor` float NOT NULL,
  `idPassageiro` int(11) NOT NULL,
  `idViagem` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Reembolso_Passageiro1_idx` (`idPassageiro`),
  KEY `fk_Reembolso_Viagem1_idx` (`idViagem`),
  CONSTRAINT `fk_Reembolso_Passageiro1` FOREIGN KEY (`idPassageiro`) REFERENCES `passageiro` (`id`),
  CONSTRAINT `fk_Reembolso_Viagem1` FOREIGN KEY (`idViagem`) REFERENCES `viagem` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reembolso`
--

LOCK TABLES `reembolso` WRITE;
/*!40000 ALTER TABLE `reembolso` DISABLE KEYS */;
/*!40000 ALTER TABLE `reembolso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `id` int(11) NOT NULL,
  `dataCompra` datetime NOT NULL,
  `stausPagamento` varchar(50) COLLATE latin1_bin NOT NULL,
  `valorPagamento` float NOT NULL,
  `idViagem` int(11) NOT NULL AUTO_INCREMENT,
  `idPassageiro` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Reserva_Viagem1_idx` (`idViagem`),
  KEY `fk_Reserva_Passageiro1_idx` (`idPassageiro`),
  CONSTRAINT `fk_Reserva_Passageiro1` FOREIGN KEY (`idPassageiro`) REFERENCES `passageiro` (`id`),
  CONSTRAINT `fk_Reserva_Viagem1` FOREIGN KEY (`idViagem`) REFERENCES `viagem` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sugestaoviagem`
--

DROP TABLE IF EXISTS `sugestaoviagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sugestaoviagem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(50) COLLATE latin1_bin NOT NULL,
  `localOrigem` varchar(50) COLLATE latin1_bin NOT NULL,
  `localDestino` varchar(50) COLLATE latin1_bin NOT NULL,
  `valorPassagem` float NOT NULL,
  `totalVagas` int(11) NOT NULL,
  `dataPartida` datetime NOT NULL,
  `dataChegada` datetime NOT NULL,
  `descricao` varchar(100) COLLATE latin1_bin NOT NULL,
  `visibilidade` enum('Pública','Privada') COLLATE latin1_bin NOT NULL DEFAULT 'Pública',
  `idPassageiro` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_SugestaoViagem_Passageiro1_idx` (`idPassageiro`),
  KEY `idx_localDestino` (`localDestino`),
  CONSTRAINT `fk_SugestaoViagem_Passageiro1` FOREIGN KEY (`idPassageiro`) REFERENCES `passageiro` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sugestaoviagem`
--

LOCK TABLES `sugestaoviagem` WRITE;
/*!40000 ALTER TABLE `sugestaoviagem` DISABLE KEYS */;
INSERT INTO `sugestaoviagem` VALUES (3,'FestVerão','Itabaiana','Laranjeiras',10,25,'2024-01-04 14:00:00','2024-01-06 14:00:00','Sem reembolso após saída do veículo','Pública',4);
/*!40000 ALTER TABLE `sugestaoviagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veiculo`
--

DROP TABLE IF EXISTS `veiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `veiculo` (
  `id` int(11) NOT NULL,
  `renavam` varchar(15) COLLATE latin1_bin NOT NULL,
  `placa` varchar(10) COLLATE latin1_bin NOT NULL,
  `dataEmissao` datetime NOT NULL,
  `expeditor` varchar(5) COLLATE latin1_bin NOT NULL,
  `estado` varchar(2) COLLATE latin1_bin NOT NULL,
  `idMotoristaPassageiro` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `renavam_UNIQUE` (`renavam`),
  KEY `fk_Veiculo_Motorista1_idx` (`idMotoristaPassageiro`),
  KEY `idx_placa` (`placa`),
  CONSTRAINT `fk_Veiculo_Motorista1` FOREIGN KEY (`idMotoristaPassageiro`) REFERENCES `motorista` (`idPassageiro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiculo`
--

LOCK TABLES `veiculo` WRITE;
/*!40000 ALTER TABLE `veiculo` DISABLE KEYS */;
INSERT INTO `veiculo` VALUES (1,'12345678990','BCV3G79','2022-12-01 14:30:00','SSP','SE',2),(2,'6541237','BCV3G79','2023-12-01 14:30:00','SSP','SE',6);
/*!40000 ALTER TABLE `veiculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `viagem`
--

DROP TABLE IF EXISTS `viagem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `viagem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(50) COLLATE latin1_bin NOT NULL,
  `localOrigem` varchar(50) COLLATE latin1_bin NOT NULL,
  `localDestino` varchar(50) COLLATE latin1_bin NOT NULL,
  `valorPassagem` float NOT NULL,
  `totalVagas` int(11) NOT NULL,
  `dataPartida` datetime NOT NULL,
  `dataChegada` datetime NOT NULL,
  `descricao` varchar(100) COLLATE latin1_bin NOT NULL,
  `idMotorista` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idx_localDestino` (`localDestino`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COLLATE=latin1_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `viagem`
--

LOCK TABLES `viagem` WRITE;
/*!40000 ALTER TABLE `viagem` DISABLE KEYS */;
INSERT INTO `viagem` VALUES (1,'FestVerão','Areia Branca','Aracaju',15,14,'2023-12-31 14:30:00','2024-01-01 19:00:00','Sem reembolso para atrasos',6);
/*!40000 ALTER TABLE `viagem` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-23  0:20:08
