using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperLeft : BumperCategory
    {
        public BumperLeft(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, BumperCategory.Type.Left)
        {
            this.poColObject.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObject.pColSprite.SetColor(1, 1, 0);
        }

        ~BumperLeft()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitBumperLeft(this);
        }


        public override void Update()
        {
            // Go to first child
            base.Update();
        }

        // Data: ---------------

    }
}
