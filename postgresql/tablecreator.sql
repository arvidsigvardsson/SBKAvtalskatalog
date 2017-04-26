drop table if exists avtal;
create table avtal(
	id			serial primary key,
	diarienummer		bigint not null,
	startdate		date,
	enddate			date,
	orgnummer		varchar(20)
);

insert into avtal(diarienummer, startdate, enddate, orgnummer)
values(314, '2017-01-01', CURRENT_DATE, '820403');

select * from avtal;