using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTable.Models.ViewModel
{
    public class ViewCar
    {
        public string Model { get; set; } = string.Empty;
        public string Mark { get; set; } = string.Empty;
        public int MaxSpeed { get; set; }
        //public ViewCar(string model, string mark, int maxSpeed)
        //{
        //    Model = model;
        //    Mark = mark;
        //    MaxSpeed = maxSpeed;
        //}
    }
}
