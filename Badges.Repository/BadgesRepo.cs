using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Repository
{
    public class BadgesRepo
    {
        public static Dictionary<int, Badge> _badgeDict = new Dictionary<int, Badge>();

        public static void CreateBadge(int badgeID, Badge badge)
        {
            _badgeDict.Add(badgeID, badge);
        }
        public static Dictionary<int, Badge> ViewBadgeInfo()
        {
            return _badgeDict;
        }
        public static bool UpdateADoor(int badgeID, string door)
        {
            Badge oldBadge = GetBadgeByIDNumber(badgeID);
            if(oldBadge != null)
            {
                oldBadge.DoorNames.Add(door);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool RemoveDoorFromBadge(int badgeID, string door)
        {
            Badge badge = GetBadgeByIDNumber(badgeID);
            int count = badge.DoorNames.Count();
            badge.DoorNames.Remove(door);
            if (badge.DoorNames.Count() < count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Badge GetBadgeByIDNumber(int badgeID)
        {
            foreach (KeyValuePair<int, Badge> entry in _badgeDict)
            {
                if (entry.Value.BadgeID == badgeID)
                {
                    return entry.Value;
                }
            }
            return null;
        }
    }
}
