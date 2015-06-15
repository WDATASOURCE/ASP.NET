------------创建 DB_Mispersonal 数据库------------
use master
if exists(select * from sysdatabases where name ='DB_Mispersonal')
	drop database DB_Mispersonal
create database DB_Mispersonal
on
(
	name='DB_Mispersonal_Data',
	filename='d:\DB_Mispersonal.mdf',
	size=16 mb,
	filegrowth=10%
)
log on
(
	name='DB_Mispersonal_Log',
	filename='d:\DB_Mispersonal.ldf',
	size=16 mb,
	maxsize=512 mb,
	filegrowth=10%
)
GO


use DB_Mispersonal
GO
if exists (select * from sysobjects where id = OBJECT_ID('[Tb_department]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Tb_department]

CREATE TABLE [Tb_department] (
[D_ID] [char]  (3) NOT NULL,
[D_Name] [char]  (10) NOT NULL,
[D_Tel] [char]  (11) NOT NULL,
[D_Address] [char]  (100) NULL,
[D_Chief] [char]  (10) NULL,
[D_Belong] [char]  (10) NULL)

if exists (select * from sysobjects where id = OBJECT_ID('[Tb_employee]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Tb_employee]

CREATE TABLE [Tb_employee] (
[E_ID] [char]  (7) NOT NULL,
[E_Name] [nvarchar]  (50) NOT NULL,
[E_Sex] [nvarchar]  (50) NOT NULL,
[E_Birth] [nvarchar]  (50) NULL,
[E_Tel] [nvarchar]  (50) NOT NULL,
[E_Address] [nvarchar]  (255) NOT NULL,
[E_Intro] [nvarchar]  (255) NULL,
[E_Picurl] [nvarchar]  (50) NULL,
[D_Name] [nvarchar]  (50) NULL)

INSERT [Tb_employee] ([E_ID],[E_Name],[E_Sex],[E_Birth],[E_Tel],[E_Address],[E_Intro],[E_Picurl],[D_Name]) VALUES ( '001','小刘','男','2008-03-17','888','888','01','开发部的','~/WebFiles/Images/1.GIF')

if exists (select * from sysobjects where id = OBJECT_ID('[Tb_User_Login]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Tb_User_Login]

CREATE TABLE [Tb_User_Login] (
[ID] [char]  (10) NOT NULL,
[userName] [char]  (20) NULL,
[userPass] [char]  (16) NULL,
[userRole] [char]  (10) NULL)

INSERT [Tb_User_Login] ([ID],[userName],[userPass],[userRole]) VALUES ( '1','1','1','1')

CREATE TABLE [dbo].[Tb_Wage] (
    [E_ID]        NVARCHAR (50) NOT NULL,
    [E_Name]      NCHAR (10)    NULL,
    [Day_Wage]    FLOAT (53)    NULL,
    [Work_Day]    INT           NULL,
    [All_Wage]    FLOAT (53)    NULL,
    [Paid_Wage]   FLOAT (53)    NULL DEFAULT 0,
    [Unpaid_Wage] FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([E_ID] ASC)
);
