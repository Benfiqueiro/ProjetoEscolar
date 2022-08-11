create database bdEscola;
use bdEscola;


create table tbAluno(
codAluno int primary key auto_increment,
nomeAluno varchar(50),
telAluno varchar(20)
);


create table tbProfessor(
codProf  int primary key auto_increment,
nomeProf varchar(50)
)

select * from tbAluno;
select * from tbProfessor;