using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldGrid : Composite
    {
        public ShieldGrid(GameObject.Name name, Sprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;

            // this creates a new box which is white
            base.Resurrect();

            // Set it to desired color
            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }

        ~ShieldGrid()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldGrid(this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldGrid
            // Debug.WriteLine("--Grid vs Missile");
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

		public override void VisitGrid(AlienGrid b)
		{
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }

		public override void VisitBomb(Bomb b)
		{
            GameObject pGameObject = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(b, pGameObject);             
		}


		public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // -------------------------------------------
        // Data: 
        // -------------------------------------------


    }
}