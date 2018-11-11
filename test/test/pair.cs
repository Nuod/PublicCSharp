using System;
namespace test
{
    public class Pair<T, K>
    {
		public T First { get; set; }
		public K Second { get; set; }
        public Pair(T item1, K item2)
        {
			First = item1;
			Second = item2;
        }
		public static Pair<int, int> MakePair(int f,int s)
		{
			return new Pair<int, int>(f, s);
		}
    }
}
