using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipCategory : Leaf
    {
        public enum Type
        {
            Ship,
            ShipRoot,
            Unitialized
        }

        protected ShipCategory(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, ShipCategory.Type shipType)
            : base(name, spriteName, posX, posY)
        {
            this.ShipType = shipType;
        }

        // Data: ---------------
        ~ShipCategory()
        {
        }

        // this is just a placeholder, who knows what data will be stored here
        protected ShipCategory.Type ShipType;

    }
}