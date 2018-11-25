using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>  

    class Steps
    {
        public int startPosX;
        public int startPosY;
        public int endPosX;
        public int endPosY;

        public Steps(int startPosX, int startPosY, int endPosX, int endPosY)
        {
            this.startPosX = startPosX;
            this.startPosY = startPosY;
            this.endPosX = endPosX;
            this.endPosY = endPosY;
        }

        public override string ToString()
        {
            return $"startX: {startPosX}, startY: {startPosY}, endX: {endPosX}, endY: {endPosY}";
        }
    }
    public partial class MainWindow : Window
    {

        const int rowHeight = 80;
        const int columnWidth = 75;
        string color1, color2;
        bool isFigureCliked = false;
        bool leftButtonClicked = false;
        string nonPlayingColor;
        Boolean color;
        String player1Color;
        String player2Color;
        List<Figures> figures = new List<Figures>();
        int[,] matrix = new int[8, 8];
        Image[,] image = new Image[8, 8];
        Image[,] hint = new Image[8, 8];
        Image[,] comboBoxFigure = new Image[8, 8];
        List<Steps> calculatedSteps = new List<Steps>();
        List<Figures> currentLocationOfFigures = new List<Figures>();
        List<string> selectedSteps = new List<string>();
        List<string> opponentSelectedSteps = new List<string>();
        public Dictionary<string, List<Figures>> dictionary = new Dictionary<string, List<Figures>>();
        public Dictionary<string, int> stepsPoints = new Dictionary<string, int>();
        public Dictionary<string, int> figurePoints = new Dictionary<string, int>();
        public void StartGame(Boolean IsWhite = true)
        {
            Figures.opponentColor = player2Color;
            Figures.playerColor = player1Color;
            figurePoints.Add("pawn", 10);
            figurePoints.Add("bishop", 30);
            figurePoints.Add("knight", 30);
            figurePoints.Add("rook", 50);
            figurePoints.Add("queen", 90);
            figurePoints.Add("king", 900);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = 0;
                    image[i, j] = new Image
                    {
                        Source = null,
                        Stretch = Stretch.Fill,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(i * rowHeight, j * columnWidth, 0, 0),
                        Width = 80,
                        Height = 75
                    };
                    hint[i, j] = new Image
                    {
                        Source = null,
                        Stretch = Stretch.Fill,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(i * rowHeight, j * columnWidth, 0, 0),
                        Width = 80,
                        Height = 75
                    };
                    comboBoxFigure[i, j] = new Image
                    {
                        Source = null,
                        Stretch = Stretch.Fill,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(i * rowHeight, j * columnWidth, 0, 0),
                        Width = 80,
                        Height = 75
                    };
                    table.Children.Add(image[i, j]);
                    table.Children.Add(hint[i, j]);
                    table.Children.Add(comboBoxFigure[i, j]);
                }
            }

            color1 = IsWhite ? "white" : "black";
            color2 = color1 == "white" ? "black" : "white";

            figures.Add(new Figures("pawn", 0, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 1, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 2, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 3, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 4, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 5, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 6, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 7, 6, color1, color1 + "-pawn.png"));
            figures.Add(new Figures("pawn", 0, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("pawn", 1, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("pawn", 2, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("pawn", 3, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("pawn", 4, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("pawn", 5, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("pawn", 6, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("pawn", 7, 1, color2, color2 + "-pawn.png"));
            figures.Add(new Figures("bishop", 2, 7, color1, color1 + "-bishop.png"));
            figures.Add(new Figures("bishop", 5, 7, color1, color1 + "-bishop.png"));
            figures.Add(new Figures("bishop", 2, 0, color2, color2 + "-bishop.png"));
            figures.Add(new Figures("bishop", 5, 0, color2, color2 + "-bishop.png"));
            figures.Add(new Figures("rook", 7, 7, color1, color1 + "-rook.png"));
            figures.Add(new Figures("rook", 0, 7, color1, color1 + "-rook.png"));
            figures.Add(new Figures("rook", 0, 0, color2, color2 + "-rook.png"));
            figures.Add(new Figures("rook", 7, 0, color2, color2 + "-rook.png"));
            figures.Add(new Figures("knight", 1, 7, color1, color1 + "-knight.png"));
            figures.Add(new Figures("knight", 6, 7, color1, color1 + "-knight.png"));
            figures.Add(new Figures("knight", 1, 0, color2, color2 + "-knight.png"));
            figures.Add(new Figures("knight", 6, 0, color2, color2 + "-knight.png"));
            figures.Add(new Figures("queen", 3, 7, color1, color1 + "-queen.png"));
            figures.Add(new Figures("queen", 3, 0, color2, color2 + "-queen.png"));
            figures.Add(new Figures("king", 4, 7, color1, color1 + "-king.png"));
            figures.Add(new Figures("king", 4, 0, color2, color2 + "-king.png"));

            foreach (var figure in figures)
            {
                matrix[figure.positionX, figure.positionY] = 1;
                image[figure.positionX, figure.positionY].Source = new BitmapImage(new Uri(figure.ImgSource, UriKind.Relative));
                Panel.SetZIndex(image[figure.positionX, figure.positionY], 1);
            }
            nonPlayingColor = "black";
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        Figures clickedFigure;
        int clickedMousePosX, clickedMousePosY;

        private Figures GetSelectedFigure(int x, int y)
        {
            foreach (var l in figures)
            {
                if (l.positionX == x && l.positionY == y)
                {
                    return l;
                }
            }

            return null;
        }
        private void Start_game_Click(object sender, RoutedEventArgs e)
        {
            color = radio_button_white.IsChecked == true ? true : false;
            player1Color = radio_button_white.IsChecked == true ? "white" : "black";
            player2Color = radio_button_white.IsChecked == false ? "white" : "black";
            StartGame(color);
            start_game.IsEnabled = false;
        }

        double deltaX, deltaY;

        private void Radio_button_Checked(object sender, RoutedEventArgs e)
        {
            //start_game.IsEnabled = true;
        }
        static int n;
        string selectedColor1;
        private void Calculate()
        {
            GC.Collect();
            n = Convert.ToInt32(depth_selector.Text.ToString());
            currentLocationOfFigures.Clear();
            dictionary.Clear();
            foreach (var f in figures)
            {
                currentLocationOfFigures.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
            }

            for (int i = 0; i < calculatedSteps.ToArray().Length; i++)
            {
                dictionary.Add("A " + i.ToString(), MiniMaxTree.GetNewBoard(currentLocationOfFigures, calculatedSteps[i]));

            }

            selectedColor1 = GetSelectedFigure(calculatedSteps[0].startPosX, calculatedSteps[0].startPosY).Color;
            string selectedColor2;
            if (selectedColor1 == "white")
                selectedColor2 = "black";
            else selectedColor2 = "white";
            string[] keys = dictionary.Keys.ToArray();

            MiniMaxTree tree = new MiniMaxTree();
            for (int i = 0; i < (2 * n - 1); i++)
            {
                if (i % 2 == 0)
                {
                    keys = tree.CreateNodes(keys, dictionary, selectedColor2);
                }
                else
                {
                    keys = tree.CreateNodes(keys, dictionary, selectedColor1);
                }
            }

            ChooseBestStep();
        }
        private int GetCountOfSpaces(string key)
        {
            return key.Count(x => x.ToString() == " ");
        }

        private void MiniMax(bool isMinimizer, int deep)
        {
            if (isMinimizer)
            {
                Minimizer(deep);
            }
            else
            {
                Maximizer(deep);
            }
        }

        private void Minimizer(int deep)
        {
            List<int> list = new List<int>();
            foreach (var d in dictionary)
            {
                if (GetCountOfSpaces(d.Key) == deep)
                {
                    list.Clear();
                    var value = stepsPoints.Where(x => x.Key.StartsWith(d.Key));
                    foreach (var v in value)
                    {
                        list.Add(v.Value);
                    }
                    stepsPoints.Add(d.Key, list.Min());
                }
            }
        }
        private void Maximizer(int deep)
        {
            List<int> list = new List<int>();
            foreach (var d in dictionary)
            {
                if (GetCountOfSpaces(d.Key) == deep)
                {
                    var value = stepsPoints.Where(x => x.Key.StartsWith(d.Key));
                    foreach (var v in value)
                    {
                        list.Add(v.Value);
                    }
                    stepsPoints.Add(d.Key, list.Max());
                }
            }
        }
        private void ChooseBestStep()
        {
            stepsPoints.Clear();
            foreach (var d in dictionary)
            {
                if (GetCountOfSpaces(d.Key) == 2 * n)
                {
                    stepsPoints.Add(d.Key, CountPoints(d.Key));
                }
            }

            for (int i = 0; i < 2 * n - 1; i++)
            {
                MiniMax(i % 2 == 0 ? true : false, 2 * n - 1 - i);
            }
            List<int> list = new List<int>();
            var value = stepsPoints.Where(x => GetCountOfSpaces(x.Key) == 1);
            foreach (var v in value)
            {
                list.Add(v.Value);
            }
            var index = list.IndexOf(list.Max());
            var result = calculatedSteps[index];
            image[result.endPosX, result.endPosY].Source = new BitmapImage(new Uri(GetSelectedFigure(result.startPosX, result.startPosY)?.ImgSource, UriKind.Relative));
            image[result.endPosX, result.endPosY].Margin = new Thickness(result.endPosX * rowHeight, result.endPosY * columnWidth, 0, 0);
            foreach (var f in figures)
            {
                if (f.positionX == result.endPosX && f.positionY == result.endPosY)
                {
                    figures.Remove(f);
                    break;
                }
            }
            foreach (var f in figures)
            {
                if (f.positionX == result.startPosX && f.positionY == result.startPosY)
                {
                    f.positionX = result.endPosX;
                    f.positionY = result.endPosY;
                }
            }
            image[result.startPosX, result.startPosY].Source = null;
            calculatedSteps.Clear();
        }

        private int CountPoints(string key)
        {
            int count = 0;

            foreach (var l in dictionary[key])
            {
                if (l.Color == selectedColor1)
                {
                    count = count + figurePoints[l.Name];
                }
                else
                {
                    count = count - figurePoints[l.Name];
                }
            }

            return count;
        }

        string PawnCategory;

        private bool IsMate(string color)
        {
            var king = figures.Where(x => x.Name == "king" && x.Color == color).FirstOrDefault();
            int posX = king.positionX;
            int posY = king.positionY;

            List<Point> kingHint = new List<Point>();
            kingHint.Add(new Point(0, 1));
            kingHint.Add(new Point(0, -1));
            kingHint.Add(new Point(1, 0));
            kingHint.Add(new Point(-1, 0));
            kingHint.Add(new Point(1, 1));
            kingHint.Add(new Point(1, -1));
            kingHint.Add(new Point(-1, 1));
            kingHint.Add(new Point(-1, -1));

            foreach (Point p in kingHint)
            {
                if (!Mate(posX + p.x, posY + p.y, color))
                {
                    return false;
                }
            }
            return true;
        }
        private bool Mate(int pX, int pY, string color)
        {
            int posX = pX;
            int posY = pY;
            string[] anyFigures = { "queen", "rook" };
            for (int i = posX + 1; i <= 7; i++)
            {
                if (GetSelectedFigure(i, posY)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(i, posY)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(i, posY)?.Name))
                    {
                        return true;
                    }
                }
            }
            for (int i = posX - 1; i >= 0; i--)
            {
                if (GetSelectedFigure(i, posY)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(i, posY)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(i, posY)?.Name))
                    {
                        return true;
                    }
                }
            }
            for (int j = posY + 1; j <= 7; j++)
            {
                if (GetSelectedFigure(posX, j)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(posX, j)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(posX, j)?.Name))
                    {
                        return true;
                    }
                }
            }
            for (int j = posY - 1; j >= 0; j--)
            {
                if (GetSelectedFigure(posX, j)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(posX, j)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(posX, j)?.Name))
                    {
                        return true;
                    }
                }
            }
            string[] anyFigures2 = { "queen", "bishop" };
            int ii = posX, jj = posY;
            while (ii < 7 && ii >= 0 && jj < 7 && jj >= 0)
            {
                ii++;
                jj++;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }

            ii = posX;
            jj = posY;
            while (ii <= 7 && ii > 0 && jj <= 7 && jj > 0)
            {
                ii--;
                jj--;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }
            ii = posX;
            jj = posY;
            while (ii < 7 && ii >= 0 && jj <= 7 && jj > 0)
            {
                ii++;
                jj--;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }
            ii = posX;
            jj = posY;
            while (ii <= 7 && ii > 0 && jj < 7 && jj >= 0)
            {
                ii--;
                jj++;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }
            List<Point> knightHint = new List<Point>();
            knightHint.Add(new Point(2, 1));
            knightHint.Add(new Point(2, -1));
            knightHint.Add(new Point(1, 2));
            knightHint.Add(new Point(1, -2));
            knightHint.Add(new Point(-1, 2));
            knightHint.Add(new Point(-1, -2));
            knightHint.Add(new Point(-2, 1));
            knightHint.Add(new Point(-2, -1));

            foreach (Point p in knightHint)
            {
                if (GetSelectedFigure(posX + p.x, posY + p.y)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(posX + p.x, posY + p.y)?.Color != color)
                {
                    if (GetSelectedFigure(posX + p.x, posY + p.y)?.Name == "knight")
                    {
                        return true;
                    }
                }
            }
            //MessageBox.Show(king.positionX + "  " + king.positionY);
            return false;
        }
        private bool IsShax(string color)
        {
            var king = figures.Where(x => x.Name == "king" && x.Color == color).FirstOrDefault();
            int posX = king.positionX;
            int posY = king.positionY;
            string[] anyFigures = { "queen", "rook" };
            for (int i = posX + 1; i <= 7; i++)
            {
                if (GetSelectedFigure(i, posY)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(i, posY)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(i, posY)?.Name))
                    {
                        return true;
                    }
                }
            }
            for (int i = posX - 1; i >= 0; i--)
            {
                if (GetSelectedFigure(i, posY)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(i, posY)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(i, posY)?.Name))
                    {
                        return true;
                    }
                }
            }
            for (int j = posY + 1; j <= 7; j++)
            {
                if (GetSelectedFigure(posX, j)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(posX, j)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(posX, j)?.Name))
                    {
                        return true;
                    }
                }
            }
            for (int j = posY - 1; j >= 0; j--)
            {
                if (GetSelectedFigure(posX, j)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(posX, j)?.Color != color)
                {
                    if (anyFigures.Contains(GetSelectedFigure(posX, j)?.Name))
                    {
                        return true;
                    }
                }
            }
            string[] anyFigures2 = { "queen", "bishop" };
            int ii = posX, jj = posY;
            while (ii < 7 && ii >= 0 && jj < 7 && jj >= 0)
            {
                ii++;
                jj++;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }

            ii = posX;
            jj = posY;
            while (ii <= 7 && ii > 0 && jj <= 7 && jj > 0)
            {
                ii--;
                jj--;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }
            ii = posX;
            jj = posY;
            while (ii < 7 && ii >= 0 && jj <= 7 && jj > 0)
            {
                ii++;
                jj--;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }
            ii = posX;
            jj = posY;
            while (ii <= 7 && ii > 0 && jj < 7 && jj >= 0)
            {
                ii--;
                jj++;
                if (GetSelectedFigure(ii, jj)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(ii, jj)?.Color != color)
                {
                    if (anyFigures2.Contains(GetSelectedFigure(ii, jj)?.Name))
                    {
                        return true;
                    }
                }
            }
            List<Point> knightHint = new List<Point>();
            knightHint.Add(new Point(2, 1));
            knightHint.Add(new Point(2, -1));
            knightHint.Add(new Point(1, 2));
            knightHint.Add(new Point(1, -2));
            knightHint.Add(new Point(-1, 2));
            knightHint.Add(new Point(-1, -2));
            knightHint.Add(new Point(-2, 1));
            knightHint.Add(new Point(-2, -1));

            foreach (Point p in knightHint)
            {
                if (GetSelectedFigure(posX + p.x, posY + p.y)?.Color == color)
                {
                    break;
                }
                if (GetSelectedFigure(posX + p.x, posY + p.y)?.Color != color)
                {
                    if (GetSelectedFigure(posX + p.x, posY + p.y)?.Name == "knight")
                    {
                        return true;
                    }
                }
            }
            //MessageBox.Show(king.positionX + "  " + king.positionY);
            return false;
        }
        private void Finish_oponent_steps_Click(object sender, RoutedEventArgs e)
        {
            your_steps.Items.Clear();
            opponent_steps.Items.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == 2)
                    {
                        hint[i, j].Source = null;
                        matrix[i, j] = 0;
                    }
                }
            }
            var color = nonPlayingColor;
            if (nonPlayingColor == "black")
                nonPlayingColor = "white";
            else nonPlayingColor = "black";

            Calculate();
            if (IsShax(color))
            {
                MessageBox.Show("Shaaax");
            }

        }
        int clickedLeftButtonPosX = -1;
        int clickedLeftButtonPosY = -1;
        string currentColor;
        string qar;
        string step;
        int startX;
        int startY;
        int endX;
        int endY;
        private void Table_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GetSelectedFigure((int)((e.GetPosition(this).X) / rowHeight), (int)((e.GetPosition(this).Y) / columnWidth))?.Color == nonPlayingColor && matrix[(int)((e.GetPosition(this).X) / rowHeight), (int)((e.GetPosition(this).Y) / columnWidth)] != 2)
            {
                MessageBox.Show("Opssss, it's not step of this color");
            }
            else if (GetSelectedFigure((int)((e.GetPosition(this).X) / rowHeight), (int)((e.GetPosition(this).Y) / columnWidth))?.Color == nonPlayingColor && matrix[(int)((e.GetPosition(this).X) / rowHeight), (int)((e.GetPosition(this).Y) / columnWidth)] == 2)
            {
                clickedLeftButtonPosX = (int)((e.GetPosition(this).X) / rowHeight);
                clickedLeftButtonPosY = (int)((e.GetPosition(this).Y) / columnWidth);
                step = $"{clickedLeftButtonPosX} / {clickedLeftButtonPosY}";
                endX = clickedLeftButtonPosX;
                endY = clickedLeftButtonPosY;
                if (currentColor == player1Color)
                {
                    opponent_steps.Items.Clear();
                    opponentSelectedSteps.Clear();
                    if (!selectedSteps.Contains(qar + step))
                    {
                        your_steps.Items.Add(qar + step);
                        selectedSteps.Add(qar + step);
                    }

                }
                else
                {
                    your_steps.Items.Clear();
                    selectedSteps.Clear();
                    if (!opponentSelectedSteps.Contains(qar + step))
                    {
                        opponent_steps.Items.Add(qar + step);
                        opponentSelectedSteps.Add(qar + step);
                    }
                }
                calculatedSteps.Add(new Steps(startX, startY, endX, endY));
                step = "";
            }
            else
            {
                clickedLeftButtonPosX = (int)((e.GetPosition(this).X) / rowHeight);
                clickedLeftButtonPosY = (int)((e.GetPosition(this).Y) / columnWidth);
                if (GetSelectedFigure(clickedLeftButtonPosX, clickedLeftButtonPosY) != null)
                {
                    currentColor = GetSelectedFigure(clickedLeftButtonPosX, clickedLeftButtonPosY)?.Color;
                    qar = $"{GetSelectedFigure(clickedLeftButtonPosX, clickedLeftButtonPosY)?.Name} - {clickedLeftButtonPosX} / {clickedLeftButtonPosY} to ";
                    startX = clickedLeftButtonPosX;
                    startY = clickedLeftButtonPosY;
                }

                if (matrix[clickedLeftButtonPosX, clickedLeftButtonPosY] != 2)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (matrix[i, j] == 2)
                            {
                                hint[i, j].Source = null;
                                matrix[i, j] = 0;
                            }
                        }
                    }
                }
                else
                {
                    step = $"{clickedLeftButtonPosX} / {clickedLeftButtonPosY}";
                    endX = clickedLeftButtonPosX;
                    endY = clickedLeftButtonPosY;
                    if (currentColor == player1Color)
                    {
                        opponent_steps.Items.Clear();
                        opponentSelectedSteps.Clear();
                        if (!selectedSteps.Contains(qar + step))
                        {
                            your_steps.Items.Add(qar + step);
                            selectedSteps.Add(qar + step);
                        }

                    }
                    else
                    {
                        your_steps.Items.Clear();
                        selectedSteps.Clear();
                        if (!opponentSelectedSteps.Contains(qar + step))
                        {
                            opponent_steps.Items.Add(qar + step);
                            opponentSelectedSteps.Add(qar + step);
                        }
                    }
                    calculatedSteps.Add(new Steps(startX, startY, endX, endY));
                    step = "";

                }
                if (GetSelectedFigure(clickedLeftButtonPosX, clickedLeftButtonPosY) != null)
                {
                    clickedFigure = GetSelectedFigure(clickedLeftButtonPosX, clickedLeftButtonPosY);
                    clickedFigure.AddHint(ref hint, ref matrix, figures, GetSelectedFigure(clickedLeftButtonPosX, clickedLeftButtonPosY)?.Color);
                }
            }
        }
        private void Table_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (GetSelectedFigure((int)((e.GetPosition(this).X) / rowHeight), (int)((e.GetPosition(this).Y) / columnWidth))?.Color == nonPlayingColor)
            {
                MessageBox.Show("Opssss, it's not step of this color");
            }
            else if (GetSelectedFigure((int)((e.GetPosition(this).X) / rowHeight), (int)((e.GetPosition(this).Y) / columnWidth)) != null)
            {
                isFigureCliked = true;
                clickedMousePosX = (int)((e.GetPosition(this).X) / rowHeight);
                clickedMousePosY = (int)((e.GetPosition(this).Y) / columnWidth);
                clickedFigure = GetSelectedFigure(clickedMousePosX, clickedMousePosY);
                clickedFigure.AddHint(ref hint, ref matrix, figures, GetSelectedFigure(clickedMousePosX, clickedMousePosY)?.Color);
                deltaX = e.GetPosition(this).X - image[clickedMousePosX, clickedMousePosY].Margin.Left;
                deltaY = e.GetPosition(this).Y - image[clickedMousePosX, clickedMousePosY].Margin.Top;
            }

        }

        private void Table_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isFigureCliked = false;
            double mousePosX = (e.GetPosition(this).X) / rowHeight;
            double mousePosY = (e.GetPosition(this).Y) / columnWidth;
            double eatenPosX = (e.GetPosition(this).X) / rowHeight;
            double eatenPosY = (e.GetPosition(this).Y) / columnWidth;
            string anyColor = "";
            if (GetSelectedFigure(clickedMousePosX, clickedMousePosY) != null)
            {
                image[(int)mousePosX, (int)mousePosY].Source = image[clickedMousePosX, clickedMousePosY].Source;
                image[(int)mousePosX, (int)mousePosY].Margin = new Thickness((int)mousePosX * rowHeight, (int)mousePosY * columnWidth, 0, 0);
                if ((int)mousePosX != clickedMousePosX || (int)mousePosY != clickedMousePosY)
                {
                    image[clickedMousePosX, clickedMousePosY].Source = null;
                }

                if (matrix[(int)mousePosX, (int)mousePosY] != 2)
                {

                    if (GetSelectedFigure((int)mousePosX, (int)mousePosY) != null || Figures.GetFigure((int)mousePosX, (int)mousePosY, figures)?.Color == player2Color)
                    {
                        image[(int)mousePosX, (int)mousePosY].Source = new BitmapImage(new Uri(Figures.GetFigure((int)mousePosX, (int)mousePosY, figures)?.ImgSource, UriKind.Relative));
                    }
                    else
                    {
                        image[(int)mousePosX, (int)mousePosY].Source = null;
                    }

                    mousePosX = clickedMousePosX;
                    mousePosY = clickedMousePosY;
                    image[clickedMousePosX, clickedMousePosY].Margin = new Thickness(clickedMousePosX * rowHeight, clickedMousePosY * columnWidth, 0, 0);
                    image[clickedMousePosX, clickedMousePosY].Source = new BitmapImage(new Uri(clickedFigure.ImgSource, UriKind.Relative));

                }
                else
                {
                    selectedSteps.Clear();
                    opponentSelectedSteps.Clear();
                    your_steps.Items.Clear();
                    opponent_steps.Items.Clear();
                    anyColor = nonPlayingColor;
                    if (nonPlayingColor == "black")
                        nonPlayingColor = "white";
                    else nonPlayingColor = "black";


                    foreach (var figure in figures)
                    {
                        if (figure.positionX == (int)eatenPosX && figure.positionY == (int)eatenPosY)
                        {
                            if (figure.Name != "king")
                            {
                                figures.Remove(figure);
                            }
                            else
                            {
                                if (figure.Color == "black")
                                {
                                    MessageBox.Show("White Win");
                                }
                                else
                                {
                                    MessageBox.Show("Black Win");
                                }
                            }
                            break;
                        }
                    }
                }

                foreach (var figure in figures)
                {
                    if (figure != null)
                    {
                        if (figure.positionX == clickedMousePosX && figure.positionY == clickedMousePosY)
                        {
                            figure.positionX = (int)mousePosX;
                            figure.positionY = (int)mousePosY;

                            if (matrix[(int)mousePosX, (int)mousePosY] == 2)
                            {
                                if (IsShax(anyColor))
                                {
                                    MessageBox.Show("Shaaax");
                                }
                                //if (IsMate(anyColor))
                                //{
                                //    MessageBox.Show("Mate");
                                //}                               
                            }


                        }
                    }
                }
                if ((int)mousePosY == 0 && figures.Where(x => (x.positionX == (int)mousePosX && x.positionY == (int)mousePosY)).First().Name == "pawn")
                {
                    Choose choose = new Choose();
                    choose.ShowDialog();
                    PawnCategory = choose.pawnCategory;
                    string color = figures.Where(x => (x.positionX == (int)mousePosX && x.positionY == (int)mousePosY)).First().Color;
                    Figures figure = figures.Where(x => (x.positionX == (int)mousePosX && x.positionY == (int)mousePosY)).First();
                    figure.ImgSource = color + "-" + PawnCategory + ".png";
                    figure.Name = PawnCategory;
                    image[figure.positionX, figure.positionY].Source = new BitmapImage(new Uri(figure.ImgSource, UriKind.Relative));
                }


                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (matrix[i, j] == 2)
                        {
                            hint[i, j].Source = null;
                            matrix[i, j] = 0;
                        }
                    }
                }

            }
            //if (figures.Where(x => x.Name == "king" && x.Color == "black").ToArray().Length == 0)
            //{
            //    MessageBox.Show("White Win");
            //}
            //else if(figures.Where(x => x.Name == "king" && x.Color == "white").ToArray().Length == 0)
            //{
            //    MessageBox.Show("Black Win");
            //}

        }

        private void Table_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFigureCliked)
            {
                image[clickedMousePosX, clickedMousePosY].Margin = new Thickness(e.GetPosition(this).X - deltaX, e.GetPosition(this).Y - deltaY, 0, 0);
                Panel.SetZIndex(image[clickedMousePosX, clickedMousePosY], 1);
            }
        }
    }
}
