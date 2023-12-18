using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace IshiharaCompany.Patches
{
    internal class EnemyAIPatch
    {
        [HarmonyPatch(typeof(BaboonBirdAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectFBaboonBirdSpawn(BaboonBirdAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(DocileLocustBeesAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectDocileLocustBeesSpawn(DocileLocustBeesAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(DoublewingAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectDoublewingSpawn(DoublewingAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(JesterAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectJesterSpawn(JesterAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(LassoManAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectLassoManSpawn(LassoManAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(NutcrackerEnemyAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectNutcrackerEnemySpawn(NutcrackerEnemyAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(PufferAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectPufferSpawn(PufferAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(SandSpiderAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectSandSpiderSpawn(SandSpiderAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(SandWormAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectSandWormSpawn(SandWormAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(BlobAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectBlobSpawn(BlobAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(CentipedeAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectCentipedeSpawn(CentipedeAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(CrawlerAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectCrawlerSpawn(CrawlerAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(RedLocustBees), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectRedLocustBeesSpawn(RedLocustBees __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(DressGirlAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectDressGirlSpawn(DressGirlAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(FlowermanAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectFlowermanSpawn(FlowermanAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(ForestGiantAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectForestGiantSpawn(ForestGiantAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(HoarderBugAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectHoarderBugSpawn(HoarderBugAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(MouthDogAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectMouthDogSpawn(MouthDogAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(SpringManAI), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectSpringManSpawn(SpringManAI __instance)
        {
            DetectSpawn(__instance);
        }
        [HarmonyPatch(typeof(TestEnemy), "__initializeVariables")]
        [HarmonyPostfix]
        public static void DetectTestEnemySpawn(TestEnemy __instance)
        {
            DetectSpawn(__instance);
        }


        public static void DetectSpawn(EnemyAI __instance)
        {
            ManualLogSource mls = IshiharaCompanyModBase.mls;
            mls.LogInfo((object)String.Format("{0} Summoned", __instance.name));
            Transform transform = __instance.transform;
            if (transform == null)
            {
                mls.LogInfo((object)"Transform Not Found");
            }
            else
            {
                mls.LogInfo((object)"Transform Found");
            }
            GameObject mapDot = null;
            Regex mapDotRegex = new Regex("MapDot.*");
            Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                MatchCollection matches = mapDotRegex.Matches(child.name);
                mls.LogInfo(child.name + ": " + matches.Count);
                if (matches.Count > 0)
                {
                    mapDot = child.gameObject;
                    break;
                }
            }
            if (!mapDot)
            {
                mls.LogWarning(string.Format("Object \"{0}\" has no map dot object!", transform.name));
                return;
            }
            mls.LogMessage(string.Format("Found map dot object \"{0}\" in \"{1}\".", mapDot.name, transform.name));
            mapDot.GetComponent<MeshRenderer>().material = IshiharaCompanyModBase.assetBundle.LoadAsset<Material>("MapDotPink");
        }
    }
}
