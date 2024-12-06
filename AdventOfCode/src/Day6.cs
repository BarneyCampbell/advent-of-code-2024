using System.Data;
using AdventOfCode.Lib;

namespace AdventOfCode.Days;

public class Day6(string _input) : IDay
{
    public string Input { get; } = _input;

    private List<(int, int)> directions = [
        (0,-1),
        (1,0),
        (0,1),
        (-1,0)
    ];

    public string Part1()
    {
        IEnumerable<string> lines = Input.Split('\n');
        char[][] map = lines.Select(line => line.ToCharArray()).ToArray();

        int x = 0, y = 0;
        for (int i = 0; i < map.Length; i++)
        {
            int index = map[i].ToList().IndexOf('^');
            if (index != -1)
            {
                x = index;
                y = i;
            }
        }

        map[y][x] = 'X';

        int currentDirection = 0;
        while (y >= 0 && y < map.Length && x >= 0 && x < map[0].Length)
        {
            int dx, dy;
            (dx, dy) = directions[currentDirection];
            
            y += dy;
            x += dx;

            if (!(y >= 0 && y < map.Length && x >= 0 && x < map[0].Length))
            {
                break;
            }

            if (map[y][x] == '#')
            {
                y -= dy;
                x -= dx;
                currentDirection = NewDirection(currentDirection);
                continue;
            }

            map[y][x] = 'X';
        }

        // foreach (var line in map)
        // {
        //     Console.WriteLine(string.Join("", line));
        // }
        return map.Select(line => line.Count(p => p == 'X')).Sum().ToString();
    }

    public int NewDirection(int currentDirection)
    {
        if(currentDirection >= 3) return 0;
        return currentDirection + 1;
    }

    public string Part2()
    {
        return "Not implemented";
    }
}