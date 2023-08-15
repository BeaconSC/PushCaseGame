using System;
namespace PuchCaseGame.GameMap
{
	abstract public class MapObject
	{
		public int PosX
		{
			get;
			set;
		}

		public int PosY
		{
			get;
			set;
		}

		public char Avatar
		{
			get;
			set;
		}

		public MapObject(int posX, int posY, char avatar)
		{
			PosX = posX;
			PosY = posY;
			Avatar = avatar;
		}

		public void Draw()
		{
			Console.CursorLeft = PosX;
			Console.CursorTop = PosY;
			Console.Write(Avatar);
		}

	}
}

