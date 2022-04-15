using System.Text.RegularExpressions;

public class Solution {
    public bool IsPalindrome(string s) {
        string clean = Regex.Replace(s, "[^A-Za-z0-9]", "").ToLower();
        
        if (clean.Length == 0)
            return true;
        
        int front = 0, back = clean.Length - 1;
        
        while (front != back && (front - 1) != back)
        {   
            if (clean[front] != clean[back]){
                return false;
            }
            
            front++;
            back--;
        }
        
        return true;
    }
}