using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipRoot : Composite
    {
        public ShipRoot(GameObject.Name name, Sprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObject.pColSprite.SetColor(0, 0, 1);
        }

        ~ShipRoot()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShipRoot(this);
        }

        public override void VisitBumperRoot(BumperRoot b)
        {
            //Debug.WriteLine("collide: {0} with {1}", this, b);

            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(b, pGameObj);
        }

		public override void VisitGrid(AlienGrid b)
		{
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            GameObject pGameObjB = (GameObject)IteratorForwardComposite.GetChild(b);
            ColPair.Collide(pGameObjB, pGameObj);
        }

		public override void VisitBombRoot(BombRoot b)
		{
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
		}

		public override void VisitBomb(Bomb b)
		{
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
		}

		public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }


        // Data: ---------------


    }
}