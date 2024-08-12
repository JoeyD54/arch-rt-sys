using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatchMan : ManBase
    {
        /**********************
		* 
		* Constructor
		* 
		**********************/

        //LTN's - ManBase (the 2 DLinkMan's)
        public SpriteBatchMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            SpriteBatchMan.psActiveSBMan = null;         
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/


        //Lower priority # means it is rendered earlier in list
        public static void Create()
        {

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                //LTN's - SpriteBatchMan
                pInstance = new SpriteBatchMan();
            }
        }
        public static void Destroy()
        {
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance(); ;
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
        }


        public static SpriteBatch Add(SpriteBatch.Name name,int reserveNum = 3, int reserveGrow = 1)
        {
            SpriteBatchMan pMan = SpriteBatchMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            //Replace this and make a "baseAddByPriority"?
            //SpriteBatch pNode = (SpriteBatch)pMan.baseAddToFront();

            //Add by priority, not to front
            SpriteBatch pNode = (SpriteBatch)pMan.baseAddToFront();
            Debug.Assert(pNode != null);

            // Initialize the data
            pNode.Set(name, reserveNum, reserveGrow);

            return pNode;
        }

        public static SpriteBatch AddByPriority(SpriteBatch.Name name, int priority, int reserveNum = 3, int reserveGrow = 1)
        {
            SpriteBatchMan pMan = SpriteBatchMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            //Replace this and make a "baseAddByPriority"?
            //SpriteBatch pNode = (SpriteBatch)pMan.baseAddToFront();

            //Add by priority, not to front
            SpriteBatch pNode = (SpriteBatch)pMan.baseAddByPriority(priority);
            Debug.Assert(pNode != null);

            // Initialize the data
            pNode.Set(name, priority, reserveNum, reserveGrow);

            return pNode;
        }
        public static void Draw()
        {
            SpriteBatchMan pMan = SpriteBatchMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            // walk through the list and render
            Iterator pIt = pMan.baseGetIterator();
            Debug.Assert(pIt != null);

            SpriteBatch pSpriteBatch = (SpriteBatch)pIt.First();

            // Walk through the nodes
            while (!pIt.IsDone())
            {
                if (pSpriteBatch.GetDrawEnable())
                {
                    SpriteNodeMan pSBNodeMan = pSpriteBatch.GetSBNodeMan();
                    Debug.Assert(pSBNodeMan != null);

                    // Kick the can
                    pSBNodeMan.Draw();
                }

                pSpriteBatch = (SpriteBatch)pIt.Next();
            }
        }

        public static void SetActive(SpriteBatchMan pSBMan)
        {
            SpriteBatchMan pMan = SpriteBatchMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSBMan != null);
            SpriteBatchMan.psActiveSBMan = pSBMan;
        }

        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            SpriteBatchMan pMan = SpriteBatchMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;

            SpriteBatch pData = (SpriteBatch)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(SpriteBatch pNode)
        {
            SpriteBatchMan pMan = SpriteBatchMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);

            pMan.baseRemove(pNode);
        }

        public static void Remove(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            SpriteNodeMan pSpriteNodeMan = pSpriteBatchNode.GetSBNodeMan();

            Debug.Assert(pSpriteNodeMan != null);
            pSpriteNodeMan.Remove(pSpriteBatchNode);
        }

        public static void Dump()
        {
            SpriteBatchMan pMan = SpriteBatchMan.psActiveSBMan;
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private static SpriteBatchMan privGetInstance()
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
            //LTN's - SpriteBatchMan
            NodeBase pNodeBase = new SpriteBatch();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private readonly SpriteBatch poNodeCompare = new SpriteBatch();
        private static SpriteBatchMan pInstance = null;
        private static SpriteBatchMan psActiveSBMan = null;

    }
}
