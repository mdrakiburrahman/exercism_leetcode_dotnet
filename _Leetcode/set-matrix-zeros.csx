using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

Solution sol = new Solution();

// var matrix = new int[][] {
//     new int[] {0, 1, 2, 0},
//     new int[] {3, 0, 5, 2},
//     new int[] {1, 3, 1, 5}
// };

var matrix = new int[][] {
    new int[] {-4,-2147483648,6,-7,0},
    new int[] {-8,6,-8,-6,0},
    new int[] {2147483647,2,-9,-6,-10}
};

sol.SetZeroes(matrix);

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        bool firstRow = false; // This will be set to true if the first row has a zero anywhere
        int numRows, numCols;
        numRows = matrix.Length;
        numCols = matrix[0].Length;

        // Loop over rows to determine zeros
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    // Set row flag
                    if (i == 0)
                    {
                        firstRow = true;
                    }
                    else
                    {
                        matrix[i][0] = 0;
                    }
                    // Set column flag
                    matrix[0][j] = 0;
                }
            }
        }

        // Fill in Zeros

        // j = 1 to numCols
        for (int j = 1; j < numCols; j++)
        {
            if (matrix[0][j] == 0)
            {
                for (int i = 1; i < numRows; i++)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // i = 1 to numRows
        for (int i = 1; i < numRows; i++)
        {
            if (matrix[i][0] == 0)
            {
                for (int j = 1; j < numCols; j++)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // j = 0 was found 0
        if (matrix[0][0] == 0)
        {
            for (int i = 1; i < numRows; i++)
            {
                matrix[i][0] = 0;
            }
        }

        // i = 0 was found 0
        if (firstRow)
        {
            for (int j = 0; j < numCols; j++)
            {
                matrix[0][j] = 0;
            }
        }
        return;
    }
}