# CS_Winform_ESIEE

---

![License](https://img.shields.io/github/license/Redstoneur/CS_Winform_ESIEE)
![Top Language](https://img.shields.io/github/languages/top/Redstoneur/CS_Winform_ESIEE)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![C#](https://img.shields.io/badge/C%23-10.0-brightgreen)
![NuGet](https://img.shields.io/badge/NuGet-6.2.1-blue)
![Size](https://img.shields.io/github/repo-size/Redstoneur/CS_Winform_ESIEE)
![Contributors](https://img.shields.io/github/contributors/Redstoneur/CS_Winform_ESIEE)
![Last Commit](https://img.shields.io/github/last-commit/Redstoneur/CS_Winform_ESIEE)
![Issues](https://img.shields.io/github/issues/Redstoneur/CS_Winform_ESIEE)
![Pull Requests](https://img.shields.io/github/issues-pr/Redstoneur/CS_Winform_ESIEE)

---

![Forks](https://img.shields.io/github/forks/Redstoneur/CS_Winform_ESIEE)
![Stars](https://img.shields.io/github/stars/Redstoneur/CS_Winform_ESIEE)
![Watchers](https://img.shields.io/github/watchers/Redstoneur/CS_Winform_ESIEE)

---

![Latest Release](https://img.shields.io/github/v/release/Redstoneur/CS_Winform_ESIEE)
![Release Date](https://img.shields.io/github/release-date/Redstoneur/CS_Winform_ESIEE)
![Build Status](https://img.shields.io/github/actions/workflow/status/Redstoneur/CS_Winform_ESIEE/build.yml)

---

## Sommaire

<!-- TOC -->
* [CS_Winform_ESIEE](#cs_winform_esiee)
  * [Sommaire](#sommaire)
  * [Introduction](#introduction)
  * [Installation](#installation)
    * [Prérequis](#prérequis)
    * [Instructions](#instructions)
  * [Utilisation](#utilisation)
    * [Exemple d'utilisation](#exemple-dutilisation)
    * [Captures d'écran](#captures-décran)
  * [Fonctionnalités](#fonctionnalités)
  * [Schéma de la base de données](#schéma-de-la-base-de-données)
  * [Licence](#licence)
  * [Télécharger l'exécutable](#télécharger-lexécutable)
<!-- TOC -->

## Introduction

Le projet consiste à développer une application de gestion de magasin en C# avec une interface graphique WinForms.
L'application permettra de gérer les articles, les paniers, les commandes et les promotions, tout en utilisant des
fonctionnalités avancées comme LINQ, la sérialisation JSON et les expressions lambda.

Ce projet a été développé dans le cadre d'un cours à l'ESIEE. Il vise à fournir une solution complète pour la gestion
d'un magasin, incluant la gestion des articles, des commandes et des promotions.

## Installation

### Prérequis

- .NET Framework 4.8 ou supérieur
- Visual Studio ou JetBrains Rider

### Instructions

1. Clonez le dépôt :
   ```bash
   git clone https://github.com/Redstoneur/CS_Winform_ESIEE.git
   ```
2. Ouvrez le projet dans votre IDE préféré (Visual Studio ou JetBrains Rider).
3. Restaurez les packages NuGet :
   ```bash
   dotnet restore
   ```
4. Complétez le fichier [.env](./CS_Winform_ESIEE/.env) avec les informations de connexion à la base de données.
5. Compilez et exécutez le projet.

## Utilisation

### Exemple d'utilisation

1. Lancez l'application.
2. Ajoutez des articles au panier.
3. Passez une commande.
4. Gérez les promotions.

### Captures d'écran

[//]: # (![Capture d'écran 1]&#40;path/to/screenshot1.png&#41;)

[//]: # (![Capture d'écran 2]&#40;path/to/screenshot2.png&#41;)

> En cours de développement...

## Fonctionnalités

- Gestion des articles
- Gestion des commandes
- Gestion des promotions
- Utilisation de LINQ pour les requêtes
- Sérialisation JSON pour la sauvegarde des données
- Expressions lambda pour les opérations sur les collections

## Schéma de la base de données

```mermaid
erDiagram
    ARTICLE {
        int IdArticle PK
        int IdCategorie FK
        string Nom
        decimal PrixUnitaire
        int Quantite
        int Promotion
        bool EstActif
    }

    CATEGORY {
        int IdCategorie PK
        string Nom
        bool EstActif
    }

    COMMANDE {
        int IdCommande PK
        string Etat
        DateTime Date
        DateTime DateEnvoi
        DateTime DateLivraison
    }

    LIGNE_COMMANDE {
        int IdLigneCommande PK
        int IdCommande FK
        int IdArticle FK
        decimal PrixUnitaire
        int Quantite
        int Promotion
    }

    ARTICLE ||--o{ CATEGORY: "belongs to"
    COMMANDE ||--o{ LIGNE_COMMANDE: "contains"
    ARTICLE ||--o{ LIGNE_COMMANDE: "included in"
```

Voir le fichier [Create-DataBase.sql](Create-DataBase.sql) pour le script de création de la base de données.

## Licence

Ce projet est sous licence MIT. Voir le fichier [LICENSE](LICENSE) pour plus de détails.

## Télécharger l'exécutable

Vous pouvez télécharger la dernière version de l'exécutable
ici : [📥 Télécharger CS_Winform_ESIEE.exe](https://github.com/Redstoneur/CS_Winform_ESIEE/releases/latest)
