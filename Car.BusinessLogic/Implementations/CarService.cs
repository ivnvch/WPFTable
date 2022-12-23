using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WPFTable.BusinessLogic.Contracts;
using WPFTable.Models;
using WPFTable.Models.ViewModel;

namespace WPFTable.BusinessLogic.Implementations
{
    public class CarService : ICarService
    {

        DataContext _context;
        public CarService(DataContext context)
        {
            _context = context;
        }

        public void Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.ID == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Car not exist!");
            }
        }

        public List<Car> Gets()
        {
            var cars = _context.Cars.AsNoTracking().ToList();
            return cars;
        }

        public void Update(Car car)
        {
          _context.Cars.Update(car);
          _context.SaveChanges();
        }
    }
}
