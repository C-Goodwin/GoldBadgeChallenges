using Cafe.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe.UnitTests
{
    [TestClass]
    public class CafeTests
    {
        private Menu _item;
        private CafeRepo _repo;
        public void Arrange()
        {
            _repo = new CafeRepo();
            List<string> ingredientsForBNM = new List<string> { "Bananas, Walnuts, flour, sugar, salt" };
            _item = new Menu(1, "Banana Nut Muffin", "A delicious banana muffin packed with walnuts",
              ingredientsForBNM, 2.99);

            _repo.AddNewMenuItem(_item);
        }
        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            List<string> ingredientsForOCM = new List<string> { "orange rind", "dried cranberries", "flour", "sugar", "salt" };

            Menu item2 = new Menu(2, "Orange Cranberry Muffin", "A delicious muffin packed with orange and cranberry flavours",
              ingredientsForOCM, 2.99);
            _repo.AddNewMenuItem(item2);
            Menu itemFromMenu = _repo.GetMenuItemByNumber(2);
            Assert.IsNotNull(itemFromMenu);
        }
        public void LookUpByNumber_ShouldreturnNotNull()
        {
            Menu itemFromMenu = _repo.GetMenuItemByNumber(1);
            Assert.IsNotNull(itemFromMenu);
        }
        public void DeleteItem_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveMenuItem(_item.MealNumber);
            Assert.IsTrue(deleteResult);
        }  
    }
}
