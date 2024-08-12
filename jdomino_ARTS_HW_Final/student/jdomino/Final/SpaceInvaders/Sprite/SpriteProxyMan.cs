using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class SpriteProxyMan : ManBase
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		//LTN's - ManBase (the 2 DLinkMan's)
		private SpriteProxyMan(int reserveNum = 3, int reserveGrow = 1)
			: base (new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)
		{
			//LTN's - SpriteProxyMan
			poNodeCompare = new SpriteProxy();
			poNodeCompare.pSprite = SpriteMan.Find(Sprite.Name.Null_Object);
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/

		public static void Create(int reserveNum = 3, int reserveGrow = 1)
		{
			Debug.Assert(reserveNum > 0);
			Debug.Assert(reserveGrow > 0);

			Debug.Assert(pInstance == null);

			if (pInstance == null)
			{
				//LTN's - SpriteProxyMan
				pInstance = new SpriteProxyMan(reserveNum, reserveGrow);
			}

			SpriteProxyMan.Add(Sprite.Name.Null_Object);
		}

		public static void Destroy()
		{
			//SpriteProxyMan pMan = SpriteProxyMan.privGetInstance();
			//Debug.Assert(pMan != null);

			// Do something clever here
			// track peak number of active nodes
			// print stats on destroy
			// invalidate the singleton
		}

		public static SpriteProxy Add(Sprite.Name _name)
		{
			SpriteProxyMan pMan = SpriteProxyMan.privGetInstance();
			Debug.Assert(pMan != null);

			SpriteProxy pNode = (SpriteProxy)pMan.baseAddToFront();
			Debug.Assert(pNode != null);

			pNode.Set(_name);

			return pNode;
		}

		public static void Remove(SpriteProxy pNode)
		{
			Debug.Assert(pNode != null);

			SpriteProxyMan pMan = SpriteProxyMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseRemove(pNode);
		}


		public static SpriteProxy Find(Sprite.Name name)
		{
			SpriteProxyMan pMan = SpriteProxyMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.poNodeCompare.pSprite.name = name;

			SpriteProxy pData = (SpriteProxy)pMan.baseFind(pMan.poNodeCompare);
			return pData;
		}

		public static void Dump()
		{
			SpriteProxyMan pMan = SpriteProxyMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseDump();
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private static SpriteProxyMan privGetInstance()
		{
			Debug.Assert(pInstance != null);

			return pInstance;
		}

		/**********************
		* 
		* Orverride Methods
		* 
		**********************/

		protected override NodeBase DerivedCreateNode()
		{
			//LTN's - SpriteProxyMan
			NodeBase pNodeBase = new SpriteProxy();
			Debug.Assert(pNodeBase != null);

			return pNodeBase;
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		private readonly SpriteProxy poNodeCompare;
		private static SpriteProxyMan pInstance = null;
	}
}
