using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextureMan : ManBase
    {
        /**********************
		* 
		* Constructor
		* 
		**********************/

        //LTN's - ManBase (the 2 DLinkMan's)
        private TextureMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            //LTN's - TextureMan
            this.poNodeCompare = new Texture();
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                //LTN's - TextureMan
                pInstance = new TextureMan(reserveNum, reserveGrow);
            }

            // Default
            Texture pHotPinkTexture = TextureMan.Add(Texture.Name.HotPink, "HotPink.tga");
            Debug.Assert(pHotPinkTexture != null);
        }
        public static void Destroy()
        {
            TextureMan pMan = TextureMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
        }
        public static Texture Add(Texture.Name name, string pTextureName)
        {
            TextureMan pMan = TextureMan.privGetInstance();
            Debug.Assert(pMan != null);

            Texture pNode = (Texture)pMan.baseAddToFront();
            Debug.Assert(pNode != null);

            // Initialize the date
            pNode.Set(name, pTextureName);
            return pNode;
        }

        public static Texture Find(Texture.Name name)
        {
            TextureMan pMan = TextureMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;

            Texture pData = (Texture)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }
        public static void Remove(Texture pTexture)
        {
            Debug.Assert(pTexture != null);

            TextureMan pMan = TextureMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseRemove(pTexture);
        }
        public static void Dump()
        {
            TextureMan pMan = TextureMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private static TextureMan privGetInstance()
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
            //LTN's - TextureMan
            NodeBase pNodeBase = new Texture();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private readonly Texture poNodeCompare;
        private static TextureMan pInstance = null;
    }
}