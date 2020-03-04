--Usar o banco de dados
use InLock_Games_Tarde;

--Listar todos os usuários  	
select * from Usuarios;

--Listar todos os estúdios; 
select * from Estudio;

--Listar todos os jogos; 
select * from Jogo;

--Listar todos os jogos e seus respectivos estúdios;
select Jogo.NomeJogo, Estudio.NomeEstudio from Jogo
inner join Estudio on Estudio.IdEstudio = Jogo.IdEstudio;

--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência; 
select Estudio.NomeEstudio , Jogo.NomeJogo from Estudio
left join Jogo on Jogo.IdEstudio = Estudio.IdEstudio;


select * from Usuarios
--Buscar um usuário por email e senha; 
select Email , Senha  from Usuarios 
where Email like '%cliente@cliente.com%' and Senha like '%cliente%';

--Buscar um jogo por IdJogo;
select NomeJogo from Jogo
where IdJogo = 2;

