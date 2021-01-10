use GTVT
GO
CREATE PROCEDURE sp_laychuxe
AS
	BEGIN
		SELECT Id, CMND, HoTen, DiaChi, GioiTinh, NamSinh
		FROM Chuxes
	END
GO

EXEC sp_laychuxe
go
CREATE PROCEDURE sp_laybanglai_id @Id int
AS
	BEGIN	
		SELECT *
		FROM Banglais
		WHERE Id = @Id
	END
GO

CREATE PROCEDURE sp_laybanglai
AS
	BEGIN
		SELECT *
		FROM Banglais
	END
GO

EXEC sp_laybanglai
GO

EXEC sp_laybanglai_id @id = 1
go

CREATE PROCEDURE sp_xemchuxe_theoid @Id INT
AS
	BEGIN 
		SELECT *
		FROM Chuxes
		where Id = @Id
	END
GO

EXEC sp_xemchuxe_theoid @Id = 1
go

CREATE PROCEDURE sp_layxe 
AS
	BEGIN
		SELECT *
		FROM Xes
	END
GO

EXEC sp_layxe
GO

CREATE PROCEDURE sp_layxetheoid @Id INT
AS
	BEGIN
		SELECT *
		FROM Xes
		WHERE Id = @Id
	END
GO

EXEC sp_layxetheoid @Id = 2