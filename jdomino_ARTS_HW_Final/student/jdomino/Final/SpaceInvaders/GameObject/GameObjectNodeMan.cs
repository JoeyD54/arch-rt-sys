using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class GameObjectNodeMan : ManBase
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/
		//LTN- ManBase (the 2 DLinkMan's)
		private GameObjectNodeMan(int reserveNum = 3, int reserveGrow = 1)
			: base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)
		{
			//LTN - GameObjectNodeMan
			poNodeCompare = new GameObjectNode();

			//LTN - GameObjectNodeMan
			poGameObject = new GameObjectNull();
			poNodeCompare.pGameObject = this.poGameObject;
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
				//LTN - GameObjectNodeMan
				pInstance = new GameObjectNodeMan(reserveNum, reserveGrow);
			}
		}

		public static void Destroy()
		{
			//track peak number of nodes
			//print stats on destroy
			//Invalidate singleton (make null?)
		}

		public static GameObjectNode Attach(GameObject _gameObject)
		{
			GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
			Debug.Assert(pMan != null);

			GameObjectNode pNode = (GameObjectNode)pMan.baseAddToFront();
			Debug.Assert(pNode != null);

			pNode.Set(_gameObject);

			return pNode;
		}

		public static GameObject Find(GameObject.Name _name)
		{
			GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
			Debug.Assert(pMan != null);

			// Compare functions only compares two Nodes

			// So:  Use the Compare Node - as a reference
			//      use in the Compare() function
			Debug.Assert(pMan.poNodeCompare.pGameObject != null);

			pMan.poNodeCompare.pGameObject.name = _name;

			GameObjectNode pData = (GameObjectNode)pMan.baseFind(pMan.poNodeCompare);
			//Debug.Assert(pData != null);
			// OK to be null

			GameObject pObj = null;

			if (pData != null)
			{
				pObj = pData.pGameObject;
			}

			return pObj;
		}

		public static void Update()
		{
			GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
			Debug.Assert(pMan != null);

			// Debug.WriteLine("---------------");

			Iterator pIt = pMan.baseGetIterator();
			GameObjectNode pGameObjectNode = (GameObjectNode)pIt.First();

			while (!pIt.IsDone())
			{
				IteratorReverseComposite pRev = new IteratorReverseComposite(pGameObjectNode.pGameObject);

				Component pNode = pRev.First();
				while (!pRev.IsDone())
				{
					GameObject pGameObj = (GameObject)pNode;

					//Debug.WriteLine("update: {0} ({1})", pGameObj, pGameObj.GetHashCode());
					pGameObj.Update();

					pNode = pRev.Next();
				}

				pGameObjectNode = (GameObjectNode)pIt.Next();
			}
		}

		public static void Remove(GameObjectNode pNode)
		{
			Debug.Assert(pNode != null);

			GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseRemove(pNode);
		}

		public static void Remove(GameObject pNode)
		{
			// Keenan(delete.E)
			Debug.Assert(pNode != null);
			GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();

			GameObject pSafetyNode = pNode;

			// OK so we have a linked list of trees (Remember that)

			// 1) find the tree root (we already know its the most parent)

			 GameObject pTmp = pNode;
			 GameObject pRoot = null;
			while (pTmp != null)
			{
				pRoot = pTmp;
				pTmp = (GameObject)IteratorForwardComposite.GetParent(pTmp);
			}

			// 2) pRoot is the tree we are looking for
			// now walk the active list looking for pRoot

			Iterator pIt = pMan.baseGetIterator();
			GameObjectNode pTree = (GameObjectNode)pIt.First();

			while (!pIt.IsDone())
			{
				if (pTree.pGameObject == pRoot)
				{
					// found it
					break;
				}
				pTree = (GameObjectNode)pIt.Next();
			}

			// 3) pTree is the tree that holds pNode
			//  Now remove the node from that tree

			Debug.Assert(pTree != null);
			Debug.Assert(pTree.pGameObject != null);

			// Is pTree.poGameObj same as the node we are trying to delete?
			// Answer: should be no... since we always have a group (that was a good idea)

			Debug.Assert(pTree.pGameObject != pNode);

			GameObject pParent = (GameObject)IteratorForwardComposite.GetParent(pNode);
			Debug.Assert(pParent != null);

			// Make sure there is no child before the delete
			GameObject pChild = (GameObject)IteratorForwardComposite.GetChild(pNode);
			Debug.Assert(pChild == null);

			// remove the node
			Debug.WriteLine("Removing {0} node from {1} parent", pNode, pParent);
			pParent.Remove(pNode);

			// FOUND the bug!!!!
			pParent.Update();

		}

		public static void Dump()
		{
			GameObjectNodeMan pMan = GameObjectNodeMan.privGetInstance();
			Debug.Assert(pMan != null);

			pMan.baseDump();
		}

		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private static GameObjectNodeMan privGetInstance()
		{
			Debug.Assert(pInstance != null);

			return pInstance;
		}
		/**********************
		* 
		* Override Methods
		* 
		**********************/

		protected override NodeBase DerivedCreateNode()
		{
			//LTN - GameObjectNodeMan
			NodeBase pNodeBase = new GameObjectNode();
			Debug.Assert(pNodeBase != null);

			return pNodeBase;
		}
		/**********************
		* 
		* Local Variables
		* 
		**********************/

		private readonly GameObjectNode poNodeCompare;
		private readonly GameObjectNull poGameObject;
		private static GameObjectNodeMan pInstance = null;
	}
}
