using System;
using System.Linq;

public class PhoneNumber
{
    public static string CleanNumber(string phoneNumber)
    {
        string result = "";
        foreach(char c in phoneNumber)
        {
            if(Char.IsDigit(c))
            {
                result += c;
            }
        }
        return result;
    }

    public static bool CheckValidN(char digit)
    {
        if (digit >= '2' && digit <= '9')
        {
            return true;
        }
        return false;
    }

    public static string Clean(string phoneNumber)
    {
        phoneNumber = CleanNumber(phoneNumber);

        // Error handling
        if (phoneNumber.Length < 10)
        {
            throw new ArgumentException("Phone number must be at least 10 digits");
        } else if (phoneNumber.Length > 11)
        {
            throw new ArgumentException("Number is greater than 11 digits");
        }
        
        // Handle 11 digits
        if (phoneNumber.Length == 11)
        {
            if (phoneNumber.StartsWith("1"))
            {
                phoneNumber = phoneNumber.Substring(1); // Trim country code
            } else
            {
                throw new ArgumentException("Number does not start with 1");
            }
        }

        // Handle invalid N: NXX NXX XXXX
        var N_area = phoneNumber[0];
        var N_exchange = phoneNumber[3];

        if (!CheckValidN(N_area) || !CheckValidN(N_exchange))
        {
            throw new ArgumentException("Invalid N");
        }

        return phoneNumber;
    }
}