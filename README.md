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


--SELECT TABLE

Select * from Friends

--INSERT TABLE
Insert into Friends Values ('Nihat','Bozkurt','40','02-04-1980','Nihatb@gmail.com','Erkek','İzmir'),
 ('Nesrin','Erdoğan','15','02-04-2005','elerdd@gmail.com','Kadın','Ankara')

 Insert into Friends Values('test','test','50','01.01.2001','test','test','test','(536-411-50-50)')


 --UPDATE TABLE
Update Friends set BirthDate = '21.03.2001' where FriendID = 2

-- DELETE TABLE
Insert into Friends Values ('Test','Testa','30','02.04.1997','test@gmail.com','Test','Test','test')
Select * from Friends
Delete from Friends where FriendID = 31

