-- Script Creare BD

DROP TABLE IF EXISTS OrdineDeplasare;
DROP TABLE IF EXISTS Rectori;
DROP TABLE IF EXISTS ProRectori;
DROP TABLE IF EXISTS COS;
DROP TABLE IF EXISTS DFC;
DROP TABLE IF EXISTS Cereri;
DROP TABLE IF EXISTS GradeDidactice;
DROP TABLE IF EXISTS Facultati;
DROP TABLE IF EXISTS Scopuri;
DROP TABLE IF EXISTS Tari;
DROP TABLE IF EXISTS Monezi;

-------------------------------------

-- Creare tabela GradeDidactice
CREATE TABLE GradeDidactice (
GradDidacticGD VARCHAR(150) CONSTRAINT pk_GradDidacticGD PRIMARY KEY
);

-- Creare tabela Facultati
CREATE TABLE Facultati (
FacultatiF VARCHAR(150) CONSTRAINT pk_FacultatiF PRIMARY KEY
);

-- Creare tabela Facultati
CREATE TABLE Monezi (
MoneziM VARCHAR(50) CONSTRAINT pk_MoneziM PRIMARY KEY
);

-- Creare tabela Tari
CREATE TABLE Tari (
TariT VARCHAR(150) CONSTRAINT pk_TariT PRIMARY KEY
);

-- Creare tabela Scopuri
CREATE TABLE Scopuri (
ScopuriS VARCHAR(1000) CONSTRAINT pk_ScopuriS PRIMARY KEY
);

-- Creare tabela Cereri
CREATE TABLE Cereri (
NrInregistrareC NUMERIC(5) CONSTRAINT pk_NrInregistrareC PRIMARY KEY,
DataC DATE,
SubsemnatulC VARCHAR(70),
GradDidacticC VARCHAR(50) CONSTRAINT fk_GradDidacticC REFERENCES GradeDidactice(GradDidacticGD) ON UPDATE CASCADE,
FacultateaC VARCHAR(150) CONSTRAINT fk_FacultateaC REFERENCES Facultati(FacultatiF) ON UPDATE CASCADE,
DepartamentulC VARCHAR(50),
TaraC VARCHAR(100) CONSTRAINT fk_TaraC REFERENCES Tari(TariT) ON UPDATE CASCADE,
LocalitateaC VARCHAR(100),
ScopC VARCHAR(300) CONSTRAINT fk_ScopC REFERENCES Scopuri(ScopuriS) ON UPDATE CASCADE,
PrecizariScopC VARCHAR(300),
InstitutiaC VARCHAR(300),
DataInceputC DATE,
DataSfarsitC DATE,
RutaC VARCHAR(30),
MijTransC VARCHAR(30),
PlatitorTranspC VARCHAR(30),
PlatitorIntretinereC VARCHAR(30),
BifaDiurnaC BOOLEAN,
NrZileDiurnaC NUMERIC(3),
DiurnaC NUMERIC(7,2),
MonedaDiurnaC VARCHAR(50) CONSTRAINT fk_MonedaDiurnaC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaCazareC BOOLEAN,
NrZileCazareC NUMERIC(3),
CazareC NUMERIC(7,2),
MonedaCazareC VARCHAR(50) CONSTRAINT fk_MonedaCazareC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaTaxaDeParticipareC BOOLEAN,
TaxaDeParticipareC NUMERIC(7,2),
MonedaTaxaDeParticipareC VARCHAR(50) CONSTRAINT fk_MonedaTaxaDeParticipareC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaTaxaDeVizaEtcC BOOLEAN,
TaxaDeVizaEtcC NUMERIC(7,2),
MonedaTaxaDeVizaEtcC VARCHAR(50) CONSTRAINT fk_MonedaTaxaDeVizaEtcC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
TotalC VARCHAR(50),
TIOZC BOOLEAN
);

-- Creare tabela Rectori
CREATE TABLE Rectori (
Rector VARCHAR(50) CONSTRAINT pk_Rector PRIMARY KEY,
EMailR VARCHAR(50),
TelefonR NUMERIC(12),
RectorCurent BOOLEAN
);

-- Creare tabela ProRectori
CREATE TABLE ProRectori (
ProRector VARCHAR(50) CONSTRAINT pk_ProRector PRIMARY KEY,
EMailP VARCHAR(50),
TelefonP1 NUMERIC(12) NOT NULL,
TelefonP2 NUMERIC(12),
SectorP VARCHAR(400)
);

-- Creare tabela DFC
CREATE TABLE DFC (
DFCD VARCHAR(50) CONSTRAINT pk_DFC PRIMARY KEY
);

-- Creare tabela COS
CREATE TABLE COS (
COSC VARCHAR(300) CONSTRAINT pk_COS PRIMARY KEY
);

-- Creare tabela CereriBECA
CREATE TABLE OrdineDeplasare (
NrInregistrareODC NUMERIC(5) CONSTRAINT fk_NrInregistrareBC REFERENCES Cereri(NrInregistrareC),
NrInregistrareOD NUMERIC(10),
NrInregistrareODNou NUMERIC(10),
DataOD DATE,
DataODNoua DATE,
SubsemnatulOD VARCHAR(70),
GradDidacticOD VARCHAR(50) CONSTRAINT fk_GradDidacticC REFERENCES GradeDidactice(GradDidacticGD) ON UPDATE CASCADE,
FacultateaOD VARCHAR(150) CONSTRAINT fk_FacultateaC REFERENCES Facultati(FacultatiF) ON UPDATE CASCADE,
TaraOD VARCHAR(100) CONSTRAINT fk_TaraOD REFERENCES Tari(TariT) ON UPDATE CASCADE,
LocalitateaOD VARCHAR(100),
ScopOD VARCHAR(300) CONSTRAINT fk_ScopC REFERENCES Scopuri(ScopuriS) ON UPDATE CASCADE,
PrecizariScopOD VARCHAR(300),
InstitutiaOD VARCHAR(300),
DataInceputOD DATE,
DataSfarsitOD DATE,
RutaOD VARCHAR(30),
PlatitorTranspOD VARCHAR(30),
PlatitorIntretinereOD VARCHAR(30),
BifaDiurnaOD BOOLEAN,
NrZileDiurnaOD NUMERIC(3),
DiurnaOD NUMERIC(7,2),
MonedaDiurnaOD VARCHAR(50) CONSTRAINT fk_MonedaDiurnaC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaCazareOD BOOLEAN,
NrZileCazareOD NUMERIC(3),
CazareOD NUMERIC(7,2),
MonedaCazareOD VARCHAR(50) CONSTRAINT fk_MonedaCazareC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaTaxaDeParticipareOD BOOLEAN,
TaxaDeParticipareOD NUMERIC(7,2),
MonedaTaxaDeParticipareOD VARCHAR(50) CONSTRAINT fk_MonedaTaxaDeParticipareC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaTaxaDeVizaEtcOD BOOLEAN,
TaxaDeVizaEtcOD NUMERIC(7,2),
MonedaTaxaDeVizaEtcOD VARCHAR(50) CONSTRAINT fk_MonedaTaxaDeVizaEtcC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
TotalOD VARCHAR(50),
COSOD VARCHAR(300),
AlteDispuneri1OD VARCHAR(150),
AlteDispuneri2OD VARCHAR(150),
AlteDispuneri3OD VARCHAR(150),
AlteDispuneri4OD VARCHAR(150),
RectorOD BOOLEAN,
ProrectorOD BOOLEAN,
NumeRPOD VARCHAR(100),
BifaDFCOD BOOLEAN,
DFCOD VARCHAR(100) CONSTRAINT fk_DFCOD REFERENCES DFC(DFCD) ON UPDATE CASCADE,
BifaCPOD BOOLEAN,
CPNumeProjOD VARCHAR(300),
CPGradDidacticOD VARCHAR(50) CONSTRAINT fk_CPGradDidacticOD REFERENCES GradeDidactice(GradDidacticGD) ON UPDATE CASCADE,
CPNumeCoordOD VARCHAR(100),
ODDI BOOLEAN
);

INSERT INTO DFC(DFCD) VALUES ('! Modifică DFC !');
INSERT INTO COS(COSC) VALUES ('! Modifică Dispunere 1 !');