CREATE TABLE IF NOT EXISTS`produto` (
  `id` INT(10) NOT NULL AUTO_INCREMENT ,
  `name` varchar(50) NOT NULL,
  `sobre_name` varchar(50) NOT NULL,
  `value` decimal(65,5) NOT NULL,
  PRIMARY KEY(`id`)
)