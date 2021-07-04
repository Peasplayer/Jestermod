using BepInEx;
using BepInEx.IL2CPP;
using Essentials.Options;
using HarmonyLib;
using PeasAPI;
using PeasAPI.Components;
using Reactor;

namespace Jester
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class JesterPlugin : BasePlugin
    {
        public const string Id = "me.change.please";

        public Harmony Harmony { get; } = new Harmony(Id);

        public static CustomNumberOption JesterAmount = CustomOption.AddNumber("JesterAmount", "Jesters", true, 1, 1, 3, 1);

        public override void Load()
        {
            Watermark.PingText = "Jestermod by Peasplayer";
            Watermark.VersionText = "Jestermod by Peasplayer";

            CustomServerManager.RegisterServer("Peaspowered", "au.peasplayer.tk", 22023);

            RegisterCustomRoleAttribute.Register(this);

            Harmony.PatchAll();
        }
    }
}
