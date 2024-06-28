using MelonLoader;
using BTD_Mod_Helper;
using ClassicTowers;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.Main.DifficultySelect;
using Il2Cpp;
using Il2CppAssets.Scripts.Unity.UI_New.Main.ModeSelect;
using Il2CppAssets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Extensions;
using System;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Utils.ElasticSearch;
using System.ComponentModel;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using UnityEngine.UIElements;
using ClassicRounds.Bloons;

[assembly: MelonInfo(typeof(ClassicRounds.ClassicRounds), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace ClassicRounds;

public class ClassicRounds : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<ClassicRounds>("ClassicRounds loaded!");
    }

    static float BloonInterval(int curLevel)
    {
        float bloonInterval = 20 - curLevel;
        if (bloonInterval < 7)
        {
            bloonInterval = (float)Math.Ceiling((double)(7 - curLevel / 20));
        };
        return bloonInterval * 2;
    }
    public class BTD3Easy : ModGameMode
    {
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD3";

        public override string Icon => VanillaSprites.CustomRoundIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //BuildLevelHints(levelHints)
            gameModeModel.SetMkEnabled(false);
            gameModeModel.SetIncomeEnabled(false);
            gameModeModel.SetContinuesEnabled(false);
            gameModeModel.SetStartingHealth(100);
            gameModeModel.SetMaxHealth(100);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(50);
            gameModeModel.UseRoundSet<Btd3Rounds>();
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
        }
        public class BTD3Medium : ModGameMode
        {
            public override string Difficulty => DifficultyType.Medium;

            public override string BaseGameMode => GameModeType.None;

            public override string DisplayName => "BTD3";

            public override string Icon => VanillaSprites.CustomRoundIcon;

            public override void ModifyBaseGameModeModel(ModModel gameModeModel)
            {
                //BuildLevelHints(levelHints)
                gameModeModel.SetMkEnabled(false);
                gameModeModel.SetIncomeEnabled(false);
                gameModeModel.SetContinuesEnabled(false);
                gameModeModel.SetStartingHealth(75);
                gameModeModel.SetMaxHealth(75);
                gameModeModel.SetStartingRound(1);
                gameModeModel.SetEndingRound(50);
                gameModeModel.UseRoundSet<Btd3Rounds>();
                gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
                gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
                gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            }
        }
        public class BTD3Hard : ModGameMode
        {
            public override string Difficulty => DifficultyType.Hard;

            public override string BaseGameMode => GameModeType.None;

            public override string DisplayName => "BTD3";

            public override string Icon => VanillaSprites.CustomRoundIcon;

            public override void ModifyBaseGameModeModel(ModModel gameModeModel)
            {
                //BuildLevelHints(levelHints)
                gameModeModel.SetMkEnabled(false);
                gameModeModel.SetIncomeEnabled(false);
                gameModeModel.SetContinuesEnabled(false);
                gameModeModel.SetStartingHealth(50);
                gameModeModel.SetMaxHealth(50);
                gameModeModel.SetStartingRound(1);
                gameModeModel.SetEndingRound(50);
                gameModeModel.UseRoundSet<Btd3Rounds>();
                gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
                gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
                gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            }
        }

        public class BTD3Impoppable : ModGameMode
        {
            public override string Difficulty => DifficultyType.Hard;

            public override string BaseGameMode => GameModeType.None;

            public override string DisplayName => "BTD3 Impoppable";

            public override string Icon => VanillaSprites.CustomRoundIcon;

            public override void ModifyBaseGameModeModel(ModModel gameModeModel)
            {
                //BuildLevelHints(levelHints)
                gameModeModel.SetMkEnabled(false);
                gameModeModel.SetImpoppable(true);
                gameModeModel.SetIncomeEnabled(false);
                gameModeModel.SetContinuesEnabled(false);
                gameModeModel.SetStartingHealth(1);
                gameModeModel.SetMaxHealth(1);
                gameModeModel.SetStartingRound(1);
                gameModeModel.SetEndingRound(70);
                gameModeModel.UseRoundSet<Btd3Rounds>();
                gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
                gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
                gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
                gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            }
        }

        private void BuildLevelHints(string[] levelHints)
        {
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
            levelHints[18] = "Thermite allows boomerangs to pop lead bloons.";
            levelHints[19] = "Lead bloons move slowly, but they are immune to sharp objects. You need to use bombs or similar.";
            levelHints[20] = "";
            levelHints[21] = "Monkey glue is good on levels with multiple paths - you can split the oncoming streams.";
            levelHints[22] = "Next level will be a doozy.";
            levelHints[23] = "";
            levelHints[24] = "Monkey beacons do not attack, they just increase the range of all stuff in their radius.";
            levelHints[25] = "";
            levelHints[26] = "Some tracks are hard on easy, and others are easy on hard. Ain\'t life funny.";
            levelHints[27] = "In BTD6, every tower type has 15 upgrades, split into 3 upgrade paths.";
            levelHints[28] = "";
            levelHints[29] = "Black bloons are immune to bombs, white ones are immune to freezing.";
            levelHints[30] = "Did you know the Missile Launcher upgrade also gives a slight fire rate increase?";
            levelHints[31] = "";
            levelHints[32] = "60 black bloons followed by 3 brown coming up.";
            levelHints[33] = "Enjoying the Ceramic bloons? They\'re ceramic, so they take several hits to pop. They have rainbows in them too :)";
            levelHints[34] = "";
            levelHints[35] = "";
            levelHints[36] = "Beware the M.O.A.B - its coming next level.";
            levelHints[37] = "M.O.A.B stands for Massive Ornary Air Blimp, not Mother Of All Bloons. Either way, it brings pain.";
            levelHints[38] = "";
            levelHints[39] = "";
            levelHints[40] = "If you manage to beat level 50, you can opt to play on in \'free play\' mode until you run out of lives.";
            levelHints[41] = "Need a cash injection? Heres 100 yellows - right after 9 Ceramics. Sorry, it is level 42 after all.";
            levelHints[42] = "";
            levelHints[43] = "If a M.O.A.B escapes, it\'s game over. Yes, that sucker will eat all your lives.";
            levelHints[44] = "Rainbows, Ceramics, then 100 straight whites.";
            levelHints[45] = "";
            levelHints[46] = "Super monkey plasma shoots even faster than laser vision.";
            levelHints[47] = "";
            levelHints[48] = "Nicely done. Getting difficult yet?";
            levelHints[49] = "Here comes the final level. It\'s hard. Don\'t forget if you win you can play on in free play mode.";
        }
    }
    public class Btd3Rounds : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Empty;
        public override int DefinedRounds => 150;
        public override string DisplayName => "BTD3";
        public override string Icon => VanillaSprites.CustomRoundIcon;
        public float delay = 0;
        private int _loc2_; //these are varables for freeplay round generation
        private int _loc3_;
        private int _loc4_;
        private int _loc5_;
        public string[] levelHints = new string[50];
        static float ABSTL(int bloonCount, int curLevel, int bloonRank, RoundModel roundModel, float delay)
        {
            switch (bloonRank)
            {
                case 1: //reds
                    roundModel.AddBloonGroup("Red", bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                    delay += BloonInterval(curLevel) * bloonCount;
                    return delay;
                case 2: //blues
                    roundModel.AddBloonGroup("Blue", bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                    delay += BloonInterval(curLevel) * bloonCount;
                    return delay;
                case 3: //greens
                    roundModel.AddBloonGroup("Green", bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                    delay += BloonInterval(curLevel) * bloonCount;
                    return delay;
                case 4: //Yellow
                    roundModel.AddBloonGroup("Yellow", bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                    delay += BloonInterval(curLevel) * bloonCount;
                    return delay;
                case 5: //blacks
                    if (curLevel < 60)
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicBlack>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    else
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicLead>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    return delay;
                case 6: //White
                    if (curLevel < 60)
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicWhite>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    else
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicIce>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    return delay;
                case 7: //Lead
                    if (curLevel < 60)
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicLead>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    else
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicLead>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    return delay;
                case 8: //Rainbow
                    if (curLevel < 60)
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicRainbow>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    else
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicRainbow>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    return delay;
                case 9: //Ceramic
                    if (curLevel < 60)
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicCeramic>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    else
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicCeramicF>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    return delay;
                case 10: // MOABs
                    //roundModel.AddBloonGroup("Black", bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                    //delay += BloonInterval(curLevel) * bloonCount;
                    if (curLevel < 60)
                    {
                        roundModel.AddBloonGroup(BloonID<ClassicMoab>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        delay += BloonInterval(curLevel) * bloonCount;
                    }
                    else
                    {
                        //if (curLevel >= 90 && curLevel % 10 == 0 || curLevel >= 93 && curLevel % 2 == 1)
                        // round 90, every 10th round after round 90, round 93, & every odd round after round 93
                        //{
                        //roundModel.AddBloonGroup("Ddt", bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                        //delay += BloonInterval(curLevel) * bloonCount;
                        //}
                        //else
                        {
                            roundModel.AddBloonGroup(BloonID<ClassicMoab>(), bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                            delay += BloonInterval(curLevel) * bloonCount;
                        }
                    }
                    return delay;
                case 11: // DDTs\Fortified MOABs

                    roundModel.AddBloonGroup("Ddt", bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
                    delay += BloonInterval(curLevel) * bloonCount;
                    return delay;

                default:
                    ModHelper.Warning<ClassicRounds>("Round " + curLevel + ": Specified bloon rank out of bounds, using pink bloons!");
                    roundModel.AddBloonGroup("Pink", bloonCount, delay, delay + BloonInterval(curLevel));
                    delay += BloonInterval(curLevel) * bloonCount;
                    return delay;
            }
        }

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            float delay = 0;
            switch (round)
            {
                case 0:
                    delay = 0;
                    ABSTL(14, round, 1, roundModel, delay);
                    break;
                case 1:
                    delay = 0;
                    ABSTL(30, round, 1, roundModel, delay);
                    break;
                case 2:
                    delay = 0;
                    delay = ABSTL(10, 3, 1, roundModel, delay);
                    delay = ABSTL(4, 3, 2, roundModel, delay);
                    ABSTL(5, 3, 1, roundModel, delay);
                    break;
                case 3:
                    delay = 0;
                    delay = ABSTL(5, 4, 1, roundModel, delay);
                    delay = ABSTL(12, 4, 2, roundModel, delay);
                    delay = ABSTL(5, 4, 1, roundModel, delay);
                    delay = ABSTL(12, 4, 2, roundModel, delay);
                    break;
                case 4:
                    delay = 0;
                    delay = ABSTL(10, 5, 1, roundModel, delay);
                    delay = ABSTL(8, 5, 2, roundModel, delay);
                    delay = ABSTL(12, 5, 1, roundModel, delay);
                    ABSTL(20, 5, 2, roundModel, delay);
                    break;
                case 5:
                    delay = 0;
                    delay = ABSTL(13, 6, 1, roundModel, delay);
                    delay = ABSTL(7, 6, 3, roundModel, delay);
                    ABSTL(8, 6, 3, roundModel, delay); // this one was after round 7 for some reson..
                    break;
                case 6:
                    delay = 0;
                    ABSTL(50, 7, 2, roundModel, delay);
                    break;
                case 7:
                    delay = 0;
                    delay = ABSTL(9, 8, 1, roundModel, delay);
                    delay = ABSTL(16, 8, 2, roundModel, delay);
                    delay = ABSTL(9, 8, 1, roundModel, delay);
                    delay = ABSTL(7, 8, 2, roundModel, delay);
                    delay = ABSTL(9, 8, 1, roundModel, delay);
                    ABSTL(7, 8, 2, roundModel, delay);
                    break;
                case 8:
                    delay = 0;
                    delay = ABSTL(20, 9, 2, roundModel, delay);
                    delay = ABSTL(15, 9, 3, roundModel, delay);
                    ABSTL(12, 9, 2, roundModel, delay);
                    break;
                case 9:
                    delay = 0;
                    ABSTL(32, 10, 3, roundModel, delay);
                    break;
                case 10:
                    delay = 0;
                    delay = ABSTL(12, 11, 3, roundModel, delay);
                    delay = ABSTL(7, 11, 4, roundModel, delay);
                    ABSTL(4, 11, 4, roundModel, delay);
                    break;
                case 11:
                    delay = 0;
                    ABSTL(1, 12, 8, roundModel, delay);
                    break;
                case 12:
                    delay = 0;
                    delay = ABSTL(18, 13, 2, roundModel, delay);
                    delay = ABSTL(18, 13, 1, roundModel, delay);
                    delay = ABSTL(30, 13, 3, roundModel, delay);
                    ABSTL(20, 13, 2, roundModel, delay);
                    break;
                case 13:
                    delay = 0;
                    delay = ABSTL(1, 14, 8, roundModel, delay);
                    ABSTL(12, 14, 4, roundModel, delay);
                    break;
                case 14:
                    delay = 0;
                    delay = ABSTL(8, 15, 4, roundModel, delay);
                    delay = ABSTL(6, 15, 3, roundModel, delay);
                    delay = ABSTL(8, 15, 4, roundModel, delay);
                    delay = ABSTL(8, 15, 3, roundModel, delay);
                    ABSTL(5, 15, 4, roundModel, delay);
                    break;
                case 15:
                    delay = 0;
                    delay = ABSTL(35, 16, 3, roundModel, delay);
                    delay = ABSTL(15, 16, 4, roundModel, delay);
                    delay = ABSTL(9, 16, 2, roundModel, delay);
                    ABSTL(7, 16, 4, roundModel, delay);
                    break;
                case 16:
                    delay = 0;
                    delay = ABSTL(20, 17, 2, roundModel, delay);
                    delay = ABSTL(55, 17, 3, roundModel, delay);
                    ABSTL(10, 17, 4, roundModel, delay);
                    break;
                case 17:
                    delay = 0;
                    delay = ABSTL(30, 18, 2, roundModel, delay);
                    delay = ABSTL(25, 18, 4, roundModel, delay);
                    ABSTL(28, 18, 3, roundModel, delay);
                    break;
                case 18:
                    delay = 0;
                    delay = ABSTL(45, 19, 3, roundModel, delay);
                    ABSTL(25, 19, 4, roundModel, delay);
                    break;
                case 19:
                    delay = 0;
                    ABSTL(5, 20, 7, roundModel, delay);
                    break;
                case 20:
                    delay = 0;
                    delay = ABSTL(17, 21, 4, roundModel, delay);
                    delay = ABSTL(10, 21, 2, roundModel, delay);
                    delay = ABSTL(27, 21, 4, roundModel, delay);
                    delay = ABSTL(10, 21, 3, roundModel, delay);
                    delay = ABSTL(30, 21, 3, roundModel, delay);
                    break;
                case 21:
                    delay = 0;
                    ABSTL(50, 22, 4, roundModel, delay);
                    break;
                case 22:
                    delay = 0;
                    delay = ABSTL(30, 23, 4, roundModel, delay);
                    delay = ABSTL(35, 23, 3, roundModel, delay);
                    ABSTL(30, 23, 4, roundModel, delay);
                    break;
                case 23:
                    delay = 0;
                    delay = ABSTL(30, 24, 3, roundModel, delay);
                    delay = ABSTL(45, 24, 4, roundModel, delay);
                    delay = ABSTL(26, 24, 3, roundModel, delay);
                    ABSTL(20, 24, 2, roundModel, delay);
                    break;
                case 24:
                    delay = 0;
                    delay = ABSTL(20, 25, 4, roundModel, delay);
                    delay = ABSTL(15, 25, 5, roundModel, delay);
                    ABSTL(22, 25, 4, roundModel, delay);
                    break;
                case 25:
                    delay = 0;
                    delay = ABSTL(80, 26, 4, roundModel, delay);
                    delay = ABSTL(15, 26, 5, roundModel, delay);
                    //after 27..
                    delay = ABSTL(20, 26, 4, roundModel, delay);
                    ABSTL(14, 26, 7, roundModel, delay);
                    break;
                case 26:
                    delay = 0;
                    ABSTL(35, 27, 5, roundModel, delay);
                    break;
                case 27:
                    delay = 0;
                    delay = ABSTL(19, 28, 5, roundModel, delay);
                    ABSTL(16, 28, 6, roundModel, delay);
                    break;
                case 28:
                    delay = 0;
                    delay = ABSTL(6, 29, 7, roundModel, delay);
                    delay = ABSTL(12, 29, 5, roundModel, delay);
                    ABSTL(14, 29, 6, roundModel, delay);
                    break;
                case 29:
                    delay = 0;
                    delay = ABSTL(60, 30, 4, roundModel, delay);
                    ABSTL(28, 30, 5, roundModel, delay);
                    break;
                case 30:
                    delay = 0;
                    ABSTL(2, 31, 9, roundModel, delay);
                    break;
                case 31:
                    delay = 0;
                    delay = ABSTL(20, 32, 4, roundModel, delay);
                    delay = ABSTL(16, 32, 6, roundModel, delay);
                    ABSTL(22, 32, 5, roundModel, delay);
                    break;
                case 32:
                    delay = 0;
                    delay = ABSTL(60, 33, 5, roundModel, delay);
                    ABSTL(3, 33, 9, roundModel, delay);
                    break;
                case 33:
                    delay = 0;
                    delay = ABSTL(25, 34, 5, roundModel, delay);
                    delay = ABSTL(25, 34, 6, roundModel, delay);
                    delay = ABSTL(50, 34, 4, roundModel, delay);
                    ABSTL(4, 34, 9, roundModel, delay);
                    break;
                case 34:
                    delay = 0;
                    ABSTL(12, 35, 8, roundModel, delay);
                    break;
                case 35:
                    delay = 0;
                    delay = ABSTL(11, 36, 5, roundModel, delay);
                    delay = ABSTL(12, 36, 4, roundModel, delay);
                    delay = ABSTL(10, 36, 5, roundModel, delay);
                    delay = ABSTL(10, 36, 7, roundModel, delay);
                    delay = ABSTL(12, 36, 6, roundModel, delay);
                    ABSTL(9, 36, 5, roundModel, delay);
                    break;
                case 36:
                    delay = 0;
                    ABSTL(1, 37, 10, roundModel, delay);
                    break;
                case 37:
                    delay = 0;
                    delay = ABSTL(1, 38, 9, roundModel, delay);
                    delay = ABSTL(60, 38, 4, roundModel, delay);
                    delay = ABSTL(50, 38, 5, roundModel, delay);
                    ABSTL(4, 38, 9, roundModel, delay);
                    break;
                case 38:
                    delay = 0;
                    delay = ABSTL(50, 39, 4, roundModel, delay);
                    delay = ABSTL(22, 39, 5, roundModel, delay);
                    delay = ABSTL(22, 39, 6, roundModel, delay);
                    delay = ABSTL(10, 39, 7, roundModel, delay);
                    delay = ABSTL(9, 39, 8, roundModel, delay);
                    //
                    ABSTL(25, 39, 6, roundModel, delay);
                    break;
                case 39:
                    delay = 0;
                    delay = ABSTL(64, 40, 5, roundModel, delay);
                    ABSTL(5, 40, 9, roundModel, delay);
                    break;
                case 40:
                    delay = 0;
                    delay = ABSTL(18, 41, 6, roundModel, delay);
                    delay = ABSTL(14, 41, 7, roundModel, delay);
                    ABSTL(16, 41, 8, roundModel, delay);
                    break;
                case 41:
                    delay = 0;
                    delay = ABSTL(10, 42, 9, roundModel, delay);
                    delay = ABSTL(100, 42, 4, roundModel, delay);
                    ABSTL(54, 42, 5, roundModel, delay);
                    break;
                case 42:
                    delay = 0;
                    delay = ABSTL(23, 43, 8, roundModel, delay);
                    delay = ABSTL(20, 43, 7, roundModel, delay);
                    ABSTL(5, 43, 9, roundModel, delay);
                    break;
                case 43:
                    delay = 0;
                    delay = ABSTL(5, 44, 9, roundModel, delay);
                    delay = ABSTL(130, 44, 5, roundModel, delay);
                    ABSTL(1, 44, 10, roundModel, delay);
                    break;
                case 44:
                    delay = 0;
                    delay = ABSTL(11, 45, 9, roundModel, delay);
                    ABSTL(90, 45, 6, roundModel, delay);
                    break;
                case 45:
                    delay = 0;
                    delay = ABSTL(12, 46, 8, roundModel, delay);
                    //44
                    delay = ABSTL(8, 46, 9, roundModel, delay);
                    delay = ABSTL(38, 46, 7, roundModel, delay);
                    ABSTL(18, 46, 8, roundModel, delay);
                    break;
                case 46:
                    delay = 0;
                    delay = ABSTL(20, 47, 5, roundModel, delay);
                    delay = ABSTL(40, 47, 6, roundModel, delay);
                    delay = ABSTL(6, 47, 9, roundModel, delay);
                    delay = ABSTL(18, 47, 7, roundModel, delay);
                    delay = ABSTL(15, 47, 8, roundModel, delay);
                    ABSTL(6, 47, 9, roundModel, delay);
                    break;
                case 47:
                    delay = 0;
                    delay = ABSTL(25, 48, 8, roundModel, delay);
                    delay = ABSTL(30, 48, 6, roundModel, delay);
                    delay = ABSTL(30, 48, 5, roundModel, delay);
                    delay = ABSTL(25, 48, 7, roundModel, delay);
                    ABSTL(12, 48, 8, roundModel, delay);
                    break;
                case 48:
                    delay = 0;
                    delay = ABSTL(5, 49, 9, roundModel, delay);
                    delay = ABSTL(34, 49, 8, roundModel, delay);
                    ABSTL(17, 49, 9, roundModel, delay);
                    break;
                case 49:
                    delay = 0;
                    delay = ABSTL(8, 50, 9, roundModel, delay);
                    delay = ABSTL(13, 50, 8, roundModel, delay);
                    delay = ABSTL(6, 50, 7, roundModel, delay);
                    delay = ABSTL(5, 50, 9, roundModel, delay);
                    delay = ABSTL(7, 50, 8, roundModel, delay);
                    delay = ABSTL(6, 50, 7, roundModel, delay);
                    delay = ABSTL(9, 50, 8, roundModel, delay);
                    delay = ABSTL(4, 50, 7, roundModel, delay);
                    delay = ABSTL(9, 50, 8, roundModel, delay);
                    ABSTL(2, 50, 10, roundModel, delay);
                    break;
                default:
                    delay = 0;
                    if (!(round >= 50))

                    {
                        ModHelper.Warning<ClassicRounds>("Round " + round + 1 + ": Missing round data, sending some browns");
                        ABSTL(6, round, 9, roundModel, delay);
                        break;
                    }
                    else
                    {
                        var rand = new Random();

                        _loc2_ = 8 + round - 50;
                        _loc3_ = 0;
                        while (_loc3_ < _loc2_)
                        {
                            _loc4_ = 5;
                            _loc5_ = (int)(rand.Next(round));
                            //if (diff == "medium")
                            //{
                            _loc5_ += 3;
                            //}
                            //if (diff == "hard")
                            //{
                            //    _loc5_ += 7;
                            //}
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
                                    delay = ABSTL(10, round, _loc4_, roundModel, delay);
                                    break;
                                case 6:
                                    delay = ABSTL(10, round, _loc4_, roundModel, delay);
                                    break;
                                case 7:
                                    delay = ABSTL(10, round, _loc4_, roundModel, delay);
                                    break;
                                case 8:
                                    delay = ABSTL(round - 40, round, _loc4_, roundModel, delay);
                                    break;
                                case 9:
                                    delay = ABSTL(round - 42, round, _loc4_, roundModel, delay);
                                    break;
                                case 10:
                                    delay = ABSTL((int)Math.Round((double)(round - 50) / 3), round, _loc4_, roundModel, delay);
                                    break;
                                default:
                                    break;
                            }
                            _loc3_++;
                        }
                        break;

                    }
            }
        }
    }
}
