using BepInEx.IL2CPP;
using HarmonyLib;
using PeasAPI;
using PeasAPI.Components;
using PeasAPI.CustomEndReason;
using PeasAPI.Roles;
using System.Collections.Generic;
using UnityEngine;

namespace Jester
{
    [RegisterCustomRole]
    class Jester : BaseRole
    {
        public Jester(BasePlugin plugin) : base(plugin) { }

        public override string Name => "Jester";

        public override string Description => "Trick the crew";

        public override string TaskText => "Trick the crew into voting you out";

        public override Color Color => new Color(136f / 256f, 31f / 255f, 136f / 255f);

        public override int Limit => (int)JesterPlugin.JesterAmount.GetValue(); //This is a CustomNumberOption from Reactor-Essentials. You need to make it in the Main class so it gets loaded.
                                                                                //The code for that option is this: public static CustomNumberOption JesterAmount = CustomOption.AddNumber("JesterAmount", "Jesters", true, 1, 1, 3, 1);

        public override Team Team => Team.Alone;

        public override Visibility Visibility => Visibility.NoOne;

        public override void OnGameStart()
        {

        }

        public override void OnUpdate()
        {

        }

        public override void OnMeetingUpdate(MeetingHud meeting)
        {

        }

        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Exiled))]
        class PlayerControlExiledPatch
        {
            public static void Prefix(PlayerControl __instance)
            {
                if (__instance.IsRole<Jester>())
                {
                    var winners = new List<GameData.PlayerInfo>();
                    foreach (var player in PlayerControl.AllPlayerControls)
                        if (player.IsRole<Jester>())
                            winners.Add(player.Data);

                    new CustomEndReason(new Color(136f / 256f, 31f / 255f, 136f / 255f), "Victory", "Jester Wins", "impostor", winners);
                }
            }
        }
    }
}
