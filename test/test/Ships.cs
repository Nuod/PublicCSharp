using System;
namespace test
{
	public class OneShip:Boat
    {
        
		public OneShip(Pair<int, int> begin, Pair<int, int> end):base(begin, end)
		{
            HP = 1;
            len = 1;
            count++;
		}
    }

	public class TwoShip:Boat
    {
		public TwoShip(Pair<int, int> begin, Pair<int, int> end) : base(begin, end)
        {
            HP = 2;
            len = 2;
            count++;
        }
    }

	public class ThreeShip:Boat
    {
        public ThreeShip(Pair<int, int> begin, Pair<int, int> end) : base(begin, end)
        {
            HP = 3;
            len = 3;
            count++;
        }
    }

	public class FourShip:Boat
    {
        public FourShip(Pair<int, int> begin, Pair<int, int> end) : base(begin, end)
        {
            HP = 4;
            len = 4;
            count++;
        }
    }
}
