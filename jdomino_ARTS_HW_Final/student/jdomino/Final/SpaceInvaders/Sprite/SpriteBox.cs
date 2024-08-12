using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBox : SpriteBase
    {
        /**********************
		* 
		* Constructor and Enum
		* 
		**********************/

        public enum Name
        {
            Box,
            Box1,
            Box2,

            Null_Object,

            Uninitialized
        }

        public SpriteBox()
        : base()   // <--- Delegate (kick the can)
        {
            this.name = SpriteBox.Name.Uninitialized;

            Debug.Assert(SpriteBox.psTmpRect != null);
            SpriteBox.psTmpRect.Set(0, 0, 1, 1);

            // Here is the actual new
            //LTN's - SpriteBox
            this.poLineColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poLineColor != null);

            // Here is the actual new
            //LTN's - SpriteBox
            this.poAzulSpriteBox = new Azul.SpriteBox(psTmpRect, this.poLineColor);
            Debug.Assert(this.poAzulSpriteBox != null);

            this.x = poAzulSpriteBox.x;
            this.y = poAzulSpriteBox.y;
            this.sx = poAzulSpriteBox.sx;
            this.sy = poAzulSpriteBox.sy;
            this.angle = poAzulSpriteBox.angle;
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/

        public void Set(SpriteBox.Name name, float x, float y, float width, float height, Azul.Color pLineColor)
        {
            Debug.Assert(this.poAzulSpriteBox != null);
            Debug.Assert(this.poLineColor != null);

            Debug.Assert(psTmpRect != null);
            SpriteBox.psTmpRect.Set(x, y, width, height);

            this.name = name;

            if (pLineColor == null)
            {
                this.poLineColor.Set(1, 1, 1);
            }
            else
            {
                this.poLineColor.Set(pLineColor);
            }

            this.poAzulSpriteBox.Swap(psTmpRect, this.poLineColor);

            this.x = poAzulSpriteBox.x;
            this.y = poAzulSpriteBox.y;
            this.sx = poAzulSpriteBox.sx;
            this.sy = poAzulSpriteBox.sy;
            this.angle = poAzulSpriteBox.angle;
        }

        public void Set(SpriteBox.Name name, float x, float y, float width, float height)
        {
            Debug.Assert(this.poAzulSpriteBox != null);
            Debug.Assert(this.poLineColor != null);

            Debug.Assert(psTmpRect != null);
            SpriteBox.psTmpRect.Set(x, y, width, height);

            this.name = name;

            this.poAzulSpriteBox.Swap(psTmpRect, this.poLineColor);

            this.x = poAzulSpriteBox.x;
            this.y = poAzulSpriteBox.y;
            this.sx = poAzulSpriteBox.sx;
            this.sy = poAzulSpriteBox.sy;
            this.angle = poAzulSpriteBox.angle;
        }

        public void SwapColor(Azul.Color _pColor)
        {
            Debug.Assert(_pColor != null);
            this.poAzulSpriteBox.SwapColor(_pColor);
        }

        public void SetColor(float red, float green, float blue, float alpha = 1.0f)
		{
            Debug.Assert(poLineColor != null);
            poLineColor.Set(red, green, blue, alpha);
            poAzulSpriteBox.SwapColor(poLineColor);
		}

        public void SetRect(float x, float y, float width, float height)
		{
            Set(this.name, x, y, width, height);
		}

        /**********************
        * 
        * Private Methods
        * 
        **********************/

        private void privClear()
        {
            this.name = SpriteBox.Name.Uninitialized;

            // NOTE:
            // Do not null the poAzulBoxSprite it is created once in Default then reused
            // Do not null the poLineColor it is created once in Default then reused

            this.poLineColor.Set(1, 1, 1);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }

        /**********************
		* 
		* Override Methods
		* 
		**********************/


        override public void Update()
        {
            this.poAzulSpriteBox.x = this.x;
            this.poAzulSpriteBox.y = this.y;
            this.poAzulSpriteBox.sx = this.sx;
            this.poAzulSpriteBox.sy = this.sy;
            this.poAzulSpriteBox.angle = this.angle;

            this.poAzulSpriteBox.Update();
        }

        override public void Render()
        {
            this.poAzulSpriteBox.Render();
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

            SpriteBox pDataB = (SpriteBox)pTarget;

            bool status = false;

            if (this.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            // Dump - Print contents to the debug output window
            //        Using HASH code as its unique identifier 
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("      Color(r,b,g): {0},{1},{2} ({3})", this.poLineColor.red, this.poLineColor.green, this.poLineColor.blue, this.poLineColor.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.poAzulSpriteBox.GetHashCode());
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
        public Azul.Color poLineColor;
        private Azul.SpriteBox poAzulSpriteBox;

        //Static to avoid unecessary news
        //LTN's - SpriteBox
        static private Azul.Rect psTmpRect = new Azul.Rect();

    }
}
