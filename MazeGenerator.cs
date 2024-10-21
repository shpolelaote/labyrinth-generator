using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class MazeGenerator
    {
        //переменные для входных параметров
        public int Width, Height, NumberOfExits;
        public double MazeComplexity;
        private MazeGeneratorCell[,] maze;
        
        int MinWinLength; //минимальная длина пути до одного из заданных выходов
        int MaxWinLength; //аналогично максимальная величина
        public MazeGeneratorCell[] Exits;
        public bool GenerateAble()
        {
            if (ExceptionFinder() == "Верные входные данные")
                return true;
            return false;
        }
        //конструктор класса
        public MazeGenerator(int Width, int Height, double Complexity, int NumberOfExits = 1)
        {
            this.Width = Width;
            this.Height = Height;
            this.MazeComplexity = Complexity;
            this.NumberOfExits = NumberOfExits;

            //дробную часть отбрасываем, т.к. длина целая
            MinWinLength = (int) ((double)(Width * Height) * (Complexity));
            //Проверка правильности вводных данных
        }
        public string ExceptionFinder()
        {
            //запрет на введение чисел меньше или равных нулю
            if (Width <= 0 || Height <= 0 || MazeComplexity <= 0 || NumberOfExits <= 0) return "Введены отрицательные или нулевые значения";

            if ((MazeComplexity > 1)) return "Сложность <= 1"; 
            //длина пути кратчайшего решения лабиринта
            //должна быть не равной 0
            if ((int)((double)(Width * Height) * (MazeComplexity)) == 0) return "Неверные размеры для такой сложности";

            //минимальная площадь лабиринта равна 2
            if (Width == 1)
            {
                if (Height == 1) return "Площадь лабиринта при введенных данных < 2";
            }
            //проверка на возможность вмещения заданного числа выходов
            if(Width*Height - MinWinLength < NumberOfExits - 1) return "Число выходов не может быть реализовано для такой сложности и размеров";
            return "Верные входные данные";
        }
        //сам метод генератор лабиринта
        public MazeGeneratorCell[,] GenerateMaze()
        {
            //создаем матрицу клеток
            MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
                }
            }
            //проверка на правильность входных данных
            if (ExceptionFinder() != "Верные входные данные") throw new Exception("Неверные входные данные.");
            //приводим матрицу к виду лабиринта
            Mazer(maze);
            this.maze = maze;
            //поиск выходов при потребности
            ExitChooser();
            maze[0, 0].IsStart = true;
            return this.maze;
        }
        //метод для счета количества посещенных клеток
        private int VisitedCount(MazeGeneratorCell[,] maze)
        {
            int count = 0;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j].IsVisited) count++;
                }
            }
            return count;
        }
        //метод преобразует матрицу клеток в лабиринт
        private void Mazer(MazeGeneratorCell[,] maze)
        {
            //выделим память для массива выходов
            Exits = new MazeGeneratorCell[NumberOfExits];
            //создадим временную ссылку на клетки, на строке ниже она ссылается на начальную
            MazeGeneratorCell current = maze[0, 0];
            current.IsVisited = true;
            current.DistanceFromStart = VisitedCount(maze);
            //направление продвижения для ген. 1 части
            //здесь принимает R (вправо), L, DR, DL (down from left)
            string Orientation = "R";
            //временные переменные
            var x = current.X;
            var y = current.Y;

            //ниже идет генерация первой части лабиринта
            while (VisitedCount(maze) != MinWinLength)
            {
                if (Orientation == "R")
                {
                    //проверка на нахождение текущей клетки не у границы
                    if (x < Width - 1)
                    {
                        RemoveNeighbourWall(current, maze[x + 1, y]);
                        current = maze[x + 1, y];
                    }
                    //теперь лабиринт будет расширяться вниз
                    else
                    {
                        RemoveNeighbourWall(current, maze[x, y + 1]);
                        current = maze[x, y + 1];
                        Orientation = "DR";
                    }
                }
                else if (Orientation == "L")
                {
                    //проверка на нахождение текущей клетки не у границы
                    if (x > 0)
                    {
                        RemoveNeighbourWall(current, maze[x - 1, y]);
                        current = maze[x - 1, y];
                    }
                    //теперь лабиринт будет расширяться вниз
                    else
                    {
                        RemoveNeighbourWall(current, maze[x, y + 1]);
                        current = maze[x, y + 1];
                        Orientation = "DL";
                    }
                }
                //находится у правой границы?
                else if (Orientation == "DR")
                {
                    //если ширина лабиринта не равна 1, то выполняется в привычном порядке
                    if (maze.GetLength(0) != 1)
                    {
                        RemoveNeighbourWall(current, maze[x - 1, y]);
                        current = maze[x - 1, y];
                        Orientation = "L";
                    }
                    //иначе это прямой лабиринт вниз и ориентация сохраняется
                    else
                    {
                        RemoveNeighbourWall(current, maze[x, y + 1]);
                        current = maze[x, y + 1];
                    }
                }
                //находится у левой границы?
                else if (Orientation == "DL")
                {
                    RemoveNeighbourWall(current, maze[x + 1, y]);
                    current = maze[x + 1, y];
                    Orientation = "R";
                }
                //отмечаем следующую клетку посещенной
                //увеличиваем переменную длины 1 части лаб.
                current.DistanceFromStart = VisitedCount(maze);
                x = current.X;
                y = current.Y;
                maze[x, y].IsVisited = true;
            }
            //объявим выходом клетку с длиной до старта равным MinWinLenth 
            Exits[0] = current;
            Exits[0].IsExit = true;

            //ниже идет генерация второй части лабиринта
            Stack<MazeGeneratorCell> open = new Stack<MazeGeneratorCell>();
            //создадим объект для рандомизации
            Random random = new Random();
            //Пока есть непосещенные клетки идет цикл
            while(IsThereUnvisited(maze))
            {
                //лист соседних клеток
                List<MazeGeneratorCell> UnvisitedNeighbours = new List<MazeGeneratorCell>();

                //для удобства
                x = current.X; y = current.Y;

                //добавление непосещенных соседних текущей клетке ячеек в лист
                if (x > 0 && !maze[x - 1, y].IsVisited) UnvisitedNeighbours.Add(maze[x - 1, y]);
                if (y > 0 && !maze[x, y - 1].IsVisited) UnvisitedNeighbours.Add(maze[x, y - 1]);
                if (x < Width - 1 && !maze[x + 1, y].IsVisited) UnvisitedNeighbours.Add(maze[x + 1, y]);
                if (y < Height - 1 && !maze[x, y + 1].IsVisited) UnvisitedNeighbours.Add(maze[x, y + 1]);

                //если есть такие соседние клетки то выбираем одну из них:
                if (UnvisitedNeighbours.Count > 0)
                {
                    //выбор следующей клетки случайным образом
                    MazeGeneratorCell chosen = UnvisitedNeighbours[random.Next(0, UnvisitedNeighbours.Count)];
                    //убираем между ними стену
                    RemoveNeighbourWall(chosen, current);

                    //вводим ее расстояние от старта, объявляем посещенной,
                    //вносим в стек и считаем ее текущей
                    chosen.DistanceFromStart = current.DistanceFromStart + 1;
                    chosen.IsVisited = true;
                    open.Push(chosen);
                    current = chosen;

                    //Поиск самого длинного маршрута в лабиринте
                    if(current.DistanceFromStart > MaxWinLength) 
                        MaxWinLength = current.DistanceFromStart;
                }
                //если нужных соседних клеток нет, то извлекаем
                //клетку из стека и объявляем текущей 
                else
                {
                    current = open.Pop();
                }
            }
        }
        //выполняет поиск выходов для лабиринта
        public void ExitChooser()
        {
            //если число выходов было ведено 1, то выбор новых выходов не нужен
            if (NumberOfExits == 1) return;
            //рандомайзер
            Random random = new();

            //поиск выходов
            for (int i = 1; i < NumberOfExits; i++)
            {
                //ищем клетку, походящую для выхода
                while (Exits[i] == null || Exits[i]?.DistanceFromStart < MinWinLength)
                {
                    int x = random.Next(maze.GetLength(0));
                    int y = random.Next(maze.GetLength(1));
                    //важно, чтобы потенциальной клетки уже не было в списке найденных выходов
                    if (!Exits.Contains(maze[x,y])) Exits[i] = maze[x, y];
                }
                Exits[i].IsExit = true;
            }
        }
        //проверяет, есть ли среди клеток непосещенные,
        //если есть, то выводит true
        private bool IsThereUnvisited(MazeGeneratorCell[,] Visited)
        {
            for (int i = 0; i < Visited.GetLength(0); i++)
            {
                for (int j = 0; j < Visited.GetLength(1); j++)
                {
                    if (!Visited[i, j].IsVisited) return true;
                }
            }
            return false;
        }
        //метод для удаления стены между соседними клетками
        private void RemoveNeighbourWall(MazeGeneratorCell a, MazeGeneratorCell b)
        {
            //метод для СОСЕДНИХ клеток, поэтому
            //случай с клетками с одинаковыми коорд. выводит ошибку
            if (a.X == b.X && a.Y == b.Y)
            {
                throw new Exception("Попытка удаления стены между клетками с одинаковыми коорд.");
                return;
            }
            if (a.X == b.X)
            {
                if (a.Y > b.Y) { a.HasWallBottom = false; b.HasWallTop = false; }
                else { b.HasWallBottom = false; a.HasWallTop = false; }
            }
            else if (a.Y == b.Y)
            {
                if (a.X > b.X) { a.HasWallLeft = false; b.HasWallRight = false; }
                else { b.HasWallLeft = false; a.HasWallRight = false; }
            }
            //соседние по диагонали тоже выводят ошибку
            else throw new Exception("Попытка удаления стены между не соседними клетками.");
        }
    }
}
