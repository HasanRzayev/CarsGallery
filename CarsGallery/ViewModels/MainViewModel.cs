using Bogus;
using CarsGallery.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CarsGallery.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool istoggle;

        public bool Istoggle
        {
            get { return istoggle; }
            set { istoggle = value;OnPropertyChanged(); }
        }
        private string vaxt="00,00,00,00";

        public string Vaxt
        {
            get { return vaxt; }
            set { vaxt = value; OnPropertyChanged(); }
        }

        public RelayCommand StartButton
        {
            get => new RelayCommand(() =>
            {
                
                if (Istoggle==false)
                {
                    zaman.Start();
                    cars.Clear();
                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        Prosers_single();
                    });
                    zaman.Stop();
                    Vaxt=zaman.Elapsed.ToString();
                }
                if (Istoggle==true)
                {
                    zaman.Start();
                    cars.Clear();
                    List<string> lazimli = new List<string>();
                    lazimli.Add("Cars_1.json");
                    lazimli.Add("Cars_2.json");
                    lazimli.Add("Cars_3.json");
                    for (int i = 0; i < 2; i++)
                    {
                        ThreadPool.QueueUserWorkItem((o) =>
                        {
                            Prosers_multi(lazimli[i]);
                        });
                    }
                    zaman.Stop();
                    Vaxt=zaman.Elapsed.ToString();
                }
                cancel.Cancel();

            });
        }

        private void Prosers_multi(string a)
        {
            if (File.Exists(a) == true)
            {
                var hesabjson = File.ReadAllText(a);
                var option = JsonConvert.DeserializeObject<ObservableCollection<Car>>(hesabjson);
                lock (this)
                {
                    foreach (var item in option.ToList())
                    {
                        dispatcher.Invoke(() => cars.Add(item));
                    }
                }
               
            }
        }
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        private void Prosers_single()
        {
           
            if (File.Exists("Cars_1.json") == true)
            {
                var hesabjson = File.ReadAllText("Cars_1.json");
                var option = JsonConvert.DeserializeObject<ObservableCollection<Car>>(hesabjson);
                foreach (var item in option.ToList())
                {
                    dispatcher.Invoke(() => cars.Add(item)); 
                }


            }
            if (File.Exists("Cars_2.json") == true)
            {
                var hesabjson = File.ReadAllText("Cars_2.json");
                var option = JsonConvert.DeserializeObject<ObservableCollection<Car>>(hesabjson);

                foreach (var item in option.ToList())
                {
                    dispatcher.Invoke(() => cars.Add(item));
                }


            }
            if (File.Exists("Cars_3.json") == true)
            {
                var hesabjson = File.ReadAllText("Cars_3.json");
                var option = JsonConvert.DeserializeObject<ObservableCollection<Car>>(hesabjson);
                foreach (var item in option.ToList())
                {
                    dispatcher.Invoke(() => cars.Add(item));
                }


            }
            
        }
        public Stopwatch zaman { get; set; }
        private ObservableCollection<Car> carssss;

        public ObservableCollection<Car> cars
        {
            get { return carssss; }
            set { carssss = value; OnPropertyChanged(); }
        }
        public List<string> carimages { get; set; }
        public CancellationTokenSource cancel { get; set; } = new CancellationTokenSource();
        public MainViewModel()
        {
             CancellationTokenSource cancel = new CancellationTokenSource();
            cars=new ObservableCollection<Car>();
            zaman=new Stopwatch();
            carimages=new List<string>();
            carimages.Add("https://images.pexels.com/photos/1149137/pexels-photo-1149137.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/253096/pexels-photo-253096.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/977003/pexels-photo-977003.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/1619930/pexels-photo-1619930.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/112460/pexels-photo-112460.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/2614793/pexels-photo-2614793.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/4665693/pexels-photo-4665693.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/5288699/pexels-photo-5288699.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/5975528/pexels-photo-5975528.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/9018708/pexels-photo-9018708.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/120049/pexels-photo-120049.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/112460/pexels-photo-112460.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/164654/pexels-photo-164654.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/3729464/pexels-photo-3729464.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/215528/pexels-photo-215528.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/5214193/pexels-photo-5214193.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/5288708/pexels-photo-5288708.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/10224355/pexels-photo-10224355.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/10890912/pexels-photo-10890912.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/5320341/pexels-photo-5320341.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/1029535/pexels-photo-1029535.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/6969035/pexels-photo-6969035.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/10902414/pexels-photo-10902414.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/6335848/pexels-photo-6335848.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/10535367/pexels-photo-10535367.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/7224168/pexels-photo-7224168.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/909907/pexels-photo-909907.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/1035108/pexels-photo-1035108.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/1719647/pexels-photo-1719647.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/8634570/pexels-photo-8634570.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/6784575/pexels-photo-6784575.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/10982945/pexels-photo-10982945.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/7682148/pexels-photo-7682148.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/9542002/pexels-photo-9542002.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/9582590/pexels-photo-9582590.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/3923522/pexels-photo-3923522.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/3849553/pexels-photo-3849553.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/5604220/pexels-photo-5604220.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/7762710/pexels-photo-7762710.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/170811/pexels-photo-170811.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/757186/pexels-photo-757186.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/8642186/pexels-photo-8642186.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/11654779/pexels-photo-11654779.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/2127732/pexels-photo-2127732.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/10905505/pexels-photo-10905505.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/6509108/pexels-photo-6509108.jpeg?auto=compress&cs=tinysrgb&w=1600");
            carimages.Add("https://images.pexels.com/photos/10108560/pexels-photo-10108560.jpeg?auto=compress&cs=tinysrgb&w=1600");
       

            var option =new List<Car>();
            if (File.Exists("Cars_1.json") == false)
            {
                var rn=new Random();
                var faker = new Faker("en");
                for (int i = 0; i < 10; i++)
                {
                    var o = new Car
                    (
                         carimages[rn.Next(0,carimages.Count())],
                         faker.Vehicle.Vin(),
                         faker.Vehicle.Model(),
                         faker.Vehicle.Manufacturer(), faker.Vehicle.Type(),
                         faker.Vehicle.Fuel(),
                         faker.Random.Number(1980, 2010)
                    
                    );
                    option.Add(o);
                }
               
                var carsss = JsonConvert.SerializeObject(option, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("Cars_1.json", carsss);
                option.Clear();
        
            }
            if (File.Exists("Cars_2.json") == false)
            {
                var rn = new Random();
                var faker = new Faker("en");
                for (int i = 0; i < 10; i++)
                {
                    var o = new Car
                    (
                         carimages[rn.Next(0, carimages.Count())],
                         faker.Vehicle.Vin(),
                         faker.Vehicle.Model(),
                         faker.Vehicle.Manufacturer(), faker.Vehicle.Type(),
                         faker.Vehicle.Fuel(),
                         faker.Random.Number(1980, 2010)

                    );
                    option.Add(o);
                }

                var carsss = JsonConvert.SerializeObject(option, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("Cars_2.json", carsss);
                option.Clear();

            }
            if (File.Exists("Cars_3.json") == false)
            {
                var rn = new Random();
                var faker = new Faker("en");
                for (int i = 0; i < 10; i++)
                {
                    var o = new Car
                    (
                         carimages[rn.Next(0, carimages.Count())],
                         faker.Vehicle.Vin(),
                         faker.Vehicle.Model(),
                         faker.Vehicle.Manufacturer(), faker.Vehicle.Type(),
                         faker.Vehicle.Fuel(),
                         faker.Random.Number(1980, 2010)

                    );
                    option.Add(o);
                }

                var carsss = JsonConvert.SerializeObject(option, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("Cars_3.json", carsss);
                option.Clear();

            }
        }
    }
}
