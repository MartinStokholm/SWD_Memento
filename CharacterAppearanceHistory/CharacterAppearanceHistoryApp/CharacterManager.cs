namespace CharacterAppearanceHistoryApp
{ 
    // The Caretaker doesn't depend on the Concrete Memento class. Therefore, it
    // doesn't have access to the originator's state, stored inside the memento.
    // It works with all mementos via the base Memento interface.
    class CharacterManager
    {
        private List<ICharacterMemento> _mementos = new();

        private Character _character;

        public CharacterManager(Character character)
        {
            _character = character;
            _character.CharacterChanged += HandleCharacterEvent;
            Backup();
        }

        public void HandleCharacterEvent(object s, CharacterChangedEventArgs e)
        {
            Backup();
        }
        public void Backup()
        {
            Console.WriteLine("\nCharacterHistory: Saving Character state...");
            _mementos.Add(_character.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0) {return;}
            if (_mementos.Count > 1) 
                _mementos.Remove(_mementos.Last());
            var memento = _mementos.Last();

            Console.WriteLine("CharacterHistory: Restoring state to: " + memento.GetState());

            try { _character.Restore(memento); }
            catch (Exception) { Undo(); }
        }

        public void PrintHistory()
        {
            Console.WriteLine("CharacterHistory: List of mementos:");

            foreach (var memento in _mementos)
            {
                Console.WriteLine(memento.GetState());
            }
        }
    }
}
    