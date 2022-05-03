public class Solution {
    public bool IsValid(string input) {
        var stack = new Stack<char>();
        var open = new List<char> {'(', '[', '{'};
        var close = new List<char> {')', ']', '}'};
        
        // Iterate through and add valid characters to stack
        foreach (char c in input)
        {
            if (open.Contains(c)) // Open Bracket
            {
                stack.Push(c);
            } else if (close.Contains(c)) // Close Bracket
            {
                // Hit closing bracket with empty stack
                if (stack.Count == 0)
                {
                    return false;
                }
                switch (c)
                {
                    case ')':
                        if (stack.Peek() != '(')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                    case ']':
                        if (stack.Peek() != '[')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                    case '}':
                        if (stack.Peek() != '{')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                }       
            }
        }
        return stack.Count == 0;         
    }
}