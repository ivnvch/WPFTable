using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTable.BusinessLogic.Implementations;
using WPFTable.Models;

namespace WPFTable
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        DataContext _context = new DataContext();
        CarService _service;
        Car _car = new Car();
        public ChangeWindow()
        {
            _service = new CarService(_context);
            InitializeComponent();
        }

        private void ChangeCar_Click(object sender, RoutedEventArgs e)
        {
            Change();
        }

        public void ShowData(Car car)
        {
            ModelChange.Text = car.Model;
            MarkChange.Text = car.Mark;
            MaxSpeedChange.Text = car.MaxSpeed.ToString();
            _car = car;
        }

        private void Change()
        {
            _car.Model = ModelChange.Text;
            _car.Mark = MarkChange.Text;
            _car.MaxSpeed = int.Parse(MaxSpeedChange.Text);
            _service.Update(_car);
        }
    }
}
