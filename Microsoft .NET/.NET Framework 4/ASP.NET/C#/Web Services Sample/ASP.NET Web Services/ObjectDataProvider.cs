using System;
using System.Collections.Generic;
using System.ComponentModel;
using combit.ListLabel25;
using combit.ListLabel25.DataProviders;

namespace combit.Services
{
    public sealed class GenericList
    {
        private GenericList()
        { 
        }

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
    public sealed class Customer
    {
        //Constructor
        public Customer(int customerID, string companyName, string contactName, string address, string city)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            ContactName = contactName;
            Address = address;
            City = city;
        }

        #region customer fields
        private List<Order> orderList = new List<Order>();
        public List<Order> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

        
        private int customerID;

        // D: Die CustomerID soll nicht im Designer zur Auswahl verfuegbar sein
        // US: The CustomerID should not be available in the designer
        [Browsable(false)]
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private string contactName;

        // D: Setze Property-Name, welcher im Designer verwendet werden soll
        // US: Set property name, which should be used in the designer
        [DisplayName("Name")]
        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        #endregion
    }

    //D: Die Klasse "Order" repraesentiert eine einzelne Bestellung eines Kunden
    //US: The "Order" class represents a single order of a customer
    public sealed class Order
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

        #region Order fields
        private int orderID;
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        private DateTime orderDate;
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        private string shipName;
        public string ShipName
        {
            get { return shipName; }
            set { shipName = value; }
        }

        private string shipCountry;
        public string ShipCountry
        {
            get { return shipCountry; }
            set { shipCountry = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        [FieldType(LlFieldType.Barcode_EAN128)]
        public string PriceEan
        {
            get { return price.ToString(); }
        }
        #endregion
    }
}
