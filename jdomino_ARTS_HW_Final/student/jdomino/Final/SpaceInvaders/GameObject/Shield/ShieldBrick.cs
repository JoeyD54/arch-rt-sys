using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldBrick : ShieldCategory
    {
        public ShieldBrick(GameObject.Name name, Sprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, posX, posY, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);

            //GameObjectNodeMan.Attach(this);
        }

        //Gives a warning, but still works, so screw you method!
        public void Resurrect(float posX, float posY)
		{
            this.x = posX;
            this.y = posY;

            base.Resurrect();

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
		}
        ~ShieldBrick()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldBrick(this);
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            // Debug.WriteLine("--Brick vs Missile");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }
        public override void VisitBomb(Bomb b)
        {
            // Bomb vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

		public override void VisitGrid(AlienGrid b)
		{
            //AlienColumn vs Brick
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }
		public override void VisitColumn(AlienColumn b)
		{
            //AlienCrab/Squid/Octopus vs Brick
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }


		public override void VisitCrab(AlienCrab alienCrab)
		{
			// AlienCrab vs ShieldBrick
			//Debug.WriteLine(" ---> Done");
			ColPair pColPair = ColPairMan.GetActiveColPair();
			pColPair.SetCollision(alienCrab, this);
			pColPair.NotifyListeners();
		}

		public override void VisitSquid(AlienSquid alienSquid)
		{
			// AlienSquid vs ShieldBrick
			//Debug.WriteLine(" ---> Done");
			ColPair pColPair = ColPairMan.GetActiveColPair();
			pColPair.SetCollision(alienSquid, this);
			pColPair.NotifyListeners();
		}

		public override void VisitOctopus(AlienOctopus alienOctopus)
		{
			// AlienOctopus vs ShieldBrick
			//Debug.WriteLine(" ---> Done");
			ColPair pColPair = ColPairMan.GetActiveColPair();
			pColPair.SetCollision(alienOctopus, this);
			pColPair.NotifyListeners();
		}



		public override void Update()
        {
            base.Update();
        }

		//public override void Move(float x, float y)
		//{  
  //          //Do nothing
  //         Debug.Assert(false);
		//}

		// ---------------------------------
		// Data: 
		// ---------------------------------


	}
}
