using System;
using Crossword.Shared.Constants;
using Myra.Graphics2D.UI;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region InitListBoxes
    /// <summary>
    /// Inits Listboxes
    /// </summary>
    private void InitListBoxes()
    {
        try
        {
            _logger.LogInformation("Start InitListBoxes()");
            
            //List box elements

            //List box across
            InitListBoxAcross();

            //List box down
            InitListBoxDown();

            //Populate and add lists
            _mainPanel.Widgets.Add(_clueAcrossLabel);
            _mainPanel.Widgets.Add(LstClueAcross);
            _mainPanel.Widgets.Add(_clueDownLabel);
            _mainPanel.Widgets.Add(LstClueDown);
            LstClueAcross.SelectedIndex = 0;
            LstClueDown.SelectedIndex = -1;
            LstClueAcross.Visible = false;
            LstClueDown.Visible = false;
        
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }

    #endregion

    #region InitListBoxDown
    /// <summary>
    /// Init listbox - Down 
    /// </summary>
    private void InitListBoxDown()
    {
        try
        {
            _logger.LogInformation("Start InitListBoxDown()");
            
            //Down Label
            _clueDownLabel = new Label
            {
                Text = "Clues Down",
                Font = _fntListhead,
                Left = rectCrossWord.Right + CWSettings.MainOffsetX,
                TextColor = CWSettings.ListBoxTextColor,
                Height = CWSettings.ClLabelHeight,
                Top = CWSettings.ClListboxHeight + CWSettings.ClLabelHeight + CWSettings.ClListSpacer * 3
            };

            //Down
            LstClueDown = new ListBox
            {
                Left = rectCrossWord.Right + CWSettings.MainOffsetY,
                Top = CWSettings.ClListboxHeight + CWSettings.ClLabelHeight + CWSettings.ClListSpacer * 2 +
                      CWSettings.ClLabelHeight,
                AcceptsKeyboardFocus = true,
                SelectionMode = SelectionMode.Single,
                Height = CWSettings.ClListboxHeight
            };

            //set the font
            LstClueDown.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

            //List box event handlers
            //LstClueDown.SelectedIndexChanged += SelChangeListClueDown;
        
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion

    #region InitListBoxAcross
    /// <summary>
    /// Init listbox - Across 
    /// </summary>
    private void InitListBoxAcross()
    {
        try
        {
            _logger.LogInformation("Start InitListBoxAcross()");
            
            //Across Label
            _clueAcrossLabel = new Label
            {
                Text = "Clues Across",
                Font = _fntListhead,
                Left = rectCrossWord.Right + CWSettings.MainOffsetX,
                TextColor = CWSettings.ListBoxTextColor,
                Height = CWSettings.ClLabelHeight,
                Top = CWSettings.MainOffsetY - CWSettings.ClListSpacer * 3
            };

            //Across ListBox
            LstClueAcross = new ListBox
            {
                Left = rectCrossWord.Right + CWSettings.MainOffsetX,
                Top = CWSettings.MainOffsetY,
                AcceptsKeyboardFocus = true,
                SelectionMode = SelectionMode.Single,
                Height = CWSettings.ClListboxHeight
            };

            //set the font
            LstClueAcross.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

            //List box event handlers
            //LstClueAcross.SelectedIndexChanged += SelChangeListClueAcross;
        
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion

}