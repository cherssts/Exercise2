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

namespace Exercise_project2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            Start();
        }


        #endregion




        #region Events or Actions

        /// <summary>
        /// The Reset Mechanism of the program
        /// </summary>
        private void Start()
        {
            _display_Box.IsReadOnly = true;



        }

        private void _button1_Click(object sender, RoutedEventArgs e)
        {
            var Win1 = new Window1();
            Win1.Show();
            _display_Box.Text = String.Empty;

        }



        private void _noSelection(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (_display_Box.SelectionLength > 0)
            {
                _display_Box.SelectionLength = 0;
            }

        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }


        #endregion

    }
}
