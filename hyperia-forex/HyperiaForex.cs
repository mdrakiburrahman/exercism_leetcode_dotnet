using System;

public struct CurrencyAmount
{
    public decimal amount;
    public string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
    // Overrides
    public override bool Equals(object other)
    {
        if (!(other is CurrencyAmount))
          return false;
        
        CurrencyAmount my_curr = (CurrencyAmount)other;

        return this.amount == my_curr.amount && this.currency == my_curr.currency;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(amount, currency);
    }

    // Equality operators
    public static bool operator ==(CurrencyAmount A, CurrencyAmount B)
    {
        return A.currency == B.currency 
            ?
                A.amount == B.amount
                : 
                throw new ArgumentException("Currency must be the same");
    }
    public static bool operator !=(CurrencyAmount A, CurrencyAmount B)
    {
        return A.currency == B.currency 
            ?
                A.amount != B.amount
                : 
                throw new ArgumentException("Currency must be the same");
    }

    // Comparison operators
    public static bool operator >(CurrencyAmount A, CurrencyAmount B)
    {
        return A.currency == B.currency 
            ?
                A.amount > B.amount
                : 
                throw new ArgumentException("Currency must be the same");
    }

    public static bool operator <(CurrencyAmount A, CurrencyAmount B)
    {
        return A.currency == B.currency 
            ?
                A.amount < B.amount
                : 
                throw new ArgumentException("Currency must be the same");
    }

    // Arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount A, CurrencyAmount B)
    {
        return A.currency == B.currency 
            ?
                new CurrencyAmount (A.amount + B.amount, A.currency)
                : 
                throw new ArgumentException("Currency must be the same");
    }
    public static CurrencyAmount operator -(CurrencyAmount A, CurrencyAmount B)
    {
        return A.currency == B.currency 
            ?
                new CurrencyAmount (A.amount - B.amount, A.currency)
                : 
                throw new ArgumentException("Currency must be the same");
    }
    public static CurrencyAmount operator *(CurrencyAmount A, decimal num)
    {
        return new CurrencyAmount (A.amount * num, A.currency);
    }
    public static CurrencyAmount operator /(CurrencyAmount A, decimal num)
    {
        return new CurrencyAmount (A.amount / num, A.currency);
    }

    // Conversion operators
    // Explicit really just means we are physically converting one of the fields to another type - I.e. decimal -> double is explicit cast
    public static explicit operator double(CurrencyAmount A) => (double)A.amount;
    // Implicit really just means we are not doing any type casting, but rather when someone asked for a "decimal" against a CurrencyAmount we return amount, which is already a decimal
    // So basically, "give me the decimal part of this struct -> here you go"
    public static implicit operator decimal(CurrencyAmount A) => A.amount;
}
