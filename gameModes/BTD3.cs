using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using ClassicRounds.Rounds;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Extensions;

namespace ClassicRounds.GameModes
{
    public class BTD3Easy : ModGameMode
    {
        protected override int Order => 3;
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD3 Standard";

        public override string Icon => "Classic";

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
            //gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 75, 1.25f));
            if (ClassicRoundsMod.ReducedCashinClassicModes)
            {
                gameModeModel.SetAllCashMultiplier(0.8f);
            }
            gameModeModel.UseRoundSet<Btd3StandardRounds>();
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

            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }                                                                          // Powers
                                                                                       // Note: Allowing Pontoons for watery maps
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-MoabMine"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-PortableLake")); // No water towers
            //gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot")); //No ablitys
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-CamoTrap")); //no camos
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Military));
        }
    }
    public class BTD3Medium : ModGameMode
    {
        protected override int Order => 3;
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD3 Standard";

        public override string Icon => "Classic";

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
            gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0.0f, 0.8f));
            if (ClassicRoundsMod.ReducedCashinClassicModes) { gameModeModel.SetAllCashMultiplier(0.8f); }
            gameModeModel.UseRoundSet<Btd3StandardRounds>();
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
            //gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot")); //No ablitys

            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }

            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Military));
        }
    }
    public class BTD3Hard : ModGameMode
    {
        protected override int Order => 3;
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD3 Standard";

        public override string Icon => "Classic";

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
            gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0.0f, 0.625f));
            if (ClassicRoundsMod.ReducedCashinClassicModes) { gameModeModel.SetAllCashMultiplier(0.8f); }
            gameModeModel.UseRoundSet<Btd3StandardRounds>();
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
            //gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-TechBot")); //No ablitys

            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Military));
        }
    }
}