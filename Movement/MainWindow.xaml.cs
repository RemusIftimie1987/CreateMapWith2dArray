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

namespace Movement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model _Model;
        private ObjectType[,] MapArray;
        private Rectangle Packman;

        public MainWindow()
        {
            _Model = new Model();
            InitializeComponent();
            DataContext = _Model;

            MapArray = new ObjectType[_Model.Width, _Model.Height];
            FillMap();
            CreateMap();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    Canvas.SetLeft(Packman, Canvas.GetLeft(Packman) - _Model.Dimension);
                    break;
                case Key.Up:
                    Canvas.SetTop(Packman, Canvas.GetTop(Packman) - _Model.Dimension);
                    break;
                case Key.Down:
                    Canvas.SetTop(Packman, Canvas.GetTop(Packman) + _Model.Dimension);
                    break;
                case Key.Right:
                    Canvas.SetLeft(Packman, Canvas.GetLeft(Packman) + _Model.Dimension);
                    break;
            }
        }

        private void FillMap()
        {
            MapArray[0, 0] = ObjectType.Packman;
            MapArray[5, 3] = ObjectType.Obstacle;
            MapArray[5, 4] = ObjectType.Obstacle;
            MapArray[5, 6] = ObjectType.Monster;
        }

        private void CreateMap()
        {
            // todo _Model.Dimension * 20 refactor
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    var obj = MapArray[i, j];
                    
                    var rectangle = GetObject(obj);
                    


                    if (obj == ObjectType.Packman)
                    {
                        rectangle.Name = "Packman";
                    }

                    Map.Children.Add(rectangle);
                    Canvas.SetTop(rectangle, (i*_Model.Dimension));
                    Canvas.SetLeft(rectangle, (j*_Model.Dimension));

                    if (obj == ObjectType.Packman)
                    {
                        Packman = rectangle;
                        Canvas.SetZIndex(Packman, (int)999);                        
                    }
                }
            }            
        }

        private Rectangle GetObject(ObjectType type)
        {
            var brush = Brushes.AliceBlue;

            switch (type)
            {
                case ObjectType.Space:
                    brush = Brushes.White;
                    break;
                case ObjectType.Packman:
                    brush = Brushes.Green;
                    break;
                case ObjectType.Obstacle:
                    brush = Brushes.Blue;
                    break;
                case ObjectType.Coin:
                    brush = Brushes.Yellow;
                    break;
                case ObjectType.Monster:
                    brush = Brushes.Red;
                    break;
                default:
                    break;
            }

            return new Rectangle()
            {
                Width = _Model.Dimension,
                Height = _Model.Dimension,
                Fill = brush
            };
        }
    }
}
