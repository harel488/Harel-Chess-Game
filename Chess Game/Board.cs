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

namespace Chess_Game
{
    public class Board
    {
       public int[, ] _board;
       

        public Board()
        {
            _board = new int[8, 8] { { 1,2,3,4,5,3,2,1},
                                     { 6,6,6,6,6,6,6,6},
                                     { 0,0,0,0,0,0,0,0},
                                     { 0,0,0,0,0,0,0,0},
                                     { 0,0,0,0,0,0,0,0},
                                     { 0,0,0,0,0,0,0,0},
                                     { -6,-6,-6,-6,-6,-6,-6,-6},
                                     { -1,-2,-3,-4,-5,-3,-2,-1} };
        }

        public Board(Board board)
        {
            _board = new int[8, 8];

            for (int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    _board[i, j] = board._board[i, j];
                }
        }
    }

   
}
