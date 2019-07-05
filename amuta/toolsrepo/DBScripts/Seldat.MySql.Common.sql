-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema common
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema common
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `common` DEFAULT CHARACTER SET utf8 ;
USE `common` ;

-- -----------------------------------------------------
-- Table `common`.`levels`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`levels` (
  `id` VARCHAR(45) NOT NULL,
  `index` INT(11) NOT NULL,
  `title` VARCHAR(45) NULL DEFAULT NULL,
  `show_always` TINYINT(4) NULL DEFAULT NULL,
  `is_multiple` TINYINT(4) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `level_index_UNIQUE` (`index` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `common`.`chart_parameters`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`chart_parameters` (
  `id` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `level_id` INT(11) NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  INDEX `chart_level_idx` (`level_id` ASC),
  CONSTRAINT `chart_level`
    FOREIGN KEY (`level_id`)
    REFERENCES `common`.`levels` (`index`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `common`.`chart_parameters_relationships`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`chart_parameters_relationships` (
  `id` VARCHAR(45) NOT NULL,
  `parent` VARCHAR(45) NULL DEFAULT NULL,
  `son` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `parent_level_idx` (`parent` ASC),
  INDEX `son_level_idx` (`son` ASC),
  CONSTRAINT `parent_level`
    FOREIGN KEY (`parent`)
    REFERENCES `common`.`chart_parameters` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `son_level`
    FOREIGN KEY (`son`)
    REFERENCES `common`.`chart_parameters` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `common`.`chart_type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`chart_type` (
  `id` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `common`.`dashboards`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`dashboards` (
  `id` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `descriotion` VARCHAR(45) NOT NULL,
  `creation_date` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `common`.`charts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`charts` (
  `id` VARCHAR(45) NOT NULL,
  `chart_name` VARCHAR(45) NULL DEFAULT NULL,
  `chart_type` VARCHAR(45) NULL DEFAULT NULL,
  `show_by` VARCHAR(45) NOT NULL,
  `legend` LONGTEXT NOT NULL,
  `x_axis` VARCHAR(100) NULL DEFAULT NULL,
  `dashboard_id` VARCHAR(45) NULL DEFAULT NULL,
  `is_stacked` VARCHAR(45) NULL DEFAULT 'false',
  `date_range` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `chart_dashboard_idx` (`dashboard_id` ASC),
  CONSTRAINT `chart_dashboard`
    FOREIGN KEY (`dashboard_id`)
    REFERENCES `common`.`dashboards` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `common`.`employees_dashboards`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`employees_dashboards` (
  `user_id` VARCHAR(45) NOT NULL,
  `dashboard_id` VARCHAR(45) NOT NULL,
  `creation_date` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`, `dashboard_id`),
  INDEX `dashboard_idx` (`dashboard_id` ASC),
  CONSTRAINT `dashboard`
    FOREIGN KEY (`dashboard_id`)
    REFERENCES `common`.`dashboards` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `common`.`files`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `common`.`files` (
  `id` VARCHAR(45) NOT NULL,
  `provider_id` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `storage_provider_name` VARCHAR(45) NOT NULL,
  `creation_date` DATE NOT NULL,
  `extension` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
