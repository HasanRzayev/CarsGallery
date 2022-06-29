using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGallery.Models
{
    public class Car
    {
        public Car(string imageurl, string vin, string model, string vendor, string type, string fuel, int year)
        {
            this.imageurl=imageurl;
            Vin=vin;
            Model=model;
            Vendor=vendor;
            Type=type;
            Fuel=fuel;
            Year=year;
        }

        public string imageurl { get; set; }
        public string Vin { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public string Type { get; set; }
        public string Fuel { get; set; }
        public int Year { get; set; }
    }
}
