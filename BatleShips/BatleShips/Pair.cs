using System;
namespace BatleShips
{
	public class Pair <T, K>
    {

		public T First { get; set; }
		public K Second { get; set; }
        public Pair(T f,K s)
        {
			First = f;
			Second = s;
        }
    }
}
