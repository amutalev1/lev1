CREATE DATABASE  IF NOT EXISTS `amuta` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_bin */;
USE `amuta`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: amuta
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `address` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `country_id` int(11) NOT NULL,
  `city_id` int(11) NOT NULL,
  `neighborhood_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `street_id` int(11) NOT NULL,
  `house_number` int(11) NOT NULL,
  `apartment_number` int(11) DEFAULT NULL,
  `zip_code` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `country_id_address_idx` (`country_id`),
  KEY `city_id_address_idx` (`city_id`),
  KEY `street_id_idx` (`street_id`),
  CONSTRAINT `city_id_address` FOREIGN KEY (`city_id`) REFERENCES `cities` (`id`),
  CONSTRAINT `country_id_address` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`),
  CONSTRAINT `street_id` FOREIGN KEY (`street_id`) REFERENCES `streets` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (1,1,1,'רובע A',1,253,4,'5617786'),(2,1,2,'רובע B',4,254,11,'1488696'),(3,1,3,'רובע C',7,145,4,'4829129'),(4,1,4,'רובע A',10,293,13,'4315390'),(5,1,5,'רובע B',14,107,3,'9059217'),(6,1,6,'רובע C',16,264,2,'1017081'),(7,1,1,'רובע A',1,271,12,'5093099'),(8,1,2,'רובע B',5,392,6,'4861747'),(9,1,3,'רובע C',8,72,14,'1213625'),(10,1,4,'רובע A',11,441,15,'1966974'),(11,1,5,'רובע B',15,129,16,'5862259'),(12,1,6,'רובע C',17,121,13,'4889961'),(13,1,1,'רובע A',1,292,1,'3653154'),(14,1,2,'רובע B',6,53,13,'1674175'),(15,1,3,'רובע C',9,375,7,'3507219'),(16,1,4,'רובע A',12,192,8,'8671335'),(17,1,5,'רובע B',13,199,14,'5430866'),(18,1,6,'רובע C',18,457,16,'8195544'),(19,1,1,'רובע A',1,232,6,'7463968'),(20,1,2,'רובע B',4,405,16,'6065869'),(21,1,3,'רובע B',7,98,13,'7795890'),(22,1,4,'רובע B',10,94,15,'5721804'),(23,1,5,'רובע B',14,404,19,'5054198'),(24,1,6,'רובע B',16,280,16,'6030157'),(25,1,1,'רובע B',1,254,22,''),(26,1,2,'רובע B',5,275,1,''),(27,1,3,'רובע C',8,240,15,''),(28,1,4,'רובע A',11,214,21,''),(29,1,5,'רובע B',15,20,23,''),(30,1,6,'רובע C',17,348,6,''),(31,1,1,'רובע A',1,159,7,'5098099'),(32,1,2,'רובע B',6,481,15,'3293313'),(33,1,3,'רובע C',9,176,9,'9448212'),(34,1,4,'רובע A',12,292,2,'3073143'),(35,1,5,'רובע B',13,172,21,'9540883'),(36,1,6,'רובע C',18,21,13,'7728903'),(37,1,1,'רובע A',1,24,8,'2922483'),(38,1,2,'רובע B',4,490,4,'6006830'),(39,1,3,'רובע C',7,235,6,'8090539'),(40,1,4,'רובע A',10,199,5,'5795015'),(41,1,5,'רובע B',14,245,4,'1615415'),(42,1,6,'רובע C',16,215,3,'9272810'),(43,1,1,'רובע B',1,325,10,'4414505'),(44,1,2,'רובע B',5,444,25,'9635485'),(45,1,3,'רובע B',8,473,17,'3500309'),(46,1,4,'רובע B',11,14,3,'6354868'),(47,1,5,'רובע B',15,289,14,'7618526'),(48,1,6,'רובע C',17,341,21,'9497806'),(49,1,1,'רובע A',1,149,24,'9061456'),(50,1,2,'רובע B',6,111,8,'4254377'),(51,1,2,'רובע B',19,1,5,'7744401'),(52,1,4,'רובע B',20,3,5,'9909603'),(53,1,1,'רובע B',1,60,4,'5127319'),(54,1,5,'רובע B',21,2,6,'7183402'),(55,1,6,'רובע B',22,94,6,'4082414'),(56,1,3,'רובע B',23,20,6,'4926124');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attendance` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `branch_id` int(11) NOT NULL,
  `time` datetime NOT NULL,
  `is_entry` tinyint(1) NOT NULL,
  `user_logged_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `device_id` int(11) NOT NULL,
  `location_device` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `time_logged` datetime NOT NULL,
  `reason` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `is_approved` tinyint(1) DEFAULT NULL,
  `user_approved_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `attendance_type_id` int(11) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `collel_id_idxx` (`branch_id`),
  KEY `student_id_attendance_idx` (`student_id`),
  KEY `device_id_idx` (`device_id`),
  KEY `attendance_type_id_idx` (`attendance_type_id`),
  CONSTRAINT `attendance_type_id` FOREIGN KEY (`attendance_type_id`) REFERENCES `attendance_types` (`id`),
  CONSTRAINT `branch_id_attendance` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `device_id` FOREIGN KEY (`device_id`) REFERENCES `devices` (`id`),
  CONSTRAINT `student_id_attendance` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance_rules`
--

DROP TABLE IF EXISTS `attendance_rules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attendance_rules` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `branch_id` int(11) NOT NULL,
  `maximum_lateness` int(11) NOT NULL,
  `maximum_absences` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_rules`
--

LOCK TABLES `attendance_rules` WRITE;
/*!40000 ALTER TABLE `attendance_rules` DISABLE KEYS */;
/*!40000 ALTER TABLE `attendance_rules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance_types`
--

DROP TABLE IF EXISTS `attendance_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `attendance_types` (
  `id` int(11) NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance_types`
--

LOCK TABLES `attendance_types` WRITE;
/*!40000 ALTER TABLE `attendance_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `attendance_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `banks`
--

DROP TABLE IF EXISTS `banks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `banks` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bank_number` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `branch_number` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `address_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `address_bank_idx` (`address_id`),
  KEY `address_id_banks_idx` (`address_id`),
  CONSTRAINT `address_bank` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`),
  CONSTRAINT `address_id_banks` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `banks`
--

LOCK TABLES `banks` WRITE;
/*!40000 ALTER TABLE `banks` DISABLE KEYS */;
INSERT INTO `banks` VALUES (1,'4','בנק יהב לעובדי המדינה בע\"מ','114',51),(2,'10','בנק לאומי לישראל בע\"מ','164',52),(3,'11','בנק דיסקונט לישראל בע\"מ','139',53),(4,'52','בנק פועלי אגודת ישראל בע\"מ','180',54),(5,'12','בנק הפועלים בע\"מ','475',55),(6,'20','בנק מזרחי טפחות בע\"מ','429',56);
/*!40000 ALTER TABLE `banks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch_activity_hours`
--

DROP TABLE IF EXISTS `branch_activity_hours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branch_activity_hours` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `branch_id` int(11) NOT NULL,
  `late_hour` time NOT NULL,
  `start_study_hours` time NOT NULL,
  `end_study_hours` time NOT NULL,
  PRIMARY KEY (`id`),
  KEY `branch_id_activity_hours_idx` (`branch_id`),
  CONSTRAINT `branch_id_activity_hours` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch_activity_hours`
--

LOCK TABLES `branch_activity_hours` WRITE;
/*!40000 ALTER TABLE `branch_activity_hours` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch_activity_hours` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch_devices`
--

DROP TABLE IF EXISTS `branch_devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branch_devices` (
  `branch_id` int(11) NOT NULL,
  `device_id` int(11) NOT NULL,
  PRIMARY KEY (`branch_id`,`device_id`),
  KEY `device_id_branch_idx` (`device_id`),
  CONSTRAINT `branch_id_devices` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `device_id_branch` FOREIGN KEY (`device_id`) REFERENCES `devices` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch_devices`
--

LOCK TABLES `branch_devices` WRITE;
/*!40000 ALTER TABLE `branch_devices` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch_devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch_exams`
--

DROP TABLE IF EXISTS `branch_exams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branch_exams` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `branch_id` int(11) NOT NULL,
  `submit_exam_scholarship_addition` int(11) NOT NULL,
  `failing_submit_exam_scholarship_reducing` int(11) NOT NULL,
  `passed_exam_scholarship_addition` int(11) NOT NULL,
  `not_passed_exam_scholarship_reducing` int(11) NOT NULL,
  `pass_grade` decimal(5,2) NOT NULL,
  `subject` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `branch_id_exams_idx` (`branch_id`),
  CONSTRAINT `branch_id_exams` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch_exams`
--

LOCK TABLES `branch_exams` WRITE;
/*!40000 ALTER TABLE `branch_exams` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch_exams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch_staff`
--

DROP TABLE IF EXISTS `branch_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branch_staff` (
  `branch_id` int(11) NOT NULL,
  `user_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `role_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `is_contact` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`branch_id`,`user_id`,`role_id`),
  CONSTRAINT `branch_id_staff` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch_staff`
--

LOCK TABLES `branch_staff` WRITE;
/*!40000 ALTER TABLE `branch_staff` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch_students`
--

DROP TABLE IF EXISTS `branch_students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branch_students` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `branch_id` int(11) NOT NULL,
  `branch_study_path_id` int(11) DEFAULT NULL,
  `entry_hebrew_date` date DEFAULT NULL,
  `entry_gregorian_date` date DEFAULT NULL,
  `release_hebrew_date` date DEFAULT NULL,
  `release_gregorian_date` date DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  `status` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `student_id_branch_idx` (`student_id`),
  KEY `branch_student_idx` (`branch_id`),
  KEY `branch_study_path_idx` (`branch_study_path_id`),
  CONSTRAINT `branch_student` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `branch_study_path` FOREIGN KEY (`branch_study_path_id`) REFERENCES `branch_study_path` (`id`),
  CONSTRAINT `student_id_branch` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch_students`
--

LOCK TABLES `branch_students` WRITE;
/*!40000 ALTER TABLE `branch_students` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch_students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch_study_path`
--

DROP TABLE IF EXISTS `branch_study_path`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branch_study_path` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `branch_id` int(11) NOT NULL,
  `study_path_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `branch_id_courses_idx` (`branch_id`),
  KEY `study_track_idx` (`study_path_id`),
  CONSTRAINT `branch_id_courses` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `study_path` FOREIGN KEY (`study_path_id`) REFERENCES `study_path` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch_study_path`
--

LOCK TABLES `branch_study_path` WRITE;
/*!40000 ALTER TABLE `branch_study_path` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch_study_path` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branch_types`
--

DROP TABLE IF EXISTS `branch_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branch_types` (
  `id` int(11) NOT NULL,
  `type` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`,`type`,`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branch_types`
--

LOCK TABLES `branch_types` WRITE;
/*!40000 ALTER TABLE `branch_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `branch_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branches`
--

DROP TABLE IF EXISTS `branches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `branches` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type_id` int(11) NOT NULL,
  `head_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `address_id` int(11) NOT NULL,
  `institution_id` int(11) NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `opening_date` date NOT NULL,
  `students_number` int(11) NOT NULL,
  `study_subjects` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT '1',
  `image` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `branch_type_id_idx` (`type_id`),
  KEY `address_branch_idx` (`address_id`),
  KEY `institution_id_branch_idx` (`institution_id`),
  CONSTRAINT `address_branch` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`),
  CONSTRAINT `branch_type_id` FOREIGN KEY (`type_id`) REFERENCES `branch_types` (`id`),
  CONSTRAINT `institution_id_branch` FOREIGN KEY (`institution_id`) REFERENCES `institutions` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branches`
--

LOCK TABLES `branches` WRITE;
/*!40000 ALTER TABLE `branches` DISABLE KEYS */;
/*!40000 ALTER TABLE `branches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cities`
--

DROP TABLE IF EXISTS `cities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cities` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `country_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `country_id_city_idx` (`country_id`),
  CONSTRAINT `country_city` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cities`
--

LOCK TABLES `cities` WRITE;
/*!40000 ALTER TABLE `cities` DISABLE KEYS */;
INSERT INTO `cities` VALUES (1,'בני ברק',1),(2,'אשדוד',1),(3,'פתח תקוה',1),(4,'בית שמש',1),(5,'מודיעין עילית',1),(6,'אלעד',1);
/*!40000 ALTER TABLE `cities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `countries`
--

DROP TABLE IF EXISTS `countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `countries` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `short_name` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `dialing_code` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `countries`
--

LOCK TABLES `countries` WRITE;
/*!40000 ALTER TABLE `countries` DISABLE KEYS */;
INSERT INTO `countries` VALUES (1,'Israel',NULL,NULL);
/*!40000 ALTER TABLE `countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dental_health_support_request`
--

DROP TABLE IF EXISTS `dental_health_support_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `dental_health_support_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `voucher_number` int(11) DEFAULT NULL,
  `realization_date` datetime DEFAULT NULL,
  `patient_name` varchar(100) COLLATE utf8_bin NOT NULL,
  `age` decimal(4,1) NOT NULL,
  `family_relation_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `branch_id` int(11) NOT NULL,
  `details` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `date` datetime NOT NULL,
  `current_status_id` int(11) NOT NULL,
  `is_approved` tinyint(1) DEFAULT NULL,
  `digital_signature` varbinary(3000) DEFAULT NULL,
  `is_canceled` tinyint(1) DEFAULT '0',
  `reason_is_approved` varchar(2000) COLLATE utf8_bin DEFAULT NULL,
  `is_disapproved_closed_request` tinyint(1) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `student_id_dental_idx` (`student_id`),
  KEY `branch_id_dental_idx` (`branch_id`),
  KEY `current_status_id_dental_idx` (`current_status_id`),
  KEY `family_relation_id_dental_idx` (`family_relation_id`),
  CONSTRAINT `branch_id_dental` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `current_status_id_dental` FOREIGN KEY (`current_status_id`) REFERENCES `request_status` (`id`),
  CONSTRAINT `family_relation_id_dental` FOREIGN KEY (`family_relation_id`) REFERENCES `family_relation` (`id`),
  CONSTRAINT `student_id_dental` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dental_health_support_request`
--

LOCK TABLES `dental_health_support_request` WRITE;
/*!40000 ALTER TABLE `dental_health_support_request` DISABLE KEYS */;
/*!40000 ALTER TABLE `dental_health_support_request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devices`
--

DROP TABLE IF EXISTS `devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `devices` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `device_type_id` int(11) NOT NULL,
  `serial_number` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `model` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `envierment_id_idx` (`device_type_id`),
  CONSTRAINT `envierment_id` FOREIGN KEY (`device_type_id`) REFERENCES `devices_types` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devices`
--

LOCK TABLES `devices` WRITE;
/*!40000 ALTER TABLE `devices` DISABLE KEYS */;
/*!40000 ALTER TABLE `devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devices_types`
--

DROP TABLE IF EXISTS `devices_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `devices_types` (
  `id` int(11) NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devices_types`
--

LOCK TABLES `devices_types` WRITE;
/*!40000 ALTER TABLE `devices_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `devices_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exams_rules`
--

DROP TABLE IF EXISTS `exams_rules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `exams_rules` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `branch_id` int(11) NOT NULL,
  `is_required_exams` tinyint(1) NOT NULL,
  `exams_per_period` int(11) NOT NULL,
  `exams_period` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exams_rules`
--

LOCK TABLES `exams_rules` WRITE;
/*!40000 ALTER TABLE `exams_rules` DISABLE KEYS */;
/*!40000 ALTER TABLE `exams_rules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `family_relation`
--

DROP TABLE IF EXISTS `family_relation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `family_relation` (
  `id` int(11) NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `family_relation`
--

LOCK TABLES `family_relation` WRITE;
/*!40000 ALTER TABLE `family_relation` DISABLE KEYS */;
/*!40000 ALTER TABLE `family_relation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `financial_support_request`
--

DROP TABLE IF EXISTS `financial_support_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `financial_support_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `approved_amount` decimal(8,2) DEFAULT NULL,
  `number_of_months_approved` int(11) DEFAULT NULL,
  `details` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `date` datetime NOT NULL,
  `is_approved` tinyint(1) DEFAULT NULL,
  `digital_signature` varbinary(3000) DEFAULT NULL,
  `branch_id` int(11) NOT NULL,
  `current_status_id` int(11) NOT NULL,
  `is_canceled` tinyint(1) DEFAULT '0',
  `reason_is_approved` varchar(2000) COLLATE utf8_bin DEFAULT NULL,
  `is_disapproved_closed_request` tinyint(1) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `student_id_financial_idx` (`student_id`),
  KEY `branch_id_financial_idx` (`branch_id`),
  KEY `current_status_id_financial_idx` (`current_status_id`),
  CONSTRAINT `branch_id_financial` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `current_status_id_financial` FOREIGN KEY (`current_status_id`) REFERENCES `request_status` (`id`),
  CONSTRAINT `student_id_financial` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `financial_support_request`
--

LOCK TABLES `financial_support_request` WRITE;
/*!40000 ALTER TABLE `financial_support_request` DISABLE KEYS */;
/*!40000 ALTER TABLE `financial_support_request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guarantors`
--

DROP TABLE IF EXISTS `guarantors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `guarantors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `last_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `identity_number` varchar(12) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `digital_signature` varbinary(3000) NOT NULL,
  `id_card` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `guarantee_deed_writing_date` datetime NOT NULL,
  `loan_note` varchar(100) COLLATE utf8_bin NOT NULL,
  `passport_number` varchar(12) COLLATE utf8_bin DEFAULT NULL,
  `address_id` int(11) NOT NULL,
  `phone_number` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `cellphone_number` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `addree_guarnator_idx` (`address_id`),
  CONSTRAINT `addree_guarnator` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guarantors`
--

LOCK TABLES `guarantors` WRITE;
/*!40000 ALTER TABLE `guarantors` DISABLE KEYS */;
/*!40000 ALTER TABLE `guarantors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `health_support_request`
--

DROP TABLE IF EXISTS `health_support_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `health_support_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `branch_id` int(11) NOT NULL,
  `current_status_id` int(11) NOT NULL,
  `family_relation_id` int(11) NOT NULL,
  `approved_amount` decimal(8,2) DEFAULT NULL,
  `realization_date` datetime DEFAULT NULL,
  `patient_name` varchar(100) COLLATE utf8_bin NOT NULL,
  `age` decimal(4,1) NOT NULL,
  `details` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `date` datetime NOT NULL,
  `is_approved` tinyint(1) DEFAULT NULL,
  `digital_signature` varbinary(3000) DEFAULT NULL,
  `student_id` int(11) NOT NULL,
  `is_canceled` tinyint(1) DEFAULT '0',
  `reason_is_approved` varchar(2000) COLLATE utf8_bin DEFAULT NULL,
  `is_disapproved_closed_request` tinyint(1) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `branch_id_health_idx` (`branch_id`),
  KEY `current_status_id_health_idx` (`current_status_id`),
  KEY `family_relation_id_health_idx` (`family_relation_id`),
  CONSTRAINT `branch_id_health` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `current_status_id_health` FOREIGN KEY (`current_status_id`) REFERENCES `request_status` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `health_support_request`
--

LOCK TABLES `health_support_request` WRITE;
/*!40000 ALTER TABLE `health_support_request` DISABLE KEYS */;
/*!40000 ALTER TABLE `health_support_request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `institutions`
--

DROP TABLE IF EXISTS `institutions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `institutions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `institutions`
--

LOCK TABLES `institutions` WRITE;
/*!40000 ALTER TABLE `institutions` DISABLE KEYS */;
/*!40000 ALTER TABLE `institutions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loan_guarantors`
--

DROP TABLE IF EXISTS `loan_guarantors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `loan_guarantors` (
  `loan_id` int(11) NOT NULL,
  `guarantor_id` int(11) NOT NULL,
  PRIMARY KEY (`loan_id`,`guarantor_id`),
  KEY `loan_id_idx` (`loan_id`),
  KEY `guarnator_id` (`guarantor_id`),
  CONSTRAINT `guarnator_id` FOREIGN KEY (`guarantor_id`) REFERENCES `guarantors` (`id`),
  CONSTRAINT `loan_id` FOREIGN KEY (`loan_id`) REFERENCES `loan_support_request` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loan_guarantors`
--

LOCK TABLES `loan_guarantors` WRITE;
/*!40000 ALTER TABLE `loan_guarantors` DISABLE KEYS */;
/*!40000 ALTER TABLE `loan_guarantors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loan_support_request`
--

DROP TABLE IF EXISTS `loan_support_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `loan_support_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `branch_id` int(11) NOT NULL,
  `current_status_id` int(11) NOT NULL,
  `amount_requested` int(11) NOT NULL,
  `amount_repayment_monthly` int(11) DEFAULT NULL,
  `date_returning_entire_amount` datetime DEFAULT NULL,
  `reason_is_approved` varchar(2000) COLLATE utf8_bin DEFAULT NULL,
  `is_disapproved_closed_request` tinyint(1) DEFAULT NULL,
  `details` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `date` datetime NOT NULL,
  `is_approved` tinyint(1) DEFAULT NULL,
  `digital_signature` varbinary(3000) DEFAULT NULL,
  `is_canceled` tinyint(1) DEFAULT '0',
  `number_approved_months` int(11) DEFAULT NULL,
  `approved_amount` decimal(8,2) DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `student_id_loan_idx` (`student_id`),
  KEY `branch_id_loan_idx` (`branch_id`),
  KEY `current_status_id_loan_idx` (`current_status_id`),
  CONSTRAINT `branch_id_loan` FOREIGN KEY (`branch_id`) REFERENCES `branches` (`id`),
  CONSTRAINT `current_status_id_loan` FOREIGN KEY (`current_status_id`) REFERENCES `request_status` (`id`),
  CONSTRAINT `student_id_loan` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loan_support_request`
--

LOCK TABLES `loan_support_request` WRITE;
/*!40000 ALTER TABLE `loan_support_request` DISABLE KEYS */;
/*!40000 ALTER TABLE `loan_support_request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `network`
--

DROP TABLE IF EXISTS `network`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `network` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `network`
--

LOCK TABLES `network` WRITE;
/*!40000 ALTER TABLE `network` DISABLE KEYS */;
/*!40000 ALTER TABLE `network` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `network_institutions`
--

DROP TABLE IF EXISTS `network_institutions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `network_institutions` (
  `network_id` int(11) NOT NULL,
  `institution_id` int(11) NOT NULL,
  PRIMARY KEY (`network_id`,`institution_id`),
  KEY `institution_id_network_idx` (`institution_id`),
  CONSTRAINT `institution_id_network` FOREIGN KEY (`institution_id`) REFERENCES `institutions` (`id`),
  CONSTRAINT `network_id` FOREIGN KEY (`network_id`) REFERENCES `network` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `network_institutions`
--

LOCK TABLES `network_institutions` WRITE;
/*!40000 ALTER TABLE `network_institutions` DISABLE KEYS */;
/*!40000 ALTER TABLE `network_institutions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_process_info`
--

DROP TABLE IF EXISTS `request_process_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `request_process_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `support_request_id` int(11) NOT NULL,
  `support_type_id` int(11) NOT NULL,
  `user_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `previous_status_id` int(11) NOT NULL,
  `next_status_id` int(11) DEFAULT NULL,
  `current_status_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `previous_status_id_idx` (`previous_status_id`),
  KEY `next_status_id_idx` (`next_status_id`),
  KEY `support_type_id_idx` (`support_type_id`),
  KEY `current_status_id_request_idx` (`current_status_id`),
  CONSTRAINT `current_status_id_request` FOREIGN KEY (`current_status_id`) REFERENCES `request_status` (`id`),
  CONSTRAINT `next_status_id` FOREIGN KEY (`next_status_id`) REFERENCES `request_status` (`id`),
  CONSTRAINT `previous_status_id` FOREIGN KEY (`previous_status_id`) REFERENCES `request_status` (`id`),
  CONSTRAINT `previous_status_id_reqest` FOREIGN KEY (`previous_status_id`) REFERENCES `request_status` (`id`),
  CONSTRAINT `support_type_id` FOREIGN KEY (`support_type_id`) REFERENCES `support_types` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_process_info`
--

LOCK TABLES `request_process_info` WRITE;
/*!40000 ALTER TABLE `request_process_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_process_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_status`
--

DROP TABLE IF EXISTS `request_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `request_status` (
  `id` int(11) NOT NULL,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_status`
--

LOCK TABLES `request_status` WRITE;
/*!40000 ALTER TABLE `request_status` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `roles` (
  `id` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `name` varchar(256) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scolarships`
--

DROP TABLE IF EXISTS `scolarships`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `scolarships` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `amount` decimal(9,2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scolarships`
--

LOCK TABLES `scolarships` WRITE;
/*!40000 ALTER TABLE `scolarships` DISABLE KEYS */;
/*!40000 ALTER TABLE `scolarships` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `streets`
--

DROP TABLE IF EXISTS `streets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `streets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `city_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `city_id_street_idx` (`city_id`),
  CONSTRAINT `city_street` FOREIGN KEY (`city_id`) REFERENCES `cities` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `streets`
--

LOCK TABLES `streets` WRITE;
/*!40000 ALTER TABLE `streets` DISABLE KEYS */;
INSERT INTO `streets` VALUES (1,'רבי עקיבא',1),(2,'אחיה השילוני',1),(3,'חגי',1),(4,'יהושפט המלך',2),(5,'האגוז',2),(6,'ברק בן אבינועם',2),(7,'האחים יטקובסקי',3),(8,'דגניה',3),(9,'הרב אורבך מאיר',3),(10,'דולב',4),(11,'נחל עין גדי',4),(12,'שדרות נהר הירדן',4),(13,'טורי זהב',5),(14,'שדרות הלל ושמאי',5),(15,'רש\"י\"',5),(16,'מאיר',6),(17,'רבי עקיבא',6),(18,'רב ניסים גאון',6),(19,'הבנים',2),(20,'נחל זהר ',4),(21,'שדרות יחזקאל',5),(22,'יהודה הנשיא',6),(23,'בר כוכבא',3);
/*!40000 ALTER TABLE `streets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_exams`
--

DROP TABLE IF EXISTS `student_exams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `student_exams` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `branch_exam_id` int(11) NOT NULL,
  `grade` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `student_id_exams_idx` (`student_id`),
  KEY `branch_exam_id_idx` (`branch_exam_id`),
  CONSTRAINT `branch_exam_id` FOREIGN KEY (`branch_exam_id`) REFERENCES `branch_exams` (`id`),
  CONSTRAINT `student_id_exams` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_exams`
--

LOCK TABLES `student_exams` WRITE;
/*!40000 ALTER TABLE `student_exams` DISABLE KEYS */;
/*!40000 ALTER TABLE `student_exams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_exceptions`
--

DROP TABLE IF EXISTS `student_exceptions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `student_exceptions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `branch_id` int(11) NOT NULL,
  `type` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `value` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `student_id_exceptions_idx` (`student_id`),
  KEY `branch_id_exceptions_idx` (`branch_id`),
  CONSTRAINT `student_id_exceptions` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_exceptions`
--

LOCK TABLES `student_exceptions` WRITE;
/*!40000 ALTER TABLE `student_exceptions` DISABLE KEYS */;
/*!40000 ALTER TABLE `student_exceptions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `students` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bank_id` int(11) NOT NULL,
  `children_number` int(11) DEFAULT NULL,
  `married_children_number` int(11) DEFAULT NULL,
  `phone_number` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `cellphone_number` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `identity_number` varchar(12) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `born_date` date NOT NULL,
  `account_number` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `wife_name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `job_wife` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `monthly_income` decimal(8,2) DEFAULT NULL,
  `image` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `id_card` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `travel_expenses` decimal(6,2) DEFAULT NULL,
  `address_id` int(11) NOT NULL,
  `fax_number` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `first_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `last_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `is_active` tinyint(1) NOT NULL,
  `travel_expenses_currency` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `monthly_income_currency` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `identity_number` (`identity_number`),
  KEY `bank_id_idx` (`bank_id`),
  KEY `address_id_student_idx` (`address_id`),
  CONSTRAINT `address_id_student` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`),
  CONSTRAINT `bank_id` FOREIGN KEY (`bank_id`) REFERENCES `banks` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=200 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,1,NULL,NULL,'490-379-2324','057-981-0810','361666387','1975-07-31','749752786','יהודית','סוכנת ביטוח',5725.00,'','',143.00,13,'','יצחק','קורן',0,'','\r'),(2,6,NULL,NULL,'887-850-8892','059-136-0864','621346603','1998-01-02','791280053','רות','סוכנת ביטוח',2897.00,'','',309.00,21,'','דוד','קליין',1,'','\r'),(3,1,NULL,NULL,'864-646-1735','056-216-7042','365866078','1988-06-20','977771277','אביגיל','מנהלת חשבונות',6625.00,'','',439.00,35,'','שמואל','סופר',1,'','\r'),(4,2,NULL,NULL,'299-536-8335','054-532-6820','520158084','1978-08-23','851156670','שרה','גננת',4778.00,'','',435.00,10,'','ישראל','אשכנזי',0,'','\r'),(5,4,NULL,NULL,'255-143-0650','056-151-7267','635099498','1989-07-09','641983653','איילה','מנהלת חשבונות',3406.00,'','',349.00,23,'','שמואל','פרידמן',0,'','\r'),(6,6,NULL,NULL,'225-315-7385','055-388-3897','474602437','1990-04-01','625106377','רחל','מנהלת',5410.00,'','',65.00,29,'','אברהם','רבינוביץ',0,'','\r'),(7,3,NULL,NULL,'999-487-6621','056-131-4687','767473129','1983-07-25','864602842','יהודית','לא עובדת',6885.00,'','',129.00,8,'','דניאל','וייס',0,'','\r'),(8,6,NULL,NULL,'838-307-4491','057-231-1209','652105133','1975-01-20','638854994','אדל','מורה',5051.00,'','',201.00,33,'','אורי','וייס',0,'','\r'),(9,6,NULL,NULL,'263-442-2241','059-040-7826','635371720','1998-07-30','934636094','אפרת','מנהלת',6255.00,'','',278.00,6,'','יוסף','שפירא',0,'','\r'),(10,4,NULL,NULL,'765-930-4798','053-247-3264','797606790','1982-09-25','997429231','אדל','פקידה',2636.00,'','',61.00,13,'','יהודה','לוין',0,'','\r'),(11,6,NULL,NULL,'778-985-6904','058-090-3485','880257448','1980-07-21','419307457','תמר','מאמנת',3842.00,'','',367.00,38,'','ישראל','סגל',1,'','\r'),(12,1,NULL,NULL,'485-519-8573','054-155-8987','681033679','1996-09-26','935834554','הודיה','גננת',4672.00,'','',339.00,38,'','איתמר','כהן',0,'','\r'),(13,3,NULL,NULL,'264-193-5362','051-155-9132','640055576','1989-09-07','302874950','רות','מאמנת',6530.00,'','',184.00,45,'','אברהם','רובין',1,'','\r'),(14,2,NULL,NULL,'532-757-7511','055-103-5242','822406699','1976-08-24','581491142','מיכל','מאמנת',3990.00,'','',55.00,17,'','איתמר','פלדמן',1,'','\r'),(15,4,NULL,NULL,'550-034-9957','053-723-7649','474092457','1980-11-10','320637906','רחל','מורה',3537.00,'','',205.00,15,'','משה','שחר',0,'','\r'),(16,1,NULL,NULL,'824-897-2901','055-788-2497','580052284','1975-05-21','382709418','מרים','גננת',5471.00,'','',443.00,14,'','יצחק','רוזנברג',1,'','\r'),(17,6,NULL,NULL,'938-787-5766','059-157-8727','769351297','1997-12-07','693314857','מרים','מאמנת',3576.00,'','',236.00,42,'','יאיר','קורן',1,'','\r'),(18,1,NULL,NULL,'309-437-2353','055-233-3874','397271085','1995-04-03','569758006','אסתר','מטפלת',5620.00,'','',323.00,34,'','רפאל','שטרן',1,'','\r'),(19,1,NULL,NULL,'291-238-6564','051-896-3820','718478671','1997-02-04','966478569','מרים','גננת',4510.00,'','',352.00,22,'','יהודה','גולדשטיין',1,'','\r'),(20,4,NULL,NULL,'121-156-9534','052-406-5546','697407557','1982-08-24','558135907','שרה','מאמנת',5717.00,'','',143.00,16,'','חיים','רוזנברג',0,'','\r'),(21,5,NULL,NULL,'822-178-9942','051-889-6684','646116940','1977-02-05','977143414','רות','פקידה',6171.00,'','',138.00,19,'','יוסף','לוי',1,'','\r'),(22,5,NULL,NULL,'223-499-8944','057-793-7128','467156337','1991-11-22','416411171','שירה','יועץ מס',4919.00,'','',168.00,22,'','יצחק','כהן',1,'','\r'),(23,1,NULL,NULL,'331-526-4136','053-610-1413','436773027','1995-10-28','234280845','מרים','לא עובדת',4153.00,'','',351.00,41,'','שמואל','רוזנברג',1,'','\r'),(24,2,NULL,NULL,'241-932-7103','056-207-9520','603109185','1979-04-20','817816214','יהודית','מנהלת',5848.00,'','',188.00,11,'','דניאל','רבינוביץ',1,'','\r'),(25,1,NULL,NULL,'850-252-5891','052-806-9987','497107506','1984-09-04','947447062','מלכה','מורה',3868.00,'','',167.00,20,'','דניאל','סופר',0,'','\r'),(26,3,NULL,NULL,'696-097-7525','051-074-1183','715825161','1984-03-25','898947234','חיה','מורה',3413.00,'','',409.00,40,'','אריאל','וייס',0,'','\r'),(27,4,NULL,NULL,'283-480-7771','052-032-0768','825795789','1983-07-23','972582918','יהודית','שפית',5088.00,'','',192.00,46,'','יהונתן','פרידמן',1,'','\r'),(28,5,NULL,NULL,'446-060-6051','055-620-9826','359608941','1999-04-09','159252427','יעל','מטפלת',5362.00,'','',255.00,35,'','יהודה','כהן',0,'','\r'),(29,2,NULL,NULL,'404-143-9743','056-364-9928','536669905','1977-06-19','911258582','אדל','מנהלת',4208.00,'','',302.00,18,'','יהודה','רבינוביץ',1,'','\r'),(30,5,NULL,NULL,'999-680-4849','054-816-7511','794109045','1980-01-07','954033479','תמר','יועץ מס',5414.00,'','',240.00,44,'','יאיר','גולדברג',0,'','\r'),(31,1,NULL,NULL,'798-020-8425','057-717-7744','553049319','1996-07-15','831810174','מלכה','מורה',4178.00,'','',86.00,13,'','שמואל','שחר',1,'','\r'),(32,2,NULL,NULL,'331-825-4897','051-053-5481','857309861','1986-08-08','417305582','יעל','אדריכלית',6463.00,'','',321.00,10,'','יהונתן','שפירא',0,'','\r'),(33,2,NULL,NULL,'861-151-9800','055-371-6459','760063311','1980-01-30','646484852','מיכל','אדריכלית',2822.00,'','',59.00,42,'','דוד','קורן',1,'','\r'),(34,5,NULL,NULL,'685-640-6112','056-298-2690','484739031','1993-08-29','747019803','אדל','מזכירה',2535.00,'','',378.00,20,'','יוסף','סופר',0,'','\r'),(35,4,NULL,NULL,'516-075-8293','053-097-8452','894064295','1991-03-11','547451832','רות','מורה',3382.00,'','',206.00,9,'','יוסף','גולדברג',1,'','\r'),(36,4,NULL,NULL,'530-777-7400','057-746-4351','395144023','1990-09-10','165348612','מלכה','מורה',2520.00,'','',193.00,45,'','יונתן','פרידמן',1,'','\r'),(37,2,NULL,NULL,'539-772-8712','055-842-6807','607122702','1975-07-24','492885884','אביגיל','פקידה',7000.00,'','',178.00,19,'','יעקב','קורן',0,'','\r'),(38,6,NULL,NULL,'579-601-8523','059-168-2336','795561972','1975-04-17','408300761','רבקה','סוכנת ביטוח',5558.00,'','',85.00,6,'','דניאל','לוי',0,'','\r'),(39,6,NULL,NULL,'407-683-6165','052-739-2806','501597415','1996-04-28','743063427','שירה','סוכנת ביטוח',2655.00,'','',133.00,14,'','יהודה','סגל',0,'','\r'),(40,2,NULL,NULL,'526-743-0177','059-317-5804','750896213','1993-01-14','205464053','שירה','אדריכלית',6989.00,'','',224.00,16,'','שמואל','רוזנברג',0,'','\r'),(41,3,NULL,NULL,'166-243-4873','059-403-5991','811542483','1990-12-10','362006196','אדל','מתכנתת',3884.00,'','',191.00,19,'','יאיר','שחר',0,'','\r'),(42,5,NULL,NULL,'420-845-2797','054-204-2363','547493789','1990-07-04','412850989','רבקה','מנהלת חשבונות',6922.00,'','',156.00,38,'','יהודה','לוין',0,'','\r'),(43,6,NULL,NULL,'257-109-5178','055-716-3503','760505922','1985-04-27','114020169','רבקה','לא עובדת',3373.00,'','',149.00,16,'','דוד','גרינברג',1,'','\r'),(44,2,NULL,NULL,'352-913-9799','059-679-2899','406016979','1991-04-23','139436430','הודיה','גננת',4379.00,'','',362.00,35,'','אברהם','חזן',0,'','\r'),(45,3,NULL,NULL,'341-866-5105','057-049-3484','544730400','1975-08-14','623408445','חנה','סוכנת ביטוח',3951.00,'','',271.00,7,'','אריאל','לוין',1,'','\r'),(46,2,NULL,NULL,'193-833-8086','054-555-9464','453882574','1984-02-04','912046863','תמר','מאמנת',4332.00,'','',320.00,40,'','אריאל','לוי',1,'','\r'),(47,4,NULL,NULL,'570-767-9704','053-957-2616','859586301','1988-04-30','829056531','יהודית','גננת',3986.00,'','',52.00,29,'','אורי','רוזנברג',0,'','\r'),(48,2,NULL,NULL,'665-872-8475','058-350-9349','530777387','1984-03-02','164818808','איילה','שפית',5242.00,'','',150.00,40,'','חיים','גולדשטיין',0,'','\r'),(49,2,NULL,NULL,'572-565-9759','051-458-3816','809451419','1978-08-12','389562849','איילה','סוכנת ביטוח',5948.00,'','',324.00,5,'','יעקב','גולדברג',0,'','\r'),(50,3,NULL,NULL,'630-113-7018','059-292-5658','431402624','1995-11-22','874516316','הודיה','מתכנתת',4975.00,'','',423.00,20,'','משה','גולדברג',1,'','\r'),(51,5,NULL,NULL,'109-550-1801','051-193-2473','532636060','1992-03-18','848672024','רבקה','מנהלת חשבונות',5238.00,'','',260.00,44,'','רפאל','סגל',0,'','\r'),(52,5,NULL,NULL,'429-979-5489','055-957-5129','757222155','1988-11-10','661856598','לאה','מטפלת',3953.00,'','',279.00,23,'','יונתן','כץ',0,'','\r'),(53,3,NULL,NULL,'728-630-6707','051-814-2819','875980645','1990-07-23','537784056','חיה','מתכנתת',3872.00,'','',108.00,37,'','יונתן','קליין',0,'','\r'),(54,2,NULL,NULL,'614-869-0792','051-416-1718','454352487','1984-06-03','872662565','שרה','מתכנתת',5141.00,'','',182.00,16,'','רפאל','כץ',0,'','\r'),(55,1,NULL,NULL,'198-705-1759','058-698-7877','610333595','1996-04-13','826253375','הודיה','שפית',4302.00,'','',80.00,5,'','אליה','כץ',1,'','\r'),(56,2,NULL,NULL,'194-636-8387','056-119-0451','472989400','1994-04-19','555578236','איילה','מתכנתת',4631.00,'','',189.00,31,'','מיכאל','רבינוביץ',0,'','\r'),(57,2,NULL,NULL,'698-616-5318','053-914-3640','654884003','1979-08-03','553501110','חנה','פקידה',5878.00,'','',179.00,5,'','חיים','שפירא',1,'','\r'),(58,3,NULL,NULL,'244-131-3555','052-329-5117','667815556','1986-04-21','594336950','יהודית','סוכנת ביטוח',3878.00,'','',321.00,38,'','אריאל','רובין',1,'','\r'),(59,6,NULL,NULL,'215-947-7830','059-950-3668','829506486','1996-07-26','854582291','איילה','מנהלת חשבונות',5024.00,'','',143.00,4,'','מיכאל','כהן',1,'','\r'),(60,4,NULL,NULL,'320-454-1922','052-176-9770','700167278','1983-01-01','677529650','יעל','מנהלת',6073.00,'','',404.00,34,'','רפאל','שפירא',1,'','\r'),(61,6,NULL,NULL,'116-481-1063','057-434-1703','373720077','1981-11-02','316653431','יהודית','מנהלת',4335.00,'','',54.00,23,'','שלמה','רבינוביץ',0,'','\r'),(62,1,NULL,NULL,'626-324-2287','058-577-6730','392413845','1990-09-25','694672844','איילה','פקידה',4291.00,'','',250.00,47,'','אריאל','קורן',0,'','\r'),(63,5,NULL,NULL,'487-540-7883','054-537-4330','702273346','1988-01-22','665064656','מלכה','יועץ מס',4516.00,'','',267.00,14,'','יהודה','קליין',1,'','\r'),(64,4,NULL,NULL,'160-271-5228','056-472-7329','672022346','1978-12-10','286899184','רות','מורה',6116.00,'','',134.00,12,'','יהודה','גרינברג',0,'','\r'),(65,3,NULL,NULL,'966-615-9290','059-213-5779','393322712','1983-08-29','349163477','הודיה','מתכנתת',5252.00,'','',261.00,33,'','שמעון','רוזנברג',1,'','\r'),(66,2,NULL,NULL,'699-223-7306','051-426-0446','481504170','1995-05-23','726662812','מרים','גננת',5033.00,'','',319.00,16,'','יונתן','קורן',1,'','\r'),(67,6,NULL,NULL,'108-742-2183','057-380-2738','849517714','1995-09-07','686443826','תמר','מנהלת',5102.00,'','',353.00,49,'','איתמר','שטרן',0,'','\r'),(68,3,NULL,NULL,'121-563-1334','053-494-0594','501439134','1991-10-16','610275302','רחל','מזכירה',6534.00,'','',327.00,47,'','יהודה','גולדשטיין',1,'','\r'),(69,3,NULL,NULL,'974-047-0414','058-598-7723','439282308','1981-11-20','442928427','אביגיל','יועץ מס',3158.00,'','',96.00,49,'','יוסף','שחר',1,'','\r'),(70,5,NULL,NULL,'451-815-1704','057-916-8860','440406799','1994-11-10','989043651','לאה','אדריכלית',5793.00,'','',374.00,4,'','רפאל','קליין',0,'','\r'),(71,3,NULL,NULL,'304-416-5114','052-935-2581','610731550','1980-01-11','425960443','אפרת','מנהלת',4431.00,'','',376.00,11,'','יוסף','רובין',1,'','\r'),(72,5,NULL,NULL,'983-513-2731','051-076-4766','808754918','1996-04-18','237880719','הדסה','אדריכלית',3568.00,'','',130.00,49,'','דוד','רובין',0,'','\r'),(73,3,NULL,NULL,'818-420-7180','057-111-4475','594338783','1981-05-22','567615836','אפרת','מאמנת',6439.00,'','',329.00,13,'','אורי','רובין',1,'','\r'),(74,2,NULL,NULL,'981-301-1868','054-852-6736','505038909','1979-09-08','448633071','חנה','מנהלת',2918.00,'','',413.00,2,'','חיים','חזן',0,'','\r'),(75,6,NULL,NULL,'856-499-2615','056-365-7307','511670050','1986-02-05','341006850','תמר','סוכנת ביטוח',3111.00,'','',373.00,23,'','רפאל','קורן',1,'','\r'),(76,6,NULL,NULL,'294-645-5111','056-185-9251','786139095','1989-08-25','486090876','מרים','מזכירה',6171.00,'','',98.00,3,'','יהודה','סופר',0,'','\r'),(77,2,NULL,NULL,'684-401-8561','058-350-9868','437050628','1997-01-29','930311312','מלכה','לא עובדת',5444.00,'','',419.00,26,'','אריאל','כץ',1,'','\r'),(78,6,NULL,NULL,'337-473-4265','058-592-5177','620126925','1976-04-08','825556876','מרים','יועץ מס',2572.00,'','',271.00,27,'','אליה','וייס',1,'','\r'),(79,4,NULL,NULL,'971-475-2962','052-156-1900','828805702','1983-02-17','998725166','שירה','גננת',6478.00,'','',177.00,6,'','איתמר','פלדמן',1,'','\r'),(80,3,NULL,NULL,'745-446-0758','051-409-6152','741261927','1977-08-31','719146284','חנה','יועץ מס',5061.00,'','',340.00,49,'','דוד','וייס',1,'','\r'),(81,6,NULL,NULL,'166-392-5171','057-832-4858','654486866','1989-08-03','637650159','יהודית','מורה',3578.00,'','',88.00,29,'','דוד','כץ',0,'','\r'),(82,2,NULL,NULL,'488-570-4134','058-372-6544','554223078','1988-01-04','510761926','לאה','מנהלת',3334.00,'','',307.00,38,'','דניאל','וייס',0,'','\r'),(83,2,NULL,NULL,'892-168-1694','055-083-7205','557959605','1995-05-19','551371945','לאה','לא עובדת',2586.00,'','',55.00,22,'','ישראל','אשכנזי',0,'','\r'),(84,2,NULL,NULL,'642-790-3091','054-185-1213','695434994','1979-04-06','685884145','רחל','מזכירה',3298.00,'','',331.00,34,'','שלמה','חזן',1,'','\r'),(85,6,NULL,NULL,'415-359-7472','057-074-0005','517031372','1977-12-09','240039221','יעל','פקידה',4674.00,'','',415.00,2,'','אריאל','סופר',0,'','\r'),(86,4,NULL,NULL,'343-178-8903','051-946-8337','838416315','1981-06-26','347537137','מרים','אדריכלית',5037.00,'','',216.00,17,'','איתמר','כהן',0,'','\r'),(87,2,NULL,NULL,'546-671-5269','052-026-1838','530845139','1982-09-14','974911245','מלכה','מנהלת',4931.00,'','',433.00,29,'','אליה','גולדברג',0,'','\r'),(88,4,NULL,NULL,'507-935-0089','058-778-0506','544050083','1983-10-06','452950548','רחל','אדריכלית',4952.00,'','',170.00,25,'','יוסף','שטרן',1,'','\r'),(89,3,NULL,NULL,'277-204-7017','057-596-1001','551013844','1989-03-30','190008973','יעל','מנהלת חשבונות',6247.00,'','',291.00,14,'','אורי','כץ',0,'','\r'),(90,4,NULL,NULL,'528-850-2665','051-160-4588','374640195','1978-07-13','432644369','חיה','מזכירה',3565.00,'','',239.00,37,'','יהונתן','שטרן',1,'','\r'),(91,6,NULL,NULL,'359-900-8902','058-593-1468','591474966','1977-01-17','548712887','לאה','מאמנת',4414.00,'','',437.00,16,'','יונתן','גולדברג',1,'','\r'),(92,3,NULL,NULL,'594-683-5607','056-501-3250','427846489','1994-03-26','866084613','שירה','מטפלת',6620.00,'','',100.00,37,'','יהודה','פרידמן',0,'','\r'),(93,6,NULL,NULL,'337-896-9953','053-505-0878','636116849','1985-01-05','763890838','אדל','מנהלת',5714.00,'','',105.00,36,'','שמעון','גולדשטיין',1,'','\r'),(94,3,NULL,NULL,'881-809-1860','056-423-8880','658246237','1994-03-12','754851617','יהודית','פקידה',4618.00,'','',395.00,48,'','יהונתן','כץ',0,'','\r'),(95,2,NULL,NULL,'892-652-4500','055-250-0623','706302998','1999-03-05','470824905','מרים','אדריכלית',5017.00,'','',198.00,14,'','יהודה','קליין',0,'','\r'),(96,6,NULL,NULL,'733-415-6365','059-577-4969','726496333','1985-09-24','674616360','יעל','מורה',5644.00,'','',330.00,19,'','מיכאל','פרידמן',1,'','\r'),(97,6,NULL,NULL,'875-492-6617','059-872-0061','842902995','1987-08-26','113141582','רבקה','מטפלת',5997.00,'','',354.00,8,'','אליה','גולדשטיין',0,'','\r'),(98,6,NULL,NULL,'957-546-3042','053-564-5492','382329434','1977-10-15','787397368','אדל','מטפלת',5776.00,'','',324.00,16,'','ישראל','שחר',0,'','\r'),(99,2,NULL,NULL,'739-329-1106','058-425-0622','737814979','1990-10-25','637789762','הודיה','מורה',4728.00,'','',85.00,7,'','אברהם','וייס',1,'','\r'),(100,1,NULL,NULL,'361-821-6886','054-964-3306','869150070','1996-06-11','769350615','איילה','אדריכלית',5912.00,'','',116.00,11,'','יונתן','גולדברג',0,'','\r'),(101,6,NULL,NULL,'393-095-6748','059-714-9094','790216883','1977-06-15','271082293','חנה','מטפלת',5639.00,'','',58.00,15,'','יוסף','שפירא',1,'','\r'),(102,5,NULL,NULL,'696-279-6327','054-964-7030','783479879','1976-03-19','345942842','שרה','מנהלת חשבונות',4604.00,'','',241.00,47,'','יהודה','פרידמן',1,'','\r'),(103,6,NULL,NULL,'464-121-2862','053-684-5118','636853498','1984-01-25','256538982','איילה','מאמנת',5666.00,'','',272.00,20,'','יהונתן','שחר',0,'','\r'),(104,4,NULL,NULL,'216-768-2329','057-686-0437','395674199','1999-09-05','942618320','יעל','מנהלת',4211.00,'','',336.00,41,'','יוסף','גולדברג',0,'','\r'),(105,6,NULL,NULL,'403-839-2985','051-314-7810','438097026','1976-02-07','807828460','מיכל','אדריכלית',3031.00,'','',371.00,28,'','רפאל','גולדברג',0,'','\r'),(106,1,NULL,NULL,'949-606-9116','051-470-0974','826852838','1980-01-23','151213496','הדסה','מתכנתת',6276.00,'','',376.00,38,'','שמעון','גולדשטיין',0,'','\r'),(107,5,NULL,NULL,'812-412-9651','055-969-4490','499743959','1994-03-16','232805477','הדסה','מזכירה',3807.00,'','',78.00,40,'','שמואל','כץ',1,'','\r'),(108,3,NULL,NULL,'842-014-7949','056-803-9095','432851405','1996-05-14','232172379','הדסה','פקידה',2809.00,'','',347.00,41,'','יאיר','וייס',1,'','\r'),(109,2,NULL,NULL,'422-763-8453','054-832-8770','690428153','1979-02-10','308528552','רחל','שפית',2567.00,'','',434.00,28,'','אורי','רוזנברג',1,'','\r'),(110,3,NULL,NULL,'728-914-6201','059-137-6824','431056140','1999-02-10','854096538','מרים','מורה',3735.00,'','',374.00,8,'','יצחק','גולדשטיין',0,'','\r'),(111,1,NULL,NULL,'436-230-7098','059-604-7971','818835977','1983-01-30','963534379','אפרת','לא עובדת',6655.00,'','',293.00,33,'','דניאל','קורן',1,'','\r'),(112,2,NULL,NULL,'319-803-9582','053-411-7687','712587529','1997-01-11','615822478','תמר','מזכירה',4975.00,'','',124.00,24,'','יהונתן','חזן',1,'','\r'),(113,3,NULL,NULL,'231-273-8104','057-320-0252','827949777','1986-12-30','618934726','רבקה','סוכנת ביטוח',3109.00,'','',235.00,25,'','שלמה','גולדשטיין',0,'','\r'),(114,2,NULL,NULL,'642-173-5866','054-761-4568','800450761','1992-04-20','753433502','אדל','סוכנת ביטוח',4956.00,'','',144.00,46,'','אריאל','וייס',1,'','\r'),(115,4,NULL,NULL,'957-018-9484','053-512-6151','600560549','1991-01-25','369923391','חיה','מורה',6839.00,'','',148.00,7,'','אורי','קליין',1,'','\r'),(116,5,NULL,NULL,'498-033-1580','053-320-9757','673589985','1992-12-18','169155132','הדסה','מנהלת',2945.00,'','',183.00,19,'','אורי','וייס',1,'','\r'),(117,3,NULL,NULL,'990-339-1861','057-486-9612','548261338','1976-06-12','800151194','מיכל','מזכירה',2936.00,'','',160.00,33,'','דוד','שפירא',0,'','\r'),(118,5,NULL,NULL,'266-234-3538','059-928-9854','555003700','1995-03-05','660758226','מיכל','אדריכלית',6490.00,'','',433.00,46,'','אורי','גולדשטיין',0,'','\r'),(119,3,NULL,NULL,'479-666-1098','056-676-7562','379183424','1989-03-29','674940633','אפרת','שפית',2967.00,'','',272.00,30,'','שמעון','וייס',0,'','\r'),(120,6,NULL,NULL,'949-978-2396','056-768-6485','580300823','1978-01-15','491303500','חיה','פקידה',3521.00,'','',258.00,16,'','איתמר','לוין',0,'','\r'),(121,2,NULL,NULL,'133-525-6830','051-612-4625','670247860','1983-07-06','861712634','תמר','מטפלת',6348.00,'','',375.00,31,'','מיכאל','סגל',1,'','\r'),(122,1,NULL,NULL,'815-369-4960','056-528-1602','680232222','1982-02-10','394758008','חנה','שפית',3334.00,'','',362.00,19,'','חיים','רוזנברג',0,'','\r'),(123,3,NULL,NULL,'545-511-0018','051-399-7490','651698153','1985-02-23','736717977','אסתר','מורה',3552.00,'','',218.00,1,'','איתמר','פרידמן',0,'','\r'),(124,4,NULL,NULL,'943-496-7309','054-953-6580','851039209','1977-04-08','202721784','אביגיל','מזכירה',2782.00,'','',232.00,17,'','אריאל','גולדברג',1,'','\r'),(125,4,NULL,NULL,'312-200-7778','055-826-8334','813561122','1975-12-18','307271044','תמר','שפית',3491.00,'','',387.00,42,'','ישראל','שטרן',1,'','\r'),(126,2,NULL,NULL,'807-321-9122','056-240-8186','583913114','1990-09-15','152335970','אדל','מתכנתת',5511.00,'','',404.00,39,'','דניאל','רוזנברג',0,'','\r'),(127,4,NULL,NULL,'824-233-5554','059-728-1699','364192772','1992-12-07','490158357','אסתר','אדריכלית',6276.00,'','',251.00,44,'','אריאל','רבינוביץ',1,'','\r'),(128,2,NULL,NULL,'238-184-2423','057-368-3165','547066936','1994-06-26','171641780','לאה','סוכנת ביטוח',5619.00,'','',204.00,11,'','אליה','גרינברג',0,'','\r'),(129,4,NULL,NULL,'919-263-6913','058-610-0126','830949143','1983-02-16','677671481','חנה','לא עובדת',3932.00,'','',143.00,47,'','מיכאל','רובין',1,'','\r'),(130,1,NULL,NULL,'983-181-8555','057-597-1291','567585477','1991-04-28','329124712','רות','אדריכלית',3126.00,'','',297.00,3,'','יאיר','קורן',0,'','\r'),(131,6,NULL,NULL,'550-358-0910','053-372-9033','392813498','1996-01-19','673450019','חנה','לא עובדת',4440.00,'','',220.00,3,'','דוד','אשכנזי',0,'','\r'),(132,3,NULL,NULL,'353-878-3569','051-691-3568','793161580','1976-12-25','278598881','רחל','גננת',4272.00,'','',401.00,48,'','שמעון','גרינברג',1,'','\r'),(133,5,NULL,NULL,'528-944-1147','059-265-8106','642470479','1984-03-06','833827863','אביגיל','מאמנת',6048.00,'','',448.00,3,'','אורי','כץ',1,'','\r'),(134,4,NULL,NULL,'765-633-8184','052-395-2083','593628232','1983-12-07','602870803','אפרת','גננת',2844.00,'','',64.00,49,'','יונתן','שטרן',0,'','\r'),(135,2,NULL,NULL,'344-948-5347','056-270-0943','811795536','1977-02-28','935856919','מיכל','מורה',6300.00,'','',397.00,38,'','יאיר','לוין',0,'','\r'),(136,6,NULL,NULL,'549-448-0329','056-090-1353','771047487','1976-06-24','149157040','מלכה','מאמנת',4183.00,'','',196.00,12,'','שמואל','לוין',0,'','\r'),(137,3,NULL,NULL,'874-990-2853','059-736-0518','443314416','1978-11-23','929928280','שרה','מתכנתת',4498.00,'','',249.00,29,'','רפאל','גולדשטיין',1,'','\r'),(138,4,NULL,NULL,'221-676-8712','056-274-1988','736864002','1998-10-30','758717578','איילה','פקידה',4377.00,'','',389.00,20,'','אברהם','סגל',1,'','\r'),(139,2,NULL,NULL,'926-195-0038','056-342-7325','655595035','1999-11-10','993654177','חיה','מתכנתת',4790.00,'','',299.00,17,'','שלמה','לוין',0,'','\r'),(140,4,NULL,NULL,'111-369-4009','054-860-7477','855679371','1988-02-17','253022239','אסתר','שפית',6423.00,'','',96.00,3,'','יצחק','גרינברג',1,'','\r'),(141,5,NULL,NULL,'551-264-0014','052-559-3370','549333155','1989-05-08','763315110','יהודית','פקידה',5176.00,'','',140.00,35,'','יעקב','כץ',1,'','\r'),(142,2,NULL,NULL,'801-076-8026','055-340-8400','763254867','1992-09-26','659957213','מיכל','מנהלת',6894.00,'','',119.00,17,'','איתמר','לוי',0,'','\r'),(143,3,NULL,NULL,'189-513-2772','053-732-5805','760916802','1992-06-13','409850330','מלכה','מאמנת',4950.00,'','',53.00,18,'','יהודה','סופר',0,'','\r'),(144,6,NULL,NULL,'253-669-3768','055-300-2688','531382138','1980-09-19','110949504','יעל','יועץ מס',6330.00,'','',389.00,44,'','יהודה','וייס',0,'','\r'),(145,4,NULL,NULL,'584-622-1221','057-092-8048','411972302','1988-06-09','226571323','אדל','מנהלת חשבונות',6576.00,'','',135.00,43,'','יוסף','לוין',1,'','\r'),(146,2,NULL,NULL,'663-504-3845','057-013-1651','797979673','1976-07-06','706515086','אפרת','מורה',4796.00,'','',200.00,49,'','דניאל','פרידמן',0,'','\r'),(147,2,NULL,NULL,'701-517-8100','053-133-8664','421168533','1989-01-01','417862575','מרים','מאמנת',3654.00,'','',316.00,42,'','דוד','קליין',1,'','\r'),(148,4,NULL,NULL,'529-686-9876','056-974-3407','404968643','1976-05-30','924092765','מלכה','לא עובדת',5127.00,'','',365.00,16,'','יאיר','גולדברג',1,'','\r'),(149,6,NULL,NULL,'834-615-5939','059-317-4546','495041507','1976-11-22','137706535','יעל','מאמנת',4546.00,'','',65.00,41,'','אליה','פרידמן',0,'','\r'),(150,3,NULL,NULL,'875-521-2609','054-255-9983','477951565','1994-01-19','890094711','לאה','מתכנתת',4555.00,'','',230.00,24,'','איתמר','סגל',0,'','\r'),(151,5,NULL,NULL,'330-755-8293','058-787-9308','748743560','1975-05-04','223761107','מרים','שפית',3836.00,'','',97.00,38,'','שלמה','כהן',0,'','\r'),(152,4,NULL,NULL,'286-363-0641','058-683-6920','511191449','1987-01-03','999921770','רות','מנהלת',5195.00,'','',374.00,3,'','אליה','לוין',0,'','\r'),(153,1,NULL,NULL,'569-580-7952','053-497-1287','361869836','1982-01-31','210357361','לאה','יועץ מס',6961.00,'','',186.00,29,'','יהונתן','כהן',1,'','\r'),(154,3,NULL,NULL,'650-312-0954','057-542-7037','748373879','1999-07-17','339714556','אלישבע','לא עובדת',6162.00,'','',448.00,44,'','יצחק','סופר',0,'','\r'),(155,5,NULL,NULL,'169-157-7419','056-919-9008','507339982','1979-10-03','194908301','יעל','מנהלת',4456.00,'','',371.00,11,'','חיים','שחר',0,'','\r'),(156,3,NULL,NULL,'584-585-3457','057-922-0815','595299450','1982-09-14','168052156','יהודית','שפית',2519.00,'','',428.00,33,'','יעקב','קורן',0,'','\r'),(157,4,NULL,NULL,'294-851-5980','051-747-8625','768576577','1975-10-20','816974880','חנה','מורה',4446.00,'','',429.00,21,'','מיכאל','לוין',0,'','\r'),(158,3,NULL,NULL,'545-730-5817','054-749-3126','395609271','1999-06-06','505120591','מלכה','יועץ מס',2629.00,'','',337.00,44,'','שמעון','לוי',1,'','\r'),(159,2,NULL,NULL,'748-138-0484','054-195-0882','602752597','1979-01-27','755377385','חנה','מאמנת',5407.00,'','',289.00,41,'','חיים','רובין',0,'','\r'),(160,6,NULL,NULL,'946-070-5842','059-887-1020','422301561','1978-10-10','148160163','שרה','גננת',3661.00,'','',80.00,2,'','יצחק','אשכנזי',0,'','\r'),(161,5,NULL,NULL,'239-015-7260','054-091-6161','604019339','1979-11-28','798511819','יעל','יועץ מס',3081.00,'','',153.00,21,'','דניאל','רוזנברג',0,'','\r'),(162,2,NULL,NULL,'622-802-5801','054-831-0082','611071476','1999-04-13','512044131','יעל','אדריכלית',6340.00,'','',112.00,20,'','ישראל','גולדשטיין',1,'','\r'),(163,2,NULL,NULL,'962-809-9671','055-560-0330','553814509','1978-05-25','720564865','אדל','מנהלת',4474.00,'','',56.00,21,'','שמואל','רבינוביץ',0,'','\r'),(164,1,NULL,NULL,'386-514-1762','052-138-1929','826262982','1995-12-17','467119909','מרים','מזכירה',5502.00,'','',245.00,2,'','ישראל','קורן',0,'','\r'),(165,2,NULL,NULL,'473-531-3241','054-808-9915','808876971','1997-02-18','819630550','מרים','גננת',6561.00,'','',164.00,14,'','אברהם','פרידמן',1,'','\r'),(166,2,NULL,NULL,'901-311-6179','059-458-8777','497028855','1989-05-08','676955710','אלישבע','לא עובדת',2584.00,'','',179.00,29,'','רפאל','גולדברג',1,'','\r'),(167,5,NULL,NULL,'374-852-5291','052-329-7247','455547836','1992-03-20','649754386','שירה','מזכירה',5321.00,'','',420.00,8,'','יונתן','פלדמן',0,'','\r'),(168,4,NULL,NULL,'541-691-1012','051-649-2094','767846894','1992-02-19','133349289','שרה','מורה',2676.00,'','',175.00,12,'','דוד','קליין',1,'','\r'),(169,3,NULL,NULL,'254-813-4093','052-918-5447','850471562','1994-11-06','908187383','אפרת','מנהלת',2635.00,'','',157.00,32,'','יונתן','לוין',1,'','\r'),(170,5,NULL,NULL,'131-162-9004','056-447-5891','827999415','1988-04-20','422643559','יעל','מטפלת',3770.00,'','',255.00,43,'','אריאל','חזן',1,'','\r'),(171,1,NULL,NULL,'515-385-6993','058-247-3536','719350865','1976-10-21','463029428','תמר','מורה',3242.00,'','',319.00,5,'','שמעון','כהן',0,'','\r'),(172,2,NULL,NULL,'194-566-6464','052-873-5854','890358699','1978-08-06','610337013','אביגיל','מזכירה',5583.00,'','',147.00,8,'','יהונתן','גולדברג',0,'','\r'),(173,1,NULL,NULL,'246-975-1312','056-080-5128','873875621','1993-11-20','220104001','חיה','סוכנת ביטוח',4787.00,'','',150.00,48,'','יונתן','רובין',1,'','\r'),(174,5,NULL,NULL,'276-523-1026','051-684-0087','659571921','1978-06-23','560586122','חיה','גננת',5476.00,'','',274.00,27,'','מיכאל','לוין',0,'','\r'),(175,1,NULL,NULL,'451-683-9118','055-385-1497','700986061','1994-05-24','961779059','הדסה','יועץ מס',3885.00,'','',347.00,6,'','איתמר','לוין',0,'','\r'),(176,2,NULL,NULL,'299-809-0954','058-869-6351','478423771','1978-03-09','105284739','לאה','שפית',3513.00,'','',86.00,6,'','רפאל','אשכנזי',1,'','\r'),(177,5,NULL,NULL,'148-805-7072','052-201-8998','486605504','1986-05-11','487457677','הדסה','מזכירה',4664.00,'','',336.00,35,'','יצחק','אשכנזי',0,'','\r'),(178,6,NULL,NULL,'565-845-2440','053-342-6291','622396598','1990-08-09','124955840','שירה','מנהלת',5799.00,'','',431.00,22,'','יהונתן','חזן',1,'','\r'),(179,2,NULL,NULL,'742-627-4990','053-679-2656','816327210','1979-07-14','684283651','שרה','שפית',4662.00,'','',362.00,23,'','שמעון','גולדשטיין',0,'','\r'),(180,3,NULL,NULL,'783-005-9575','054-196-8330','377791208','1988-09-07','433259994','מיכל','יועץ מס',3667.00,'','',356.00,22,'','אליה','סופר',0,'','\r'),(181,5,NULL,NULL,'830-791-1088','055-413-4057','474643863','1991-06-23','177190763','יהודית','אדריכלית',3499.00,'','',321.00,19,'','אליה','לוי',1,'','\r'),(182,2,NULL,NULL,'358-534-9204','059-158-6550','849737897','1977-09-26','378340458','אלישבע','גננת',5882.00,'','',281.00,27,'','אליה','גולדברג',0,'','\r'),(183,4,NULL,NULL,'969-228-0765','059-969-8077','390306828','1990-04-30','674220017','מיכל','מזכירה',6640.00,'','',339.00,35,'','יעקב','פרידמן',0,'','\r'),(184,3,NULL,NULL,'589-915-6148','059-842-2941','662239199','1984-10-19','722783492','אביגיל','מתכנתת',2564.00,'','',336.00,19,'','איתמר','שפירא',1,'','\r'),(185,6,NULL,NULL,'669-967-5808','051-864-0951','811301614','1980-08-01','800559392','מיכל','לא עובדת',4520.00,'','',432.00,3,'','רפאל','קליין',0,'','\r'),(186,3,NULL,NULL,'436-708-3543','054-529-7593','824677005','1998-06-24','406941547','מלכה','מתכנתת',4705.00,'','',338.00,27,'','אליה','חזן',0,'','\r'),(187,6,NULL,NULL,'104-677-7870','053-340-4590','624344356','1982-09-06','761583937','שרה','מנהלת חשבונות',5468.00,'','',51.00,44,'','יצחק','סופר',1,'','\r'),(188,3,NULL,NULL,'892-859-6841','053-688-5311','712069026','1978-09-27','618612924','יהודית','מזכירה',6578.00,'','',66.00,46,'','דניאל','גרינברג',1,'','\r'),(189,3,NULL,NULL,'570-706-8501','059-661-7585','828183079','1980-09-08','266099494','שירה','מורה',6750.00,'','',239.00,19,'','דניאל','רובין',0,'','\r'),(190,1,NULL,NULL,'634-116-7497','051-153-3403','860914864','1996-05-12','373271076','יעל','מאמנת',2698.00,'','',306.00,19,'','יהודה','גרינברג',0,'','\r'),(191,5,NULL,NULL,'843-316-3152','051-361-9350','489529907','1995-01-23','572509711','שרה','פקידה',6741.00,'','',307.00,19,'','רפאל','פלדמן',1,'','\r'),(192,6,NULL,NULL,'267-660-6314','057-211-7758','751812247','1977-08-23','151139598','רות','מאמנת',6142.00,'','',156.00,13,'','שמואל','כהן',0,'','\r'),(193,6,NULL,NULL,'822-534-1902','052-079-3281','521896764','1987-06-26','154763959','רות','מאמנת',6263.00,'','',313.00,40,'','דוד','כהן',0,'','\r'),(194,4,NULL,NULL,'178-389-3830','052-079-3566','534012863','1983-11-28','604197722','תמר','שפית',4005.00,'','',156.00,29,'','יעקב','וייס',1,'','\r'),(195,4,NULL,NULL,'120-636-8994','059-470-5956','748566755','1989-10-07','250072976','חנה','גננת',5010.00,'','',248.00,43,'','דוד','סגל',1,'','\r'),(196,1,NULL,NULL,'508-837-0944','057-461-4694','591010424','1986-08-22','566526451','הדסה','מאמנת',4042.00,'','',448.00,47,'','שמואל','סגל',0,'','\r'),(197,3,NULL,NULL,'918-710-5360','055-032-0869','524779603','1997-10-13','890007464','שרה','מטפלת',3050.00,'','',152.00,33,'','שלמה','כהן',0,'','\r'),(198,1,NULL,NULL,'273-067-8748','053-454-8845','751755706','1992-06-22','585042727','חנה','שפית',6301.00,'','',446.00,26,'','דניאל','שפירא',0,'','\r'),(199,4,NULL,NULL,'786-849-7939','058-570-3032','739922815','1987-05-19','902385765','אסתר','פקידה',6551.00,'','',190.00,43,'','אריאל','לוין',0,'','\r');
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students_children`
--

DROP TABLE IF EXISTS `students_children`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `students_children` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_id` int(11) NOT NULL,
  `first_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `last_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `gender` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `age` decimal(4,1) NOT NULL,
  `status` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `student_id_children_idx` (`student_id`),
  CONSTRAINT `student_id_children` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=301 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students_children`
--

LOCK TABLES `students_children` WRITE;
/*!40000 ALTER TABLE `students_children` DISABLE KEYS */;
INSERT INTO `students_children` VALUES (1,191,'תמר','חזן','בת',0.0,'רוווק/ה'),(2,112,'הדסה','שטרן','בת',0.0,'רוווק/ה'),(3,46,'ישראל','פלדמן','בן',0.0,'רוווק/ה'),(4,93,'חיים','פלדמן','בן',0.0,'רוווק/ה'),(5,115,'יוסף','גולדברג','בן',0.0,'רוווק/ה'),(6,187,'חנה','חזן','בת',0.0,'רוווק/ה'),(7,17,'יהודה','שחר','בן',0.0,'רוווק/ה'),(8,105,'דניאל','שפירא','בן',0.0,'רוווק/ה'),(9,32,'רפאל','קורן','בן',0.0,'רוווק/ה'),(10,22,'איילה','גולדברג','בת',0.0,'רוווק/ה'),(11,57,'שמואל','לוין','בן',0.0,'רוווק/ה'),(12,36,'אסתר','גולדשטיין','בת',0.0,'רוווק/ה'),(13,71,'אברהם','שפירא','בן',0.0,'רוווק/ה'),(14,16,'איילה','קורן','בת',0.0,'רוווק/ה'),(15,132,'מיכאל','פלדמן','בן',0.0,'רוווק/ה'),(16,131,'מרים','רבינוביץ','בת',0.0,'רוווק/ה'),(17,187,'יוסף','חזן','בן',0.0,'רוווק/ה'),(18,20,'רות','סופר','בת',0.0,'רוווק/ה'),(19,94,'שמעון','שטרן','בן',0.0,'רוווק/ה'),(20,180,'שירה','שפירא','בת',0.0,'רוווק/ה'),(21,124,'מיכאל','גולדשטיין','בן',0.0,'רוווק/ה'),(22,80,'אליה','לוין','בן',0.0,'רוווק/ה'),(23,8,'מרים','לוי','בת',0.0,'רוווק/ה'),(24,143,'רות','שחר','בת',0.0,'רוווק/ה'),(25,197,'חנה','רובין','בת',0.0,'רוווק/ה'),(26,54,'יאיר','גולדברג','בן',0.0,'רוווק/ה'),(27,173,'שמעון','סגל','בן',0.0,'רוווק/ה'),(28,6,'יהודית','רבינוביץ','בת',0.0,'רוווק/ה'),(29,25,'תמר','קליין','בת',0.0,'רוווק/ה'),(30,24,'רפאל','אשכנזי','בן',0.0,'רוווק/ה'),(31,157,'אדל','אשכנזי','בת',0.0,'רוווק/ה'),(32,56,'אסתר','אשכנזי','בת',0.0,'רוווק/ה'),(33,73,'חיה','סופר','בת',0.0,'רוווק/ה'),(34,125,'אליה','גולדברג','בן',0.0,'רוווק/ה'),(35,80,'יהודה','לוין','בן',0.0,'רוווק/ה'),(36,80,'יעל','לוין','בת',0.0,'רוווק/ה'),(37,17,'דניאל','שחר','בן',0.0,'רוווק/ה'),(38,169,'שלמה','פלדמן','בן',0.0,'רוווק/ה'),(39,74,'רפאל','שפירא','בן',0.0,'רוווק/ה'),(40,160,'אורי','כהן','בן',0.0,'רוווק/ה'),(41,155,'אליה','גרינברג','בן',0.0,'רוווק/ה'),(42,27,'דניאל','סגל','בן',0.0,'רוווק/ה'),(43,69,'איילה','כץ','בת',0.0,'רוווק/ה'),(44,107,'תמר','לוין','בת',0.0,'רוווק/ה'),(45,143,'יעל','שחר','בת',0.0,'רוווק/ה'),(46,47,'דוד','כץ','בן',0.0,'רוווק/ה'),(47,54,'חיים','גולדברג','בן',0.0,'רוווק/ה'),(48,64,'אורי','כץ','בן',0.0,'רוווק/ה'),(49,114,'הדסה','קורן','בת',0.0,'רוווק/ה'),(50,131,'דניאל','רבינוביץ','בן',0.0,'רוווק/ה'),(51,170,'אביגיל','קורן','בת',0.0,'רוווק/ה'),(52,171,'יוסף','רבינוביץ','בן',0.0,'רוווק/ה'),(53,10,'מלכה','רבינוביץ','בת',0.0,'רוווק/ה'),(54,2,'מיכל','גולדברג','בת',0.0,'רוווק/ה'),(55,43,'שמואל','רוזנברג','בן',0.0,'רוווק/ה'),(56,87,'לאה','גולדשטיין','בת',0.0,'רוווק/ה'),(57,117,'שמואל','כהן','בן',0.0,'רוווק/ה'),(58,171,'רפאל','רבינוביץ','בן',0.0,'רוווק/ה'),(59,5,'מיכל','רוזנברג','בת',0.0,'רוווק/ה'),(60,108,'יהודית','קליין','בת',0.0,'רוווק/ה'),(61,83,'לאה','שטרן','בת',0.0,'רוווק/ה'),(62,87,'יעקב','גולדשטיין','בן',0.0,'רוווק/ה'),(63,50,'חנה','רבינוביץ','בת',0.0,'רוווק/ה'),(64,55,'אפרת','פלדמן','בת',0.0,'רוווק/ה'),(65,154,'יוסף','לוי','בן',0.0,'רוווק/ה'),(66,40,'אברהם','לוין','בן',0.0,'רוווק/ה'),(67,13,'שמואל','חזן','בן',0.0,'רוווק/ה'),(68,30,'אליה','חזן','בן',0.0,'רוווק/ה'),(69,40,'יהונתן','לוין','בן',0.0,'רוווק/ה'),(70,171,'יוסף','רבינוביץ','בן',0.0,'רוווק/ה'),(71,28,'אלישבע','פרידמן','בת',0.0,'רוווק/ה'),(72,155,'תמר','גרינברג','בת',0.0,'רוווק/ה'),(73,93,'שרה','פלדמן','בת',0.0,'רוווק/ה'),(74,82,'יאיר','גולדברג','בן',0.0,'רוווק/ה'),(75,129,'מרים','גולדשטיין','בת',0.0,'רוווק/ה'),(76,33,'איילה','גולדברג','בת',0.0,'רוווק/ה'),(77,63,'משה','רבינוביץ','בן',0.0,'רוווק/ה'),(78,95,'הודיה','רבינוביץ','בת',0.0,'רוווק/ה'),(79,102,'יוסף','חזן','בן',0.0,'רוווק/ה'),(80,35,'דניאל','סופר','בן',0.0,'רוווק/ה'),(81,152,'רבקה','אשכנזי','בת',0.0,'רוווק/ה'),(82,132,'רות','פלדמן','בת',0.0,'רוווק/ה'),(83,43,'דוד','רוזנברג','בן',0.0,'רוווק/ה'),(84,176,'איתמר','גרינברג','בן',0.0,'רוווק/ה'),(85,154,'יאיר','לוי','בן',0.0,'רוווק/ה'),(86,51,'אסתר','אשכנזי','בת',0.0,'רוווק/ה'),(87,163,'אסתר','קליין','בת',0.0,'רוווק/ה'),(88,112,'אסתר','שטרן','בת',0.0,'רוווק/ה'),(89,19,'שרה','קליין','בת',0.0,'רוווק/ה'),(90,22,'שמעון','גולדברג','בן',0.0,'רוווק/ה'),(91,103,'תמר','סגל','בת',0.0,'רוווק/ה'),(92,194,'שרה','פלדמן','בת',0.0,'רוווק/ה'),(93,162,'אסתר','אשכנזי','בת',0.0,'רוווק/ה'),(94,4,'איילה','גולדשטיין','בת',0.0,'רוווק/ה'),(95,162,'מלכה','אשכנזי','בת',0.0,'רוווק/ה'),(96,174,'רבקה','קליין','בת',0.0,'רוווק/ה'),(97,62,'שרה','וייס','בת',0.0,'רוווק/ה'),(98,80,'שירה','לוין','בת',0.0,'רוווק/ה'),(99,177,'יונתן','רוזנברג','בן',0.0,'רוווק/ה'),(100,181,'רחל','אשכנזי','בת',0.0,'רוווק/ה'),(101,32,'אפרת','קורן','בת',0.0,'רוווק/ה'),(102,131,'יוסף','רבינוביץ','בן',0.0,'רוווק/ה'),(103,39,'מיכאל','גרינברג','בן',0.0,'אלמנ/ה'),(104,35,'יהודה','סופר','בן',0.0,'רוווק/ה'),(105,93,'ישראל','פלדמן','בן',0.0,'רוווק/ה'),(106,191,'רבקה','חזן','בת',0.0,'רוווק/ה'),(107,110,'מלכה','וייס','בת',0.0,'רוווק/ה'),(108,116,'שמואל','שטרן','בן',0.0,'רוווק/ה'),(109,133,'חנה','חזן','בת',0.0,'רוווק/ה'),(110,103,'יהונתן','סגל','בן',0.0,'רוווק/ה'),(111,195,'יונתן','שחר','בן',0.0,'רוווק/ה'),(112,36,'רות','גולדשטיין','בת',0.0,'רוווק/ה'),(113,141,'מלכה','חזן','בת',0.0,'רוווק/ה'),(114,129,'משה','גולדשטיין','בן',0.0,'רוווק/ה'),(115,136,'אברהם','גרינברג','בן',0.0,'רוווק/ה'),(116,146,'יצחק','רוזנברג','בן',0.0,'רוווק/ה'),(117,81,'מרים','כץ','בת',0.0,'רוווק/ה'),(118,37,'חיים','רוזנברג','בן',0.0,'רוווק/ה'),(119,29,'אסתר','כץ','בת',0.0,'רוווק/ה'),(120,193,'ישראל','שחר','בן',0.0,'רוווק/ה'),(121,172,'יעל','וייס','בת',0.0,'רוווק/ה'),(122,171,'מיכל','רבינוביץ','בת',0.0,'רוווק/ה'),(123,137,'יהודה','סופר','בן',0.0,'רוווק/ה'),(124,86,'יונתן','כהן','בן',0.0,'רוווק/ה'),(125,93,'אליה','פלדמן','בן',0.0,'רוווק/ה'),(126,168,'אסתר','שטרן','בת',0.0,'רוווק/ה'),(127,48,'מיכל','קורן','בת',0.0,'רוווק/ה'),(128,17,'מיכל','שחר','בת',0.0,'רוווק/ה'),(129,138,'אברהם','פלדמן','בן',0.0,'רוווק/ה'),(130,73,'מיכל','סופר','בת',0.0,'רוווק/ה'),(131,87,'לאה','גולדשטיין','בת',0.0,'רוווק/ה'),(132,195,'מיכל','שחר','בת',0.0,'רוווק/ה'),(133,105,'אסתר','שפירא','בת',0.0,'רוווק/ה'),(134,47,'לאה','כץ','בת',0.0,'רוווק/ה'),(135,122,'יאיר','לוין','בן',0.0,'רוווק/ה'),(136,86,'יצחק','כהן','בן',0.0,'רוווק/ה'),(137,115,'יהודית','גולדברג','בת',0.0,'רוווק/ה'),(138,186,'רבקה','סגל','בת',0.0,'רוווק/ה'),(139,186,'רחל','סגל','בת',0.0,'רוווק/ה'),(140,108,'שמואל','קליין','בן',0.0,'רוווק/ה'),(141,123,'שמעון','שפירא','בן',0.0,'רוווק/ה'),(142,10,'יהונתן','רבינוביץ','בן',0.0,'רוווק/ה'),(143,34,'יאיר','רוזנברג','בן',0.0,'רוווק/ה'),(144,75,'חיים','גולדשטיין','בן',0.0,'רוווק/ה'),(145,74,'משה','שפירא','בן',0.0,'רוווק/ה'),(146,26,'מיכאל','אשכנזי','בן',0.0,'רוווק/ה'),(147,50,'יוסף','רבינוביץ','בן',0.0,'רוווק/ה'),(148,160,'אריאל','כהן','בן',0.0,'רוווק/ה'),(149,175,'אסתר','פלדמן','בת',0.0,'רוווק/ה'),(150,15,'יעקב','גולדברג','בן',0.0,'רוווק/ה'),(151,68,'רפאל','וייס','בן',0.0,'רוווק/ה'),(152,164,'אורי','רובין','בן',0.0,'רוווק/ה'),(153,169,'יוסף','פלדמן','בן',0.0,'רוווק/ה'),(154,100,'שמואל','אשכנזי','בן',0.0,'רוווק/ה'),(155,184,'הודיה','שפירא','בת',0.0,'רוווק/ה'),(156,55,'מלכה','פלדמן','בת',0.0,'רוווק/ה'),(157,52,'לאה','רוזנברג','בת',0.0,'רוווק/ה'),(158,168,'אלישבע','שטרן','בת',0.0,'רוווק/ה'),(159,77,'חיה','שפירא','בת',0.0,'רוווק/ה'),(160,145,'שמואל','רוזנברג','בן',0.0,'רוווק/ה'),(161,109,'לאה','לוין','בת',0.0,'רוווק/ה'),(162,49,'אסתר','לוין','בת',0.0,'רוווק/ה'),(163,11,'דניאל','כהן','בן',0.0,'רוווק/ה'),(164,85,'לאה','לוין','בת',0.0,'רוווק/ה'),(165,29,'חיה','כץ','בת',0.0,'רוווק/ה'),(166,121,'יצחק','פרידמן','בן',0.0,'רוווק/ה'),(167,87,'יוסף','גולדשטיין','בן',0.0,'רוווק/ה'),(168,142,'שרה','שטרן','בת',0.0,'רוווק/ה'),(169,107,'חיה','לוין','בת',0.0,'רוווק/ה'),(170,124,'יעל','גולדשטיין','בת',0.0,'רוווק/ה'),(171,14,'רבקה','פרידמן','בת',0.0,'רוווק/ה'),(172,101,'חיה','חזן','בת',0.0,'רוווק/ה'),(173,32,'אסתר','קורן','בת',0.0,'רוווק/ה'),(174,102,'אדל','חזן','בת',0.0,'רוווק/ה'),(175,130,'אסתר','פלדמן','בת',0.0,'רוווק/ה'),(176,178,'רבקה','גולדשטיין','בת',0.0,'רוווק/ה'),(177,84,'משה','חזן','בן',0.0,'רוווק/ה'),(178,16,'מרים','קורן','בת',0.0,'רוווק/ה'),(179,136,'משה','גרינברג','בן',0.0,'רוווק/ה'),(180,132,'חנה','פלדמן','בת',0.0,'רוווק/ה'),(181,52,'מרים','רוזנברג','בת',0.0,'רוווק/ה'),(182,58,'אדל','גולדשטיין','בת',0.0,'רוווק/ה'),(183,32,'איילה','קורן','בת',0.0,'רוווק/ה'),(184,56,'אברהם','אשכנזי','בן',0.0,'רוווק/ה'),(185,115,'רפאל','גולדברג','בן',0.0,'רוווק/ה'),(186,16,'יונתן','קורן','בן',0.0,'רוווק/ה'),(187,139,'אברהם','שחר','בן',0.0,'רוווק/ה'),(188,160,'רבקה','כהן','בת',0.0,'רוווק/ה'),(189,134,'תמר','כץ','בת',0.0,'רוווק/ה'),(190,10,'חיה','רבינוביץ','בת',0.0,'רוווק/ה'),(191,128,'יהונתן','גולדברג','בן',0.0,'רוווק/ה'),(192,10,'לאה','רבינוביץ','בת',0.0,'רוווק/ה'),(193,9,'רחל','וייס','בת',0.0,'רוווק/ה'),(194,136,'אורי','גרינברג','בן',0.0,'רוווק/ה'),(195,24,'שמעון','אשכנזי','בן',0.0,'רוווק/ה'),(196,125,'יוסף','גולדברג','בן',0.0,'רוווק/ה'),(197,132,'אריאל','פלדמן','בן',0.0,'רוווק/ה'),(198,197,'יעקב','רובין','בן',0.0,'רוווק/ה'),(199,57,'תמר','לוין','בת',0.0,'רוווק/ה'),(200,57,'יוסף','לוין','בן',0.0,'רוווק/ה'),(201,43,'דוד','רוזנברג','בן',0.0,'רוווק/ה'),(202,147,'לאה','שפירא','בת',0.0,'רוווק/ה'),(203,76,'יצחק','פרידמן','בן',0.0,'רוווק/ה'),(204,35,'מרים','סופר','בת',0.0,'רוווק/ה'),(205,55,'מיכאל','פלדמן','בן',0.0,'רוווק/ה'),(206,72,'רחל','כץ','בת',0.0,'רוווק/ה'),(207,37,'אברהם','רוזנברג','בן',0.0,'רוווק/ה'),(208,173,'אליה','סגל','בן',0.0,'רוווק/ה'),(209,138,'חיים','פלדמן','בן',0.0,'רוווק/ה'),(210,19,'הודיה','קליין','בת',0.0,'רוווק/ה'),(211,190,'שמעון','רובין','בן',0.0,'רוווק/ה'),(212,67,'הדסה','שפירא','בת',0.0,'רוווק/ה'),(213,70,'חיה','שחר','בת',0.0,'רוווק/ה'),(214,184,'אפרת','שפירא','בת',0.0,'רוווק/ה'),(215,159,'יעקב','שטרן','בן',0.0,'רוווק/ה'),(216,68,'חנה','וייס','בת',0.0,'רוווק/ה'),(217,195,'יעקב','שחר','בן',0.0,'רוווק/ה'),(218,91,'איילה','חזן','בת',0.0,'רוווק/ה'),(219,155,'רות','גרינברג','בת',0.0,'רוווק/ה'),(220,158,'ישראל','כץ','בן',0.0,'רוווק/ה'),(221,44,'אורי','כץ','בן',0.0,'רוווק/ה'),(222,55,'מרים','פלדמן','בת',0.0,'רוווק/ה'),(223,191,'מיכל','חזן','בת',0.0,'רוווק/ה'),(224,76,'יאיר','פרידמן','בן',0.0,'רוווק/ה'),(225,37,'מלכה','רוזנברג','בת',0.0,'רוווק/ה'),(226,198,'אברהם','קליין','בן',0.0,'רוווק/ה'),(227,27,'מיכל','סגל','בת',0.0,'רוווק/ה'),(228,169,'הדסה','פלדמן','בת',0.0,'רוווק/ה'),(229,54,'יהונתן','גולדברג','בן',0.0,'רוווק/ה'),(230,96,'רפאל','חזן','בן',0.0,'רוווק/ה'),(231,85,'אסתר','לוין','בת',0.0,'רוווק/ה'),(232,9,'משה','וייס','בן',0.0,'רוווק/ה'),(233,109,'אדל','לוין','בת',0.0,'רוווק/ה'),(234,73,'אורי','סופר','בן',0.0,'רוווק/ה'),(235,133,'לאה','חזן','בת',0.0,'רוווק/ה'),(236,64,'איילה','כץ','בת',0.0,'רוווק/ה'),(237,89,'אביגיל','סגל','בת',0.0,'רוווק/ה'),(238,62,'אדל','וייס','בת',0.0,'רוווק/ה'),(239,133,'יעל','חזן','בת',0.0,'רוווק/ה'),(240,14,'שמעון','פרידמן','בן',0.0,'רוווק/ה'),(241,172,'שירה','וייס','בת',0.0,'רוווק/ה'),(242,152,'יוסף','אשכנזי','בן',0.0,'רוווק/ה'),(243,23,'מיכל','שפירא','בת',0.0,'רוווק/ה'),(244,71,'רחל','שפירא','בת',0.0,'רוווק/ה'),(245,118,'יעקב','כץ','בן',0.0,'רוווק/ה'),(246,192,'חיה','סגל','בת',0.0,'רוווק/ה'),(247,139,'רבקה','שחר','בת',0.0,'רוווק/ה'),(248,51,'מיכל','אשכנזי','בת',0.0,'רוווק/ה'),(249,125,'רחל','גולדברג','בת',0.0,'רוווק/ה'),(250,126,'שרה','גולדברג','בת',0.0,'רוווק/ה'),(251,123,'חיים','שפירא','בן',0.0,'רוווק/ה'),(252,113,'מיכל','לוי','בת',0.0,'רוווק/ה'),(253,62,'יהודית','וייס','בת',0.0,'רוווק/ה'),(254,184,'חנה','שפירא','בת',0.0,'רוווק/ה'),(255,134,'אריאל','כץ','בן',0.0,'רוווק/ה'),(256,42,'אברהם','פלדמן','בן',0.0,'רוווק/ה'),(257,20,'חיה','סופר','בת',0.0,'רוווק/ה'),(258,107,'רות','לוין','בת',0.0,'רוווק/ה'),(259,145,'אפרת','רוזנברג','בת',0.0,'רוווק/ה'),(260,183,'אברהם','קורן','בן',0.0,'רוווק/ה'),(261,100,'חיה','אשכנזי','בת',0.0,'רוווק/ה'),(262,107,'חיים','לוין','בן',0.0,'רוווק/ה'),(263,68,'הדסה','וייס','בת',0.0,'רוווק/ה'),(264,35,'יהונתן','סופר','בן',0.0,'רוווק/ה'),(265,116,'דניאל','שטרן','בן',0.0,'רוווק/ה'),(266,60,'איתמר','שפירא','בן',0.0,'רוווק/ה'),(267,100,'שמעון','אשכנזי','בן',0.0,'רוווק/ה'),(268,7,'יונתן','וייס','בן',0.0,'רוווק/ה'),(269,91,'רפאל','חזן','בן',0.0,'רוווק/ה'),(270,37,'יהודית','רוזנברג','בת',0.0,'רוווק/ה'),(271,45,'יהודה','קליין','בן',0.0,'רוווק/ה'),(272,55,'מרים','פלדמן','בת',0.0,'רוווק/ה'),(273,86,'אסתר','כהן','בת',0.0,'רוווק/ה'),(274,117,'שמואל','כהן','בן',0.0,'רוווק/ה'),(275,19,'משה','קליין','בן',0.0,'רוווק/ה'),(276,168,'יעל','שטרן','בת',0.0,'רוווק/ה'),(277,126,'איילה','גולדברג','בת',0.0,'רוווק/ה'),(278,96,'דוד','חזן','בן',0.0,'רוווק/ה'),(279,13,'ישראל','חזן','בן',0.0,'רוווק/ה'),(280,82,'יהודית','גולדברג','בת',0.0,'רוווק/ה'),(281,145,'אביגיל','רוזנברג','בת',0.0,'רוווק/ה'),(282,155,'רות','גרינברג','בת',0.0,'רוווק/ה'),(283,113,'אפרת','לוי','בת',0.0,'רוווק/ה'),(284,51,'הודיה','אשכנזי','בת',0.0,'רוווק/ה'),(285,127,'רבקה','אשכנזי','בת',0.0,'רוווק/ה'),(286,13,'יהונתן','חזן','בן',0.0,'רוווק/ה'),(287,82,'יעל','גולדברג','בת',0.0,'רוווק/ה'),(288,99,'אסתר','קליין','בת',0.0,'רוווק/ה'),(289,140,'יהודה','קליין','בן',0.0,'רוווק/ה'),(290,127,'אסתר','אשכנזי','בת',0.0,'רוווק/ה'),(291,37,'מיכל','רוזנברג','בת',0.0,'רוווק/ה'),(292,15,'משה','גולדברג','בן',0.0,'רוווק/ה'),(293,36,'אדל','גולדשטיין','בת',0.0,'רוווק/ה'),(294,50,'חיה','רבינוביץ','בת',0.0,'רוווק/ה'),(295,42,'יעקב','פלדמן','בן',0.0,'רוווק/ה'),(296,107,'אליה','לוין','בן',0.0,'רוווק/ה'),(297,108,'לאה','קליין','בת',0.0,'רוווק/ה'),(298,112,'הדסה','שטרן','בת',0.0,'רוווק/ה'),(299,49,'אביגיל','לוין','בת',0.0,'רוווק/ה'),(300,104,'שלמה','קליין','בן',0.0,'רוווק/ה');
/*!40000 ALTER TABLE `students_children` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `study_path`
--

DROP TABLE IF EXISTS `study_path`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `study_path` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `study_path`
--

LOCK TABLES `study_path` WRITE;
/*!40000 ALTER TABLE `study_path` DISABLE KEYS */;
/*!40000 ALTER TABLE `study_path` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `support_types`
--

DROP TABLE IF EXISTS `support_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `support_types` (
  `id` int(11) NOT NULL,
  `name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `support_types`
--

LOCK TABLES `support_types` WRITE;
/*!40000 ALTER TABLE `support_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `support_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_claims`
--

DROP TABLE IF EXISTS `user_claims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user_claims` (
  `id` int(11) NOT NULL,
  `user_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `claim_type` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `claim_value` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Id` (`id`),
  KEY `UserId` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_claims`
--

LOCK TABLES `user_claims` WRITE;
/*!40000 ALTER TABLE `user_claims` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_claims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_extra_details`
--

DROP TABLE IF EXISTS `user_extra_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user_extra_details` (
  `user_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `identity_number` varchar(12) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `phone_number` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `cellphone_number` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `image` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `address_id` int(11) NOT NULL,
  `first_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `last_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  KEY `address_user_idx` (`address_id`),
  CONSTRAINT `address_user` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_extra_details`
--

LOCK TABLES `user_extra_details` WRITE;
/*!40000 ALTER TABLE `user_extra_details` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_extra_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_logins`
--

DROP TABLE IF EXISTS `user_logins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user_logins` (
  `login_provider` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `provider_key` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `user_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`login_provider`,`provider_key`,`user_id`),
  KEY `ApplicationUser_Logins` (`user_id`),
  CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_logins`
--

LOCK TABLES `user_logins` WRITE;
/*!40000 ALTER TABLE `user_logins` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_logins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_roles`
--

DROP TABLE IF EXISTS `user_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user_roles` (
  `user_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `role_id` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`user_id`,`role_id`),
  KEY `carrierRole_Users` (`role_id`),
  CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE,
  CONSTRAINT `carrierRole_Users` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_roles`
--

LOCK TABLES `user_roles` WRITE;
/*!40000 ALTER TABLE `user_roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `id` varchar(128) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `email` varchar(64) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `email_confirmed` tinyint(1) NOT NULL,
  `password_hash` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `security_stamp` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `phone_number` longtext CHARACTER SET utf8 COLLATE utf8_bin,
  `phone_number_confirmed` tinyint(1) DEFAULT NULL,
  `two_factor_enabled` tinyint(1) NOT NULL,
  `lockout_end_date_utc` datetime DEFAULT NULL,
  `lockout_enabled` tinyint(1) NOT NULL,
  `access_failed_count` int(11) NOT NULL,
  `user_name` varchar(256) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `password_created` datetime DEFAULT NULL,
  `password_expired` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-05 12:03:40
