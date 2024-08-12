using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class Font : DLink
	{
		/**********************
		* 
		* Constructor and Enum
		* 
		**********************/
		public enum Name
		{
			TestMessage,
			TestOneOff,
			LifeCount,
			CreditCount,
			Player1Score,
			Player2Score,
			Scoreboard,
			TimedCharacter,			
			HighScore,		
			
			GameOver,

			NullObject,
			Uninitialized
		}

		public Font()
		{
			name = Name.Uninitialized;
			poSpriteFont = new SpriteFont();
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public void Set(Font.Name name, string pMessage, Glyph.Name glyphName, float xStart, float yStart)
		{
			Debug.Assert(pMessage != null);

			this.name = name;
			this.poSpriteFont.Set(name, pMessage, glyphName, xStart, yStart);
		}


		public void UpdateMessage(string pMessage)
		{
			Debug.Assert(pMessage != null);
			Debug.Assert(this.poSpriteFont != null);
			this.poSpriteFont.UpdateMessage(pMessage);
		}

		public void SetColor(float red, float green, float blue)
		{
			this.poSpriteFont.SetColor(red, green, blue);
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private void privClear()
		{
			this.name = Name.Uninitialized;
			this.poSpriteFont.Set(Font.Name.NullObject, pNullString, Glyph.Name.Null_Object, 0.0f, 0.0f);
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

			Font pDataB = (Font)pTarget;

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

			base.Dump();
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public Name name;
		public SpriteFont poSpriteFont;
		static private string pNullString = "null";
	}
}
