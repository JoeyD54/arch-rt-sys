using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallRight : WallCategory
    {
        public WallRight(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, Type.Right)
        {
            this.poColObject.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObject.pColSprite.SetColor(1, 1, 0);
        }

        ~WallRight()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallRight(this);
        }
        public override void Update()
        {
            // Go to first child
            base.Update();
        }


        public override void VisitGrid(AlienGrid a)
        {
            // AlienGrid vs WallRight
            Debug.WriteLine("\ncollide: {0} with {1}", this, a);
            Debug.WriteLine("               --->DONE<----");

            ColPair pColPair = ColPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }

		public override void VisitUFOGrid(UFOGrid g)
		{
            // UFOGrid vs WallRight
            Debug.WriteLine("\ncollide: {0} with {1}", this, g);
            Debug.WriteLine("               --->DONE<----");

            ColPair pColPair = ColPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(this, g);
            pColPair.NotifyListeners();
        }

		//public override void Move(float x, float y)
		//{
		//	throw new NotImplementedException();
		//}

		// Data: ---------------


	}

}
