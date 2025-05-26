using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Input;

namespace SortingVisualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private const int RECTANGLE_HEIGHT_FACTOR = 20;
        private const int RECTANGLE_WIDTH = 40;
        private const int RECTANGLE_MAX_HEIGHT = 300;
        private List<Rectangle> rectangles = new List<Rectangle>();
        private Random random = new Random();
        private int currentStep = 0;
        private int currentIndex = 0;
        private bool isPaused = false;
        private bool isRunning = false;
        private SortContextManager sortContextManager = new SortContextManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Sorting is already in progress.");
                return;
            }

            currentIndex = 0;
            currentStep = 0;
            isPaused = false;
            isRunning = true;

            rectangles.Clear();
            VisualizationCanvas.Children.Clear();
            int[] heights = new int[15];

            for (int j = 0; j < heights.Length; j++)
            {
                heights[j] = random.Next(20, RECTANGLE_MAX_HEIGHT);
            }

            InitializeRectangles(heights);

            string selectedAlgorithm = (AlgorithmSelection.SelectedItem as ComboBoxItem)?.Content.ToString();
            Console.WriteLine("Selected Sort Type: " + selectedAlgorithm);

            switch (selectedAlgorithm)
            {
                //Only 10 Sorting Algorithms Are Working For Now! Will Work on later...!!
                case "BubbleSort":
                    Console.WriteLine("BubbleSort strategy selected");
                    sortContextManager.SetStrategy(new BubbleSort());
                    break;
                case "QuickSort":
                    sortContextManager.SetStrategy(new QuickSort());
                    break;
                case "MergeSort":
                    sortContextManager.SetStrategy(new MergeSort());
                    break;
                case "SelectionSort":
                    sortContextManager.SetStrategy(new SelectionSort());
                    break;
                case "InsertionSort":
                    sortContextManager.SetStrategy(new InsertionSort());
                    break;
                case "HeapSort":
                    sortContextManager.SetStrategy(new HeapSort());
                    break;
                //case "BucketSort":
                //    sortContextManager.SetStrategy(new BucketSort());
                //    break;
                case "TimSort":
                    sortContextManager.SetStrategy(new TimSort());
                    break;
                case "ShellSort":
                    sortContextManager.SetStrategy(new ShellSort());
                    break;
                case "CountingSort":
                    sortContextManager.SetStrategy(new CountingSort());
                    break;
                case "RadixSort":
                    sortContextManager.SetStrategy(new RadixSort());
                    break;
                //case "GnomeSort":
                //    sortContextManager.SetStrategy(new GnomeSort());
                //    break;
                //case "CombSort":
                //    sortContextManager.SetStrategy(new CombSort());
                //    break;
                //case "PigeonholeSort":
                //    sortContextManager.SetStrategy(new PigeonholeSort());
                //    break;
                //case "CycleSort":
                //    sortContextManager.SetStrategy(new CycleSort());
                //    break;
                default:
                    MessageBox.Show("Please select a sorting algorithm.");
                    isRunning = false;
                    return;
            }
            isRunning = true;
            Console.WriteLine("Starting sort...");
            await sortContextManager.Sort(
                rectangles,
                async (i, j) => await AnimateSwap(i, j),
                async (i, j) =>
                {
                    HighlightRectangles(rectangles[i], rectangles[j], Brushes.Red);
                    await Task.Delay(100);
                    HighlightRectangles(rectangles[i], rectangles[j], Brushes.Blue);
                },
                () => isPaused,
                () => isRunning,
                (val) => isRunning = val
            );
            Console.WriteLine("Sort function returned");
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(selectedAlgorithm + " Completed!");
            });
        }
        private void PauseResume_Click(object sender, RoutedEventArgs e)
        {
            if (!isRunning) return;

            isPaused = !isPaused;
            PauseResume.Content = isPaused ? "Resume" : "Pause";
        }

        private void InitializeRectangles(int[] heights)
        {
            rectangles.Clear();
            VisualizationCanvas.Children.Clear();

            for (int i = 0; i < heights.Length; i++)
            {
                var rect = new Rectangle()
                {
                    Width = RECTANGLE_WIDTH,
                    Height = heights[i],
                    Fill = Brushes.Blue
                };

                Canvas.SetLeft(rect, i * (RECTANGLE_WIDTH + 10));
                Canvas.SetBottom(rect, 0);

                rectangles.Add(rect);
                VisualizationCanvas.Children.Add(rect); 
            }
        }
        private async Task AnimateSwap(int index1, int index2)
        {
            var rect1 = rectangles[index1];
            var rect2 = rectangles[index2];

            double left1 = Canvas.GetLeft(rect1);
            double left2 = Canvas.GetLeft(rect2);

            DoubleAnimation anim1 = new DoubleAnimation
            {
                From = left1,
                To = left2,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            DoubleAnimation anim2 = new DoubleAnimation
            {
                From = left2,
                To = left1,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            rect1.BeginAnimation(Canvas.LeftProperty, anim1);
            rect2.BeginAnimation(Canvas.LeftProperty, anim2);

            await Task.Delay(300);

            // Swap logical positions
            (rectangles[index1], rectangles[index2]) = (rectangles[index2], rectangles[index1]);
        }

        private void HighlightRectangles(Rectangle r1, Rectangle r2, Brush color)
        {
            r1.Fill = color;
            r2.Fill = color;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Placeholder if needed later
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Stop any ongoing sorting
            isRunning = false;
            isPaused = false;

            // Clear existing rectangles from UI
            VisualizationCanvas.Children.Clear();
            rectangles.Clear();

            MessageBox.Show("Reset complete!");
        }
    }
}
