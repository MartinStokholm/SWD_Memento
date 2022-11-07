namespace CharacterAppearanceHistoryApp
{
    // The Originator holds some important state that may change over time. It
    // also defines a method for saving the state inside a memento and another
    // method for restoring the state from it.
    class Character
    {
        // Define character states
        private string _color;
        private string _size;
        private string _strength;
        public Character(string newColor, string newSize = "medium", string newStrength = "average")
        {
            _color = newColor;
            _size = newSize;
            _strength = newStrength;
            Console.WriteLine($"Character: I am a {_color}, {_size}, {_strength} character.");
        }

        // The Originator's business logic may affect its internal state.
        // Therefore, the client should backup the state before launching
        // methods of the business logic via the save() method.
        public void ChangeAppearance(string newColor, string newSize = "medium", string newStrength = "average")
        {
            Console.WriteLine($"Character: I am changing my appearance to {newColor}, {newSize}, {newStrength}.");
            _color = newColor;
            _size = newSize;
            _strength = newStrength;
        }

        // Saves the current state inside a memento.
        public ICharacterMemento Save()
        {
            return new CharacterMemento(_color, _size, _strength);
        }

        // Restores the Originator's state from a memento object.
        public void Restore(ICharacterMemento memento)
        {
            if (!(memento is CharacterMemento))
            {
                throw new Exception("Unknown memento class " + memento);
            }

            _color = memento.GetColor();
            Console.Write($"Character: my color is now changed to: {_color}");
            
            _size = memento.GetSize();
            Console.Write($", my size is now changed to: {_size}");
            
            _strength = memento.GetStrength();
            Console.WriteLine($", my strength is now changed to: {_strength}");
        }
    }
}