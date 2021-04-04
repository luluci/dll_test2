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

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace dll_gui
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControl1 : Window
    {
        public data_container data_c = new data_container();

        public UserControl1()
        {
            InitializeComponent();
            
            DataContext = this.data_c;
        }

        public int get_slider()
        {
            return this.data_c.X;
        }
    }


    public class data_container : INotifyPropertyChanged
    {
        public int X { get; set; }

        public data_container()
        {
            this.X = 11;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string PropertyName)
        {
            var e = new PropertyChangedEventArgs(PropertyName);
            PropertyChanged?.Invoke(this, e);
        }
    }
}
