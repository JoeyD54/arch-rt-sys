using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class IteratorForwardComposite : IteratorCompositeBase
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/
		public IteratorForwardComposite(Component _startRoot)
		{
			Debug.Assert(_startRoot != null);
			Debug.Assert(_startRoot.containerType == Component.Container.Composite);

			pCurr = _startRoot;
			pRoot = _startRoot;
		}
		/**********************
		* 
		* Public Methods
		* 
		**********************/

		static public Component GetParent(Component pNode)
		{
			Debug.Assert(pNode != null);

			return pNode.pParent;
		}

		static public Component GetChild(Component pNode)
		{
			Debug.Assert(pNode != null);

			Component pChild = null;

			if(pNode.containerType == Component.Container.Composite)
			{
				pChild = ((Composite)pNode).GetHead();
			}

			return pChild;
		}

		static public Component GetSibling(Component pNode)
		{
			Debug.Assert(pNode != null);

			return (Component)pNode.pNext;
		}


		/**********************
		* 
		* Private Methods
		* 
		**********************/

		private Component privNextStep(Component pNode, Component pParent, Component pChild, Component pSibling)
		{
			//Debug.Assert(pNode != null);
			//Debug.Assert(pChild != null);
			//Debug.Assert(pParent != null);
			//Debug.Assert(pSibling != null);
			pNode = null;

			if (pChild != null)
			{
				pNode = pChild;
			}
			else
			{
				//No child, check sibling
				if (pSibling != null)
				{
					pNode = pSibling;
				}
				else
				{
					//No siblings or children
					//Find parent
					while(pParent != null)
					{
						pNode = GetSibling(pParent);

						if(pNode != null)
						{
							//found a parent. GTFO
							break;
						}
						else
						{
							//Find next parent
							pParent = GetParent(pParent);
						}
					}
				}
			}

			return pNode;
		}
		/**********************
		* 
		* Override Methods
		* 
		**********************/

		override public Component First()
		{
			Debug.Assert(this.pRoot != null);
			Component pNode = this.pRoot;

			Debug.Assert(pNode != null);
			this.pCurr = pNode;

			return this.pCurr;
		}

		override public Component Curr()
		{
			return this.pCurr;
		}

		override public Component Next()
		{
			Debug.Assert(this.pCurr != null);

			Component pNode = this.pCurr;

			Component pChild = GetChild(pNode);
			Component pSibling = GetSibling(pNode);
			Component pParent = GetParent(pNode);

			pNode = this.privNextStep(pNode, pParent, pChild, pSibling);

			this.pCurr = pNode;

			return this.pCurr;
		}

		override public bool IsDone()
		{
			return (this.pCurr == null);
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		private Component pCurr;
		private Component pRoot;
	}
}
