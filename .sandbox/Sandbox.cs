using System;
using System.Linq;

char[] s1 = { 't','h','e',' ','s','k','y',' ','i','s',' ','b','l','u','e' };
Solution sol = new Solution();
sol.ReverseWords(s1);

char[] s2 = { 'a' };
sol.ReverseWords(s2);

char[] s3 = { 'a',' ','b',' ','c',' ','d',' ','e' };
sol.ReverseWords(s3);

char[] s4 = { 'h','i'};
sol.ReverseWords(s4);

public class Solution {
    public void ReverseWords(char[] s) {
        if (s == null || s.Length == 0 || s.Length == 1 || !s.Contains(' ')) return;

        int left_ptr = 0, right_ptr = (s.Length - 1);
        string buffer = ""; // 0. Start buffer as empty
        
        
        while (left_ptr <= right_ptr) // Loop until left_ptr >= right_ptr
        {
            // 1. Start from the right, find the first word - including the space, set right_ptr
            (int, string) tuple1 = GetRightWord(s, right_ptr);
            string new_word = tuple1.Item2 + " ";
            
            // 2. For the number of digits we found in new_word, copy to a 'buffer' from front
            // 3. Copy the new_word to front, set left_ptr
            (int, string) tuple2 = CopyRightWord(s, new_word, left_ptr);
            buffer += tuple2.Item2;

            if (left_ptr != right_ptr) // If pointers are same, we want to start copying from here
            {
                right_ptr = tuple1.Item1 - 1; // One over from _
                left_ptr = tuple2.Item1;
            } else {
                break;
            }
        }

        // From left_ptr -> Split buffer by space -> Copy per word into s -> return
        string words = String.Join(" ", buffer.Split(' ')[0..^1].Reverse().ToArray());

        // Loop from left_ptr -> Copy words to s
        for (int i = left_ptr; i < s.Length; i++)
        {
            s[i] = words[i - left_ptr];
        }

    }
    
    public (int, string) CopyRightWord(char[] s, string new_word, int left_ptr)
    {
        string buffer = "";
        
        for (int i=left_ptr; i<new_word.Length+left_ptr; i++)
        {
            buffer += s[i];
            if (i == new_word.Length+left_ptr-1)
            {
                s[i] = ' ';                
            }    
            else {
                s[i] = new_word[i-left_ptr];   
            }
        }
        return(left_ptr + new_word.Length, buffer);
    }
    
    public (int, string) GetRightWord(char[] s, int right_ptr)
    {
        string word = "";
        
        while ((char)s[right_ptr] != ' ' && right_ptr != 0)
        {
            word += s[right_ptr];
            right_ptr--;
        }

        return(right_ptr, new string(word.ToCharArray().Reverse().ToArray()));
    }
}