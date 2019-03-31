using System;
using System.Linq;
using Newtonsoft.Json;
using LINQ_in_manhattan.Classes;

namespace LINQ_in_manhattan
{
    public class Program
    {
        static void Main(string[] args)
        {
            Questions();
            Console.ReadKey();
        }

        /// <summary>
        /// Answers all the questions
        /// </summary>
        public static void Questions()
        {
            string text = System.IO.File.ReadAllText("../../../../data.json");
            Data json = JsonConvert.DeserializeObject<Data>(text);
            
            var query = from places in json.Features
                        select places.Properties.Neighborhood;

            foreach (string place in query)
            {
                Console.WriteLine(place);
            }

            Console.WriteLine("----------------------------------");

            var query2 = query.Distinct();

            foreach (string place in query2)
            {
                Console.WriteLine(place);
            }

            Console.WriteLine("----------------------------------");

            var query3 = from places in query2
                         where places != ""
                         select places;

            foreach (string place in query3)
            {
                Console.WriteLine(place);
            }

            Console.WriteLine("----------------------------------");

            var query4 = from places in json.Features
                         where places.Properties.Neighborhood != ""
                         group places by places.Properties.Neighborhood into newPlaces
                         select newPlaces.First().Properties.Neighborhood;

            foreach (string place in query4)
            {
                Console.WriteLine(place);
            }

            Console.WriteLine("----------------------------------");

            var query5 = json.Features.Select(places => places.Properties.Neighborhood);

            foreach (string place in query5)
            {
                Console.WriteLine(place);
            }
        }
    }
}
