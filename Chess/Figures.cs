using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess
{
    struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Figures
    {
        public string Name;
        public int positionX;
        public int positionY;
        public string Color;
        public string ImgSource;
        public static string opponentColor;
        public static string playerColor;
        List<Point> knightHint = new List<Point>();
        List<Point> kingHint = new List<Point>();
        public Figures(String Name, int positionX, int positionY, String Color, String ImgSource)
        {
            this.Name = Name;
            this.positionX = positionX;
            this.positionY = positionY;
            this.Color = Color;
            this.ImgSource = ImgSource;
        }

        public override string ToString()
        {
            return $"Name: {Name}, PositionX: {positionX}, PoitionY: {positionY}, Color: {Color}, ImgSouce: {ImgSource}";
        }
        public void AddHint(ref Image[,] img, ref int[,] matrix, List<Figures> figures, string color)
        {
            switch (Name)
            {
                case "pawn":
                    if (color == playerColor) {                        
                        PawnHint(positionX, positionY, ref img, ref matrix, figures);
                    }
                    else
                    {
                        PawnOpponentHint(positionX, positionY, ref img, ref matrix, figures);
                    }
                    break;
                case "king":
                    KingHint(positionX, positionY, ref img, ref matrix, figures, color);
                    break;
                case "queen":
                    QueenHint(positionX, positionY, ref img, ref matrix, figures, color);
                    break;
                case "knight":
                    KnightHint(positionX, positionY, ref img, ref matrix, figures, color);
                    break;
                case "rook":
                    RookHint(positionX, positionY, ref img, ref matrix, figures, color);
                    break;
                default:
                    BishopHint(positionX, positionY, ref img, ref matrix, figures, color);
                    break;

            }
        }
        public static Figures GetFigure(int x, int y, List<Figures> figures)
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
        private void PawnHint(int indexX, int indexY, ref Image[,] img, ref int[,] matrix, List<Figures> figures)
        {
            if (GetFigure(indexX, indexY - 1, figures)?.Color != opponentColor && GetFigure(indexX, indexY - 1, figures)?.Color != playerColor)
            {
                if (indexX >= 0 && indexX <= 7 && indexY - 1 >= 0 && indexY - 1 <= 7)
                {
                    img[indexX, indexY - 1].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    matrix[indexX, indexY - 1] = 2;
                }
            }
            if (indexY >= 6 && GetFigure(indexX, indexY - 1, figures)?.Color != opponentColor && GetFigure(indexX, indexY - 1, figures)?.Color != playerColor)
            {
                if (indexX >= 0 && indexX <= 7 && indexY - 2 >= 0 && indexY - 2 <= 7)
                {
                    if (GetFigure(indexX, indexY - 2, figures) == null)
                    {
                        img[indexX, indexY - 2].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                        matrix[indexX, indexY - 2] = 2;
                    }
                }
            }
            if (GetFigure(indexX + 1, indexY - 1, figures)?.Color == opponentColor)
            {
                if (indexX + 1 >= 0 && indexX + 1 <= 7 && indexY - 1 >= 0 && indexY - 1 <= 7)
                {
                    img[indexX + 1, indexY - 1].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    matrix[indexX + 1, indexY - 1] = 2;
                }
            }
            if (GetFigure(indexX - 1, indexY - 1, figures)?.Color == opponentColor)
            {
                if (indexX - 1 >= 0 && indexX - 1 <= 7 && indexY - 1 >= 0 && indexY - 1 <= 7)
                {
                    img[indexX - 1, indexY - 1].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    matrix[indexX - 1, indexY - 1] = 2;
                }
            }
        }
        private void PawnOpponentHint(int indexX, int indexY, ref Image[,] img, ref int[,] matrix, List<Figures> figures)
        {            
            if (GetFigure(indexX, indexY + 1, figures)?.Color != opponentColor && GetFigure(indexX, indexY + 1, figures)?.Color != playerColor)
            {
                if (indexX >= 0 && indexX <= 7 && indexY + 1 >= 0 && indexY + 1 <= 7)
                {
                    img[indexX, indexY + 1].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    matrix[indexX, indexY + 1] = 2;
                }
            }
            if (indexY <= 1 && GetFigure(indexX, indexY + 1, figures)?.Color != opponentColor && GetFigure(indexX, indexY + 1, figures)?.Color != playerColor)
            {
                if (indexX >= 0 && indexX <= 7 && indexY + 2 >= 0 && indexY + 2 <= 7)
                {
                    if (GetFigure(indexX, indexY + 2, figures) == null)
                    {
                        img[indexX, indexY + 2].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                        matrix[indexX, indexY + 2] = 2;
                    }
                }
            }
            if (GetFigure(indexX + 1, indexY + 1, figures)?.Color == playerColor)
            {
                if (indexX + 1 >= 0 && indexX + 1 <= 7 && indexY + 1 >= 0 && indexY + 1 <= 7)
                {
                    img[indexX + 1, indexY + 1].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    matrix[indexX + 1, indexY + 1] = 2;
                }
            }
            if (GetFigure(indexX - 1, indexY + 1, figures)?.Color == playerColor)
            {
                if (indexX - 1 >= 0 && indexX - 1 <= 7 && indexY + 1 >= 0 && indexY + 1 <= 7)
                {
                    img[indexX - 1, indexY + 1].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    matrix[indexX - 1, indexY + 1] = 2;
                }
            }
        }
        private void KingHint(int indexX, int indexY, ref Image[,] img, ref int[,] matrix, List<Figures> figures, string color)
        {
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
                if (GetFigure(indexX + p.x, indexY + p.y, figures)?.Color != color)
                {
                    if (indexX + p.x >= 0 && indexX + p.x <= 7 && indexY + p.y >= 0 && indexY + p.y <= 7)
                    {
                        img[indexX + p.x, indexY + p.y].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                        matrix[indexX + p.x, indexY + p.y] = 2;
                    }
                }
            }
            kingHint.Clear();            
        }
        private void QueenHint(int indexX, int indexY, ref Image[,] img, ref int[,] matrix, List<Figures> figures, string color)
        {
            BishopHint(indexX, indexY, ref img, ref matrix, figures, color);
            RookHint(indexX, indexY, ref img, ref matrix, figures, color);
        }
        private void BishopHint(int indexX, int indexY, ref Image[,] img, ref int[,] matrix, List<Figures> figures, string color)
        {

            int i = indexX, j = indexY;
            while (i < 7 && i >= 0 && j < 7 && j >= 0)
            {
                i++;
                j++;
                if (GetFigure(i, j, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }

            i = indexX;
            j = indexY;
            while (i <= 7 && i > 0 && j <= 7 && j > 0)
            {
                i--;
                j--;
                if (GetFigure(i, j, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }
            i = indexX;
            j = indexY;
            while (i < 7 && i >= 0 && j <= 7 && j > 0)
            {
                i++;
                j--;
                if (GetFigure(i, j, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }
            i = indexX;
            j = indexY;
            while (i <= 7 && i > 0 && j < 7 && j >= 0)
            {
                i--;
                j++;
                if (GetFigure(i, j, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[i, j] = 2;
                    img[i, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }
        }
        private void KnightHint(int indexX, int indexY, ref Image[,] img, ref int[,] matrix, List<Figures> figures, string color)
        {
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
                if (GetFigure(indexX + p.x, indexY + p.y, figures)?.Color != color)
                {
                    if (indexX + p.x >= 0 && indexX + p.x <= 7 && indexY + p.y >= 0 && indexY + p.y <= 7)
                    {
                        img[indexX + p.x, indexY + p.y].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                        matrix[indexX + p.x, indexY + p.y] = 2;

                    }
                }
            }
            knightHint.Clear();            
        }
        private static void RookHint(int indexX, int indexY, ref Image[,] img, ref int[,] matrix, List<Figures> figures, string color)
        {
            int i = indexX, j = indexY;
            for (int t = indexX - 1; t >= 0; t--)
            {
                if (GetFigure(t, j, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[t, j] = 2;
                    img[t, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(t, j, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[t, j] = 2;
                    img[t, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }
            i = indexX;
            j = indexY;
            for (int t = indexX + 1; t <= 7; t++)
            {
                if (GetFigure(t, j, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[t, j] = 2;
                    img[t, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(t, j, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[t, j] = 2;
                    img[t, j].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }
            i = indexX;
            j = indexY;
            for (int t = indexY - 1; t >= 0; t--)
            {
                if (GetFigure(i, t, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[i, t] = 2;
                    img[i, t].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(i, t, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[i, t] = 2;
                    img[i, t].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }
            i = indexX;
            j = indexY;
            for (int t = indexY + 1; t <= 7; t++)
            {
                if (GetFigure(i, t, figures)?.Color == (color == playerColor ? opponentColor : playerColor))
                {
                    matrix[i, t] = 2;
                    img[i, t].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                    break;
                }
                else if (GetFigure(i, t, figures)?.Color == (color == playerColor ? playerColor : opponentColor))
                {
                    break;
                }
                else
                {
                    matrix[i, t] = 2;
                    img[i, t].Source = new BitmapImage(new Uri("border.png", UriKind.Relative));
                }
            }
        }
    }
}
