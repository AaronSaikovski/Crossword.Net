using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    #region 
    /// <summary>
    /// GetAnswers
    /// </summary>
    /// <param name="strData"></param>
    private void GetAnswers(IReadOnlyList<string> strData)
    {
        string puzzletempstr;
        string[] answertemp;
        puzzletempstr = strData[5];
        answertemp = puzzletempstr.Split("#");
        _crosswordData.Answers = new string[_crosswordData.NumQuestions];
        for (var k = 0; k < _crosswordData.NumQuestions; k++)
        {
            _crosswordData.Answers[k] = answertemp[k];
        }
    }
    #endregion
}