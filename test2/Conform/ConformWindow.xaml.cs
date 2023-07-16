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
using System.Windows.Shapes;

namespace test2.Conform
{
    /// <summary>
    /// Interaction logic for ConformWindow.xaml
    /// </summary>
    public partial class ConformWindow : Window
    {
        public ConformWindow(ConformWIndowVM vM)
        {
            InitializeComponent();
            DataContext = vM;
            vM.CloseAction = ()=> Close();
        }
    }
}
