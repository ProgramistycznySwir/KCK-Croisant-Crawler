using System;

namespace Croisant_Crawler.Data
{
    public struct Connections
    {
        // 4x Empty, Left, Down, Right, Up;
        public byte data { get; private set; }

        public Connections Inverted => new Connections { data = (byte)~this.data };

        public bool IsUp    => ((data >> 0) % 2) is 1;
        public bool IsRight => ((data >> 1) % 2) is 1;
        public bool IsDown  => ((data >> 2) % 2) is 1;
        public bool IsLeft  => ((data >> 3) % 2) is 1;

        public bool IsFull => (data & 0b00001111) == 0b00001111;

        public bool Is(int num)
            => num switch{
                0 => IsUp,
                1 => IsRight,
                2 => IsDown,
                3 => IsLeft,
                _ => throw new ArgumentException()
            };

        public static Connections Up    => new Connections { data = 0b00000001};
        public static Connections Right => new Connections { data = 0b00000010};
        public static Connections Down  => new Connections { data = 0b00000100};
        public static Connections Left  => new Connections { data = 0b00001000};
        public static Connections None  => new Connections { data = 0b00000000};

        public static Connections operator +(Connections left, Connections right)
            => new Connections { data = (byte)(left.data | right.data) };
        public static Connections operator -(Connections left, Connections right)
            => new Connections { data = (byte)(left.data & ~right.data) };

        // public static Vector2Int operator +(Vector2Int vector, Connections connections)
        //     => Vector2Int;
    }
}