using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;

using Path = System.IO.Path;

namespace SortingVisualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SortContextManager contextManager = new SortContextManager();
        private int[] currentArray;

        private CancellationTokenSource _cancellationTokenSource;

        private string _imageDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "CanvasFrames");

        private bool _isFinished = false;

        private bool _isRecording = true; // TODO Checkbox if recording is enabled
        private int _frameIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var currentArray = Utils.GetArrayWithRandomNumbers(1, 100, 50);
            Console.WriteLine(string.Join(", ", currentArray));
            await DrawArray(currentArray.ToList());
        }
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected algorithm from the ComboBox
            var selectedAlgorithm = (AlgorithmSelection.SelectedItem as ComboBoxItem)?.Content.ToString();
            Console.WriteLine(selectedAlgorithm);
            Base strategy = GetSortStrategy(selectedAlgorithm);
            if (strategy == null)
            {
                MessageBox.Show("Please select a valid sorting algorithm");
                return;
            }
            var currentArray = Utils.GetArrayWithRandomNumbers(1, 100, 50);
            if (currentArray == null || currentArray.Length == 0)
            {
                MessageBox.Show("Generated array is empty. Cannot proceed.");
                return;
            }
            contextManager.AddContext(strategy);
            contextManager.AddElements(currentArray);
            
            contextManager.Sort();
            contextManager.Display();
            //for re-drawing
            
            await DrawArray(currentArray.ToList());

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
        //private void DrawArray(int[] currentArray)
        //{
        //    if (currentArray == null || currentArray.Length == 0) return;

        //    VisualizationCanvas.Children.Clear();

        //    double canvasWidth = VisualizationCanvas.ActualWidth;
        //    double canvasHeight = VisualizationCanvas.ActualHeight;

        //    double barWidth = canvasWidth / currentArray.Length;

        //    for (int i = 0; i < currentArray.Length; i++)
        //    {
        //        double height = Math.Max((currentArray[i] / 100.0) * canvasHeight, 1);
        //        Rectangle rect = new Rectangle
        //        {
        //            Width = Math.Max(barWidth - 2, 1),
        //            Height = height,
        //            Fill = Brushes.SteelBlue
        //        };

        //        Canvas.SetLeft(rect, i * barWidth);
        //        Canvas.SetBottom(rect, 0);
        //        VisualizationCanvas.Children.Add(rect);
        //    }
        //}

        public async Task DrawArray(List<int> array, bool isFinished = false)
        {
            VisualizationCanvas.Children.Clear();

            if (array == null || array.Count == 0) return;

            int barWidth = (int)(VisualizationCanvas.ActualWidth / array.Count);
            double canvasHeight = VisualizationCanvas.ActualHeight;

            for (int i = 0; i < array.Count; i++)
            {
                var rect = new Rectangle
                {
                    Height = (array[i] / 100.0) * canvasHeight,
                    Width = Math.Max(barWidth - 2, 1),
                    Fill = isFinished ? Brushes.Green : Brushes.SteelBlue
                };
                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                VisualizationCanvas.Children.Add(rect);
            }

            if (_isRecording)
            {
                var imagePath = Path.Combine(_imageDirectory, $"frame{_frameIndex:D4}.png");
                //SaveCanvasAsImage(VisualizationCanvas, imagePath);
                _frameIndex++;
            }

            await Task.Delay(500); // Controls animation speed
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
