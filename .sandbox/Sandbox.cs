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
        public int hits; // Number of times we've hit edges
        public int r_move, c_move; // Boundary counter
        public  string direction; // Starting direction

        public matrix(int[][] g) {
            this.grid = g;
            this.m = g.Length;
            this.n = g[0].Length;
            this.r = 0;
            this.c = 0;
            this.direction = "right";
            this.hits = 3;
            this.r_move = this.n;
            this.r_move = this.m;
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
            if (c < m - 1) {
                c++;
                return;
            } else {
                hits--;
                if (hits <= 0) {
                    n--; // Reduce boundary   
                }
                direction = "left";
                r--;
                return;
            }
        }
        public void MoveUp() {
            if (c > 0) {
                c--;
                return;
            } else {
                hits--;
                if (hits <= 0) {
                    n--; // Reduce boundary   
                }
                direction = "right";
                r++;
                return;
            }
        }
        public void MoveLeft() {
            if (r > 0) {
                r--;
                return;
            } else {
                hits--;
                if (hits <= 0) {
                    m--; // Reduce boundary   
                }
                direction = "up";
                c--;
                return;
            }
        }
        public void MoveRight() {
            if (r < n - 1) {
                r++;
                return;
            } else {
                hits--;
                if (hits <= 0) {
                    m--; // Reduce boundary   
                }
                direction = "down";
                c++;
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
        var dims = m.m * m.n;

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