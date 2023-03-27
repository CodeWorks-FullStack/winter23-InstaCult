CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

-- SECTION CULTS

CREATE TABLE IF NOT EXISTS cults(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',

  name VARCHAR(100) NOT NULL,
  category VARCHAR(50) NOT NULL DEFAULT 'BIGINT' COMMENT 'default big int is a joke, not actually changing data type',
  description TEXT,
  leaderId VARCHAR(255) NOT NULL,

  FOREIGN KEY (leaderId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO cults
(name, description, `leaderId`)
VALUES
("BIGINT BOYS", "It comes first cause it's the best.", '6421b7d467701be1e2885bf5');

SELECT LAST_INSERT_ID();