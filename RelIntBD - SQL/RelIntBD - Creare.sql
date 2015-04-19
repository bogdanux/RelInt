-- Script Creare BD

DROP TABLE IF EXISTS ConditiiDePlata;
DROP TABLE IF EXISTS OreRecuperate;
DROP TABLE IF EXISTS Cereri;

-------------------------------------

-- Creare tabela Cereri
CREATE TABLE Cereri (
NrInregistrareC NUMERIC(5) CONSTRAINT pk_NrInregistrareC PRIMARY KEY,
DataC DATE,
SubsemnatulC VARCHAR(70),
GradDidacticC VARCHAR(30),
FacultateaC VARCHAR(30),
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
DiurnaC NUMERIC(7,2),
CazareC NUMERIC(7,2),
TaxaDeParticipareC NUMERIC(7,2),
TaxaDeVizaEtcC NUMERIC(7,2),
TotalC NUMERIC (7,2),
AmbasadaC VARCHAR(50),
NedeterminataC BOOLEAN,
DeterminataC BOOLEAN,
DecanC VARCHAR(30),
VizaContaC VARCHAR(30),
AdmSefBirouC VARCHAR(30),
SefDepartamentDirC VARCHAR(30),
VizaRUC VARCHAR(30),
TIOZ BOOLEAN
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
