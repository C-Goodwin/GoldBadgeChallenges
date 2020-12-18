using Claims.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims.UnitTests
{
    [TestClass]
    public class ClaimsTests
    {
        private Claim _claim;
        private ClaimsRepo _claimsRepo;
        public void Arrange()
        {
            _claimsRepo = new ClaimsRepo();
            _claim = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, "4/25/18", "4/27/18", true);
           ClaimsRepo.AddClaimToList(_claim);
        }
        [TestMethod]
        public void AddClaim_ShouldGetNotNull()
        {
            Arrange();
            Assert.IsNotNull(_claim);
        }
        
    }
}
