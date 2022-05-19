-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Table structure for table `composition`
--

DROP TABLE IF EXISTS `composition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `composition` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_ingr` int NOT NULL,
  `id_menu` int NOT NULL,
  `amount` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`,`id_ingr`,`id_menu`),
  KEY `fk_composition_ingredients1_idx` (`id_ingr`),
  KEY `fk_composition_menu1_idx` (`id_menu`),
  CONSTRAINT `fk_composition_ingredients1` FOREIGN KEY (`id_ingr`) REFERENCES `ingredients` (`id_ingr`),
  CONSTRAINT `fk_composition_menu1` FOREIGN KEY (`id_menu`) REFERENCES `menu` (`id_menu`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `composition`
--

LOCK TABLES `composition` WRITE;
/*!40000 ALTER TABLE `composition` DISABLE KEYS */;
INSERT INTO `composition` VALUES (1,2,1,'1');
/*!40000 ALTER TABLE `composition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drinks`
--

DROP TABLE IF EXISTS `drinks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `drinks` (
  `id_drink` int NOT NULL AUTO_INCREMENT,
  `title_drink` varchar(45) DEFAULT NULL,
  `amount_drink` varchar(45) DEFAULT NULL,
  `price_drink` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_drink`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drinks`
--

LOCK TABLES `drinks` WRITE;
/*!40000 ALTER TABLE `drinks` DISABLE KEYS */;
INSERT INTO `drinks` VALUES (1,'Вода',NULL,'110');
/*!40000 ALTER TABLE `drinks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drinks_reg`
--

DROP TABLE IF EXISTS `drinks_reg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `drinks_reg` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_reg` int NOT NULL,
  `id_drink` int NOT NULL,
  `amount` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`id_reg`,`id_drink`),
  KEY `fk_drinks_reg_registration1_idx` (`id_reg`),
  KEY `fk_drinks_reg_drinks1_idx` (`id_drink`),
  CONSTRAINT `fk_drinks_reg_drinks1` FOREIGN KEY (`id_drink`) REFERENCES `drinks` (`id_drink`),
  CONSTRAINT `fk_drinks_reg_registration1` FOREIGN KEY (`id_reg`) REFERENCES `registration` (`id_reg`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drinks_reg`
--

LOCK TABLES `drinks_reg` WRITE;
/*!40000 ALTER TABLE `drinks_reg` DISABLE KEYS */;
INSERT INTO `drinks_reg` VALUES (1,1,1,'2');
/*!40000 ALTER TABLE `drinks_reg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grams`
--

DROP TABLE IF EXISTS `grams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grams` (
  `id_grams` int NOT NULL AUTO_INCREMENT,
  `title_grams` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_grams`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grams`
--

LOCK TABLES `grams` WRITE;
/*!40000 ALTER TABLE `grams` DISABLE KEYS */;
INSERT INTO `grams` VALUES (1,'кг'),(2,'г'),(3,'шт'),(4,'мл'),(5,'л');
/*!40000 ALTER TABLE `grams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredients` (
  `id_ingr` int NOT NULL AUTO_INCREMENT,
  `title_ingr` varchar(45) DEFAULT NULL,
  `amount_ingr` varchar(45) DEFAULT NULL,
  `grams_id_grams` int NOT NULL,
  PRIMARY KEY (`id_ingr`,`grams_id_grams`),
  UNIQUE KEY `UK_ingredients_id_ingr` (`id_ingr`),
  KEY `fk_ingredients_grams1_idx` (`grams_id_grams`),
  CONSTRAINT `fk_ingredients_grams1` FOREIGN KEY (`grams_id_grams`) REFERENCES `grams` (`id_grams`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES (1,'Огурец',NULL,3),(2,'Яйцо',NULL,3);
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu` (
  `id_menu` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) DEFAULT NULL,
  `price` varchar(45) DEFAULT NULL,
  `type_id_type` int NOT NULL,
  `description` varchar(245) DEFAULT NULL,
  PRIMARY KEY (`id_menu`,`type_id_type`),
  UNIQUE KEY `UK_menu_id_menu` (`id_menu`),
  KEY `fk_menu_type1_idx` (`type_id_type`),
  CONSTRAINT `fk_menu_type1` FOREIGN KEY (`type_id_type`) REFERENCES `type` (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,'Оливье','110',1,'Небольшой салат');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_reg`
--

DROP TABLE IF EXISTS `menu_reg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_reg` (
  `id` int NOT NULL AUTO_INCREMENT,
  `amount` varchar(45) DEFAULT NULL,
  `id_reg` int NOT NULL,
  `id_menu` int NOT NULL,
  PRIMARY KEY (`id`,`id_reg`,`id_menu`),
  KEY `fk_menu_reg_registration2_idx` (`id_reg`),
  KEY `fk_menu_reg_menu2_idx` (`id_menu`),
  CONSTRAINT `fk_menu_reg_menu2` FOREIGN KEY (`id_menu`) REFERENCES `menu` (`id_menu`),
  CONSTRAINT `fk_menu_reg_registration2` FOREIGN KEY (`id_reg`) REFERENCES `registration` (`id_reg`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_reg`
--

LOCK TABLES `menu_reg` WRITE;
/*!40000 ALTER TABLE `menu_reg` DISABLE KEYS */;
INSERT INTO `menu_reg` VALUES (1,'1',1,1);
/*!40000 ALTER TABLE `menu_reg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registration`
--

DROP TABLE IF EXISTS `registration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registration` (
  `id_reg` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `data` date DEFAULT NULL,
  `number` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_reg`,`user_id`),
  KEY `fk_registration_user1_idx` (`user_id`),
  CONSTRAINT `fk_registration_user1` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` VALUES (1,1,'2022-05-19','C22H01');
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type`
--

DROP TABLE IF EXISTS `type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type` (
  `id_type` int NOT NULL AUTO_INCREMENT,
  `title_type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type`
--

LOCK TABLES `type` WRITE;
/*!40000 ALTER TABLE `type` DISABLE KEYS */;
INSERT INTO `type` VALUES (1,'Салат');
/*!40000 ALTER TABLE `type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `nomer` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Алексей','Романов','89147344426');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'mydb'
--

--
-- Dumping routines for database 'mydb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-19 23:34:36
