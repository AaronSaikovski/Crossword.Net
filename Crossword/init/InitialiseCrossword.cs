using System;
using Crossword.Puzzle.ClueAnswerMap;
using Crossword.Puzzle.Squares;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitialiseCrossword
    /// <summary>
    /// Builds the crossword objects
    /// </summary>
    private void InitialiseCrossword()
    {
        try
        {
            _logger.LogInformation("Start BuildCrossword()");

            //Init squares
            _sqPuzzleSquares = new Square[_NumRows, _NumCols];
            _puzzleSquares = new Rectangle[_NumRows, _NumCols];

            //Init ClueAnswers
            _caPuzzleClueAnswers = new ClueAnswer[_numQuestions];

            //Initialise the arrays
            InitArrays();

            //Init the ClueAnswers
            InitClueAnswers();

            _initCrossword = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion
}