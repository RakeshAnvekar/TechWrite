create database TechWriteDb
use TechWriteDb


create table userType(
UserTypeId int primary key identity(1,100),
[type] varchar(20) not null)