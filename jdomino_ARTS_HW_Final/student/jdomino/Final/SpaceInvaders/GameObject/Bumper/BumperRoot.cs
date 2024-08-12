using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperRoot : Composite
    {
        public BumperRoot(GameObject.Name name, Sprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObject.pColSprite.SetColor(1, 1, 0);

            this.name = name;
        }
        ~BumperRoot()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitBumperRoot(this);
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }


        // Data: ---------------


    }
}