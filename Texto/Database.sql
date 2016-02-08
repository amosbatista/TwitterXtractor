create table TwitterUser (id varchar (100) not null, screen_name varchar (20) null, followersCount decimal not null, friendsCount decimal not null, userProcessed bit not null);
create table TwitterFollowers (id varchar (100) not null, id_Follower varchar (100) not null);


CREATE USER 'xTractorUser'@'localhost' IDENTIFIED BY 'amos28amos';
GRANT ALL PRIVILEGES ON *.* TO 'xTractorUser'@'localhost' WITH GRANT OPTION;