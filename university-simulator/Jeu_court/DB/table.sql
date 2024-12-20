CREATE TABLE Catpersonne (
    idcat NUMERIC PRIMARY KEY NOT NULL,
    nom TEXT NOT NULL UNIQUE
);


CREATE TABLE Question (
    id NUMERIC PRIMARY KEY NOT NULL,
    idcat NUMERIC NOT NULL,
    question TEXT NOT NULL,
    FOREIGN KEY (idcat) REFERENCES Catpersonne(idcat)
);

CREATE TABLE Reponse (
    idquestion NUMERIC NOT NULL,
    idreponse NUMERIC NOT NULL,
    reponse TEXT NOT NULL,
    j1 NUMERIC NOT NULL,
    j2 NUMERIC NOT NULL,
    j3 NUMERIC NOT NULL,
    j4 NUMERIC NOT NULL,
    PRIMARY KEY (idquestion, idreponse),
    FOREIGN KEY (idquestion) REFERENCES Question(id)
);

CREATE TABLE Formation(
    idformation NUMERIC NOT NULL,
    nom Text NOT NULL,
    effectif NUMERIC NOT NULL,
    eleve NUMERIC NOT NULL,
    budget NUMERIC NOT NULL,
    Opt Text NOT NULL,
    PRIMARY KEY(idformation)
    

);

CREATE TABLE ChoixFormation(
    idforma NUMERIC NOT NULL,
    idreponse NUMERIC NOT NULL,
    j1 NUMERIC NOT NULL,
    j2 NUMERIC NOT NULL,
    j3 NUMERIC NOT NULL,
    j4 NUMERIC NOT NULL,
    PRIMARY KEY (idforma, idreponse),
    FOREIGN KEY (idforma) REFERENCES Formation(idformation)
    
);




