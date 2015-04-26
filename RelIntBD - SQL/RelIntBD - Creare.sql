-- Script Creare BD

DROP TABLE IF EXISTS OrdineDeplasare;
DROP TABLE IF EXISTS Rectori;
DROP TABLE IF EXISTS ProRectori;
DROP TABLE IF EXISTS OreRecuperate;
DROP TABLE IF EXISTS ConditiiDePlata;
DROP TABLE IF EXISTS Cereri;
DROP TABLE IF EXISTS GradeDidactice;
DROP TABLE IF EXISTS Facultati;
DROP TABLE IF EXISTS Monezi;

-------------------------------------

-- Creare tabela GradeDidactice
CREATE TABLE GradeDidactice (
GradDidacticGD VARCHAR(50) CONSTRAINT pk_GradDidacticGD PRIMARY KEY
);

-- Creare tabela Facultati
CREATE TABLE Facultati (
FacultatiF VARCHAR(50) CONSTRAINT pk_FacultatiF PRIMARY KEY
);

-- Creare tabela Facultati
CREATE TABLE Monezi (
MoneziM VARCHAR(50) CONSTRAINT pk_MoneziM PRIMARY KEY
);

-- Creare tabela Cereri
CREATE TABLE Cereri (
NrInregistrareC NUMERIC(5) CONSTRAINT pk_NrInregistrareC PRIMARY KEY,
DataC DATE,
SubsemnatulC VARCHAR(70),
GradDidacticC VARCHAR(30) CONSTRAINT fk_GradDidacticC REFERENCES GradeDidactice(GradDidacticGD),
FacultateaC VARCHAR(30) CONSTRAINT fk_FacultateaC REFERENCES Facultati(FacultatiF),
DepartamentulC VARCHAR(50),
LocalitateaC VARCHAR(30),
TaraC VARCHAR(20),
ScopC VARCHAR(100),
InstitutiaC VARCHAR(70),
DataInceputC DATE,
DataSfarsitC DATE,
RutaC VARCHAR(30),
MijTransC VARCHAR(30),
PlatitorTranspC VARCHAR(30),
PlatitorIntretinereC VARCHAR(30),
NrZileDiurnaC NUMERIC(3),
DiurnaC NUMERIC(7,2),
MonedaDiurnaC VARCHAR(50) CONSTRAINT fk_MonedaDiurnaC REFERENCES Monezi(MoneziM),
NrZileCazareC NUMERIC(3),
CazareC NUMERIC(7,2),
MonedaCazareC VARCHAR(50) CONSTRAINT fk_MonedaCazareC REFERENCES Monezi(MoneziM),
TaxaDeParticipareC NUMERIC(7,2),
MonedaTaxaDeParticipareC VARCHAR(50) CONSTRAINT fk_MonedaTaxaDeParticipareC REFERENCES Monezi(MoneziM),
TaxaDeVizaEtcC NUMERIC(7,2),
MonedaTaxaDeVizaEtcC VARCHAR(50) CONSTRAINT fk_MonedaTaxaDeVizaEtcC REFERENCES Monezi(MoneziM),
TotalC VARCHAR(50),
AmbasadaC VARCHAR(50),
NedeterminataC BOOLEAN,
DeterminataC BOOLEAN,
DecanC VARCHAR(30),
VizaContaC VARCHAR(30),
AdmSefBirouC VARCHAR(30),
SefDepartamentDirC VARCHAR(30),
VizaRUC VARCHAR(30),
TIOZC BOOLEAN
);

-- Creare tabela OreRecuperate
CREATE TABLE OreRecuperate (
NrCerereOR NUMERIC(5) CONSTRAINT fk_NrCrtOR REFERENCES Cereri(NrInregistrareC),
NrCrtOR NUMERIC(5),
DenDisciplinaOR VARCHAR(30),
DataOR DATE,
OraOR time,
SalaOR VARCHAR(5)
);

-- Creare tabela ConditiiDePlata
CREATE TABLE ConditiiDePlata (
NrCerereCDP NUMERIC(5) CONSTRAINT fk_NrCrtCDP REFERENCES Cereri(NrInregistrareC),
NrCrtCDP NUMERIC(5),
NumePrenProfCDP VARCHAR(30),
DenDisciplinaCDP VARCHAR(50),
CondDePlataCDP VARCHAR(70)
);

-- Creare tabela Rectori
CREATE TABLE Rectori (
Rector VARCHAR(50) CONSTRAINT pk_Rector PRIMARY KEY,
EMailR VARCHAR(50),
TelefonR NUMERIC(12)
);

-- Creare tabela ProRectori
CREATE TABLE ProRectori (
ProRector VARCHAR(50) CONSTRAINT pk_ProRector PRIMARY KEY,
EMailP VARCHAR(50),
TelefonP1 NUMERIC(12) NOT NULL,
TelefonP2 NUMERIC(12)
);

-- Creare tabela CereriBECA
CREATE TABLE OrdineDeplasare (
NrInregistrareBC NUMERIC(5) CONSTRAINT fk_NrInregistrareCBC REFERENCES Cereri(NrInregistrareC),
NrInregistrareB NUMERIC(5) CONSTRAINT pk_NrInregistrareCB PRIMARY KEY
);