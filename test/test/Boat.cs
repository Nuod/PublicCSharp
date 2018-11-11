using System;
namespace test
{
	public abstract class Boat
	{
		public string id { get; set; }
		public int status; // 0 - die, 1 - wouded, 2 - full hp
		public int HP { get; set; }
		public Pair<int, int> begin;
		public Pair<int, int> end;
		public static int count = 0;
        protected int len;
        
		public Boat (Pair<int, int> begin, Pair<int, int> end)
         
		{
			this.begin = begin;
			this.end = end;
			count++;
			status = 2;
			HP = LenghtOfBoat(begin, end);
		}
		private int LenghtOfBoat(Pair<int, int> beginShip, Pair<int, int> endShip)
		{
			return (int)Math.Truncate(Math.Sqrt(Math.Pow((endShip.First - beginShip.First), 2) + Math.Pow((endShip.Second - beginShip.Second),2))) + 1;
		}
		private string GenerateId()
		{
			return HP.ToString() + count.ToString();
		}
        public void updateStatus()
        {
            if (HP == len) 
            {
                status = 2;    
            }
            else if(HP == 0)
            {
                status = 0;
            }
            else
            {
                status = 1;
            }
            

        }
        

    }
}
