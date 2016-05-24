using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
using TrapClasses;


namespace Trap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int gridSize = 10;
        MapContext map;

        public MainWindow()
        {
            InitializeComponent();
            map = new MapContext();
        }

        private void CreateCanvas()
        {
            var placeholder = GetBitmapImage(Trap.Properties.Resources.placeholder);
            ImageSource source = placeholder;
            for (int y = 0; y < gridSize; y++)
            {
                int x = 0;
                int rowSize = 9;
                if(y%2==0){
                    x = 1;
                    rowSize = gridSize;
                }
                for (; x < rowSize; x++)
                {
                    Canvas canvas = new Canvas();
                    canvas.Width = mainGrid.ActualWidth / 10;
                    canvas.Height = mainGrid.ActualHeight / 10;
                    canvas.MouseUp += canvas_MouseUp;
                    Grid.SetColumn(canvas, x);
                    Grid.SetRow(canvas, y);
                   
                    System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                    image.Source = source;
                    image.Height = canvas.Height;
                    image.Width = canvas.Width;

                    canvas.Children.Add(image);
                    mainGrid.Children.Add(canvas);
                    map.PossibleSpaces.Add(new Tuple<int, int>(x,y));
                    if (x == 5 && y == 5)
                    {
                        MoveComputer(new Tuple<int, int>(x,y));
                    }
                }
            }
        }

        void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            int column = (int)canvas.GetValue(Grid.RowProperty);
            int row = (int)canvas.GetValue(Grid.ColumnProperty);
            if (canvas.Children.Count < 2)
            {
                MovePlayer(canvas);
                Tuple<int, int> position = new Tuple<int, int>(row, column);
                map.BlockedSpaces.Add(position);

                if (map.BlockedSpaces.Count == 1)
                {
                    SetDirection();
                }
                Tuple<int, int> move = map.Strategy.Analyze(map.CurrentPosition, map.BlockedSpaces);
                if (move == null)
                {
                    WinWindow window = new WinWindow();
                    window.Show();
                    this.Close();
                }
                else if (!map.PossibleSpaces.Exists(x => x.Item1 == move.Item1 && x.Item2 == move.Item2))
                {
                    WinWindow window = new WinWindow();
                    window.Show();
                    this.Close();
                }
                else
                {
                    ResetPosition(map.CurrentPosition);
                    MoveComputer(move);
                }
            }
            
        }

        private Canvas GetCanvasChild(Tuple<int,int> point)
        {
            Canvas element = mainGrid.Children.Cast<Canvas>().
                FirstOrDefault(e => Grid.GetColumn(e) == point.Item1 && Grid.GetRow(e) == point.Item2);
            return element;
        }

        void ResetPosition(Tuple<int, int> position)
        {
            var placeholder = GetBitmapImage(Trap.Properties.Resources.placeholder);
            ImageSource source = placeholder;
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = source;
            Canvas canvas = GetCanvasChild(position);
            canvas.Children.Clear();
            image.Height = canvas.Height;
            image.Width = canvas.Width;

            canvas.Children.Add(image);
        }

        void MoveComputer(Tuple<int, int> position)
        {
            map.CurrentPosition = position;
            Canvas canvas = GetCanvasChild(position);
            var placeholder = GetBitmapImage(Trap.Properties.Resources.pig);
            ImageSource source = placeholder;
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = source;
            image.Height = canvas.Height;
            image.Width = canvas.Width;

            canvas.Children.Add(image);
        }

        void MovePlayer(Canvas canvas)
        {
            var placeholder = GetBitmapImage(Trap.Properties.Resources.brick);
            ImageSource source = placeholder;
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = source;
            image.Height = canvas.Height;
            image.Width = canvas.Width;

            canvas.Children.Add(image);
        }

        private BitmapImage GetBitmapImage(Bitmap bitmap)
        {
            
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateCanvas();
        }

        private void SetDirection(){
            var firstPosition = map.BlockedSpaces.First();
            if (firstPosition.Item1 > 5)
            {
                if (firstPosition.Item2 > 5)
                {
                    map.SetStrategy(new NorthWestStrategy());
                }
                else
                {
                    map.SetStrategy(new SouthWestStrategy());
                }

            }
            else
            {
                if (firstPosition.Item2 > 5)
                {
                    map.SetStrategy(new NorthEastStrategy());
                }
                else
                {
                    map.SetStrategy(new SouthEastStrategy());
                }

            }
        }
    }
}
