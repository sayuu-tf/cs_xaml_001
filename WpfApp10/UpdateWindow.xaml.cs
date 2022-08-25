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

namespace WpfApp10
{
    /// <summary>
    /// UpdateWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class UpdateWindow : Window
    {
        MainWindow _main;

        public UpdateWindow(MainWindow main)
        {
            _main = main;
            InitializeComponent();
            UpdateTextBox.Text = _main.SelectedPerson.Name;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateTextBox.Text == string.Empty)
                return;

            _main.UpdatePerson(UpdateTextBox.Text);
        }
    }
}
