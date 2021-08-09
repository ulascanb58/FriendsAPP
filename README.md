# FriendsAPP

CREATE DATABASE Friends
ON
PRIMARY ( 
	NAME=Friends,
	FILENAME = 'C:\Databases\Friends.mdf',
	SIZE=10MB,
	MAXSIZE=75MB,
	FILEGROWTH=10%
	) 
 
LOG ON (
	NAME=ETRADEBTKLog,
	FILENAME='C:\Databases\Friends.ldf',
	SIZE=3MB,
	MAXSIZE=15MB,
	FILEGROWTH=2MB
	)
 COLLATE Turkish_CI_AS


 Use Friends

 CREATE TABLE Friends(
FriendID int IDENTITY(1,1) PRIMARY KEY,
FirstName varchar(20),
LastName varchar(20),
Age int,
BirthDate date,
Email varchar(20),
 CONSTRAINT UQ_Friends UNIQUE (FirstName,LastName,Age,BirthDate,Email)
)




ALTER TABLE Friends Alter Column Email varchar(30)
Truncate Table Friends

ALTER TABLE Friends Add Gender varchar(6), City varchar(10)



