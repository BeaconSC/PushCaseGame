using PuchCaseGame.GamePlayer;
using PuchCaseGame.GameMap;
using PuchCaseGame.Stage;
namespace PuchCaseGame;

class Program
{
    static void Main(string[] args)
    {
        InputController inputController = new InputController();

        StageController.Instance().ReadInit("MapInfo.json");

        StageController.Instance().ShowWelcome(inputController);

        int currentLevel = StageController.Instance().ChooseStage(inputController);

        StageController.Instance().EnterStage(currentLevel);

        RecordMap.Record(MapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);

        while (true)
        {
            Input input = inputController.InputConvert();

            if (input == Input.RESET)
            {
                StageController.Instance().ReadInit("MapInfo.json");
                StageController.Instance().EnterStage(currentLevel);
                RecordMap.Record(MapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);
                continue;
            }

            if(input == Input.Q)
            {
                Environment.Exit(0);
            }

            PlayerController.Instance().Move(input, MapController.Instance());

            RecordMap.Record(MapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);

            if (StageController.Instance().CheckWin())
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You win!");
                Console.WriteLine("(Tab any key to continue)");
                Console.ReadKey(true);
                StageController.Instance().ReadInit("MapInfo.json");
                Console.Clear();
                currentLevel = StageController.Instance().ChooseStage(inputController);
                StageController.Instance().EnterStage(currentLevel);
                RecordMap.Record(MapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);
            }

        }
    }
}

