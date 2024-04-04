using System;
using Crossword.Shared.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region DrawSmallFont

    /// <summary>
    /// Draws small font Across
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void DrawSmallFontAcross(int i, int j)
    {
        try
        {
            logger.LogInformation("Start DrawSmallFontAcross()");
            if (sqPuzzleSquares[i, j]?.ClueAnswerAcross is null) return;
            if (sqPuzzleSquares[i, j]?.ClueAnswerAcross?.SqAnswerSquares?[0] != sqPuzzleSquares[i, j]) return;
            if (_puzzleSquares is not null)
                _spriteBatch.DrawString(_fntnumFont,
                    sqPuzzleSquares[i, j]?.ClueAnswerAcross?.QuestionNumber.ToString(),
                    new Vector2(_puzzleSquares[i, j].X + UIConstants.SmlNumOffsetX,
                        _puzzleSquares[i, j].Y + UIConstants.SmlNumOffsetY), UIConstants.SmallFontColor);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
    
    // private void DrawSmallFontAcross(SpriteBatch spriteBatch, Square sqPuzzleSquare, Rectangle? puzzleSquare)
    // {
    //     try
    //     {
    //         //logger.LogInformation("Start DrawSmallFontAcross()");
    //         if (sqPuzzleSquare.ClueAnswerAcross is null) return;
    //         if (sqPuzzleSquare.ClueAnswerAcross?.SqAnswerSquares?[0] != sqPuzzleSquare) return;
    //         if (puzzleSquare is not null)
    //             spriteBatch.DrawString(_fntnumFont,
    //                 sqPuzzleSquare.ClueAnswerAcross?.QuestionNumber.ToString(),
    //                 new Vector2(puzzleSquare.X + UIConstants.SmlNumOffsetX,
    //                     puzzleSquare.Y + UIConstants.SmlNumOffsetY), UIConstants.SmallFontColor);
    //     }
    //     catch (Exception ex)
    //     {
    //         logger.LogError(ex, ex.Message);
    //         throw;
    //     }
    // }

    /// <summary>
    /// Draws small font Down
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void DrawSmallFontDown(int i, int j)
    {
        try
        {
            logger.LogInformation("Start DrawSmallFontDown()");

            if (sqPuzzleSquares?[i, j].ClueAnswerDown is null) return;
            if (sqPuzzleSquares?[i, j].ClueAnswerDown?.SqAnswerSquares?[0] != sqPuzzleSquares[i, j]) return;
            _spriteBatch.DrawString(_fntnumFont,
                sqPuzzleSquares[i, j]?.ClueAnswerDown?.QuestionNumber.ToString(),
                new Vector2(_puzzleSquares[i, j].X + UIConstants.SmlNumOffsetX,
                    _puzzleSquares[i, j].Y + UIConstants.SmlNumOffsetY), UIConstants.SmallFontColor);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}