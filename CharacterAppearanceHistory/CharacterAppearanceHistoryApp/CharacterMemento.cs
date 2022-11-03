namespace CharacterAppearanceHistoryApp
{
    // The Memento interface provides a way to retrieve the memento's metadata,
    // such as creation date or name. However, it doesn't expose the
    // Originator's state.
    public interface ICharacterMemento
    {
        string GetName();

        string GetColor();
        string GetSize();
        string GetStrength();

        DateTime GetDate();
    }

    // The Concrete Memento contains the infrastructure for storing the
    // Originator's state.
    class CharacterMemento : ICharacterMemento
    {
        private string _color;
        private string _size;
        private string _strength;

        private DateTime _date;

        public CharacterMemento(string color, string size, string strength)
        {
            this._color = color;
            this._size = size;
            this._strength = strength;
            this._date = DateTime.Now;
        }

        public string GetColor()
        {
            return this._color;
        }

        public string GetSize()
        {
            return this._size;
        }

        public string GetStrength()
        {
            return this._strength;
        }
        
        // helper methods for meta data about the CharacterMementos 
        public string GetName()
        {
            return $"{this._date} // {this._color} : {this._size} : {this._strength}";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }
}