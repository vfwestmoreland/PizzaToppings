using PizzaToppings;
using Newtonsoft.Json;


namespace FavoritePizzaToppings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string result = File.ReadAllText("C:\\Users\\vfwes\\Capstone-Backend\\C#\\PizzaToppings\\OOP\\pizzas.json");
            var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(result);

            Dictionary<String, int> totalToppings = new();

            pizzas.ForEach(pizza =>
            {

                string toppingsAsString = String.Join(",", pizza.Toppings.OrderByDescending(x => x));

                if (!totalToppings.ContainsKey(toppingsAsString))
                {
                    totalToppings[toppingsAsString] = 1;
                }
                else
                {
                    totalToppings[toppingsAsString]++;
                };

            });

            var mostPopularPizzaToppings = totalToppings.OrderByDescending(toppingCombo => toppingCombo.Value).Take(1).FirstOrDefault();
            var mostTimesOrdered = totalToppings.Max(item => item.Value);
            Console.WriteLine($"The most popular pizza was ordered {mostTimesOrdered} times.");
            Console.WriteLine($"The most popular pizza is {mostPopularPizzaToppings.Key}, and it was ordered {mostPopularPizzaToppings.Value} times.");


            Console.ReadLine();

            


        }
    }
}