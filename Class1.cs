using System;
using System.Collections.Generic;
using Harmony;
using UnityEngine;
using System.Reflection;

namespace RealCompanies
{
    [HarmonyPatch(typeof(AIStudio), "GetNameText")]
    public class AIStudio_GetNameText_Patch
    {
        public static bool Prefix(AIStudio __instance, ref string __result)
        {
            AIStudio.Name name = (AIStudio.Name)typeof(AIStudio)
                .GetField("name", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(__instance);

            switch (name)
            {
                case AIStudio.Name.Vlampier: __result = "Bethesda"; return false;
                case AIStudio.Name.Electronic_Poptarts: __result = "Electronic Arts"; return false;
                case AIStudio.Name.Walve_Software: __result = "Valve"; return false;
                case AIStudio.Name.Double_Pine: __result = "Double Fine"; return false;
                case AIStudio.Name.Clay_Entertainment: __result = "IO Interactive"; return false;
                case AIStudio.Name.Telltail_Games: __result = "Telltale Games"; return false;
                case AIStudio.Name.Fireaxes_Games: __result = "Firaxis Games"; return false;
                case AIStudio.Name.DVD_Projekt_Red: __result = "CD Projekt RED"; return false;
                case AIStudio.Name.Introsturgeon_Software: __result = "Capcom"; return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Studio), MethodType.Constructor, new Type[] { typeof(string) })]
public class Studio_SaveConstructor_Patch
{
    public static void Postfix(Studio __instance)
    {
        string name = (string)typeof(Studio)
            .GetField("name", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(__instance);

        string newName = null;
        switch (name)
        {
            case "Vlampier": newName = "Bethesda"; break;
            case "Electronic Poptarts": newName = "Electronic Arts"; break;
            case "Walve Software": newName = "Valve"; break;
            case "Double Pine": newName = "Double Fine"; break;
            case "Clay Entertainment": newName = "IO Interactive"; break;
            case "Telltail Games": newName = "Telltale Games"; break;
            case "Fireaxes Games": newName = "Firaxis Games"; break;
            case "DVD Projekt RED": newName = "CD Projekt RED"; break;
            case "Introsturgeon Software": newName = "Capcom"; break;
        }

        if (newName != null)
        {
            typeof(Studio)
                .GetField("name", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(__instance, newName);
        }
    }
}
}