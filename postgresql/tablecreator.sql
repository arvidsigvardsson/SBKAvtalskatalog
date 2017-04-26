drop table if exists avtal;
create table avtal(
	id			serial primary key,
	diarienummer		bigint not null,
	startdate		date,
	enddate			date,
	orgnummer		varchar(20)
);

insert into avtal(diarienummer, startdate, enddate, orgnummer)
values	(314, '2017-01-01', CURRENT_DATE, '820403'),
	(1000, CURRENT_DATE, CURRENT_DATE, '820403'),
	(666, '1982-04-03', CURRENT_DATE, '140807');

select * from avtal;