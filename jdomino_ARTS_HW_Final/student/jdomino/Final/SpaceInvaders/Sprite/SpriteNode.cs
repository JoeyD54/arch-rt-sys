using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNode : DLink
    {

        /**********************
		* 
		* Constructor
		* 
		**********************/

        public SpriteNode()
        : base()
        {
            this.pSpriteBase = null;
            this.pBackSpriteNodeMan = null;
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/

        public void Set(SpriteBase pNode, SpriteNodeMan _pSpriteNodeMan)
        {
            Debug.Assert(pNode != null);
            this.pSpriteBase = pNode;

            // Set the back pointer
            // Allows easier deletion in the future
            Debug.Assert(pSpriteBase != null);
            this.pSpriteBase.SetSpriteNode(this);

            Debug.Assert(_pSpriteNodeMan != null);
            this.pBackSpriteNodeMan = _pSpriteNodeMan;
        }
        public SpriteBase GetSpriteBase()
        {
            return this.pSpriteBase;
        }
        public SpriteNodeMan GetSBNodeMan()
        {
            Debug.Assert(this.pBackSpriteNodeMan != null);
            return this.pBackSpriteNodeMan;
        }
        public SpriteBatch GetSpriteBatch()
        {
            Debug.Assert(this.pBackSpriteNodeMan != null);
            return this.pBackSpriteNodeMan.GetSpriteBatch();
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private void privClear()
        {
            this.pSpriteBase = null;
        }

        /**********************
		* 
		* Override Methods
		* 
		**********************/

        override public void Wash()
        {
            this.privClear();
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   ({0}) node", this.GetHashCode());

            // Data:
            Debug.WriteLine("   pSprite: {0} ({1})", this.pSpriteBase.GetName(), this.pSpriteBase.GetHashCode());

            base.Dump();
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        public SpriteBase pSpriteBase;
        private SpriteNodeMan pBackSpriteNodeMan;
    }
}
