using CharacterAppearanceHistoryApp;

// Client code.
var character = new Character("green");
var characterManager = new CharacterManager(character);

characterManager.Backup();
character.ChangeAppearance("red", "small", "strong");
            
characterManager.Backup();
character.ChangeAppearance("blue", "large", "weak");

Console.WriteLine();
characterManager.PrintHistory();

Console.WriteLine("\nProgramMain: first undo!\n");
characterManager.Undo();

Console.WriteLine("\n\nProgramMain: second undo!\n");
characterManager.Undo();

Console.WriteLine();