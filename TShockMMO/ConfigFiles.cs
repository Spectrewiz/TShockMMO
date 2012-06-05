using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TShockAPI;
using System.IO;

namespace TShockMMO
{
    public class AchievementConfig
    {
        public AchievementList writeFile(string file)
        {
            StreamWriter tw = new StreamWriter(file, true);

            AchievementList AchievementList = new AchievementList();

            AchievementList.AddItem(new Achievement(0, "Level 1", new Conditions(0, 0, 50), new Effects(0, 0)));

            tw.Write(JsonConvert.SerializeObject(AchievementList, Formatting.Indented));
            tw.Close();

            return AchievementList;
        }

        public AchievementList readFile(string file)
        {
            TextReader tr = new StreamReader(file);
            string raw = tr.ReadToEnd();
            tr.Close();
            AchievementList achievementList = JsonConvert.DeserializeObject<AchievementList>(raw);
            return achievementList;
        }
    }
}
