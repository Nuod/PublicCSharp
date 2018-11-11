using System;
namespace test
{
    public class GameMaster
    {
		private Pair<int, Boat>[,] player1Field;
		private Pair<int, Boat>[,] player2Field;
		private Player p1;
		private Player p2;
		
		public GameMaster(Player p1, Player p2)
        {
			this.p1 = p1;
			this.p2 = p2;
			player1Field = p1.field;
			player2Field = p2.field;
        }
		public void DrawField()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					switch (player1Field[i, j].First)
					{
						case 0:
							{
								if (player1Field[i, j].Second == null)
								{
									Console.Write(" ~ ");
									break;
								}
								else
								{
									Console.Write(" H ");
									break;
								}
							}
						case 1:
							{
								if (player1Field[i, j].Second == null)
								{
									Console.Write(" * ");
									break;
								}
								else
								{
									Console.Write(" X ");
									break;
								}
							}
					}
				}
				Console.Write("   |  ");
				for (int j = 0; j < 10; j++)
				{
					switch (player2Field[i, j].First)
					{
						case 0:
							{
								if (player2Field[i, j].Second == null)
								{
									Console.Write(" ~ ");
									break;
								}
								else
								{
									Console.Write(" H ");
									break;
								}
							}
						case 1:
							{
								if (player2Field[i, j].Second == null)
								{
									Console.Write(" * ");
									break;
								}
								else
								{
									Console.Write(" X ");
									break;
								}
							}
					}

				}
				Console.WriteLine();
			}
		}
		private bool Win()
		{
				if(p1.isLose() || p2.isLose())
				{
					return true;
				}
			return false;
		}
    }
}
