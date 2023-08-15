using System;
using PuchCaseGame.GameMap;

namespace PuchCaseGame.GamePlayer
{
	internal class PlayerController
	{
		static private PlayerController instance = new PlayerController();
		static public PlayerController Instance()
		{
			return instance;
		}
		private PlayerController(){}

		public Player CurrentPlayer
		{
			get;
			set;
		}

        public void Move(Input input, MapController mapController)
        {
            int oldPosX = CurrentPlayer.PosX;
            int oldPosY = CurrentPlayer.PosY;

            switch (input)
            {
                case Input.UP: CurrentPlayer.PosY--; break;
                case Input.DOWN: CurrentPlayer.PosY++; break;
                case Input.LEFT: CurrentPlayer.PosX--; break;
                case Input.RIGHT: CurrentPlayer.PosX++; break;
                default: break;
            }

            if (!mapController.CheckMove(input, CurrentPlayer.PosX, CurrentPlayer.PosY))
            {
                CurrentPlayer.PosX = oldPosX;
                CurrentPlayer.PosY = oldPosY;
            }
        }

        public void Record()
        {
            DrawTool.Draw(CurrentPlayer.PosX, CurrentPlayer.PosY, CurrentPlayer.avatar);
        }
    }
}

