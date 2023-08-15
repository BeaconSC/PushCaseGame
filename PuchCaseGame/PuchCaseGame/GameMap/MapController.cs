using System;
namespace PuchCaseGame.GameMap
{
	internal class MapController
	{
		static private MapController instance = new MapController();
		static public MapController Instance()
		{
			return instance;
		}

		private MapController()
		{
		}

		public Map CurrentMap
		{
			get;
			set;
		}

        public bool CheckMove(Input input, int x, int y)
        {
            if (CurrentMap.MapElements[y, x] is WallElement)
            {
                return false;
            }
            foreach (BoxElement box in CurrentMap.BoxElements)
            {
                if (box.PosX == x && box.PosY == y)
                {
                    switch (input)
                    {
                        case Input.UP: box.PosY--; break;
                        case Input.DOWN: box.PosY++; break;
                        case Input.LEFT: box.PosX--; break;
                        case Input.RIGHT: box.PosX++; break;
                        default:
                            break;
                    }
                    if (CurrentMap.MapElements[box.PosY, box.PosX] is WallElement)
                    {
                        box.PosX = x;
                        box.PosY = y;
                        return false;
                    }
                    foreach (BoxElement checkBox in CurrentMap.BoxElements)
                    {
                        if (box != checkBox)
                        {
                            if (box.PosY == checkBox.PosY && box.PosX == checkBox.PosX)
                            {
                                box.PosX = x;
                                box.PosY = y;
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}

