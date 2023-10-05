using Chrome___Firefox_Db_Project.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Chrome___Firefox_Db_Project
{
    public partial class MainWindow : Window
    {
        readonly DataViewModel viewmodel = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => DataContext = viewmodel;

        private void QueryText_KeyUp(object sender, KeyEventArgs e)
        {
            Processing.Visibility = Visibility.Visible;
            string Query = QueryText.Text;
            if (e.Key == Key.Enter && !(viewmodel.ExecuteQuery(Query)))
                MessageBox.Show("Invalid Query!...");
            Processing.Visibility = Visibility.Collapsed;
        }
    }
}