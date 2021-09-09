USE master
GO

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases 
WHERE name = 'BuhuzooDB'))
BEGIN
    ALTER DATABASE BuhuzooDB set single_user with rollback immediate
    DROP DATABASE BuhuzooDB
END
GO

CREATE DATABASE BuhuzooDB
GO
USE BuhuzooDB
GO

--Create new table
CREATE TABLE Animal (
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(255),
Race NVARCHAR(255),
Color NVARCHAR(255),
DateOfBirth DateTime,
Gender NVARCHAR(255)
)

CREATE TABLE ZooKeeper (
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(255),
Email NVARCHAR(255),
DateOfBirth DateTime,
Gender NVARCHAR(255)
)

SELECT * FROM Animal

--create table colors (
--id INT IDENTITY(1,1) PRIMARY KEY not null,
--color NVARCHAR(255)
--)

--create table race (
--id INT IDENTITY(1,1) PRIMARY KEY not null,
--racetype NVARCHAR(255)
--)