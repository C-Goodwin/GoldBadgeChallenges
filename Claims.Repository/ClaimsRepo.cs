using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Repository
{
    public class ClaimsRepo
    {

        public static Queue<Claim> _claimsList = new Queue<Claim>();
        public static Queue<Claim> GetAllClaims()
        {
            return _claimsList;
        }
        public static DataTable InsuranceClaimsDT()
        {
            Console.Clear();
            DataTable insuranceClaimsTable = new DataTable("InsuranceClaims");
            DataColumn[] cols =
            {
                new DataColumn("ClaimID", typeof(int)),
                new DataColumn("Claim Type", typeof(ClaimType)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Claim Amount", typeof(double)),
                new DataColumn("Date of Incident", typeof(string)),
                new DataColumn("Date of Claim", typeof(string)),
                new DataColumn("Is Valid", typeof(bool)),
            };
            foreach (DataColumn col in cols) { insuranceClaimsTable.Columns.Add(col); }
            insuranceClaimsTable.PrimaryKey = new DataColumn[] { insuranceClaimsTable.Columns["ClaimID"] };

            foreach (Claim c in _claimsList)
            {
                DataRow dr = insuranceClaimsTable.NewRow();
                insuranceClaimsTable.Rows.Add(c.ClaimID, c.ClaimType, c.Description, c.ClaimAmount, c.DateOfIncident, c.DateOfClaim, c.IsValid);
            }
            return insuranceClaimsTable;
        }
        public static void ShowTable(DataTable table)
        {
            foreach (DataColumn col in table.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName + "       ");
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.Write("{0,-14}", row[col] + "         ");
                }
                Console.WriteLine();
            }
        }
        
        public static void AddClaimToList(Claim claim)
        {
            _claimsList.Enqueue(claim);
        }
        public void SeedContentList()
        {
            Claim a = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, "4/25/18", "4/27/18", true);
            Claim b = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, "4/11/18", "4/12/18", true);
            Claim c = new Claim(3, ClaimType.Theft, "Stolen Pancakes.", 4.00, "4/27/18", "6/01/18", false);
            Claim d = new Claim(4, ClaimType.Car, "Wreck on I-70", 2000.00, "4/27/18", "4/28/18", true);
            _claimsList.Enqueue(a);
            _claimsList.Enqueue(b);
            _claimsList.Enqueue(c);
            _claimsList.Enqueue(d);
        }
    }
}