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
using System.Runtime.InteropServices;



namespace Exercise_project2
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       
        public Window1()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            _inputBox.Focus();
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

        private void _dA(object sender, EventArgs e)
        {
            _forceWin.Activate();
            _forceWin.Focus();
            _inputBox.Focus();
            _forceWin.Topmost = true;
        }



        #region Lock Mouse in window
        /// <summary>
        /// Detect if the Cursor left the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _forceWin_MouseLeave(object sender, MouseEventArgs e)
        {
            //Declaration of the values for X Y values for the Position
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            //Creating a new POINT for the input
            Point pos = new Point();
            //Setting up the X, Y
            pos.X = (int)(screenWidth / 2) - (int)(windowWidth / 2);
            pos.Y = (int)(screenHeight / 2) - (int)(windowHeight / 2);

            //Set Cursor On These Coordinates if left the window
            SetCursorPos(pos.X + 100, pos.Y + 100);
        }

        /// <summary>   
        /// Mouse Pos Setting 
        /// </summary>   
        /// <param name="x">Vertical Pos</param>   
        /// <param name="y">Horizontal Pos</param>          

        [DllImport("User32")]

        public extern static void SetCursorPos(int x, int y);

        //struct can be used to hold small data values that do not require inheritance,
        //e.g. coordinate points, key-value pairs, and complex data structure.
        public struct Point
        {
            public int X;
            public int Y;
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

        }


        #endregion


        #region Key press
        private void _inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && _inputBox.Text.Length == 0 || _inputBox.Text ==" ")
            {
                MessageBoxResult _msg = MessageBox.Show("Please write something");
            }
            if(e.Key == Key.Escape)
            {
                Close();
            }
            if (e.Key == Key.Enter)
            {
                DataInOut data = new DataInOut();
                data.Record((string)_inputBox.Text);
                ((MainWindow)Application.Current.MainWindow)._display_Box.Text = data.GetData(((MainWindow)Application.Current.MainWindow)._display_Box.Text);
                Close();
            }

        }

        private void _forceWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }


        #endregion


    }
}
