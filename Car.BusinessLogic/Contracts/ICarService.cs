using WPFTable.Models;
using WPFTable.Models.ViewModel;

namespace WPFTable.BusinessLogic.Contracts
{
    public interface ICarService
    {
        List<Car> Gets();
        void Create(Car car);
        void Delete(int id);
        void Update(Car car);
    }
}
