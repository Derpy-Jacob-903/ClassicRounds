using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper;
using ClassicRounds.Bloons;
using ClassicRounds;
using Il2CppAssets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Extensions;
using System;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Unity.Achievements.List;
using System.IO;
using System.Text.Json;
using ClassicRounds.Rounds;
using Il2CppSystem;
using NullReferenceException = System.NullReferenceException;
using System.Reflection;

namespace ClassicRounds.Rounds
{
    /// <summary>
    /// RawBtd5RoundSet
    /// </summary>
    public class RawBtd5RoundSet
    {
        /// <summary>
        /// An array of Btd5RoundModels
        /// </summary>
        public Btd5RoundModel[] Rounds { get; set; } = [];
    }
    /// <summary>
    /// a BloonGroup that uses Booleans for  like BTD5 and adds it to a RoundModel, then returns a new delay for the next group.
    /// Defaults to 50 Olive bloons 
    /// </summary>
    public class Btd5RoundModel
    {
        public string Hint { get; set; } = "Round Null";
        public Btd5BloonGroupModel[] Waves { get; set; } = [];
    }
    /// <summary>
    /// a BloonGroup that uses Booleans for Properties like BTD5.
    /// Defaults to 50 Olive bloons 
    /// </summary>
    public class Btd5BloonGroupModel
    {
        /// <summary>
        /// The id of the Bloon
        /// Defaults to "ClassicRounds-Olive"
        /// </summary>
        public string Bloon { get; set; } = "ClassicRounds-Olive";
        /// <summary>
        /// 
        /// Skipped if the Bloon is already a Regrow Bloon
        /// </summary>
        public bool IsRegen { get; set; } = false;
        /// <summary>
        /// 
        /// Skipped if the Bloon is already a Regrow Bloon
        /// </summary>
        public bool IsCamo { get; set; } = false;
        /// <summary>
        /// startTime
        /// </summary>
        public bool? IsFortified { get; set; } = null;
        /// <summary>
        /// 
        /// Skipped if the Bloon is already a Fortified Bloon
        /// </summary>
        public float StartTime { get; set; } = 0;
        /// <summary>
        /// When this group starts emitting, in seconds (frames / 60)
        /// </summary>
        public float Duration { get; set; } = 20;
        /// <summary>
        /// The id of the Bloon
        /// </summary>
        public int Count { get; set; } = 50;
        public void AddBloonGroup(RoundModel roundModel)
        {
            if (roundModel is null)
            {
                throw new System.ArgumentException($"'{nameof(roundModel)}' cannot be null.", nameof(roundModel));
            }
            if (string.IsNullOrWhiteSpace(Bloon))
            {
                throw new System.ArgumentException($"'{nameof(Bloon)}' cannot be null or whitespace.", nameof(Bloon));
            }
            if (string.IsNullOrWhiteSpace(Bloon))
            {
                ModHelper.Log<ClassicRoundsMod>("Btd5BloonGroupModel is using a Olive Bloon.");
            }
            string bloon = Bloon;
            //convert all caps names to tile case (MOAB ==> Moab)
            if (Bloon.StartsWith("MOAB")) { bloon = "Moab"; }
            if (Bloon.StartsWith("BFB")) { bloon = "Bfb"; }
            if (Bloon.StartsWith("ZOMG")) { bloon = "Zomg"; }
            if (Bloon.StartsWith("DDT")) { bloon = "Ddt"; }
            if (Bloon.StartsWith("BAD")) { bloon = "Bad"; }
            //vailtdate properties
            if (Bloon.EndsWith("Regrow") || Bloon.EndsWith("RegrowCamo") || Bloon.EndsWith("RegrowFortified") || Bloon.EndsWith("RegrowFortifiedCamo")) 
                { IsRegen = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was given a Regrow Bloon. IsRegen should be used to add Regrow Bloons."); }
            if (IsRegen) { bloon += "Regrow"; }
            if (Bloon.EndsWith("Fortified") || Bloon.EndsWith("FortifiedCamo") || IsFortified is null) 
                { IsFortified = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was given a Fortified Bloon. IsFortified should be used to add Fortified Bloons."); }
            if ((bool)IsFortified) { bloon += "Fortified"; }
            if (Bloon.EndsWith("Camo")) { IsCamo = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was given a Camo Bloon. IsCamo should be used to add Camo Bloons."); }
            if (IsCamo) { bloon += "Camo"; }
            roundModel.AddBloonGroup(bloon, Count, StartTime * 60, (StartTime + Duration) * 60);
        }
    }
#pragma warning disable IDE1006 // Naming Styles
    public class Btd5StandardRounds : ModRoundSet
    {
        protected override int Order => 3;
        public override bool Rounds1Index => true;
        public override string BaseRoundSet => RoundSetType.Empty;
        public override int DefinedRounds => 85; // + ClassicRoundsMod.GeneratedBTD5FreeplayRounds;
        public override string DisplayName => "BTD5 Standard";
        public override string Icon => VanillaSprites.ModeSelectEasyBtn;
        public float delay = 0;

        public RawBtd5RoundSet? rawBtd5RoundSet = null;
        //public string[] levelHints = new string[50];
        public override bool AddToOverrideMenu => true;
        //public virtual string diff => "medium";
        public override void Register()
        {
            base.Register();
            //var n = new ReadAndParseJsonFileWithSystemTextJson("Mods/DefaultBTD5rounds.json"); //todo: use emebedded json instend.
            //rawBtd5RoundSet = n.UseFileReadAllTextWithSystemTextJson();
        }
        public class ReadAndParseJsonFileWithSystemTextJson(string json)
        {
            //private readonly string _sampleJsonFilePath = sampleJsonFilePath;

            public RawBtd5RoundSet? UseFileReadAllTextWithSystemTextJson()
            {
                //var json = File.ReadAllText(_sampleJsonFilePath);
                RawBtd5RoundSet? raw = JsonSerializer.Deserialize<RawBtd5RoundSet?>(json);
                return raw;
            }
        }
        /// <summary>
        /// Generates a BloonGroup using variables like BTD5 and adds it to a RoundModel.
        /// Defalts to 50 Camo Olive bloons 
        /// </summary>
        /// <param name="Count">How many bloons to add?</param>
        /// <param name="StartTime">When this group starts emitting, in frames (seconds * 60)</param>
        /// <param name="Duration">When this group stops emitting, in frames (seconds * 60)</param>
        /// <param name="IsRegen">Is this Bloon a Regrow Bloon?</param>
        /// <param name="IsCamo">Is this Bloon a Camo Bloon?param>
        /// <param name="Bloon">The id of the Bloon?</param>
        /// <param name="roundModel">The RoundModel to add the BloonGroup to.</param>
        [System.Obsolete("BTD5 round data is loaded in a different way. This is unused.")]
        public void ABSTL(int Count = 50, int StartTime = 0, float Duration = 20, bool IsRegen = false, bool IsCamo = false, string Bloon = "OliveCamo", RoundModel? roundModel = null)
        {
            if (roundModel is null) { ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was not given a roundModel, or was given a null roundModel."); return; }
            if (Bloon == "OliveCamo") { ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was not given a Bloon, or was given exactly \"OliveCamo\"."); }
            string bloon = Bloon;
            //convert all caps names to tile case (MOAB ==> Moab)
            if (Bloon.StartsWith("MOAB")) { bloon = "Moab"; }
            if (Bloon.StartsWith("BFB")) { bloon = "Bfb"; }
            if (Bloon.StartsWith("ZOMG")) { bloon = "Zomg"; }
            if (Bloon.StartsWith("DDT")) { bloon = "Ddt"; }
            if (Bloon.StartsWith("BAD")) { bloon = "Bad"; }
            //vailtdate properties
            if (Bloon.EndsWith("Fortified") || Bloon.EndsWith("FortifiedCamo")) { ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was given a Fortified Bloon."); }
            if (Bloon.EndsWith("Regrow") || Bloon.EndsWith("RegrowCamo")) { IsRegen = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was given a Regrow Bloon. IsRegen should be used to add Regrow Bloons."); }
            if (IsRegen) { bloon += "Regrow"; }
            if (Bloon.EndsWith("Camo")) { IsCamo = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was given a Camo Bloon. IsCamo should be used to add Camo Bloons."); }
            if (IsCamo) { bloon += "Camo"; }
            roundModel.AddBloonGroup(bloon, Count, StartTime, StartTime + Duration);
            return;
        }


        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            var assembly = Assembly.GetExecutingAssembly(); 
            var resourceName = "ClassicRounds.rounds.DefaultBTD5rounds.json"; 
            using (Stream? stream = assembly.GetManifestResourceStream(resourceName)) 
            { if (stream == null) { throw new FileNotFoundException("Resource not found: " + resourceName); }
                using StreamReader reader = new(stream);
                string json = reader.ReadToEnd(); 
                var n = new ReadAndParseJsonFileWithSystemTextJson(json); 
                rawBtd5RoundSet = n.UseFileReadAllTextWithSystemTextJson();
            }

            if (rawBtd5RoundSet?.Rounds is null)
            {
                throw new NullReferenceException("rawBtd5RoundSet or rawBtd5RoundSet.Rounds is null");
            }

            if (round < 85)
            {
                var waves = (rawBtd5RoundSet.Rounds[round]?.Waves) ?? throw new NullReferenceException("rawBtd5RoundSet.Rounds[round] or rawBtd5RoundSet.Rounds[round].Waves is null");
                foreach (var wave in waves)
                {
                    wave.AddBloonGroup(roundModel);
                }
            }
            else // Freeplay
            {
                var rand = new System.Random();
                // Logic for freeplay rounds
            }
        }

    }
    public class Btd5ImpopRounds : Btd5StandardRounds
    {
        public override string Icon => VanillaSprites.ImpoppableIcon;
        public override bool Rounds1Index => true;
        public override string DisplayName => "BTD5 Impoppable";
        public override bool AddToOverrideMenu => true;
        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            switch (round)
            {
                case 85:
                    //clear
                    //roundModel.
                    //ABSTL(5, 0, 10, false, false, "Zomg", roundModel);
                    break;
            }
        }
    }
}