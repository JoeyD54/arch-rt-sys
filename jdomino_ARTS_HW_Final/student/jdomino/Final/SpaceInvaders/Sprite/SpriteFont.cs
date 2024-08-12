using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class SpriteFont : SpriteBase
	{
		/**********************
		* 
		* Constructor and Enum
		* 
		**********************/

		public enum Name
		{
			HotPink,

			AlienSquid,
			AlienCrab,
			AlienOctopus,

			Null_Object,
			Not_Initialized
		}

		public SpriteFont()
			:base()
		{
			poAzulSprite = new Azul.Sprite();
			poScreenRect = new Azul.Rect();
			poColor = new Azul.Color(1.0f, 1.0f, 1.0f);

			pMessage = null;
			glyphName = Glyph.Name.Uninitialized;

			x = 0.0f;
			y = 0.0f;
		}
		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Set(Font.Name name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
		{
			Debug.Assert(pMessage != null);
			this.pMessage = pMessage;

			this.x = xStart;
			this.y = yStart;

			this.name = name;

			// TODO: for wash... this should be a nullGlyph
			this.glyphName = glyphName;

			// Force color to white
			Debug.Assert(this.poColor != null);
			this.poColor.Set(1.0f, 1.0f, 1.0f);
		}


		public void SetColor(float red, float green, float blue, float alpha = 1.0f)
		{
			Debug.Assert(this.poColor != null);
			this.poColor.Set(red, green, blue, alpha);
		}

		public void UpdateMessage(String pMessage)
		{
			Debug.Assert(pMessage != null);
			this.pMessage = pMessage;
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/
		private void privClear()
		{
			Debug.Assert(poAzulSprite != null);
			Debug.Assert(poColor != null);
			Debug.Assert(poScreenRect != null);

			poScreenRect.Set(0, 0, 0, 0);
			poColor.Set(1.0f, 1.0f, 1.0f);

			pMessage = null;
			glyphName = Glyph.Name.Uninitialized;

			x = 0.0f;
			y = 0.0f;
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

			SpriteFont pDataB = (SpriteFont)pTarget;

			bool status = false;

			if (this.name == pDataB.name)
			{
				status = true;
			}

			return status;
		}

		override public void Update()
		{
			Debug.Assert(this.poAzulSprite != null);
		}

		override public void Render()
		{
			Debug.Assert(this.poAzulSprite != null);
			Debug.Assert(this.poColor != null);
			Debug.Assert(this.poScreenRect != null);
			Debug.Assert(this.pMessage != null);
			Debug.Assert(this.pMessage.Length > 0);

			float xTmp = this.x;
			float yTmp = this.y;

			float xEnd = this.x;

			for (int i = 0; i < this.pMessage.Length; i++)
			{
				int key = Convert.ToByte(pMessage[i]);

				Glyph pGlyph = GlyphMan.Find(this.glyphName, key);
				Debug.Assert(pGlyph != null);

				xTmp = xEnd + pGlyph.GetAzulRect().width / 2;
				this.poScreenRect.Set(xTmp, yTmp, pGlyph.GetAzulRect().width, pGlyph.GetAzulRect().height);

				poAzulSprite.Swap(pGlyph.GetAzulTexture(), pGlyph.GetAzulRect(), this.poScreenRect, this.poColor);

				poAzulSprite.Update();
				poAzulSprite.Render();

				// move the starting to the next character
				xEnd = pGlyph.GetAzulRect().width / 2 + xTmp;

			}
		}

		override public void Dump()
		{
			// we are using HASH code as its unique identifier 
			Debug.WriteLine("   {0} ({1})", this.name, this.GetHashCode());

			base.Dump();
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/
		public Font.Name name;
		private Azul.Sprite poAzulSprite;
		private Azul.Rect poScreenRect;
		private Azul.Color poColor;   // this color is multplied by the texture

		private string pMessage;
		public Glyph.Name glyphName;

		public float x;
		public float y;
	}
}
