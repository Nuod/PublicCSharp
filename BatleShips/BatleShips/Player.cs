using System;
using System.Collections.Generic;
using System.IO;
namespace BatleShips
{
    public class Player
    {
		public string name { get; set; }
		Dictionary<Tuple<int, int>, Boat> PlayersShips;
		Dictionary<Tuple<int, int>, char> missFair;
		Dictionary<Tuple<int, int>, char> enemyField;

		public Player(string name,string path)
        {
			this.name = name;
			PlayersShips = ParseString.ParseShip(new StreamReader(path));
			missFair = new Dictionary<Tuple<int, int>, char>();
			enemyField = new Dictionary<Tuple<int, int>, char>();

        }

		public Answer getHit(Tuple<int, int> coordinate)
		{
			
			foreach(KeyValuePair<Tuple<int, int>, Boat> kvp in PlayersShips)
			{
				if(kvp.Key == coordinate)
				{
					
					missFair.Add(coordinate,'X'); 
					PlayersShips.Remove(coordinate);
					return new Answer(PlayersShips.Count == 0, kvp.Value.doHit(), false);

				}
			}
			foreach(KeyValuePair<Tuple<int, int>, char> kvp in missFair)
			{
				if(kvp.Key == coordinate)
				{
					return new Answer(false, -2, true);
				}
			}
			missFair.Add(coordinate,'*');
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
		public void Draw()
		{
			var field = new char[Const.WidthField, Const.LenghtField];
			var enemy = new char[Const.WidthField, Const.LenghtField];
			for (int i = 0; i < Const.WidthField; i++)
				for (int j = 0; j < Const.LenghtField; j++)
				{
					field[i, j] = '~';
					enemy[i, j] = '~';
				}
			foreach(var kvp in PlayersShips)
			{
				field[kvp.Key.Item1, kvp.Key.Item2] = 'O';
			}

				foreach (var kvp in missFair)
				{
					field[kvp.Key.Item1, kvp.Key.Item2] = kvp.Value;
				}
            

				foreach (var kvp in enemyField)
				{
					enemy[kvp.Key.Item1, kvp.Key.Item2] = kvp.Value;
				}
			
			for (int i = 0; i < Const.WidthField; i++)
			{
				for (int j = 0; j < Const.LenghtField; j++)
					Console.Write(" {0} ",field[i,j]);
				Console.Write(" | ");
				for (int j = 0; j < Const.LenghtField; j++)
					Console.Write(" {0} ", enemy[i,j]);
				Console.WriteLine();
				}	
		}

    }
}
