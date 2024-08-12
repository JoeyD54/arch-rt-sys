using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class ColPair : DLink
	{
		/**********************
		* 
		* Constructor, Destructor, Enum
		* 
		**********************/

		public enum Name
		{
			Alien_Missile,
			Alien_Wall,
            Alien_Shield,
            Alien_Ship,
			Missile_Wall,
            Bomb_Missile,
            Bomb_Wall,
            Bomb_Shield,
            Missile_Shield,
            Bumper_Ship,
            Bomb_Ship,
            Wall_UFO,
            Missile_UFO,

			NullObject,
			Not_Initialized
		}

		public ColPair()
			:base()
		{
			treeA = null;
			treeB = null;
			name = ColPair.Name.Not_Initialized;

			poSubject = new ColSubject();
			Debug.Assert(poSubject != null);
		}

		~ColPair()
		{

		}

        /**********************
		* 
		* Public Methods
		* 
		**********************/

        public void Set(ColPair.Name colpairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
            this.name = colpairName;
        }
        private void privClear()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
        }

        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    // who is being tested?
                    //  Debug.WriteLine("ColPair: test:  {0}, {1}", pNodeA.name, pNodeB.name);

                    // Get rectangles
                    ColRect rectA = pNodeA.GetColObject().poColRect;
                    ColRect rectB = pNodeB.GetColObject().poColRect;

                    // test them
                    if (ColRect.Intersect(rectA, rectB))
                    {
                        // Boom - it works (Visitor in Action)
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)IteratorForwardComposite.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)IteratorForwardComposite.GetSibling(pNodeA);
            }
        }

        public void Attach(ColObserver observer)
        {
            this.poSubject.Attach(observer);
        }
        public void NotifyListeners()
        {
            this.poSubject.Notify();
        }
        public void SetCollision(GameObject pObjA, GameObject pObjB)
        {
            Debug.Assert(pObjA != null);
            Debug.Assert(pObjB != null);

            // GameObject pAlien = AlienCategory.GetAlien(objA, objB);
            this.poSubject.pGameObjA = pObjA;
            this.poSubject.pGameObjB = pObjB;
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        /**********************
		* 
		* Override Methods
		* 
		**********************/

        public override object GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.privClear();
        }

        override public bool Compare(NodeBase pTarget)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(pTarget != null);

            ColPair pDataB = (ColPair)pTarget;

            bool status = false;

            if (this.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            //        todo

            base.Dump();
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/
        public ColPair.Name name;
		public GameObject treeA;
		public GameObject treeB;
		public ColSubject poSubject;
	}
}
