using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Repository
{
    public enum ClaimType
    {
            Car =1,
            Home,
            Theft,
    }
    public class Claim
    {
       
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim () { }
        public Claim(int id, ClaimType type, string description, double claimAmount,  string incident, string claim, bool valid)
        {
            ClaimID = id;
            ClaimType = type;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incident;
            DateOfClaim = claim;
            IsValid = valid;
        }
    }
}
