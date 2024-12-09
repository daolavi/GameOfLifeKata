namespace GameOfLife.Logic;

public class GameOfLife
{
    public bool[,] Grid { get; private set; }

    public GameOfLife(bool[,] grid)
    {
        Grid = grid;
    }

    public void NextGeneration()
    {
        var newGrid = (Grid.Clone() as bool[,])!;
        
        var rows = Grid.GetLength(0);
        var columns = Grid.GetLength(1);
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var numberOfLiveNeighbors = GetNumberOfLiveNeighbors(i, j);
                if (Grid[i, j])
                {
                    if (numberOfLiveNeighbors is < 2 or > 3)
                    {
                        newGrid[i, j] = false;
                    }
                }
                else
                {
                    if (numberOfLiveNeighbors == 3)
                    {
                        newGrid[i, j] = true;
                    }
                }
            }
        }

        Grid = newGrid;
    }
/*
x-1,y-1  x-1,y  x-1, y+1
         x,y     x,y+1
                x+1,y+1
 */
    private int GetNumberOfLiveNeighbors(int row, int column)
    {
        var maxRow = Grid.GetLength(0);
        var maxColumn = Grid.GetLength(1);
        var result = 0;
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                if (i ==0 && j == 0) continue;
                if (row + i >= 0 && row + i < maxRow
                    && column + j >=0 && column + j < maxColumn
                    && Grid[row + i, column + j])
                {
                    result++;
                }
            }
        }

        return result;
    }
}