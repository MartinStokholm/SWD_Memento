namespace CharacterAppearanceHistoryApp
{ 
    // The Caretaker doesn't depend on the Concrete Memento class. Therefore, it
    // doesn't have access to the originator's state, stored inside the memento.
    // It works with all mementos via the base Memento interface.
    class CharacterManager
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private Character _character = null;

        public CharacterManager(Character character)
        {
            this._character = character;
        }

        public void Backup()
        {
            Console.WriteLine("\nCharacterHistory: Saving Character state...");
            this._mementos.Add(this._character.Save());
        }

        public void Undo()
        {
            if (this._mementos.Count == 0) { return; }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("CharacterHistory: Restoring state to: " + memento.GetName());

            try { this._character.Restore(memento); }
            catch (Exception) { this.Undo(); }
        }

        public void PrintHistory()
        {
            Console.WriteLine("CharacterHistory: List of mementos:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}
    