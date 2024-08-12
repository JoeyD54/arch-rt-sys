using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class ColPairMan : ManBase
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		private ColPairMan(int reserveNum = 3, int reserveGrow = 1)
			: base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)
		{
			pActiveColPair = null;
			poNodeCompare = new ColPair();
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

			if(pInstance == null)
			{
				pInstance = new ColPairMan(reserveNum, reserveGrow);
			}
		}

		public static void Destroy()
		{
			ColPairMan pMan = ColPairMan.privGetInstance();
			Debug.Assert(pMan != null);
		}

		public static ColPair Add(ColPair.Name colPairName, GameObject treeRootA, GameObject treeRootB)
		{
			// Get the instance
			ColPairMan pMan = ColPairMan.privGetInstance();
			Debug.Assert(pMan != null);

			// Go to Man, get a node from reserve, add to active, return it
			ColPair pColPair = (ColPair)pMan.baseAddToFront();
			Debug.Assert(pColPair != null);

			// Initialize Image
			pColPair.Set(colPairName, treeRootA, treeRootB);

			return pColPair;
		}

		public static void Process()
		{
			// get the singleton
			ColPairMan pMan = ColPairMan.privGetInstance();

			// walk through the list and render
			Iterator pIt = pMan.baseGetIterator();
			Debug.Assert(pIt != null);

			ColPair pNode = (ColPair)pIt.First();

			// Walk through the nodes
			while (!pIt.IsDone())
			{
				// set the current active  <--- Key concept: set this before
				pMan.pActiveColPair = pNode;

				// Update the node
				Debug.Assert(pNode != null);

				pNode.Process();

				pNode = (ColPair)pIt.Next();
			}

		}

		public static ColPair GetActiveColPair()
		{
			// get the singleton
			ColPairMan pMan = ColPairMan.privGetInstance();

			return pMan.pActiveColPair;
		}

		public static ColPair Find(ColPair.Name name)
		{
			ColPairMan pMan = ColPairMan.privGetInstance();
			Debug.Assert(pMan != null);

			// Compare functions only compares two Nodes

			// So:  Use the Compare Node - as a reference
			//      use in the Compare() function
			pMan.poNodeCompare.name = name;

			ColPair pData = (ColPair)pMan.baseFind(pMan.poNodeCompare);
			return pData;
		}

		public static void Remove(ColPair pNode)
		{
			Debug.Assert(pNode != null);

			ColPairMan pMan = ColPairMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseRemove(pNode);
		}

		public static void Dump()
		{
			ColPairMan pMan = ColPairMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseDump();
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private static ColPairMan privGetInstance()
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
			NodeBase pNodeBase = new ColPair();
			Debug.Assert(pNodeBase != null);

			return pNodeBase;
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		private readonly ColPair poNodeCompare;
		private static ColPairMan pInstance = null;
		private ColPair pActiveColPair;
	}
}
