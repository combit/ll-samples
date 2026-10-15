using BlazorServerSample.Models;

namespace BlazorServerSample.Services;

/// <summary>
/// Provides an in-memory list of customer data used as the LLCP report data source.
/// </summary>
public class CustomerDataService
{
    /// <summary>
    /// Returns the sample customer list.
    /// </summary>
    /// <returns>A read-only list of <see cref="Customer"/> records.</returns>
    public IReadOnlyList<Customer> GetCustomers()
    {
        return new List<Customer>
        {
            new() { Id = 1, Name = "Acme Corp",          City = "New York",     Revenue = 125_000.00m },
            new() { Id = 2, Name = "Globex Inc.",         City = "Springfield",  Revenue =  87_500.50m },
            new() { Id = 3, Name = "Initech Solutions",   City = "Austin",       Revenue = 210_300.75m },
            new() { Id = 4, Name = "Umbrella Ltd.",       City = "Raccoon City", Revenue =  55_000.00m },
            new() { Id = 5, Name = "Hooli Technologies",  City = "Palo Alto",    Revenue = 450_000.00m },
            new() { Id = 6, Name = "Soylent Corp",        City = "Los Angeles",  Revenue =  33_200.10m },
            new() { Id = 7, Name = "Massive Dynamic",     City = "Boston",       Revenue = 320_750.25m },
        };
    }
}
