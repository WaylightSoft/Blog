Use Blog
GO
CREATE TABLE  Post  (
	 Id  INT NOT NULL IDENTITY,
	 Content  VARCHAR(255) NOT NULL,
	 UserId  INT NOT NULL,
	 Rating  INT NULL,
	 Views	 INT NULL,			
	PRIMARY KEY ( Id )
);

CREATE TABLE  Image  (
	 Id  INT NOT NULL IDENTITY,
	 Path  VARCHAR(255) NOT NULL,
	PRIMARY KEY ( Id )
);

CREATE TABLE  Role  (
	 Id  INT NOT NULL IDENTITY,
	 Name  VARCHAR(255) NOT NULL,
	PRIMARY KEY ( Id )
);

CREATE TABLE  [User]  (
	 Id  INT NOT NULL IDENTITY,
	 Nickname  VARCHAR(255) NOT NULL UNIQUE,
	 Bio  VARCHAR(255) NOT NULL,
	 ImageId INT NOT NULL,
	 RoleId  INT NOT NULL,
     UserCredentialsId  INT NOT NULL UNIQUE,
     PRIMARY KEY ( Id )
);

CREATE TABLE  PostImage  (
	 Id  INT NOT NULL IDENTITY,
	 PostId  INT NOT NULL,
	 ImageId  INT NOT NULL,
	 ImageNumber  INT NULL,
	PRIMARY KEY ( Id )
);

CREATE TABLE  UserCredentials  (
	 Id  INT NOT NULL IDENTITY,
	 Login  VARCHAR(255) NOT NULL UNIQUE,
	 Password  VARCHAR(255) NOT NULL,
	
	PRIMARY KEY ( Id )
);

CREATE TABLE  Tag  (
	 Id  INT NOT NULL IDENTITY,
	 Name  VARCHAR(255) NOT NULL UNIQUE,
	PRIMARY KEY ( Id )
);

CREATE TABLE  PostTag  (
	 Id  INT NOT NULL IDENTITY,
	 PostId  INT NOT NULL,
	 TagId  INT NOT NULL,
	PRIMARY KEY ( Id )
);

CREATE TABLE UserRatedPost (
	Id  INT NOT NULL IDENTITY,
	PostId  INT NOT NULL,
	UserId INT  NULL,
	Points INT NOT NULL,
	PRIMARY KEY ( Id )
);

ALTER TABLE  Post  ADD CONSTRAINT  Post_fk0  FOREIGN KEY ( UserId ) REFERENCES  [User] ( Id );

ALTER TABLE  [User]  ADD CONSTRAINT  User_fk0  FOREIGN KEY ( ImageId ) REFERENCES  Image ( Id );

ALTER TABLE  [User]  ADD CONSTRAINT  User_fk0  FOREIGN KEY ( RoleId ) REFERENCES  Role ( Id );

ALTER TABLE  [User]  ADD CONSTRAINT  User_fk_UserCredentials  FOREIGN KEY ( UserCredentialsId ) REFERENCES  UserCredentials ( Id ) ON DELETE CASCADE;

ALTER TABLE  PostImage  ADD CONSTRAINT  PostImage_fk0  FOREIGN KEY ( PostId ) REFERENCES  Post ( Id );

ALTER TABLE  PostImage  ADD CONSTRAINT  PostImage_fk1  FOREIGN KEY ( ImageId ) REFERENCES  Image ( Id );

ALTER TABLE  PostTag  ADD CONSTRAINT  PostTag_fk0  FOREIGN KEY ( PostId ) REFERENCES  Post ( Id );

ALTER TABLE  PostTag  ADD CONSTRAINT  PostTag_fk1  FOREIGN KEY ( TagId ) REFERENCES  Tag ( Id );

ALTER TABLE  [User]  ADD CONSTRAINT  User_fk0  FOREIGN KEY ( ImageId ) REFERENCES  Image ( Id );

ALTER TABLE UserRatedPost ADD CONSTRAINT UserRatedPost_fkUser FOREIGN KEY (UserId) REFERENCES [User] (Id)

ALTER TABLE UserRatedPost ADD CONSTRAINT UserRatedPost_fkPost FOREIGN KEY (PostId) REFERENCES Post (Id)

use BLOg
 Insert into  Tag VALUES('test')
 select * from Tag

 insert into Role Values('testRole')
 insert into UserCredentials Values('testLOgin','testPword')

 SELECT * FROM Dbo.[User]
 SELECT * FROM Post