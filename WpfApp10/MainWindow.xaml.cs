using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp10
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

        private int _index = 0;

        public Person SelectedPerson { get; set; }
        public int SelectedListViewIndex { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            _persons.Add(new Person { Id = ++_index, Name = "name" + _index });
            _persons.Add(new Person { Id = ++_index, Name = "name" + _index });
            _persons.Add(new Person { Id = ++_index, Name = "name" + _index });
            _persons.Add(new Person { Id = ++_index, Name = "name" + _index });
            PersonListView.ItemsSource = _persons;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SaveWindow sw = new SaveWindow(this);
            sw.Show();
            
        }

        public void SavePerson(string name)
        {
            if (SelectedPerson == null)
                return;

            _persons.Add(new Person { Id = ++_index, Name = name });
        }
        public void UpdatePerson(string name)
        {
            if (SelectedPerson == null)
                return;

            _persons.RemoveAt(SelectedListViewIndex);

            Person person = new Person() { Id = SelectedPerson.Id, Name = name };
            _persons.Insert(SelectedListViewIndex, person);
        }

        private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PersonListView.SelectedItem == null)
                return;

            SelectedPerson = (Person)PersonListView.SelectedItem;   //一旦ここで保存しておかないと、別画面に行ったときに、値がリセットされてしまう。
            SelectedListViewIndex = PersonListView.SelectedIndex;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPerson == null)
                return;

            _persons.Remove(SelectedPerson);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPerson == null)
                return;

            UpdateWindow uw = new UpdateWindow(this);
            uw.Show();
        }
    }
}
