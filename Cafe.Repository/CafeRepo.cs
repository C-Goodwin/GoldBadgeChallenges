using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository
{
    public class CafeRepo
    {
        private readonly List<Menu> _menuRepo = new List<Menu>();
        public void AddNewMenuItem(Menu item)
        {
            _menuRepo.Add(item);
        }
        public List<Menu> GetMenuItems()
        {
            return _menuRepo;
        }
        public bool RemoveMenuItem(int mealNum)
        {
            Menu item = GetMenuItemByNumber(mealNum);
            if(item == null)
            {
                return false;
            }
            int initialCount = _menuRepo.Count;
            _menuRepo.Remove(item);
            if(initialCount > _menuRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Menu GetMenuItemByNumber(int mealNum)
        {
            foreach (Menu item in _menuRepo)
            {
                if (item.MealNumber == mealNum)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
