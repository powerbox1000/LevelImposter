using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using UnityEngine.SceneManagement;
using LevelImposter.DB;

namespace LevelImposter
{
    [BepInPlugin(ID, "LevelImposter", VERSION)]
    [BepInProcess("Among Us.exe")]
    public class MainHarmony : BasePlugin
    {
        public const string VERSION = "0.3.3";
        public const string ID = "com.DigiWorm.LevelImposter";

        public HarmonyLib.Harmony Harmony { get; } = new HarmonyLib.Harmony(ID);

        public override void Load()
        {
			SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((_, __) =>
            ModManager.Instance.ShowModStamp()));
			
            LILogger.Init();
            VersionCheck.CheckVersion();
            VersionCheck.CheckNewtonsoft();
            AssetDB.Init();
            Harmony.PatchAll();
            LILogger.LogMsg("LevelImposter Initialized.");
        }
    }
}
