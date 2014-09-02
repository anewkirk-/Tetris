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

namespace Tetris.Views.GameScreens
{
    /// <summary>
    /// Interaction logic for KeyBindingsMenu.xaml
    /// </summary>
    public partial class KeyBindingsMenu : UserControl
    {
        public KeyBindingsMenu()
        {
            InitializeComponent();
            List<Key> bindableKeys = new List<Key>() { Key.A, Key.B, Key.C, Key.D, Key.F, Key.G, Key.H, Key.I, Key.J, Key.K, Key.L, Key.M, Key.N, Key.O, Key.P, Key.Q, Key.R, Key.S, Key.T, Key.U, Key.V, Key.W, Key.X, Key.Y, Key.Z, Key.Space, Key.LeftShift, Key.RightShift, Key.LeftCtrl, Key.RightCtrl, Key.Enter, Key.Up, Key.Down, Key.Left, Key.Right };

            List<ComboBox> selectors = new List<ComboBox>() { P1MoveLeftBox, P1MoveRightBox, P1MoveSoftDropBox, P1MoveHardDropBox, P1MoveRotateBox, P2MoveHardBox, P2MoveLeftBox, P2MoveRightBox, P2MoveSoftDropBox, P2MoveHardBox, P2MoveRotateBox};

            foreach (ComboBox b in selectors)
            {
                b.ItemsSource = bindableKeys;
            }
        }
    }
}