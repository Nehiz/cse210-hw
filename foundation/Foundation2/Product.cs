class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Calculates the total cost of the product
    public double GetTotalCost()
    {
        return price * quantity;
    }

    // Returns the product's name
    public string GetName()
    {
        return name;
    }

    // Returns the product's ID
    public string GetProductId()
    {
        return productId;
    }
}