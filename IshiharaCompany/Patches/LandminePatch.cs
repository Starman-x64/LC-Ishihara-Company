using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IshiharaCompany.Patches
{
    [HarmonyPatch(typeof(Landmine))]
    internal class LandminePatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void StartPatch(Landmine __instance)
        {
            ManualLogSource mls = IshiharaCompanyModBase.mls;
            Transform transform = __instance.transform;

            for (int i = 0; i < __instance.transform.childCount; i++)
            {
                mls.LogInfo(__instance.transform.GetChild(i));
            }
            Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
            GameObject scanSphere = null;
            foreach (Transform child in allChildren)
            {
                if (child.name == "ScanSphere")
                {
                    scanSphere = child.gameObject;
                    break;
                }
            }
            if (!scanSphere)
            {
                mls.LogWarning(string.Format("Could not find ScanSphere in {0}", transform.name));
                return;
            }
            mls.LogInfo(string.Format("Found {0} in {1}!", scanSphere.name, transform.name));
            scanSphere.GetComponent<MeshRenderer>().material = IshiharaCompanyModBase.assetBundle.LoadAsset<Material>("MapDotPink");
        }
    }
}
