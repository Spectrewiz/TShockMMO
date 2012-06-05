using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TShockAPI;

namespace TShockMMO
{
    [Serializable]
    public class Achievement
    {
        public int id;
        public string Name;
        public Conditions Conditions;
        public Effects Effects;
        public Achievement(int id, string Name, Conditions Conditions, Effects Effects)
        {
            this.id = id;
            this.Name = Name;
            this.Conditions = Conditions;
            this.Effects = Effects;
        }

        public string getName()
        {
            return Name;
        }
    }

    [Serializable]
    public class Conditions
    {
        public int monsterKill;
        public int monsterAmount;
        public int xpAmount;
        public Conditions(int monsterKill, int monsterAmount, int xpAmount)
        {
            this.monsterKill = monsterKill;
            this.monsterAmount = monsterAmount;
            this.xpAmount = xpAmount;
        }
    }
    [Serializable]
    public class Effects
    {
        public int itemEarned;
        public int xpEarned;
        public Effects(int itemEarned, int xpEarned)
        {
            this.itemEarned = itemEarned;
            this.xpEarned = xpEarned;
        }
    }

    public class AchievementList
    {
        public List<Achievement> Achievements;

        public AchievementList()
        {
            Achievements = new List<Achievement>();
        }

        public void AddItem(Achievement a)
        {
            Achievements.Add(a);
        }

        public Achievement findAchievement(string name)
        {
            foreach (Achievement a in Achievements)
            {
                if (a.getName().ToLower() == name.ToLower())
                {
                    return a;
                }
            }
            return null;
        }

        public List<string> getListOfNames()
        {
            List<string> AchievementNames = new List<string>();
            foreach (Achievement a in Achievements)
            {
                AchievementNames.Add(a.Name);
            }
            return AchievementNames;
        }
    }
}
