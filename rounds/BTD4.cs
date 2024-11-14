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
#pragma warning disable IDE1006 // Naming Styles
    public class Btd4StandardRounds : ModRoundSet
    {
        protected override int Order => 3;
        public override bool Rounds1Index => true;
        public override string BaseRoundSet => RoundSetType.Empty;
        public override int DefinedRounds => 75 + ClassicRoundsMod.GeneratedBTD4FreeplayRounds;
        public override string DisplayName => "BTD4 Standard";
        public override string Icon => "BTD4Medium";
        public float delay = 0;
        public string[] levelHints = new string[50];
        public override bool AddToOverrideMenu => false;
        public virtual string diff => "medium";

        static float BloonInterval(int curLevel)
        {
            float bloonInterval = (float)(20 - Math.Floor((decimal)(curLevel / 3)));
            if (bloonInterval < 7)
            {
                bloonInterval = (float)Math.Ceiling((decimal)(7 - curLevel / 20));
            }
            //bloonInterval = 20 - curLevel;
            //if (bloonInterval < 7)
            //{
            //bloonInterval = (float)Math.Ceiling((double)(7 - curLevel / 20));
            //};
            return bloonInterval * 2.2f;
        }
        /// <summary>
        /// Generates a BloonGroup using variables like BTD3 and adds it to a RoundModel, then returns a new delay for the next group.
        /// </summary>
        /// <param name="bloonCount">How many Bloons will be emitted?</param>
        /// <param name="bloonRank">The bloonRanks are Red, Blue, Green, Yellow, Black, White, Zebra, Lead, Rainbow, Camo (Olive), Ceramic, MOAB, BFB.</param> 
        /// <param name="curLevel">Which round is this? Affects how dense the bloons are.</param> 
        /// <param name="roundModel">The RoundModel to add the BloonGroup to.</param>
        /// <param name="delay">When this group starts emitting, in frames (seconds * 60)</param>
        /// <returns></returns>
        public float ABSTL(int bloonCount = 50, int bloonRank = 11, int curLevel = 33, RoundModel? roundModel = null, float delay = 0)
        {
            if (roundModel is null) { ModHelper.Log<ClassicRoundsMod>("Btd3StandardRounds.ABSTL() was not given a roundModel, or was given a null roundModel."); return delay + 20; }
            string[] ranks = ["Red", "Blue", "Green", "Yellow", "Pink", "Black", "White", "Zebra", "Lead", "Rainbow", BloonID<OliveCamo>(), "Ceramic", "Moab", "Bfb", "Zomg", "Bad"];
            roundModel.AddBloonGroup(ranks[bloonRank - 1], bloonCount, delay, delay + BloonInterval(curLevel) * bloonCount);

            delay += BloonInterval(curLevel) * bloonCount;
            return delay;
        }


        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            var _loc1_ = round;
            var _loc2_ = round;
            var _loc3_ = 0;
            var _loc4_ = 0;
            var _loc5_ = 0;
            var _loc6_ = 0;
            delay = 0;
            switch (round)
            {
                case 1:
                    ABSTL(14, 1, _loc1_, roundModel, delay);
                    break;
                case 2:
                    delay = ABSTL(30, 1, _loc1_, roundModel, delay);
                    break;
                case 3:
                    delay = ABSTL(10, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 1, _loc1_, roundModel, delay);
                    break;
                case 4:
                    delay = ABSTL(20, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 1, _loc1_, roundModel, delay);
                    break;
                case 5:
                    delay = ABSTL(10, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 2, _loc1_, roundModel, delay);
                    break;
                case 6:
                    delay = ABSTL(4, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 2, _loc1_, roundModel, delay);
                    break;
                case 7:
                    delay = ABSTL(10, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 2, _loc1_, roundModel, delay);
                    break;
                case 8:
                    delay = ABSTL(20, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(2, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 3, _loc1_, roundModel, delay);
                    break;
                case 9:
                    delay = ABSTL(10, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(12, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 3, _loc1_, roundModel, delay);
                    break;
                case 10:
                    delay = ABSTL(100, 2, _loc1_, roundModel, delay);
                    break;
                case 11:
                    delay = ABSTL(2, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(12, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 1, _loc1_, roundModel, delay);
                    break;
                case 12:
                    delay = ABSTL(10, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 4, _loc1_, roundModel, delay);
                    break;
                case 13:
                    delay = ABSTL(20, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(25, 3, _loc1_, roundModel, delay);
                    break;
                case 14:
                    delay = ABSTL(5, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 2, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 4, _loc1_, roundModel, delay);
                    break;
                case 15:
                    delay = ABSTL(20, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(3, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 4, _loc1_, roundModel, delay);
                    break;
                case 16:
                    delay = ABSTL(20, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(13, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 5, _loc1_, roundModel, delay);
                    break;
                case 17:
                    delay = ABSTL(15, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(8, 4, _loc1_, roundModel, delay);
                    break;
                case 18:
                    delay = ABSTL(80, 3, _loc1_, roundModel, delay);
                    break;
                case 19:
                    delay = ABSTL(5, 3, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(11, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(3, 5, _loc1_, roundModel, delay);
                    break;
                case 20:
                    delay = ABSTL(8, 6, _loc1_, roundModel, delay);
                    break;
                case 21:
                    delay = ABSTL(10, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(6, 5, _loc1_, roundModel, delay);
                    break;
                case 22:
                    delay = ABSTL(9, 7, _loc1_, roundModel, delay);
                    break;
                case 23:
                    delay = ABSTL(6, 6, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 7, _loc1_, roundModel, delay);
                    break;
                case 24:
                    delay = ABSTL(1, 11, _loc1_, roundModel, delay);
                    break;
                case 25:
                    delay = ABSTL(6, 9, _loc1_, roundModel, delay);
                    break;
                case 26:
                    delay = ABSTL(5, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(6, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(4, 6, _loc1_, roundModel, delay);
                    delay = ABSTL(4, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 4, _loc1_, roundModel, delay);
                    delay = ABSTL(3, 7, _loc1_, roundModel, delay);
                    break;
                case 27:
                    delay = ABSTL(100, 4, _loc1_, roundModel, delay);
                    break;
                case 28:
                    delay = ABSTL(7, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(3, 9, _loc1_, roundModel, delay);
                    break;
                case 29:
                    delay = ABSTL(70, 5, _loc1_, roundModel, delay);
                    break;
                case 30:
                    delay = ABSTL(10, 8, _loc1_, roundModel, delay);
                    break;
                case 31:
                    delay = ABSTL(18, 9, _loc1_, roundModel, delay);
                    break;
                case 32:
                    delay = ABSTL(25, 6, _loc1_, roundModel, delay);
                    delay = ABSTL(30, 7, _loc1_, roundModel, delay);
                    delay = ABSTL(8, 8, _loc1_, roundModel, delay);
                    break;
                case 33:
                    delay = ABSTL(50, 11, _loc1_, roundModel, delay);
                    break;
                case 34:
                    delay = ABSTL(14, 9, _loc1_, roundModel, delay);
                    break;
                case 35:
                    delay = ABSTL(25, 7, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(35, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(3, 10, _loc1_, roundModel, delay);
                    break;
                case 36:
                    delay = ABSTL(90, 5, _loc1_, roundModel, delay);
                    break;
                case 37:
                    delay = ABSTL(20, 6, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 7, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 9, _loc1_, roundModel, delay);
                    break;
                case 38:
                    delay = ABSTL(20, 7, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(16, 9, _loc1_, roundModel, delay);
                    delay = ABSTL(12, 10, _loc1_, roundModel, delay);
                    break;
                case 39:
                    delay = ABSTL(10, 6, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 7, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 9, _loc1_, roundModel, delay);
                    delay = ABSTL(22, 10, _loc1_, roundModel, delay);
                    break;
                case 40:
                    delay = ABSTL(10, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(4, 12, _loc1_, roundModel, delay);
                    break;
                case 41:
                    delay = ABSTL(80, 6, _loc1_, roundModel, delay);
                    delay = ABSTL(80, 7, _loc1_, roundModel, delay);
                    break;
                case 42:
                    delay = ABSTL(40, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(30, 10, _loc1_, roundModel, delay);
                    break;
                case 43:
                    delay = ABSTL(10, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 12, _loc1_, roundModel, delay);
                    break;
                case 44:
                    delay = ABSTL(5, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(40, 9, _loc1_, roundModel, delay);
                    delay = ABSTL(30, 7, _loc1_, roundModel, delay);
                    break;
                case 45:
                    delay = ABSTL(25, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(200, 5, _loc1_, roundModel, delay);
                    delay = ABSTL(8, 8, _loc1_, roundModel, delay);
                    break;
                case 46:
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    break;
                case 47:
                    delay = ABSTL(20, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(70, 11, _loc1_, roundModel, delay);
                    break;
                case 48:
                    delay = ABSTL(120, 11, _loc1_, roundModel, delay);
                    delay = ABSTL(50, 10, _loc1_, roundModel, delay);
                    break;
                case 49:
                    delay = ABSTL(10, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 11, _loc1_, roundModel, delay);
                    delay = ABSTL(18, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 9, _loc1_, roundModel, delay);
                    delay = ABSTL(22, 10, _loc1_, roundModel, delay);
                    break;
                case 50:
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(8, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    break;
                case 51:
                    delay = ABSTL(28, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 10, _loc1_, roundModel, delay);
                    break;
                case 52:
                    delay = ABSTL(25, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 12, _loc1_, roundModel, delay);
                    break;
                case 53:
                    delay = ABSTL(50, 11, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    break;
                case 54:
                    delay = ABSTL(15, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 12, _loc1_, roundModel, delay);
                    break;
                case 55:
                    delay = ABSTL(40, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(12, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(19, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    break;
                case 56:
                    delay = ABSTL(120, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(25, 12, _loc1_, roundModel, delay);
                    break;
                case 57:
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 12, _loc1_, roundModel, delay);
                    break;
                case 58:
                    delay = ABSTL(1, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(25, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 12, _loc1_, roundModel, delay);
                    break;
                case 59:
                    delay = ABSTL(50, 12, _loc1_, roundModel, delay);
                    break;
                case 60:
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    break;
                case 61:
                    delay = ABSTL(20, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(10, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 10, _loc1_, roundModel, delay);
                    break;
                case 62:
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(200, 11, _loc1_, roundModel, delay);
                    break;
                case 63:
                    delay = ABSTL(50, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(37, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(18, 8, _loc1_, roundModel, delay);
                    break;
                case 64:
                    delay = ABSTL(7, 13, _loc1_, roundModel, delay);
                    break;
                case 65:
                    delay = ABSTL(100, 9, _loc1_, roundModel, delay);
                    delay = ABSTL(50, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(20, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    break;
                case 66:
                    delay = ABSTL(9, 13, _loc1_, roundModel, delay);
                    break;
                case 67:
                    delay = ABSTL(5, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(14, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(15, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(14, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(5, 13, _loc1_, roundModel, delay);
                    break;
                case 68:
                    delay = ABSTL(4, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(14, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    break;
                case 69:
                    delay = ABSTL(30, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(100, 12, _loc1_, roundModel, delay);
                    break;
                case 70:
                    delay = ABSTL(200, 10, _loc1_, roundModel, delay);
                    delay = ABSTL(3, 13, _loc1_, roundModel, delay);
                    break;
                case 71:
                    delay = ABSTL(10, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(30, 12, _loc1_, roundModel, delay);
                    break;
                case 72:
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    delay = ABSTL(30, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    break;
                case 73:
                    delay = ABSTL(5, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(30, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    delay = ABSTL(14, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    break;
                case 74:
                    delay = ABSTL(100, 12, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    delay = ABSTL(100, 12, _loc1_, roundModel, delay);
                    break;
                case 75:
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    delay = ABSTL(14, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    delay = ABSTL(14, 8, _loc1_, roundModel, delay);
                    delay = ABSTL(2, 13, _loc1_, roundModel, delay);
                    delay = ABSTL(14, 1, _loc1_, roundModel, delay);
                    delay = ABSTL(1, 14, _loc1_, roundModel, delay);
                    break;
                case 250:
                    delay = ABSTL(9999, 14, _loc1_, roundModel, delay);
                    break;
                //_loc2_ = 76;
                default:
                    if (!(round >= 75))

                    {
                        ModHelper.Warning<ClassicRoundsMod>("Round " + (round + 1) + ": Missing round data, using a placeholder round.");
                        //ABSTL(6, round, 9, roundModel, delay);
                        roundModel.AddBloonGroup(BloonID<OliveCamo>(), 1, delay, delay + BloonInterval(round));
                        //delay += BloonInterval(round);
                        roundModel.AddBloonGroup("Red", 40, delay, delay + BloonInterval(round));
                        //delay = ABSTL(40, round, 1, roundModel, delay);
                        roundModel.AddBloonGroup("Blue", 4, delay, delay + BloonInterval(round));
                        break;
                    }
                    else
                    {
                        var rand = new Random();
                        //while (_loc2_ < 255)
                        //{
                        _loc3_ = 7 + _loc2_ - 75;
                        _loc4_ = 0;
                        while (_loc4_ < _loc3_)
                        {
                            _loc5_ = 9;
                            _loc6_ = rand.Next(_loc2_);
                            if (diff == "medium")
                            {
                                _loc6_ += 3;
                            }
                            if (diff == "hard")
                            {
                                _loc6_ += 7;
                            }
                            if (diff == "impop")
                            {
                                _loc6_ += 14;
                            }
                            if (_loc6_ > 10)
                            {
                                _loc5_ = 10;
                            }
                            if (_loc6_ > 47)
                            {
                                _loc5_ = 12;
                            }
                            if (_loc6_ > 67)
                            {
                                _loc5_ = 13;
                            }
                            if (_loc6_ > 77)
                            {
                                _loc5_ = 14;
                            }
                            switch (_loc5_)
                            {
                                case 5: //why.
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                case 11:
                                    delay = ABSTL(10, _loc5_, _loc2_, roundModel, delay);
                                    break;
                                case 12:
                                    delay = ABSTL(_loc2_ - 65, _loc5_, _loc2_, roundModel, delay);
                                    break;
                                case 13:
                                    delay = ABSTL(_loc2_ - 70, _loc5_, _loc2_, roundModel, delay);
                                    break;
                                case 14:
                                    delay = ABSTL((int)Math.Round((decimal)(_loc2_ - 75) / 3), _loc5_, _loc2_, roundModel, delay);
                                    break;
                            }
                            _loc4_++;
                        }
                        //_loc2_++;
                        break;
                        //};
                        //break;
                    }
                    //delay = ABSTL(9999, 14, 250);
            }
        }
    }
    public class Btd4ApopRounds : Btd4StandardRounds
    {
        public override string diff => "medium";
        public override string Icon => VanillaSprites.BFBIcon;
        public override bool Rounds1Index => true;
        public override int DefinedRounds => 255 + ClassicRoundsMod.GeneratedBTD4ApopalypseRounds;
        public override string DisplayName => "BTD4 Apopalypse";
        public override bool AddToOverrideMenu => true;
        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            switch (round)
            {
                case 1:
                    ABSTL(50, 1, 1, roundModel, 0);
                    break;
                default:
                    Random rand = new();

                    //int _loc2_ = 0;
                    //int _loc3_ = 0;
                    //int _loc4_ = 0;
                    delay = 0;
                    var _loc2_ = 0;
                    while (_loc2_ < 50)
                    {
                        var _loc3_ = rand.Next(10) + round + 1;
                        var _loc4_ = 1;
                        if (_loc3_ < 10)
                        {
                            _loc4_ = 1;
                        }
                        if (_loc3_ >= 10 && _loc3_ < 15)
                        {
                            _loc4_ = 2;
                        }
                        if (_loc3_ >= 15 && _loc3_ < 20)
                        {
                            _loc4_ = 3;
                        }
                        if (_loc3_ >= 20 && _loc3_ < 25)
                        {
                            _loc4_ = 4;
                        }
                        if (_loc3_ >= 25 && _loc3_ < 30)
                        {
                            _loc4_ = 5;
                        }
                        if (_loc3_ >= 30 && _loc3_ < 35)
                        {
                            _loc4_ = 6;
                        }
                        if (_loc3_ >= 35 && _loc3_ < 40)
                        {
                            _loc4_ = 7;
                        }
                        if (_loc3_ >= 40 && _loc3_ < 45)
                        {
                            _loc4_ = 8;
                        }
                        if (_loc3_ >= 45 && _loc3_ < 50)
                        {
                            _loc4_ = 9;
                        }
                        if (_loc3_ >= 50 && _loc3_ < 55)
                        {
                            _loc4_ = 10;
                        }
                        if (_loc3_ >= 55 && _loc3_ < 60)
                        {
                            _loc4_ = 11;
                        }
                        if (_loc3_ >= 60 && _loc3_ < 65)
                        {
                            _loc4_ = 12;
                        }
                        if (_loc3_ >= 65 && _loc3_ < 70)
                        {
                            _loc4_ = 13;
                        }
                        if (_loc3_ >= 70)
                        {
                            _loc4_ = 14;
                        }
                        if (_loc3_ >= 75 && false)
                        {
                            _loc4_ = 15;
                        }
                        if (_loc3_ >= 80 && false)
                        {
                            _loc4_ = 16;
                        }
                        if (_loc4_ >= 16)
                        {
                            _loc4_ = 16;
                        }
                        //this.ABTL(_loc4_, ?); <== this is the funcion to spawn a single bloon in BTD4

                        // THIS IS DUMB AND INEFFICIENT!! 
                        // One BloonGroup for every. single. fucking. Bloon.
                            //..yet it is still smaller than the Standard roundset :/

                        //_loc4_++;
                        delay = ABSTL(1, _loc4_, round, roundModel, delay);
                        _loc2_++;
                    }
                    break;
            }
        }
    }
}