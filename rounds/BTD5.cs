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
using Math = System.Math;
using ClassicRounds.Util;

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
                { IsRegen = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.AddBloonGroup() was given a Regrow Bloon. IsRegen should be used to add Regrow Bloons."); }
            if (IsRegen) { bloon += "Regrow"; }
            if (Bloon.EndsWith("Fortified") || Bloon.EndsWith("FortifiedCamo") || IsFortified is null) 
                { IsFortified = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.AddBloonGroup() was given a Fortified Bloon. IsFortified should be used to add Fortified Bloons."); }
            if ((bool)IsFortified) { bloon += "Fortified"; }
            if (Bloon.EndsWith("Camo")) { IsCamo = false; ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.AddBloonGroup() was given a Camo Bloon. IsCamo should be used to add Camo Bloons."); }
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
        public override int DefinedRounds => 85 + ClassicRoundsMod.GeneratedBTD5FreeplayRounds;
        public override string DisplayName => "BTD5 Standard";
        public override string Icon => VanillaSprites.ModeSelectEasyBtn;

        public Btd5rndm rndm = new();

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


        public float getInterval(int param1)
        {
            if (param1 > 10)
            {
                return (float)Math.Min(16 + (param1 - 10) * 0.2, 20);
            }
            return param1 + 6;
        }

        public int getRandomType(int param1)
      {
         int _loc2_ = (int)(this.rndm.random() * (param1 + 100));

            if (_loc2_ > 95) { return 12; }
            if (_loc2_ > 60) { return 11; }
            if (_loc2_ > 20) { return 10; }
            return 9;
        }
        public int getTotalWaves(int param1)
        {
            if (param1 > 10)
            {
                return Math.Min((int)(16 + (param1 - 10) * 0.2), 20);
            }
            return param1 + 6;
        }
        /// <summary>
        /// Generates a BloonGroup using variables like BTD5 Flash and adds it to the given RoundModel.
        /// </summary>
        public void Spawner(int param1 = 50, float param2 = 0, float param3 = 10, int? param4 = null, bool param5 = false, bool param6 = false, RoundModel? roundModel = null)
        {
            string[] bloonArray = ["Red", "Blue", "Green", "Yellow", "Pink", "Black", "White", "Lead", "Zebra", "Rainbow", "Ceramic", "Moab", "Bfb", "Zomg", "Bad", "Bloonarius5"];
            if (param4 is null)
            { ABSTL(param1, param2, param1 * param3, param5, param6, "Olive", roundModel); return; }
            ABSTL(param1, param2, param1 * param3, param5, param6, bloonArray[(int)param4], roundModel); return;
        }
        public void Spawner(int param1 = 50, int? param4 = null, float param2 = 0, float param3 = 10, bool param5 = false, bool param6 = false, RoundModel? roundModel = null)
        {
            string[] bloonArray = ["Red", "Blue", "Green", "Yellow", "Pink", "Black", "White", "Lead", "Zebra", "Rainbow", "Ceramic", "Moab", "Bfb", "Zomg", "Bad", "Bloonarius5"];
            if (param4 is null)
            { ABSTL(param1, param2, param1 * param3, param5, param6, "Olive", roundModel); return; }
            ABSTL(param1, param2, param1 * param3, param5, param6, bloonArray[(int)(param4 - 1)], roundModel); return;
        }
        /// <summary>
        /// Generates a BloonGroup using variables like BTD5 Moblie and adds it to the given RoundModel.
        /// Defalts to 50 Olive bloons.
        /// </summary>
        public void ABSTL(int Count = 50, float StartTime = 0, float Duration = 20, bool IsRegen = false, bool IsCamo = false, string Bloon = "Olive", RoundModel? roundModel = null)
        {
            if (roundModel is null) { ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was not given a roundModel, or was given a null roundModel."); return; }
            if (Bloon == "Olive") { ModHelper.Log<ClassicRoundsMod>("Btd5StandardRounds.ABSTL() was not given a Bloon, or was given exactly \"Olive\"."); }
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
                //string[] bloonArray = ["Red", "Blue", "Green", "Yellow", "Pink", "Black", "White", "Lead", "Zebra", "Rainbow", "Ceramic", "Moab", "Bfb", "Zomg", "Bad"];
                //string[] exprtBloonArray = ["Red", "BlueRegrow", "GreenRegrow", "YellowRegrow", "PinkRegrow", "BlackRegrow", "WhiteRegrow", "LeadRegrow", "ZebraRegrow", "RainbowRegrow", "CeramicRegrowFortified", "Ddt", "BfbFortified", "ZomgFortified", "BadFortified"];
                    int _loc10_ = 0;
                    float _loc11_ = -1; //delay
                    int _loc12_ = -1; //
                    RoundModel _loc2_ = roundModel;
                    int _loc4_ = round - 85;
                    int _loc5_;
                    int _loc6_ = _loc5_ = this.getTotalWaves(_loc4_);
                    int _loc7_ = _loc5_ + 6;
                    float _loc8_ = 0;
                    int _loc9_ = 0;
                    while (_loc9_ < _loc5_)
                    {
                        _loc10_ = (int)(rndm.random() * (_loc7_ - _loc6_) + _loc6_);
                        _loc11_ = this.getInterval(_loc4_);
                        if ((_loc12_ = this.getRandomType(_loc4_)) == 11) //Ceramic
                        {
                            _loc11_ /= 3;
                            _loc10_ *= 3;
                        }
                        else if (_loc12_ == 14) //Zomg
                        {
                            _loc11_ *= 4;
                            _loc10_ = (int)Math.Floor((decimal)(_loc10_ / 3));
                        }
                    //_loc2_.addSpawners(_loc10_, _loc12_, _loc11_, _loc8_, false, false);
                    Spawner(_loc10_, _loc8_, _loc11_, _loc12_, roundModel: roundModel);
                    _loc8_ += _loc10_ * _loc11_; //ABSTL.Duration i think.
                    _loc9_++;
                    }
                    //return _loc2_;
                    if (round % ClassicRoundsMod.LogOnNthGeneratedBTD5Round == 0 && ClassicRoundsMod.LogOnNthGeneratedBTD5Round > 0) { ModHelper.Log<ClassicRoundsMod>("Generated round" + round+ "for"+ this.DisplayName);}
                    return;
                }
            }
        }

    }
    public class Btd5ImpopRounds : Btd5StandardRounds
    {
        public override string Icon => VanillaSprites.ImpoppableIcon;
        public override string DisplayName => "BTD5 Impoppable";
        public override bool AddToOverrideMenu => true;
        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            switch (round)
            {
                case 85:
                    //clear
                    roundModel.RemoveBloonGroup("Zomg");
                    ABSTL(5, 0, 10, false, false, "Zomg", roundModel);
                    break;
            }
        }

        public class Btd5ApopRounds : ModRoundSet
    {
            public override string Icon => VanillaSprites.ApopalypseBtn;
            public override string BaseRoundSet => RoundSetType.Empty;
            public override int DefinedRounds => ClassicRoundsMod.GeneratedBTD5ApopalypseRounds;
            public override bool Rounds1Index => true;
            public override string DisplayName => "BTD5 Apopalypse";
            public override bool AddToOverrideMenu => true;

            public Btd5rndm rndm = new();

            public float calculateSpawnInterval(int param1)
            { 
                if (param1 > 40)
                {
                    return (float)(1 - 0.4 - 0.0015 * param1);
                }
                return (float)(1 - 0.01 * param1);
            }


        /// <summary>
        /// Generates a BloonGroup using variables like BTD5 Flash and adds it to the given RoundModel.
        /// </summary>
        public void Spawner(int param1 = 50, float param2 = 0, float param3 = 10, int? param4 = null, bool param5 = false, bool param6 = false, RoundModel? roundModel = null)
        {
            string[] bloonArray = ["Red", "Blue", "Green", "Yellow", "Pink", "Black", "White", "Lead", "Zebra", "Rainbow", "Ceramic", "Moab", "Bfb", "Zomg", "Bad", "Bloonarius5"];
            if (param4 is null)
            { ABSTL(param1, param2, param1 * param3, param5, param6, "Olive", roundModel); return; }
            ABSTL(param1, param2, param1 * param3, param5, param6, bloonArray[(int)param4], roundModel); return;
        }
        public void Spawner(int param1 = 50, int? param4 = null, float param2 = 0, float param3 = 10, bool param5 = false, bool param6 = false, RoundModel? roundModel = null)
        {
            string[] bloonArray = ["Red", "Blue", "Green", "Yellow", "Pink", "Black", "White", "Lead", "Zebra", "Rainbow", "Ceramic", "Moab", "Bfb", "Zomg", "Bad", "Bloonarius5"];
            if (param4 is null)
            { ABSTL(param1, param2, param1 * param3, param5, param6, "Olive", roundModel); return; }
            ABSTL(param1, param2, param1 * param3, param5, param6, bloonArray[(int)(param4 - 1)], roundModel); return;
        }
        /// <summary>
        /// Generates a BloonGroup using variables like BTD5 Moblie and adds it to the given RoundModel.
        /// Defalts to 50 Olive bloons.
        /// </summary>
        public void ABSTL(int Count = 50, float StartTime = 0, float Duration = 20, bool IsRegen = false, bool IsCamo = false, string Bloon = "Olive", RoundModel? roundModel = null)
        {
            if (roundModel is null) { ModHelper.Log<ClassicRoundsMod>("Btd5ApopRounds.ABSTL() was not given a roundModel, or was given a null roundModel."); return; }
            if (Bloon == "Olive") { ModHelper.Log<ClassicRoundsMod>("Btd5ApopRounds.ABSTL() was not given a Bloon, or was given exactly \"Olive\"."); }
            string bloon = Bloon;
            //convert all caps names to tile case (MOAB ==> Moab)
            if (Bloon.StartsWith("MOAB")) { bloon = "Moab"; }
            if (Bloon.StartsWith("BFB")) { bloon = "Bfb"; }
            if (Bloon.StartsWith("ZOMG")) { bloon = "Zomg"; }
            if (Bloon.StartsWith("DDT")) { bloon = "Ddt"; }
            if (Bloon.StartsWith("BAD")) { bloon = "Bad"; }
            //vailtdate properties
            if (Bloon.EndsWith("Fortified") || Bloon.EndsWith("FortifiedCamo")) { ModHelper.Log<ClassicRoundsMod>("Btd5ApopRounds.ABSTL() was given a Fortified Bloon."); }
            if (Bloon.EndsWith("Regrow") || Bloon.EndsWith("RegrowCamo")) { IsRegen = false; ModHelper.Log<ClassicRoundsMod>("Btd5ApopRounds.ABSTL() was given a Regrow Bloon. IsRegen should be used to add Regrow Bloons."); }
            if (IsRegen) { bloon += "Regrow"; }
            if (Bloon.EndsWith("Camo")) { IsCamo = false; ModHelper.Log<ClassicRoundsMod>("Btd5ApopRounds.ABSTL() was given a Camo Bloon. IsCamo should be used to add Camo Bloons."); }
            if (IsCamo) { bloon += "Camo"; }
            roundModel.AddBloonGroup(bloon, Count, StartTime, StartTime + Duration);
            return;
        }

        public override void ModifyRoundModels(RoundModel roundModel, int round)
            {
                    //private function createApopalypseWave(param1:int) : Wave
                    {
                    var rand = new System.Random();
                    int _loc17_ = -1;
                    bool _loc18_ = false;
                    bool _loc19_ = false;
                    float _loc3_ = (float)Math.Pow(Math.Min(round / 80, 1), 0.63);
                    float _loc4 = Math.Min(round / 80, 1);
                    int _loc7_ = 24 + Math.Min(round / 80, 1) * (90 - 24);
                    int _loc9_ = 0 - 8;
                    int _loc10_ = 10;
                    float _loc11_ = 0;
                    //var _loc12_:Wave = new Wave();
                    var _loc13_ = this.calculateSpawnInterval(round);
                    while (_loc11_ < _loc7_)
                    {
                        _loc17_ = (int)Math.Min(Math.Max(Math.Floor(Math.Pow(rndm.random(), 1.2) * 8 + _loc9_ + _loc3_ * (_loc10_ - _loc9_)), 0), 12);
                        _loc18_ = rndm.random() + _loc3_ > 1.6 && _loc17_ < 11;
                        if (_loc19_ = rndm.random() + _loc3_ > 1.4 && _loc17_ < 11)
                        {
                            _loc17_ = Math.Max(2, _loc17_ - 3);
                        }
                        _loc17_ = Math.Min(_loc17_, 10);
                        Spawner(1, _loc11_, _loc13_, _loc17_, _loc18_, _loc19_, roundModel);
                        _loc11_ += _loc13_;
                        if (ClassicRoundsMod.VerboseLogsForGeneratedBTD5Rounds) { ModHelper.Log<ClassicRoundsMod>($"round: {round}, _loc11_: {_loc11_}, _loc7_: {_loc7_}, _loc13_: {_loc13_}"); }

                    }
                    if (round >= 40)
                    {
                        _loc13_ = _loc7_ / (3 + 40 * Math.Min((round - 40) / 10, 1));
                        if (_loc13_ * _loc7_ == 0) { ModHelper.Log<ClassicRoundsMod>("Denominator became zero, skipping this iteration"); return; } // Avoid division by zero 
                        ModHelper.Log<ClassicRoundsMod>($"round: {round}, _loc13_: {_loc13_}, Denominator: {_loc13_ * _loc7_}");
                        _loc11_ = 0;
                        while (_loc11_ < _loc7_)
                        {
                            _loc17_ = 10;
                            Spawner(1, _loc11_, _loc13_, _loc17_, false, false, roundModel);
                            _loc11_ += _loc13_;
                            if (ClassicRoundsMod.VerboseLogsForGeneratedBTD5Rounds){ ModHelper.Log<ClassicRoundsMod>($"round: {round}, _loc11_: {_loc11_}, _loc7_: {_loc7_}, _loc13_: {_loc13_}"); }
                        }
                    }
                    if (round > 50)
                    {
                        _loc13_ = _loc7_ / (3 + 30 * Math.Min((round - 50) / 10, 1)); var denominator = 3 + 30 * Math.Min((float)(round - 50) / 10, 1);
                        if (_loc13_ * _loc7_ == 0) { ModHelper.Log<ClassicRoundsMod>("Denominator became zero, skipping this iteration"); return; } // Avoid division by zero 
                        _loc11_ = 0;
                        ModHelper.Log<ClassicRoundsMod>($"round: {round}, _loc11_: {_loc11_}, _loc7_: {_loc7_}, _loc13_: {_loc13_}");
                        while (_loc11_ < _loc7_)
                        {
                            _loc17_ = 11;
                            Spawner(1, _loc11_, _loc13_, _loc17_, false, false, roundModel);
                            _loc11_ += _loc13_;
                            if (ClassicRoundsMod.VerboseLogsForGeneratedBTD5Rounds){ModHelper.Log<ClassicRoundsMod>($"round: {round}, _loc11_: {_loc11_}, _loc7_: {_loc7_}, _loc13_: {_loc13_}");}
                        }
                    }
                    if (round > 60)
                    {
                        _loc13_ = _loc7_ / (3 + 20 * Math.Min((round - 60) / 10, 1));
                        if (_loc13_ * _loc7_ == 0) { ModHelper.Log<ClassicRoundsMod>("Denominator became zero, skipping this iteration"); return; } // Avoid division by zero 
                        _loc11_ = 0;
                        while (_loc11_ < _loc7_)
                        {
                            _loc17_ = 12;
                            Spawner(1, _loc11_, _loc13_, _loc17_, false, false, roundModel);
                            _loc11_ += _loc13_;
                            if (ClassicRoundsMod.VerboseLogsForGeneratedBTD5Rounds) { ModHelper.Log<ClassicRoundsMod>($"round: {round}, _loc11_: {_loc11_}, _loc7_: {_loc7_}, _loc13_: {_loc13_}"); }
                        }
                     }
                    if (round % ClassicRoundsMod.LogOnNthGeneratedBTD5Round == 0 && ClassicRoundsMod.LogOnNthGeneratedBTD5Round > 0) { ModHelper.Log<ClassicRoundsMod>("Generated round" + round + "for" + this.DisplayName); }
                    return;
                }
            }
        }
}



