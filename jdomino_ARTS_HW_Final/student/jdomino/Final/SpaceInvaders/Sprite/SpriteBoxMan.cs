using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    class SpriteBoxMan : ManBase
    {
        /**********************
		* 
		* Constructor
		* 
		**********************/

        //LTN's - ManBase (the 2 DLinkMan's)
        private SpriteBoxMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            //LTN's - SpriteBoxMan
            this.poNodeCompare = new SpriteBox();
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                //LTN's - SpriteBoxMan
                pInstance = new SpriteBoxMan(reserveNum, reserveGrow);
            }

            SpriteBoxMan.Add(SpriteBox.Name.Null_Object, 0, 0, 0, 0, null);
        }
        public static void Destroy()
        {
            SpriteBoxMan pMan = SpriteBoxMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
        }
        public static SpriteBox Add(SpriteBox.Name name, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            SpriteBoxMan pMan = SpriteBoxMan.privGetInstance();
            Debug.Assert(pMan != null);

            SpriteBox pNode = (SpriteBox)pMan.baseAddToFront();
            Debug.Assert(pNode != null);

            pNode.Set(name, x, y, width, height, pColor);

            return pNode;
        }

        public static SpriteBox Find(SpriteBox.Name name)
        {
            SpriteBoxMan pMan = SpriteBoxMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;

            SpriteBox pData = (SpriteBox)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(SpriteBox pNode)
        {
            Debug.Assert(pNode != null);

            SpriteBoxMan pMan = SpriteBoxMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseRemove(pNode);
        }
        public static void Dump()
        {
            SpriteBoxMan pMan = SpriteBoxMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private static SpriteBoxMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        /**********************
		* 
		* Override Methods
		* 
		**********************/

        override protected NodeBase DerivedCreateNode()
        {
            //LTN's - SpriteBoxMan
            NodeBase pNodeBase = new SpriteBox();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private readonly SpriteBox poNodeCompare;
        private static SpriteBoxMan pInstance = null;
    }
}
