using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace test
{
    public class Player
    {
		private ArrayList ListOfShips;
		public Pair<int, Boat>[,] field { get; protected set; }
        
		public Player(StreamReader shipsReader)
        {
            field = new Pair<int, Boat>[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field[i, j] = new Pair<int, Boat>(0, null);
                }
            }
			FormatShips(shipsReader);

        }

		public Pair<int, Boat>[,] Shoot(Pair<int, Boat>[,] field)
		{
			this.field = field;
			string s = Console.ReadLine();
			Pair<int, int> sh; 
			do
			{
				try
				{

					int s1, s2;
					s1 = Int32.Parse(s[0].ToString());
					s2 = Int32.Parse(s[1].ToString());
					sh = new Pair<int, int>(s1, s2);

				}
				catch (InvalidOperationException)
				{
					Console.WriteLine("Invalid input");
					sh = new Pair<int, int>(-1,-1);

				}
			}while (!X2Shot(sh));
			field[sh.First, sh.Second].Second.HP--;
			field[sh.First, sh.Second].Second.updateStatus();
			if(field[sh.First, sh.Second].Second.status == 0)
			{
				foreach (Boat i in ListOfShips)
				{
					if (i.status == 0)
					{
						ListOfShips.Remove(i);
					}
				}

			}
			return field;

		}

		public bool isLose()
		{
			return ListOfShips.Count == 0;
		}
		public void FormatShips(StreamReader shipsReader)
		{
			string s;
			while(!shipsReader.EndOfStream)
			{
				s = shipsReader.ReadLine();
				switch (Int32.Parse(s.Substring(0,1)))
				{
					case 1:{
							var ship = new OneShip(Pair<int,int>.MakePair(Int32.Parse(s.Substring(2, 1)), Int32.Parse(s.Substring(3, 1))), 
							                       Pair<int, int>.MakePair(Int32.Parse(s.Substring(5, 1)), Int32.Parse(s.Substring(6, 1))));
							ListOfShips.Add(ship);
							break;
						}
					case 2:
						{
							var ship = new TwoShip(Pair<int, int>.MakePair(Int32.Parse(s.Substring(2, 1)), Int32.Parse(s.Substring(3, 1))),
                                                   Pair<int, int>.MakePair(Int32.Parse(s.Substring(5, 1)), Int32.Parse(s.Substring(6, 1))));
                            ListOfShips.Add(ship);
                            break;
						}
					case 3:
						{
							var ship = new ThreeShip(Pair<int, int>.MakePair(Int32.Parse(s.Substring(2, 1)), Int32.Parse(s.Substring(3, 1))),
                                                   Pair<int, int>.MakePair(Int32.Parse(s.Substring(5, 1)), Int32.Parse(s.Substring(6, 1))));
                            ListOfShips.Add(ship);
                            break;
						}
					case 4:
						{
							var ship = new FourShip(Pair<int, int>.MakePair(Int32.Parse(s.Substring(2, 1)), Int32.Parse(s.Substring(3, 1))),
                                                   Pair<int, int>.MakePair(Int32.Parse(s.Substring(5, 1)), Int32.Parse(s.Substring(6, 1))));
                            ListOfShips.Add(ship);
                            break;
						}
                        

				}
			}
			
		}
		private bool X2Shot(Pair<int, int> shoot)
		{
			if(field[shoot.First,shoot.Second].First == 1 || (shoot.First == -1 || shoot.First == -1))
			{
				return true;
			}
			return false;
		}

       


    }
}
