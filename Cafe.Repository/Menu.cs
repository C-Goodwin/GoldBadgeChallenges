using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }

        public Menu() { }
        public Menu(int number, string name, string description, List<string> ingredients, double price)
        {
            MealNumber = number;
            MealName = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
