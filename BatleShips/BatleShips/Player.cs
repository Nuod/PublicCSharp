using System;
using System.Collections.Generic;
namespace BatleShips
{
    public class Player
    {
		public string name { get; set; }
		Dictionary<Tuple<int, int>, Boat> PlayersShips;
		Dictionary<int, int> missFair;
		Dictionary<Tuple<int, int>, char> enemyField;

		public Player(string name)
        {
			this.name = name;
			PlayersShips = GenerateShips.Generate();

        }

		public Answer getHit(Tuple<int, int> coordinate)
		{
			
			foreach(KeyValuePair<Tuple<int, int>, Boat> kvp in PlayersShips)
			{
				if(kvp.Key == coordinate)
				{
					
					missFair.Add(coordinate.Item1,coordinate.Item2);
					PlayersShips.Remove(coordinate);
					return new Answer(PlayersShips.Count == 0, kvp.Value.doHit(), false);

				}
			}
			foreach(KeyValuePair<int,int> kvp in missFair)
			{
				if(kvp.Key == coordinate.Item1 && kvp.Value == coordinate.Item2)
				{
					return new Answer(false, -2, true);
				}
			}
			missFair.Add(coordinate.Item1, coordinate.Item2);
			return new Answer(false, -3, false);
		}

		public void doHit(Player enemy)
		{
			Answer hit;
			int x, y;
			do
			{
				Console.WriteLine("Input X");
				x = Int32.Parse(Console.ReadLine());
				Console.WriteLine("Input Y");
				y = Int32.Parse(Console.ReadLine());
				hit = enemy.getHit(new Tuple<int, int>(x, y));
			} while (!hit.failFair);
			if(hit.lose)
			{
				Console.WriteLine("Win");
				return;
			}
			switch (hit.status)
			{
				case -3: { Console.WriteLine("Miss"); break;}
				case -1: { Console.WriteLine("Die ");  break;}
				case  0: { Console.WriteLine("Hurt"); break;}
			}

			if(hit.status == 0)
			{
				enemyField.Add(new Tuple<int, int>(x, y), 'X');
			}
			else
			{
				enemyField.Add(new Tuple<int, int>(x, y), '*');
			}


		
		}
    }
}
