using System;

namespace PuchCaseGame
{
	enum Input
	{
		UP,
		DOWN,
		LEFT,
		RIGHT,
		ENTER,
		Q,
		RESET,
		D1,
		D2,
		NONE
	}

	internal class InputController
	{
		public InputController() {}

		 public Input InputConvert()
		{
			Input input = Input.NONE;

            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
			 
            switch (keyinfo.Key)
			{
				case ConsoleKey.W:
					input = Input.UP;
					break;
				case ConsoleKey.S:
					input = Input.DOWN;
					break;
				case ConsoleKey.A:
					input = Input.LEFT;
					break;
				case ConsoleKey.D:
					input = Input.RIGHT;
					break;
				case ConsoleKey.Enter:
					input = Input.ENTER;
					break;
				case ConsoleKey.Q:
					input = Input.Q;
					break;
                case ConsoleKey.R:
                    input = Input.RESET;
                    break;
                case ConsoleKey.D1:
					input = Input.D1;
					break;
				case ConsoleKey.D2:
					input = Input.D2;
					break;
				default:
					input = Input.NONE;
					break;
			}

			return input;
		}
	}
}

