using System;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (identifier == "") {
            return "";
        }

        string newString = "";       
        for (int i = 0; i < identifier.Length; i++) {
            // A = 65; a = 97; Z = 90; z = 122;
            if (((int)identifier[i] <= 57 && (int)identifier[i] >= 48) || (int)identifier[i] > 50000) { // Omit non characters
                continue;                
            } else if (char.IsControl(identifier, i)){ // Replace control characters with the upper case string "CTRL"
                newString += "CTRL";
            } else if (identifier[i] == '-') { // 3. Kebab Case to Camel Case
                newString += identifier[i+1].ToString().ToUpper(); // Skip to next char
                i++; // Increment i so we don't double count
            } else if ((int)identifier[i] >= 945 && (int)identifier[i] <= 969) { // 4. Omit lower case greek letters
                continue;                
            } else { // Add as usual
                newString += identifier[i];
            }
        }
        // Replace any spaces encountered with underscores
        newString = newString.Replace(" ", "_");
        return newString;
    }
}
