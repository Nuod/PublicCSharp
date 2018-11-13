using System;
namespace BatleShips
{
    public class Game
    {
		public static void Start()
		{
			var P1 = new Player("Bob", "/home/nuuduha/Code/C#/BatleShips/BatleShips/InputShips1.txt");
			var P2 = new Player("Bill", "/home/nuuduha/Code/C#/BatleShips/BatleShips/InputShips2.txt");
			while(true)
			{
				if(P1.doHit(P2))
				{
					break;
				}
				if (P2.doHit(P1))
                {
                    break;
                }
			}
		}

    }
}
