using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using ClassicRounds.Rounds;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System;

namespace ClassicRounds.GameModes
{
    public class BTD5Easy : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD5 Standard";

        public override string Icon => "BTD5Easy";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //BuildLevelHints(levelHints)
            gameModeModel.SetMkEnabled(false);
            gameModeModel.SetContinuesEnabled(false);
            gameModeModel.SetStartingHealth(200);
            gameModeModel.SetMaxHealth(200);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(50);
            gameModeModel.UseRoundSet<Btd5StandardRounds>();
            // New to BTD 5/6
            //gameModeModel.AddMutator(new MonkeyMoneyModModel("MonkeyMoneyModModel_", 0.0f, 1.25f));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));


            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD5Medium : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD5 Standard";

        public override string Icon => "BTD5Medium";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //BuildLevelHints(levelHints)
            gameModeModel.SetMkEnabled(false);
            gameModeModel.SetContinuesEnabled(false);
            gameModeModel.SetStartingHealth(150);
            gameModeModel.SetMaxHealth(150);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(60);
            gameModeModel.UseRoundSet<Btd5StandardRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD5Hard : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD5 Standard";

        public override string Icon => "BTD5Hard";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.SetStartingHealth(100);
            gameModeModel.SetMaxHealth(100);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(85);
            gameModeModel.UseRoundSet<Btd5StandardRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD5Impop : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD5 Impoppable";

        public override string Icon => VanillaSprites.ImpoppableBtn;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.SetStartingHealth(1);
            gameModeModel.SetMaxHealth(1);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(85);
            gameModeModel.SetImpoppable(true);
            gameModeModel.SetBloonHealth(1.5f, BloonTag.Ceramic);
            gameModeModel.SetBloonHealth(2f, BloonTag.Moabs);
            gameModeModel.UseRoundSet<Btd5ImpopRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD5Chimps : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.Clicks;

        public override string DisplayName => "BTD5 NPMKFRILLS";
        public override string Description => "The true test of a BTD5 master. No Powers*, Monkey Knowledge, Income, Road Items, Lives Lost, or Selling.\n *How the fuck do I disable powers?";

        public override string Icon => VanillaSprites.ClicksBtn;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(85);

            gameModeModel.SetContinuesEnabled(false);

            gameModeModel.SetImpoppable(true);

            gameModeModel.SetMkEnabled(false);

            gameModeModel.SetIncomeEnabled(false);
            

            gameModeModel.AddMutator( new ChimpsModModel("ChimpsModModel_"));
            gameModeModel.SetPowersEnabled(false);

            gameModeModel.SetSellingEnabled(false);
            gameModeModel.SetSellMultiplier(0);

            if (ClassicRoundsMod.NPPMKFRILLS)
            {
                gameModeModel.SetBloonHealth(1.5f, BloonTag.Ceramic);
                gameModeModel.SetBloonHealth(2f, BloonTag.Moabs);
                gameModeModel.UseRoundSet<Btd5ImpopRounds>();
            }
            else
            {
                gameModeModel.UseRoundSet<Btd5StandardRounds>();
            }
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    public class BTD5Mastery : ModGameMode
    {
        protected override int Order => 4;
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD5 Mastery";

        public override string Icon => VanillaSprites.GoldenBloonIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.SetStartingHealth(100);
            gameModeModel.SetMaxHealth(100);
            gameModeModel.SetStartingRound(1);
            gameModeModel.SetEndingRound(85);
            gameModeModel.UseRoundSet<Btd5MasteryRounds>();
            gameModeModel.SetAllCashMultiplier(0.5f);
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }

    public class BTD5Deflation : ModGameMode
    {
        protected override int Order => 5;
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD5 Deflation";

        public override string Icon => "BTD5Deflation";

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            //BuildLevelHints(levelHints)
            gameModeModel.SetMkEnabled(false);
            gameModeModel.SetContinuesEnabled(false);
            gameModeModel.SetStartingCash(50000);
            gameModeModel.SetStartingHealth(150);
            gameModeModel.SetMaxHealth(150);
            gameModeModel.SetStartingRound(30);
            gameModeModel.SetEndingRound(90);
            gameModeModel.AddMutator(new DeflationModel("DeflationModel_"));
            gameModeModel.SetAllCashMultiplier(0.0f);
            gameModeModel.UseRoundSet<Btd5StandardRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi"));
            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    /*
    [Obsolete]
    public class BTD5Apopalypse : ModGameMode
    {
        protected override int Order => 5;
        public override string Difficulty => DifficultyType.Medium;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "BTD5 Apopalypse";

        public override string Icon => "BTD5Apopalypse";

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
            gameModeModel.UseRoundSet<Btd5ApopRounds>();
            // New to BTD 4/5/6
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Alchemist"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "BeastHandler"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Mermonkey"));
            gameModeModel.AddMutator(new LockTowerModModel("LockTowerModModel_", "Luigi-Luigi")); 

            foreach (var i in gameModeModel.GetDescendants<LockTowerModModel>().ToList())
            {
                if (i is not null && i.name == "LockTowerModModel_")
                {
                    i.name += i.towerToLock;
                }
            }
        }
    }
    */
}