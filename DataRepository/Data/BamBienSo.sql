use GTVT 
go


insert into xes (MauSac, ChuxeId, Nam) values ('xanh',2, 2020)
insert into xes (MauSac, ChuxeId, Nam) values ('do',4, 2019)
insert into xes (MauSac, ChuxeId, Nam) values ('tim',3, 2020)
insert into xes (MauSac, ChuxeId, Nam) values ('vang',5, 2021)
GO
--select * from xe_test
-- Do ham Rand() khong chay duoc trong Function nen phai tao view rieng
create view v_random
as
select FLOOR(RAND()*(99999-1+1))+1 as randnum
go

-- Tao function bam bien so tu dong, neu da co roi thi bam lai so khac
create function bam_bien_so()
returns char(5)
as
begin
	DECLARE @biensoint int;
	declare @biensochar char(5);
	set @biensoint = (select randnum from v_random); -- goi view v_random da tao o tren 
	set @biensochar = RIGHT('00000'+ CAST(@biensoint as varchar(5)), 5);
	while exists  (select BienSoXe from Xes where BienSoXe = @biensochar) 
		begin
			set @biensoint = (select randnum from v_random); -- goi view v_random da tao o tren
			set @biensochar = RIGHT('00000'+ CAST(@biensoint as varchar(5)), 5);
		end
	return @biensochar	
end;
go

-- Tao procedure nhap bien so vao Xes
create procedure nhap_bien_so (@id int)
as
	begin
		declare @bienso char(5)
		set @bienso = (select dbo.bam_bien_so())
		print @bienso
		update Xes
		set BienSoXe = @bienso
		where XeId = @id
	end
go

--exec nhap_bien_so @id = 8

--exec nhap_bien_so @id = 9