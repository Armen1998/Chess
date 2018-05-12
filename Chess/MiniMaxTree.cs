using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{

    class MiniMaxTree
    {
        string color1;
        string color2;
        public List<List<Figures>> listOfLists = new List<List<Figures>>();
        public Figures GetFigure(int x, int y, List<Figures> figures)
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
        public void AddFigureSteps(string Name, int indexX, int indexY, List<Figures> figures)
        {
            switch (Name)
            {
                case "pawn":
                    {
                        if (color1 == "black")
                        {                            
                            
                            if (GetFigure(indexX, indexY + 1, figures)?.Color != color1 && GetFigure(indexX, indexY + 1, figures)?.Color != color2)
                            {
                                if (indexX >= 0 && indexX <= 7 && indexY + 1 >= 0 && indexY + 1 <= 7)
                                {
                                    List<Figures> list = new List<Figures>();

                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX && l.positionY == indexY + 1)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {
                                            i.positionX = indexX;
                                            i.positionY = indexY + 1;                                            
                                        }
                                    }
                                    listOfLists.Add(list);                                    
                                    list = null;
                                }
                            }
                            if (indexY <= 1 && GetFigure(indexX, indexY + 1, figures)?.Color != color1 && GetFigure(indexX, indexY + 1, figures)?.Color != color2)
                            {
                                if (indexX >= 0 && indexX <= 7 && indexY + 2 >= 0 && indexY + 2 <= 7)
                                {
                                    if (GetFigure(indexX, indexY + 2, figures) == null)
                                    {
                                        List<Figures> list = new List<Figures>();
                                        foreach (var i in figures)
                                        {
                                            list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                        }
                                        foreach (var l in list)
                                        {
                                            if (l.positionX == indexX && l.positionY == indexY + 2)
                                            {
                                                list.Remove(l);
                                                break;
                                            }
                                        }
                                        foreach (var i in list)
                                        {
                                            if (i.positionX == indexX && i.positionY == indexY)
                                            {
                                                i.positionX = indexX;
                                                i.positionY = indexY + 2;

                                            }
                                        }
                                        listOfLists.Add(list);                                        
                                        list = null;
                                    }
                                }
                            }
                            if (GetFigure(indexX + 1, indexY + 1, figures)?.Color == color2)
                            {
                                if (indexX + 1 >= 0 && indexX + 1 <= 7 && indexY + 1 >= 0 && indexY + 1 <= 7)
                                {
                                    List<Figures> list = new List<Figures>();
                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX + 1 && l.positionY == indexY + 1)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {

                                            i.positionX = indexX + 1;
                                            i.positionY = indexY + 1;
                                            
                                        }
                                    }
                                    listOfLists.Add(list);                                                                       
                                    list = null;
                                }
                            }
                            if (GetFigure(indexX - 1, indexY + 1, figures)?.Color == color2)
                            {
                                if (indexX - 1 >= 0 && indexX - 1 <= 7 && indexY + 1 >= 0 && indexY + 1 <= 7)
                                {
                                    List<Figures> list = new List<Figures>();
                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX - 1 && l.positionY == indexY + 1)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {

                                            i.positionX = indexX - 1;
                                            i.positionY = indexY + 1;
                                            
                                        }
                                    }
                                    listOfLists.Add(list);                                                                                                           
                                    list = null;
                                }
                            }
                        }
                        else
                        {                            
                            if (GetFigure(indexX, indexY - 1, figures)?.Color != color1 && GetFigure(indexX, indexY - 1, figures)?.Color != color2)
                            {
                                if (indexX >= 0 && indexX <= 7 && indexY - 1 >= 0 && indexY - 1 <= 7)
                                {
                                    List<Figures> list = new List<Figures>();
                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX && l.positionY == indexY - 1)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {
                                            
                                            i.positionX = indexX;
                                            i.positionY = indexY - 1;
                                            
                                        }
                                    }
                                    listOfLists.Add(list);                                    
                                    list = null;
                                }
                            }
                            if (indexY >= 6 && GetFigure(indexX, indexY - 1, figures)?.Color != color1 && GetFigure(indexX, indexY - 1, figures)?.Color != color2)
                            {
                                if (indexX >= 0 && indexX <= 7 && indexY - 2 >= 0 && indexY - 2 <= 7)
                                {
                                    if (GetFigure(indexX, indexY - 2, figures) == null)
                                    {
                                        List<Figures> list = new List<Figures>();
                                        foreach (var i in figures)
                                        {
                                            list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                        }
                                        foreach (var l in list)
                                        {
                                            if (l.positionX == indexX && l.positionY == indexY - 2)
                                            {
                                                list.Remove(l);
                                                break;
                                            }
                                        }
                                        foreach (var i in list)
                                        {
                                            if (i.positionX == indexX && i.positionY == indexY)
                                            {

                                                i.positionX = indexX;
                                                i.positionY = indexY - 2;

                                            }
                                        }
                                        listOfLists.Add(list);                                        
                                        list = null;
                                    }
                                }
                            }
                            if (GetFigure(indexX + 1, indexY - 1, figures)?.Color == color2)
                            {
                                if (indexX + 1 >= 0 && indexX + 1 <= 7 && indexY - 1 >= 0 && indexY - 1 <= 7)
                                {
                                    List<Figures> list = new List<Figures>();
                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX + 1 && l.positionY == indexY - 1)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {
                                            
                                            i.positionX = indexX + 1;
                                            i.positionY = indexY - 1;
                                            
                                        }
                                    }
                                    listOfLists.Add(list);                                   
                                    list = null;
                                }
                            }
                            if (GetFigure(indexX - 1, indexY - 1, figures)?.Color == color2)
                            {
                                if (indexX - 1 >= 0 && indexX - 1 <= 7 && indexY - 1 >= 0 && indexY - 1 <= 7)
                                {
                                    List<Figures> list = new List<Figures>();
                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX - 1 && l.positionY == indexY - 1)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {
                                            
                                            i.positionX = indexX - 1;
                                            i.positionY = indexY - 1;
                                            
                                        }
                                    }
                                    listOfLists.Add(list);                                    
                                    list = null;
                                }
                            }                        
                        }
                    }
                    break;
                case "king":
                    {
                        List<Point> king = new List<Point>();
                        king.Add(new Point(0, 1));
                        king.Add(new Point(0, -1));
                        king.Add(new Point(1, 0));
                        king.Add(new Point(-1, 0));
                        king.Add(new Point(1, 1));
                        king.Add(new Point(1, -1));
                        king.Add(new Point(-1, 1));
                        king.Add(new Point(-1, -1));

                        
                        foreach (Point p in king)
                        {
                            if (GetFigure(indexX + p.x, indexY + p.y, figures)?.Color != color1)
                            {                                
                                if (indexX + p.x >= 0 && indexX + p.x <= 7 && indexY + p.y >= 0 && indexY + p.y <= 7)
                                {                                    
                                    List<Figures> list = new List<Figures>();
                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX + p.x && l.positionY == indexY + p.y)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {
                                            i.positionX = indexX + p.x;
                                            i.positionY = indexY + p.y;                                            
                                        }
                                    }
                                    listOfLists.Add(list);
                                    list = null;
                                }   
                            }
                        }
                        king.Clear();
                        king = null;
                    }
                    break;
                case "queen":
                    {
                        
                        int i = indexX, j = indexY;
                        while (i < 7 && i >= 0 && j < 7 && j >= 0)
                        {
                            i++;
                            j++;
                            if (GetFigure(i, j, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(i, j, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }

                        i = indexX;
                        j = indexY;
                        while (i <= 7 && i > 0 && j <= 7 && j > 0)
                        {
                            i--;
                            j--;
                            if (GetFigure(i, j, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(i, j, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }
                        i = indexX;
                        j = indexY;
                        while (i < 7 && i >= 0 && j <= 7 && j > 0)
                        {
                            i++;
                            j--;
                            if (GetFigure(i, j, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(i, j, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }
                        i = indexX;
                        j = indexY;
                        while (i <= 7 && i > 0 && j < 7 && j >= 0)
                        {
                            i--;
                            j++;
                            if (GetFigure(i, j, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(i, j, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }


                        i = indexX;
                        j = indexY;
                        for (int t = indexX - 1; t >= 0; t--)
                        {
                            if (GetFigure(t, j, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == t && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = t;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(t, j, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == t && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = t;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }
                        i = indexX;
                        j = indexY;
                        for (int t = indexX + 1; t <= 7; t++)
                        {
                            if (GetFigure(t, j, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == t && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = t;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(t, j, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == t && l.positionY == j)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = t;
                                        f.positionY = j;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }
                        i = indexX;
                        j = indexY;
                        for (int t = indexY - 1; t >= 0; t--)
                        {
                            if (GetFigure(i, t, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == t)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = t;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(i, t, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == t)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = t;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }
                        i = indexX;
                        j = indexY;
                        for (int t = indexY + 1; t <= 7; t++)
                        {
                            if (GetFigure(i, t, figures)?.Color == color2)
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == t)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = t;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                                break;
                            }
                            else if (GetFigure(i, t, figures)?.Color == color1)
                            {
                                break;
                            }
                            else
                            {
                                List<Figures> list = new List<Figures>();
                                foreach (var f in figures)
                                {
                                    list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                                }
                                foreach (var l in list)
                                {
                                    if (l.positionX == i && l.positionY == t)
                                    {
                                        list.Remove(l);
                                        break;
                                    }
                                }
                                foreach (var f in list)
                                {
                                    if (f.positionX == indexX && f.positionY == indexY)
                                    {
                                        f.positionX = i;
                                        f.positionY = t;
                                        //MessageBox.Show(f.positionX + "  " + f.positionY);
                                    }
                                }
                                listOfLists.Add(list);
                                list = null;
                            }
                        }                    
                    }
                    break;
                case "knight":
                    {
                        List<Point> knight = new List<Point>();
                        knight.Add(new Point(2, 1));
                        knight.Add(new Point(2, -1));
                        knight.Add(new Point(1, 2));
                        knight.Add(new Point(1, -2));
                        knight.Add(new Point(-1, 2));
                        knight.Add(new Point(-1, -2));
                        knight.Add(new Point(-2, 1));
                        knight.Add(new Point(-2, -1));

                                                
                        foreach (Point p in knight)
                        {
                            if (GetFigure(indexX + p.x, indexY + p.y, figures)?.Color != color1)
                            {
                                if ((indexX + p.x) >= 0 && (indexX + p.x) <= 7 && (indexY + p.y) >= 0 && (indexY + p.y) <= 7)
                                {                                    
                                    List<Figures> list = new List<Figures>();
                                    foreach (var i in figures)
                                    {
                                        list.Add(new Figures(i.Name, i.positionX, i.positionY, i.Color, i.ImgSource));
                                    }
                                    foreach (var l in list)
                                    {
                                        if (l.positionX == indexX + p.x && l.positionY == indexY + p.y)
                                        {
                                            list.Remove(l);
                                            break;
                                        }
                                    }
                                    foreach (var i in list)
                                    {
                                        if (i.positionX == indexX && i.positionY == indexY)
                                        {
                                            i.positionX = indexX + p.x;
                                            i.positionY = indexY + p.y;                                            
                                        }
                                    }                                
                                    listOfLists.Add(list);
                                    list = null;
                                }
                            }
                        }
                        knight.Clear();
                        knight = null;
                    }
                    break;
                case "rook":
                    AddRookSteps(indexX, indexY, figures);
                    break;
                default:
                    AddBishopSteps(indexX, indexY, figures);
                    break;
            }
        }
        public void AddBishopSteps(int indexX, int indexY, List<Figures> figures)
        {
            
            int i = indexX, j = indexY;
            while (i < 7 && i >= 0 && j < 7 && j >= 0)
            {
                i++;
                j++;
                if (GetFigure(i, j, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);                   
                }
            }

            i = indexX;
            j = indexY;
            while (i <= 7 && i > 0 && j <= 7 && j > 0)
            {
                i--;
                j--;
                if (GetFigure(i, j, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                }
            }
            i = indexX;
            j = indexY;
            while (i < 7 && i >= 0 && j <= 7 && j > 0)
            {
                i++;
                j--;
                if (GetFigure(i, j, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);                    
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                }
            }
            i = indexX;
            j = indexY;
            while (i <= 7 && i > 0 && j < 7 && j >= 0)
            {
                i--;
                j++;
                if (GetFigure(i, j, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                    break;
                }
                else if (GetFigure(i, j, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = j;
                            
                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                }
            }           
        }
        public void AddRookSteps(int indexX, int indexY, List<Figures> figures)
        {
            
            int i = indexX, j = indexY;
            for (int t = indexX - 1; t >= 0; t--)
            {
                if (GetFigure(t, j, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == t && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = t;
                            f.positionY = j;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                    break;
                }
                else if (GetFigure(t, j, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == t && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = t;
                            f.positionY = j;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                }
            }
            i = indexX;
            j = indexY;
            for (int t = indexX + 1; t <= 7; t++)
            {
                if (GetFigure(t, j, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == t && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = t;
                            f.positionY = j;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                    break;
                }
                else if (GetFigure(t, j, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == t && l.positionY == j)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = t;
                            f.positionY = j;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                }
            }
            i = indexX;
            j = indexY;
            for (int t = indexY - 1; t >= 0; t--)
            {
                if (GetFigure(i, t, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == t)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = t;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                    break;
                }
                else if (GetFigure(i, t, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == t)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = t;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                }
            }
            i = indexX;
            j = indexY;
            for (int t = indexY + 1; t <= 7; t++)
            {
                if (GetFigure(i, t, figures)?.Color == color2)
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == t)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = t;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                    break;
                }
                else if (GetFigure(i, t, figures)?.Color == color1)
                {
                    break;
                }
                else
                {
                    List<Figures> list = new List<Figures>();
                    foreach (var f in figures)
                    {
                        list.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
                    }
                    foreach (var l in list)
                    {
                        if (l.positionX == i && l.positionY == t)
                        {
                            list.Remove(l);
                            break;
                        }
                    }
                    foreach (var f in list)
                    {
                        if (f.positionX == indexX && f.positionY == indexY)
                        {
                            f.positionX = i;
                            f.positionY = t;

                        }
                    }
                    listOfLists.Add(list);
                    list = null;
                }
            }         
        }
        
        public static List<Figures> GetNewBoard(List<Figures> list, Steps steps)
        {
            List<Figures> newList = new List<Figures>();
            foreach(var l in list)
            {
                newList.Add(new Figures(l.Name, l.positionX, l.positionY, l.Color, l.ImgSource));
            }

            foreach (var l in newList)
            {
                if (l.positionX == steps.endPosX && l.positionY == steps.endPosY)
                {
                    newList.Remove(l);
                    break;
                }
            }

            foreach (var l in newList)
            {                
                if(l.positionX == steps.startPosX && l.positionY == steps.startPosY)
                {                    
                    l.positionX = steps.endPosX;
                    l.positionY = steps.endPosY;                    
                }
            }
            
            return newList;
        }
        List<Figures> newFigures = new List<Figures>();
        public List<List<Figures>> GetAllSteps(List<Figures> figures, string color) 
        {
            listOfLists.Clear();
            newFigures.Clear();
            foreach(var f in figures)
            {
                newFigures.Add(new Figures(f.Name, f.positionX, f.positionY, f.Color, f.ImgSource));
            }
            listOfLists.Clear();
            foreach(var f in newFigures)
            {
                if(f.Color == color)
                {
                    AddFigureSteps(f.Name, f.positionX, f.positionY, newFigures);
                }
            }
            return listOfLists;
        }

        List<List<Figures>> listOfList2 = new List<List<Figures>>();
        Dictionary<string, List<Figures>> newDictionary = new Dictionary<string, List<Figures>>();
        List<string> newKeys = new List<string>();
        public string[] CreateNodes(string[] keys, Dictionary<string, List<Figures>> dictionary, string color)
        {            
            color1 = color;
            if (color1 == "white")
                color2 = "black";
            else color2 = "white";
            GC.Collect();
            newDictionary.Clear();
            foreach (var d in dictionary)
            {
                newDictionary.Add(d.Key, d.Value);
            }

            newKeys.Clear();
            for(int i = 0; i < keys.Length; i++)
            {
                GC.Collect();
                listOfList2.Clear();
                listOfList2 = GetAllSteps(newDictionary[keys[i]], color);                
                for (int j = 0; j < listOfList2.ToArray().Length; j++)
                {
                    dictionary.Add(keys[i] + " " + j, listOfList2[j]);
                    newKeys.Add(keys[i] + " " + j);
                }              
            }
            newDictionary.Clear();       
            return newKeys.ToArray();
        }
    }
}
