using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHESSWPF
{
    class Piece
    {
        public string Name { get; set; }
        public bool White { get; set; }
        public bool Inplay { get; set; }
        public bool Moved { get; set; }
        public byte value { get; set; } // værdier fra wikipedia

        virtual public bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            return false;
        }


        private string symbol;

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }


        public string[] Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        private string[] icon = new string[3] { "      ", "      ", "      " };

        public Piece(bool white)
        {
            Inplay = true;
            Moved = false;
            White = white;
        }
    }

    class Empty : Piece
    {
        public Empty(bool white) : base(white)
        {
            Name = "Empty";
            value = 0;
            Symbol = "  ";
            Icon = new string[] { "      ", "      ", "      " };
        }
        public override bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            return false;
        }
    }

    class Peasent : Piece
    {
        public Peasent(bool white) : base(white)
        {
            Name = "Peasent";
            value = 1;
            Symbol = "\u2659\u265F";
            Icon = new string[] { "  ▄▄  ", "▀█▄▄█▀", " █▀▀█ " };
        }
        public override bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            // det er lidt rodet

            if (b[markedx, markedy].White && ((cursorx == markedx && cursory - markedy == 1) || cursorx == markedx && cursory - markedy == 2 && Moved == false) && b[cursorx, cursory].Name == "Empty")
                return true;
            else if (!b[markedx, markedy].White && ((cursorx == markedx && cursory - markedy == -1) || cursorx == markedx && cursory - markedy == -2 && Moved == false) && b[cursorx, cursory].Name == "Empty")
                return true;
            else if (b[markedx, markedy].White && Math.Abs(cursorx - markedx) == 1 && cursory - markedy == 1 && b[cursorx, cursory].Name != "Empty")
                return true;
            else if (!b[markedx, markedy].White && Math.Abs(cursorx - markedx) == 1 && cursory - markedy == -1 && b[cursorx, cursory].Name != "Empty")
                return true;
            else
                return false;
        }

    }
    class Tower : Piece
    {
        public Tower(bool white) : base(white)
        {
            Name = "Tower";
            value = 5;
            Symbol = "\u2656\u265C";
            Icon = new string[] { "█▄█▀▄█", " █▄▀█ ", "▄█▄██▄" };

        }
        // cursorens position, den valgte briks position, den valgte briks farve, brættet
        public override bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            bool unblocked = true;
            if (cursorx == markedx || cursory == markedy)
            {
                // hit detection
                if (cursorx > markedx)
                {
                    for (int i = markedx + 1; i < cursorx; i++)
                        if (b[i, cursory].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx < markedx)
                {
                    for (int i = cursorx + 1; i < markedx; i++)
                        if (b[i, cursory].Name != "Empty")
                            unblocked = false;
                }
                else if (cursory > markedy)
                {
                    for (int i = markedy + 1; i < cursory; i++)
                        if (b[cursorx, i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursory < markedy)
                {
                    for (int i = cursory + 1; i < markedy; i++)
                        if (b[cursorx, i].Name != "Empty")
                            unblocked = false;
                }
                return unblocked;
            }
            else
                return false;
        }

    }
    class Knight : Piece
    {
        public Knight(bool white) : base(white)
        {
            Name = "Knight";
            value = 3;
            Symbol = "\u2658\u265E";
            Icon = new string[] { " ▄    ", "██▄▄▄█", " █▀▀█ " };
        }
        public override bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            if ((Math.Abs(cursorx - markedx) == 1 && Math.Abs(cursory - markedy) == 2) || (Math.Abs(cursorx - markedx) == 2 && Math.Abs(cursory - markedy) == 1))
            {
                return true;

            }
            else
                return false;
        }
    }
    class Bishop : Piece
    {
        public Bishop(bool white) : base(white)
        {
            Name = "Bishop";
            value = 3;
            Symbol = "\u2657\u265D";
            Icon = new string[] { "  ██  ", "▀█▄▄█▀", " █▀█  " };
        }
        public override bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            bool unblocked = true;



            // der er fejl i nedenstående!!!
            if (Math.Abs(cursorx - markedx) == Math.Abs(cursory - markedy))
            {
                // hit detection
                if (cursorx > markedx && cursory > markedy) // ned mod højre
                {
                    for (int i = 1; i < cursorx - markedx; i++)
                        if (b[markedx + i, markedy + i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx > markedx && cursory < markedy) // op mod højre
                {
                    for (int i = 1; i < cursorx - markedx; i++)
                        if (b[markedx + i, markedy - i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx < markedx && cursory > markedy) // ned mod venstre
                {
                    for (int i = 1; i < markedx - cursorx; i++)
                        if (b[markedx - i, markedy + i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx < markedx && cursory < markedy) // op mod venstre
                {
                    for (int i = 1; i < markedx - cursorx; i++)
                        if (b[markedx - i, markedy - i].Name != "Empty")
                            unblocked = false;
                }
                return unblocked;
            }

            else
                return false;
        }
    }
    class Queen : Piece
    {
        public Queen(bool white) : base(white)
        {
            Name = "Queen";
            value = 9;
            Symbol = "\u2655\u265B";
            Icon = new string[] { " ▀██▀ ", " ▀██▀ ", "▄████▄" };
        }
        public override bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            bool unblocked = true;

            if (Math.Abs(cursorx - markedx) == Math.Abs(cursory - markedy))
            {
                return true;
            }
            else if (cursorx == markedx || cursory == markedy)
            {
                // hit detection
                if (cursorx > markedx)
                {
                    for (int i = markedx + 1; i <= cursorx; i++)
                        if (b[i, cursory].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx < markedx)
                {
                    for (int i = cursorx; i < markedx; i++)
                        if (b[i, cursory].Name != "Empty")
                            unblocked = false;
                }
                else if (cursory > markedy)
                {
                    for (int i = markedy + 1; i <= cursory; i++)
                        if (b[cursorx, i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursory < markedy)
                {
                    for (int i = cursory; i < markedy; i++)
                        if (b[cursorx, i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx > markedx && cursory > markedy) // ned mod højre
                {
                    for (int i = 1; i < cursorx - markedx; i++)
                        if (b[markedx + i, markedy + i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx > markedx && cursory < markedy) // op mod højre
                {
                    for (int i = 1; i < cursorx - markedx; i++)
                        if (b[markedx + i, markedy - i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx < markedx && cursory > markedy) // ned mod venstre
                {
                    for (int i = 1; i < markedx - cursorx; i++)
                        if (b[markedx - i, markedy + i].Name != "Empty")
                            unblocked = false;
                }
                else if (cursorx < markedx && cursory < markedy) // op mod venstre
                {
                    for (int i = 1; i < markedx - cursorx; i++)
                        if (b[markedx + i, markedy - i].Name != "Empty")
                            unblocked = false;
                }
                return unblocked;
            }
            else
                return false;
        }
    }
    class King : Piece
    {
        public King(bool white) : base(white)
        {
            Name = "King";
            value = 200;
            Symbol = "\u2654\u265A";   // rex
            Icon = new string[] { "█ ▄▄ █", " █▄▄█ ", " █▀▀█ " };
        }
        public override bool CheckMove(int cursorx, int cursory, int markedx, int markedy, Piece[,] b)
        {
            if (Math.Abs(cursorx - markedx) <= 1 && Math.Abs(cursory - markedy) <= 1)
                return true;
            else
                return false;

            /*
             * Her mangler der check for, at kongen ikke stiller sig selv skak
             *
             * Der mangler også Castling : når kongen og et tårn flytter
             * det kræver at kongen og tårnet ikke er flyttet før, at kongen ikke står skak
             * og at kongen ikke står skak på den nye position 
             */
        }
    }
}
