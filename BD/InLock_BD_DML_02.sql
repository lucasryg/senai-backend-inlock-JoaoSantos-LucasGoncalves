--Usar o banco de dados
use InLock_Games_Tarde;

--Iserir os dados na tabela

insert into Estudio (NomeEstudio)
values ('Blizzard'),('Rockstar Studios'),('Square Enix');

insert into Jogo(NomeJogo, Descricao, DataDeLancamento, Valor, IdEstudio)	
values ('Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '15/05/2012', 99.00, 1),('Red Dead Redemption II','Jogo eletrônico de ação-aventura western','26/10/2018',120.00,2);

insert into  TipoUsuario(Titulo)
values ('Administrador'),('Cliente');

insert into Usuarios (Email, Senha, IdTipoUsuario)
values ('admin@admin.com','admin', 1),('cliente@cliente.com','cliente', 2);



