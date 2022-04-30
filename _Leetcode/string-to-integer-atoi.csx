using System;
using System.Linq;

Solution sol = new Solution();
int result;
// result = sol.MyAtoi("  -4193 with words");
// result = sol.MyAtoi("words and 987");
// result = sol.MyAtoi("    -42");
// result = sol.MyAtoi("-2147483648");
// result = sol.MyAtoi("+-12");
// result = sol.MyAtoi("992147483646");
result = sol.MyAtoi("21474836460");
Console.WriteLine(result);

public class Solution {
    public int MyAtoi(string s) {
        bool isPositive = true; // Start assuming positive
        bool inStreak = false;
        long result = 0; // We will switch to integer after :)
        for (int i=0; i<s.Length; i++) {
            if (inStreak && (s[i] < '0' || s[i] > '9')) { // Check if streak is broken
                break;
            }
            if (s[i] == '-') {
                isPositive = false;
                inStreak = true;
                continue;
            }
            if (s[i] == '+') {
                isPositive = true;
                inStreak = true;
                continue;
            }
            if (s[i] == ' ') {
                continue;
            }
            if (!inStreak && (s[i] < '0' || s[i] > '9')) { // Not in streak yet and not a digit
                break;
            }
            if (s[i] >= '0' && s[i] <= '9') { // If we find a digit, start streak
                if (!inStreak) {
                    inStreak = true;
                }

                result = result*10 + int.Parse(s[i].ToString());

                if ( result > (long)(int.MaxValue) ) { // Check if we already overflowed past an int
                    if (isPositive) {
                        return int.MaxValue;
                    } else {
                        return int.MinValue;
                    }
                }
            }
        }
        if (!isPositive) {
            result = -result;
        }
        return (int)result;
    }
}