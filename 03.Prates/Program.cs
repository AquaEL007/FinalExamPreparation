namespace _03.Prates
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
    internal class Program
    {
        static void Main()
        {
            List<City> cities = new List<City>();

            string line;
            while ((line = Console.ReadLine()) != "Sail")
            {
                string[] tokens = line.Split("||");
                string cityName = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);

                City city = cities.FirstOrDefault(x => x.Name == cityName);
                if (city is not null)
                {
                    city.Population += population;
                    city.Gold += gold;
                    continue;
                }
                else
                {
                    cities.Add(new City { Name = cityName, Population = population, Gold = gold });
                }
            }

            line = string.Empty;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] tokens = line.Split("=>");
                string command = tokens[0];
                string cityName = tokens[1];

                City targetCity = cities.FirstOrDefault(x => x.Name == cityName);

                if (command == "Plunder")
                {
                    int people = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);
                    targetCity.Population -= people;
                    targetCity.Gold -= gold;
                    Console.WriteLine($"{targetCity.Name} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (targetCity.Population <= 0 || targetCity.Gold <= 0)
                    {
                        Console.WriteLine($"{targetCity.Name} has been wiped off the map!");
                        cities.Remove(targetCity);
                    }
                }
                else // Prosper
                {
                    int gold = int.Parse(tokens[2]);
                    
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    targetCity.Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {targetCity.Name} now has {targetCity.Gold} gold.");
                }
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }

            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
            }
        }
    }
}
