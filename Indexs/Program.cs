using System;
using System.Collections.Generic;
using System.Linq;

namespace Indexs
{
    class Program
    {
        static void Main(string[] args)
        {
            var vagons = new List<Vagon>();

            Console.Write("Введи колво вагонов: ");
            var countOfVagons = int.Parse(Console.ReadLine());

            for (int i = 1; i <= countOfVagons; i++)
            {
                Console.Write($"\tВведи название вагона №{i}: ");
                var vagon = new Vagon(Console.ReadLine());

                vagons.Add(vagon);
            }

            var stations = new List<Station>();

            Console.Write("Введи колво станций: ");
            var countOfStations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= countOfStations; i++)
            {
                Console.WriteLine($"Заполните данные вагона №{i}: ");

                var station = new Station();
                Console.Write("\n\n\t Имя станции: ");
                station.Name = Console.ReadLine();
                Console.Write("\n\t Время прибытия в формате (DD.MM.YYYY HH.MM): ");
                station.TimeOfArrival = DateTime.Parse(Console.ReadLine());
                // проверка в функции
                Console.Write("\n\t Время отбытия в формате (DD.MM.YYYY HH.MM): ");
                station.TimeOfDeparture = DateTime.Parse(Console.ReadLine());
                // проверка в функции
                stations.Add(station);
            }

            var train = new Train(vagons, stations);

            Console.WriteLine("Введите номер поезда: ");
            train.Number = Console.ReadLine();
            Console.Clear();

            train.PrintTrainData();

            Console.WriteLine(train["Moscow"].Name);
            train["Moscow"] = new Station()
            {
                Name = "Kazan",
                TimeOfArrival = DateTime.Now,
                TimeOfDeparture = DateTime.Now
            };

            Console.WriteLine();

            foreach (var s in train.Stations)
            {
                Console.WriteLine(s.Name);
            }

            Console.ReadKey();
        }
    }

    class Station
    {
        public string Name { get; set; }

        private DateTime timeOfArrival;
        private DateTime timeOfDeparture;

        public DateTime TimeOfArrival
        {
            get
            {
                return timeOfArrival;
            }
            set
            {
                timeOfArrival = value > timeOfDeparture ? timeOfArrival : value;
            }
        }

        public DateTime TimeOfDeparture
        {
            get
            {
                return timeOfDeparture;
            }
            set
            {
                timeOfDeparture = value < timeOfArrival ? timeOfDeparture : value;
            }
        }

    }

    class Vagon
    {
        public string Name { get; set; }

        public Vagon(string name)
        {
            Name = name;
        }
    }

    class Train
    {
        public string Number { get; set; }
        public int CountOFVagon { get; set ; }

        public List<Vagon> Vagons { get; set; }
        public List<Station> Stations { get; set; }

        public Train(List<Vagon> vagons, List<Station> stations)
        {
            Vagons = vagons;
            Stations = stations;
        }
        // написать индексатор

        public Station this[string stationName]
        {
            get
            {
                return Stations.FirstOrDefault(x => x.Name == stationName) ?? throw new Exception("Not Found");
            }
            set
            {
                var stationIndex = Stations.FindIndex(x => x.Name == stationName);
                if (stationIndex < 0) throw new Exception("Not Found");
                Stations[stationIndex] = value;
            }
        } 

        public void PrintTrainData()
        {
            Console.Write($"Поезд с номером: {Number} ");

            Console.Write($"\n\tУ поезда {Number} есть вагоны {Vagons.Count}");

            foreach (var c in Vagons)
            {
                Console.Write($"\n\tИмя: {c.Name} ");
            }

            Console.Write($"\n\nСтанции: {Stations.Count}: ");

            foreach (var s in Stations)
            {
                Console.WriteLine($"\n\tСтанция: {s.Name} " +
                    $"\n\t\tВремя прибытия: {s.TimeOfArrival} " +
                    $"\n\t\tВремя отправления: {s.TimeOfDeparture} ");
            }
        }

        public TimeSpan CalcTimeOnWay(Station station1, Station station2)
        {
            return station2.TimeOfArrival - station1.TimeOfDeparture;
        }
    }
}