using System;
using System.Windows;
using System.Windows.Controls;

// dette er en pull test

namespace CHESSWPF
{
    class Game
    {
        public static int turns = 0;
        public static bool whiteStarts = true;
        public static bool whitesTurn = false;
        public static bool picked = false;
        public static bool exit = false;
        public static bool promote = false;

        private static int promotionNumber;

        public static int PromotionNumber
        {
            get { return promotionNumber; }
            set {
                if (value >= 3)
                    promotionNumber = 0;
                else if (value < 0)
                    promotionNumber = 3;
                else
                    promotionNumber = value; 
                }
        }

        static Piece[] catelog = { new Bishop(true), new Tower(true), new Knight(true) , new Queen(true) };

        public static Piece[] Catelog
        {
            get { return catelog;  }
            set { catelog = value; }
        }

        static public void Initialize()
        {
            Player player1 = new Player();
            player1.White = true;
            Player player2 = new Player();
            player2.White = false;

            if (whiteStarts)
                whitesTurn = true;

        }

        static public void Input(Board ind)
        {

            /*
            ConsoleKeyInfo input;
            input = default(ConsoleKeyInfo);

            input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    ind.CursorPositionY--;
                    PromotionNumber--;
                    break;
                case ConsoleKey.DownArrow:
                    ind.CursorPositionY++;
                    PromotionNumber++;
                    break;
                case ConsoleKey.LeftArrow:
                    ind.CursorPositionX--;
                    break;
                case ConsoleKey.RightArrow:
                    ind.CursorPositionX++;
                    break;
                case ConsoleKey.Spacebar:
                    ind.Pick();
                    promote = true;
                    break;
                case ConsoleKey.Enter:
                    ind.Move(ind.CursorPositionX, ind.CursorPositionY, ind.MarkedPieceX, ind.MarkedPieceY);
                    break;
                case ConsoleKey.Escape:
                    Game.exit = true;
                    break;
            }
            */
        }
        static public void turn()
        {
            // skal køres hver tur

            // turskifte
            Game.whitesTurn = Game.whitesTurn == true ? false : true;
            Game.turns++;

            // sørg for at ingen brik er valgt
            Game.picked = false;

            // tjekker om en konge står skak

            if (Game.turns > 1)
                Program.Board1.Check();
                    
        }
    }
}
