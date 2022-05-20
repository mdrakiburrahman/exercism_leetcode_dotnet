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


Console.WriteLine("");
Console.WriteLine("\n\noriginal: ");
sol.PrintMatrix(matrix);

public class Solution {
    struct matrix {
        public  int m, n; // m rows, n columns
        public  int[][] grid;
        public  int r, c; // Indices - zero indexed
        public  string direction; // Starting direction
        public int[] r_bound, c_bound; // Boundaries for the current row and column
        public int hits; // Number of times we've hit a boundary

        public matrix(int[][] g) {
            this.grid = g;
            this.m = g.Length;
            this.n = g[0].Length;
            this.r = 0;
            this.c = 0;
            this.direction = "right";
            this.r_bound = new int[] {0, n - 1};
            this.c_bound = new int[] {0, m - 1};
            this.hits = 0;
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
                direction = "left";
                r--;
                IncrementHits();
                return;
            }
        }
        public void MoveUp() {
            if (c > 0) {
                c--;
                return;
            } else {
                direction = "right";
                r++;
                IncrementHits();
                return;
            }
        }
        public void MoveLeft() {
            if (r > 0) {
                r--;
                return;
            } else {
                direction = "up";
                c--;
                IncrementHits();
                return;
            }
        }
        public void MoveRight() {
            if (r < n - 1) {
                r++;
                return;
            } else {
                direction = "down";
                c++;

                hits++;

                return;
            }
        }
        public void IncrementHits(){
            hits++;
            if(hits >= 3){
                UpdateBounds();
            }
        }
        public void UpdateBounds(){
            switch (direction) {
                case "up":
                    c_bound[0]++;
                    break;
                case "down":
                    c_bound[1]--;
                    break;
                case "left":
                    r_bound[0]++;
                    break;
                case "right":
                    r_bound[1]--;
                    break;
            }
        }
    }

    public IList<int> SpiralOrder(int[][] grid) {        
        // Initialize matrix
        var m = new matrix(grid);

        // New return variable
        var ret = new List<int>();

        // Loop until we've visited all elements
        for (int i = 1; i <= (m.m * m.n); i++)
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