using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;
using System.Threading;

namespace TShockMMO
{
    public class Functions
    {
        public static void Broadcast(string message)
        {
            TShock.Utils.Broadcast(message);
        }
        public static void AddAchievement(int id, string playername, bool broadcast)
        {

        }
        public static void AddAchievementByName(string achievementname, string playername, bool broadcast)
        {

        }
        public static void AddXP(int amount, string playername)
        {
            Player.giveXPAmount(playername, amount);
        }
        public static void SetXP(int amount, string playername)
        {
            Player.setXPAmount(playername, amount);
        }
        public static void Wait(int time)
        {
            Thread.Sleep(time);
        }
    }
}
