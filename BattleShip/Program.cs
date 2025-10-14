// See https://aka.ms/new-console-template for more information
while (true)
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. New game");
    Console.WriteLine("2. Load game");
    Console.WriteLine("3. Save game");
    Console.WriteLine("0. Quit");

    string userInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userInput)
        || !int.TryParse(userInput, out int userChoice)
        || userChoice < 0 
        || userChoice > 3
       )
    {
        Console.WriteLine("Wrong! Enter 1,2,3 or 0.");
        continue;
    }
    Console.WriteLine("Wonderful!");
    break;
}

