namespace Game
{
    internal class Game
    {
        int size;
        int[,] map;
        int spaceX, spaceY;
        static Random rnd = new Random();
        public Game ()
        {
            size = 4;
            map = new int[size, size];
        }
        public void Start()
        {
            for (int x = 0; x < size; ++x)
                for (int y = 0; y < size; ++y)
                    map[x, y] = IsCoords(x, y) + 1;
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX, spaceY] = 0;
        }

        public int GetNumber(int position)
        {
            int x, y;
            IsPosition(position, out x, out y);
            if (x < 0 || x >= size || y < 0 || y >= size) return 0;
            return map[x, y];
        }

        public int IsCoords (int x, int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;
            return y * size + x;
        }

        public void IsPosition (int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;
            x = position % size;
            y = position / size;
        }

        public bool Shift(int position)
        {
            int x, y;
            IsPosition(position, out x, out y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1)
                return false;
            map[spaceX, spaceY] = map[x, y];
            map[x, y] = 0;
            spaceX = x;
            spaceY = y;
            return true;
        }
        public void ShiftRandom()
        {
            int a = rnd.Next(0, 4);
            int x = spaceX;
            int y = spaceY;

            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            Shift(IsCoords(x, y));
        }

        public bool Win()
        {
            if (!(spaceX == size - 1 && spaceY == size - 1)) 
                return false;
            for (int x = 0; x < size; ++x)
                for (int y = 0; y < size; ++y)
                    if (!(x == size - 1 && y == size - 1))
                        if(map[x, y] != IsCoords(x, y) + 1)
                            return false;
            return true;
        }
    }
}
