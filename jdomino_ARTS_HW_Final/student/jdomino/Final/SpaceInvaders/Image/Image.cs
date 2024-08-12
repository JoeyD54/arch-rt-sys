using System.Diagnostics;

namespace SpaceInvaders
{
    public class Image : DLink
    {
        /**********************
		* 
		* Constructor and Enum
		* 
		**********************/

        public enum Name
        {
            HotPink,

            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,

            AlienUFO,            
            AlienSquid,
            AlienSquid2,
            AlienCrabUp,
            AlienCrabDown,
            AlienOctopusClosed,
            AlienOctopusOpen,

            AlienLogo,
            AlienRed,
            AlienGreen,
            AlienWhiteUp,
            AlienWhiteDown,
            AlienGroup,
            AlienDead,
            AlienUFODead,

            Wall,
            Missile,
            Missile2,
            MissileExplosion,
            Ship,
            ShipDead1,
            ShipDead2,

            BombStraight,
            BombStraight1,
            BombStraight2,
            BombStraight3,
            BombZigZag,
            BombZigZag1,
            BombZigZag2,
            BombZigZag3,
            BombDagger,
            BombDagger1,
            BombDagger2,
            BombDagger3,
            BombExplosion,

            Brick,
            BrickLeft_Top0,
            BrickLeft_Top1,
            BrickLeft_Bottom,
            BrickRight_Top0,
            BrickRight_Top1,
            BrickRight_Bottom,
            BrickRight_BottomHalfVert,
            BrickLeft_BottomHalfVert,

            Uninitialized
        }

        public Image()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;

            //LTN - Image
            this.poRect = new Azul.Rect();
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/


        public void Set(Name name, Texture pSrcTexture, float x, float y, float width, float height)
        {
            Debug.Assert(pSrcTexture != null);
            Debug.Assert(poRect != null);
            this.pTexture = pSrcTexture;
            this.poRect.Set(x, y, width, height);
            this.name = name;
        }
        public Azul.Texture GetAzulTexture()
        {
            return this.pTexture.GetAzulTexture();
        }

        public Azul.Rect GetAzulRect()
		{
            return poRect;
		}

        /**********************
		* 
		* Private Methods
		* 
		**********************/


        private void privClear()
        {
            Debug.Assert(this.poRect != null);
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.poRect.Clear();
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

        override public bool Compare(NodeBase pTarget)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(pTarget != null);

            Image pDataB = (Image)pTarget;

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
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("      Rect: [{0} {1} {2} {3}] ", this.poRect.x, this.poRect.y, this.poRect.width, this.poRect.height);

            base.Dump();
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        public Name name;
        public Azul.Rect poRect;
        public Texture pTexture;
    }
}

// --- End of File ---

