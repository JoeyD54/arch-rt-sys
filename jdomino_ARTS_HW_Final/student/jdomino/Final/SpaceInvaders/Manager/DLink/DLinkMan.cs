using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class DLinkMan : ListBase
    {
        public DLinkMan()
            : base()
        {
            //LTN - DLinkMan
            this.poIterator = new DLinkIterator();
            this.poHead = null;
        }
        override public void AddToFront(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);

            DLink pNode = (DLink)_pNode;
            // add node
            if (poHead == null)
            {
                // push to the front
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // push to front
                pNode.pPrev = null;
                pNode.pNext = poHead;

                // update head
                poHead.pPrev = pNode;
                poHead = pNode;
            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }


        //Add to list by priority
        //This is currently only for SpriteBatches
		public override void AddByPriority(NodeBase pNodeIn, int priority)
		{
            Debug.Assert(pNodeIn != null);
            DLink pNode = (DLink)pNodeIn;
            nodeStored = false;

            if(poHead == null)
			{
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
			}
			else
			{
                // spin until we find a node
                // of priority # greater than ours
                DLink pCurrNode = poHead;
                SpriteBatch SB = (SpriteBatch)pCurrNode;

                while (pCurrNode != null)
                {
                    //Place node in front of current if our # is smaller
                    if (priority < SB.GetPriority())
					{
                        if(pCurrNode == poHead)
						{
                            poHead = pNode;
						}
						else
						{
                            pCurrNode.pPrev.pNext = pNode;
						}

                        pNode.pPrev = pCurrNode.pPrev;

                        pCurrNode.pPrev = pNode;
                        pNode.pNext = pCurrNode;

                        nodeStored = true;

                        //Node stored, stop the loop
                        break;
					}

                    //If they are equal, add after the current node
                    if(priority == SB.GetPriority())
					{
                        if (pCurrNode == poHead && pCurrNode.pNext != null)
                        {
                            pCurrNode.pNext.pPrev = pNode;
                        }
                        

                        pNode.pNext = pCurrNode.pNext;
                        pCurrNode.pNext = pNode;
                        pNode.pPrev = pCurrNode;

                        nodeStored = true;

                        //Node stored, stop the loop
                        break;
                    }
                    if(pCurrNode.pNext == null)
					{
                        break;
					}

                    pCurrNode = pCurrNode.pNext;
                    SB = (SpriteBatch)pCurrNode;
                }
                //We didn't store the node
                //Add it to EOL
                if(!nodeStored)
				{
                    pCurrNode.pNext = pNode;
                    pNode.pPrev = pCurrNode;
                    pNode.pNext = null;

                    nodeStored = true;
				}
            }

		}

        public override void AddByTimeToTrig(NodeBase pNodeIn, float timeToTrigger)
        {
            Debug.Assert(pNodeIn != null);
            DLink pNode = (DLink)pNodeIn;
            nodeStored = false;

            if (poHead == null)
            {
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // spin until we find a node
                // of priority # greater than ours
                DLink pCurrNode = poHead;
                TimerEvent TE = (TimerEvent)pCurrNode;

                while (pCurrNode != null)
                {
                    //Place node in front of current if our # is smaller
                    if (timeToTrigger < TE.timeTrigger)
                    {
                        if (pCurrNode == poHead)
                        {
                            poHead = pNode;
                        }
                        else
                        {
                            pCurrNode.pPrev.pNext = pNode;
                        }

                        pNode.pPrev = pCurrNode.pPrev;

                        pCurrNode.pPrev = pNode;
                        pNode.pNext = pCurrNode;

                        nodeStored = true;

                        //Node stored, stop the loop
                        break;
                    }

                    //If they are equal, add after the current node
                    if (timeToTrigger == TE.timeTrigger)
                    {
                        if (pCurrNode == poHead && pCurrNode.pNext != null)
                        {
                            pCurrNode.pNext.pPrev = pNode;
                        }


                        pNode.pNext = pCurrNode.pNext;
                        pCurrNode.pNext = pNode;
                        pNode.pPrev = pCurrNode;

                        nodeStored = true;

                        //Node stored, stop the loop
                        break;
                    }
                    if (pCurrNode.pNext == null)
                    {
                        break;
                    }

                    pCurrNode = pCurrNode.pNext;
                    TE = (TimerEvent)pCurrNode;
                }
                //We didn't store the node
                //Add it to EOL
                if (!nodeStored)
                {
                    pCurrNode.pNext = pNode;
                    pNode.pPrev = pCurrNode;
                    pNode.pNext = null;

                    nodeStored = true;
                }
            }

        }

        override public void AddToEnd(NodeBase _pNode)
        {
            // add to front
            Debug.Assert(_pNode != null);
            DLink pNode = (DLink)_pNode;

            // add node
            if (poHead == null)
            {
                // none on list... so add it
                poHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                // spin until end
                DLink pTmp = poHead;
                DLink pLast = pTmp;
                while (pTmp != null)
                {
                    pLast = pTmp;
                    pTmp = pTmp.pNext;
                }

                // push to front
                pLast.pNext = pNode;
                pNode.pPrev = pLast;
                pNode.pNext = null;

            }

            // worst case, pHead was null initially, now we added a node so... this is true
            Debug.Assert(poHead != null);
        }

		override public void Remove(NodeBase _pNode)
        {
            // There should always be something on list
            Debug.Assert(poHead != null);
            Debug.Assert(_pNode != null);
            DLink pNode = (DLink)_pNode;

            // four cases

            if (pNode.pPrev == null && pNode.pNext == null)
            {   // Only node
                poHead = null;
            }
            else if (pNode.pPrev == null && pNode.pNext != null)
            {   // First node
                poHead = pNode.pNext;
                pNode.pNext.pPrev = pNode.pPrev;
            }
            else if (pNode.pPrev != null && pNode.pNext == null)
            {   // Last node
                pNode.pPrev.pNext = pNode.pNext;
            }
            else // (pNode.pPrev != null && pNode.pNext != null)
            {   // Middle node
                pNode.pNext.pPrev = pNode.pPrev;
                pNode.pPrev.pNext = pNode.pNext;
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();
        }

        override public NodeBase RemoveFromFront()
        {
            // There should always be something on list
            Debug.Assert(poHead != null);

            // return node
            DLink pNode = poHead;

            // Update head (OK if it points to NULL)
            poHead = poHead.pNext;
            if (poHead != null)
            {
                poHead.pPrev = null;
                // do not change pEnd
            }
            else
            {
                // only one on the list
                // pHead == null
            }

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            pNode.Clear();

            return pNode;
        }


		override public Iterator GetIterator()
        {
            poIterator.Reset(this.poHead);
            return poIterator;
        }

        public DLinkIterator poIterator;
        public DLink poHead;
        private bool nodeStored;
    }
}