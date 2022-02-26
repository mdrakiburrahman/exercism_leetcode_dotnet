using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        return new Dictionary<int, string> {
                    [1] = "United States of America",
                    [55] = "Brazil",
                    [91] = "India"
                };
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        Dictionary<int, string> countryCodes = GetEmptyDictionary();
        countryCodes.Add(countryCode, countryName);
        return countryCodes;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            return existingDictionary[countryCode];
        }
        else
        {
            return "";
        }
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }
        else
        {
            return existingDictionary;
        };
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary.Remove(countryCode);
            return existingDictionary;
        }
        else
        {
            return existingDictionary;
        };
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longest = "";
        foreach (KeyValuePair<int, string> entry in existingDictionary)
        {
            if (entry.Value.Length > longest.Length)
            {
                longest = entry.Value;
            }
        };
        return longest;
    }
}