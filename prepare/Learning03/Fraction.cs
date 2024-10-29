using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // No-argument constructor
    public Fraction()    // Defaults to 1/1
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Single-paramenter constructor
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Two-parameter constructor
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getters and Setters
    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator != 0) // Avoid division by zero
        {
            _denominator = denominator;
        }
        else
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
    }

    // Methods for representation
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}