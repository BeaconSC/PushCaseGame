using System;
using Newtonsoft.Json;
using PuchCaseGame.GameMap;
using PuchCaseGame.GamePlayer;
namespace PuchCaseGame.Stage
{
	internal class StageInfo
	{
		public string Name
		{
			get;
			set;
		}

		public int Width
		{
			get;
			set;
		}

		public int Height
		{
			get;
			set;
		}

		public int Playerpox
		{
			get;
			set;
		}

		public int Playerpoy
		{
			get;
			set;
		}

		public int Boxcount
		{
			get;
			set;
		}

		public int[,] Elements
		{
			get;
			set;
		}

		public StageInfo()
		{
		}
	}
}

