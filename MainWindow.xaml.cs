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

namespace CHESSWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TextBlock[,] WindowBoard;

        public MainWindow()
        {
            InitializeComponent();

            WindowBoard = new TextBlock[,]
            {
                /*
                { A8, B8, C8, D8, E8, F8, G8, H8 },
                { A7, B7, C7, D7, E7, F7, G7, H7 },
                { A6, B6, C6, D6, E6, F6, G6, H6 },
                { A5, B5, C5, D5, E5, F5, G5, H5 },
                { A4, B4, C4, D4, E4, F4, G4, H4 },
                { A3, B3, C3, D3, E3, F3, G3, H3 },
                { A2, B2, C2, D2, E2, F2, G2, H2 },
                { A1, B1, C1, D1, E1, F1, G1, H1 }
                */
                {A8,A7,A6,A5,A4,A3,A2,A1 },
                {B8,B7,B6,B5,B4,B3,B2,B1 },
                {C8,C7,C6,C5,C4,C3,C2,C1 },
                {D8,D7,D6,D5,D4,D3,D2,D1 },
                {E8,E7,E6,E5,E4,E3,E2,E1 },
                {F8,F7,F6,F5,F4,F3,F2,F1 },
                {G8,G7,G6,G5,G4,G3,G2,G1 },
                {H8,H7,H6,H5,H4,H3,H2,H1 }
            };

            DrawBoard();
        }

        private void DrawBoard()
        {
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                {


                    if (Program.Board1.Onboard[x, y].White)
                        WindowBoard[x, y].Text = Program.Board1.Onboard[x, y].Symbol.Substring(0, 1);
                    else
                        WindowBoard[x, y].Text = Program.Board1.Onboard[x, y].Symbol.Substring(1, 1);

                    // background
                    if (y == Program.Board1.MarkedPieceY && x == Program.Board1.MarkedPieceX && Game.picked)
                    {
                        if (Game.whitesTurn)
                            WindowBoard[x, y].Background = Brushes.Green;
                        else
                            WindowBoard[x, y].Background = Brushes.Blue;
                    }
                    else if (y == Program.Board1.CursorPositionY && x == Program.Board1.CursorPositionX)
                    {
                        Program.Board1.ToDraw();
                        WindowBoard[x, y].Background = Program.Board1.ToDraw() == 0 ? Brushes.Red : Program.Board1.ToDraw() == 1 ? Brushes.LightGreen : Brushes.LightBlue;
                    }
                    else
                    {
                        if ((x + y) % 2 == 0)
                            WindowBoard[x, y].Background = Brushes.Gray;
                        else
                            WindowBoard[x, y].Background = Brushes.White;
                    }

                }
        }

        private new void IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            TextBlock someBlock = sender as TextBlock;


            Program.Board1.CursorPositionX = Program.transformX(someBlock.Name);
            Program.Board1.CursorPositionY = Program.transformY(someBlock.Name);
            /*
            if (someBlock != null)
                    someBlock.Background = someBlock.Background == Brushes.Green ? (Program.transformX(someBlock.Name) + Program.transformY(someBlock.Name)) % 2 == 0? Brushes.Gray : Brushes.White : Brushes.Green;
            */
            DrawBoard();
        }

        private new void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // videregiver musens koordinater, altså hvilket felt den klikker på til metoder i board

            TextBlock someBlock = sender as TextBlock;

            if (Game.picked == false || (Program.Board1.MarkedPieceX == Program.transformX(someBlock.Name) && Program.Board1.MarkedPieceY == Program.transformY(someBlock.Name)))
                Program.Board1.Pick(Program.transformX(someBlock.Name), Program.transformY(someBlock.Name));
            else
                Program.Board1.Move(Program.transformX(someBlock.Name), Program.transformY(someBlock.Name));

            DrawBoard();

        }
        private new void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // debug

            TextBlock someBlock = sender as TextBlock;

            MessageBox.Show(Program.Board1.Onboard[Program.transformX(someBlock.Name), Program.transformY(someBlock.Name)].Name +" " +Program.Board1.Onboard[Program.transformX(someBlock.Name), Program.transformY(someBlock.Name)].White);
        }
    }
}
