//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// -----------------------------------------------
// Add CODE/REFACTOR here
// -----------------------------------------------
//    Fill in methods
//    Add additional methods if desired
//    Add additional data if desired
// -----------------------------------------------

namespace PA
{
    class PriorityQueue
    {
        public Node GetHead()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            return (Node)poHead;
        }

        public void Remove( Node pNode )
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Node pCurrNode = (Node)poHead;

            while(pCurrNode != pNode)
			{
                pCurrNode = (Node)pCurrNode.pNext;
			}

            if(pNode == poHead)
			{
                poHead = pNode.pNext;
			}
            //Clear out adjacent pointers in next checks
            else
            {
                pCurrNode.pPrev.pNext = pCurrNode.pNext;
            }

            if(pCurrNode.pNext != null)
			{
                pCurrNode.pNext.pPrev = pCurrNode.pPrev;
            }
            

            //Clear node pointers
            pCurrNode.pNext = null;
            pCurrNode.pPrev = null;

        }
        public void Insert( Node pNode )
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Node pCurrNode = (Node)poHead;
            nodeStored = false;

            if(poHead == null)
			{
                poHead = pNode;
			}
			else
			{
                //Step through the list
                while(pCurrNode.pNext != null)
				{
                    //Insert based on the Key
                    if (pNode.key < pCurrNode.key)
					{
                        //This should put pNode in front of currNode

                        //Replace head if we're at head
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

                        //We found a storage spot, break out of loop
                        break;
					}
                    pCurrNode = (Node)pCurrNode.pNext;
                }
                //We didn't store the node, add to to end
                if(!nodeStored)
				{
                    pCurrNode.pNext = pNode;
                    pNode.pPrev = pCurrNode;
                    pNode.pNext = null;

                    nodeStored = true;
				}
            }
        }

        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        public DLink poHead;
        private bool nodeStored;
    }
}

// --- End of File ---

