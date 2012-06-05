using System;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using Terraria;
using Hooks;
using TShockAPI;
using TShockAPI.DB;
using System.ComponentModel;
using System.IO;

namespace TShockMMO
{
    [APIVersion(1, 12)]
    public class TShockMMO : TerrariaPlugin
    {
        public static List<Player> Players = new List<Player>();
        public static AchievementList achievementlist;
        public static string save = "";
        public static Color bluebase = new Color(30, 144, 255);
        public static Color bluesecondarybase = new Color(135, 206, 255);
        public override string Name
        {
            get { return "TShockMMO"; }
        }

        public override string Author
        {
            get { return "Spectrewiz and K0rd"; }
        }

        public override string Description
        {
            get { return "Completely customized MMO"; }
        }

        public override Version Version
        {
            get { return new Version(0, 0, 1); }
        }

        public override void Initialize()
        {
            GameHooks.Update += OnUpdate;
            GameHooks.Initialize += OnInitialize;
            NetHooks.GreetPlayer += OnGreetPlayer;
            ServerHooks.Leave += OnLeave;
            ServerHooks.Chat += OnChat;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GameHooks.Update -= OnUpdate;
                GameHooks.Initialize -= OnInitialize;
                NetHooks.GreetPlayer -= OnGreetPlayer;
                ServerHooks.Leave -= OnLeave;
                ServerHooks.Chat -= OnChat;
            }
            base.Dispose(disposing);
        }

        public TShockMMO(Main game)
            : base(game)
        {
        }

        public void OnInitialize()
        {
            save = Path.Combine(TShock.SavePath, @"TShockMMO\Achievements.json");
            AchievementConfig config = new AchievementConfig();

            if (File.Exists(save))
            {
                try
                {
                    achievementlist = config.readFile(save);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (achievementlist.Achievements.Count != 0)
                        Console.WriteLine(achievementlist.Achievements.Count + " achievements have been loaded.");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error in Achievements.json file! Check log for more details.");
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    Log.Error("--------- Config Exception in TShockMMO Config file (Achievements.json) ---------");
                    Log.Error(e.Message);
                    Log.Error("----------------------------------- Error End -----------------------------------");
                }
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(TShock.SavePath, "TShockMMO"));
                achievementlist = config.writeFile(save);
                using (StreamWriter writer = new StreamWriter(Path.Combine(TShock.SavePath, @"TShockMMO\loginmsg.txt"), true))
                {
                    writer.WriteLine("Welcome %playername% %color%");
                    writer.WriteLine("You currently have %xp% %color%");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Sample Achievement file generated.");
                Console.ResetColor();
                Log.Info("Sample Achievement file genereated.");
            }
        }

        public void OnUpdate()
        {
        }

        public void OnGreetPlayer(int who, HandledEventArgs e)
        {
            lock (Players)
                Players.Add(new Player(who));
        }

        public void OnLeave(int ply)
        {
            lock (Players)
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Players[i].Index == ply)
                    {
                        Players.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void OnChat(messageBuffer msg, int ply, string text, HandledEventArgs e)
        {
        }
    }
}