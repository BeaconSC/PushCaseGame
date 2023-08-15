using System;
namespace PuchCaseGame
{
	static class DrawTool
	{
		static public void Draw(int x, int y, char avatar)
		{
			Console.CursorVisible = false;
			Console.CursorLeft = x;
			Console.CursorTop = y;
			Console.Write(avatar);
		}
	}
}

