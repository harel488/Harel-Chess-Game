using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Chess_Game.Util;

/// <summary>
/// CHESS-GAME
/// </summary>
/// <author> Harel Isaschar </author>
namespace Chess_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Piece prev;
        Piece next;

        Brush prev_squareColor;

        Board board;

        PIECE_COLOR turn;

        int BkingX, BkingY, WkingX, WkingY; //places of the kings to know about chess

        public MainWindow()
        {
            InitializeComponent();

            Create_UIboard();
        }

        /// <summary>
        /// initalize the UI board for start new game.
        /// </summary>
        private void Create_UIboard()
        {
            board = new Board();
            turn = PIECE_COLOR.white;
            turnLabel.Content = "TURN: WHITE";
            turnLabel.Foreground = Brushes.Black;
            restartBut.Visibility = Visibility.Hidden;
            winLabel.Visibility = Visibility.Hidden;

            //initalize the coordinates of the kings to know about chesses
            BkingX = 7;
            BkingY = 4;
            WkingX = 0;
            WkingY = 4;

            prev = null;
            next = null;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece butt = new Piece();
                    butt.Width = 50;
                    butt.Height = 50;
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            butt.Background = Brushes.White;
                        else
                            butt.Background = Brushes.Brown;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            butt.Background = Brushes.Brown;
                        else
                            butt.Background = Brushes.White;
                    }

                    if (j == 1)
                    {
                        Image im = new Image();
                        im.Width = 30;
                        im.Height = 30;
                        im.Source = new BitmapImage(new Uri("pack://application:,,,/images/pawnW.png"));
                        butt.Content = im;
                        butt._type = PIECE_TYPE.pawn;
                        butt._color = PIECE_COLOR.white;
                    }

                    else if (j == 6)
                    {
                        Image im = new Image();
                        im.Width = 30;
                        im.Height = 30;
                        im.Source = new BitmapImage(new Uri("pack://application:,,,/images/pawnB.png"));
                        butt.Content = im;
                        butt._type = PIECE_TYPE.pawn;
                        butt._color = PIECE_COLOR.black;
                    }

                    else if (j == 0)
                    {
                        if (i == 0 || i == 7)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/rookW.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.rook;
                            butt._color = PIECE_COLOR.white;

                        }
                        if (i == 1 || i == 6)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/knightW.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.knight;
                            butt._color = PIECE_COLOR.white;
                        }
                        if (i == 2 || i == 5)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/bishopW.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.bishop;
                            butt._color = PIECE_COLOR.white;
                        }
                        if (i == 3)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/queenW.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.queen;
                            butt._color = PIECE_COLOR.white;
                        }
                        if (i == 4)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/kingW.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.king;
                            butt._color = PIECE_COLOR.white;
                        }
                    }

                    else if (j == 7)
                    {
                        if (i == 0 || i == 7)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/rookB.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.rook;
                            butt._color = PIECE_COLOR.black;
                        }
                        if (i == 1 || i == 6)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/knightB.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.knight;
                            butt._color = PIECE_COLOR.black;
                        }
                        if (i == 2 || i == 5)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/bishopB.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.bishop;
                            butt._color = PIECE_COLOR.black;
                        }
                        if (i == 3)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/queenB.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.queen;
                            butt._color = PIECE_COLOR.black;
                        }
                        if (i == 4)
                        {
                            Image im = new Image();
                            im.Width = 30;
                            im.Height = 30;
                            im.Source = new BitmapImage(new Uri("pack://application:,,,/images/kingB.png"));
                            butt.Content = im;
                            butt._type = PIECE_TYPE.king;
                            butt._color = PIECE_COLOR.black;
                        }
                    }
                    else
                    {
                        butt._type = PIECE_TYPE.empty;
                        butt._color = PIECE_COLOR.empty;
                    }

                    myCanvas.Children.Add(butt);
                    Canvas.SetLeft(butt, i * 50);
                    Canvas.SetTop(butt, j * 50);
                    butt.Click += MovePiece;
                }
            }
        }
        //******************************************************************************************************************
        /// <summary>
        /// event of Clicking on button of piece.
        /// The function defines the previous piece and the next piece 
        /// and moves the pieces on the board according to the rules
        /// </summary>
        /// <param name="sender">The piece button pressed by the user </param>
        /// <param name="e"></param>
        private void MovePiece(object sender, RoutedEventArgs e)
        {
            if (prev == null)
            {
                prev = sender as Piece;
                prev_squareColor = prev.Background;
                prev.Background = Brushes.Green;  //mark the chossen piece
            }
            else
            {
                next = sender as Piece;
                
                //getting the coordinates of the pieces
                int xp = (int)Canvas.GetTop(prev) / 50;
                int yp = (int)Canvas.GetLeft(prev) / 50;
                int xn = (int)Canvas.GetTop(next) / 50;
                int yn = (int)Canvas.GetLeft(next) / 50;
             
                if (!prev.Equals(next) && turn == prev._color && prev._color != next._color && isLegalMove(xp, yp, xn, yn, prev._type))
                {
                    Board tempBoard = new Board(board);
                    board._board[xn, yn] = board._board[xp, yp];  //making background move
                    board._board[xp, yp] = 0;

                    if (turn == PIECE_COLOR.white)
                    {
                        //temps for the place of the king, If there is still a state of chess
                        int wxt = WkingX;
                        int wyt = WkingY;
                        if (prev._type == PIECE_TYPE.king) // changing the place of the king
                        {
                            WkingX = xn;
                            WkingY = yn;
                        }

                        if (isCheck(0))
                        {
                            WkingX = wxt;
                            WkingY = wyt;
                            board = new Board(tempBoard);
                            prev.Background = prev_squareColor;
                        }
                        else   //making foreground move 
                        {
                            turnLabel.Foreground = Brushes.Black; //return the color of the turn label to black
                            next.Content = prev.Content; //image
                            next._type = prev._type;
                            next._color = prev._color;
                            prev._color = PIECE_COLOR.empty;
                            prev._type = PIECE_TYPE.empty;
                            prev.Content = ' ';
                            turn = PIECE_COLOR.black;
                            turnLabel.Content = "TURN: BLACK";
                        }

                    }
                    else
                    {
                        //temps for the place of the king, If there is still a state of chess
                        int bxt = BkingX;
                        int byt = BkingY;
                        if (prev._type == PIECE_TYPE.king) // changing the place of the king
                        {
                            BkingX = xn;
                            BkingY = yn;
                        }

                        if (isCheck(1))
                        {
                            BkingX = bxt;
                            BkingY = byt;
                            board = new Board(tempBoard);
                            prev.Background = prev_squareColor;
                        }
                        else  //making foreground move 
                        {
                            turnLabel.Foreground = Brushes.Black;
                            next.Content = prev.Content; //image
                            next._type = prev._type;
                            next._color = prev._color;
                            prev._color = PIECE_COLOR.empty;
                            prev._type = PIECE_TYPE.empty;
                            prev.Content = ' ';
                            turn = PIECE_COLOR.white;
                            turnLabel.Content = "TURN: WHITE";
                        }
                    }
                }

                prev.Background = prev_squareColor;
                prev = null;

                //************* checking if chess mode is on, then checking if there is a Matt and go to gameOver method*******

                if (isCheck(1))
                {
                    turnLabel.Foreground = Brushes.Red; //Painting the label in red while chess
                    if (isMatt(1))
                    {
                        GameOver(0);
                    }

                }
                if (isCheck(0))
                {
                    turnLabel.Foreground = Brushes.Red;
                    if (isMatt(0))
                    {
                        GameOver(1);
                    }
                }              
            }
        }

        /// <summary>
        /// checking if move is legal according to the piece type
        /// also checking if there is no another piece with the same color
        /// between the previous to the next
        /// </summary>
        /// <param name="xp">xp is the coordinate X of the previous piece</param>
        /// <param name="yp">yp is the coordinate Y of the previous piece</param>
        /// <param name="xn">xn is the coordinate X of the next piece</param>
        /// <param name="yn">yn is the coordinate Y of the next piece</param>
        /// <param name="type"></param>
        /// <returns>true if legal move | else: false</returns>
        private bool isLegalMove(int xp, int yp, int xn, int yn, PIECE_TYPE type)
        {
            switch (type)
            {
                case PIECE_TYPE.empty:
                    break;
                case PIECE_TYPE.rook:
                    if (xp == xn)
                    {
                        for (int i = Math.Min(yn, yp) + 1; i < Math.Max(yn, yp); i++)
                        {
                            if (board._board[xp, i] != 0)
                                return false;
                        }
                        return true;
                    }
                    if (yp == yn)
                    {
                        for (int i = Math.Min(xn, xp) + 1; i < Math.Max(xn, xp); i++)
                        {
                            if (board._board[i, yp] != 0)
                                return false;
                        }
                        return true;
                    }

                    break;
                case PIECE_TYPE.knight:
                    if ((Math.Abs(xn - xp) == 2 && Math.Abs(yn - yp) == 1) || (Math.Abs(xn - xp) == 1 && Math.Abs(yn - yp) == 2))
                        return true;
                    break;
                case PIECE_TYPE.bishop:
                    if (Math.Abs(xn - xp) == Math.Abs(yn - yp))
                    {
                        int i = xp < xn ? xp + 1 : xp - 1;
                        int j = yp < yn ? yp + 1 : yp - 1;
                        while (i != xn && j != yn)
                        {
                            if (board._board[i, j] != 0)
                                return false;

                            i = xn > xp ? i + 1 : i - 1;
                            j = yn > yp ? j + 1 : j - 1;
                        }
                        return true;
                    }
                    break;
                case PIECE_TYPE.queen:
                    if (xp == xn)
                    {
                        for (int i = Math.Min(yn, yp) + 1; i < Math.Max(yn, yp); i++)
                        {
                            if (board._board[xp, i] != 0)
                                return false;
                        }
                        return true;
                    }
                    if (yp == yn)
                    {
                        for (int i = Math.Min(xn, xp) + 1; i < Math.Max(xn, xp); i++)
                        {
                            if (board._board[i, yp] != 0)
                                return false;
                        }
                        return true;
                    }
                    if (Math.Abs(xn - xp) == Math.Abs(yn - yp))
                    {
                        int i = xp < xn ? xp + 1 : xp - 1;
                        int j = yp < yn ? yp + 1 : yp - 1;
                        while (i != xn && j != yn)
                        {
                            if (board._board[i, j] != 0)
                                return false;

                            i = xn > xp ? i + 1 : i - 1;
                            j = yn > yp ? j + 1 : j - 1;
                        }
                        return true;
                    }
                    break;
                case PIECE_TYPE.king:
                    if ((Math.Abs(xp - xn) == 1 && yp == yn) || (Math.Abs(yp - yn) == 1 && xp == xn) || (Math.Abs(xp - xn) == 1 && Math.Abs(yp - yn) == 1))
                        return true;
                    break;
                case PIECE_TYPE.pawn:
                    if (board._board[xp, yp] > 0) // if turn is white
                    {
                        if (((xn - xp == 1) || (xn - xp == 2 && xp == 1)) && yp == yn && board._board[xn, yn] == 0)
                            return true;
                        if (xn - xp == 1 && Math.Abs(yn - yp) == 1 && board._board[xn, yn] < 0) // If there is an enemy diagonally
                            return true;
                    }
                    else //if turn is black
                    {
                        if (((xp - xn == 1) || (xp - xn == 2 && xp == 6)) && yp == yn && board._board[xn, yn] == 0)
                            return true;
                        if (xp - xn == 1 && Math.Abs(yn - yp) == 1 && board._board[xn, yn] > 0) // If there is an enemy diagonally
                            return true;
                    }
                    break;
                default:
                    return false;
                    break;
            }
            return false;
        }

        /// <summary>
        /// checking if the king is in chess mode.
        /// foreach  piece the function check if there is a legal move from
        /// the enemy piece to the king. 
        /// </summary>
        /// <param name="col">color of king that checking the check on , white=0, black=1</param>
        /// <returns>true if chess| else: false</returns>
        public bool isCheck(int col)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (col == 0) //white check
                    {
                        if (board._board[i, j] < 0)
                        {
                            if (isLegalMove(i, j, WkingX, WkingY, (PIECE_TYPE)Math.Abs(board._board[i, j])))
                            {
                                return true;
                            }
                        }
                    }
                    else // black check
                    {
                        if (board._board[i, j] > 0)
                        {
                            if (isLegalMove(i, j, BkingX, BkingY, (PIECE_TYPE)Math.Abs(board._board[i, j])))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// checking if king is on matt
        /// for each piece- try to move the current piece to any legal place
        /// then check- if isChess() then return false.
        /// if there is not legal moves that disabled the chess- king is in matt mode.    
        /// </summary>
        /// <param name="col">color of king that checking the matt on , white=0, black=1</param>
        /// <returns>true if matt| else: false</returns>
        public bool isMatt(int col)
        {
            int xt = col == 0 ? WkingX : BkingX;
            int yt = col == 0 ? WkingY : BkingY;

            bool matt = true;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (col == 0) //white matt
                    {
                        if (board._board[i, j] > 0)
                        {
                            for (int r = 0; r < 8; r++)
                            {
                                for (int c = 0; c < 8; c++)
                                {
                                    if ((i != r || j != c) && board._board[r, c] <= 0 && isLegalMove(i, j, r, c, (PIECE_TYPE)board._board[i, j]))
                                    {
                                        Board tmp = new Board(board);
                                        board._board[r, c] = board._board[i, j];
                                        board._board[i, j] = 0;
                                        if ((PIECE_TYPE)(board._board[r, c]) == PIECE_TYPE.king)
                                        {
                                            WkingX = r;
                                            WkingY = c;
                                        }
                                        if (!isCheck(0))
                                        {
                                            matt = false;
                                        }
                                        board = new Board(tmp);
                                        WkingX = xt;
                                        WkingY = yt;
                                    }
                                }
                            }
                        }
                    }
                    else //black matt
                    {
                        if (board._board[i, j] < 0)
                        {
                            for (int r = 0; r < 8; r++)
                            {
                                for (int c = 0; c < 8; c++)
                                {
                                    if ((i != r || j != c) && board._board[r, c] >= 0 && isLegalMove(i, j, r, c, (PIECE_TYPE)Math.Abs(board._board[i, j])))
                                    {
                                        Board tmp = new Board(board);
                                        board._board[r, c] = board._board[i, j];
                                        board._board[i, j] = 0;
                                        if ((PIECE_TYPE)(board._board[r, c] * -1) == PIECE_TYPE.king)
                                        {
                                            BkingX = r;
                                            BkingY = c;
                                        }
                                        if (!isCheck(1))
                                        {
                                            matt = false;
                                        }
                                        board = new Board(tmp);
                                        BkingX = xt;
                                        BkingY = yt;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return matt;
        }

        /// <summary>
        /// ending the game -Announces the winner
        /// </summary>
        /// <param name="win">winner color</param>
        public void GameOver(int win)
        {
            restartBut.Visibility = Visibility.Visible;
            winLabel.Visibility = Visibility.Visible;
            turnLabel.Foreground = Brushes.Red;
            turnLabel.Content = "GAME-OVER";         
            if (win == 0)
            {
                winLabel.Content = "WINNER IS: WHITE";
            }
            else
            {
                winLabel.Content = "WINNER IS: BLACK";
            }

        }

        private void RestartBut_Click(object sender, RoutedEventArgs e)
        {
            Create_UIboard();
        }      
        
    }
}
