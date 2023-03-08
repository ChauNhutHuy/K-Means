create database KHAITHACDL
go
use KHAITHACDL

create table NHANVIEN
(

	TAIKHOAN nchar(50),
	MATKHAU nchar(50),

)

set dateformat dmy
insert into NHANVIEN(TAIKHOAN,MATKHAU)
values ('admin','1')
