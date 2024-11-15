using System;

namespace ClassicRounds.Util
{
    // C# version of BTD5's RNG code (util.§'#§)
    public class Btd5rndm
    {
        private static Btd5rndm _instance = new();
        private uint _seed;
        private uint _pointer = 0;
        private bool _reset = true;
        private Random _random;

        public Btd5rndm(uint seed = 0)
        {
            _seed = seed;
            _random = new Random((int)seed);
        }

        public static Btd5rndm Instance => _instance;

        public uint Seed
        {
            get => _seed;
            set
            {
                if (value != _seed)
                {
                    _reset = true;
                    _pointer = 0;
                }
                _seed = value;
                _random = new Random((int)value);
            }
        }

        public uint Pointer
        {
            get => _pointer;
            set => _pointer = value;
        }

#pragma warning disable IDE1006 // Naming Styles
        public double random()
        {
            if (_reset)
            {
                _random = new Random((int)_seed);
                _reset = false;
            }
            _pointer = (_pointer + 1) % 200000;
            return _random.NextDouble();
        }

        public double NextDouble(double minValue, double maxValue = double.NaN)
        {
            if (double.IsNaN(maxValue))
            {
                maxValue = minValue;
                minValue = 0;
            }
            return random() * (maxValue - minValue) + minValue;
        }

        public bool NextBool(double probability = 0.5)
        {
            return random() < probability;
        }

        public int NextSign(double probability = 0.5)
        {
            return random() < probability ? 1 : -1;
        }

        public int NextBit(double probability = 0.5)
        {
            return random() < probability ? 1 : 0;
        }

        public int NextInt(double minValue, double maxValue = double.NaN)
        {
            if (double.IsNaN(maxValue))
            {
                maxValue = minValue;
                minValue = 0;
            }
            return (int)Math.Floor(NextDouble(minValue, maxValue));
        }

        public void Reset()
        {
            _pointer = 0;
        }
    }
}
