using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class SLinkIterator : Iterator
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		public SLinkIterator()
			: base()
		{
			this.privClear();
		}

		/**********************
		* 
		* Public methods
		* 
		**********************/

		public void Reset(SLink _pHead)
		{
			if(_pHead == null)
			{
				privClear();
			}
			else
			{
				pHead = _pHead;
				pCurr = _pHead;
				bDone = false;
			}
		}

		/**********************
		* 
		* Private methods
		* 
		**********************/

		private void privClear()
		{
			pHead = null;
			pCurr = null;
			bDone = true;
		}

		/**********************
		* 
		* Override methods
		* 
		**********************/

		public override NodeBase Curr()
		{
			NodeBase pNode = pCurr;
			return pNode;
		}

		public override NodeBase Next()
		{
			SLink pSLink = (SLink)pCurr;

			if(pSLink != null)
			{
				pSLink = pSLink.pNext;
			}

			if(pSLink == null)
			{
				bDone = true;
			}
			else
			{
				bDone = false;
			}

			pCurr = (NodeBase)pSLink;

			return pSLink;
		}

		public override bool IsDone()
		{
			return bDone;
		}

		public override NodeBase First()
		{
			if(pHead != null)
			{
				bDone = false;
				pCurr = pHead;
			}
			else
			{
				privClear();
			}

			return pCurr;
		}

		public NodeBase pHead;
		public NodeBase pCurr;
		public bool bDone;
	}
}
