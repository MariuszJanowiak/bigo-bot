using Domain.ValueObjects;

namespace Engine.Decision;

public interface IMoveSelector
{
    UciMove Select(IReadOnlyList<UciMove> moves);
}
