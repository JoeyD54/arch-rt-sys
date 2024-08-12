using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BumperCategory : Leaf
    {
        public enum Type
        {
            Right,
            Left,

            Unitialized
        }

        protected BumperCategory(GameObject.Name gameName, Sprite.Name spriteName, float _x, float _y, BumperCategory.Type _type)
        : base(gameName, spriteName, _x, _y)
        {
            BumperType = _type;
        }

        ~BumperCategory()
        {
        }

        public BumperCategory.Type GetCategoryType()
        {
            return this.BumperType;
        }

        // Data ----------
        protected BumperCategory.Type BumperType;

    }
}