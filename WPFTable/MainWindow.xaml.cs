using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using WPFTable.BusinessLogic.Implementations;
using WPFTable.Models;


namespace WPFTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataContext _context = new DataContext();
        CarService _carService;
        public MainWindow()
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _context.Database.EnsureCreated();
            //var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            //IMapper mapper = mappingConfig.CreateMapper();
            _carService = new CarService(_context);
            _context.Cars.Load();
            DGTable.ItemsSource = _context.Cars.Local.ToObservableCollection();

        }
        private void Create()
        {
            //var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            //IMapper mapper = mappingConfig.CreateMapper();
            //var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => { services.AddTransient<ICarService, CarService>(); services.AddSingleton(mapper); }).Build();
            //  _carService = ActivatorUtilities.CreateInstance<CarService>(host.Services);
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void Deleted()
        {
            try
            {
                if (DGTable.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Подтвердить удаление", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < DGTable.SelectedItems.Count; i++)
                        {
                            var car = DGTable.SelectedItems[i] as Car;
                            if (car != null)
                            {
                                _carService.Delete(car.ID);
                            }
                        }
                    }

                }
                else
                {
                    throw new Exception("В таблице нет строк данных для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }      

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Updated();
        }

        private void Updated()
        {
            DGTable.ItemsSource = _carService.Gets();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Deleted();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            Changed();
        }

        private void Changed()
        {
            if (DGTable.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DGTable.SelectedItems.Count; i++)
                {
                    Car? car = DGTable.SelectedItems[i] as Car;
                    if (car != null)
                    {
                        ChangeWindow changeWindow = new ChangeWindow();
                        changeWindow.ShowData(car);
                        changeWindow.Show();
                    }
                }
            }
        }

        private void SearchEngine_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            DGTable.ItemsSource = _carService.Gets().Where(x => x.Model.Contains(SearchEngine.Text) || x.Mark.Contains(SearchEngine.Text) || x.MaxSpeed.ToString().Contains(SearchEngine.Text)).ToList();
        }
    }
}
