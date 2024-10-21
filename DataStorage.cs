using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    //класс для доступа через разные Forms
    static class DataStorage
    {
        public static MazeGenerator MazeGenerator;
        public static MazeGeneratorCell[,] Maze;
        //делегат для рисования на втором окне
        public static Action DrawTheMaze;
    }
}
