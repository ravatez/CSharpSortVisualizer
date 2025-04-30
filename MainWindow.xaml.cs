using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SortingVisualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isFinished = false;
        private SortContextManager contextManager = new SortContextManager();
        private int[] currentArray;
        public MainWindow()
        {
            InitializeComponent();
            var currentArray = Utils.GetArrayWithRandomNumbers(10, 100, 50);
            DrawArray(currentArray);
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected algorithm from the ComboBox
            var selectedAlgorithm = (AlgorithmSelection.SelectedItem as ComboBoxItem)?.Content.ToString();
            Console.WriteLine(selectedAlgorithm);
            Base strategy = GetSortStrategy(selectedAlgorithm);
            if (strategy != null)
            {
                MessageBox.Show("Please select a valid sorting algorithm");
                return;
            }
            contextManager.AddContext(strategy);
            contextManager.AddElements(currentArray);
            contextManager.Sort();
            contextManager.Display();
            //for re-drawing
            DrawArray(currentArray);

        }
        private Base GetSortStrategy(string selectedAlgorithm)
        {
            switch (selectedAlgorithm)
            {
                case "QuickSort":
                    return new QuickSort();
                case "MergeSort":
                    return new MergeSort();
                case "BubbleSort":
                    return new BubbleSort();
                case "SelectionSort":
                    return new SelectionSort();
                case "InsertionSort":
                    return new InsertionSort();
                case "HeapSort":
                    return new HeapSort();
                case "BucketSort":
                    return new BucketSort();
                case "BogoSort":
                    return new TimSort();
                case "ShellSort":
                    return new ShellSort();
                case "CountingSort":
                    return new CountingSort();
                case "RadixSort":
                    return new RadixSort();
                case "GnomeSort":
                    return new GnomeSort();
                case "CombSort":
                    return new CombSort();
                case "PigeonholeSort":
                    return new PigeonholeSort();
                case "CycleSort":
                    return new CycleSort();
                default:
                    return null;
            }
        }
        private void DrawArray(int[] currentArray)
        {
            VisualizationCanvas.Children.Clear();
            double barWidth = VisualizationCanvas.ActualWidth/currentArray.Length;
            double canvasHeight = VisualizationCanvas.ActualHeight;

            for (int i = 0; i < currentArray.Length; i++)
            {
                double height = (currentArray[i]/100.0) * canvasHeight;
                var rect = new Rectangle
                {
                    Width = Math.Max(barWidth - 2, 1),
                    Height = height,
                    Fill = Brushes.SteelBlue
                };
                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                VisualizationCanvas.Children.Add(rect);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
