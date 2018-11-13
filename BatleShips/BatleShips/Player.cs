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
				if(kvp.Key.Equals(coordinate))
				{
					
					missFair.Add(coordinate,'X'); 
					PlayersShips.Remove(coordinate);
					return new Answer(PlayersShips.Count == 0, kvp.Value.doHit(), false);

				}
			}
			foreach(KeyValuePair<Tuple<int, int>, char> kvp in missFair)
			{
				if(kvp.Key.Equals(coordinate))
				{
					return new Answer(false, -2, true);
				}
			}
			missFair.Add(coordinate,'*');
			return new Answer(false, -3, false);
		}

		public bool doHit(Player enemy)
		{
			Answer hit;
			int x, y;
			do
			{
				Console.WriteLine(this.name + " strike:");
				Console.WriteLine("Input X");
				string s = Console.ReadLine();
				if(s == "D")
				{
					this.Draw();
					Console.WriteLine("Input X");
					s = Console.ReadLine();
				}

				x = Int32.Parse(s);
				Console.WriteLine("Input Y");
				y = Int32.Parse(Console.ReadLine());
				hit = enemy.getHit(new Tuple<int, int>(x, y));
				switch (hit.status)
                {
                    case -3: { 
							Console.WriteLine("Miss");
							enemyField.Add(new Tuple<int, int>(x, y), '*');
							break; 
						}
					case -2: { 
							Console.WriteLine("Try again!"); 
							break; }
                    case -1: { 
							Console.WriteLine("Die "); 
							enemyField.Add(new Tuple<int, int>(x, y), 'X');
							break; 
						}
                    case  0: { 
							Console.WriteLine("Hurt"); 
							enemyField.Add(new Tuple<int, int>(x, y), 'X');
							break; }
                }
			} while ((hit.failFair || hit.status != -3) && !hit.lose);
			if(hit.lose)
			{
				Console.WriteLine(this.name+"Win");
				return true;
			}
			return false;
            
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
