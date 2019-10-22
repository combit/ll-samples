using System;
using System.Collections.Generic;
using System.ComponentModel;
using combit.ListLabel25.DataProviders;

namespace combit.ListLabel25.CSharpSample.ObjectDataProviderSample
{
    class GenericList
    {
        public static List<Customer> GetGenericList()
        {
            List<Customer> customerList = new List<Customer>();

            //D: Mehrere Kunden erstellen
            //US: Create some customers
            Customer customer1 = new Customer(1, "Joe's Tatoo", "Joe Smith", "Kingstreet 2a", "Queens");
            Customer customer2 = new Customer(2, "Tec n Toc", "Peter Bush", "Park Avenue", "NewYork");
            Customer customer3 = new Customer(3, "Sunshine Agency", "Brian Holiday", "Island Road 1", "Zurich");
            Customer customer4 = new Customer(4, "Hiking Store", "Sandra Mountain", "Hillstreet 6", "Garmisch");

            //D: Die Bestellungen fuer den ersten Kunden definieren
            //US: Define orders for the first customer
            customer1.OrderList.Add(new Order(1, new DateTime(2006, 1, 20), "Nils van de Glocke", "Houston", 14.64));
            customer1.OrderList.Add(new Order(2, new DateTime(2006, 6, 21), "Bruce White", "New Orleans", 214.00));
            customer1.OrderList.Add(new Order(3, new DateTime(2006, 3, 1), "Kurt Muster", "Berlin", 6420.00));

            //D: Die Bestellungen fuer den zweiten Kunden definieren
            //US: Define orders for the second customer
            customer2.OrderList.Add(new Order(4, new DateTime(2005, 12, 3), "Bill Bunny", "Frankfurt", 640.99));

            //D: Die Bestellungen fuer den dritten Kunden definieren
            //US: Define orders for the third customer
            customer3.OrderList.Add(new Order(5, new DateTime(2006, 4, 3), "Mia Rust", "Madrid", 56.60));
            customer3.OrderList.Add(new Order(6, new DateTime(2006, 4, 16), "Mia Rust", "Madrid", 450.00));
            customer3.OrderList.Add(new Order(7, new DateTime(2006, 4, 25), "Mia Rust", "Madrid", 1585.00));

            //D: Die Bestellungen fuer den vierten Kunden definieren
            //US: Define orders for the fourth customer
            customer4.OrderList.Add(new Order(8, new DateTime(2006, 6, 6), "Steve Random", "Vienna", 990.00));

            //D: Die einzelnen Kunden in die Kundenliste aufnehmen
            //US: Add the single customers to the customer list
            customerList.AddRange(new Customer[] { customer1, customer2, customer3, customer4 });

            return (customerList);
        }
    }


    //D: Die Klasse "Customer" repraesentiert einen Kunden der n Bestellungen enthaelt 
    //US: The "Customer" class represents a customer who has n orders
    class Customer
    {
        //Constructor
        public Customer(int customerID, string companyName, string contactName, string address, string city)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            ContactName = contactName;
            Address = address;
            City = city;
            OrderList = new List<Order>();
        }

        public List<Order> OrderList { get; set; }

        // D: Die CustomerID soll nicht im Designer zur Auswahl verfuegbar sein
        // US: The CustomerID should not be available in the designer
        [Browsable(false)]
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }

        // D: Setze Property-Name, welcher im Designer verwendet werden soll
        // US: Set property name, which should be used in the designer
        [DisplayName("Name")]
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

    //D: Die Klasse "Order" repraesentiert eine einzelne Bestellung eines Kunden
    //US: The "Order" class represents a single order of a customer
    class Order
    {
        //Constructor
        public Order(int orderID, DateTime orderDate, string shipName, string shipCountry, double price)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            ShipName = shipName;
            ShipCountry = shipCountry;
            Price = price;
        }

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public double Price { get; set; }

        [FieldType(LlFieldType.Barcode_EAN128)]
        public string PriceEan
        {
            get { return Price.ToString(); }
        }
    }
}
