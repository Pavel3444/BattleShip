namespace BattleShip;

public class Game
{
    public void Start()
    {
        GameState userChoice;
        do
        {
            PrintMenu();
            userChoice = ValidateInput();
            switch (userChoice)
            {
                case GameState.Quit:
                    Quit();
                    break;
                case GameState.New:
                    New();
                    break;
                case GameState.Save:
                    Save();
                    break;
                case GameState.Load:
                    Load();
                    break;
                default:
                    break;
            }
        } while (userChoice == GameState.Menu);
    }

    private GameState ValidateInput()
    {
        var userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput)
            || !int.TryParse(userInput, out int userChoice)
            || userChoice < (int)GameState.Quit
            || userChoice > (int)GameState.Save
           )
        {
            Console.WriteLine("Wrong! Enter 1,2,3 or 0.");
            return GameState.Menu;
        }
        return (GameState)userChoice;
    }

    private void PrintMenu()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("1. New game");
        Console.WriteLine("2. Load game");
        Console.WriteLine("3. Save game");
        Console.WriteLine("0. Quit");
    }

    private void New()
    {
        Console.WriteLine("New");
    }

    private void Save()
    {
        Console.WriteLine("Save");
    }

    private void Load()
    {
        Console.WriteLine("Load");
    }

    private void Quit()
    {
        Console.WriteLine("Quit");
    }
    
}