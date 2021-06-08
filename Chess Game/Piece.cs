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
    class Piece : Button
    {
        public PIECE_TYPE _type;
        public PIECE_COLOR _color;


        public Piece(PIECE_TYPE t, PIECE_COLOR c)
        {
            _type = t;
            _color = c;
        }

        public Piece()
        {
            _type =  PIECE_TYPE.empty;
            _color = PIECE_COLOR.empty;
        }

        public bool Equals(Piece p)
        {
            return p != null &&
                   _type == p._type &&
                   _color == p._color;
        }
    }
}
