using Crossword.ClueAnswer;
using Crossword.InputHandlers;
using Crossword.PuzzleSquares;
using FontStashSharp;
using InputHandlers.Keyboard;
using InputHandlers.Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;

////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     crossword.cs                                          //
//      Authors:    Aaron Saikovski & Bryan Richards                      //
//      Date:       24/03/97                                              //
//      Purpose:    A crossword Applet based on the well known crossword. //
//                  Part of the OzEmail Cyber puzzles suite.              //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

namespace Crossword.App
{
    public sealed partial class CrosswordMain : Game
    {
        #region Fields       

        //Puzzle State machines
        private bool PuzzleFinished;
        private bool SetFinished;

        //Next Puzzle is currently unavailable flag
        private bool IsNextPuzzleReady = true;

        //String for Puzzle ID of last puzzle in set
        private string? PuzzleData;

        //Repaint variables
        private bool bBufferDirty;
        public bool InitCrossword;

        //Image imBackBuffer;
        private bool NewBackFlush;

        //Data set variables
        public string? PuzzleType;
        public int _NumCols, _NumRows, _NumAcross, _NumDown, _PuzzleId;
        private int[] _colRef, _rowRef, _quesNum;
        private bool[] _bDataIsAcross;
        private string[] _szClues, _szAnswers;
        private int[] _nCosts = [0, 0, 0, 0, 0, 0];
        private string? _szGetLetters;
        private string? _szTmpGetLetters;
        private string? _szBlurb;
        private int NumQuestions;

        //Puzzle Dataset instance
        private PuzzleState.PuzzleState[] _puzzleDataset;

        //Square instance variable
        private Square?[,] sqPuzzleSquares;

        //ClueAnswer Instance variable
        private ClueAnswerMap[] caPuzzleClueAnswers;

        //Highlight Constants
        private readonly int CurrentLetter = 1;
        private readonly int CurrentWord = 2;
        private readonly int CurrentNone = 3;

        //CrosswordMain.Application dimension constants
        private readonly int MaxCrossWidth = 291;
        private readonly int MaxCrossHeight = 291;

        //string[,] strGuesses = null;
        private Square? SqCurrentSquare;

        public bool IsFinished;

        //Square width and height constants
        private static readonly int SquareWidth;
        private static readonly int SquareHeight;

        //X and Y Offsets for the square's answer number.
        //private int NXnumOffset = 2, NYnumOffset = 9;


        //Status of row/column orientation (Across or Down)
        private bool IsAcross = true;

        //Mouse Coords
        public int NMouseX;
        public int NMouseY;

        //Tab key variable
        //private readonly int NTabPress;

        //Scoring variable
        //private int Score;


        //Component focus variable
        private int FocusState;

        //mouseMove String
        private readonly string PuzzleTitle;

        //Number of times Hint has been accessed by the user
        //int nUserHintPress;

        // CrosswordMain.Application score
        private int CrosswordScore;

        //More puzzles in set boolean flag
        private bool _bMorePuzzles;

        //Parser class
        private CrosswordParser.PuzzleData? _mrParserData;

        //Images to use forx CrosswordMain.Application squares
        private Texture2D _imgSquareWord;
        private Texture2D _imgHighliteSquare;
        private Texture2D _imgNormalSquare;
        private Texture2D _imgBlackSquare;


        //Link buttons
        private PuzzleButton _HintButton;
        private Texture2D _imgHintButton;
        
        private PuzzleButton _NextPuzzButton;
        private Texture2D _imgNextPuzzButton;
        
        //list boxes
        private ListBox LstClueAcross;
        private ListBox LstClueDown;

        //Panel for UI
        private Panel _mainPanel;


        //Puzzle squares
        private Rectangle[,]? _puzzleSquares;

        // Monogame graphics
        public readonly GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public Desktop _desktop;


        // Define a color for the rectangles
        private readonly Color _rectangleColor = Color.White;
        //private Color _rectangleBlack = Color.Black;
        private Texture2D _blackTexture;

        //Fonts
        private DynamicSpriteFont _fntnumFont;   //small number font
        private DynamicSpriteFont _fntFont;      //Char entered by user.
        private DynamicSpriteFont _fntScore;     //CrosswordMain.Application score
        private DynamicSpriteFont _fntListhead;  //Across/Down listbox Headers
        private DynamicSpriteFont _fntListFont;  // ListBox font


        //Keyboard handler
        private readonly KeyboardInput _keyboardInput;
        private readonly KeyboardInputHandler _keyboardInputHandler;

        //Mouse handler
        private readonly MouseInput _mouseInput;
        private readonly MouseInputHandler _mouseInputHandler;

        //Labels
        private Label _currentScoreLabel;
        private Label _maxScoreLabel;
        private Label _clueAcrossLabel;
        private Label _clueDownLabel;

        //CrosswordMain.Application Rectangles for mouse handling
        //Rectangle variable
        public Rectangle rectCrossWord;

        //Hint LinkButton
        private TextButton HintButton;

        //Get Next Puzzle LinkButton
        private TextButton GetNextPuzzleButton;


        //CrosswordMain.Application Width and Height variables
        private int _nCrosswordWidth;
        private int _nCrosswordHeight;
        private readonly int _nCrosswordOffset = 6;

        //Offset constants
        private readonly int _nCrossBorderWidth = 3;
        private int nCrossOffsetX = 5;
        private int nCrossOffsetY = 5;

        #endregion

        #region main_constructor
        // Main crossword constructor
        public CrosswordMain()
        {
            //Prepare Graphics
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Keyboard handlers
            _keyboardInput = new KeyboardInput();
            _keyboardInputHandler = new KeyboardInputHandler(this); //Pass in crossword instance object
            _keyboardInput.Subscribe(_keyboardInputHandler);

            //Mouse handlers
            _mouseInput = new MouseInput();
            _mouseInputHandler = new MouseInputHandler(this); //Pass in crossword instance object
            _mouseInput.Subscribe(_mouseInputHandler);
        }
        #endregion

    }
}