create database QLSinhVien
create table MonHoc
(
   MaMH char(20) primary key,
   TenMH nvarchar(100),
   SoTC int,
   HocKy char(10),
   HocPhan nvarchar(100)
)
create table SinhVien
(
   MaSV  char(20) primary key,
   TenSV nvarchar(100),
   DiaChi nvarchar(100),
   Sdt char(10)
)
create table BangDiem
(
   MaSV char(20),
   MaMH char(20),
   Diem int
   CONSTRAINT PK_Person PRIMARY KEY (MaSV,MaMH),
   CONSTRAINT fk_MaSV
  FOREIGN KEY (MaSV)
  REFERENCES SinhVien (MaSV),foreign key (MaMH) references MonHoc(MaMH)
)

	Select * from MonHoc