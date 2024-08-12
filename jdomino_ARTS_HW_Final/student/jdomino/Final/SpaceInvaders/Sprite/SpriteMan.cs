using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteMan : ManBase
    {
        /**********************
		* 
		* Constructor
		* 
		**********************/

        //LTN's - ManBase (the 2 DLinkMan's)
        private SpriteMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            //LTN's - SpriteMan
            this.poNodeCompare = new Sprite();
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
                //LTN's - SpriteMan
                pInstance = new SpriteMan(reserveNum, reserveGrow);
            }

            //Image pImage = ImageMan.Find(Image.Name.HotPink);
            //Debug.Assert(pImage != null);
            SpriteMan.Add(Sprite.Name.Null_Object, Image.Name.HotPink, 0.0f, 0.0f, 0.0f, 0.0f, null);
        }
        public static void Destroy()
        {
            SpriteMan pMan = SpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
        }
        public static Sprite Add(Sprite.Name name, Image.Name imageName, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            SpriteMan pMan = SpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            Image pImage = ImageMan.Find(imageName);

            Debug.Assert(pImage != null);

            Sprite pNode = (Sprite)pMan.baseAddToFront();
            Debug.Assert(pNode != null);

            // Initialize the date
            pNode.Set(name, pImage, x, y, width, height, pColor);
            return pNode;
        }

        public static Sprite Find(Sprite.Name name)
        {
            SpriteMan pMan = SpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;

            Sprite pData = (Sprite)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(Sprite pNode)
        {
            Debug.Assert(pNode != null);

            SpriteMan pMan = SpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseRemove(pNode);
        }
        public static void Dump()
        {
            SpriteMan pMan = SpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private static SpriteMan privGetInstance()
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
            //LTN's - SpriteMan
            NodeBase pNodeBase = new Sprite();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private readonly Sprite poNodeCompare;
        private static SpriteMan pInstance = null;
    }
}

