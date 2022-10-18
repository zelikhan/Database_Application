CREATE TABLE [dbo].[customer] (
    [CustomerID]   NCHAR (5)     NOT NULL IDENTITY,
    [CompanyName] NVARCHAR (50) NOT NULL,
    [ContactName]  NVARCHAR (50) NULL,
    [Phone]        NVARCHAR (24) NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

