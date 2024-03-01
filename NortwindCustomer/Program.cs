using Microsoft.EntityFrameworkCore;
using Nortwind.Shared; // Northwind, Customer

using (Northwind db = new())
{
		// Get all unique cities where there are customers
		var citiesWithCustomers = db.Customers.Select(c => c.City).Distinct().ToList();

		// Show list of unique cities
		Console.WriteLine("Unique cities with at least one customer:");
		foreach (var city in citiesWithCustomers)
		{
			Console.WriteLine(city);
		}

		// Ask the user to state a city
		Console.Write("State the city to show which company is registered in it: ");
		string inputCity = Console.ReadLine();

		// Get customers in the stated city and show the company name
		var customersInCity = db.Customers.Where(c => c.City == inputCity).ToList();
		if (customersInCity.Any())
		{
			Console.WriteLine($"\nCompany names for {inputCity}:");
			foreach (var customer in customersInCity)
			{
				Console.WriteLine(customer.CompanyName);
			}
		}
		else
		{
			Console.WriteLine($"\nNo customers were found in {inputCity}.");
		}

}
