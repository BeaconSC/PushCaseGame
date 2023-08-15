using System;
using Newtonsoft.Json;
using PuchCaseGame.GameMap;
using PuchCaseGame.GamePlayer;
namespace PuchCaseGame.Stage
{
	internal class StageController
	{
		static private StageController instance = new StageController();
		static public StageController Instance()
		{
			return instance;
		}
		private StageController()
		{
		}

        private StageInfo[] stageInfos = null;

        public void ShowWelcome(InputController inputController)
		{
            Console.CursorVisible = false;
            Console.WriteLine("*******************************Welcome to Push Box World*******************************");
			Console.WriteLine("1. Start the game.");
			Console.WriteLine("2. Quit the game.");
            while (true)
			{
				Input inputKey = inputController.InputConvert();
				switch (inputKey)
				{
					case Input.D1:
						{
							Console.Clear();
							return;
						}
					case Input.D2:
						{
							Environment.Exit(0);
						}
						break;
					default:
						break;
				}
            }
		}

		public int ChooseStage(InputController inputController)
		{
            Console.CursorVisible = true;
            int currentLevel = 0;
			for(int i = 0; i < stageInfos.Length; i++)
			{
				currentLevel += 1;
				Console.WriteLine(currentLevel+ ". " +stageInfos[i].Name);
			}
			Console.WriteLine("Tap Q to level the game.");
			Console.WriteLine("Tap R to reset the game.");
			Console.CursorTop = 0;
			currentLevel = 0;
			while (true)
			{
				Input inputKey = inputController.InputConvert();
				switch (inputKey)
				{
					case Input.UP:
						{
							if (currentLevel > 0)
							{
								currentLevel -= 1;
								Console.CursorTop -= 1;
							}
						}
						break;
					case Input.DOWN:
						{
							if (currentLevel < stageInfos.Length - 1)
							{
								currentLevel += 1;
								Console.CursorTop += 1;
							}
						}
						break;
					case Input.Q:
						Environment.Exit(0);
						break;
					case Input.ENTER:
						Console.CursorVisible = false;
						Console.Clear();
						return currentLevel;
					default:
						break;
				} 
			}
		}

        public void ReadInit(string path)
        {
            string Jstr = File.ReadAllText(path);
            stageInfos = JsonConvert.DeserializeObject<StageInfo[]>(Jstr);
        }

        public bool EnterStage(int num)
        {
            if (num >= stageInfos.Length || num < 0)
            {
                return false;
            }

            StageInfo currentStage = stageInfos[num];

            Player player = new Player(currentStage.Playerpox, currentStage.Playerpoy, '&');
            PlayerController.Instance().CurrentPlayer = player;

            Map map = new Map(currentStage.Elements, currentStage.Width, currentStage.Height, currentStage.Boxcount);
            MapController.Instance().CurrentMap = map;

            return true;
        }

        public bool CheckWin()
		{
			Map currentMap = MapController.Instance().CurrentMap;
			MapObject[] boxList = currentMap.BoxElements;
			MapObject[] targetList = currentMap.TargetElements;

			foreach(MapObject box in boxList)
			{
				bool flag = false;
				foreach(MapObject target in targetList)
				{
					if (box.PosX == target.PosX && box.PosY == target.PosY)
					{
						flag = true;
						break;
					}
				}
				if(flag == false)
				{
					return false;
				}
			}

			return true;
		}
	}
}

