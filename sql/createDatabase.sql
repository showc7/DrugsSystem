USE master;
GO

CREATE DATABASE "Store";
GO

USE "Store"
GO

--IF NOT EXISTS(SELECT * FROM Countries)
if not exists (select * from sysobjects where name='Countries' and xtype='U')
	CREATE TABLE "Countries"
	(
		"CountryID" INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		"CountryName" nvarchar(250)
	)
GO

if not exists (select * from sysobjects where name='DepotCountries' and xtype='U')
	CREATE TABLE "DepotCountries"
	(
		Depot_DepotID INT NOT NULL,
		Country_CountryID INT NOT NULL,
		CONSTRAINT "DepotCountries.PK" PRIMARY KEY (Depot_DepotID, Country_CountryID)
	)
GO

if not exists (select * from sysobjects where name='Depots' and xtype='U')
	CREATE TABLE "Depots"
	(
		DepotID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		DepotName nvarchar(250)
	)
GO

if not exists (select * from sysobjects where name='DrugTypes' and xtype='U')
	CREATE TABLE "DrugTypes"
	(
		DrugTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
		DrugTypeName nvarchar(250)
	)
GO

if not exists (select * from sysobjects where name='DrugUnits' and xtype='U')
	CREATE TABLE "DrugUnits"
	(
		DrugUnitID nvarchar(25),
		PickNumber int,
		Quantity INT DEFAULT 0,
		DrugType_DrugTypeID INT,
		Depot_DepotID INT
	);
GO

ALTER TABLE "DepotCountries"
	ADD CONSTRAINT "DepotCountries.Country_CountryID.CountryID"
	FOREIGN KEY ("Country_CountryID")
	REFERENCES "Countries"("CountryID");
GO

ALTER TABLE "DepotCountries"
	ADD CONSTRAINT "DepotCountries.Depot_DepotID.DepotID"
	FOREIGN KEY ("Depot_DepotID")
	REFERENCES "Depots"("DepotID");
GO

ALTER TABLE "DrugUnits"
	ADD CONSTRAINT "DrugUnits.Depot_DepotID.DepotID"
	FOREIGN KEY ("Depot_depotID")
	REFERENCES "Depots"("DepotID");
GO

ALTER TABLE "DrugUnits"
	ADD CONSTRAINT "DrugUnits.DrugType_DrugTypeID.DrugTypeID"
	FOREIGN KEY ("DrugType_DrugTypeID")
	REFERENCES "DrugTypes"("DrugTypeID");
GO

INSERT INTO "Countries" ("CountryName") VALUES(N'Romania')
INSERT INTO "Countries" ("CountryName") VALUES(N'United States of America')
INSERT INTO "Depots" ("DepotName") VALUES(N'Depot-0')
INSERT INTO "Depots" ("DepotName") VALUES(N'Depot-1')
INSERT INTO "DrugTypes" ("DrugTypeName") VALUES(N'Type-0')
INSERT INTO "DrugTypes" ("DrugTypeName") VALUES(N'Type-1')
GO

SELECT * FROM "Countries";
SELECT * FROM "Depots";
SELECT * FROM "DrugTypes";

declare @id int
select @id = 1
while @id >=1 and @id <= 100
begin
    insert into "DrugUnits" ("DrugUnitID","PickNumber") values('a_' + convert(varchar(5), @id), convert(varchar(5), @id))
    select @id = @id + 1
end;

SELECT * FROM "DrugUnits";

---INSERT INTO "DepotCountries" ("Depot_DepotID", "Country_CountryID") VALUES(1,1);
INSERT INTO "DepotCountries" ("Depot_DepotID", "Country_CountryID")
select * from 
(SELECT DepotID FROM Depots WHERE DepotName  = N'Depot-0') as DrugTypeIDResult,
(SELECT CountryID FROM Countries WHERE CountryName = N'Romania') as DrugUnitIDresult

UPDATE DrugUnits
SET
DrugType_DrugTypeID = (
	SELECT DrugTypeID FROM DrugTypes WHERE DrugTypeName  = N'Type-0'
),
Quantity = 4
WHERE PickNumber = 1;
