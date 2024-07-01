using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using ClassicRounds;

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
}
public class BTD3Easy : ModGameMode
{
    protected override int Order => 3;
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
        gameModeModel.SetAllCashMultiplier(0.8f);
        gameModeModel.UseRoundSet<Btd3Rounds>();
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarmerTower-Banana Farmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Druid"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "GlueGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-BananaFarmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
    }
}
public class BTD3Medium : ModGameMode
{
    protected override int Order => 3;
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
                gameModeModel.SetAllCashMultiplier(0.8f);
                gameModeModel.UseRoundSet<Btd3Rounds>();
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarmerTower-Banana Farmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "DartlingGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Druid"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "GlueGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeyAce"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-BananaFarmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpikeFactory"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "WizardMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            }
}
public class BTD3Hard : ModGameMode
{
    protected override int Order => 3;
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
                gameModeModel.SetAllCashMultiplier(0.8f);
                gameModeModel.UseRoundSet<Btd3Rounds>();
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarmerTower-Banana Farmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "DartlingGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Druid"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "GlueGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeyAce"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-BananaFarmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-Pontoon"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-PortableLake"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpikeFactory"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "WizardMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
        gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            }
}
    public class BTD3Impoppable : ModGameMode
{
    protected override int Order => 3;
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
            gameModeModel.SetAllCashMultiplier(0.8f);
            gameModeModel.UseRoundSet<Btd3Rounds>();
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarm"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BananaFarmerTower-Banana Farmer"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "DartlingGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Druid"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "GlueGunner"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeyAce"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-BananaFarmer"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-Pontoon"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-PortableLake"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SpikeFactory"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "WizardMonkey"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot"));
        gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap"));
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
        }
    }
