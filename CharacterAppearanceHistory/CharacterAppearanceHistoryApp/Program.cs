namespace CharacterAppearanceHistoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client code.
            Character character = new Character("green");
            CharacterManager characterManager = new CharacterManager(character);

            characterManager.Backup();
            character.ChangeColor("red");

            characterManager.Backup();
            character.ChangeColor("blue");

            Console.WriteLine();
            characterManager.PrintHistory();

            Console.WriteLine("\nClient: Now, let's rollback!\n");
            characterManager.Undo();

            Console.WriteLine("\n\nClient: Once more!\n");
            characterManager.Undo();

            Console.WriteLine();
        }
    }
}