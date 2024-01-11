# .NET - Exercices

## Etapes base de données

- Ouvrir la console SQLServer et exécuter le sql
- Installer les packages NuGet suivants :
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Proxies
- Ouvrir la console NuGet et executer : Scaffold-DbContext -OutputDir Models 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind' Microsoft.EntityFrameworkCore.SqlServer
- Activer le lazyloading dans le Context => Modifier la méthode OnConfiguring en ajoutant .UseLazyLoadingProxies

Enjoy x)
