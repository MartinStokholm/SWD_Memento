namespace CharacterAppearanceHistoryApp
{ 
    // The Caretaker doesn't depend on the Concrete Memento class. Therefore, it
    // doesn't have access to the originator's state, stored inside the memento.
    // It works with all mementos via the base Memento interface.
    public class CharacterManager
    {
        private List<ICharacterMemento> _mementos = new();

        private Character _character;

        public CharacterManager(Character character)
        {
            _character = character;
        }

        public void Backup()
        {
            Console.WriteLine("\nCharacterHistory: Saving Character state...");
            _mementos.Add(_character.Save());
        }

        public void Undo()
        {
            if (_mementos.Count == 0) { return; }

            var memento = _mementos.Last();
            _mementos.Remove(memento);

            Console.WriteLine("CharacterHistory: Restoring state to: " + memento.GetName());

            try { _character.Restore(memento); }
            catch (Exception) { Undo(); }
        }

        public void PrintHistory()
        {
            Console.WriteLine("CharacterHistory: List of mementos:");

            foreach (var memento in _mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}
    