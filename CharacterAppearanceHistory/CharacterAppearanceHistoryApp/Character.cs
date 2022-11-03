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
        // Define character states
        private string _color;
        private string _size;
        private string _strength;
        public Character(string newColor, string newSize = "medium", string newStrength = "average")
        {
            this._color = newColor;
            this._size = newSize;
            this._strength = newStrength;
            System.Console.WriteLine($"Character: I am a {this._color}, {this._size}, {this._strength} character.");
        }

        // The Originator's business logic may affect its internal state.
        // Therefore, the client should backup the state before launching
        // methods of the business logic via the save() method.
        public void ChangeAppearance(string newColor, string newSize = "medium", string newStrength = "average")
        {
            System.Console.WriteLine($"Character: I am changing my appearance to {newColor}, {newSize}, {newStrength}.");
            this._color = newColor;
            this._size = newSize;
            this._strength = newStrength;
        }

        // Saves the current state inside a memento.
        public ICharacterMemento Save()
        {
            return new CharacterMemento(this._color, this._size, this._strength);
        }

        // Restores the Originator's state from a memento object.
        public void Restore(ICharacterMemento memento)
        {
            if (!(memento is CharacterMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this._color = memento.GetColor();
            Console.Write($"Character: my color is now changed to: {_color}");
        }
    }

}