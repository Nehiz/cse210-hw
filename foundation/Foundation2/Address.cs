using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    // Constructor to initialize the address
    public Address (string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // Returns true if the address is in the USA
    public bool IsInUSA()
    {
        return country.Tolower() == "usa";
    }

    // TReturns the full address as a string
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }

}

