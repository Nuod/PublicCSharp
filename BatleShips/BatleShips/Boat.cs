using System;
namespace BatleShips
{
	public abstract class Boat
	{
		public int status { get; set; }
		public int Hp { get; set; }
		public int numOfDeck { get; }

		public Boat(int countDeck)
		{
			status = 1;
			Hp = countDeck;
			numOfDeck = countDeck;
		}
		public int doHit()
		{
			Hp--;
			updateStatus();
			return status;

		}
		private void updateStatus()
		{
			if (Hp == numOfDeck)
			{
				status = 1;
			}
			else if (Hp <= 0)
			{
				status = -1;
			}
			else
			{
				status = 0;
			}
		}


	}
	class OneShip : Boat
	{
		static int count = 0;

		public OneShip(int countDeck) : base(countDeck)
		{
			count++;
		}
	}
	class TwoShip : Boat
	{
		static int count = 0;

		public TwoShip(int countDeck) : base(countDeck)
		{
			count++;
		}
	}
	class ThreeShip : Boat
	{
		static int count = 0;

		public ThreeShip(int countDeck) : base(countDeck)
		{
			count++;
		}
	}
	class FourShip : Boat
	{
		static int count = 0;

		public FourShip(int countDeck) : base(countDeck)
		{
			count++;
		}
	}
	class CustopShip : Boat
	{

		public CustopShip(int countDeck) : base(countDeck)
		{

		}
	}
	class ShipBuilder
	{
		public static Boat Builder(int Deck)
		{
			switch(Deck)
			{
					case 1: { return new OneShip(Deck); }
					case 2: { return new TwoShip(Deck); }
					case 3: { return new ThreeShip(Deck); }
					case 4: { return new FourShip(Deck); }
					default: { return new CustopShip(Deck); }
			}
		}
	}

}
