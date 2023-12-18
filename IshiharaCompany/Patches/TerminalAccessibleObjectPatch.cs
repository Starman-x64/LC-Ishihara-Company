using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IshiharaCompany.Patches
{
    [HarmonyPatch(typeof(TerminalAccessibleObject))]
    internal class TerminalAccessibleObjectPatch
    {
        [HarmonyPatch("OnPowerSwitch")]
        [HarmonyPostfix]
        public static void AdjustDoorClosedColourOnPowerSwitch(ref string ___objectCode, ref bool ___isDoorOpen, ref TextMeshProUGUI ___mapRadarText, ref Image ___mapRadarBox)
        {
            ManualLogSource mls = IshiharaCompanyModBase.mls;
            mls.LogInfo("Power Switched, running AdjustDoorClosedColour...");
            if (!___isDoorOpen)
            {
                ___mapRadarText.color = Color.magenta;
                ___mapRadarBox.color = Color.magenta;
                mls.LogInfo("Changed colour of closed door " + ___objectCode + " to magenta.");
            }
        }
        [HarmonyPatch("SetDoorOpen")]
        [HarmonyPostfix]
        public static void AdjustDoorClosedColourSetDoorOpen(ref string ___objectCode, ref bool ___isDoorOpen, ref TextMeshProUGUI ___mapRadarText, ref Image ___mapRadarBox)
        {
            ManualLogSource mls = IshiharaCompanyModBase.mls;
            mls.LogInfo("Set Door Open, running AdjustDoorClosedColour...");
            if (!___isDoorOpen)
            {
                ___mapRadarText.color = Color.magenta;
                ___mapRadarBox.color = Color.magenta;
                mls.LogInfo("Changed colour of closed door " + ___objectCode + " to magenta.");
            }
        }
        [HarmonyPatch("CallFunctionFromTerminal")]
        [HarmonyPostfix]
        public static void AdjustDoorClosedColourCallFunctionFromTerminal(ref string ___objectCode, ref bool ___isDoorOpen, ref TextMeshProUGUI ___mapRadarText, ref Image ___mapRadarBox)
        {
            ManualLogSource mls = IshiharaCompanyModBase.mls;
            mls.LogInfo("Called Function From Terminal, running AdjustDoorClosedColour...");
            if (!___isDoorOpen)
            {
                ___mapRadarText.color = Color.magenta;
                ___mapRadarBox.color = Color.magenta;
                mls.LogInfo("Changed colour of closed door " + ___objectCode + " to magenta.");
            }
        }

    }
}
