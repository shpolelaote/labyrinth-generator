using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    //класс клетки лабиринта
    public class MazeGeneratorCell 
    {
        //координаты клетки
        public int X;
        public int Y;

        //по умолчанию, клетка должна иметь все стены
        public bool HasWallLeft = true;
        public bool HasWallRight = true;
        public bool HasWallTop = true;
        public bool HasWallBottom = true;

        //проверка на посещенность
        public bool IsVisited = false;
        public bool IsExit = false;
        public bool IsStart = false;

        //расстояние до стартовой клетки
        public int DistanceFromStart;
    }
}
