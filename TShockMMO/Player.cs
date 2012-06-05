using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;

namespace TShockMMO
{
    public class Player
    {
        public bool enabled;
        public int XP;
        public int Index { get; set; }
        public TSPlayer TSPlayer { get { return TShock.Players[Index]; } }

        public Player(int index)
        {
            Index = index;
        }

        public static Player getPlayer(string name)
        {
            var player = TShock.Utils.FindPlayer(name)[0];
            if (player != null)
            {
                foreach (Player ply in TShockMMO.Players)
                {
                    if (ply.TSPlayer == player)
                    {
                        return ply;
                    }
                }
            }
            return null;
        }
        public static Player getPlayer(int index)
        {
            foreach (Player player in TShockMMO.Players)
            {
                if (player != null && player.Index == index)
                    return player;
            }
            return null;
        }

        public static int getXPAmount(string name)
        {
            var player = TShock.Utils.FindPlayer(name)[0];
            if (player != null)
            {
                foreach (Player ply in TShockMMO.Players)
                {
                    if (ply.TSPlayer == player)
                    {
                        return ply.XP;
                    }
                }
            }
            return 0;
        }
        public static int getXPAmount(int index)
        {
            return TShockMMO.Players[index].XP;
        }

        public static void giveXPAmount(string name, int amount)
        {
            var player = TShock.Utils.FindPlayer(name)[0];
            if (player != null)
            {
                foreach (Player ply in TShockMMO.Players)
                {
                    if (ply.TSPlayer == player)
                    {
                        ply.XP += amount;
                    }
                }
            }
        }
        public static void giveXPAmount(int index, int amount)
        {
            TShockMMO.Players[index].XP += amount;
        }

        public static void setXPAmount(string name, int amount)
        {
            var player = TShock.Utils.FindPlayer(name)[0];
            if (player != null)
            {
                foreach (Player ply in TShockMMO.Players)
                {
                    if (ply.TSPlayer == player)
                    {
                        ply.XP = amount;
                    }
                }
            }
        }
        public static void setXPAmount(int index, int amount)
        {
            TShockMMO.Players[index].XP = amount;
        }
    }
}
