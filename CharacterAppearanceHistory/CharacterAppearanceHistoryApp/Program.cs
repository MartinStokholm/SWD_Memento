using CharacterAppearanceHistoryApp;

// Client code.
var character = new Character("green");
var characterManager = new CharacterManager(character);

while (true)
{
    if (Console.KeyAvailable)
    {
        var keyPressed = Console.ReadKey(true);
        
        if (keyPressed.Key == ConsoleKey.R) character.ChangeColor("red");
        if (keyPressed.Key == ConsoleKey.L) character.ChangeSize("large");
        if (keyPressed.Key == ConsoleKey.P) characterManager.PrintHistory(); 
        if (keyPressed.Key == ConsoleKey.U) characterManager.Undo();
        if (keyPressed.Key == ConsoleKey.Escape) break;
    }
}