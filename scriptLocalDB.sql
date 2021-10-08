Create database logikeSports;
use logikeSports;
CREATE TABLE usuario (
    idUsuario int auto_increment primary key,
    nome varchar(255),
    login varchar(255),
    senha varchar(255),
    email varchar(255),
    dataNasc date,
    Estilo int
);

insert into usuario values (null, "Gustavo", "admin", "admin123", "asdsada@gmail.com", '2003-3-31',1);
insert into usuario value (null, "Daniel", "dandan", "1229", "sdads@adsad.com", '2002-2-02',2);
select * from usuario;
 -- SELECT count(*) FROM usuario WHERE login = 'admin'and senha = 'admin123';
 -- drop database logikeSports;