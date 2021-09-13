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

CREATE TABLE ZooKeeperAnimal (
ZooKeeperId int,
AnimalId int
)
GO
INSERT INTO ZooKeeperAnimal VALUES (1,1), (1,2), (1,3)
SELECT * FROM ZooKeeper
SELECT * FROM Animal
SELECT * FROM ZooKeeperAnimal

SELECT A.id, A.[Name], A.Race, A.Color, A.DateOfBirth, A.Gender
FROM ZooKeeperAnimal AS Z
JOIN animal AS A ON A.Id = Z.AnimalId
WHERE Z.ZooKeeperId = 1


--create table colors (
--id INT IDENTITY(1,1) PRIMARY KEY not null,
--color NVARCHAR(255)
--)

DELETE FROM Animal
--Resets identity
DBCC CHECKIDENT ('Animal', RESEED, 0)

DBCC CHECKIDENT ('Animal', RESEED)

--create table race (
--id INT IDENTITY(1,1) PRIMARY KEY not null,
--racetype NVARCHAR(255)
--)