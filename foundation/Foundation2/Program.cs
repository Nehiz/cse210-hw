using System;

class Program
{
    static void Main(string[] args)
    {
        // Create two addresses
        Address address1 = new Address("123 Main St", "Sprinfield", "IL", "USA");
        Address address2 = new Address("456 High St", "London", "England", "UK");

        // Create two customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Jane Doe", address2);

        // Create some products
        Product product1 = new Product("Laptop", "12345", 1000, 1);
        Product product2 = new Product("Tablet", "65432", 500, 2);
        Product product3 = new Product("Monitor", "54321", 200, 1);
        Product product4 = new Product("Keyboard", "98765", 50, 1);

        // Create order for customer1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        
        // Create order for customer2
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display packing and shipping Labels and total cost for order1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total cost: {order1.GetTotalPrice()}");
        Console.WriteLine("\n---------------------\n");

        // Display packing and shipping Labels and total cost for order2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total cost: {order2.GetTotalPrice()}");
    
    }
}