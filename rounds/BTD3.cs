using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper;
using ClassicRounds.Bloons;
using ClassicRounds;
using Il2CppAssets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Extensions;
using System;

namespace ClassicRounds.Rounds
{
    public class Btd3StandardRounds : ModRoundSet
    {
        protected override int Order => 3;
        public override bool AddToOverrideMenu => false;
        public override bool Rounds1Index => false;
        public override string BaseRoundSet => RoundSetType.Empty;
        public override int DefinedRounds => 50 + ClassicRoundsMod.GeneratedBTD3FreeplayRounds;
        public override string DisplayName => "BTD3 Standard";
        public override string Icon => "Classic";
        public float delay = 0;
        //private int _loc1_ = round;
        private int _loc2_; //these are varables for freeplay round generation
        private int _loc3_;
        private int _loc4_;
        private int _loc5_;

        /// <summary>
        /// A string that affects freeplay generation.
        /// </summary>
        public virtual string diff => "medium";

        public string[] levelHints = new string[50];

        static float BloonInterval(int curLevel)
        {
            float bloonInterval = 20 - curLevel;
            if (bloonInterval < 7)
            {
                bloonInterval = (float)Math.Ceiling((double)(7 - curLevel / 20));
            };
            return bloonInterval * (60/35);
        }
        /// <summary>
        /// Generates a BloonGroup using variables like BTD3 and adds it to a RoundModel, then returns a new delay for the next group.   
        /// 
        /// </summary>
        /// <param name="bloonCount">How many Bloons will be emitted?</param>
        /// <param name="curLevel">Which round is this? Affects how dense the bloons are.</param> 
        /// <param name="bloonRank">The bloonRanks are Red, Blue, Green, Yellow, Black, White, Lead, Rainbow, Ceramic, MOAB.</param> 
        /// <param name="roundModel">The RoundModel to add a BloonGroup to.</param>
        /// <param name="delay">Corresponds to the BloonGroup's startTime.</param>
        /// <returns></returns>
        static float ABSTL(int bloonCount = 50, int curLevel = 33, int bloonRank = 11, RoundModel? roundModel = null, float delay = 0)
        {
            if (roundModel is null) { ModHelper.Log<ClassicRoundsMod>("Btd3StandardRounds.ABSTL() was not given a roundModel, or was given a null roundModel."); return delay + 20; }
            string[] ranks = new string[10];
            if (ClassicRoundsMod.UseClassicBloonsinClassicModes)
            {
                ranks = [BloonID<ClassicRed>(), BloonID<ClassicBlue>(), BloonID<ClassicGreen>(), BloonID<ClassicYellow>(), BloonID<ClassicBlack>(), BloonID<ClassicWhite>(), BloonID<ClassicLead>(), BloonID<ClassicRainbow>(), BloonID<ClassicCeramic>(), BloonID<ClassicMoab>()];
            }
            else
            {
                ranks = ["Red", "Blue", "Green", "Yellow", "Black", "White", "Lead", "Rainbow", "Ceramic", BloonType.Moab, BloonType.Bfb, BloonType.Zomg, BloonType.Bad, BloonType.Bloonarius5];
            }
            //string[] expertRanks = ["Blue", "Green", "Yellow", "Pink", "Lead", "Rainbow", "Lead", "RainbowRegrow", "CeramicFortified", "MoabFortified"]; //60-79
            //string[] freeplayRanks = ["Red", "Blue", "Green", "Yellow", BloonID<ClassicBlack>(), BloonID<ClassicWhite>(), BloonID<ClassicLeadF>(), BloonID<ClassicRainbow>(), BloonID<ClassicCeramicF>(), BloonID<ClassicMoabF>()]; //80+
            //string[] altFreeplayRanks = ["RedRegrow", "BlueRegrow", "GreenRegrow", "YellowRegrow", "BlackRegrow", "WhiteRegrow", "LeadRegrow", "RainbowRegrow", "CeramicRegrow", "Ddt"]; //90, 93, 95, 97, 99, 100, 101, 103, 105 etc.
            //if (curLevel >= 90 && curLevel % 10 == 0 || curLevel >= 93 && curLevel % 2 == 1)
            //{
            //roundModel.AddBloonGroup(altFreeplayRanks[bloonRank - 1], bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
            //}
            //else
            //{
            //if (curLevel >= 60)
            //{
            //roundModel.AddBloonGroup(expertRanks[bloonRank - 1], bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
            //}
            //else
            //{
            //if (curLevel >= 80)
            //{
            //roundModel.AddBloonGroup(freeplayRanks[bloonRank - 1], bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
            //}
            //else
            //{
            roundModel.AddBloonGroup(ranks[bloonRank - 1], bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);
            //}
            //}
            //}

            delay += BloonInterval(curLevel) * bloonCount;
            return delay;
        }

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            float delay = 0;
            switch (round)
            {
                case 0:
                    delay = 0;
                    ABSTL(14, 1, 1, roundModel, delay);
                    break;
                case 1:
                    delay = 0;
                    ABSTL(30, 2, 1, roundModel, delay);
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
                    ABSTL(30, 21, 3, roundModel, delay);
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
                        ModHelper.Warning<ClassicRoundsMod>("Round " + (round + 1) + ": Missing round data, using a placeholder round.");
                        //ABSTL(6, round, 9, roundModel, delay);
                        roundModel.AddBloonGroup(BloonID<OliveCamo>(), 1, delay, delay + BloonInterval(round));
                        delay += BloonInterval(round);
                        delay = ABSTL(40, round, 1, roundModel, delay);
                        roundModel.AddBloonGroup("4", 4, delay, delay + BloonInterval(round));
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
                            _loc5_ = rand.Next(round);
                            if (diff == "medium")
                            {
                                _loc5_ += 3;
                            }
                            if (diff == "hard")
                            {
                                _loc5_ += 7;
                            }
                            if (diff == "impop")
                            {
                                _loc5_ += 14;
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
                                    delay = ABSTL(10, round + 1, _loc4_, roundModel, delay);
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