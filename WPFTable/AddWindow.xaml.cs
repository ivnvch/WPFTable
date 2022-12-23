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
using WPFTable.BusinessLogic.Implementations;
using WPFTable.Models;

namespace WPFTable
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        CarService _service;
        DataContext _context;
        public AddWindow()
        {
            InitializeComponent();
            _context = new DataContext();
            _service = new CarService(_context);
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCar();
        }

        void AddCar()
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите добавить эту модель?", "ds", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _service.Create(new Car() { Model = ModelAdd.Text, Mark = MarkAdd.Text, MaxSpeed = int.Parse(MaxSpeedAdd.Text) });
                }
                ModelAdd.Text = string.Empty;
                MarkAdd.Text = string.Empty;
                MaxSpeedAdd.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
