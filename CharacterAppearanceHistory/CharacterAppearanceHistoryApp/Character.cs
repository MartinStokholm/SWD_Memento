using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CharacterAppearanceHistoryApp
{
    // The Originator holds some important state that may change over time. It
    // also defines a method for saving the state inside a memento and another
    // method for restoring the state from it.
    class Character
    {
        // For the sake of simplicity, the originator's state is stored inside a
        // single variable.
        private string _color;

        public Character(string newColor)
        {
            this._color = newColor;
            Console.WriteLine("Character: My color is: " + newColor);
        }

        // The Originator's business logic may affect its internal state.
        // Therefore, the client should backup the state before launching
        // methods of the business logic via the save() method.
        public void ChangeColor(string newColor)
        {
            Console.WriteLine("Character: I'm changing my color.");
            this._color = newColor;
            Console.WriteLine($"Character: my color is now changed to: {_color}");
        }

        // Saves the current state inside a memento.
        public IMemento Save()
        {
            return new ConcreteMemento(this._color);
        }

        // Restores the Originator's state from a memento object.
        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this._color = memento.GetColor();
            Console.Write($"Character: my color is now changed to: {_color}");
        }
    }

    // The Memento interface provides a way to retrieve the memento's metadata,
    // such as creation date or name. However, it doesn't expose the
    // Originator's state.
    public interface IMemento
    {
        string GetName();

        string GetColor();

        DateTime GetDate();
    }

    // The Concrete Memento contains the infrastructure for storing the
    // Originator's state.
    class ConcreteMemento : IMemento
    {
        private string _color;

        private DateTime _date;

        public ConcreteMemento(string color)
        {
            this._color = color;
            this._date = DateTime.Now;
        }

        // The Originator uses this method when restoring its state.
        public string GetColor()
        {
            return this._color;
        }
        
        // The rest of the methods are used by the Caretaker to display
        // metadata.
        public string GetName()
        {
            return $"{this._date} / {this._color}";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }
}