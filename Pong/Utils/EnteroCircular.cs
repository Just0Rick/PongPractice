namespace Pong.Utils
{
    public class EnteroCircular
    {
        public int Value { get; private set; }
        public EnteroCircular()
        {
            Value = 0;
        }
        public EnteroCircular(int i)
        {
            if (i > 2)
                i = 0;
            else if (i < 0)
                i = 2;
            Value = i;
        }

        public static implicit operator int(EnteroCircular o)
        {
            return o.Value;
        }

        public static implicit operator EnteroCircular(int i)
        {
            return new EnteroCircular(i);
        }

        public static EnteroCircular operator+(EnteroCircular o, int i)
        {
            return new EnteroCircular(o.Value + i);
        }

        public static EnteroCircular operator-(EnteroCircular o, int i)
        {
            return new EnteroCircular(o.Value - 1);
        }

        public static EnteroCircular operator++(EnteroCircular o)
        {
            return new EnteroCircular(o.Value + 1);
        }

        public static EnteroCircular operator--(EnteroCircular o)
        {
            return new EnteroCircular(o.Value - 1);
        }
    }
}
