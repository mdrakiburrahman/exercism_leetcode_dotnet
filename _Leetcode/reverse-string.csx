public class Solution {
    public void ReverseString(char[] s) {

        int front = 0, back = s.Length - 1;

        while (front != back && (front - 1) != back)
        {   
            char temp = s[back];
            s[back] = s[front];
            s[front] = temp;
            
            front++;
            back--;
        }
        
        return;
    }
}