using Crossword.Puzzle.Squares;

namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region GetSquare

    /// <summary>
    /// Gets the first square referenced by my answer.
    /// </summary>
    /// <returns></returns>
    public Square? GetSquare()
    {
        return SqAnswerSquares?[0];
    }

    #endregion
}