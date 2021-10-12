use ABSDB;

create table AIRPORT
(AIRPORT_ID sql_variant not null,
 NAME nchar(3) not null,

 constraint PK_AIRPORT primary key (AIRPORT_ID),
 constraint UQ_AIRPORT_NAME unique (NAME),
 constraint CHK_AIRPORT_NAME_VALIDATION check (NAME collate SQL_Latin1_General_CP1_CS_AS = upper(NAME) COLLATE SQL_Latin1_General_CP1_CS_AS)
);

create table AIRLINE
(AIRLINE_ID sql_variant not null,
 NAME nvarchar(5) not null,

 constraint PK_AIRLINE primary key (AIRLINE_ID),
 constraint UQ_AIRLINE_NAME unique (NAME),
 constraint CHK_AIRLINE_NAME_VALIDATION check (NAME collate SQL_Latin1_General_CP1_CS_AS = upper(NAME) COLLATE SQL_Latin1_General_CP1_CS_AS and len(NAME) >= 1)
);

create table FLIGHT
(FLIGHT_ID sql_variant not null,
 FLIGHT_NUMBER nchar(10) not null,
 AIRLINE_ID sql_variant not null,
 ORIG_AIRPORT_ID sql_variant not null,
 DEST_AIRPORT_ID sql_variant not null,
 TAKE_OFF datetime not null

 constraint PK_FLIGHT primary key (FLIGHT_ID),
 constraint UQ_FLIGHT_NUMBER unique (FLIGHT_NUMBER),
 constraint FK_AIRLINE_FLIGHT foreign key (AIRLINE_ID) references AIRLINE(AIRLINE_ID),
 constraint FK_ORIGIN_AIRPORT_FLIGHT foreign key (ORIG_AIRPORT_ID) references AIRPORT(AIRPORT_ID) on update no action on delete no action,
 constraint FK_DESTINATION_AIRPORT_FLIGHT foreign key (DEST_AIRPORT_ID) references AIRPORT(AIRPORT_ID) on update no action on delete no action
 );

 create table SEATCLASS
(SEATCLASS_ID sql_variant not null,
 TYPE nvarchar(25) not null,

 constraint PK_SEATCLASS primary key (SEATCLASS_ID),
 constraint UQ_SEATCLASS_TYPE unique (TYPE)
);