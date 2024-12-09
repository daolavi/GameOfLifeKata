namespace GameOfLife.Tests;

[TestFixture]
public class GameOfLifeTests
{
    [Test]
    public void Initialise_ShouldCreateBoard()
    {
        bool[,] grid =
        {
            { false, false, false },
            { false, false, false },
            { false, false, false }
        };

        var game = new Logic.GameOfLife(grid);
        Assert.That(game.Grid, Is.Not.Null);
    }

    [Test]
    public void NextGeneration_LiveCell_WithFewerThanTwoLiveNeighbors_Dies()
    {
        bool[,] grid =
        {
            { false, true, false },
            { false, true, false },
            { false, false, false }
        };
        var game = new Logic.GameOfLife(grid);
        game.NextGeneration();
        Assert.That(game.Grid[1,1], Is.EqualTo(false));
    }

    [Test]
    public void NextGeneration_LiveCell_WithTwoLiveNeighbors_Lives()
    {
        bool[,] grid =
        {
            { false, true, false },
            { false, true, true },
            { false, false, false }
        };
        var game = new Logic.GameOfLife(grid);
        game.NextGeneration();
        Assert.That(game.Grid[1,1], Is.EqualTo(true));
    }
    
    [Test]
    public void NextGeneration_LiveCell_WithThreeLiveNeighbors_Lives()
    {
        bool[,] grid =
        {
            { false, true, false },
            { false, true, true },
            { false, true, false }
        };
        var game = new Logic.GameOfLife(grid);
        game.NextGeneration();
        Assert.That(game.Grid[1,1], Is.EqualTo(true));
    }

    [Test]
    public void NextGeneration_LiveCell_WithMoreThanThreeLiveNeighbors_Dies()
    {
        bool[,] grid =
        {
            { false, true, false },
            { true, true, true },
            { false, true, false }
        };
        var game = new Logic.GameOfLife(grid);
        game.NextGeneration();
        Assert.That(game.Grid[1,1], Is.EqualTo(false));
    }
    
    [Test]
    public void NextGeneration_DeadCell_WithThreeLiveNeighbors_Lives()
    {
        bool[,] grid =
        {
            { false, true, false },
            { true, false, true },
            { false, false, false }
        };
        var game = new Logic.GameOfLife(grid);
        game.NextGeneration();
        Assert.That(game.Grid[1,1], Is.EqualTo(true));
    }
}