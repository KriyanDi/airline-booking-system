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
 constraint FK_AIRLINE_FLIGHT foreign key (AIRLINE_ID) references AIRLINE(AIRLINE_ID) on update cascade on delete cascade,
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
 constraint FK_FLIGHT_FLIGHT_SECTION foreign key (FLIGHT_ID) references FLIGHT (FLIGHT_ID) on update cascade on delete cascade,
 constraint FK_SEATCLASS_FLIGHT_SECTION foreign key (SEATCLASS_ID) references SEATCLASS (SEATCLASS_ID) on update cascade on delete cascade,
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
 constraint FK_FLIGHT_SECTION_SEAT foreign key (FLIGHT_SECTION_ID) references FLIGHT_SECTION (FLIGHT_SECTION_ID) on update cascade on delete cascade
);

create table ROLE
(ROLE_ID sql_variant not null,
 TYPE nvarchar(16) not null,

 constraint PK_ROLE primary key (ROLE_ID),
 constraint UQ_ROLE_TYPE unique (TYPE),
 constraint CHK_TYPE_LENGTH check (len(TYPE) > 0)
);

create table ACCOUNT
(ACCOUNT_ID sql_variant not null,
 ROLE_ID sql_variant not null,
 USERNAME nvarchar(32) not null,
 EMAIL nvarchar(255) not null,
 PASSWORD nvarchar(32) not null,

 constraint PK_ACCOUNT primary key (ACCOUNT_ID),
 constraint UQ_USERNAME unique (USERNAME),
 constraint UQ_EMAIL unique (EMAIL),
 constraint CHK_USERNAME_LENGHT check (len(USERNAME) >= 8),
 constraint CHK_EMAIL_VALIDATION check (EMAIL like '%@%.%'),
 constraint CHK_PASSWORD_LENGHT check (len(PASSWORD) >= 8)
);

create table TICKET
(TICKET_ID sql_variant not null,
 ACCOUNT_ID sql_variant not null,
 FLIGHT_SECTION_ID sql_variant not null,
 SEAT_ID sql_variant not null,
 PRICE money not null,

 constraint PK_TICKET primary key (TICKET_ID),
 constraint FK_ACCOUNT_TICKET foreign key (ACCOUNT_ID) references ACCOUNT(ACCOUNT_ID) on update cascade on delete cascade,
 constraint FK_SEAT_TICKET foreign key (SEAT_ID) references SEAT(SEAT_ID) on update cascade on delete cascade,
 constraint CHK_PRICE check (PRICE >= 0.0)
);
go

create trigger TR_AIRPORT_INSTEAD_OF_DELETE
on AIRPORT
instead of DELETE
as
begin
	delete from FLIGHT
	where 
	 FLIGHT.DEST_AIRPORT_ID in (select AIRPORT_ID from DELETED)
	 or FLIGHT.ORIG_AIRPORT_ID in (select AIRPORT_ID from DELETED);

	 delete from AIRPORT
	 where AIRPORT.AIRPORT_ID in (select AIRPORT_ID from DELETED)
end
go

create trigger TR_SEAT_BEFORE_DELETE
on SEAT
for DELETE
as
begin
	delete from TICKET
	where TICKET.SEAT_ID in (select SEAT_ID from DELETED)
end
go

create trigger TR_TICKET_AFTER_DELETE
on TICKET
for delete
as
begin
	update SEAT
	set SEAT.BOOKED = 'FALSE'
	where SEAT.SEAT_ID in (select SEAT_ID from DELETED);
end
go



insert into AIRPORT (AIRPORT_ID, NAME) 
values 
 (1, 'CAN'),
 (2, 'TEW'),
 (3, 'AED'),
 (4, 'OQW'),
 (5, 'FDA'),
 (6, 'BVD'),
 (7, 'ASD'),
 (8, 'BZX'),
 (9, 'WIU'),
 (10, 'USA');

insert into AIRLINE (AIRLINE_ID, NAME) 
values 
 (1, 'DELTA'),
 (2, 'WIZZ'),
 (3, 'CLOUD'),
 (4, 'RTRN'),
 (5, 'BBERT'),
 (6, 'HWG'),
 (7, 'PUUI'),
 (8, 'APLUS'),
 (9, 'WIU'),
 (10, 'ATTA');

insert into FLIGHT (FLIGHT_ID, FLIGHT_NUMBER, AIRLINE_ID, ORIG_AIRPORT_ID, DEST_AIRPORT_ID, TAKE_OFF)
values
 (1, '100-100-01', 1, 1, 2, '2021-10-01 12:35:29.00'),
 (2, '100-100-02', 2, 2, 2, '2021-10-01 12:35:29.00'),
 (3, '100-100-03', 3, 3, 5, '2021-10-01 12:35:29.00'),
 (4, '100-100-04', 4, 1, 7, '2021-10-01 12:35:29.00'),
 (5, '100-100-05', 5, 8, 10, '2021-10-01 12:35:29.00');

insert into SEATCLASS(SEATCLASS_ID, TYPE) 
values
  (1, 'FIRST'),
  (2, 'BUSINESS'),
  (3, 'ECONOMY');

insert into FLIGHT_SECTION(FLIGHT_SECTION_ID, FLIGHT_ID, SEATCLASS_ID, ROWS, COLS)
values
 (1, 1, 1, 10, 6),
 (2, 1, 2, 10, 6),
 (3, 2, 3, 10, 6),
 (4, 2, 1, 10, 6),
 (5, 3, 3, 10, 6);

insert into ROLE(ROLE_ID, TYPE)
values
 (1, 'ADMIN'),
 (2, 'USER');
go
