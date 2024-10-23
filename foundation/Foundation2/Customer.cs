class Customer
{
    private string name;
    private string address;

    public Customer(string name, string address)
    {
        this.name = name;
        this.address = address;
    }

    // Returns true if the address is in the USA
    public bool LivesInUSA()
    {
        return adderess.IsInUSA();
    }

    // Returns the customer's name
    public string GetName()
    {
        return name;
    }

    // Returns the customer's address
    public Address GetAddress()
    {
        return address;
    }
}