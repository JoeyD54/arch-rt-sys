using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallTop : WallCategory
    {
        public WallTop(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, WallCategory.Type.Top)
        {
            this.poColObject.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObject.pColSprite.SetColor(1, 0, 0);
        }

        ~WallTop()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallTop(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);
            // MissileRoot vs WallTop
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs WallTop
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);            
            pColPair.NotifyListeners();
        }

        public override void Update()
        {
            // Go to first child
            base.Update();
        }

		//public override void Move(float x, float y)
		//{
		//	throw new NotImplementedException();
		//}


		// Data: ---------------


	}
}