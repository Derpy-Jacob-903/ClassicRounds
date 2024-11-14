using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using ClassicRounds.Rounds;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Extensions;

namespace ClassicRounds.GameModes
{
    public class BTD4Easy : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD4 Standard";

        public override string Icon => "BTD4Easy";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //BuildLevelHints(levelHints)
            gameModeModel.SetMkEnabled(false);
            gameModeModel.SetContinuesEnabled(false);
            gameModeModel.SetStartingHealth(200);
            gameModeModel.SetMaxHealth(200);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(50);
            gameModeModel.UseRoundSet<Btd4StandardRounds>();
            // New to BTD 5/6
            //gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0.0f, 1.25f));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                                  // Powers
                                                                                                  // Note: Allowing Pontoons for watery maps
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));


            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD4Medium : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD4 Standard";

        public override string Icon => "BTD4Medium";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //BuildLevelHints(levelHints)
            gameModeModel.SetMkEnabled(false);
            gameModeModel.SetContinuesEnabled(false);
            gameModeModel.SetStartingHealth(150);
            gameModeModel.SetMaxHealth(150);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(60);
            gameModeModel.UseRoundSet<Btd4StandardRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                                  // Powers
                                                                                                  // Note: Allowing Pontoons for watery maps
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD4Hard : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD4 Standard";

        public override string Icon => "BTD4Hard";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //BuildLevelHints(levelHints)
            gameModeModel.SetMkEnabled(false);
            gameModeModel.SetContinuesEnabled(false);
            gameModeModel.SetStartingHealth(100);
            gameModeModel.SetMaxHealth(100);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(75);
            gameModeModel.UseRoundSet<Btd4StandardRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                                  // Powers
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem"));
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD4Deflation : ModGameMode
    {
        protected override int Order => 5;
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD4 Deflation";

        public override string Icon => "BTD4Deflation";

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
            gameModeModel.UseRoundSet<Btd4StandardRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "HeliPilot"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                                  // Powers
                                                                                                  // Note: Allowing Pontoons for watery maps
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }

    public class BTD4Apopalypse : ModGameMode
    {
        protected override int Order => 5;
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD4 Apopalypse";

        public override string Icon => "BTD4Apopalypse";

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
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "SniperMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "NinjaMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "MonkeySub"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "EngineerMonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Eevee-Eevee"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); //
                                                                                                  // Powers
                                                                                                  // Note: Allowing Pontoons for watery maps
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "PowersInShop-EnergisingTotem")); // No Buffs
            gameModeModel.AddMutator(new LockTowerSetModModel("LockTowerSetModModel_", Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Hero));

            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
}