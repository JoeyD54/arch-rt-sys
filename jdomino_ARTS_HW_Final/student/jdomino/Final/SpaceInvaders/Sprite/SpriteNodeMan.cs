using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNodeMan : ManBase
    {
        /**********************
		* 
		* Constructor
		* 
		**********************/

        //LTN's - ManBase (the 2 DLinkMan's)
        public SpriteNodeMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            //LTN's - SpriteNodeMan
            this.poNodeCompare = new SpriteNode();
            this.pBackSpriteBatch = null;

            Debug.Assert(poNodeCompare != null);
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/

        public void Set(SpriteBatch.Name name, int reserveNum, int reserveGrow)
        {
            this.name = name;

            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            this.baseSetReserve(reserveNum, reserveGrow);
        }

        //public SpriteNode Attach(Sprite.Name name)
        //{
        //    SpriteNode pNode = (SpriteNode)this.baseAddToFront();
        //    Debug.Assert(pNode != null);

        //    // Initialize the date
        //    pNode.Set(name);
        //    return pNode;
        //}

        //public SpriteNode Attach(SpriteBox.Name name)
        //{
        //    SpriteNode pNode = (SpriteNode)this.baseAddToFront();
        //    Debug.Assert(pNode != null);

        //    // Initialize SpriteBatchNode
        //    pNode.Set(name, this);

        //    return pNode;
        //}

  //      public SpriteNode Attach(SpriteProxy pNode)
		//{
  //          SpriteNode pSpriteNode = (SpriteNode)this.baseAddToFront();
  //          Debug.Assert(pSpriteNode != null);

  //          pSpriteNode.Set(pNode);

  //          return pSpriteNode;
		//}

        public SpriteNode Attach(SpriteBase pNode)
		{
            SpriteNode pSpriteNode = (SpriteNode)this.baseAddToFront();
            Debug.Assert(pSpriteNode != null);

            pSpriteNode.Set(pNode, this);

            return pSpriteNode;
        }

        public void Draw()
        {
            // walk through the list and render
            Iterator pIt = this.baseGetIterator();
            Debug.Assert(pIt != null);

            SpriteNode pNode = (SpriteNode)pIt.First();

            // Walk through the nodes
            while (!pIt.IsDone())
            {
                // Assumes someone before here called update() on each sprite
                // Draw me.
                pNode.pSpriteBase.Render();

                pNode = (SpriteNode)pIt.Next();
            }
        }

        public void Remove(SpriteNode pSpriteNode)
        {
            Debug.Assert(pSpriteNode != null);

            this.baseRemove(pSpriteNode);
        }

        public void Dump()
        {

            this.baseDump();
        }

        public SpriteBatch GetSpriteBatch()
        {
            return this.pBackSpriteBatch;
        }
        public void SetSpriteBatch(SpriteBatch _pSpriteBatch)
        {
            this.pBackSpriteBatch = _pSpriteBatch;
        }

        /**********************
		* 
		* Override Methods
		* 
		**********************/

        override protected NodeBase DerivedCreateNode()
        {
            //LTN's - SpriteNodeMan
            NodeBase pNodeBase = new SpriteNode();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private readonly SpriteNode poNodeCompare;
        private SpriteBatch.Name name;
        private SpriteBatch pBackSpriteBatch;
    }
}
