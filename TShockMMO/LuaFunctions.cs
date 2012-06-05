using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuaInterface;

namespace TShockMMO
{
    class LuaFunctions
    {
        public static void setupFunctions()
        {
            Lua lua = new Lua();
            Functions functions = new Functions();
            
            lua.RegisterFunction("Broadcast", functions, functions.GetType().GetMethod("Broadcast"));//string message
            lua.RegisterFunction("Achievement", functions, functions.GetType().GetMethod("AddAchievement"));//int id, string playername, bool broadcast
            lua.RegisterFunction("AchievementByName", functions, functions.GetType().GetMethod("AddAchievementByName"));//string achievementname, string playername, bool broadcast
            lua.RegisterFunction("AddXP", functions, functions.GetType().GetMethod("AddXP"));//int amount, string playername
            lua.RegisterFunction("SetXP", functions, functions.GetType().GetMethod("SetXP"));//int amount, string playername
            lua.RegisterFunction("Wait", functions, functions.GetType().GetMethod("Wait"));//int time
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
            lua.RegisterFunction("", functions, functions.GetType().GetMethod(""));
        }
    }
}
