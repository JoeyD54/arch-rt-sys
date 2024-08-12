using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	/*******************************
	 * 
	 * Sprite Batch
	 * 
	 * This class will act as a header for a node DLink 
	 *	of sprites. It will allow us to easily spawn multiple
	 *	sprites of the same type, but be able to be acted on
	 *	individually
	 * 
	 * ******************************/
    public class SpriteBatch : DLink
    {
        /**********************
		* 
		* Constructor and Enum
		* 
		**********************/

        public enum Name
        {
            PacMan,
            Aliens,
            AngryBirds,            
            Boxes,
            Shields,
            Player,
            BigBoomBooms,
            MainMenuAliens,
            Player1,
            Player2,

            Texts,
            UI,

            Uninitialized
        }

        public SpriteBatch()
            : base()
        {
            this.drawEnable = true;
            this.name = SpriteBatch.Name.Uninitialized;

            //LTN's - SpriteBatch
            this.poSpriteNodeMan = new SpriteNodeMan();
            Debug.Assert(this.poSpriteNodeMan != null);
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/

        public void Set(SpriteBatch.Name name, int inPriority, int reserveNum = 3, int reserveGrow = 1)
        {
            this.name = name;
            this.priority = inPriority;
            this.poSpriteNodeMan.Set(name, reserveNum, reserveGrow);
        }

        public void SetName(SpriteBatch.Name inName)
        {
            this.name = inName;
        }

        public SpriteNodeMan GetSBNodeMan()
        {
            return this.poSpriteNodeMan;
        }

        //public SpriteNode Attach(Sprite.Name name)
        //{
        //    SpriteNode pNode = this.pSpriteNodeMan.Attach(name);
        //    return pNode;
        //}

  //      public SpriteNode Attach(SpriteProxy pNode)
		//{
  //          SpriteNode pSBNode = pSpriteNodeMan.Attach(pNode);
  //          return pSBNode;
		//}

  //      public SpriteNode Attach(SpriteBox.Name name)
  //      {
  //          SpriteNode pNode = this.pSpriteNodeMan.Attach(name);
  //          return pNode;
  //      }
  //      public SpriteNode Attach(SpriteBox pNode)
  //      {
  //          SpriteNode pSBNode = this.pSpriteNodeMan.Attach(pNode);
  //          return pSBNode;
  //      }

        public SpriteNode Attach(SpriteBase _pNode)
		{
            SpriteNode pNode = this.poSpriteNodeMan.Attach(_pNode);

            // Initialize SpriteBatchNode
            pNode.Set(_pNode, this.poSpriteNodeMan);

            // Back pointer
            this.poSpriteNodeMan.SetSpriteBatch(this);

            return pNode;
        }

        public SpriteNode Attach(GameObject pGameObject)
		{
            Debug.Assert(pGameObject != null);
            SpriteNode pNode = this.poSpriteNodeMan.Attach(pGameObject.pSpriteProxy);


            // Initialize SpriteBatchNode
            pNode.Set(pGameObject.pSpriteProxy, this.poSpriteNodeMan);

            // Back pointer
            this.poSpriteNodeMan.SetSpriteBatch(this);

            return pNode;
        }

        public int GetPriority()
		{
            return priority;
		}

        public void SetDrawEnable(bool status)
        {
            this.drawEnable = status;
        }
        public bool GetDrawEnable()
        {
            return this.drawEnable;
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/


        private void privClear()
        {

        }

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

		override public bool Compare(NodeBase pTargetNode)
		{
            Debug.Assert(pTargetNode != null);

            SpriteBatch pData = (SpriteBatch)pTargetNode;

            bool status = false;

            if(name == pData.name)
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
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());

            base.Dump();
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        private bool drawEnable;
        public SpriteBatch.Name name;
        public int priority = 0;
        private readonly SpriteNodeMan poSpriteNodeMan;
    }
}
