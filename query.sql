create database LaptopsDb

use LaptopsDb

CREATE TABLE Gaming (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
    Price FLOAT
)

CREATE TABLE Business (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
    Price FLOAT
)

CREATE TABLE ThinLight (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
    Price FLOAT
)