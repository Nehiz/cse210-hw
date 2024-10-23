class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Returns true if the address is in the USA
    public bool LivesInUSA()
    {
        return address.IsInUSA();
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