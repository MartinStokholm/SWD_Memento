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
            _color = color;
            _size = size;
            _strength = strength;
            _date = DateTime.Now;
        }

        public string GetColor()
        {
            return _color;
        }

        public string GetSize()
        {
            return _size;
        }

        public string GetStrength()
        {
            return _strength;
        }
        
        // helper methods for meta data about the CharacterMementos 
        public string GetName()
        {
            return $"{_date} // {_color} : {_size} : {_strength}";
        }

        public DateTime GetDate()
        {
            return _date;
        }
    }
}