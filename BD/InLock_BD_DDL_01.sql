--Criar um database
create database InLock_Games_Tarde;

--Usar o banco de dados
use InLock_Games_Tarde;

--Criação das tabelas 
create table Estudio(
	IdEstudio int primary key identity,
	NomeEstudio varchar(255) not null unique
);



create table Jogo(
	IdJogo int primary key identity, 
	NomeJogo varchar(255) not null unique,
	Descricao varchar(500) not null,
	DataDeLancamento date not null,
	Valor decimal not null,
	IdEstudio int foreign key references Estudio (IdEstudio) 
);


create table TipoUsuario(
	IdTipoUsuario int primary key identity,
	Titulo varchar(255) not null
);

select * from Usuarios

select Usuarios.IdUsuario, Usuarios.Email, Usuarios.Senha, TipoUsuario.IdTipoUsuario, TipoUsuario.Titulo  FROM Usuarios
inner join TipoUsuario on TipoUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario WHERE Usuario.Email = '' AND Senha = '';

"SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Titulo FROM Usuarios U INNER JOIN TiposUsuario TU ON U.IdTipoUsuario = TU.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

create table Usuarios(
	IdUsuario int primary key identity,
	Email varchar(255) not null unique,
	Senha varchar(255) not null,
	IdTipoUsuario int foreign key references TipoUsuario( IdTipoUsuario)
);



