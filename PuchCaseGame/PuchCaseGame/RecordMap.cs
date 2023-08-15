using System;
using PuchCaseGame.GameMap;
using PuchCaseGame.GamePlayer;

namespace PuchCaseGame
{
	static class RecordMap
	{
		static public void Record(Map gameMap, Player player)
		{
            Console.CursorVisible = false;
            int width = gameMap.Width;
            int deepth = gameMap.Deepth;
            int boxcount = gameMap.BoxCount;

            MapObject[,]? mapElements = gameMap.MapElements;
            MapObject[]? boxElements = gameMap.BoxElements;
            MapObject[]? targetElements = gameMap.TargetElements;

            for (int y = 0; y < deepth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    DrawTool.Draw(mapElements[y, x].PosX, mapElements[y, x].PosY, mapElements[y, x].Avatar);
                }
            }

            for (int x = 0; x < boxcount; x++)
            {
                DrawTool.Draw(targetElements[x].PosX, targetElements[x].PosY, targetElements[x].Avatar);
            }

            DrawTool.Draw(player.PosX, player.PosY, player.avatar);

            for (int x = 0; x < boxcount; x++)
            {
                DrawTool.Draw(boxElements[x].PosX, boxElements[x].PosY, boxElements[x].Avatar);
            }

            Console.CursorLeft = PlayerController.Instance().CurrentPlayer.PosX;
            Console.CursorTop = PlayerController.Instance().CurrentPlayer.PosY;
        }
	}
}

