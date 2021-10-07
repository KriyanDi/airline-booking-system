use ABSDB;

create table AIRPORT
(AIRPORT_ID sql_variant not null,
 NAME nchar(3) not null,

 constraint PK_AIRPORT primary key (AIRPORT_ID),
 constraint UQ_AIRPORT_NAME unique (NAME),
 constraint CHK_AIRPORT_NAME_VALIDATION check (NAME collate SQL_Latin1_General_CP1_CS_AS = upper(NAME) COLLATE SQL_Latin1_General_CP1_CS_AS)
);