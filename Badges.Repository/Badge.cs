using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public Badge() { }
        public Badge(int id, List<string> doors)
        {
            BadgeID = id;
            DoorNames = doors;
        }
    }
}
