# CS_Winform_ESIEE

Le projet consiste à développer une application de gestion de magasin en C# avec une interface graphique WinForms.
L'application permettra de gérer les articles, les paniers, les commandes et les promotions, tout en utilisant des
fonctionnalités avancées comme LINQ, la sérialisation JSON et les expressions lambda.

## Schema de la base de données

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
