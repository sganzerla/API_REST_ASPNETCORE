CREATE TABLE   `books` (
  `id` int(10) auto_increment NOT NULL,
  `Author` longtext,
  `LaunchDate` datetime(6) NOT NULL,
  `Price` decimal(65,2) NOT NULL,
  `Title` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
