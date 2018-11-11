using System;
namespace BatleShips
{
    public class Answer
    {
		public bool lose { get; }
		public int status{ get; }
		public bool failFair{ get; }

        public Answer(bool l, int s,bool f)
        {
			lose = l;
			status = s;
			failFair = f;
        }
    }
}
