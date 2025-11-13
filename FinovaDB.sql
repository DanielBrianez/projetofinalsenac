CREATE DATABASE FinovaDB;
GO

USE FinovaDB;
GO

CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    SenhaHash NVARCHAR(255)
);

CREATE TABLE Categorias (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    NomeCategoria NVARCHAR(100),
    TipoCategoria NVARCHAR(10),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
);

CREATE TABLE Transacoes (
    IdTransacao INT PRIMARY KEY IDENTITY(1,1),
    Valor DECIMAL(10,2),
    TipoTransacao NVARCHAR(10),
    DataTransacao DATE,
    Descricao NVARCHAR(255),
    IdCategoria INT FOREIGN KEY REFERENCES Categorias(IdCategoria),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
);