using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class AlienGrid : Composite
	{
		public AlienGrid()
			: base()
		{
			name = Name.AlienGrid;

            delta = 15.0f;
            deltaY = 35.0f;
            moveDown = false;

            poColObject.pColSprite.SetColor(1, 0, 0);
        }

        public override void Resurrect()
        {
            base.Resurrect();

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);
        }


        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an AlienGroup
            // Call the appropriate collision reaction            
            other.VisitGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // AlienGrid vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitWallGroup(WallGroup w)
        {
            //Grid vs wallgroup
            //Figure out which wall we hit to decide direction

            //Debug.WriteLine("         collide:  {0} <-> {1}", w.name, this.name);
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(w);
            ColPair.Collide(this, pGameObj);
        }

		//public override void VisitWallRight(WallRight w)
		//{
		//	//We collided with the right wall
  //          Debug.WriteLine("         collide:  { 0} <-> { 1}", w.name, this.name);

  //      }

		public override void Update()
        {
            //Debug.WriteLine("update: {0}", this);
            base.BaseUpdateBoundingBox(this);

            //We need to remove the buffer space each time a column is killed off
            //Totaly space between all columns
            //float maxSpaceBetween = 33.0f;

            //int count = this.GetNumChildren();

            // proof its working
            //this.poColObject.poColRect.width -= maxSpaceBetween;

            base.Update();
        }

        public void MoveGrid()
        {

            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += delta;
                //pGameObj.y += this.y;

                pNode = pFor.Next();
            }
        }

        public void MoveGridDown()
        {

            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.y -= deltaY;
                //pGameObj.y += this.y;

                pNode = pFor.Next();
            }
        }

        public int GetAlienCount()
		{
            int alienCount = 0;

            //Grab a column
            
            GameObject child = (GameObject)IteratorForwardComposite.GetChild(this);
            AlienColumn pColumn = null;


            if(child.name == GameObject.Name.AlienColumn)
			{
                pColumn = (AlienColumn)child;
			}

            while(pColumn != null)
			{
                GameObject pAlien = (GameObject)IteratorForwardComposite.GetChild(pColumn);

                while(pAlien != null)
				{
                    alienCount++;

                    pAlien = (GameObject)pAlien.pNext;
				}


                pColumn = (AlienColumn)pColumn.pNext;
			}

            return alienCount;
		}

		public float GetDelta()
		{
			return this.delta;
		}

        public void SetDelta(float _delta)
		{
            this.delta = _delta;
		}

        private float delta;
        private float deltaY;
        public bool moveDown;
	}
}
