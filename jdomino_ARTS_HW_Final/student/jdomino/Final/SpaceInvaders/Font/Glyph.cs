using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class Glyph : DLink
	{
		/**********************
		* 
		* Constructor and Enum
		* 
		**********************/
		public enum Name
		{
			Consolas36pt,
			Consolas20pt,

			Null_Object,
			Uninitialized
		}

		public Glyph()
			: base()
		{
			this.name = Name.Uninitialized;
			this.pTexture = null;
			this.poSubRect = new Azul.Rect();
			this.key = 0;
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/
		public void Set(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
		{
			Debug.Assert(this.poSubRect != null);
			this.name = name;

			this.pTexture = TextureMan.Find(textName);
			Debug.Assert(this.pTexture != null);

			this.poSubRect.Set(x, y, width, height);

			this.key = key;

		}

		public Azul.Rect GetAzulRect()
		{
			Debug.Assert(this.poSubRect != null);
			return this.poSubRect;
		}

		public Azul.Texture GetAzulTexture()
		{
			Debug.Assert(this.pTexture != null);
			return this.pTexture.GetAzulTexture();
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private void privClear()
		{
			this.name = Name.Uninitialized;
			this.pTexture = null;
			this.poSubRect.Set(0, 0, 1, 1);
			this.key = 0;
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

			Glyph pDataB = (Glyph)pTarget;

			bool status = false;

			if (this.name == pDataB.name && this.key == pDataB.key)
			{
				status = true;
			}

			return status;
		}

		override public void Dump()
		{
			Debug.WriteLine("\t\tname: {0} ({1})", this.name, this.GetHashCode());
			Debug.WriteLine("\t\t\tkey: {0}", this.key);
			if (this.pTexture != null)
			{
				Debug.WriteLine("\t\t   pTexture: {0}", this.pTexture.GetName());
			}
			else
			{
				Debug.WriteLine("\t\t   pTexture: null");
			}
			Debug.WriteLine("\t\t      pRect: {0}, {1}, {2}, {3}", this.poSubRect.x, this.poSubRect.y, this.poSubRect.width, this.poSubRect.height);

			base.Dump();
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/
		public Name name;
		public int key;
		private Azul.Rect poSubRect;
		private Texture pTexture;
	}
}
