using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

NorthwindContext context = new NorthwindContext();

/**
 * 1.	Lister tous les Customers habitants dans une ville saisie au clavier.
 */
Console.Write("Enter a city name: ");
string? city = Console.ReadLine();

IQueryable<Customer> customers = context.Customers
    .Where(c => c.City == city);

foreach (Customer c in customers)
{
    Console.WriteLine($"{c.ContactName}");
}


/**
 * 2.	Afficher les produits de la catégorie Beverages et Condiments. Utilisez le lazy loading  (pas d’include !)
 */
IQueryable<Category> categories = context.Categories
    .Where(c => c.CategoryName == "Beverages" || c.CategoryName == "Condiments");

foreach (Category c in categories)
{
    Console.WriteLine($"{c.CategoryName}");
    foreach (Product p in c.Products)
    {
        Console.WriteLine($"\t{p.ProductName}");
    }
}

/**
 * 3.	Afficher les produits de la catégorie Beverages et Condiments. Utilisez le eager loading ! (avec include).  
 */
IQueryable<Category> categories1 = context.Categories
    .Include(c => c.Products)
    .Where(c => c.CategoryName == "Beverages" || c.CategoryName == "Condiments");

foreach (Category c in categories1)
{
    Console.WriteLine($"{c.CategoryName}");
    foreach (Product p in c.Products)
    {
        Console.WriteLine($"\t{p.ProductName}");
    }
}

/**
 * 4.	Donnez pour un client donné saisi au clavier (LILAS par ex) la liste de ces commandes (de la plus récente à la plus ancienne) et qui ont été livrées ( il y a une date de livraison). Les champs renvoyés par ce query sont le ID du client «CustomerID »,  la date de la commande « OrderDate » et la date de livraison « ShippedDate ».
 */
Console.Write("Enter a customer ID: ");
string? customerId = Console.ReadLine();

IQueryable<Order> orders = context.Orders
    .Where(o => o.CustomerId == customerId && o.ShippedDate != null)
    .OrderByDescending(o => o.OrderDate);

foreach (Order o in orders)
{
    Console.WriteLine($"Customer ID : {o.CustomerId}, Order Date : {o.OrderDate}, Shipped Date : {o.ShippedDate}");
}

/**
 * 5.	Afficher le total des ventes par produit (ID  produit -> Total) trié par ordre de numéro produit.
 */
var totalSalesByProduct = context.OrderDetails
    .GroupBy(o => o.ProductId)
    .OrderBy(g => g.Key)
    .Select(g => new
    {
        ProductId = g.Key,
        TotalSales = g.Sum(o => o.UnitPrice * o.Quantity)
    });

foreach (var productSales in totalSalesByProduct)
{
    Console.WriteLine($"Product ID: {productSales.ProductId}, Total Sales: {productSales.TotalSales}");
}

/**
 * 6.	Afficher tous les employés (leur nom) qui ont sous leur responsabilité la région « Western »
 */
IQueryable<Employee> employees = context.Employees
    .Where(e => e.Territories.Any(t => t.Region.RegionDescription == "Western"));

foreach (Employee e in employees)
{
    Console.WriteLine($"{e.FirstName} {e.LastName}");
}

/**
 * 7.	Quels sont les territoires gérés par le supérieur de « Suyama Michael »
 */
var territories = context.Employees
    .Where(e => e.LastName.Equals("Suyama"))
    .Select(e => e.ReportsToNavigation.Territories)
    .SingleOrDefault();


foreach (Territory t in territories)
{
    Console.WriteLine($"{t.TerritoryDescription}");
}

/**
 * Mettre en majuscules tous les noms des clients
 */
IQueryable<Customer> customers1 = context.Customers;

foreach (Customer c in customers1)
{
    c.ContactName = c.ContactName.ToUpper();
}

context.SaveChanges();

IQueryable<Customer> customers2 = context.Customers;

foreach (Customer c in customers2)
{
    Console.WriteLine($"{c.ContactName}");
}

/**
 * Ajouter une catégorie à partir d'une entrée clavier
 */
Console.Write("Enter a category name: ");
string? categoryName = Console.ReadLine();

Category category = new Category
{
    CategoryName = categoryName
};

context.Categories.Add(category);
context.SaveChanges();

/**
 * Supprimez la catégorie ajoutée à l’exercice précédent
 */
context.Categories.Remove(category);

/**
 * Supprimez un employé et réassignez toutes ses commandes (« orders ») à un autre employé. Vous demanderez les «id » des employés au clavier.
 */
Console.WriteLine("Reassign an employee's orders to another employee.");

Console.Write("Enter an employee ID: ");
int employeeId = int.Parse(Console.ReadLine()!);

Console.Write("Enter a new employee ID: ");
int newEmployeeId = int.Parse(Console.ReadLine()!);

Employee employee = context.Employees
    .Include(e => e.Orders)
    .First(e => e.EmployeeId == employeeId);

Employee newEmployee = context.Employees
    .First(e => e.EmployeeId == newEmployeeId);

foreach (Order o in employee.Orders)
{
    o.EmployeeId = newEmployee.EmployeeId;
}

context.SaveChanges();
