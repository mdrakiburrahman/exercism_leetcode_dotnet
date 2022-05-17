using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

// var matrix = new int[][] {
//     new int[] {1, 2, 3},
//     new int[] {4, 5, 6},
//     new int[] {7, 8, 9}
// };

var matrix = new int[][] {
    new int[] {5, 1, 9, 11},
    new int[] {2, 4, 8, 10},
    new int[] {13, 3, 6, 7},
    new int[] {15, 14, 12, 16}
};

Console.WriteLine("");
sol.PrintMatrix(matrix);
sol.Rotate(matrix);
Console.WriteLine("");
sol.PrintMatrix(matrix);

public class Solution {
    public struct Coordinates {
        public int X;
        public int Y;
    }

    public struct Position {
        public int Value;
        public Coordinates Coord;
    }

    public void Rotate(int[][] matrix) {
        int length = matrix.Length;

        Coordinates start = new Coordinates { X = 0, Y = 0 };
        Coordinates end = new Coordinates { X = 0, Y = length - 1 };

        Queue<Position> q = new Queue<Position>();

        while (start.X <= end.X && start.Y <= end.Y) {
            if ((start.X == end.X ) && (start.Y == end.Y)) {
                break;
            }

            // Add stuff to stack
            for (int i = start.Y; i <= end.Y; i++) {
                Position p = new Position {
                    Value = matrix[start.X][i],
                    Coord = new Coordinates { X = start.X, Y = i }
                };

                q.Enqueue(p);
                
                // Null out the value in the matrix using a large negative int
                matrix[start.X][i] = int.MinValue;
            }

            // Loop until stack is empty
            while (q.Count > 0) {
                Position p = q.Dequeue();                
                Coordinates p_new = Transpose(p.Coord, length);

                // Queue old values that we are about to replace
                Position temp = new Position {
                    Value = matrix[p_new.X][p_new.Y],
                    Coord = p_new
                };
                
                if (temp.Value != int.MinValue) {
                    q.Enqueue(temp);
                }

                // Insert into matrix
                matrix[p_new.X][p_new.Y] = p.Value;
            }

            // Enter inner loop
            start.X++;
            start.Y++;
            end.X++;
            end.Y--;
        }
    }

    public Coordinates Transpose (Coordinates c, int length) {
        return new Coordinates { X = c.Y, Y = length - c.X - 1 };
    }

    public void PrintMatrix(int[][] matrix) {
        foreach (var row in matrix) {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}