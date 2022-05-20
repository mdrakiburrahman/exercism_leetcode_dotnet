using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

var matrix = new int[][] {
    new int[] {1, 2, 3, 4},
    new int[] {5, 6, 7, 8},
    new int[] {9, 10, 11, 12}
};

Console.WriteLine("original: ");
sol.PrintMatrix(matrix);

var ret = sol.SpiralOrder(matrix);

Console.WriteLine("");
Console.WriteLine("returned: ");

// Print the result
foreach (var item in ret)
{
    Console.Write(item + " ");
}

Console.WriteLine("\n\noriginal: ");
sol.PrintMatrix(matrix);

public class Solution {
    struct matrix {
        public  int m, n; // m rows, n columns
        public  int[][] grid;
        public  int r, c; // Indices - zero indexed
        public int r_ceil, c_ceil; // Boundary counter
        public int rounds; // Number of rounds
        public string direction; // Starting direction

        public matrix(int[][] g) {
            this.grid = g;
            this.m = g.Length;
            this.n = g[0].Length;
            this.r = 0;
            this.c = 0;
            this.direction = "right";
            this.r_ceil = this.n -1;
            this.c_ceil = this.m - 1;
            this.rounds = 1;
        }

        public void Move() {
            switch (this.direction) {
                case "right":
                    this.MoveRight();
                    break;
                case "down":
                    this.MoveDown();
                    break;
                case "left":
                    this.MoveLeft();
                    break;
                case "up":
                    this.MoveUp();
                    break;
            }
        }

        public void MoveDown() {
            if (c_move > 0) {
                c_move--;
                c++;
                return;
            } else {
                // Decrement & Reset
                hits--;
                m--;
                c_move = m;
                
                // Switch direction               
                direction = "left";
                r--;
                r_move--;
                return;
            }
        }
        public void MoveUp() {
            if (c_move > 0) {
                c_move--;
                c--;
                return;
            } else {
                // Decrement & Reset
                hits--;
                m--;
                c_move = m;
                
                // Switch direction
                direction = "right";
                r++;
                r_move--;
                return;
            }
        }
        public void MoveLeft() {
            if (r_move > 0) {
                r_move--;
                r--;
                return;
            } else {
                // Decrement & Reset
                hits--;
                n--;
                r_move = n;

                // Switch direction
                direction = "up";
                c--;
                c_move--;
                return;
            }
        }
        public void MoveRight() {
            if (r_move > 0) {
                r_move--;
                r++;
                return;
            } else {
                // Decrement & Reset
                hits--;
                n--;
                r_move = n;

                // Switch direction
                direction = "down";
                c++;
                c_move--;
                return;
            }
        }
    }

    public IList<int> SpiralOrder(int[][] grid) {        
        // Initialize matrix
        var m = new matrix(grid);

        // New return variable
        var ret = new List<int>();

        // Number of dimensions - we calculate this because m and n will change as we reduce the boundary
        var dims = grid.Length * grid[0].Length;

        // Loop until we've visited all elements
        for (int i = 1; i <= dims; i++)
        {
            ret.Add(m.grid[m.c][m.r]);
            m.Move();
        }
        
        return ret;
    }

    public void PrintMatrix(int[][] grid) {
        foreach (var row in grid) {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}