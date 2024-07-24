CREATE DATABASE pdv;

USE pdv;

--
-- Estrutura da tabela 'employees'
--

CREATE TABLE employees (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    name VARCHAR(255),
    cpf VARCHAR(20),
    phone VARCHAR(20),
    job VARCHAR(30),
    address VARCHAR(255),
    date DATE,
    photo LONGBLOB
);

--
-- Estrutura da tabela 'job'
--

CREATE TABLE job (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    name varchar(255),
    date date
);

--
-- Estrutura da tabela 'Clients'
--

CREATE TABLE clients (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    code VARCHAR(30) DEFAULT '0',
    name VARCHAR(255),
    cpf VARCHAR(20),
    openAmount DECIMAL(10,2),
    status VARCHAR(10),
    phone VARCHAR(20),
    email VARCHAR(255),
    address VARCHAR(255),
    date DATE
);
