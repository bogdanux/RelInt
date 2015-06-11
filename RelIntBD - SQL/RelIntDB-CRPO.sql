-- Script Creare BD

DROP TABLE IF EXISTS OrdineDeplasare;
DROP TABLE IF EXISTS Rectori;
DROP TABLE IF EXISTS ProRectori;
DROP TABLE IF EXISTS COS;
DROP TABLE IF EXISTS ODP;
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
NrZileDiurnaC NUMERIC(7,2),
DiurnaC NUMERIC(7,2),
MonedaDiurnaC VARCHAR(50) CONSTRAINT fk_MonedaDiurnaC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaCazareC BOOLEAN,
NrZileCazareC NUMERIC(7,2),
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

-- Creare tabela ODP
CREATE TABLE ODP (
ODPO VARCHAR(300) CONSTRAINT pk_ODP PRIMARY KEY
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
NrZileDiurnaOD NUMERIC(7,2),
DiurnaOD NUMERIC(7,2),
MonedaDiurnaOD VARCHAR(50) CONSTRAINT fk_MonedaDiurnaC REFERENCES Monezi(MoneziM) ON UPDATE CASCADE,
BifaCazareOD BOOLEAN,
NrZileCazareOD NUMERIC(7,2),
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
ODPOD VARCHAR(300),
AlteDispuneri1OD VARCHAR(150),
AlteDispuneri2OD VARCHAR(150),
AlteDispuneri3OD VARCHAR(150),
AlteDispuneri4OD VARCHAR(150),
RectorOD BOOLEAN,
ProrectorOD BOOLEAN,
NumeRPOD VARCHAR(100),
BifaDFCOD BOOLEAN,
DFCOD VARCHAR(100),
BifaCPOD BOOLEAN,
BifaCPTip1OD BOOLEAN,
CPNumeProjOD VARCHAR(300),
CPGradDidacticOD VARCHAR(70) CONSTRAINT fk_CPGradDidacticOD REFERENCES GradeDidactice(GradDidacticGD) ON UPDATE CASCADE,
CPNumeCoordOD VARCHAR(100),
BifaCPTip2OD BOOLEAN,
CPGDDecanOD VARCHAR(70),
CPNumeDecanOD VARCHAR(300),
ODDI BOOLEAN
);

-- Inserari
INSERT INTO gradedidactice(graddidacticgd) VALUES ('asistent');
INSERT INTO gradedidactice(graddidacticgd) VALUES ('decan');
INSERT INTO gradedidactice(graddidacticgd) VALUES ('lect. univ.');
INSERT INTO gradedidactice(graddidacticgd) VALUES ('conf. univ.');
INSERT INTO gradedidactice(graddidacticgd) VALUES ('prodecan');
INSERT INTO gradedidactice(graddidacticgd) VALUES ('prof. dr.');
INSERT INTO gradedidactice(graddidacticgd) VALUES ('student');

INSERT INTO facultati(facultatif) VALUES ('Biologie');
INSERT INTO facultati(facultatif) VALUES ('Chimie');
INSERT INTO facultati(facultatif) VALUES ('Drept');
INSERT INTO facultati(facultatif) VALUES ('Educație Fizică și Sport');
INSERT INTO facultati(facultatif) VALUES ('Fizică');
INSERT INTO facultati(facultatif) VALUES ('Geografie și Geologie');
INSERT INTO facultati(facultatif) VALUES ('FEAA');
INSERT INTO facultati(facultatif) VALUES ('Informatică');
INSERT INTO facultati(facultatif) VALUES ('Istorie');
INSERT INTO facultati(facultatif) VALUES ('Litere');
INSERT INTO facultati(facultatif) VALUES ('Matematica');
INSERT INTO facultati(facultatif) VALUES ('Psihologie și Științe ale Educației');
INSERT INTO facultati(facultatif) VALUES ('Teologie Romano-Catolică');
INSERT INTO facultati(facultatif) VALUES ('Filosofie și Științe Social-Politice');
INSERT INTO facultati(facultatif) VALUES ('Teologie Ortodoxă');

INSERT INTO monezi(monezim) VALUES ('RON');
INSERT INTO monezi(monezim) VALUES ('EUR');
INSERT INTO monezi(monezim) VALUES ('USD');
INSERT INTO monezi(monezim) VALUES ('GBP');
INSERT INTO monezi(monezim) VALUES ('CHF');

INSERT INTO rectori(rector, emailr, telefonr, rectorcurent) VALUES ('Vasile IȘAN', 'vasileisan@uaic.ro', 0123456789, true);

INSERT INTO prorectori(prorector, emailp, telefonp1, telefonp2, sectorp) VALUES ('prorector1', 'prorector1@uaic.ro', 0123456789, 1234567890, 'activitate în cadrul departamentului XXX');
INSERT INTO prorectori(prorector, emailp, telefonp1, telefonp2, sectorp) VALUES ('prorector2', 'prorector2@uaic.ro', 0123456789, 1234567890, 'activitate în cadrul departamentului ZZZ');

INSERT INTO tari(tarit) VALUES ('Afganistan');
INSERT INTO tari(tarit) VALUES ('Africa de Sud');
INSERT INTO tari(tarit) VALUES ('Albania');
INSERT INTO tari(tarit) VALUES ('Algeria');
INSERT INTO tari(tarit) VALUES ('Andorra');
INSERT INTO tari(tarit) VALUES ('Angola');
INSERT INTO tari(tarit) VALUES ('Antigua si Barbuda');
INSERT INTO tari(tarit) VALUES ('Argentina');
INSERT INTO tari(tarit) VALUES ('Armenia');
INSERT INTO tari(tarit) VALUES ('Australia');
INSERT INTO tari(tarit) VALUES ('Austria');
INSERT INTO tari(tarit) VALUES ('Azerbaijan');
INSERT INTO tari(tarit) VALUES ('Bahamas');
INSERT INTO tari(tarit) VALUES ('Bahrain');
INSERT INTO tari(tarit) VALUES ('Bangladesh');
INSERT INTO tari(tarit) VALUES ('Barbados');
INSERT INTO tari(tarit) VALUES ('Belarus');
INSERT INTO tari(tarit) VALUES ('Belgia');
INSERT INTO tari(tarit) VALUES ('Belize');
INSERT INTO tari(tarit) VALUES ('Benin');
INSERT INTO tari(tarit) VALUES ('Bhutan');
INSERT INTO tari(tarit) VALUES ('Bolivia');
INSERT INTO tari(tarit) VALUES ('Bosnia si Herzegovina');
INSERT INTO tari(tarit) VALUES ('Botswana');
INSERT INTO tari(tarit) VALUES ('Brazilia');
INSERT INTO tari(tarit) VALUES ('Brunei');
INSERT INTO tari(tarit) VALUES ('Bulgaria');
INSERT INTO tari(tarit) VALUES ('Burkina Faso');
INSERT INTO tari(tarit) VALUES ('Burma/Myanmar');
INSERT INTO tari(tarit) VALUES ('Burundi');
INSERT INTO tari(tarit) VALUES ('Cambogia');
INSERT INTO tari(tarit) VALUES ('Camerun');
INSERT INTO tari(tarit) VALUES ('Canada');
INSERT INTO tari(tarit) VALUES ('Cape Verde');
INSERT INTO tari(tarit) VALUES ('Republica Central Africană');
INSERT INTO tari(tarit) VALUES ('Chad');
INSERT INTO tari(tarit) VALUES ('Chile');
INSERT INTO tari(tarit) VALUES ('China');
INSERT INTO tari(tarit) VALUES ('Columbia');
INSERT INTO tari(tarit) VALUES ('Comoros');
INSERT INTO tari(tarit) VALUES ('Congo');
INSERT INTO tari(tarit) VALUES ('Republica Democratica Congo');
INSERT INTO tari(tarit) VALUES ('Coreea de Nord');
INSERT INTO tari(tarit) VALUES ('Coreea de Sud');
INSERT INTO tari(tarit) VALUES ('Costa Rica');
INSERT INTO tari(tarit) VALUES ('Coasta de Fildes');
INSERT INTO tari(tarit) VALUES ('Croatia');
INSERT INTO tari(tarit) VALUES ('Cuba');
INSERT INTO tari(tarit) VALUES ('Cipru');
INSERT INTO tari(tarit) VALUES ('Republica Cehia');
INSERT INTO tari(tarit) VALUES ('Danemarca');
INSERT INTO tari(tarit) VALUES ('Djibouti');
INSERT INTO tari(tarit) VALUES ('Dominica');
INSERT INTO tari(tarit) VALUES ('Republica Dominicana');
INSERT INTO tari(tarit) VALUES ('Timorul de Est');
INSERT INTO tari(tarit) VALUES ('Ecuador');
INSERT INTO tari(tarit) VALUES ('Egipt');
INSERT INTO tari(tarit) VALUES ('El Salvador');
INSERT INTO tari(tarit) VALUES ('Elvetia');
INSERT INTO tari(tarit) VALUES ('Emiratele Arabe Unite');
INSERT INTO tari(tarit) VALUES ('Eritrea');
INSERT INTO tari(tarit) VALUES ('Estonia');
INSERT INTO tari(tarit) VALUES ('Etiopia');
INSERT INTO tari(tarit) VALUES ('Fiji');
INSERT INTO tari(tarit) VALUES ('Filipine');
INSERT INTO tari(tarit) VALUES ('Finlanda');
INSERT INTO tari(tarit) VALUES ('Franța');
INSERT INTO tari(tarit) VALUES ('Gambia');
INSERT INTO tari(tarit) VALUES ('Georgia');
INSERT INTO tari(tarit) VALUES ('Germania');
INSERT INTO tari(tarit) VALUES ('Ghana');
INSERT INTO tari(tarit) VALUES ('Grecia');
INSERT INTO tari(tarit) VALUES ('Grenada');
INSERT INTO tari(tarit) VALUES ('Guatemala');
INSERT INTO tari(tarit) VALUES ('Guineea');
INSERT INTO tari(tarit) VALUES ('Guineea-Bissau');
INSERT INTO tari(tarit) VALUES ('Guineea Ecuatoriala');
INSERT INTO tari(tarit) VALUES ('Guyana');
INSERT INTO tari(tarit) VALUES ('Haiti');
INSERT INTO tari(tarit) VALUES ('Honduras');
INSERT INTO tari(tarit) VALUES ('Islanda');
INSERT INTO tari(tarit) VALUES ('India');
INSERT INTO tari(tarit) VALUES ('Indonezia');
INSERT INTO tari(tarit) VALUES ('Iordania');
INSERT INTO tari(tarit) VALUES ('Insulele Solomon');
INSERT INTO tari(tarit) VALUES ('Iran');
INSERT INTO tari(tarit) VALUES ('Iraq');
INSERT INTO tari(tarit) VALUES ('Irlanda');
INSERT INTO tari(tarit) VALUES ('Israel');
INSERT INTO tari(tarit) VALUES ('Italia');
INSERT INTO tari(tarit) VALUES ('Jamaica');
INSERT INTO tari(tarit) VALUES ('Japonia');
INSERT INTO tari(tarit) VALUES ('Kazahstan');
INSERT INTO tari(tarit) VALUES ('Kenia');
INSERT INTO tari(tarit) VALUES ('Kiribati');
INSERT INTO tari(tarit) VALUES ('Kuweit');
INSERT INTO tari(tarit) VALUES ('Kârgâzstan');
INSERT INTO tari(tarit) VALUES ('Laos');
INSERT INTO tari(tarit) VALUES ('Letonia');
INSERT INTO tari(tarit) VALUES ('Liban');
INSERT INTO tari(tarit) VALUES ('Lesotho');
INSERT INTO tari(tarit) VALUES ('Liberia');
INSERT INTO tari(tarit) VALUES ('Libia');
INSERT INTO tari(tarit) VALUES ('Lichtenstein');
INSERT INTO tari(tarit) VALUES ('Lithuania');
INSERT INTO tari(tarit) VALUES ('Luxemburg');
INSERT INTO tari(tarit) VALUES ('Macedonia');
INSERT INTO tari(tarit) VALUES ('Madagascar');
INSERT INTO tari(tarit) VALUES ('Malawi');
INSERT INTO tari(tarit) VALUES ('Malaezia');
INSERT INTO tari(tarit) VALUES ('Maldive');
INSERT INTO tari(tarit) VALUES ('Mali');
INSERT INTO tari(tarit) VALUES ('Malta');
INSERT INTO tari(tarit) VALUES ('Insulele Marshall');
INSERT INTO tari(tarit) VALUES ('Mauritania');
INSERT INTO tari(tarit) VALUES ('Mexic');
INSERT INTO tari(tarit) VALUES ('Micronezia');
INSERT INTO tari(tarit) VALUES ('Republica Moldova');
INSERT INTO tari(tarit) VALUES ('Monaco');
INSERT INTO tari(tarit) VALUES ('Mongolia');
INSERT INTO tari(tarit) VALUES ('Muntenegru');
INSERT INTO tari(tarit) VALUES ('Maroc');
INSERT INTO tari(tarit) VALUES ('Mozambic');
INSERT INTO tari(tarit) VALUES ('Namibia');
INSERT INTO tari(tarit) VALUES ('Nauru');
INSERT INTO tari(tarit) VALUES ('Nepal');
INSERT INTO tari(tarit) VALUES ('Noua Zeelanda');
INSERT INTO tari(tarit) VALUES ('Nicaragua');
INSERT INTO tari(tarit) VALUES ('Nigeri');
INSERT INTO tari(tarit) VALUES ('Nigeria');
INSERT INTO tari(tarit) VALUES ('Norvegia');
INSERT INTO tari(tarit) VALUES ('Oman');
INSERT INTO tari(tarit) VALUES ('Olanda');
INSERT INTO tari(tarit) VALUES ('Pakistan');
INSERT INTO tari(tarit) VALUES ('Palau');
INSERT INTO tari(tarit) VALUES ('Panama');
INSERT INTO tari(tarit) VALUES ('Papua noua Guinee');
INSERT INTO tari(tarit) VALUES ('Paraguai');
INSERT INTO tari(tarit) VALUES ('Peru');
INSERT INTO tari(tarit) VALUES ('Polonia');
INSERT INTO tari(tarit) VALUES ('Portugalia');
INSERT INTO tari(tarit) VALUES ('Qatar');
INSERT INTO tari(tarit) VALUES ('Regatul Unit');
INSERT INTO tari(tarit) VALUES ('Romania');
INSERT INTO tari(tarit) VALUES ('Federatia Rusa');
INSERT INTO tari(tarit) VALUES ('Rwanda');
INSERT INTO tari(tarit) VALUES ('Saint Kitts and Nevis');
INSERT INTO tari(tarit) VALUES ('Saint Lucia');
INSERT INTO tari(tarit) VALUES ('Saint Vincent and the Grenadines');
INSERT INTO tari(tarit) VALUES ('Samoa');
INSERT INTO tari(tarit) VALUES ('San Marino');
INSERT INTO tari(tarit) VALUES ('Sao Tome and Principe');
INSERT INTO tari(tarit) VALUES ('Saudi Arabia');
INSERT INTO tari(tarit) VALUES ('Senegal');
INSERT INTO tari(tarit) VALUES ('Serbia');
INSERT INTO tari(tarit) VALUES ('Seychelles');
INSERT INTO tari(tarit) VALUES ('Singapore');
INSERT INTO tari(tarit) VALUES ('Slovacia');
INSERT INTO tari(tarit) VALUES ('Slovenia');
INSERT INTO tari(tarit) VALUES ('Somalia');
INSERT INTO tari(tarit) VALUES ('Statele Unite Ale Americii');
INSERT INTO tari(tarit) VALUES ('Sudanul de Sud');
INSERT INTO tari(tarit) VALUES ('Spania');
INSERT INTO tari(tarit) VALUES ('Sri Lanka');
INSERT INTO tari(tarit) VALUES ('Sudan');
INSERT INTO tari(tarit) VALUES ('Surinam');
INSERT INTO tari(tarit) VALUES ('Swaziland');
INSERT INTO tari(tarit) VALUES ('Suedia');
INSERT INTO tari(tarit) VALUES ('Siria');
INSERT INTO tari(tarit) VALUES ('Tadjikistan');
INSERT INTO tari(tarit) VALUES ('Tanzania');
INSERT INTO tari(tarit) VALUES ('Tailanda');
INSERT INTO tari(tarit) VALUES ('Togo');
INSERT INTO tari(tarit) VALUES ('Tonga');
INSERT INTO tari(tarit) VALUES ('Trinidad si Tobago');
INSERT INTO tari(tarit) VALUES ('Tunisia');
INSERT INTO tari(tarit) VALUES ('Turcia');
INSERT INTO tari(tarit) VALUES ('Turkmenistan');
INSERT INTO tari(tarit) VALUES ('Tuvalu');
INSERT INTO tari(tarit) VALUES ('Uganda');
INSERT INTO tari(tarit) VALUES ('Ucraina');
INSERT INTO tari(tarit) VALUES ('Ungaria');
INSERT INTO tari(tarit) VALUES ('Uruguai');
INSERT INTO tari(tarit) VALUES ('Uzbekistan');
INSERT INTO tari(tarit) VALUES ('Vanuatu');
INSERT INTO tari(tarit) VALUES ('Vatican');
INSERT INTO tari(tarit) VALUES ('Venezuela');
INSERT INTO tari(tarit) VALUES ('Vietnam');
INSERT INTO tari(tarit) VALUES ('Yemen');
INSERT INTO tari(tarit) VALUES ('Zambia');
INSERT INTO tari(tarit) VALUES ('Zimbabwe');

INSERT INTO scopuri(scopuris) VALUES ('vizite de reprezentare la instituţii din străinătate');
INSERT INTO scopuri(scopuris) VALUES ('participarea la adunări generale / întâlniri de lucru organizate în cadrul  asociațiilor universitare / parteneriatelor internaționale multiple în care UAIC este membră');
INSERT INTO scopuri(scopuris) VALUES ('încheieri de convenţii, acorduri, parteneriate cu instituţii din străinătate');
INSERT INTO scopuri(scopuris) VALUES ('participări la târguri / expoziţii');
INSERT INTO scopuri(scopuris) VALUES ('acţiuni de cooperare instituţională şi tehnico-ştiinţifică');
INSERT INTO scopuri(scopuris) VALUES ('stagiu de studii / practică / practică itinerantă');
INSERT INTO scopuri(scopuris) VALUES ('stagiu de cercetare / documentare');
INSERT INTO scopuri(scopuris) VALUES ('schimb de experienţă');
INSERT INTO scopuri(scopuris) VALUES ('participarea la întâlniri organizate în cadrul unui proiect în care Universitatea este partener');
INSERT INTO scopuri(scopuris) VALUES ('participarea la cursuri şi stagii de specializare / perfecţionare / formare');
INSERT INTO scopuri(scopuris) VALUES ('participarea cadrelor didactice ca însoţitori ai studenţilor la olimpiade şi concursuri în domeniul învăţământului');
INSERT INTO scopuri(scopuris) VALUES ('participări la congrese / conferinţe / simpozioane / seminarii / colocvii sau alte reuniuni de interes pentru activitatea specifică a Universităţii, sau la manifestări ştiinţifice, culturale, artistice, sportive etc');
INSERT INTO scopuri(scopuris) VALUES ('primiri de titluri / grade profesionale / distincţii sau premii conferite pentru realizări ştiinţifice, culturale, artistice sau sportive');
INSERT INTO scopuri(scopuris) VALUES ('desfăşurarea unei activităţi ştiinţifice, culturale, artistice sau sportive, temporare, precum şi pentru ţinerea de cursuri în calitate de profesor / cercetător vizitator / invitat');

INSERT INTO DFC(DFCD) VALUES ('Ec. Liliana IFTIMIA');
INSERT INTO COS(COSC) VALUES ('3. Serviciile CONTABILITATE și ORGANIZARE - SALARIZARE vor duce la îndeplinire prevederile prezentei dispoziții.');
INSERT INTO ODP(ODPO) VALUES ('4. Pe perioada deplasării, se asigură salariul în țară conform normelor în vigoare.');