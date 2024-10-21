namespace Coursework
{
    public partial class Form1 : Form
    {
        //������ �� 2 ����
        Window2 window2;
        //��� ���������
        Graphics g;
        //������ �� ������� ��������
        MazeGenerator MazeGenerator;
        MazeGeneratorCell[,] Maze;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //��������� ������ �� �������
            this.MazeGenerator = DataStorage.MazeGenerator;
            this.Maze = DataStorage.Maze;
            g = CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void �(object sender, EventArgs e)
        {

        }
        //������� �� �������
        private void Remove_Click(object sender, EventArgs e)
        {
            //����������� ������
            if (window2 != null)
            {
                window2.Close();
                window2.Dispose();
            }
        }
        //������� �� �������
        private void Generate_Click(object sender, EventArgs e)
        {
            //�������� ����������� ������������ ������� ������
            bool t1 = !int.TryParse(Width.Text, out int a);
            bool t2 = !int.TryParse(Height.Text, out int b);
            t1 = t1 || t2;
            t2 = !Double.TryParse(Complexity.Text, out double c);
            t1 = t1 || t2;
            //����� ������� ����� ���� �������
            if(ExitNumb.Text != "")
            {
                t2 = !int.TryParse(ExitNumb.Text, out int d);
                t1 = t1 || t2;
            }
            if (t1) MessageBox.Show("������. ��������� � ������������ ��������� ������.");
            else
            {
                //����������� ��� ������ �������� ���������
                int w = Convert.ToInt32(Width.Text);
                int h = Convert.ToInt32(Height.Text);
                double compl = Convert.ToDouble(Complexity.Text);
                //���� ����� ������� �� �������, �� ��� ��������� ������ 1
                if (ExitNumb.Text != "")
                {
                    int en = Convert.ToInt32(ExitNumb.Text);
                    MazeGenerator = new MazeGenerator(w, h, compl, en);
                }
                else MazeGenerator = new MazeGenerator(w, h, compl);
                //�������� ����������� ���������
                if (MazeGenerator.GenerateAble())
                {
                    //�������, ��������� ���� � ����������
                    DataStorage.Maze = MazeGenerator.GenerateMaze();
                    //���� ���� ������� ��� �� ��� �������� ������, ��������� �� � ����������� ������
                    if(window2 != null)
                    {
                        window2.Close();
                        window2.Dispose();
                    }
                    //�������� ������ � ���������
                    window2 = new Window2();
                    window2.Show();
                    //������ �� ����� ����
                    DataStorage.DrawTheMaze();
                }
                //����� ������
                else MessageBox.Show(MazeGenerator.ExceptionFinder());

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}