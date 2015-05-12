-- Script Creare BD

DROP TABLE IF EXISTS OrdineDeplasare;
DROP TABLE IF EXISTS Rectori;
DROP TABLE IF EXISTS ProRectori;
DROP TABLE IF EXISTS OreRecuperate;
DROP TABLE IF EXISTS ConditiiDePlata;
DROP TABLE IF EXISTS Cereri;
DROP TABLE IF EXISTS GradeDidactice;
DROP TABLE IF EXISTS Facultati;
DROP TABLE IF EXISTS Scopuri;
DROP TABLE IF EXISTS ScopuriConferinte;
DROP TABLE IF EXISTS ScopuriAltele;
DROP TABLE IF EXISTS Tari;
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

-- Creare tabela Tari
CREATE TABLE Tari (
TariT VARCHAR(150) CONSTRAINT pk_TariT PRIMARY KEY
);

-- Creare tabela Scopuri
CREATE TABLE Scopuri (
ScopuriS VARCHAR(150) CONSTRAINT pk_ScopuriS PRIMARY KEY
);

-- Creare tabela Scopuri
CREATE TABLE ScopuriConferinte (
ScopuriConferinteSC VARCHAR(150) CONSTRAINT pk_ScopuriConferinteSC PRIMARY KEY
);

-- Creare tabela Scopuri
CREATE TABLE ScopuriAltele (
ScopuriAlteleSA VARCHAR(150) CONSTRAINT pk_ScopuriAlteleSA PRIMARY KEY
);

-- Creare tabela Cereri
CREATE TABLE Cereri (
NrInregistrareC NUMERIC(5) CONSTRAINT pk_NrInregistrareC PRIMARY KEY,
DataC DATE,
SubsemnatulC VARCHAR(70),
GradDidacticC VARCHAR(50) CONSTRAINT fk_GradDidacticC REFERENCES GradeDidactice(GradDidacticGD) ON UPDATE CASCADE,
FacultateaC VARCHAR(50) CONSTRAINT fk_FacultateaC REFERENCES Facultati(FacultatiF) ON UPDATE CASCADE,
DepartamentulC VARCHAR(50),
TaraC VARCHAR(100) CONSTRAINT fk_TaraC REFERENCES Tari(TariT) ON UPDATE CASCADE,
LocalitateaC VARCHAR(100),
ScopC VARCHAR(200) CONSTRAINT fk_ScopC REFERENCES Scopuri(ScopuriS) ON UPDATE CASCADE,
ScopConferintaC VARCHAR(200) CONSTRAINT fk_ScopConferintaC REFERENCES ScopuriConferinte(ScopuriConferinteSC) ON UPDATE CASCADE,
ScopAlteleC VARCHAR(200) CONSTRAINT fk_ScopAlteleC REFERENCES ScopuriAltele(ScopuriAlteleSA) ON UPDATE CASCADE,
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
NrInregistrareODC NUMERIC(5) CONSTRAINT fk_NrInregistrareBC REFERENCES Cereri(NrInregistrareC),
NrInregistrareOD NUMERIC(10),
NrInregistrareODNou NUMERIC(10),
DataOD DATE,
DataODNoua DATE,
SubsemnatulOD VARCHAR(70),
GradDidacticOD VARCHAR(50) CONSTRAINT fk_GradDidacticC REFERENCES GradeDidactice(GradDidacticGD) ON UPDATE CASCADE,
FacultateaOD VARCHAR(50) CONSTRAINT fk_FacultateaC REFERENCES Facultati(FacultatiF) ON UPDATE CASCADE,
TaraOD VARCHAR(100) CONSTRAINT fk_TaraOD REFERENCES Tari(TariT) ON UPDATE CASCADE,
LocalitateaOD VARCHAR(100),
ScopOD VARCHAR(200) CONSTRAINT fk_ScopOD REFERENCES Scopuri(ScopuriS) ON UPDATE CASCADE,
ScopConferintaOD VARCHAR(200) CONSTRAINT fk_ScopConferintaOD REFERENCES ScopuriConferinte(ScopuriConferinteSC) ON UPDATE CASCADE,
ScopAlteleOD VARCHAR(200) CONSTRAINT fk_ScopAlteleOD REFERENCES ScopuriAltele(ScopuriAlteleSA) ON UPDATE CASCADE,
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
AlteDispuneri1OD VARCHAR(150),
AlteDispuneri2OD VARCHAR(150),
AlteDispuneri3OD VARCHAR(150),
AlteDispuneri4OD VARCHAR(150),
RectorOD BOOLEAN,
ProrectorOD BOOLEAN,
NumeRPOD VARCHAR(100),
DFCOD VARCHAR(100),
CPNumeProjOD VARCHAR(300),
CPGradDidacticOD VARCHAR(50),
CPNumeCoordOD VARCHAR(100),
ODDI BOOLEAN
);

-- Inserari
INSERT INTO gradedidactice(graddidacticgd) values ('asistent');
INSERT INTO gradedidactice(graddidacticgd) values ('decan');
INSERT INTO gradedidactice(graddidacticgd) values ('lect. univ.');
INSERT INTO gradedidactice(graddidacticgd) values ('conf. univ.');
INSERT INTO gradedidactice(graddidacticgd) values ('prodecan');
INSERT INTO gradedidactice(graddidacticgd) values ('prof. dr.');
INSERT INTO gradedidactice(graddidacticgd) values ('student');

INSERT INTO facultati(facultatif) values ('Biologie');
INSERT INTO facultati(facultatif) values ('Chimie');
INSERT INTO facultati(facultatif) values ('Drept');
INSERT INTO facultati(facultatif) values ('Educație Fizică și Sport');
INSERT INTO facultati(facultatif) values ('Fizică');
INSERT INTO facultati(facultatif) values ('Geografie și Geologie');
INSERT INTO facultati(facultatif) values ('FEAA');
INSERT INTO facultati(facultatif) values ('Informatică');
INSERT INTO facultati(facultatif) values ('Istorie');
INSERT INTO facultati(facultatif) values ('Litere');
INSERT INTO facultati(facultatif) values ('Matematica');
INSERT INTO facultati(facultatif) values ('Psihologie și Științe ale Educației');
INSERT INTO facultati(facultatif) values ('Teologie Romano-Catolică');
INSERT INTO facultati(facultatif) values ('Filosofie și Științe Social-Politice');
INSERT INTO facultati(facultatif) values ('Teologie Ortodoxă');

INSERT INTO monezi(monezim) values ('RON');
INSERT INTO monezi(monezim) values ('EUR');
INSERT INTO monezi(monezim) values ('USD');
INSERT INTO monezi(monezim) values ('GBP');
INSERT INTO monezi(monezim) values ('CHF');

INSERT INTO rectori(rector, emailr, telefonr) values ('Vasile IȘAN', 'vasileisan@uaic.ro', 0123456789);

INSERT INTO prorectori(prorector, emailp, telefonp1, telefonp2) values ('prorector1', 'prorector1@uaic.ro', 0123456789, 1234567890);
INSERT INTO prorectori(prorector, emailp, telefonp1, telefonp2) values ('prorector2', 'prorector2@uaic.ro', 0123456789, 1234567890);

INSERT INTO tari(tarit) values ('Afganistan');
INSERT INTO tari(tarit) values ('Africa de Sud');
INSERT INTO tari(tarit) values ('Albania');
INSERT INTO tari(tarit) values ('Algeria');
INSERT INTO tari(tarit) values ('Andorra');
INSERT INTO tari(tarit) values ('Angola');
INSERT INTO tari(tarit) values ('Antigua si Barbuda');
INSERT INTO tari(tarit) values ('Argentina');
INSERT INTO tari(tarit) values ('Armenia');
INSERT INTO tari(tarit) values ('Australia');
INSERT INTO tari(tarit) values ('Austria');
INSERT INTO tari(tarit) values ('Azerbaijan');
INSERT INTO tari(tarit) values ('Bahamas');
INSERT INTO tari(tarit) values ('Bahrain');
INSERT INTO tari(tarit) values ('Bangladesh');
INSERT INTO tari(tarit) values ('Barbados');
INSERT INTO tari(tarit) values ('Belarus');
INSERT INTO tari(tarit) values ('Belgia');
INSERT INTO tari(tarit) values ('Belize');
INSERT INTO tari(tarit) values ('Benin');
INSERT INTO tari(tarit) values ('Bhutan');
INSERT INTO tari(tarit) values ('Bolivia');
INSERT INTO tari(tarit) values ('Bosnia si Herzegovina');
INSERT INTO tari(tarit) values ('Botswana');
INSERT INTO tari(tarit) values ('Brazilia');
INSERT INTO tari(tarit) values ('Brunei');
INSERT INTO tari(tarit) values ('Bulgaria');
INSERT INTO tari(tarit) values ('Burkina Faso');
INSERT INTO tari(tarit) values ('Burma/Myanmar');
INSERT INTO tari(tarit) values ('Burundi');
INSERT INTO tari(tarit) values ('Cambogia');
INSERT INTO tari(tarit) values ('Camerun');
INSERT INTO tari(tarit) values ('Canada');
INSERT INTO tari(tarit) values ('Cape Verde');
INSERT INTO tari(tarit) values ('Republica Central Africană');
INSERT INTO tari(tarit) values ('Chad');
INSERT INTO tari(tarit) values ('Chile');
INSERT INTO tari(tarit) values ('China');
INSERT INTO tari(tarit) values ('Columbia');
INSERT INTO tari(tarit) values ('Comoros');
INSERT INTO tari(tarit) values ('Congo');
INSERT INTO tari(tarit) values ('Republica Democratica Congo');
INSERT INTO tari(tarit) values ('Coreea de Nord');
INSERT INTO tari(tarit) values ('Coreea de Sud');
INSERT INTO tari(tarit) values ('Costa Rica');
INSERT INTO tari(tarit) values ('Coasta de Fildes');
INSERT INTO tari(tarit) values ('Croatia');
INSERT INTO tari(tarit) values ('Cuba');
INSERT INTO tari(tarit) values ('Cipru');
INSERT INTO tari(tarit) values ('Republica Cehia');
INSERT INTO tari(tarit) values ('Danemarca');
INSERT INTO tari(tarit) values ('Djibouti');
INSERT INTO tari(tarit) values ('Dominica');
INSERT INTO tari(tarit) values ('Republica Dominicana');
INSERT INTO tari(tarit) values ('Timorul de Est');
INSERT INTO tari(tarit) values ('Ecuador');
INSERT INTO tari(tarit) values ('Egipt');
INSERT INTO tari(tarit) values ('El Salvador');
INSERT INTO tari(tarit) values ('Elvetia');
INSERT INTO tari(tarit) values ('Emiratele Arabe Unite');
INSERT INTO tari(tarit) values ('Eritrea');
INSERT INTO tari(tarit) values ('Estonia');
INSERT INTO tari(tarit) values ('Etiopia');
INSERT INTO tari(tarit) values ('Fiji');
INSERT INTO tari(tarit) values ('Filipine');
INSERT INTO tari(tarit) values ('Finlanda');
INSERT INTO tari(tarit) values ('Franța');
INSERT INTO tari(tarit) values ('Gambia');
INSERT INTO tari(tarit) values ('Georgia');
INSERT INTO tari(tarit) values ('Germania');
INSERT INTO tari(tarit) values ('Ghana');
INSERT INTO tari(tarit) values ('Grecia');
INSERT INTO tari(tarit) values ('Grenada');
INSERT INTO tari(tarit) values ('Guatemala');
INSERT INTO tari(tarit) values ('Guineea');
INSERT INTO tari(tarit) values ('Guineea-Bissau');
INSERT INTO tari(tarit) values ('Guineea Ecuatoriala');
INSERT INTO tari(tarit) values ('Guyana');
INSERT INTO tari(tarit) values ('Haiti');
INSERT INTO tari(tarit) values ('Honduras');
INSERT INTO tari(tarit) values ('Islanda');
INSERT INTO tari(tarit) values ('India');
INSERT INTO tari(tarit) values ('Indonezia');
INSERT INTO tari(tarit) values ('Iordania');
INSERT INTO tari(tarit) values ('Insulele Solomon');
INSERT INTO tari(tarit) values ('Iran');
INSERT INTO tari(tarit) values ('Iraq');
INSERT INTO tari(tarit) values ('Irlanda');
INSERT INTO tari(tarit) values ('Israel');
INSERT INTO tari(tarit) values ('Italia');
INSERT INTO tari(tarit) values ('Jamaica');
INSERT INTO tari(tarit) values ('Japonia');
INSERT INTO tari(tarit) values ('Kazahstan');
INSERT INTO tari(tarit) values ('Kenia');
INSERT INTO tari(tarit) values ('Kiribati');
INSERT INTO tari(tarit) values ('Kuweit');
INSERT INTO tari(tarit) values ('Kârgâzstan');
INSERT INTO tari(tarit) values ('Laos');
INSERT INTO tari(tarit) values ('Letonia');
INSERT INTO tari(tarit) values ('Liban');
INSERT INTO tari(tarit) values ('Lesotho');
INSERT INTO tari(tarit) values ('Liberia');
INSERT INTO tari(tarit) values ('Libia');
INSERT INTO tari(tarit) values ('Lichtenstein');
INSERT INTO tari(tarit) values ('Lithuania');
INSERT INTO tari(tarit) values ('Luxemburg');
INSERT INTO tari(tarit) values ('Macedonia');
INSERT INTO tari(tarit) values ('Madagascar');
INSERT INTO tari(tarit) values ('Malawi');
INSERT INTO tari(tarit) values ('Malaezia');
INSERT INTO tari(tarit) values ('Maldive');
INSERT INTO tari(tarit) values ('Mali');
INSERT INTO tari(tarit) values ('Malta');
INSERT INTO tari(tarit) values ('Insulele Marshall');
INSERT INTO tari(tarit) values ('Mauritania');
INSERT INTO tari(tarit) values ('Mexic');
INSERT INTO tari(tarit) values ('Micronezia');
INSERT INTO tari(tarit) values ('Republica Moldova');
INSERT INTO tari(tarit) values ('Monaco');
INSERT INTO tari(tarit) values ('Mongolia');
INSERT INTO tari(tarit) values ('Muntenegru');
INSERT INTO tari(tarit) values ('Maroc');
INSERT INTO tari(tarit) values ('Mozambic');
INSERT INTO tari(tarit) values ('Namibia');
INSERT INTO tari(tarit) values ('Nauru');
INSERT INTO tari(tarit) values ('Nepal');
INSERT INTO tari(tarit) values ('Noua Zeelanda');
INSERT INTO tari(tarit) values ('Nicaragua');
INSERT INTO tari(tarit) values ('Nigeri');
INSERT INTO tari(tarit) values ('Nigeria');
INSERT INTO tari(tarit) values ('Norvegia');
INSERT INTO tari(tarit) values ('Oman');
INSERT INTO tari(tarit) values ('Olanda');
INSERT INTO tari(tarit) values ('Pakistan');
INSERT INTO tari(tarit) values ('Palau');
INSERT INTO tari(tarit) values ('Panama');
INSERT INTO tari(tarit) values ('Papua noua Guinee');
INSERT INTO tari(tarit) values ('Paraguai');
INSERT INTO tari(tarit) values ('Peru');
INSERT INTO tari(tarit) values ('Polonia');
INSERT INTO tari(tarit) values ('Portugalia');
INSERT INTO tari(tarit) values ('Qatar');
INSERT INTO tari(tarit) values ('Regatul Unit');
INSERT INTO tari(tarit) values ('Romania');
INSERT INTO tari(tarit) values ('Federatia Rusa');
INSERT INTO tari(tarit) values ('Rwanda');
INSERT INTO tari(tarit) values ('Saint Kitts and Nevis');
INSERT INTO tari(tarit) values ('Saint Lucia');
INSERT INTO tari(tarit) values ('Saint Vincent and the Grenadines');
INSERT INTO tari(tarit) values ('Samoa');
INSERT INTO tari(tarit) values ('San Marino');
INSERT INTO tari(tarit) values ('Sao Tome and Principe');
INSERT INTO tari(tarit) values ('Saudi Arabia');
INSERT INTO tari(tarit) values ('Senegal');
INSERT INTO tari(tarit) values ('Serbia');
INSERT INTO tari(tarit) values ('Seychelles');
INSERT INTO tari(tarit) values ('Singapore');
INSERT INTO tari(tarit) values ('Slovacia');
INSERT INTO tari(tarit) values ('Slovenia');
INSERT INTO tari(tarit) values ('Somalia');
INSERT INTO tari(tarit) values ('Statele Unite Ale Americii');
INSERT INTO tari(tarit) values ('Sudanul de Sud');
INSERT INTO tari(tarit) values ('Spania');
INSERT INTO tari(tarit) values ('Sri Lanka');
INSERT INTO tari(tarit) values ('Sudan');
INSERT INTO tari(tarit) values ('Surinam');
INSERT INTO tari(tarit) values ('Swaziland');
INSERT INTO tari(tarit) values ('Suedia');
INSERT INTO tari(tarit) values ('Siria');
INSERT INTO tari(tarit) values ('Tadjikistan');
INSERT INTO tari(tarit) values ('Tanzania');
INSERT INTO tari(tarit) values ('Tailanda');
INSERT INTO tari(tarit) values ('Togo');
INSERT INTO tari(tarit) values ('Tonga');
INSERT INTO tari(tarit) values ('Trinidad si Tobago');
INSERT INTO tari(tarit) values ('Tunisia');
INSERT INTO tari(tarit) values ('Turcia');
INSERT INTO tari(tarit) values ('Turkmenistan');
INSERT INTO tari(tarit) values ('Tuvalu');
INSERT INTO tari(tarit) values ('Uganda');
INSERT INTO tari(tarit) values ('Ucraina');
INSERT INTO tari(tarit) values ('Ungaria');
INSERT INTO tari(tarit) values ('Uruguai');
INSERT INTO tari(tarit) values ('Uzbekistan');
INSERT INTO tari(tarit) values ('Vanuatu');
INSERT INTO tari(tarit) values ('Vatican');
INSERT INTO tari(tarit) values ('Venezuela');
INSERT INTO tari(tarit) values ('Vietnam');
INSERT INTO tari(tarit) values ('Yemen');
INSERT INTO tari(tarit) values ('Zambia');
INSERT INTO tari(tarit) values ('Zimbabwe');

INSERT INTO scopuri(scopuris) values ('Scop A');
INSERT INTO scopuri(scopuris) values ('Scop B');
INSERT INTO scopuri(scopuris) values ('Scop C');
INSERT INTO scopuri(scopuris) values ('Scop D');
INSERT INTO scopuri(scopuris) values ('Scop E');
INSERT INTO scopuri(scopuris) values ('Scop F');
INSERT INTO scopuri(scopuris) values ('Scop G');
INSERT INTO scopuri(scopuris) values ('Scop H');