namespace CharacterAppearanceHistoryApp
{

    public class CharacterChangedEventArgs : EventArgs
    {
        ///Data to be passed in event

    }
    // The Originator holds some important state that may change over time. It
    // also defines a method for saving the state inside a memento and another
    // method for restoring the state from it.
    public class Character
    {
        // Define character states
        private string _color;
        private string _size;
        private string _strength;

        public EventHandler<CharacterChangedEventArgs> CharacterChanged;
        public Character(string newColor, string newSize = "medium", string newStrength = "average")
        {
            _color = newColor;
            _size = newSize;
            _strength = newStrength;
            Console.WriteLine($"Character: I am a {_color}, {_size}, {_strength} character.");
        }

        public void OnCharacterChanged(CharacterChangedEventArgs e)
        {
            CharacterChanged?.Invoke(this, e);
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
            OnCharacterChanged(new CharacterChangedEventArgs());

        }

        public void ChangeColor(string newColor)
        {
            Console.WriteLine($"Character: I am changing my color to {newColor}.");
            _color = newColor;
            OnCharacterChanged(new CharacterChangedEventArgs());
            
        }

        public void ChangeSize(string newSize)
        {
            Console.WriteLine($"Character: I am changing my size to {newSize}.");
            _size = newSize;
            OnCharacterChanged(new CharacterChangedEventArgs());
        }

        public void ChangeStrength(string newStrength)
        {
            Console.WriteLine($"Character: I am changing my strength to {newStrength}.");
            _strength = newStrength;
            OnCharacterChanged(new CharacterChangedEventArgs());
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