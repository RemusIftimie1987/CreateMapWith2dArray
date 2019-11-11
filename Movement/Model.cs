using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    public class Model : INotifyPropertyChanged
    {
        private const int FixedDimension = 40;
        private const int RowCount = 20;
        private const int ColCount = 20;

        public Model()
        {
            Dimension = FixedDimension;
            Width = FixedDimension * RowCount;
            Height = FixedDimension * ColCount;
        }

        private int _Dimension;        
        public int Dimension
        {
            get { return _Dimension; }
            set { _Dimension = value; OnPropertyChanged("Dimension"); }
        }

        private int _Width;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; OnPropertyChanged("Width"); }
        }

        private int _Height;
        public int Height
        {
            get { return _Height; }
            set { _Height = value; OnPropertyChanged("Height"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
