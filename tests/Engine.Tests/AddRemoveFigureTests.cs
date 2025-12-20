using Engine.Bitboards;
using static Engine.Tests.TestHelpers.BitboardTestHelper;

namespace Engine.Tests;

public sealed class AddRemoveFigureTests
{
    [Fact]
    public void WhitePawns_Should_Be_Added_To_Particular_Field()
    {
        // arrange
        var board = new PieceBitboards();

        // act
        var d2 = DefineSquare('d', 2);
        board.AddWhitePawn(d2);

        // assert
        Assert.True(board.IsOccupied(d2)); // Check if d2 is occupied
        Assert.True(HasBit(board.WhitePawns, d2));
        Assert.False(HasBit(board.BlackPawns, d2));

    }

    [Fact]
    public void BlackPawns_Should_Be_Added_To_Particular_Field()
    {
        // arrange
        var board = new PieceBitboards();

        // act
        var d7 = DefineSquare('d', 7);
        board.AddBlackPawn(d7);

        // assert
        Assert.True(board.IsOccupied(d7)); // Check if d7 is occupied
        Assert.True(HasBit(board.BlackPawns, d7));
        Assert.False(HasBit(board.WhitePawns, d7));

    }

    [Fact]
    public void WhitePawn_Should_Be_Removed_From_Field()
    {
        var board = new PieceBitboards();


        var d2 = DefineSquare('d', 2);
        board.AddWhitePawn(d2);

        // sanity check
        Assert.True(board.IsOccupied(d2));

        // act
        board.RemoveWhitePawn(d2!);

        // assert
        Assert.False(board.IsOccupied(d2));
        Assert.False(HasBit(board.WhitePawns, d2));
    }

    [Fact]
    public void BlackPawn_Should_Be_Removed_From_Field()
    {
        var board = new PieceBitboards();

        var d7 = DefineSquare('d', 7);
        board.AddBlackPawn(d7);

        // sanity check
        Assert.True(board.IsOccupied(d7));

        // act
        board.RemoveBlackPawn(d7!);

        // assert
        Assert.False(board.IsOccupied(d7));
        Assert.False(HasBit(board.BlackPawns, d7));
    }

}