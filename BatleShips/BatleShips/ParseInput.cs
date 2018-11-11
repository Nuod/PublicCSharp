using System;
using System.Collections.Generic;
using System.IO;
namespace BatleShips
{
	public class ParseString
	{
		public static Dictionary<Tuple<int, int>, Boat> ParseShip(StreamReader file)
		{
			var ShipsKit = new Dictionary<Tuple<int, int>, Boat>();
			while(file.Peek() != -1)
			{
				string s = file.ReadLine();
				var decks = Int32.Parse(s.Substring(0, 1));
				var CoordinateBegin = new Tuple<int, int>(Int32.Parse(s.Substring(2, 1)), Int32.Parse(s.Substring(3, 1)));
				var CoordinateEnd = new Tuple<int, int>(Int32.Parse(s.Substring(5, 1)), Int32.Parse(s.Substring(6, 1)));
				var SList = FormatList(CoordinateBegin, CoordinateEnd);
				var Boat = ShipBuilder.Builder(decks);
				for (int i = 0; i < SList.Count;i++)
				{
					ShipsKit.Add(SList[i], Boat);
				}
			}
			return ShipsKit;

		}
		private static List<Tuple<int,int>> FormatList(Tuple<int,int> Cbegin, Tuple<int, int> Cend)
		{
			var Cships = new List<Tuple<int, int>>();
			if ((Cbegin.Item1 - Cend.Item1) == 0)
            {
                if (Cbegin.Item2 > Cend.Item2)
                {
                    for (int i = Cend.Item2; i <= Cbegin.Item2; i++)
                    {
						Cships.Add(new Tuple<int, int>(Cbegin.Item1, i));
                    }
                }
                else
                {
                    for (int i = Cbegin.Item2; i <= Cend.Item2; i++)
                    {
						Cships.Add(new Tuple<int, int>(Cbegin.Item1, i));
                        
                    }
                }
            }
            else if ((Cbegin.Item2 - Cend.Item2) == 0)
            {
                if (Cbegin.Item1 > Cend.Item1)
                {
					for (int i = Cend.Item1; i <= Cbegin.Item1; i++)
                    {
						Cships.Add(new Tuple<int, int>(i,Cbegin.Item2));
                        
                    }
                }
                else
                {
                    for (int i = Cbegin.Item1; i <= Cend.Item1; i++)
                    {
						Cships.Add(new Tuple<int, int>(i,Cbegin.Item2));
                        
                    }
                }
            }
			return Cships;
		}


        
    }
}
