CREATE SCHEMA if not exists `concesionario` DEFAULT CHARACTER SET utf8 ;
use concesionario;

CREATE TABLE if not exists `concesionario`.`marcas` (
  `id_marcas` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(500) NULL,
  `pais` VARCHAR(500) NULL,
  `anno_creacion` DATETIME NULL,
  PRIMARY KEY (`id_marcas`));
  
CREATE TABLE if not exists `concesionario`.`modelos` (
  `id_modelo` INT NOT NULL AUTO_INCREMENT,
  `id_marca` INT NOT NULL ,
  `modelo` VARCHAR(145) NULL,
  `motor` VARCHAR(145) NULL,
  PRIMARY KEY (`id_modelo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE if not exists `concesionario`.`vehiculos` (
  `id_vehiculo` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(145) NULL,
  `tipo` VARCHAR(145) NULL,
  `id_modelo` INT NULL,
  PRIMARY KEY (`id_vehiculo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

ALTER TABLE `concesionario`.`modelos` 
ADD INDEX `fk_1_idx` (`id_marca` ASC) VISIBLE;
;
ALTER TABLE `concesionario`.`modelos` 
ADD CONSTRAINT `fk_1`
  FOREIGN KEY (`id_marca`)
  REFERENCES `concesionario`.`marcas` (`id_marcas`)
  ON DELETE CASCADE
  ON UPDATE NO ACTION;

ALTER TABLE `concesionario`.`vehiculos` 
ADD INDEX `fk_2_idx` (`id_modelo` ASC) VISIBLE;
;
ALTER TABLE `concesionario`.`vehiculos` 
ADD CONSTRAINT `fk_2`
  FOREIGN KEY (`id_modelo`)
  REFERENCES `concesionario`.`modelos` (`id_modelo`)
  ON DELETE CASCADE
  ON UPDATE NO ACTION;
  
  
  /*-------------PRUEBAS-------------- */
INSERT INTO `concesionario`.`marcas` (`nombre`, `pais`) VALUES ('SpaceX', 'EEUU');
INSERT INTO `concesionario`.`modelos` (`id_modelo`, `id_marca`, `modelo`, `motor`) VALUES ('1', '1', 'Dragon', 'Reactor');
INSERT INTO `concesionario`.`vehiculos` (`nombre`, `tipo`, `id_modelo`) VALUES ('Star Ship', 'Cohete', '1');




## -----------------------------
select * from marcas ma , modelos mo , vehiculos ve
where ma.id_marcas = mo.id_marca
and mo.id_modelo = ve.id_vehiculo





