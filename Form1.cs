namespace Coursework
{
    public partial class Form1 : Form
    {
        //ссылка на 2 окно
        Window2 window2;
        //для рисования
        Graphics g;
        //Ссылки на объекты генетора
        MazeGenerator MazeGenerator;
        MazeGeneratorCell[,] Maze;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //передадим ссылку на объекты
            this.MazeGenerator = DataStorage.MazeGenerator;
            this.Maze = DataStorage.Maze;
            g = CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void У(object sender, EventArgs e)
        {

        }
        //нажатие на удалить
        private void Remove_Click(object sender, EventArgs e)
        {
            //освобождаем память
            if (window2 != null)
            {
                window2.Close();
                window2.Dispose();
            }
        }
        //нажатие на Создать
        private void Generate_Click(object sender, EventArgs e)
        {
            //проверка возможности правильности входных данных
            bool t1 = !int.TryParse(Width.Text, out int a);
            bool t2 = !int.TryParse(Height.Text, out int b);
            t1 = t1 || t2;
            t2 = !Double.TryParse(Complexity.Text, out double c);
            t1 = t1 || t2;
            //число выходов может быть опущено
            if(ExitNumb.Text != "")
            {
                t2 = !int.TryParse(ExitNumb.Text, out int d);
                t1 = t1 || t2;
            }
            if (t1) MessageBox.Show("Ошибка. Убедитесь в правильности введенных данных.");
            else
            {
                //конвертация для чтения методами лабиринта
                int w = Convert.ToInt32(Width.Text);
                int h = Convert.ToInt32(Height.Text);
                double compl = Convert.ToDouble(Complexity.Text);
                //если число выходов не введено, то оно считается равным 1
                if (ExitNumb.Text != "")
                {
                    int en = Convert.ToInt32(ExitNumb.Text);
                    MazeGenerator = new MazeGenerator(w, h, compl, en);
                }
                else MazeGenerator = new MazeGenerator(w, h, compl);
                //проверка возможности генерации
                if (MazeGenerator.GenerateAble())
                {
                    //успешно, открываем окно с лабиринтом
                    DataStorage.Maze = MazeGenerator.GenerateMaze();
                    //если окно открыто или на нее выделена память, закрываем ее и освобождаем память
                    if(window2 != null)
                    {
                        window2.Close();
                        window2.Dispose();
                    }
                    //выделяем память и открываем
                    window2 = new Window2();
                    window2.Show();
                    //рисуем на новом окне
                    DataStorage.DrawTheMaze();
                }
                //вывод ошибки
                else MessageBox.Show(MazeGenerator.ExceptionFinder());

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}