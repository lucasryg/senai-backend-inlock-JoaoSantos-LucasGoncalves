--Usar o banco de dados
use InLock_Games_Tarde;

--Iserir os dados na tabela

insert into Estudio (NomeEstudio)
values ('Blizzard'),('Rockstar Studios'),('Square Enix');

insert into Jogo(NomeJogo, Descricao, DataDeLancamento, Valor, IdEstudio)	
values ('Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '15/05/2012', 99.00, 1),('Red Dead Redemption II','Jogo eletr�nico de a��o-aventura western','26/10/2018',120.00,2);

insert into  TipoUsuario(Titulo)
values ('Administrador'),('Cliente');

insert into Usuarios (Email, Senha, IdTipoUsuario)
values ('admin@admin.com','admin', 1),('cliente@cliente.com','cliente', 2);



