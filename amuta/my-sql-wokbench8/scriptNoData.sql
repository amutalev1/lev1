-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema amuta
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema amuta
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `amuta` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin ;
USE `amuta` ;

-- -----------------------------------------------------
-- Table `amuta`.`countries`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`countries` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  `short_name` VARCHAR(50) NULL DEFAULT NULL,
  `dialing_code` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`cities`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`cities` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  `country_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `country_id_city_idx` (`country_id` ASC) VISIBLE,
  CONSTRAINT `country_city`
    FOREIGN KEY (`country_id`)
    REFERENCES `amuta`.`countries` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`streets`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`streets` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  `city_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `city_id_street_idx` (`city_id` ASC) VISIBLE,
  CONSTRAINT `city_street`
    FOREIGN KEY (`city_id`)
    REFERENCES `amuta`.`cities` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 24
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`address`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`address` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `country_id` INT(11) NOT NULL,
  `city_id` INT(11) NOT NULL,
  `neighborhood_name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `street_id` INT(11) NOT NULL,
  `house_number` INT(11) NOT NULL,
  `apartment_number` INT(11) NULL DEFAULT NULL,
  `zip_code` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `country_id_address_idx` (`country_id` ASC) VISIBLE,
  INDEX `city_id_address_idx` (`city_id` ASC) VISIBLE,
  INDEX `street_id_idx` (`street_id` ASC) VISIBLE,
  CONSTRAINT `city_id_address`
    FOREIGN KEY (`city_id`)
    REFERENCES `amuta`.`cities` (`id`),
  CONSTRAINT `country_id_address`
    FOREIGN KEY (`country_id`)
    REFERENCES `amuta`.`countries` (`id`),
  CONSTRAINT `street_id`
    FOREIGN KEY (`street_id`)
    REFERENCES `amuta`.`streets` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 57
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`attendance_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`attendance_types` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branch_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branch_types` (
  `id` INT(11) NOT NULL,
  `type` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`, `type`, `name`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`institutions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`institutions` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branches`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branches` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `type_id` INT(11) NOT NULL,
  `head_id` VARCHAR(128) CHARACTER SET 'utf8' NOT NULL,
  `address_id` INT(11) NOT NULL,
  `institution_id` INT(11) NOT NULL,
  `name` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  `opening_date` DATE NOT NULL,
  `students_number` INT(11) NOT NULL,
  `study_subjects` VARCHAR(500) CHARACTER SET 'utf8' NOT NULL,
  `is_active` TINYINT(1) NOT NULL DEFAULT '1',
  `image` VARCHAR(200) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `branch_type_id_idx` (`type_id` ASC) VISIBLE,
  INDEX `address_branch_idx` (`address_id` ASC) VISIBLE,
  INDEX `institution_id_branch_idx` (`institution_id` ASC) VISIBLE,
  CONSTRAINT `address_branch`
    FOREIGN KEY (`address_id`)
    REFERENCES `amuta`.`address` (`id`),
  CONSTRAINT `branch_type_id`
    FOREIGN KEY (`type_id`)
    REFERENCES `amuta`.`branch_types` (`id`),
  CONSTRAINT `institution_id_branch`
    FOREIGN KEY (`institution_id`)
    REFERENCES `amuta`.`institutions` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 22
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`devices_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`devices_types` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`devices`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`devices` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `device_type_id` INT(11) NOT NULL,
  `serial_number` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  `name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `model` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `envierment_id_idx` (`device_type_id` ASC) VISIBLE,
  CONSTRAINT `envierment_id`
    FOREIGN KEY (`device_type_id`)
    REFERENCES `amuta`.`devices_types` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`banks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`banks` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `bank_number` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `name` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `branch_number` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `address_id` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `address_bank_idx` (`address_id` ASC) VISIBLE,
  INDEX `address_id_banks_idx` (`address_id` ASC) VISIBLE,
  CONSTRAINT `address_bank`
    FOREIGN KEY (`address_id`)
    REFERENCES `amuta`.`address` (`id`),
  CONSTRAINT `address_id_banks`
    FOREIGN KEY (`address_id`)
    REFERENCES `amuta`.`address` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`students` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `bank_id` INT(11) NOT NULL,
  `children_number` INT(11) NULL DEFAULT NULL,
  `married_children_number` INT(11) NULL DEFAULT NULL,
  `phone_number` VARCHAR(20) CHARACTER SET 'utf8' NOT NULL,
  `cellphone_number` VARCHAR(20) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `identity_number` VARCHAR(12) CHARACTER SET 'utf8' NOT NULL,
  `born_date` DATE NOT NULL,
  `account_number` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  `wife_name` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `job_wife` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `monthly_income` DECIMAL(8,2) NULL DEFAULT NULL,
  `image` VARCHAR(200) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `id_card` VARCHAR(200) CHARACTER SET 'utf8' NOT NULL,
  `travel_expenses` DECIMAL(6,2) NULL DEFAULT NULL,
  `address_id` INT(11) NOT NULL,
  `fax_number` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `first_name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  `last_name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  `is_active` TINYINT(1) NOT NULL,
  `travel_expenses_currency` VARCHAR(45) NULL DEFAULT NULL,
  `monthly_income_currency` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `identity_number` (`identity_number` ASC) VISIBLE,
  INDEX `bank_id_idx` (`bank_id` ASC) VISIBLE,
  INDEX `address_id_student_idx` (`address_id` ASC) VISIBLE,
  CONSTRAINT `address_id_student`
    FOREIGN KEY (`address_id`)
    REFERENCES `amuta`.`address` (`id`),
  CONSTRAINT `bank_id`
    FOREIGN KEY (`bank_id`)
    REFERENCES `amuta`.`banks` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 200
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`attendance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`attendance` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `student_id` INT(11) NOT NULL,
  `branch_id` INT(11) NOT NULL,
  `time` DATETIME NOT NULL,
  `is_entry` TINYINT(1) NOT NULL,
  `user_logged_id` VARCHAR(128) CHARACTER SET 'utf8' NOT NULL,
  `device_id` INT(11) NOT NULL,
  `location_device` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `time_logged` DATETIME NOT NULL,
  `reason` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `is_approved` TINYINT(1) NULL DEFAULT NULL,
  `user_approved_id` VARCHAR(128) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `attendance_type_id` INT(11) NULL DEFAULT NULL,
  `is_active` TINYINT(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  INDEX `collel_id_idxx` (`branch_id` ASC) VISIBLE,
  INDEX `student_id_attendance_idx` (`student_id` ASC) VISIBLE,
  INDEX `device_id_idx` (`device_id` ASC) VISIBLE,
  INDEX `attendance_type_id_idx` (`attendance_type_id` ASC) VISIBLE,
  CONSTRAINT `attendance_type_id`
    FOREIGN KEY (`attendance_type_id`)
    REFERENCES `amuta`.`attendance_types` (`id`),
  CONSTRAINT `branch_id_attendance`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `device_id`
    FOREIGN KEY (`device_id`)
    REFERENCES `amuta`.`devices` (`id`),
  CONSTRAINT `student_id_attendance`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`attendance_rules`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`attendance_rules` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `branch_id` INT(11) NOT NULL,
  `maximum_lateness` INT(11) NOT NULL,
  `maximum_absences` INT(11) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = MyISAM
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branch_activity_hours`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branch_activity_hours` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `branch_id` INT(11) NOT NULL,
  `late_hour` TIME NOT NULL,
  `start_study_hours` TIME NOT NULL,
  `end_study_hours` TIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `branch_id_activity_hours_idx` (`branch_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_activity_hours`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 21
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branch_devices`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branch_devices` (
  `branch_id` INT(11) NOT NULL,
  `device_id` INT(11) NOT NULL,
  PRIMARY KEY (`branch_id`, `device_id`),
  INDEX `device_id_branch_idx` (`device_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_devices`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `device_id_branch`
    FOREIGN KEY (`device_id`)
    REFERENCES `amuta`.`devices` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branch_exams`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branch_exams` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `branch_id` INT(11) NOT NULL,
  `submit_exam_scholarship_addition` INT(11) NOT NULL,
  `failing_submit_exam_scholarship_reducing` INT(11) NOT NULL,
  `passed_exam_scholarship_addition` INT(11) NOT NULL,
  `not_passed_exam_scholarship_reducing` INT(11) NOT NULL,
  `pass_grade` DECIMAL(5,2) NOT NULL,
  `subject` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `branch_id_exams_idx` (`branch_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_exams`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branch_staff`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branch_staff` (
  `branch_id` INT(11) NOT NULL,
  `user_id` VARCHAR(128) CHARACTER SET 'utf8' NOT NULL,
  `role_id` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `is_contact` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`branch_id`, `user_id`, `role_id`),
  CONSTRAINT `branch_id_staff`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`study_path`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`study_path` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branch_study_path`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branch_study_path` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `branch_id` INT(11) NOT NULL,
  `study_path_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `branch_id_courses_idx` (`branch_id` ASC) VISIBLE,
  INDEX `study_track_idx` (`study_path_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_courses`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `study_path`
    FOREIGN KEY (`study_path_id`)
    REFERENCES `amuta`.`study_path` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 12
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`branch_students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`branch_students` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `student_id` INT(11) NOT NULL,
  `branch_id` INT(11) NOT NULL,
  `branch_study_path_id` INT(11) NULL DEFAULT NULL,
  `entry_hebrew_date` DATE NULL DEFAULT NULL,
  `entry_gregorian_date` DATE NULL DEFAULT NULL,
  `release_hebrew_date` DATE NULL DEFAULT NULL,
  `release_gregorian_date` DATE NULL DEFAULT NULL,
  `is_active` TINYINT(1) NOT NULL,
  `status` VARCHAR(20) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `student_id_branch_idx` (`student_id` ASC) VISIBLE,
  INDEX `branch_student_idx` (`branch_id` ASC) VISIBLE,
  INDEX `branch_study_path_idx` (`branch_study_path_id` ASC) VISIBLE,
  CONSTRAINT `branch_student`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `branch_study_path`
    FOREIGN KEY (`branch_study_path_id`)
    REFERENCES `amuta`.`branch_study_path` (`id`),
  CONSTRAINT `student_id_branch`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`request_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`request_status` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`family_relation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`family_relation` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`dental_health_support_request`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`dental_health_support_request` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `voucher_number` INT(11) NULL DEFAULT NULL,
  `realization_date` DATETIME NULL DEFAULT NULL,
  `patient_name` VARCHAR(100) NOT NULL,
  `age` DECIMAL(4,1) NOT NULL,
  `family_relation_id` INT(11) NOT NULL,
  `student_id` INT(11) NOT NULL,
  `branch_id` INT(11) NOT NULL,
  `details` VARCHAR(2000) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `date` DATETIME NOT NULL,
  `current_status_id` INT(11) NOT NULL,
  `is_approved` TINYINT(1) NULL DEFAULT NULL,
  `digital_signature` VARBINARY(3000) NULL DEFAULT NULL,
  `is_canceled` TINYINT(1) NULL DEFAULT '0',
  `reason_is_approved` VARCHAR(2000) NULL DEFAULT NULL,
  `is_disapproved_closed_request` TINYINT(1) NULL DEFAULT NULL,
  `is_active` TINYINT(1) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `student_id_dental_idx` (`student_id` ASC) VISIBLE,
  INDEX `branch_id_dental_idx` (`branch_id` ASC) VISIBLE,
  INDEX `current_status_id_dental_idx` (`current_status_id` ASC) VISIBLE,
  INDEX `family_relation_id_dental_idx` (`family_relation_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_dental`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `current_status_id_dental`
    FOREIGN KEY (`current_status_id`)
    REFERENCES `amuta`.`request_status` (`id`),
  CONSTRAINT `family_relation_id_dental`
    FOREIGN KEY (`family_relation_id`)
    REFERENCES `amuta`.`family_relation` (`id`),
  CONSTRAINT `student_id_dental`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`exams_rules`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`exams_rules` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `branch_id` INT(11) NOT NULL,
  `is_required_exams` TINYINT(1) NOT NULL,
  `exams_per_period` INT(11) NOT NULL,
  `exams_period` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`financial_support_request`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`financial_support_request` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `student_id` INT(11) NOT NULL,
  `approved_amount` DECIMAL(8,2) NULL DEFAULT NULL,
  `number_of_months_approved` INT(11) NULL DEFAULT NULL,
  `details` VARCHAR(2000) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `date` DATETIME NOT NULL,
  `is_approved` TINYINT(1) NULL DEFAULT NULL,
  `digital_signature` VARBINARY(3000) NULL DEFAULT NULL,
  `branch_id` INT(11) NOT NULL,
  `current_status_id` INT(11) NOT NULL,
  `is_canceled` TINYINT(1) NULL DEFAULT '0',
  `reason_is_approved` VARCHAR(2000) NULL DEFAULT NULL,
  `is_disapproved_closed_request` TINYINT(1) NULL DEFAULT NULL,
  `is_active` TINYINT(1) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `student_id_financial_idx` (`student_id` ASC) VISIBLE,
  INDEX `branch_id_financial_idx` (`branch_id` ASC) VISIBLE,
  INDEX `current_status_id_financial_idx` (`current_status_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_financial`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `current_status_id_financial`
    FOREIGN KEY (`current_status_id`)
    REFERENCES `amuta`.`request_status` (`id`),
  CONSTRAINT `student_id_financial`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`guarantors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`guarantors` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `last_name` VARCHAR(50) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `identity_number` VARCHAR(12) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL,
  `digital_signature` VARBINARY(3000) NOT NULL,
  `id_card` VARCHAR(100) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `guarantee_deed_writing_date` DATETIME NOT NULL,
  `loan_note` VARCHAR(100) NOT NULL,
  `passport_number` VARCHAR(12) NULL DEFAULT NULL,
  `address_id` INT(11) NOT NULL,
  `phone_number` VARCHAR(20) NULL DEFAULT NULL,
  `cellphone_number` VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `addree_guarnator_idx` (`address_id` ASC) VISIBLE,
  CONSTRAINT `addree_guarnator`
    FOREIGN KEY (`address_id`)
    REFERENCES `amuta`.`address` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`health_support_request`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`health_support_request` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `branch_id` INT(11) NOT NULL,
  `current_status_id` INT(11) NOT NULL,
  `family_relation_id` INT(11) NOT NULL,
  `approved_amount` DECIMAL(8,2) NULL DEFAULT NULL,
  `realization_date` DATETIME NULL DEFAULT NULL,
  `patient_name` VARCHAR(100) NOT NULL,
  `age` DECIMAL(4,1) NOT NULL,
  `details` VARCHAR(2000) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `date` DATETIME NOT NULL,
  `is_approved` TINYINT(1) NULL DEFAULT NULL,
  `digital_signature` VARBINARY(3000) NULL DEFAULT NULL,
  `student_id` INT(11) NOT NULL,
  `is_canceled` TINYINT(1) NULL DEFAULT '0',
  `reason_is_approved` VARCHAR(2000) NULL DEFAULT NULL,
  `is_disapproved_closed_request` TINYINT(1) NULL DEFAULT NULL,
  `is_active` TINYINT(1) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `branch_id_health_idx` (`branch_id` ASC) VISIBLE,
  INDEX `current_status_id_health_idx` (`current_status_id` ASC) VISIBLE,
  INDEX `family_relation_id_health_idx` (`family_relation_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_health`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `current_status_id_health`
    FOREIGN KEY (`current_status_id`)
    REFERENCES `amuta`.`request_status` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`loan_support_request`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`loan_support_request` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `student_id` INT(11) NOT NULL,
  `branch_id` INT(11) NOT NULL,
  `current_status_id` INT(11) NOT NULL,
  `amount_requested` INT(11) NOT NULL,
  `amount_repayment_monthly` INT(11) NULL DEFAULT NULL,
  `date_returning_entire_amount` DATETIME NULL DEFAULT NULL,
  `reason_is_approved` VARCHAR(2000) NULL DEFAULT NULL,
  `is_disapproved_closed_request` TINYINT(1) NULL DEFAULT NULL,
  `details` VARCHAR(2000) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `date` DATETIME NOT NULL,
  `is_approved` TINYINT(1) NULL DEFAULT NULL,
  `digital_signature` VARBINARY(3000) NULL DEFAULT NULL,
  `is_canceled` TINYINT(1) NULL DEFAULT '0',
  `number_approved_months` INT(11) NULL DEFAULT NULL,
  `approved_amount` DECIMAL(8,2) NULL DEFAULT NULL,
  `is_active` TINYINT(1) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `student_id_loan_idx` (`student_id` ASC) VISIBLE,
  INDEX `branch_id_loan_idx` (`branch_id` ASC) VISIBLE,
  INDEX `current_status_id_loan_idx` (`current_status_id` ASC) VISIBLE,
  CONSTRAINT `branch_id_loan`
    FOREIGN KEY (`branch_id`)
    REFERENCES `amuta`.`branches` (`id`),
  CONSTRAINT `current_status_id_loan`
    FOREIGN KEY (`current_status_id`)
    REFERENCES `amuta`.`request_status` (`id`),
  CONSTRAINT `student_id_loan`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`loan_guarantors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`loan_guarantors` (
  `loan_id` INT(11) NOT NULL,
  `guarantor_id` INT(11) NOT NULL,
  PRIMARY KEY (`loan_id`, `guarantor_id`),
  INDEX `loan_id_idx` (`loan_id` ASC) VISIBLE,
  INDEX `guarnator_id` (`guarantor_id` ASC) VISIBLE,
  CONSTRAINT `guarnator_id`
    FOREIGN KEY (`guarantor_id`)
    REFERENCES `amuta`.`guarantors` (`id`),
  CONSTRAINT `loan_id`
    FOREIGN KEY (`loan_id`)
    REFERENCES `amuta`.`loan_support_request` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`network`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`network` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`network_institutions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`network_institutions` (
  `network_id` INT(11) NOT NULL,
  `institution_id` INT(11) NOT NULL,
  PRIMARY KEY (`network_id`, `institution_id`),
  INDEX `institution_id_network_idx` (`institution_id` ASC) VISIBLE,
  CONSTRAINT `institution_id_network`
    FOREIGN KEY (`institution_id`)
    REFERENCES `amuta`.`institutions` (`id`),
  CONSTRAINT `network_id`
    FOREIGN KEY (`network_id`)
    REFERENCES `amuta`.`network` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`support_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`support_types` (
  `id` INT(11) NOT NULL,
  `name` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`request_process_info`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`request_process_info` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `support_request_id` INT(11) NOT NULL,
  `support_type_id` INT(11) NOT NULL,
  `user_id` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `previous_status_id` INT(11) NOT NULL,
  `next_status_id` INT(11) NULL DEFAULT NULL,
  `current_status_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `previous_status_id_idx` (`previous_status_id` ASC) VISIBLE,
  INDEX `next_status_id_idx` (`next_status_id` ASC) VISIBLE,
  INDEX `support_type_id_idx` (`support_type_id` ASC) VISIBLE,
  INDEX `current_status_id_request_idx` (`current_status_id` ASC) VISIBLE,
  CONSTRAINT `current_status_id_request`
    FOREIGN KEY (`current_status_id`)
    REFERENCES `amuta`.`request_status` (`id`),
  CONSTRAINT `next_status_id`
    FOREIGN KEY (`next_status_id`)
    REFERENCES `amuta`.`request_status` (`id`),
  CONSTRAINT `previous_status_id`
    FOREIGN KEY (`previous_status_id`)
    REFERENCES `amuta`.`request_status` (`id`),
  CONSTRAINT `previous_status_id_reqest`
    FOREIGN KEY (`previous_status_id`)
    REFERENCES `amuta`.`request_status` (`id`),
  CONSTRAINT `support_type_id`
    FOREIGN KEY (`support_type_id`)
    REFERENCES `amuta`.`support_types` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`roles` (
  `id` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `name` VARCHAR(256) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`scolarships`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`scolarships` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `amount` DECIMAL(9,2) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`student_exams`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`student_exams` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `student_id` INT(11) NOT NULL,
  `branch_exam_id` INT(11) NOT NULL,
  `grade` DECIMAL(5,2) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `student_id_exams_idx` (`student_id` ASC) VISIBLE,
  INDEX `branch_exam_id_idx` (`branch_exam_id` ASC) VISIBLE,
  CONSTRAINT `branch_exam_id`
    FOREIGN KEY (`branch_exam_id`)
    REFERENCES `amuta`.`branch_exams` (`id`),
  CONSTRAINT `student_id_exams`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`student_exceptions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`student_exceptions` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `student_id` INT(11) NOT NULL,
  `branch_id` INT(11) NOT NULL,
  `type` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `value` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `student_id_exceptions_idx` (`student_id` ASC) VISIBLE,
  INDEX `branch_id_exceptions_idx` (`branch_id` ASC) VISIBLE,
  CONSTRAINT `student_id_exceptions`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`students_children`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`students_children` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `student_id` INT(11) NOT NULL,
  `first_name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  `last_name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `gender` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `age` DECIMAL(4,1) NOT NULL,
  `status` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `student_id_children_idx` (`student_id` ASC) VISIBLE,
  CONSTRAINT `student_id_children`
    FOREIGN KEY (`student_id`)
    REFERENCES `amuta`.`students` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 301
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`user_claims`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`user_claims` (
  `id` INT(11) NOT NULL,
  `user_id` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `claim_type` LONGTEXT CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL,
  `claim_value` LONGTEXT CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `Id` (`id` ASC) VISIBLE,
  INDEX `UserId` (`user_id` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`user_extra_details`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`user_extra_details` (
  `user_id` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `identity_number` VARCHAR(12) CHARACTER SET 'utf8' NOT NULL,
  `phone_number` VARCHAR(20) CHARACTER SET 'utf8' NOT NULL,
  `cellphone_number` VARCHAR(20) CHARACTER SET 'utf8' NOT NULL,
  `image` VARCHAR(200) CHARACTER SET 'utf8' NOT NULL,
  `address_id` INT(11) NOT NULL,
  `first_name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  `last_name` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  `email` VARCHAR(64) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  INDEX `address_user_idx` (`address_id` ASC) VISIBLE,
  CONSTRAINT `address_user`
    FOREIGN KEY (`address_id`)
    REFERENCES `amuta`.`address` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`users` (
  `id` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `email` VARCHAR(64) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `email_confirmed` TINYINT(1) NOT NULL,
  `password_hash` LONGTEXT CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL,
  `security_stamp` LONGTEXT CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL,
  `phone_number` LONGTEXT CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL,
  `phone_number_confirmed` TINYINT(1) NULL DEFAULT NULL,
  `two_factor_enabled` TINYINT(1) NOT NULL,
  `lockout_end_date_utc` DATETIME NULL DEFAULT NULL,
  `lockout_enabled` TINYINT(1) NOT NULL,
  `access_failed_count` INT(11) NOT NULL,
  `user_name` VARCHAR(256) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `password_created` DATETIME NULL DEFAULT NULL,
  `password_expired` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`user_logins`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`user_logins` (
  `login_provider` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `provider_key` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `user_id` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  PRIMARY KEY (`login_provider`, `provider_key`, `user_id`),
  INDEX `ApplicationUser_Logins` (`user_id` ASC) VISIBLE,
  CONSTRAINT `ApplicationUser_Logins`
    FOREIGN KEY (`user_id`)
    REFERENCES `amuta`.`users` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `amuta`.`user_roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `amuta`.`user_roles` (
  `user_id` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  `role_id` VARCHAR(128) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NOT NULL,
  PRIMARY KEY (`user_id`, `role_id`),
  INDEX `carrierRole_Users` (`role_id` ASC) VISIBLE,
  CONSTRAINT `ApplicationUser_Roles`
    FOREIGN KEY (`user_id`)
    REFERENCES `amuta`.`users` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `carrierRole_Users`
    FOREIGN KEY (`role_id`)
    REFERENCES `amuta`.`roles` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
