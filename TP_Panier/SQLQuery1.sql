CREATE TABLE [dbo].[PanierProduit]

(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [panier_id] INT NOT NULL, 
    [produit_id] INT NOT NULL
)
CREATE TABLE [dbo].[Panier]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [client_id] INT NOT NULL, 
    [total] DECIMAL NOT NULL
)
CREATE TABLE [dbo].[Produit]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [label] NVARCHAR(50) NOT NULL, 
    [prix] DECIMAL NOT NULL
)
CREATE TABLE [dbo].[Client]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [nom] NVARCHAR(50) NOT NULL, 
    [prenom] NVARCHAR(50) NOT NULL, 
    [telephone] NCHAR(10) NOT NULL
)

