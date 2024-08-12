using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class SLinkMan : ListBase
	{
		/**********************
		* 
		* Constructor
		* 
		**********************/

		public SLinkMan()
			:base()
		{
			//LTN's - SLinkMan
			poIterator = new SLinkIterator();
			poHead = null;
		}

		/**********************
		* 
		* Overrides
		* 
		**********************/
		public override void AddToFront(NodeBase _pNode)
		{
			Debug.Assert(_pNode != null);

			SLink pNode = (SLink)_pNode;

			//Add node as head if empty
			if(poHead == null)
			{
				poHead = pNode;
				pNode.pNext = null;
			}
			else
			{
				pNode.pNext = poHead;
				poHead = pNode;
			}

			Debug.Assert(poHead != null);
		}

		public override void AddToEnd(NodeBase _pNode)
		{
			Debug.Assert(_pNode != null);

			SLink pNode = (SLink)_pNode;

			//Add node as head if empty
			if (poHead == null)
			{
				poHead = pNode;
				pNode.pNext = null;
			}
			else
			{
				SLink pCurr = poHead;

				//Get to last node
				while(pCurr.pNext != null)
				{
					pCurr = pCurr.pNext;
				}

				pCurr.pNext = pNode;
				pNode.pNext = null;
			}

			Debug.Assert(poHead != null);
		}

		//This currently functions like AddToEnd
		public override void AddByPriority(NodeBase _pNode, int priority)
		{
			Debug.Assert(_pNode != null);

			SLink pNode = (SLink)_pNode;

			//Add node as head if empty
			if (poHead == null)
			{
				poHead = pNode;
				pNode.pNext = null;
			}
			else
			{
				SLink pCurr = poHead;
				//bool nodeStored = false;

				//Get to last node
				while (pCurr.pNext != null)
				{
					//Fill this out later
					pCurr = pCurr.pNext;
				}

				pCurr.pNext = pNode;
				pNode.pNext = null;
			}

			Debug.Assert(poHead != null);
		}

		public override void AddByTimeToTrig(NodeBase _pNode, float timeToTrigger)
		{
			Debug.Assert(_pNode != null);

			SLink pNode = (SLink)_pNode;

			//Add node as head if empty
			if (poHead == null)
			{
				poHead = pNode;
				pNode.pNext = null;
			}
			else
			{
				SLink pCurr = poHead;
				//bool nodeStored = false;

				//TimerEvent TE = (TimerEvent)pCurr;

				//Get to last node
				while (pCurr.pNext != null)
				{
					//Fill this out later
					pCurr = pCurr.pNext;
				}

				pCurr.pNext = pNode;
				pNode.pNext = null;
			}

			Debug.Assert(poHead != null);
		}

		public override NodeBase RemoveFromFront()
		{
			Debug.Assert(poHead != null);

			SLink pNode = poHead;

			poHead = poHead.pNext;

			pNode.Clear();

			return pNode;
		}

		public override void Remove(NodeBase _pNode)
		{
			Debug.Assert(_pNode != null);
			Debug.Assert(poHead != null);

			SLink pNode = (SLink)_pNode;
			SLink pCurr = poHead;

			if(pNode == poHead)
			{
				poHead = pNode.pNext;
			}
			else
			{
				while(pCurr.pNext != null)
				{
					//Next node is what we want,
					//ignore it from the list
					if(pCurr.pNext == pNode)
					{
						pCurr.pNext = pNode.pNext;
						break;
					}
				}
			}


			
		}

		public override Iterator GetIterator()
		{
			poIterator.Reset(poHead);
			return poIterator;
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/

		public SLinkIterator poIterator;
		public SLink poHead;
	}
}
