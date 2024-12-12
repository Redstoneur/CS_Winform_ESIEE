########################################################################################################################
##### Utilisation de la base de données  ###############################################################################
########################################################################################################################

DROP DATABASE IF EXISTS MilkyMarket;
CREATE DATABASE MilkyMarket;

USE MilkyMarket;

DROP TABLE IF EXISTS LIGNE_COMMANDE;
DROP TABLE IF EXISTS COMMANDE;
DROP TABLE IF EXISTS ARTICLE;
DROP TABLE IF EXISTS CATEGORY;

########################################################################################################################
#####  Création de la base de données  #################################################################################
########################################################################################################################

CREATE TABLE CATEGORY
(
    IdCategorie INT AUTO_INCREMENT PRIMARY KEY,
    Nom         VARCHAR(255) NOT NULL UNIQUE,
    EstActif    BOOLEAN      NOT NULL DEFAULT TRUE
);

CREATE TABLE ARTICLE
(
    IdArticle     INT AUTO_INCREMENT PRIMARY KEY,
    IdCategorie   INT            NOT NULL,
    Nom           VARCHAR(255)   NOT NULL,
    PrixUnitaire  DECIMAL(10, 2) NOT NULL CHECK (PrixUnitaire >= 0),
    Quantite      INT            NOT NULL CHECK (Quantite >= 0),
    Promotion     INT CHECK (Promotion BETWEEN 0 AND 100) DEFAULT 0,
    TypePromotion ENUM ('Pourcentage', 'Montant')         DEFAULT 'Pourcentage',
    EstActif      BOOLEAN        NOT NULL                 DEFAULT TRUE,
    CONSTRAINT FK_Article_Categorie FOREIGN KEY (IdCategorie) REFERENCES CATEGORY (IdCategorie)
);

CREATE TABLE COMMANDE
(
    IdCommande    INT AUTO_INCREMENT PRIMARY KEY,
    Etat          ENUM ('Commandé', 'Expédié', 'Livré', 'Annulé') NOT NULL,
    Date          DATETIME                                        NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DateEnvoi     DATETIME                                                 DEFAULT NULL,
    DateLivraison DATETIME                                                 DEFAULT NULL
);

CREATE TABLE LIGNE_COMMANDE
(
    IdLigneCommande INT AUTO_INCREMENT PRIMARY KEY,
    IdCommande      INT            NOT NULL,
    IdArticle       INT            NOT NULL,
    PrixUnitaire    DECIMAL(10, 2) NOT NULL CHECK (PrixUnitaire >= 0),
    Quantite        INT            NOT NULL CHECK (Quantite >= 0),
    Promotion       INT CHECK (Promotion BETWEEN 0 AND 100) DEFAULT 0,
    TypePromotion   ENUM ('Pourcentage', 'Montant')         DEFAULT 'Pourcentage',
    CONSTRAINT FK_LigneCommande_Commande FOREIGN KEY (IdCommande) REFERENCES COMMANDE (IdCommande),
    CONSTRAINT FK_LigneCommande_Article FOREIGN KEY (IdArticle) REFERENCES ARTICLE (IdArticle)
);

########################################################################################################################
#####  Insert des données  #############################################################################################
########################################################################################################################

INSERT INTO CATEGORY (Nom)
VALUES ('Informatique'),
       ('Electroménager'),
       ('Jardinage'),
       ('Bricolage'),
       ('Sport'),
       ('Jeux Vidéo'),
       ('Musique'),
       ('Livres'),
       ('Vêtements'),
       ('Alimentation');

INSERT INTO ARTICLE (Nom, PrixUnitaire, Quantite, Promotion, IdCategorie)
VALUES ('Ordinateur', 500, 10, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Informatique')),
       ('Télévision', 300, 5, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Lave-vaisselle', 400, 3, 10, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Lave-linge', 400, 3, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Tondeuse', 150, 7, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Jardinage')),
       ('Perceuse', 100, 8, 30, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Bricolage')),
       ('Vélo', 200, 6, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Sport')),
       ('PS4', 400, 4, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Jeux Vidéo')),
       ('Guitare', 300, 5, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Musique')),
       ('Livre', 20, 20, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Livres')),
       ('T-shirt', 10, 50, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Vêtements')),
       ('Pomme', 1, 100, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation')),
       ('Banane', 2, 100, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation')),
       ('Pomme de terre', 3, 100, 50, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation')),
       ('Tomate', 4, 100, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation')),
       ('Carotte', 5, 100, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation')),
       ('Concombre', 6, 100, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation')),
       ('Salade', 7, 100, 0, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation')),
       ('Poire', 8, 100, 10, (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Alimentation'));

INSERT INTO ARTICLE (Nom, PrixUnitaire, Quantite, Promotion, TypePromotion, IdCategorie)
VALUES ('Aspirateur', 100, 5, 2, 'Montant', (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Micro-ondes', 100, 5, 0, 'Montant', (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Cafetière', 100, 5, 5, 'Montant', (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Fer à repasser', 100, 5, 0, 'Montant', (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Grille-pain', 100, 5, 0, 'Montant', (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Sèche-cheveux', 100, 5, 10, 'Montant', (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager')),
       ('Ventilateur', 100, 5, 0, 'Montant', (SELECT IdCategorie FROM CATEGORY WHERE Nom = 'Electroménager'));

INSERT INTO COMMANDE (Etat, Date, DateEnvoi, DateLivraison)
VALUES ('Commandé', '2021-01-01 12:00:00', null, null),
       ('Expédié', '2021-01-02 12:00:00', '2021-01-02 12:00:00', null),
       ('Livré', '2021-01-03 12:00:00', '2021-01-03 12:00:00', '2021-01-03 12:00:00'),
       ('Annulé', '2021-01-04 12:00:00', '2021-01-04 12:00:00', '2021-01-04 12:00:00'),
       ('Commandé', '2021-01-05 12:00:00', null, null);
;

INSERT INTO LIGNE_COMMANDE (IdCommande, IdArticle, PrixUnitaire, Quantite, Promotion)
VALUES (1, 6, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 6),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 6), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 6)),
       (1, 7, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 7),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 7), 70),
       (1, 8, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 8),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 8), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 8)),
       (2, 9, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 9),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 9), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 9)),
       (2, 10, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 10),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 10), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 10)),
       (2, 11, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 11),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 11), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 11)),
       (3, 12, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 12),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 12), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 12)),
       (3, 13, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 13),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 13), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 13)),
       (3, 14, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 14),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 14), 45),
       (3, 15, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 15),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 15), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 15)),
       (3, 16, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 16),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 16), 30),
       (4, 6, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 6),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 6), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 6)),
       (4, 8, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 8),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 8), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 8)),
       (4, 19, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 19),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 19), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 19)),
       (4, 1, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 1),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 1), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 1)),
       (4, 4, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 4),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 4), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 4));

INSERT INTO LIGNE_COMMANDE (IdCommande, IdArticle, PrixUnitaire, Quantite, Promotion, TypePromotion)
VALUES (5, 17, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 17),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 17), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 17),
        (SELECT TypePromotion FROM ARTICLE WHERE IdArticle = 17)),
       (5, 18, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 18),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 18), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 18),
        (SELECT TypePromotion FROM ARTICLE WHERE IdArticle = 18)),
       (5, 19, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 19),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 19), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 19),
        (SELECT TypePromotion FROM ARTICLE WHERE IdArticle = 19)),
       (5, 20, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 20),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 20), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 20),
        (SELECT TypePromotion FROM ARTICLE WHERE IdArticle = 20)),
       (5, 21, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 21),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 21), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 21),
        (SELECT TypePromotion FROM ARTICLE WHERE IdArticle = 21)),
       (5, 22, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 22),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 22), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 22),
        (SELECT TypePromotion FROM ARTICLE WHERE IdArticle = 22)),
       (5, 23, (SELECT PrixUnitaire FROM ARTICLE WHERE IdArticle = 23),
        (SELECT Quantite FROM ARTICLE WHERE IdArticle = 23), (SELECT Promotion FROM ARTICLE WHERE IdArticle = 23),
        (SELECT TypePromotion FROM ARTICLE WHERE IdArticle = 23));

########################################################################################################################
#####  Fin du fichier  #################################################################################################
########################################################################################################################