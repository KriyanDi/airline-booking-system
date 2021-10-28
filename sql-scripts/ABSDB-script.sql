use ABSDB;

create table AIRPORT
(AIRPORT_ID uniqueidentifier not null,
 NAME nchar(3) not null,

 constraint PK_AIRPORT primary key (AIRPORT_ID),
 constraint UQ_AIRPORT_NAME unique (NAME),
 constraint CHK_AIRPORT_NAME_VALIDATION check (NAME collate SQL_Latin1_General_CP1_CS_AS = upper(NAME) COLLATE SQL_Latin1_General_CP1_CS_AS)
);

create table AIRLINE
(AIRLINE_ID uniqueidentifier not null,
 NAME nvarchar(5) not null,

 constraint PK_AIRLINE primary key (AIRLINE_ID),
 constraint UQ_AIRLINE_NAME unique (NAME),
 constraint CHK_AIRLINE_NAME_VALIDATION check (NAME collate SQL_Latin1_General_CP1_CS_AS = upper(NAME) COLLATE SQL_Latin1_General_CP1_CS_AS and len(NAME) >= 1)
);

create table FLIGHT
(FLIGHT_ID uniqueidentifier  not null,
 AIRLINE_ID uniqueidentifier  not null,
 ORIG_AIRPORT_ID uniqueidentifier not null,
 DEST_AIRPORT_ID uniqueidentifier not null,
 FLIGHT_NUMBER nchar(10) not null,
 TAKE_OFF datetime not null

 constraint PK_FLIGHT primary key (FLIGHT_ID),
 constraint UQ_FLIGHT_NUMBER unique (FLIGHT_NUMBER),
 constraint FK_AIRLINE_FLIGHT foreign key (AIRLINE_ID) references AIRLINE(AIRLINE_ID) on update cascade on delete cascade,
 constraint FK_ORIGIN_AIRPORT_FLIGHT foreign key (ORIG_AIRPORT_ID) references AIRPORT(AIRPORT_ID) on update no action on delete no action,
 constraint FK_DESTINATION_AIRPORT_FLIGHT foreign key (DEST_AIRPORT_ID) references AIRPORT(AIRPORT_ID) on update no action on delete no action
 );

create table SEATCLASS
(SEATCLASS_ID uniqueidentifier not null,
 TYPE nvarchar(25) not null,

 constraint PK_SEATCLASS primary key (SEATCLASS_ID),
 constraint UQ_SEATCLASS_TYPE unique (TYPE)
);

create table FLIGHT_SECTION
(FLIGHT_SECTION_ID uniqueidentifier not null,
 FLIGHT_ID uniqueidentifier not null,
 SEATCLASS_ID uniqueidentifier not null,
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
(SEAT_ID uniqueidentifier not null,
 FLIGHT_SECTION_ID uniqueidentifier not null,
 BOOKED BIT not null,
 ROW int not null,
 COL nchar(1) not null,

 constraint PK_SEAT primary key (SEAT_ID),
 constraint FK_FLIGHT_SECTION_SEAT foreign key (FLIGHT_SECTION_ID) references FLIGHT_SECTION (FLIGHT_SECTION_ID) on update cascade on delete cascade
);

create table ROLE
(ROLE_ID uniqueidentifier not null,
 TYPE nvarchar(16) not null,

 constraint PK_ROLE primary key (ROLE_ID),
 constraint UQ_ROLE_TYPE unique (TYPE),
 constraint CHK_TYPE_LENGTH check (len(TYPE) > 0)
);

create table ACCOUNT
(ACCOUNT_ID uniqueidentifier not null,
 ROLE_ID uniqueidentifier not null,
 USERNAME nvarchar(32) not null,
 EMAIL nvarchar(255) not null,
 PASSWORD nvarchar(32) not null,

 constraint PK_ACCOUNT primary key (ACCOUNT_ID),
 constraint UQ_USERNAME unique (USERNAME),
 constraint UQ_EMAIL unique (EMAIL),
 constraint FK_ROLE_ACCOUNT foreign key (ROLE_ID) references ROLE(ROLE_ID),
 constraint CHK_USERNAME_LENGHT check (len(USERNAME) >= 8),
 constraint CHK_EMAIL_VALIDATION check (EMAIL like '%@%.%'),
 constraint CHK_PASSWORD_LENGHT check (len(PASSWORD) >= 8)
);

create table TICKET
(TICKET_ID uniqueidentifier not null,
 ACCOUNT_ID uniqueidentifier not null,
 FLIGHT_SECTION_ID uniqueidentifier not null,
 SEAT_ID uniqueidentifier not null,
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

create trigger TR_FLIGHT_SECTION_AFTER_INSERT
on FLIGHT_SECTION
after insert
as
begin
	declare @flight_section_id uniqueidentifier
	declare @rows int
	declare @cols int

	declare ins_cur cursor for
		select FLIGHT_SECTION_ID, ROWS, COLS from INSERTED

	open ins_cur

	fetch next from ins_cur into @flight_section_id, @rows, @cols
	while @@FETCH_STATUS = 0
	begin
		declare @num_of_seats int
		set @num_of_seats = @rows * @cols
		declare @count_seat int
		set @count_seat = 0
		while(@count_seat < @num_of_seats)
			begin
				insert into SEAT(SEAT_ID, FLIGHT_SECTION_ID, BOOKED, ROW, COL)
				values (NEWID( ), @flight_section_id, 0, @count_seat + 1, CHAR(65 + @count_seat % @cols))
				set @count_seat = @count_seat + 1
			end

		fetch next from ins_cur into @flight_section_id, @rows, @cols
	end

	close ins_cur
    deallocate ins_cur
end
go



insert into AIRPORT (AIRPORT_ID, NAME) 
values 
 (NEWID(), 'CAN'),
 (NEWID(), 'TEW'),
 (NEWID(), 'AED'),
 (NEWID(), 'OQW'),
 (NEWID(), 'FDA'),
 (NEWID(), 'BVD'),
 (NEWID(), 'ASD'),
 (NEWID(), 'BZX'),
 (NEWID(), 'WIU'),
 (NEWID(), 'USA');

insert into AIRLINE (AIRLINE_ID, NAME) 
values 
 (NEWID(), 'DELTA'),
 (NEWID(), 'WIZZ'),
 (NEWID(), 'CLOUD'),
 (NEWID(), 'RTRN'),
 (NEWID(), 'BBERT'),
 (NEWID(), 'HWG'),
 (NEWID(), 'PUUI'),
 (NEWID(), 'APLUS'),
 (NEWID(), 'WIU'),
 (NEWID(), 'ATTA');

insert into SEATCLASS(SEATCLASS_ID, TYPE) 
values
  (NEWID(), 'FIRST'),
  (NEWID(), 'BUSINESS'),
  (NEWID(), 'ECONOMY');

insert into ROLE(ROLE_ID, TYPE)
values
 (NEWID(), 'ADMIN'),
 (NEWID(), 'USER');
go



create view FLIGHTS_INFORMATION as
select
	f.FLIGHT_ID, 
	f.FLIGHT_NUMBER, 
	airl.NAME as AIRLINE,
	(select NAME from AIRPORT where AIRPORT_ID = f.ORIG_AIRPORT_ID) as ORIG, 
	(select NAME from AIRPORT where AIRPORT_ID = f.DEST_AIRPORT_ID) as DEST, 
	f.TAKE_OFF, 
	sc.TYPE as SEATCLASS, 
	(select COUNT(s.SEAT_ID) from SEAT s where s.FLIGHT_SECTION_ID = fs.FLIGHT_SECTION_ID and s.BOOKED = 1) as BOOKED_SEATS,
	(select COUNT(s.SEAT_ID) from SEAT s where s.FLIGHT_SECTION_ID = fs.FLIGHT_SECTION_ID and s.BOOKED = 0) as FREE_SEATS 
from 
	FLIGHT_SECTION fs
	inner join FLIGHT f on f.FLIGHT_ID = fs.FLIGHT_ID
	inner join AIRLINE airl on airl.AIRLINE_ID = f.AIRLINE_ID
	inner join SEATCLASS sc on sc.SEATCLASS_ID = fs.SEATCLASS_ID;
go

create view AVAIL_FLIGHTS as
select FLIGHT_ID, SEATCLASS
from FLIGHTS_INFORMATION
where FREE_SEATS > 0;
go



create procedure GetAirports
as
begin
	set nocount on
	select NAME from AIRPORT
end;
go

create procedure GetAirportId(@airp_name uniqueidentifier)
as
begin
	select AIRPORT.NAME from AIRPORT where AIRPORT.AIRPORT_ID = @airp_name
end;
go

create procedure AddAirport(@airp_name nchar(3))
as
begin
	insert into AIRPORT(AIRPORT_ID, NAME)
	values (NEWID(), @airp_name)
end;
go

create procedure UpdateAirport(@airp_id uniqueidentifier, @new_airp_name nchar(3))
as
begin
	update AIRPORT
	set AIRPORT.NAME = @new_airp_name
	where AIRPORT_ID = @airp_id
end;
go

create procedure DeleteAirport(@airp_id uniqueidentifier)
as
begin
	delete from AIRPORT
	where AIRPORT_ID = @airp_id
end;
go

create procedure GetAirlines
as
begin
	set nocount on
	select NAME from AIRLINE
end;
go

create procedure GetAirlineId(@airl_name uniqueidentifier)
as
begin
	select AIRLINE.NAME from AIRLINE where AIRLINE.AIRLINE_ID = @airl_name
end;
go

create procedure AddAirline(@airl_name nvarchar(5))
as
begin
	insert into AIRLINE(AIRLINE_ID, NAME)
	values (NEWID(), @airl_name)
end;
go

create procedure UpdateAirline(@airl_id uniqueidentifier, @new_airl_name nchar(3))
as
begin
	update AIRLINE
	set AIRLINE.NAME = @new_airl_name
	where AIRLINE_ID = @airl_id
end;
go

create procedure DeleteAirline(@airl_id uniqueidentifier)
as
begin
	delete from AIRLINE
	where AIRLINE_ID = @airl_id
end;
go

create procedure GetFlightsInformation
as
begin
	set nocount on
	select * from FLIGHTS_INFORMATION
end;
go

create procedure GetAvailableFlights
as
begin
	set nocount on
	select * from AVAIL_FLIGHTS
end;
go

create procedure AddFlight(@airl_id uniqueidentifier, @orig_id uniqueidentifier, @dest_id uniqueidentifier, @take_off datetime)
as
begin
	declare @orig nchar(3)
	set @orig= (select AIRPORT.NAME from AIRPORT where AIRPORT.AIRPORT_ID = @orig_id)

	declare @dest nchar(3)
	set @dest = (select AIRPORT.NAME from AIRPORT where AIRPORT.AIRPORT_ID = @dest_id)

	declare @airl nvarchar(5)
	set @airl = (select AIRLINE.NAME from AIRLINE where AIRLINE.AIRLINE_ID = @airl_id)

	declare @final_flight_number nvarchar(25)
	set @final_flight_number = CONCAT(@airl, '-', @orig, '-', @dest, '-');

	declare @count int
	set @count = 1
	while (exists(select FLIGHT.FLIGHT_NUMBER from FLIGHT where FLIGHT_NUMBER = CONCAT(@final_flight_number, @count)))
	begin
		set @count = @count + 1
	end
	set @final_flight_number = CONCAT(@final_flight_number, @count)

	insert into FLIGHT(FLIGHT_ID , AIRLINE_ID, ORIG_AIRPORT_ID, DEST_AIRPORT_ID, FLIGHT_NUMBER, TAKE_OFF)
	values (NEWID(), @airl_id, @orig_id, @dest_id, @final_flight_number, @take_off)
end;
go

create procedure UpdateFlight(@flight_id uniqueidentifier, @airl_id uniqueidentifier, @orig_id uniqueidentifier, @dest_id uniqueidentifier, @take_off datetime)
as
begin
	declare @orig nchar(3)
	set @orig= (select AIRPORT.NAME from AIRPORT where AIRPORT.AIRPORT_ID = @orig_id)

	declare @dest nchar(3)
	set @dest = (select AIRPORT.NAME from AIRPORT where AIRPORT.AIRPORT_ID = @dest_id)

	declare @airl nvarchar(5)
	set @airl = (select AIRLINE.NAME from AIRLINE where AIRLINE.AIRLINE_ID = @airl_id)

	declare @final_flight_number nvarchar(25)
	set @final_flight_number = CONCAT(@airl, '-', @orig, '-', @dest, '-');

	declare @count int
	set @count = 1
	while (exists(select FLIGHT.FLIGHT_NUMBER from FLIGHT where FLIGHT_NUMBER = CONCAT(@final_flight_number, @count)))
	begin
		set @count = @count + 1
	end
	set @final_flight_number = CONCAT(@final_flight_number, @count)

	update FLIGHT
	set FLIGHT.AIRLINE_ID = @airl_id,
		FLIGHT.ORIG_AIRPORT_ID = @orig_id,
		FLIGHT.DEST_AIRPORT_ID = @dest_id,
		FLIGHT.FLIGHT_NUMBER = @final_flight_number,
		FLIGHT.TAKE_OFF = @take_off
	where FLIGHT.FLIGHT_ID = @flight_id
end;
go

create procedure DeleteFlight(@flight_id uniqueidentifier)
as
begin
	delete from FLIGHT
	where FLIGHT.FLIGHT_ID = @flight_id
end;
go

create procedure AddFlightSection(@flight_id uniqueidentifier, @seatclass_id uniqueidentifier, @rows int, @cols int)
as
begin
	insert into FLIGHT_SECTION(FLIGHT_SECTION_ID, FLIGHT_ID, SEATCLASS_ID, ROWS, COLS)
	values (NEWID(), @flight_id, @seatclass_id, @rows, @cols)
end;
go

create procedure DeleteFlightSection(@fl_sc_id uniqueidentifier)
as
begin
	delete from FLIGHT_SECTION
	where FLIGHT_SECTION.FLIGHT_SECTION_ID = @fl_sc_id
end;
go

create procedure GetFreeFlightSections(@flight_id uniqueidentifier)
as
begin
	select SEATCLASS.TYPE 
	from SEATCLASS
	where SEATCLASS.TYPE not in (select FLIGHTS_INFORMATION.SEATCLASS
								 from FLIGHTS_INFORMATION 
								 where FLIGHTS_INFORMATION.FLIGHT_ID = FLIGHT_ID)
end;
go

create procedure GetFlightSectionSeats(@fl_sc_id uniqueidentifier)
as
begin
	select * 
	from SEAT 
	where SEAT.FLIGHT_SECTION_ID = @fl_sc_id
end;
go

create procedure GetFlightSectionFreeSeats(@fl_sc_id uniqueidentifier)
as
begin
	select * 
	from SEAT 
	where SEAT.FLIGHT_SECTION_ID = @fl_sc_id
	and SEAT.BOOKED = 0
end;
go

create procedure BookSeat(@seat_id uniqueidentifier, @row int, @col nchar)
as
begin
	update SEAT
	set SEAT.BOOKED = 1
	where SEAT.SEAT_ID = @seat_id
	and SEAT.ROW = @row
	and SEAT.COL = @col
end;
go

create procedure UnbookSeat(@seat_id uniqueidentifier, @row int, @col nchar)
as
begin
	update SEAT
	set SEAT.BOOKED = 0
	where SEAT.SEAT_ID = @seat_id
	and SEAT.ROW = @row
	and SEAT.COL = @col
end;
go
