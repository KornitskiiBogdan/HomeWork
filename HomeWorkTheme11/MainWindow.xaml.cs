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
using System.Diagnostics;
using HomeWorkTheme11.Organization;

namespace HomeWorkTheme11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationViewModel.ApplicationViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new ApplicationViewModel.ApplicationViewModel();

        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = viewModel.company;

            organizationTree.ItemsSource = viewModel.company.Departments;
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            var company = Serialized.DeserializedJson();

            this.DataContext = company;

            organizationTree.ItemsSource = company.Departments;
        }

        private void SaveProject_Click(object sender, RoutedEventArgs e)
        {
            Serialized.SerializedJson(viewModel.company);
            MessageBox.Show("Project saved", $"{viewModel.company.CompanyName}", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
