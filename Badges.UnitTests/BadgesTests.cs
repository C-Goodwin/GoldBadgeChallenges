using Badges.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badges.UnitTests
{
    [TestClass]
    public class BadgesTests
    {
        private Badge _badge;
        private BadgesRepo _repo;
        public void Arrange()
        {
            _repo = new BadgesRepo();
            List<string> doors = new List<string> { "A367", "B59", "C423" };
            _badge = new Badge(46783, doors);

            _repo.CreateBadge(_badge.BadgeID, _badge);
        }
        [TestMethod]
        public void CreateBadge_ShouldGetNotNull()
        {
            Arrange();
            Badge testBadge = _repo.GetBadgeByIDNumber(46783);
            Assert.IsNotNull(testBadge);
        }
        public void RemoveBadge_ShouldReturnTrue()
        {
            Arrange();
            bool deleteResult = _repo.RemoveBadgeFromList(_badge.BadgeID);
            Assert.IsTrue(deleteResult);
        }
        public void UpdateBadge_ShouldReturnTrue()
        {
            Arrange();
            List<string> doorChange = new List<string> { "c367", "a59", "b423" };
            Badge newBadge = new Badge(46783, doorChange);
            bool updateResult = _repo.UpdateBadge(46783, newBadge);
            Assert.IsTrue(updateResult);
        }
    }
}
