CREATE DATABASE M_Cleveland

USE M_Cleveland

CREATE TABLE Medicos (
IdMedico INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL,
DataDeNascimento DATE NOT NULL,
Crm INT NOT NULL,
IdEspecialidade INT FOREIGN KEY REFERENCES Especialidades(IdEspecialidade),
Ativo BIT NOT NULL DEFAULT(1)
)

CREATE TABLE Especialidades (
IdEspecialidade INT PRIMARY KEY IDENTITY,
Especialidade VARCHAR(255) NOT NULL
)

INSERT INTO Especialidades VALUES ('Ginecologista'), ('Obstétrica'), ('Clínico Geral'),('Oncologista'),('Pediatra'),('Oftalmologista')

SELECT * FROM Especialidades

INSERT INTO Medicos (Nome, DataDeNascimento, Crm, IdEspecialidade) VALUES ('Jorge Godoy','02/11/1967',705632,1), ('Clayton Pereira','21/04/1981',685279,6), ('Adelmar Martinez','09/01/1959',941662,5), ('Caio Fernandes','29/09/1970',561819, 4)

CREATE VIEW vmMedicosEspecialidades AS
SELECT M.IdMedico, M.Nome, M.Crm, M.DataDeNascimento, E.Especialidade, M.Ativo FROM Medicos M JOIN Especialidades E ON M.IdEspecialidade = E.IdEspecialidade 

SELECT * FROM vmMedicosEspecialidades