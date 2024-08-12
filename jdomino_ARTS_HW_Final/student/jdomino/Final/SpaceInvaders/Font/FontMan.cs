using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class FontMan : ManBase
	{
		/**********************
		* 
		* Constructor and Create
		* 
		**********************/

		public FontMan(int reserveNum = 3, int reserveGrow = 1)
				: base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
		{
			// initialize derived data here
			//this.poNodeCompare = new Font();
			FontMan.psActiveFontMan = null;
		}

		public static void Create()
		{
			// initialize the singleton here
			Debug.Assert(pInstance == null);

			// Do the initialization
			if (pInstance == null)
			{
				pInstance = new FontMan();
			}
		}
		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public static void Destroy()
		{
		}

		public static Font Add(Font.Name name, SpriteBatch.Name SB_Name, string pMessage, Glyph.Name glyphName, float xStart, float yStart)
		{
			FontMan pMan = FontMan.psActiveFontMan;

			Font pNode = (Font)pMan.baseAddToFront();
			Debug.Assert(pNode != null);

			pNode.Set(name, pMessage, glyphName, xStart, yStart);

			// Add to sprite batch
			SpriteBatch pSB = SpriteBatchMan.Find(SB_Name);
			Debug.Assert(pSB != null);
			Debug.Assert(pNode.poSpriteFont != null);
			pSB.Attach(pNode.poSpriteFont);

			return pNode;
		}

		public static void SetActive(FontMan pFontMan)
		{
			FontMan pMan = FontMan.privGetInstance();
			Debug.Assert(pMan != null);

			Debug.Assert(pFontMan != null);
			FontMan.psActiveFontMan = pFontMan;
		}

		public static void AddXml(Glyph.Name glyphName, string assetName, Texture.Name textName)
		{
			GlyphMan.AddXml(glyphName, assetName, textName);
		}

		public static Font Find(Font.Name name)
		{
			FontMan pMan = FontMan.psActiveFontMan;

			// Compare functions only compares two Nodes

			// So:  Use the Compare Node - as a reference
			//      use in the Compare() function
			FontMan.poNodeCompare.name = name;

			Font pData = (Font)pMan.baseFind(FontMan.poNodeCompare);
			return pData;
		}

		public static void Remove(Font pNode)
		{
			Debug.Assert(pNode != null);

			FontMan pMan = FontMan.psActiveFontMan;


			SpriteNode pSpriteNode = pNode.poSpriteFont.GetSpriteNode();
			Debug.Assert(pSpriteNode != null);
			SpriteBatchMan.Remove(pSpriteNode);

			pMan.baseRemove(pNode);
		}
		public static void RemoveAll()
		{
			// Get the instance
			FontMan pMan = FontMan.psActiveFontMan;

			// walk through the list and execute
			Iterator pIt = pMan.baseGetIterator();
			Debug.Assert(pIt != null);

			Font pNode = (Font)pIt.First();
			Font pNextNode = null;

			while (!pIt.IsDone())
			{
				pNextNode = (Font)pIt.Next();

				// remove from list
				pMan.baseRemove(pNode);

				// advance the pointer
				pNode = pNextNode;
			}
		}

		public static void Dump()
		{
			FontMan pMan = FontMan.psActiveFontMan;
			pMan.baseDump();
		}




		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private static FontMan privGetInstance()
		{
			// Safety - this forces users to call Create() first before using class
			Debug.Assert(pInstance != null);

			return pInstance;
		}

		/**********************
		* 
		* Override Methods
		* 
		**********************/

		override protected NodeBase DerivedCreateNode()
		{
			NodeBase pNodeBase = new Font();
			Debug.Assert(pNodeBase != null);

			return pNodeBase;
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		private static FontMan pInstance = null;
		private static FontMan psActiveFontMan = null;
		private static Font poNodeCompare = new Font();


	}
}
