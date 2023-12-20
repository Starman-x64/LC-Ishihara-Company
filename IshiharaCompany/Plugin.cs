using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using BepInEx;
using BepInEx.Logging;
using IshiharaCompany.Patches;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IshiharaCompany
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class IshiharaCompanyModBase : BaseUnityPlugin
    {
        public const string modGUID = "Starman_x64.IshiharaCompany";
        public const string modName = "Ishihara Company";
        public const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static IshiharaCompanyModBase Instance;

        public static ManualLogSource mls;

        public static AssetBundle assetBundle;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            assetBundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "IshiharaCompany/ishiharacompany"));

            mls.LogInfo("Plugin Ishihara Company is loaded!");

            harmony.PatchAll(typeof(IshiharaCompanyModBase));
            harmony.PatchAll(typeof(TerminalAccessibleObjectPatch));
            harmony.PatchAll(typeof(EnemyAIPatch));
            //harmony.PatchAll(typeof(MenuManagerPatch));
        }
    }
}
