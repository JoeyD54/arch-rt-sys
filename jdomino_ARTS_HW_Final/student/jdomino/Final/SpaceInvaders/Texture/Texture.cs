using System.Diagnostics;

namespace SpaceInvaders
{
    public class Texture : DLink
    {

        /**********************
		* 
		* Constructor and Enum
		* 
		**********************/

        public enum Name
        {
            HotPink,

            Aliens,
            Birds,
            PacMan,

            Ship,       
            Missile,

            Shields,
            Bombs,

            Consolas36pt,
            Consolas20pt,

            Uninitialized
        }

        public Texture()
        {
            // Do the create and load
            //LTN's - Texture
            this.poAzulTexture = new Azul.Texture();
            Debug.Assert(this.poAzulTexture != null);

            this.name = Texture.Name.Uninitialized;
        }


        /**********************
		* 
		* Public Methods
		* 
		**********************/

        public void Set(Name name, string pTextureName)
        {
            Debug.Assert(pTextureName != null);
            this.poAzulTexture.Set(pTextureName, Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            this.name = name;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.poAzulTexture;
        }


        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private void privClear()
        {
            // Clear with a default texture
            Debug.Assert(this.poAzulTexture != null);
            this.poAzulTexture.Set("HotPink.tga", Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);

            this.name = Name.Uninitialized;
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

            Texture pDataB = (Texture)pTarget;

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
            Debug.WriteLine("      poAzulTexture: {0} ", this.poAzulTexture.GetHashCode());

            base.Dump();
        }


        /**********************
        * 
        * Local Variables
        * 
        **********************/

        public Name name;
        public Azul.Texture poAzulTexture;
    }
}
// --- End of File ---

