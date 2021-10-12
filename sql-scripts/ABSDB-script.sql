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

create table FLIGHT_SECTION
(FLIGHT_SECTION_ID sql_variant not null,
 FLIGHT_ID sql_variant not null,
 SEATCLASS_ID sql_variant not null,
 ROWS int not null,
 COLS int not null,

 constraint PK_FLIGHT_SECTION primary key (FLIGHT_SECTION_ID),
 constraint UQ_FLIGHT_SEATCLASS unique (FLIGHT_ID, SEATCLASS_ID),
 constraint FK_FLIGHT_FLIGHT_SECTION foreign key (FLIGHT_ID) references FLIGHT (FLIGHT_ID),
 constraint FK_SEATCLASS_FLIGHT_SECTION foreign key (SEATCLASS_ID) references SEATCLASS (SEATCLASS_ID),
 constraint CHK_NUMBER_OF_ROWS_FOR_FLIGHT_SECTION check (1 <= ROWS and ROWS <= 100),
 constraint CHK_NUMEBR_OF_COLS_FOR_FLIGHT_SECTION check (1 <= COLS and COLS <= 10),
);

create table SEAT
(SEAT_ID sql_variant not null,
 FLIGHT_SECTION_ID sql_variant not null,
 BOOKED BIT not null,
 ROW int not null,
 COL int not null,

 constraint PK_SEAT primary key (SEAT_ID),
 constraint FK_FLIGHT_SECTION_SEAT foreign key (FLIGHT_SECTION_ID) references FLIGHT_SECTION (FLIGHT_SECTION_ID)
);

create table ROLE
(ROLE_ID sql_variant not null,
 TYPE nvarchar(16) not null,

 constraint PK_ROLE primary key (ROLE_ID),
 constraint UQ_ROLE_TYPE unique (TYPE),
 constraint CHK_TYPE_LENGTH check (len(TYPE) > 0)
);