-- create databese
--CREATE DATABASE Registration

-- delete tabe
--DROP TABLE RegistrationTable

CREATE TABLE RegistrationTable(
	UserID int NOT NULL PRIMARY KEY,
	UserName varchar(255),
	Password varchar(255),
	Country varchar(255),
	Email varchar(255)
);