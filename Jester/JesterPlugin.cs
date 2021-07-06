using BepInEx;
using BepInEx.IL2CPP;
using Essentials.Options;
using HarmonyLib;
using PeasAPI;
using PeasAPI.Components;
using Reactor;
using UnityEngine;

namespace Jester
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(PeasApi.Id)]
    public class JesterPlugin : BasePlugin
    {
        public const string Id = "tk.peasplayer.amongus.jester";

        public Harmony Harmony { get; } = new Harmony(Id);

        public static CustomNumberOption JesterAmount = CustomOption.AddNumber("JesterAmount", "Jesters", true, 1, 1, 3, 1);

        public override void Load()
        {
            Watermark.PingText = "\nJestermod by Peasplayer";
            Watermark.PingTextOffset = new Vector3(-0.6f, -0f, 0f);
            Watermark.VersionText = "\nJestermod by Peasplayer";
            Watermark.VersionTextOffset = new Vector3(0f, -0.4f, 0f);
            
            PeasApi.AccountTabOffset = new Vector3(0f, -0.5f, 0f);

            CustomServerManager.RegisterServer("Peaspowered", "au.peasplayer.tk", 22023);

            RegisterCustomRoleAttribute.Register(this);

            Harmony.PatchAll();
        }
    }
}
