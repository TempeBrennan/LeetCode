// C# implementation of the above approach
using System;
using System.Collections.Generic;
using TestLeetCode;

class MazePrint : IExecutable
{
    // List to store all the possible paths
    static List<String> possiblePaths = new List<String>();
    static String path = "";
    static readonly int MAX = 5;

    public AlgorithmType Type => AlgorithmType.BackTracking;

    public string Name => "";

    public string Description => "";

    // Function returns true if the
    // move taken is valid else
    // it will return false.
    static bool isSafe(int row, int col, int[,] m,
                        int n, bool[,] visited)
    {
        if (row == -1 || row == n || col == -1 ||
            col == n || visited[row, col] ||
                        m[row, col] == 0)
            return false;
        return true;
    }

    // Function to print all the possible
    // paths from (0, 0) to (n-1, n-1).
    static void printPathUtil(int row, int col, int[,] m,
                            int n, bool[,] visited)
    {

        // This will check the initial point
        // (i.e. (0, 0)) to start the paths.
        if (row == -1 || row == n || col == -1 ||
            col == n || visited[row, col] ||
                        m[row, col] == 0)
            return;

        // If reach the last cell (n-1, n-1)
        // then store the path and return
        if (row == n - 1 && col == n - 1)
        {
            possiblePaths.Add(path);
            return;
        }

        // Mark the cell as visited
        visited[row, col] = true;

        // Try for all the 4 directions (down, left,
        // right, up) in the given order to get the
        // paths in lexicographical order

        // Check if downward move is valid
        if (isSafe(row + 1, col, m, n, visited))
        {
            path += 'D';
            printPathUtil(row + 1, col, m, n,
                        visited);
            path = path.Substring(0, path.Length - 1);
        }

        // Check if the left move is valid
        if (isSafe(row, col - 1, m, n, visited))
        {
            path += 'L';
            printPathUtil(row, col - 1, m, n,
                        visited);
            path = path.Substring(0, path.Length - 1);
        }

        // Check if the right move is valid
        if (isSafe(row, col + 1, m, n, visited))
        {
            path += 'R';
            printPathUtil(row, col + 1, m, n,
                        visited);
            path = path.Substring(0, path.Length - 1);
        }

        // Check if the upper move is valid
        if (isSafe(row - 1, col, m, n, visited))
        {
            path += 'U';
            printPathUtil(row - 1, col, m, n,
                        visited);
            path = path.Substring(0, path.Length - 1);
        }

        // Mark the cell as unvisited for
        // other possible paths
        visited[row, col] = false;
    }

    // Function to store and print
    // all the valid paths
    static void printPath(int[,] m, int n)
    {
        bool[,] visited = new bool[n, MAX];

        // Call the utility function to
        // find the valid paths
        printPathUtil(0, 0, m, n, visited);

        // Print all possible paths
        for (int i = 0; i < possiblePaths.Count; i++)
            Console.Write(possiblePaths[i] + " ");
    }

    // Driver code
    public void Execute()
    {
        int[,] m = { { 1, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1 },
                { 1, 1, 1, 0, 1 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 1 } };
        int n = m.GetLength(0);
        printPath(m, n);
    }
}