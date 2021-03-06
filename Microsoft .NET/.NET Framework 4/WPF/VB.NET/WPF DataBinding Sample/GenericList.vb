Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace DataBind.GenericList
	Class GenericList
		Public Shared Function GetGenericList() As List(Of Customer)
			Dim customerList As New List(Of Customer)()

			'D: Mehrere Kunden erstellen
			'US: Create some customers
			Dim customer1 As New Customer(1, "Joe's Tatoo", "Joe Smith", "Kingstreet 2a", "Queens")
			Dim customer2 As New Customer(2, "Tec n Toc", "Peter Bush", "Park Avenue", "NewYork")
			Dim customer3 As New Customer(3, "Sunshine Agency", "Brian Holiday", "Island Road 1", "Zurich")
			Dim customer4 As New Customer(4, "Hiking Store", "Sandra Mountain", "Hillstreet 6", "Garmisch")

			'D: Die Bestellungen fuer den ersten Kunden definieren
			'US: Define orders for the first customer
			customer1.OrderList.Add(New Order(1, New DateTime(2006, 1, 20), "Nils van de Glocke", "Houston", 14.64))
			customer1.OrderList.Add(New Order(2, New DateTime(2006, 6, 21), "Bruce White", "New Orleans", 214.0))
			customer1.OrderList.Add(New Order(3, New DateTime(2006, 3, 1), "Kurt Muster", "Berlin", 6420.0))

			'D: Die Bestellungen fuer den zweiten Kunden definieren
			'US: Define orders for the second customer
			customer2.OrderList.Add(New Order(4, New DateTime(2005, 12, 3), "Bill Bunny", "Frankfurt", 640.99))

			'D: Die Bestellungen fuer den dritten Kunden definieren
			'US: Define orders for the third customer
			customer3.OrderList.Add(New Order(5, New DateTime(2006, 4, 3), "Mia Rust", "Madrid", 56.6))
			customer3.OrderList.Add(New Order(6, New DateTime(2006, 4, 16), "Mia Rust", "Madrid", 450.0))
			customer3.OrderList.Add(New Order(7, New DateTime(2006, 4, 25), "Mia Rust", "Madrid", 1585.0))

			'D: Die Bestellungen fuer den vierten Kunden definieren
			'US: Define orders for the fourth customer
			customer4.OrderList.Add(New Order(8, New DateTime(2006, 6, 6), "Steve Random", "Vienna", 990.0))

			'D: Die einzelnen Kunden in die Kundenliste aufnehmen
			'US: Add the single customers to the customer list
			customerList.AddRange(New Customer() {customer1, customer2, customer3, customer4})

			Return (customerList)
		End Function
	End Class


	'D: Die Klasse "Customer" repraesentiert einen Kunden der n Bestellungen enthaelt 
	'US: The "Customer" class represents a customer who has n orders
	Class Customer
		'Constructor
		Public Sub New(customerID__1 As Integer, companyName__2 As String, contactName__3 As String, address__4 As String, city__5 As String)
			CustomerID = customerID__1
			CompanyName = companyName__2
			ContactName = contactName__3
			Address = address__4
			City = city__5
		End Sub

		#Region "customer fields"
		Private m_orderList As New List(Of Order)()
		Public Property OrderList() As List(Of Order)
			Get
				Return m_orderList
			End Get
			Set
				m_orderList = value
			End Set
		End Property

		Private m_customerID As Integer
		Public Property CustomerID() As Integer
			Get
				Return m_customerID
			End Get
			Set
				m_customerID = value
			End Set
		End Property

		Private m_companyName As String
		Public Property CompanyName() As String
			Get
				Return m_companyName
			End Get
			Set
				m_companyName = value
			End Set
		End Property

		Private m_contactName As String
		Public Property ContactName() As String
			Get
				Return m_contactName
			End Get
			Set
				m_contactName = value
			End Set
		End Property

		Private m_address As String
		Public Property Address() As String
			Get
				Return m_address
			End Get
			Set
				m_address = value
			End Set
		End Property

		Private m_city As String
		Public Property City() As String
			Get
				Return m_city
			End Get
			Set
				m_city = value
			End Set
		End Property
		#End Region
	End Class

	'D: Die Klasse "Order" repraesentiert eine einzelne Bestellung eines Kunden
	'US: The "Order" class represents a single order of a customer
	Class Order
		'Constructor
		Public Sub New(orderID__1 As Integer, orderDate__2 As DateTime, shipName__3 As String, shipCountry__4 As String, price__5 As Double)
			OrderID = orderID__1
			OrderDate = orderDate__2
			ShipName = shipName__3
			ShipCountry = shipCountry__4
			Price = price__5
		End Sub

		#Region "Order fields"
		Private m_orderID As Integer
		Public Property OrderID() As Integer
			Get
				Return m_orderID
			End Get
			Set
				m_orderID = value
			End Set
		End Property

		Private m_orderDate As DateTime
		Public Property OrderDate() As DateTime
			Get
				Return m_orderDate
			End Get
			Set
				m_orderDate = value
			End Set
		End Property

		Private m_shipName As String
		Public Property ShipName() As String
			Get
				Return m_shipName
			End Get
			Set
				m_shipName = value
			End Set
		End Property

		Private m_shipCountry As String
		Public Property ShipCountry() As String
			Get
				Return m_shipCountry
			End Get
			Set
				m_shipCountry = value
			End Set
		End Property

		Private m_price As Double
		Public Property Price() As Double
			Get
				Return m_price
			End Get
			Set
				m_price = value
			End Set
		End Property
		#End Region
	End Class
End Namespace