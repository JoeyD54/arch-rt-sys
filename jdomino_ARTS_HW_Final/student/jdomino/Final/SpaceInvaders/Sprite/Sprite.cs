using System.Diagnostics;

namespace SpaceInvaders
{
    public class Sprite : SpriteBase
    {
        /**********************
		* 
		* Constructor and Enum
		* 
		**********************/

        public enum Name
        {
            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            RedGhost,
            PinkGhost,
            BlueGhost,
            OrangeGhost,

            AlienCrabUp,
            AlienCrabDown,
            AlienSquid,
            AlienSquid2,
            AlienOctopusClosed,
            AlienOctopusOpen,
            AlienDead,

            AlienUFO,
            AlienUFODead,

            AlienOctopus,
            AlienCrab,

            Ship,
            ShipLife1,
            ShipLife2,
            Wall,
            Missile,
            Missile2,
            MissileExplosion,

            BombStraight,
            BombZigZag,
            BombDagger,
            BombExplosion,

            Brick,
            Brick_LeftTop1,
            Brick_LeftTop0,
            Brick_LeftBottom,
            Brick_LeftBottomHalfVert,
            Brick_RightTop1,
            Brick_RightTop0,
            Brick_RightBottom,
            Brick_RightBottomHalfVert,

            Null_Object,
            Uninitialized
        }


        public Sprite()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

            this.name = Name.Uninitialized;
            this.pImage = null;

            //LTN's - Sprite
            this.poColor = new Azul.Color();
            Debug.Assert(this.poColor != null);

            //LTN's - Sprite
            this.poAzulSprite = new Azul.Sprite();
            Debug.Assert(this.poAzulSprite != null);

            // Temp instead of dynamically calling each time
            //LTN's - Sprite
            this.poRect = new Azul.Rect();
            Debug.Assert(this.poRect != null);

        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/


        public void Set(Name name, Image pImage, float x, float y, float width, float height, Azul.Color pColor)
        {
            Debug.Assert(pImage != null);
            Debug.Assert(poRect != null);
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(this.poColor != null);

            this.pImage = pImage;
            this.name = name;

            this.poRect.Set(x, y, width, height);

            if (pColor == null)
            {
                this.poColor.Set(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                // use the one passed in
                this.poColor.Set(pColor);
            }

            this.poAzulSprite.Swap(pImage.pTexture.poAzulTexture, pImage.poRect, poRect, poColor);
            this.poAzulSprite.Update();

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
		{
            Debug.Assert(poColor != null);
            Debug.Assert(poAzulSprite != null);

            poColor.Set(red, green, blue, alpha);
            poAzulSprite.SwapColor(poColor);
		}

        public void SwapColor(Azul.Color _pColor)
		{
            Debug.Assert(poColor != null);
            Debug.Assert(poAzulSprite != null);
            Debug.Assert(_pColor != null);

            poColor.Set(_pColor);
            poAzulSprite.SwapColor(_pColor);
            
        }

        public void SwapImage(Image pNewImage)
		{
            Debug.Assert(poAzulSprite != null);
            Debug.Assert(pNewImage != null);
            pImage = pNewImage;

            poAzulSprite.SwapTexture(pImage.GetAzulTexture());
            poAzulSprite.SwapTextureRect(pImage.GetAzulRect());
		}

        public Azul.Rect GetRect()
        {
            Debug.Assert(this.poRect != null);
            return this.poRect;

        }



        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private void privClear()
        {
            Debug.Assert(this.poColor != null);
            Debug.Assert(this.poAzulSprite != null);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

            this.name = Name.Uninitialized;
            this.pImage = null;

            this.poColor.Set(1.0f, 1.0f, 1.0f, 1.0f);

            Image pImage = ImageMan.Find(Image.Name.HotPink);
            Debug.Assert(pImage != null);

            this.poRect.Set(0.0f, 0.0f, 1.0f, 1.0f);
            this.poAzulSprite.Swap(pImage.GetAzulTexture(), pImage.poRect, poRect, poColor);
            this.poAzulSprite.Update();

        }

        /**********************
		* 
		* Override Methods
		* 
		**********************/

        override public void Update()
        {
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;

            this.poAzulSprite.Update();
        }

        override public void Render()
        {
            this.poAzulSprite.Render();
        }

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

            Sprite pDataB = (Sprite)pTarget;

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
            Debug.WriteLine("             Image: {0} ({1})", this.pImage.name, this.pImage.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.poAzulSprite.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("           (angle): {0}", this.angle);

            base.Dump();
        }

        /**********************
		* 
		* Local Variables
		* 
		**********************/

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        public Name name;
        public Image pImage;
        public Azul.Color poColor;
        private Azul.Sprite poAzulSprite;
        private Azul.Rect poRect;

    }
}

// --- End of File ---

