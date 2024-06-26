using System;
using Crossword.Shared.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region DrawUserChar

    /// <summary>
    /// Draws char entered by user
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void DrawUserChar(int i, int j)
    {
        try
        {
            _logger.LogInformation("Start DrawUserChar()");

            //check for null
            if (_puzzleSquares != null && _sqPuzzleSquares != null)
            {
                //Char entered by user.
                _spriteBatch.DrawString(_fntFont, char.ToUpper(_sqPuzzleSquares[i, j].Letter).ToString(),
                    new Vector2(_puzzleSquares[i, j].X + UiConstants.SqCharOffsetX,
                        _puzzleSquares[i, j].Y + UiConstants.SqCharOffsetY),
                    _sqPuzzleSquares[i, j].ForeColour);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}