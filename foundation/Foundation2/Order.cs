class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Calculate the total price of the order including shipping
    public double GetTotalPrice()
    {
        double totalCost = 0;

        // Sum up the total cost of all products
        foreach (Product product in products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost based on whether the customer is in the USA
        if (customer.LivesInUSA())
        {
            totalCost += 5; // $5 for shipping in the USA
        }
        else
        {
            totalCost += 35; // $35 for shipping outside the USA
        }

        return totalCost;
    }

    // Generate a packing label (List of product names and IDs)
    public string GetPackingLabel()
    {
        string packLabel =  "Packing Label:\n";
        foreach (Product product in products)
        {
            packLabel += $"- Product: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        return packLabel;
    }

    // Generate a shipping Label (customer's name and address)
    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}\n";
        
        return shippingLabel;
    }
}