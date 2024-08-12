using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class IteratorReverseComposite : IteratorCompositeBase
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		public IteratorReverseComposite(Component pStart)
		{
			Debug.Assert(pStart != null);
			Debug.Assert(pStart.containerType == Component.Container.Composite);

			IteratorForwardComposite pForward = new IteratorForwardComposite(pStart);

			pRoot = pStart;
			pCurr = pRoot;
			pPrev = null;

			Component pPrevNode = pRoot;

			Component pNode = pForward.First();

			while(!pForward.IsDone())
			{
				pPrevNode = pNode;

				pNode = pForward.Next();

				if(pNode != null)
				{
					pNode.pReverse = pPrevNode;
				}
			}

			pRoot.pReverse = pPrevNode;
		}

		/**********************
		* 
		* Public Methods
		* 
		**********************/
		/**********************
		* 
		* Private Methods
		* 
		**********************/
		/**********************
		* 
		* Override Methods
		* 
		**********************/

		override public Component First()
		{
			Debug.Assert(this.pRoot != null);

			this.pCurr = this.pRoot.pReverse;

			return this.pCurr;
		}
		override public Component Curr()
		{
			return this.pCurr;
		}
		override public Component Next()
		{
			Debug.Assert(this.pCurr != null);

			this.pPrev = this.pCurr;
			this.pCurr = this.pCurr.pReverse;
			return this.pCurr;
		}

		override public bool IsDone()
		{
			return (this.pPrev == this.pRoot);
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/
		private Component pRoot;
		private Component pCurr;
		private Component pPrev;
	}
}
