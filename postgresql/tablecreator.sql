drop table if exists avtal;
drop table if exists person;

drop type if exists avtalsstatus;
create type avtalsstatus as enum('Aktivt', 'Inaktivt');

drop type if exists motpartstyp;
create type motpartstyp as enum('Extern', 'Förvaltning', 'Kommunalt bolag');

create table person(
	id			serial primary key,
	first_name		varchar(50) not null,
	last_name		varchar(50) not null,
	belagenhetsadress	varchar(50),
	postnummer		varchar(20) not null,
	postort			varchar(50) not null,
	epost			varchar(50) unique not null
);

create table avtal(
	id			serial primary key,
	diarienummer		bigint not null,
	status			avtalsstatus not null,
	startdate		date,
	enddate			date,
	orgnummer		varchar(20),

	motpartstyp		motpartstyp,
	SBKavtalsid		int,
	scan_url		varchar(512),
	enligt_avtal		text,
	internt_alias		text,
	kommentar		text,

	avtalstecknare		integer references person not null,
	avtalskontakt		integer references person not null
	
);

insert into person(first_name, last_name, belagenhetsadress, postnummer, postort, epost)
values	('Sven', 'Andersson', 'Svedalavägen', '111 11', 'Svedala', 'sven@example.com');

insert into avtal(diarienummer, startdate, enddate, orgnummer, status, avtalstecknare, avtalskontakt)
values	(314, '2017-01-01', CURRENT_DATE, '820403', 'Aktivt', 1, 1);
-- 	(1000, CURRENT_DATE, CURRENT_DATE, '820403', 'Aktivt'),
-- 	(666, '1982-04-03', CURRENT_DATE, '140807', 'Inaktivt');

select * from avtal inner join person
on avtal.avtalstecknare = person.id;
--select * from person;

