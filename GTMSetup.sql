USE master;  
DROP DATABASE GTM;
GO  
CREATE DATABASE GTM
ON   
( NAME = Sales_dat,  
    FILENAME = 'F:\Programming_And_Stuff\Programming\Git\HomeworkRepositoryPattern\GTMdat.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = Sales_log,  
    FILENAME = 'F:\Programming_And_Stuff\Programming\Git\HomeworkRepositoryPattern\GTMlog.ldf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB );  
GO
USE GTM;
GO
CREATE TABLE tblProduct(
	ProductID UNIQUEIDENTIFIER PRIMARY KEY,
	ProductName VARCHAR(MAX),
	ProductDescription VARCHAR(MAX),
	CreatedDate DATETIME DEFAULT GETDATE()

);
GO
CREATE TABLE tblService(
	ServiceID UNIQUEIDENTIFIER PRIMARY KEY,
	ServiceName VARCHAR(MAX),
	ServiceDescription VARCHAR(MAX),
	CreatedDate DATETIME DEFAULT GETDATE()
);
GO