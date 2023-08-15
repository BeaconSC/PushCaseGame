using System;
using PuchCaseGame.GameMap;
namespace PuchCaseGame.GamePlayer
{
	internal class Player
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

		public char avatar
		{
			get;
			set;
		}

		public Player(int posX, int posY, char avatar)
		{
			PosX = posX;
			PosY = posY;
			this.avatar = avatar;

		}
	}
}

