using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Utils;
using Il2CppSystem;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Towers.Mods;
using Octokit;
using System;
using UnityEngine;
using Il2CppSystem.Collections.Generic;
//using ClassicTowers.Bloons;
using Il2CppAssets.Scripts.Unity.Achievements.List;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity;

namespace ClassicTowers.B3;
public abstract class BTD3 : ModRoundSet
{
    //public static readonly Dictionary<string, BTD3> Cache = new();
    //public static readonly string "BTD3";
    //public new int Order => 1;
    public override string Name => "BTD3";
    public override string BaseRoundSet => RoundSetType.Default;
    public override string DisplayName => "BTD3";
    public override string Icon => VanillaSprites.RegrowBloonIcon;
    public override bool AddToOverrideMenu => true;
    public override int DefinedRounds => 15;

    //public override SpriteReference IconReference => GetSpriteReferenceOrDefault("3f16ba2fac3822444818744a17789392");
    public override void ModifyRoundModels(RoundModel roundModel, int round)
    {

        roundModel.groups.Clear();
        var balls = Game.instance.model.bloons;
        string[] BloonSring = { "Red", "Blue", "Green", "Yellow", ClassicBlack.id, "ClassicWhite", "ClassicLead", "ClassicRainbow", "ClassicCeramic", "ClassicMoab", "Bfb", "Zomg", "Bad" };
        //ModBloon[] BloonSring = { "Red", "Blue", "Green", "Yellow", "Black", "White", "Lead", "Rainbow", "Ceramic", "Moab", "Bfb", "Zomg", "Bad" };
        //ModBloon[] ModBloonSring = { ClassicBlack, ClassicWhite, ClassicLead, ClassicRainbow, ClassicCeramic, ClassicMoab };
        //if (round > 80)
        //{
        //    string[] BloonSring2 = { "Red", "Blue", "Green", "Yellow", "ClassicBlack", "ClassicWhite", "ClassicLead", "ClassicSuperRainbow", "ClassicSuperCeramic", "ClassicSuperMoab", "Bfb", "Zomg", "Bad" };
        //    BloonSring = BloonSring2;
        //}
        var diff = "medium";
        //var round = round;
        var _loc2_ = 0;
        var _loc3_ = 0;
        var _loc4_ = 0;
        var _loc5_ = 0;
        var _locA_ = 0f;
        var _locB_ = 0f;
        //var balls = ABSTL(0, round, 1);
        ABSTL(14, 1, 1);
        ABSTL(30, 2, 1);
        ABSTL(10, 3, 1);
        ABSTL(4, 3, 2);
        ABSTL(5, 3, 1);
        ABSTL(4, 3, 2);
        ABSTL(5, 4, 1);
        ABSTL(12, 4, 2);
        ABSTL(5, 4, 1);
        ABSTL(12, 4, 2);
        ABSTL(10, 5, 1);
        ABSTL(8, 5, 2);
        ABSTL(12, 5, 1);
        ABSTL(20, 5, 2);
        ABSTL(13, 6, 1);
        ABSTL(7, 6, 3);
        ABSTL(50, 7, 2);
        ABSTL(9, 8, 1);
        ABSTL(16, 8, 2);
        ABSTL(9, 8, 1);
        ABSTL(7, 8, 2);
        ABSTL(9, 8, 1);
        ABSTL(7, 8, 2);
        ABSTL(8, 6, 3);
        ABSTL(20, 9, 2);
        ABSTL(15, 9, 3);
        ABSTL(12, 9, 2);
        ABSTL(32, 10, 3);
        ABSTL(12, 11, 3);
        ABSTL(7, 11, 4);
        ABSTL(1, 12, 8);
        ABSTL(4, 11, 4);
        ABSTL(18, 13, 2);
        ABSTL(18, 13, 1);
        ABSTL(30, 13, 3);
        ABSTL(20, 13, 2);
        ABSTL(1, 14, 8);
        ABSTL(12, 14, 4);
        ABSTL(8, 15, 4);
        ABSTL(6, 15, 3);
        ABSTL(8, 15, 4);
        ABSTL(8, 15, 3);
        ABSTL(5, 15, 4);
        ABSTL(35, 16, 3);
        ABSTL(15, 16, 4);
        ABSTL(9, 16, 2);
        ABSTL(7, 16, 4);
        ABSTL(20, 17, 2);
        ABSTL(55, 17, 3);
        ABSTL(10, 17, 4);
        ABSTL(30, 18, 2);
        ABSTL(25, 18, 4);
        ABSTL(28, 18, 3);
        ABSTL(45, 19, 3);
        ABSTL(25, 19, 4);
        ABSTL(5, 20, 7);
        ABSTL(17, 21, 4);
        ABSTL(10, 21, 2);
        ABSTL(27, 21, 4);
        ABSTL(10, 21, 3);
        ABSTL(30, 21, 3);
        ABSTL(50, 22, 4);
        ABSTL(30, 23, 4);
        ABSTL(35, 23, 3);
        ABSTL(30, 23, 4);
        ABSTL(30, 24, 3);
        ABSTL(45, 24, 4);
        ABSTL(26, 24, 3);
        ABSTL(20, 24, 2);
        ABSTL(20, 25, 4);
        ABSTL(15, 25, 5);
        ABSTL(22, 25, 4);
        ABSTL(80, 26, 4);
        ABSTL(15, 26, 5);
        ABSTL(35, 27, 5);
        ABSTL(19, 28, 5);
        ABSTL(16, 28, 6);
        ABSTL(20, 26, 4);
        ABSTL(14, 26, 7);
        ABSTL(6, 29, 7);
        ABSTL(12, 29, 5);
        ABSTL(14, 29, 6);
        ABSTL(60, 30, 4);
        ABSTL(28, 30, 5);
        ABSTL(2, 31, 9);
        ABSTL(20, 32, 4);
        ABSTL(16, 32, 6);
        ABSTL(22, 32, 5);
        ABSTL(60, 33, 5);
        ABSTL(3, 33, 9);
        ABSTL(25, 34, 5);
        ABSTL(25, 34, 6);
        ABSTL(50, 34, 4);
        ABSTL(4, 34, 9);
        ABSTL(12, 35, 8);
        ABSTL(11, 36, 5);
        ABSTL(12, 36, 4);
        ABSTL(10, 36, 5);
        ABSTL(10, 36, 7);
        ABSTL(12, 36, 6);
        ABSTL(9, 36, 5);
        ABSTL(1, 37, 10);
        ABSTL(1, 38, 9);
        ABSTL(60, 38, 4);
        ABSTL(50, 38, 5);
        ABSTL(4, 38, 9);
        ABSTL(50, 39, 4);
        ABSTL(22, 39, 5);
        ABSTL(22, 39, 6);
        ABSTL(10, 39, 7);
        ABSTL(9, 39, 8);
        ABSTL(64, 40, 5);
        ABSTL(5, 40, 9);
        ABSTL(25, 39, 6);
        ABSTL(18, 41, 6);
        ABSTL(14, 41, 7);
        ABSTL(16, 41, 8);
        ABSTL(10, 42, 9);
        ABSTL(100, 42, 4);
        ABSTL(54, 42, 5);
        ABSTL(23, 43, 8);
        ABSTL(20, 43, 7);
        ABSTL(5, 43, 9);
        ABSTL(5, 44, 9);
        ABSTL(130, 44, 5);
        ABSTL(1, 44, 10);
        ABSTL(12, 46, 8);
        ABSTL(11, 45, 9);
        ABSTL(90, 45, 6);
        ABSTL(8, 46, 9);
        ABSTL(38, 46, 7);
        ABSTL(18, 46, 8);
        ABSTL(20, 47, 5);
        ABSTL(40, 47, 6);
        ABSTL(6, 47, 9);
        ABSTL(18, 47, 7);
        ABSTL(15, 47, 8);
        ABSTL(6, 47, 9);
        ABSTL(25, 48, 8);
        ABSTL(30, 48, 6);
        ABSTL(30, 48, 5);
        ABSTL(25, 48, 7);
        ABSTL(12, 48, 8);
        ABSTL(5, 49, 9);
        ABSTL(34, 49, 8);
        ABSTL(17, 49, 9);
        ABSTL(8, 50, 9);
        ABSTL(13, 50, 8);
        ABSTL(6, 50, 7);
        ABSTL(5, 50, 9);
        ABSTL(7, 50, 8);
        ABSTL(6, 50, 7);
        ABSTL(9, 50, 8);
        ABSTL(4, 50, 7);
        ABSTL(9, 50, 8);
        ABSTL(2, 50, 10);
        //_loc1_ = 51;
        while (round < 150)
        {
            _loc2_ = 7 + round - 50;
            _loc3_ = 0;
            while (_loc3_ < _loc2_)
            {
                _loc4_ = 5;
                Il2CppSystem.Random rand = new();
                _loc5_ = rand.Next((int)round);
                if (diff == "medium")
                {
                    _loc5_ += 3;
                }
                if (diff == "hard")
                {
                    _loc5_ += 7;
                }
                if (_loc5_ > 10)
                {
                    _loc4_ = 6;
                }
                if (_loc5_ > 16)
                {
                    _loc4_ = 7;
                }
                if (_loc5_ > 29)
                {
                    _loc4_ = 8;
                }
                if (_loc5_ > 39)
                {
                    _loc4_ = 9;
                }
                if (_loc5_ > 47)
                {
                    _loc4_ = 10;
                }
                switch (_loc4_)
                {
                    case 5:
                        ABSTL(10, round, _loc4_);
                        break;
                    case 6:
                        ABSTL(10, round, _loc4_);
                        break;
                    case 7:
                        ABSTL(10, round, _loc4_);
                        break;
                    case 8:
                        ABSTL(round - 40, round, _loc4_);
                        break;
                    case 9:
                        ABSTL(round - 42, round, _loc4_);
                        break;
                    case 10:
                        ABSTL(round - 45, round, _loc4_);
                        //ABSTL(Il2CppSystem.Math.Round (_loc1_ - 50) / 3), _loc1_, _loc4_);
                        break;
                }
                _loc3_++;
            }
            //_loc1_++;
            return;
        }
        RoundModel ABSTL(int param1, int param2, int param3)
        {
            if (round == param2)
            {
                decimal bloonInterval = 20 - round;
                if (bloonInterval < 7)
                {
                    bloonInterval = System.Math.Ceiling(7.0 - round / 20.0);
                }
                _locB_ += param1 * 72f;
                //if (BloonSring[param3 - 1].Contains("Classic"))
                //{
                //    roundModel.AddBloonGroup<ModBloonSring[param3 - 1]> (param3, _locA_, _locB_);
                //}
                //else
                {
                    roundModel.AddBloonGroup(BloonSring[param3 - 1], param3, _locA_, _locB_);
                }
                _locA_ += _locB_;
                return roundModel;
            }
            else
            {
                return roundModel;
            }
        }
        //fun BuildLevelHints() : 
      {
            var levelHints = new string[];
            levelHints[0] = "";
            levelHints[1] = "Pop, pop, pop. Too easy.";
            levelHints[2] = "";
            levelHints[3] = "";
            levelHints[4] = "You can unlock all 8 tracks by passing tracks 1 to 4 in easy mode.";
            levelHints[5] = "";
            levelHints[6] = "50 blues heading down next.";
            levelHints[7] = "The Pop Count under the tower name is how many bloons that thing has popped.";
            levelHints[8] = "";
            levelHints[9] = "Road spikes are good for getting those bloons that slip through your defenses.";
            levelHints[10] = "To recap, yellows spawn, greens, that spawn blues, that spawn reds. Yellows move very fast.";
            levelHints[11] = "Rainbow bloons are fast and mean, and have 2 blacks and 2 whites in them.";
            levelHints[12] = "";
            levelHints[13] = "The permafrost and snap freeze upgrades for Ice Towers are powerful, you should try them.";
            levelHints[14] = "Try not to rely on road spikes too much, they don\'t earn as much as they cost.";
            levelHints[15] = "Strategies that work well on some tracks may not work well on others.";
            levelHints[16] = "You can play any of the tracks on Easy, Medium, or Hard difficulties. How cool is that?";
            levelHints[17] = "";
            levelHints[18] = "Red Hot Rangs allows boomerangs to pop lead bloons.";
            levelHints[19] = "Lead Bloons move slowly, but they are immune to sharp objects. You need to use bombs or similar.";
            levelHints[20] = "";
            levelHints[21] = "Monkey Glue is good on levels with multiple paths - you can split the oncoming streams.";
            levelHints[22] = "Next level will be a doozy.";
            levelHints[23] = "";
            levelHints[24] = "Monkey Village do not attack, they just increase the range of all stuff in their radius.";
            levelHints[25] = "";
            levelHints[26] = "Some tracks are hard on easy, and others are easy on hard. Ain\'t life funny.";
            levelHints[27] = "In BTD6, every tower type has 15 upgrades, split into 3 upgrade paths.";
            levelHints[28] = "";
            levelHints[29] = "Black bloons are immune to bombs, white ones are immune to freezing.";
            levelHints[30] = "Did you know the bomb missile upgrade also gives a slight fire rate increase?";
            levelHints[31] = "";
            levelHints[32] = "60 black bloons followed by 3 ceramics coming up.";
            levelHints[33] = "Enjoying the ceramic bloons? They\'re ceramic, so they take several hits to pop. They have rainbows in them too :)";
            levelHints[34] = "";
            levelHints[35] = "";
            levelHints[36] = "Beware the MOAB - its coming next level.";
            levelHints[37] = "MOAB stands for Massive Ornary Air Blimp, not Mother Of All Bloons. Either way, it brings pain.";
            levelHints[38] = "";
            levelHints[39] = "";
            levelHints[40] = "If you manage to beat level 50, you can opt to play on in \'free play\' mode until you run out of lives.";
            levelHints[41] = "Need a cash injection? Heres 100 yellows - right after 9 browns. Sorry, it is level 42 after all.";
            levelHints[42] = "";
            levelHints[43] = "If a MOAB escapes, it\'s game over. Yes, that sucker will eat all your lives.";
            levelHints[44] = "Rainbows, browns, then 100 straight whites.";
            levelHints[45] = "";
            levelHints[46] = "Super monkey plasma shoots even faster than laser vision.";
            levelHints[47] = "";
            levelHints[48] = "Nicely done. Getting difficult yet?";
            levelHints[49] = "Here comes the final level. It\'s hard. Don\'t forget if you win you can play on in free play mode.";
        }
    }
    public class BTD3Mode : ModGameMode
    {
        public override string Difficulty => DifficultyType.Medium;


        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD3";

        public override string Icon => VanillaSprites.RegrowBloonIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //gameModeModel.UseRoundSet(ModContent.GetInstance<BTD3>().Id);
            gameModeModel.UseRoundSet("BTD3");
            //gameModeModel.UseRoundSet<BTD3>(BTD3);
            //gameModeModel.UseRoundSet(RoundSetId<BTD3>());
        }
    }
}
