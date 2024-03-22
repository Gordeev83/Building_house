namespace Building_house
{
    namespace BuildingHouse
    {
        public interface IPart
        {
            void Build();
        }

        public interface IWorker
        {
            void DoWork(IPart part);
            void DoWork(House house);
        }

        public class Basement : IPart
        {
            public void Build()
            {
                Console.WriteLine("Building basement");
            }
        }

        public class Walls : IPart
        {
            public void Build()
            {
                Console.WriteLine("Building walls");
            }
        }

        public class Door : IPart
        {
            public void Build()
            {
                Console.WriteLine("Installing door");
            }
        }

        public class Window : IPart
        {
            public void Build()
            {
                Console.WriteLine("Installing windows");
            }
        }

        public class Roof : IPart
        {
            public void Build()
            {
                Console.WriteLine("Building roof");
            }
        }

        public class House
        {
            private readonly IPart[] parts;

            public House()
            {
                parts = new IPart[]
                {
                new Basement(),
                new Walls(),
                new Door(),
                new Window(),
                new Roof()
                };
            }

            public void Build()
            {
                foreach (var part in parts)
                {
                    part.Build();
                }
            }
        }

        public class Worker : IWorker
        {
            public void DoWork(IPart part)
            {
                part.Build();
            }

            public void DoWork(House house)
            {
                // Perform work on the house
            }
        }

        public class TeamLeader : IWorker
        {
            public void DoWork(IPart part)
            {
                Console.WriteLine($"Report on work done: {typeof(IPart).Name} constructed");
            }

            public void DoWork(House house)
            {
                // Perform work on the house
            }
        }

        public class Team
        {
            private readonly IWorker[] workers;

            public Team()
            {
                workers = new IWorker[]
                {
                new Worker(),
                new Worker(),
                new Worker(),
                new Worker(),
                new Worker(),
                new TeamLeader()
                };
            }

            public void BuildHouse(House house)
            {
                foreach (var worker in workers)
                {
                    worker.DoWork(house);
                }
            }
        }

        public class Program
        {
            public static void Main()
            {
                House house = new House();
                Team team = new Team();
                team.BuildHouse(house);
                Console.WriteLine("Construction of the house is completed");
            }
        }
    }

}
