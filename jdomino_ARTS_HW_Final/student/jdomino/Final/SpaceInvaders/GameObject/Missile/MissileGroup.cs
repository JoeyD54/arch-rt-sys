using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class MissileGroup : Composite
	{
        public MissileGroup()
            :base()
        {
            this.name = Name.MissileGroup;

            this.poColObject.pColSprite.SetColor(0, 0, 1);
        }

        ~MissileGroup()
        {

        }

        public override void VisitGrid(AlienGrid a)
        {
            // MissileGroup vs AlienGrid
            // Debug.WriteLine("collide: {0} with {1}", a, this);

            // MissileGroup vs AlienGrid
            //              go down a level in MissileGroup
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(a, pGameObj);
        }

		public override void VisitBombRoot(BombRoot b)
		{
             ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
		}

		public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an MissileGroup
            // Call the appropriate collision reaction            
            other.VisitMissileGroup(this);
         }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
