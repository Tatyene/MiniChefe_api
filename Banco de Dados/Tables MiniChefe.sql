create extension if not exists pgcrypto;

CREATE TABLE "Usuario" (
  "ID" serial NOT NULL,
  "Email" char(50),
  "Nome" char(50),
  "Senha" char(6),
  PRIMARY KEY ("ID")
);

CREATE TABLE "Ingredientes" (
  "ID" serial NOT NULL,
  "Descricao" varchar(500),
  PRIMARY KEY ("ID")
);

CREATE TABLE "Preparo" (
  "ID" serial NOT NULL,
  "Passo" integer,
  "Titulo" char(20),
  "Descricao" varchar(500),
  PRIMARY KEY ("ID")
);

CREATE TABLE "Porcoes" (
  "ID" serial NOT NULL,
  "Qtd" integer,
  "Tipo" char(10),
  PRIMARY KEY ("ID")
);


CREATE TABLE "Receita" (
  "ID" serial NOT NULL,
  "ID_Usuario" serial NOT NULL,
  "Titulo" char(50),
  "Descricao" varchar(500),
  "Dificuldade" numeric(1,0),
  "Custo" numeric(1,0),
  "Tempo_Preparo" numeric(6,0),
  "ID_Ingrediente" serial NOT NULL,
  "ID_Porcoes" serial NOT NULL,
  "ID_Preparo" serial NOT NULL,
  "Imagem" bytea,
  "Tipo" char(20),
  PRIMARY KEY ("ID"),
	CONSTRAINT "fk_Usuario" FOREIGN KEY("ID_Usuario") REFERENCES "Usuario"("ID"),
	CONSTRAINT "fk_Ingrediente" FOREIGN KEY("ID_Ingrediente") REFERENCES "Ingredientes"("ID"),
	CONSTRAINT "fk_Porcoes" FOREIGN KEY("ID_Porcoes") REFERENCES "Porcoes"("ID"),
	CONSTRAINT "fk_Preparo" FOREIGN KEY("ID_Preparo") REFERENCES "Preparo"("ID"),
);

CREATE TABLE "Avaliacao" (
  "ID" serial NOT NULL,
  "ID_Receita" serial NOT NULL,
  "ID_Usuario" serial NOT NULL,
  "Descricao" varchar(500),
  "Nota" numeric(1,0),
  PRIMARY KEY ("ID"),
	CONSTRAINT "fk_Usuario"
      FOREIGN KEY("ID_Usuario") 
	  REFERENCES "Usuario"("ID"),
	CONSTRAINT "fk_Receita"
      FOREIGN KEY("ID_Receita") 
	  REFERENCES "Receita"("ID")
);


CREATE TABLE "Favoritos" (
  "ID" serial NOT NULL,
  "ID_Usuario" serial NOT NULL,
  "ID_Receita" serial NOT NULL,
  PRIMARY KEY ("ID"),
	CONSTRAINT "fk_Usuario"
      FOREIGN KEY("ID_Usuario") 
	  REFERENCES "Usuario"("ID"),
	CONSTRAINT "fk_Receita"
      FOREIGN KEY("ID_Receita") 
	  REFERENCES "Receita"("ID")
);