create database lethithao_231230910_de01

use lethithao_231230910_de01

create table LttComputer(
	lttComId varchar(10) primary key,
	lttComName nvarchar(100) not null,
	lttComPrice float,
	lttComImage varchar(200),
	lttComStatus bit
)

insert into LttComputer values 
('C01', 'laptop dell', 1500, '', 1),
('C02', 'laptop asus', 2000, '', 1),
('C03', 'laptop lenovo', 3000, '', 0)
