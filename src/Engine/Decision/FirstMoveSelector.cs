using Domain.ValueObjects;

namespace Engine.Decision;

public sealed class FirstMoveSelector : IMoveSelector
{
    public UciMove Select(IReadOnlyList<UciMove> moves)
    {
        if (moves.Count == 0)
            throw new InvalidOperationException("No moves available");

        return moves[0];
    }
}