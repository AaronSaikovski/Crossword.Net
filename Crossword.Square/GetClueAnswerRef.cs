using Crossword.ClueAnswerMap;

namespace Crossword.Square;

public sealed partial class Square
{
    #region GetClueAnswerRef

    /// <summary>
    /// returns the Clue/Answer reference
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public ClueAnswer? GetClueAnswerRef(bool isAcross)
    {
        return isAcross ? ClueAnswerAcross : ClueAnswerDown;
    }

    #endregion
}