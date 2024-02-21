using System.Diagnostics;

namespace ЛР_САОД_7._3._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainProcess(10000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainProcess(100000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainProcess(1000000);
        }

        private void MainProcess(int array_length)
        {
            decimal arrays_count = nud1.Value;
            long dt_bubble = 0;
            long dt_megre = 0;
            long dt_insertion = 0;
            long dt_shell = 0;
            long dt_quick = 0;
            Stopwatch sw = new Stopwatch();

            Clear();
            for (int i = 0; i < arrays_count; i++)
            {
                int[] array = new int[array_length];
                Random rnd = new Random();
                for (int k = 0; k < array_length; k++)
                {
                    array[k] = rnd.Next(0, array_length + 1);
                    /*listBox6.Items.Add(array[k]);*/
                }
                /*sw.Restart();
                Sort(array, "bubble");
                sw.Stop();
                dt_bubble += sw.ElapsedMilliseconds;*/

                /*sw.Restart();
                Sort(array, "insertion");
                sw.Stop();
                dt_insertion += sw.ElapsedMilliseconds;*/

                sw.Restart();
                Sort(array, "megre");
                sw.Stop();
                dt_megre += sw.ElapsedMilliseconds;

                sw.Restart();
                Sort(array, "shell");
                sw.Stop();
                dt_shell += sw.ElapsedMilliseconds;

                sw.Restart();
                Sort(array, "quick");
                sw.Stop();
                dt_quick += sw.ElapsedMilliseconds;
            }
            listBox7.Items.Add($"Количество сгенерированных массивов: {arrays_count}");
            listBox7.Items.Add($"Время работы пузырьковой сортировки: {Convert.ToString(Math.Round(dt_bubble / arrays_count, 2))} милисек.");
            listBox7.Items.Add($"Время работы сортировки слиянием: {Convert.ToString(sw.Elapsed.TotalSeconds.ToString())} милисек.");
            listBox7.Items.Add($"Время работы сортировки вставками: {Convert.ToString(Math.Round(dt_insertion / arrays_count, 2))} милисек.");
            listBox7.Items.Add($"Время работы сортировки Шелла: {Convert.ToString(Math.Round(dt_shell / arrays_count, 2))} милисек.");
            listBox7.Items.Add($"Время работы быстрой сортировки: {Convert.ToString(Math.Round(dt_quick / arrays_count, 2))} милисек.");
        }

        private void Sort(int[] array, string algorithm)
        {
            int[] array_copy = array;
            switch (algorithm)
            {
                case "bubble":
                    SortingAlgorithms.BubbleSort(array_copy);
                    /*for (int i = 0; i < array.Length; i++)
                        listBox1.Items.Add(array[i]);*/
                    break;
                case "insertion":
                    SortingAlgorithms.InsertionSort(array_copy);
                    /*for (int i = 0; i < array.Length; i++)
                        listBox3.Items.Add(array[i]);*/
                    break;
                case "megre":
                    SortingAlgorithms.MegreSort(array_copy);
                    /*for (int i = 0; i < array.Length; i++)
                        listBox2.Items.Add(array[i]);*/
                    break;
                case "shell":
                    SortingAlgorithms.ShellSort(array_copy);
                    /*for (int i = 0; i < array.Length; i++)
                        listBox5.Items.Add(array[i]);*/
                    break;
                case "quick":
                    SortingAlgorithms.QuickSort(array_copy, 0, array_copy.Length - 1);
                    /*for (int i = 0; i < array.Length; i++)
                        listBox4.Items.Add(array[i]);*/
                    break;
            }
        }

        private void Clear()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random _rnd = new Random();

            int[] array = new int[1000000];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = _rnd.Next(0,array.Length);
            }

            DateTime _tm1 = DateTime.Now;
            SortingAlgorithms.MegreSort(array);
            DateTime _tm2 = DateTime.Now;   

            var a = _tm2- _tm1;
         }
    }
}