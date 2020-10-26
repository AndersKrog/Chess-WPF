using System;
using System.Windows;
using System.Windows.Controls;

namespace CHESSWPF
{
    class Board
    {
        private int cursorPositionX;

        public int CursorPositionX
        {
            get { return cursorPositionX; }
            set
            {
                if (value > 7)
                    cursorPositionX = 0;
                else if (value < 0)
                    cursorPositionX = 7;
                else
                    cursorPositionX = value;
            }
        }

        private int cursorPositionY;

        public int CursorPositionY
        {
            get { return cursorPositionY; }
            set
            {
                if (value > 7)
                    cursorPositionY = 0;
                else if (value < 0)
                    cursorPositionY = 7;
                else
                    cursorPositionY = value;
            }
        }

        public int MarkedPieceX { get; set; }
        public int MarkedPieceY { get; set; }

        private Piece[,] onboard = new Piece[8, 8];

        public Piece[,] Onboard
        {
            get { return onboard; }
            set { onboard = value; }
        }


        public Board()
        {
            // set brikkerne på pladen
            
            onboard = new Piece[,]
            {
            {new Tower(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new Tower(false)},
            {new Knight(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new Knight(false)},
            {new Bishop(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new Bishop(false)},
            {new King(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new Queen(false)},
            {new Queen(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new King(false)},
            {new Bishop(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new Bishop(false)},
            {new Knight(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new Knight(false)},
            {new Tower(true),new Peasent(true),new Empty(true),new Empty(true),new Empty(true),new Empty(true),new Peasent(false),new Tower(false) },
            };

            /*
            onboard = new Piece[,]
            {
                { new Tower(true), new Knight(true), new Bishop(true), new King(true), new Queen(true), new Bishop(true), new Knight(true), new Tower(true) },
                { new Peasent(true), new Peasent(true), new Peasent(true), new Peasent(true), new Peasent(true), new Peasent(true), new Peasent(true), new Peasent(true)},
                { new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true)},
                { new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true)},
                { new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true)},
                { new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true), new Empty(true)},
                { new Peasent(false), new Peasent(false), new Peasent(false), new Peasent(false), new Peasent(false), new Peasent(false), new Peasent(false), new Peasent(false)},
                { new Tower(false), new Knight(false), new Bishop(false), new Queen(false), new King(false), new Bishop(false), new Knight(false), new Tower(false)}
            };
            */


        }

        public bool Check() // Burde virke
        {
            // står kongen skak? metoden skal kaldes i starten af hver tur

            // men der skal være en lignende metode på kongen, som forhindrer ham i at stille sig skak.

            /*
                koncept 1:
                kan man kalde på de forskellige brikkers checkmove?
                fx kongen flytter som en rider, og den kan slå en rider af modsat farve, så kan den rider slå kongen 
                Det kræver dog at checkmate metoderne er statiske, da det er lidt bøvlet at kalde dem fra objekter

                koncept 2:
                alle brikker af modsat farve tjekker om de kan slå kongen
                kræver flere tjek end koncept 1
             */

            // koncept 2:

            bool Check = false;

            int kingposX = -1;
            int kingPosY = -1;

            //find kongens position ikke optimal
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    if (Onboard[x, y].Name == "King" && Onboard[x, y].White == Game.whitesTurn)
                    {
                        kingposX = x;
                        kingPosY = y; 
                    }

            // MessageBox.Show($"din konge {kingposX} {kingPosY} ");

            // der er noget i vejen her??
            
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    if (Onboard[x, y].Name != "Empty" && (Onboard[x, y].White != Game.whitesTurn))    // vi er ligeglade med de tomme felter og brikken skal være modstanderens
                    {
                        if (Onboard[x, y].CheckMove(kingposX, kingPosY, x, y, Onboard))
                            Check = true;
                    }
           
            if (Check)
            {
                if (Game.whitesTurn)
                    MessageBox.Show($"Hvid spiller din konge {kingposX} {kingPosY} står skak");
                else
                    MessageBox.Show($"Sort spiller din konge {kingposX} {kingPosY} står skak");
            }
                

            return Check;
        }
        public void CheckMate()
        {
            // står kongen skakmat, metoden skal kun kaldes når kongen står skak
            // måske skal den bygges sammen med Check


            // 1. kan kongen rykke sig fri?
            // 2. kan en brik stille sig imellem kongen og den brik der truer kongen?
            // 3. kan en brik slå den brik der stiller kongen skak? // dette kan gøres på samme måde som check-metoden
            // hvis ovenstående er usande er kongen skakmat

        }
        public void StaleMate()
        {
            // når spillet er låst fast, og ingen vinder.
            // ved ikke præcist hvordan det skal fungere, eller hvornår den skal kaldes
        }

        public void Pick(int MouseposX, int MouseposY)
        {
            // MessageBox.Show(Convert.ToString(MouseposX)+ " " +Convert.ToString(MouseposY));

            if (Onboard[MouseposX, MouseposY].White == Game.whitesTurn && Onboard[MouseposX, MouseposY].Name != "Empty") // vælg kun egne brikker
            {
                MarkedPieceX = MouseposX;
                MarkedPieceY = MouseposY;
                Game.picked = Game.picked == true ? false : true;
            }
        }

        public void Move(int MouseposX, int MouseposY)
        {

            if (Game.picked == true)
            {
                if (Onboard[MarkedPieceX, MarkedPieceY].CheckMove(MouseposX, MouseposY, MarkedPieceX, MarkedPieceY, Onboard))
                {
                    if (Onboard[MarkedPieceX, MarkedPieceY].White != Onboard[MouseposX, MouseposY].White || Onboard[MouseposX, MouseposY].Name == "Empty")
                    {
                        Onboard[MarkedPieceX, MarkedPieceY].Moved = true;

                        var temp = Onboard[MouseposX, MouseposY];

                        Onboard[MouseposX, MouseposY] = Onboard[MarkedPieceX, MarkedPieceY];

                        if (Onboard[MouseposX, MouseposY].Name == "Empty")
                            Onboard[MarkedPieceX, MarkedPieceY] = temp;
                        else
                            Onboard[MarkedPieceX, MarkedPieceY] = new Empty(true);

                        // hvis en bonde er flyttet til enden af brættet
                        if (Onboard[MouseposX, MouseposY].Name == "Peasent" && MouseposY == 7 || MouseposY == 0)
                        {
                            Promotion(MouseposX, MouseposY);
                        }

                        // Der er foretaget et træk => næste tur
                        Game.turn();
                    }
                }
            }
        }

        public void Promotion(int peasantX, int peasantY)
        {

            //når en bonde når den modsatte kant
            // der skal være en metode der lader spilleren vælge brik, men bare for test:

            Game.promote = false;

            // burde nok være dynamisk i forhold til spillepladens placering på skærmen
            int xtop = 5;
            int yleft = 0;

            do
            {
                for (int i = 0; i <= 2; i++)
                {
                    // menu optimalt set, bør denne nok være i Drawinfo
                    Console.SetCursorPosition(75, i + 3);
                    Console.Write(Game.Catelog[Game.PromotionNumber].Icon[i]);

                    // på brættet
                    Console.SetCursorPosition(peasantX * 6 + xtop, i + 3 * peasantY + yleft);
                    Console.Write(Game.Catelog[Game.PromotionNumber].Icon[i]);
                }


                //DrawInfo(65, 0);

                Game.Input(Program.Board1);

            } while (Game.promote == false);

            switch (Game.PromotionNumber)
            {
                case 0:
                    Onboard[peasantX, peasantY] = new Bishop(Game.whitesTurn);
                    break;
                case 1:
                    Onboard[peasantX, peasantY] = new Tower(Game.whitesTurn);
                    break;
                case 2:
                    Onboard[peasantX, peasantY] = new Knight(Game.whitesTurn);
                    break;
                case 3:
                    Onboard[peasantX, peasantY] = new Queen(Game.whitesTurn);
                    break;
            }
        }

        public int ToDraw()
        {
            int output = 0;
            if (Game.picked == false)
                output = Game.whitesTurn == Onboard[CursorPositionX, CursorPositionY].White || Onboard[CursorPositionX, CursorPositionY].Name == "Empty" ? Game.whitesTurn ? 1 : 2 : 0;
            else if (Onboard[MarkedPieceX, MarkedPieceY].CheckMove(CursorPositionX, CursorPositionY, MarkedPieceX, MarkedPieceY, Onboard)
                            && (Onboard[MarkedPieceX, MarkedPieceY].White != Onboard[CursorPositionX, CursorPositionY].White || Onboard[CursorPositionX, CursorPositionY].Name == "Empty"))
                output = Game.whitesTurn ? 1 : 2;

            else
            {
                // trækket er forbudt
                output = 0;
            }
            return output;
        }

    }
}    
