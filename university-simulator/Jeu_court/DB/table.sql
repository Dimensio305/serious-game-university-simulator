CREATE TABLE Catpersonne (
    idcat NUMERIC PRIMARY KEY NOT NULL,
    nom TEXT NOT NULL
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