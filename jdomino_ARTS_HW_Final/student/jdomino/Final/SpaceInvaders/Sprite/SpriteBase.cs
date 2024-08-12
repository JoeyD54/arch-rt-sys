using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public abstract class SpriteBase : DLink
	{
        public SpriteBase()
            : base()
        {
            this.pBackSpriteNode = null;
        }

        public abstract void Update();
		public abstract void Render();

        public SpriteNode GetSpriteNode()
        {
            Debug.Assert(this.pBackSpriteNode != null);
            return this.pBackSpriteNode;
        }
        public void SetSpriteNode(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSpriteNode = pSpriteBatchNode;
        }

        // Data: -------------------------------------------

        // Keenan(delete.B)
        // If you remove a SpriteBase initiated by gameObject... 
        //     its hard to get the spriteBatchNode
        //     so have a back pointer to it
        private SpriteNode pBackSpriteNode;
    }
}
