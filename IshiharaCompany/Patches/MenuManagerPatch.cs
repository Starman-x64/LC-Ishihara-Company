using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace IshiharaCompany.Patches
{
    [HarmonyPatch(typeof(MenuManager))]
    internal class MenuManagerPatch
    {
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        static void AddColourBlindOption(MenuManager __instance)
        {
            ManualLogSource mls = IshiharaCompanyModBase.mls;
            Transform canvas = __instance.transform.parent;
            Transform[] allChildren = canvas.GetComponentsInChildren<Transform>(true);
            Transform controlsOptions = null;
            GameObject arachniphobiaModeOption = null;
            mls.LogInfo(canvas.name);
            foreach (Transform child in allChildren)
            {
                mls.LogInfo(child.name);
                if (child.name == "ControlsOptions")
                {
                    controlsOptions = child;
                }
                else if (child.name == "ArachniphobiaMode")
                {
                    arachniphobiaModeOption = child.gameObject;
                }
                if (controlsOptions && arachniphobiaModeOption)
                {
                    break;
                }
            }
            mls.LogInfo(string.Format("Targeted objects on \"{0}\":\n- ControlsOptions: {1}\n- AracnaphobiaMode: {2}", canvas.name, !!controlsOptions, !!arachniphobiaModeOption));
            if (!controlsOptions || !arachniphobiaModeOption)
            {
                mls.LogWarning("Some objects not found, returning function.");
                return;
            }

            // copy it
            GameObject colourBlindModeOption = GameObject.Instantiate(arachniphobiaModeOption);
            colourBlindModeOption.name = "ColourBlindMode";

            // change it
            TextMeshProUGUI text = colourBlindModeOption.GetComponentInChildren<TextMeshProUGUI>();
            text.text = "Colour Blind Mode";

            // parent it
            colourBlindModeOption.transform.SetParent(controlsOptions);

            colourBlindModeOption.SetActive(true);

            // link variable to it
        }
    }
}
