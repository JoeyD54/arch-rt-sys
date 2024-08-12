using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShieldCategory : Leaf
    {
        public enum Type
        {
            Root,
            Column,
            Brick,
            Grid,

            LeftTop0,
            LeftTop1,
            LeftBottom,
            LeftBottomHalfVert,
            RightTop0,
            RightTop1,
            RightBottom,
            RightBottomHalfVert,


            Unitialized
        }

        protected ShieldCategory(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, ShieldCategory.Type shieldType)
            : base(name, spriteName, posX, posY)
        {
            this.ShieldType = shieldType;
        }
        // Data: ---------------
        ~ShieldCategory()
        {
        }
        public ShieldCategory.Type GetCategoryType()
        {
            return this.ShieldType;
        }

        // --------------------------------------------------------------------
        // Data:
        // --------------------------------------------------------------------

        // this is just a placeholder, who knows what data will be stored here
        protected ShieldCategory.Type ShieldType;

    }
}