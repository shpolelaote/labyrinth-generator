using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Window2 : Form
    {
        //система координат, Т - размер плитки
        int X = 30, Y = 30, T = 15;
        //ссылки на объекты
        MazeGenerator MazeGenerator;
        MazeGeneratorCell[,] Maze;
        Graphics g2;
        public Window2()
        {
            //Передаем ссылки на общий банк данных и копируем их оттуда
            InitializeComponent();
            MazeGenerator = DataStorage.MazeGenerator;
            this.Maze = DataStorage.Maze;
            DataStorage.DrawTheMaze = this.DrawTheMaze;

            //выделяем память для возможности рисования
            g2 = CreateGraphics();
        }
        private void Window2_Paint(object sender, PaintEventArgs e)
        {
            //выделяем память объекту graphics
            if (g2 == null) g2 = CreateGraphics();
        }
        private void Window2_timer1(object sender, PaintEventArgs e)
        {
            //постоянное рисование
            g2.Clear(Color.White);
            DrawTheMaze();
        }
        public void CellDraw(MazeGeneratorCell c)
        {
            //рисование клеток лабиринта на окне
            Pen p1 = new Pen(Color.Black, T/5);
            //временные координаты
            var Xc = X + c.X * T;
            var Yc = Y + c.Y * T;
            //рисуем соответствующие стены
            if (c.HasWallLeft)
            {
                g2.DrawLine(p1, Xc, Yc + T, Xc, Yc);
            }
            if (c.HasWallRight)
            {
                g2.DrawLine(p1, Xc + T, Yc + T, Xc + T, Yc);
            }
            if (c.HasWallTop)
            {
                g2.DrawLine(p1, Xc, Yc + T, Xc + T, Yc + T);
            }
            if (c.HasWallBottom)
            {
                g2.DrawLine(p1, Xc, Yc, Xc + T, Yc);
            }
            //выход
            if (c.IsExit)
            {
                g2.DrawString("B", new Font("Times New Roman", T / 2, FontStyle.Regular), Brushes.Black, Xc, Yc);
            }
            //начальная точка
            else if (c.IsStart)
            {
                g2.DrawString("С", new Font("Times New Roman", T / 2, FontStyle.Regular), Brushes.Black, Xc, Yc);
            }
        }
        //метод рисования лабиринта
        public void DrawTheMaze()
        {
            //заполним окно белым цветом
            g2.Clear(Color.White);
            Maze = DataStorage.Maze;
            //зададим размер клетки
            T = Math.Min(this.Width, this.Height) / (int) (Math.Max(Maze.GetLength(0), Maze.GetLength(1)) * 1.4);
            //если лабиринт имеет громадные размеры, то размер клетки при рисовании должен быть равен заданному минимому (здесь 5)
            if (T < 4) T = 5;
            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    CellDraw(Maze[i, j]);
                }
            }
        }
    }
}