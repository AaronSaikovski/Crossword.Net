using Crossword.Shared.Constants;

namespace Crossword.Puzzle.Squares;

public sealed partial class Square
{
    #region CheckLetter

    /// <summary>
    /// Check for correctness of letter based on input char parameter and toggles colour accordingly
    /// </summary>
    /// <param name="correctLetter"></param>
    public void CheckLetter(char correctLetter)
    {
        if (Letter == ' ') return;
        ForeColour = Letter == correctLetter ? UiConstants.SqCorrect : UiConstants.SqError;
        IsDirty = true;
    }

    #endregion
}