using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageMan : ManBase
    {
        /**********************
		* 
		* Constructor
		* 
		**********************/

        //LTN - ManBase (the 2 DLinkMan's)
        private ImageMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            //LTN- ImageMan
            this.poNodeCompare = new Image();
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
                //LTN - ImageMan
                pInstance = new ImageMan(reserveNum, reserveGrow);
            }

            //Texture pHotPinkText = TextureMan.Find(Texture.Name.HotPink);
            //Debug.Assert(pHotPinkText != null);

            Image pHotPink = ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);
            Debug.Assert(pHotPink != null);

            Image pImageNull = ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 0, 0);
            Debug.Assert(pImageNull != null);
        }

        public static void Destroy()
        {
            ImageMan pMan = ImageMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
        }

        public static Image Add(Image.Name name, Texture pSrcTexture, float x, float y, float width, float height)
        {
            ImageMan pMan = ImageMan.privGetInstance();
            Debug.Assert(pMan != null);

            Image pNode = (Image)pMan.baseAddToFront();
            Debug.Assert(pNode != null);

            // Initialize the date
            pNode.Set(name, pSrcTexture, x, y, width, height);
            return pNode;
        }

        public static Image Add(Image.Name name, Texture.Name textureName, float x, float y, float width, float height)
        {
            ImageMan pMan = ImageMan.privGetInstance();
            Debug.Assert(pMan != null);

            Texture pSrcTexture = TextureMan.Find(textureName);

            Image pNode = (Image)pMan.baseAddToFront();
            Debug.Assert(pNode != null);

            // Initialize the date
            pNode.Set(name, pSrcTexture, x, y, width, height);
            return pNode;
        }

        public static Image Find(Image.Name name)
        {
            ImageMan pMan = ImageMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;

            Image pData = (Image)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(Image pImage)
        {
            Debug.Assert(pImage != null);

            ImageMan pMan = ImageMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseRemove(pImage);
        }
        public static void Dump()
        {
            ImageMan pMan = ImageMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private static ImageMan privGetInstance()
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
            //LTN - ImageMan
            NodeBase pNodeBase = new Image();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private readonly Image poNodeCompare;
        private static ImageMan pInstance = null;

    }
}
