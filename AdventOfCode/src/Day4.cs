using System.Data;
using AdventOfCode.Lib;

namespace AdventOfCode.Days;

public class Day4(string _input) : IDay
{
    public string Input { get; } = _input;

    public string Part1()
    {
        var wordsearch = Input.Split('\n').Select(row => row.ToCharArray()).ToArray();
        if (wordsearch == null)
        {
            return "0";
        }

        int score = 0;
        for (int i = 0; i < wordsearch.Length; i++)
        {
            for (int j = 0; j < wordsearch[i].Length; j++)
            {
                if (wordsearch[i][j] == 'X')
                {
                    score += AllDirectionSearch(wordsearch, i, j);
                }
            }
        }

        return score.ToString();
    }

    private int AllDirectionSearch(char[][] wordsearch, int i, int j)
    {
        int count = 0;
        // left
        if (j-3 >= 0)
        {
            count += wordsearch[i][j-1] == 'M' &&  wordsearch[i][j-2] == 'A' &&  wordsearch[i][j-3] == 'S' ? 1 : 0;
        }

        // right
        if (j+3 < wordsearch[i].Length)
        {
            count += wordsearch[i][j + 1] == 'M' && wordsearch[i][j + 2] == 'A' && wordsearch[i][j + 3] == 'S' ? 1 : 0;
        }

        // up
        if (i-3 >= 0)
        {
            count += wordsearch[i-1][j] == 'M' &&  wordsearch[i-2][j] == 'A' &&  wordsearch[i-3][j] == 'S' ? 1 : 0;
        }

        // down
        if (i+3 < wordsearch.Length)
        {
            count += wordsearch[i+1][j] == 'M' && wordsearch[i+2][j] == 'A' && wordsearch[i+3][j] == 'S' ? 1 : 0;
        }

        // up left
        if (j-3 >= 0 && i-3 >= 0)
        {
            count += wordsearch[i-1][j-1] == 'M' &&  wordsearch[i-2][j-2] == 'A' &&  wordsearch[i-3][j-3] == 'S' ? 1 : 0;
        }

        // up right
        if (j+3 < wordsearch[i].Length && i-3 >= 0)
        {
            count += wordsearch[i-1][j + 1] == 'M' && wordsearch[i-2][j + 2] == 'A' && wordsearch[i-3][j+3] == 'S' ? 1 : 0;
        }

        // down left
        if (i+3 < wordsearch.Length && j-3 >= 0)
        {
            count += wordsearch[i+1][j-1] == 'M' &&  wordsearch[i+2][j-2] == 'A' &&  wordsearch[i+3][j-3] == 'S' ? 1 : 0;
        }

        // down right
        if (i+3 < wordsearch.Length && j+3 < wordsearch[i].Length)
        {
            count += wordsearch[i+1][j+1] == 'M' && wordsearch[i+2][j+2] == 'A' && wordsearch[i+3][j+3] == 'S' ? 1 : 0;
        }

        return count;
    }

    public string Part2()
    {
        var wordsearch = Input.Split('\n').Select(row => row.ToCharArray()).ToArray();
        if (wordsearch == null)
        {
            return "0";
        }

        int score = 0;
        for (int i = 0; i < wordsearch.Length; i++)
        {
            for (int j = 0; j < wordsearch[i].Length; j++)
            {
                if (wordsearch[i][j] == 'A')
                {
                    score += MasSearch(wordsearch, i, j);
                }
            }
        }

        return score.ToString();
    }

    private int MasSearch(char[][] wordsearch, int i, int j)
    {
        string lrMas = "";
        // Left to right
        if (i+1 < wordsearch.Length && j+1 < wordsearch[i].Length && j-1 >= 0 && i-1 >= 0)
        {
            lrMas = $"{wordsearch[i-1][j-1]}{wordsearch[i][j]}{wordsearch[i+1][j+1]}";
        }

        string rlMas = "";
        // Right to Left
        if (i+1 < wordsearch.Length && j-1 >= 0 && j+1 < wordsearch[i].Length && i-1 >= 0)
        {
            rlMas = $"{wordsearch[i+1][j-1]}{wordsearch[i][j]}{wordsearch[i-1][j+1]}";
        }
        
        return IsMas(lrMas) && IsMas(rlMas) ? 1 : 0;
    }

    private bool IsMas(string possibleMas) => possibleMas is "MAS" or "SAM";
}