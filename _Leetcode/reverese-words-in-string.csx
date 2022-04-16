using System.Text.RegularExpressions;

public class Solution {
    public string ReverseWords(string s) {
        // Remove leading and trailing whitespace
        s = s.Trim();
        
        // Replace multiple whitespaces with single via RegEx
        Regex regex = new Regex("[ ]{2,}", RegexOptions.None);     
        s = regex.Replace(s, " ");
        
        // Split on ' ' , turn into array
        string[] words = s.Split(' ');
        
        // Reverse the array
        Array.Reverse(words);
        
        // Turn array into string and return it
        return string.Join(" ", words);
    }
}