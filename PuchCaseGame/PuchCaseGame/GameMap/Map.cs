using System;
namespace PuchCaseGame.GameMap
{
	internal class Map
	{
		public int Deepth
		{
			get;
			set;
		}

		public int Width
		{
			get;
			set;
		}

		public int BoxCount
		{
			get;
			set;
		}

		public MapObject[,]? MapElements
		{
			get;
			set;
		}

		public MapObject[]? BoxElements
		{
			get;
			set;
		}

		public MapObject[]? TargetElements
		{
			get;
			set;
		}
		
		public Map(int[,] elements, int width, int height, int boxcount)
		{
            Deepth = height;
            Width = width;
            BoxCount = boxcount;
            InitialGame(elements);
		}

		public void InitialGame(int[,] mapInfoArr)
        {
            int currentBox = 0;
            int currentTarget = 0;

            MapElements = new MapObject[Deepth, Width];
            BoxElements = new MapObject[BoxCount];
            TargetElements = new MapObject[BoxCount];

            for (int y = 0; y < Deepth; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    switch (mapInfoArr[y, x])
                    {
                        case 0:
                            MapElements[y, x] = new EmptyElement(x, y, ' ');
                            break;
                        case 2:
                            BoxElements[currentBox] = new BoxElement(x, y, '@');
                            currentBox++;
                            MapElements[y, x] = new EmptyElement(x, y, ' ');
                            break;
                        case 3:
                            TargetElements[currentTarget] = new TargetElement(x, y, 'A');
                            currentTarget++;
                            MapElements[y, x] = new EmptyElement(x, y, ' ');
                            break;
                        case 1:
                            MapElements[y, x] = new WallElement(x, y, '#');
                            break;
                    }
                }
            }
        }
	}
}

