using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using ClassicRounds;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Freeplay;
using BTD_Mod_Helper.Api.ModOptions;
using Il2Cpp;
using Il2CppAssets.Scripts.Data.Gameplay.Mods;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using System.Linq;
using UnityEngine.InputSystem.Utilities;
using Il2CppAssets.Scripts.Models.TowerSets;
using System.IO;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

[assembly: MelonInfo(typeof(ClassicRounds.ClassicRoundsMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace ClassicRounds;
#pragma warning disable 1591






public class ClassicRoundsMod : BloonsTD6Mod
{
    public int[] cock = [1, 2, 3];
    public override void OnApplicationStart()
    {
        ModHelper.Msg<ClassicRoundsMod>("ClassicRounds loaded!");

    }
    public static readonly ModSettingBool ReducedCashinClassicModes = false;
    public static readonly ModSettingBool UseClassicBloonsinClassicModes = true;

    public static readonly ModSettingBool UseClassicBloonDisplays = new(true)
    {
        description = ""
    };
}




public class BTD3Easy : ModGameMode
{
    protected override int Order => 3;
    public override string Difficulty => DifficultyType.Easy;

    public override string BaseGameMode => GameModeType.None;

    public override string DisplayName => "BTD3 Standard";

    public override string Icon => "";

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
        gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0, 1.25f));
        if (ClassicRoundsMod.ReducedCashinClassicModes)
        {
            gameModeModel.SetAllCashMultiplier(0.8f);
        }
        gameModeModel.UseRoundSet<EasyBtd3Rounds>();
        // No Farms
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarmerTower-Banana Farmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-BananaFarmer"));
        // New to BTD 4/5/6
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "GlueGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Druid"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpikeFactory"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                              // Powers
                                                                                              // Note: Allowing Pontoons for watery maps
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-PortableLake")); // No water towers
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot")); //No ablitys
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap")); //no camos
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Military));
    }
}
public class BTD3Medium : ModGameMode
{
    protected override int Order => 3;
    public override string Difficulty => DifficultyType.Medium;

            public override string BaseGameMode => GameModeType.None;

            public override string DisplayName => "BTD3 Standard";

            public override string Icon => "";

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
        gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0, 5/6));
        if (ClassicRoundsMod.ReducedCashinClassicModes){gameModeModel.SetAllCashMultiplier(0.8f);}
        gameModeModel.UseRoundSet<MidBtd3Rounds>();
        // No Farms
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarmerTower-Banana Farmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-BananaFarmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-BananaFarmer")); // No Buffs
                                                                                                             // New to BTD 4/5/6, 
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "GlueGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Druid"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpikeFactory"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
        // Powers/Special Agents
        //Note: Allowing Pontoons for watery maps (BTD3 has no water)
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-PortableLake")); // No water towers
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-PortableLake"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-MeerkatSpy")); // No camos
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-AngrySquirrel"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-TribalTurtle"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot")); //No ablitys


        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Military));
    }
}
public class BTD3Hard : ModGameMode
{
    protected override int Order => 3;
    public override string Difficulty => DifficultyType.Hard;

            public override string BaseGameMode => GameModeType.None;

            public override string DisplayName => "BTD3 Standard";

            public override string Icon => "";

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
            gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0, 5 / 8));
        if (ClassicRoundsMod.ReducedCashinClassicModes){gameModeModel.SetAllCashMultiplier(0.8f);}
        gameModeModel.UseRoundSet<HardBtd3Rounds>();
        // No Farms
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarmerTower-Banana Farmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-BananaFarmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-BananaFarmer")); // No Buffs
                                                                                                             // New to BTD 4/5/6, 
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "GlueGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Druid"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpikeFactory"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
        // Powers/Special Agents
        //Note: Allowing Pontoons for watery maps (BTD3 has no water)
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-PortableLake")); // No water towers
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-PortableLake"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-MeerkatSpy")); // No camos
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-AngrySquirrel"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpecialAgents-TribalTurtle"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot")); //No ablitys


        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Military));
    }
}
    

public class BTD4Easy : ModGameMode
{
    protected override int Order => 4;
    public override string Difficulty => DifficultyType.Easy;

    public override string BaseGameMode => GameModeType.None;

    public override string DisplayName => "BTD4 Standard";

    public override string Icon => "1132_bloonstd4e_fla.btn_easy_223";

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        //BuildLevelHints(levelHints)
        gameModeModel.SetMkEnabled(false);
        gameModeModel.SetContinuesEnabled(false);
        gameModeModel.SetStartingHealth(200);
        gameModeModel.SetMaxHealth(200);
        gameModeModel.SetStartingRound(1);
        gameModeModel.SetEndingRound(50);
        gameModeModel.UseRoundSet<EasyBtd4Rounds>();
        // New to BTD 5/6
        gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0, 1.25f));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                              // Powers
                                                                                              // Note: Allowing Pontoons for watery maps
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
    }
}
public class BTD4Medium : ModGameMode
{
    protected override int Order => 4;
    public override string Difficulty => DifficultyType.Medium;

    public override string BaseGameMode => GameModeType.None;

    public override string DisplayName => "BTD4 Standard";

    public override string Icon => "1142_bloonstd4e_fla.btn_med_226";

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        //BuildLevelHints(levelHints)
        gameModeModel.SetMkEnabled(false);
        gameModeModel.SetContinuesEnabled(false);
        gameModeModel.SetStartingHealth(150);
        gameModeModel.SetMaxHealth(150);
        gameModeModel.SetStartingRound(1);
        gameModeModel.SetEndingRound(60);
        gameModeModel.UseRoundSet<MidBtd4Rounds>();
        // New to BTD 4/5/6
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                              // Powers
                                                                                              // Note: Allowing Pontoons for watery maps
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
    }
}
public class BTD4Hard : ModGameMode
{
    protected override int Order => 4;
    public override string Difficulty => DifficultyType.Hard;

    public override string BaseGameMode => GameModeType.None;

    public override string DisplayName => "BTD4 Standard";

    public override string Icon => "1151_bloonstd4e_fla.btn_hard_229";

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        //BuildLevelHints(levelHints)
        gameModeModel.SetMkEnabled(false);
        gameModeModel.SetContinuesEnabled(false);
        gameModeModel.SetStartingHealth(100);
        gameModeModel.SetMaxHealth(100);
        gameModeModel.SetStartingRound(1);
        gameModeModel.SetEndingRound(75);
        gameModeModel.UseRoundSet<HardBtd4Rounds>();
        // New to BTD 4/5/6
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                              // Powers
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
    }
}
public class BTD4Deflation : ModGameMode
{
    protected override int Order => 5;
    public override string Difficulty => DifficultyType.Medium;

    public override string BaseGameMode => GameModeType.None;

    public override string DisplayName => "BTD4 Deflation";

    public override string Icon => "1186_bloonstd4e_fla.deflationmodebtn_238";

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        //BuildLevelHints(levelHints)
        gameModeModel.SetMkEnabled(false);
        gameModeModel.SetContinuesEnabled(false);
        gameModeModel.SetStartingCash(50000);
        gameModeModel.SetStartingHealth(150);
        gameModeModel.SetMaxHealth(150);
        gameModeModel.SetStartingRound(21);
        gameModeModel.SetEndingRound(60);
        gameModeModel.AddMutator(new DeflationModel("DeflationModel_")); 
        gameModeModel.SetAllCashMultiplier(0.0f);
        gameModeModel.UseRoundSet<MidBtd4Rounds>();
        // New to BTD 4/5/6
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                              // Powers
                                                                                              // Note: Allowing Pontoons for watery maps
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
    }
}

public class BTD4Apopalypse : ModGameMode
{
    protected override int Order => 5;
    public override string Difficulty => DifficultyType.Medium;

    public override string BaseGameMode => GameModeType.None;

    public override string DisplayName => "BTD4 Apopalypse";

    public override string Icon => "1180_bloonstd4e_fla.continuousmodebtn_237";

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        //BuildLevelHints(levelHints)
        gameModeModel.SetMkEnabled(false);
        gameModeModel.SetContinuesEnabled(false);
        gameModeModel.SetStartingHealth(150);
        gameModeModel.SetMaxHealth(150);
        gameModeModel.SetStartingRound(1);
        gameModeModel.SetEndingRound(60);
        gameModeModel.AddMutator(new ApopalypseModel("ApopalypseModel_"));
        gameModeModel.UseRoundSet<Btd4ApopRounds>();
        // New to BTD 4/5/6
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                              // Powers
                                                                                              // Note: Allowing Pontoons for watery maps
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
    }
}
//[HarmonyPatch(typeof(ProgressiveDifficultyManager), nameof(ProgressiveDifficultyManager.GetSpeedMultiplier))]
//static class ProgressiveDifficultyManagerPatch
//{
//[HarmonyPrefix]
//private static void Prefix(ProgressiveDifficultyManager __instance, int roundOnScreen, ref bool __result)
//{
//if (InGame.instance.GetGameModel().gameMode.Contains("BTD3"))
//{
//var i = new __instance.GetSpeedMultiplier(roundOnScreen);
//__result = i(roundOnScreen + 30);
//return false;
//}
//return true;
//}
//}

[HarmonyPatch(typeof(TowerSelectionMenu), nameof(TowerSelectionMenu.IsUpgradePathClosed))]
static class IsUpgradePathClosedPatch
{
    [HarmonyPostfix]
    /// <summary>
    /// Notes: 
    /// - No Camos for Counter-Espionage or Radar Scanner
    /// - No Regrows for Grow Blocker
    /// - No Regrows OR life regen for Heart of Oak.
    /// </summary>
    private static void Postfix(TowerSelectionMenu __instance, int path, ref bool __result)
    {
        if (__instance.selectedTower == null) { return; }
        if (InGame.instance.bridge.IsSandboxMode()) { return; }

        if (InGame.instance.GetGameModel().gameMode.Contains("BTD3") || InGame.instance.GetGameModel().gameMode.Contains("BTD4") || InGame.instance.GetGameModel().gameMode.Contains("BTD5"))
        {
            Tower tower = __instance.selectedTower.tower;
            if (tower.towerModel.IsHero()) { return; }

            if (tower.GetUpgrade(path) == null) { return; }

            //foreach(var i in InGame.instance.GetAllTowerToSim().ToArray()) 
            //{ 
            //if( i.tower.model)
            //}

            string bid = tower.towerModel.baseId;
            string gamemode = InGame.instance.GetGameModel().gameMode;
            if (!gamemode.Contains("BTD")) { return; }
            else
            {
                __result = false;
                if ((bid == "SuperMonkey" || bid == "SpikeFactory") && path == 2) { __result = true; return; } //No bottom path Super or Spike Factory
                if (gamemode.Contains("BTD3") && (bid == "MonkeyVillage" || bid == "NinjaMonkey") && path == 1) { __result = true; } //See summary
                if (gamemode.Contains("BTD3") && (bid == "MonkeyAce"  || bid == "HeliPilot" || bid == "Druid") && path == 1 && tower.GetUpgrade(path).tier >= 1) { __result = true; } //ditto
                if (gamemode.Contains("BTD3") && tower.GetUpgrade(path).tier >= 2) { __result = true; } //No tier 3s and up
                if (gamemode.Contains("BTD4") && tower.GetUpgrade(path).tier >= 3) { __result = true; } //No tier 4s and up
                //if (gamemode.Contains("BTD4") && bid == "SuperMonkey" && path == 0 && tower.GetUpgrade(path).tier == 4) { __result = false; } //(not always no) BTD4 Sun Temple
                if ((gamemode.Contains("BTD5") || gamemode.Contains("BTDB") ) && tower.GetUpgrade(path).tier >= 4) { __result = true; } //No tier 5s and up
            }
            return;
        }
    }
}

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
internal static class Bloon_Damage //Wizard
{
    static string[] AddBlackWeakness = [ "Alchemist" ];

    /// <summary>
    /// Classic Black Bloons
    /// </summary>
    static string[] AddBlackWeaknessIfPurpleWeak = ["WizardMonkey", "AncientMonkey", "AncientMonkey", "Phoenix", "PermaPhoenix", "LordPhoenix"]; //

    [HarmonyPrefix]
    private static void Prefix(Bloon __instance, float totalAmount, Projectile projectile, bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect, Tower tower, BloonProperties immuneBloonProperties = BloonProperties.None, bool canDestroyProjectile = true, bool ignoreNonTargetable = false, bool blockSpawnChildren = false, bool ignoreInvunerable = false)
    {
        if (__instance != null && tower != null)
        {
            bool ShouldAddBlackWeakness = false;
            //InGame game = InGame.instance;
            string bid = tower.towerModel.baseId;

            foreach (string i in AddBlackWeakness) 
            {
                if (bid.Contains(i)) { ShouldAddBlackWeakness = true; }
            }
            if (immuneBloonProperties == BloonProperties.Purple && immuneBloonProperties != BloonProperties.White) //
            {
                foreach (string i in AddBlackWeaknessIfPurpleWeak)
                {
                    if (bid.Contains(i) || tower.towerModel.towerSet == TowerSet.Hero) { ShouldAddBlackWeakness = true; }
                }
            }
            if (__instance.bloonModel.name.Contains("ClassicBlack") && ShouldAddBlackWeakness)
            {
                immuneBloonProperties &= ~BloonProperties.Black;
            }
            //foreach (Slow i in projectile.GetProjectileBehaviors<Slow>())
            //{
                //if (i.slowModel.Mutator.id.Contains("Stun"))
                //{
                    //i.projectile.projectileModel.RemoveBehaviors<SlowModel>();
                    //i.projectile.projectileModel.AddBehavior<FreezeModel>(mer);
                //}
            //}
        }
    }
}