namespace BlazorServerSample.Models;

/// <summary>
/// Represents a customer record that will be bound to the LLCP report data source.
/// </summary>
public class Customer
{
    /// <summary>Gets or sets the customer identifier.</summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the customer name.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Gets or sets the city the customer is based in.</summary>
    public string City { get; set; } = string.Empty;

    /// <summary>Gets or sets the customer's annual revenue.</summary>
    public decimal Revenue { get; set; }
}
