//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace UnitTest_Sample
{
    public class Manager
    {
        //--------------------------------------------------------------
        // Need the following functions for UNIT test verification
        //--------------------------------------------------------------

        /********************
        * 
        * GetActive
        * 
        * Return head of active list
        * 
        */
        public Node GetActive()
        {
            return (Node)pActiveHead;
        }

        /********************
        * 
        * GetReserve
        * 
        * Return the head of the reserve list
        * 
        */
        public Node GetReserve()
        {
            return (Node)pReserveHead;
        }

        /********************
        * 
        * Manager
        * 
        * Initialize node lists and variables
        * 
        */
        public Manager(int InitialNumReserved, int DeltaGrow)
        {
            this.mDeltaGrow = DeltaGrow;
            this.mNumReserved = InitialNumReserved;
            this.mNumActive = 0;
            this.mNumReserved = 0;

            pReserveHead = null;
            pActiveHead = null;

            //Initialize the reserve with given initial size
            //Make sure we aren't supposed to be empty
            if(InitialNumReserved > 0)
			{
                AddToReserve(InitialNumReserved);
            }
        }

        /********************
        * 
        * AddToFront
        * 
        * Add node from Reserved to Active list at FOL
        * 
        */
        public Node AddToFront(Node.Name name, int val)
        {
            //Add to reserve if we need it of given amount
            if(pReserveHead == null)
			{
                AddToReserve(mDeltaGrow);
			}

            //Step 1 remove node from reserve
            Node tempNode = (Node)pReserveHead;
            
            if(pReserveHead.pNext != null)
			{
                pReserveHead.pNext.pPrev = null;
            }

            pReserveHead = pReserveHead.pNext;
            tempNode.pNext = null;
            tempNode.name = name;
            tempNode.x = val;

            //Step 2 set removed node to active list head
            if(pActiveHead == null)
			{
                pActiveHead = tempNode;       
			}
            else
			{
                tempNode.pNext = pActiveHead;
                pActiveHead.pPrev = tempNode;
                pActiveHead = tempNode;
			}

            //Update counters
            mNumActive++;
            mNumReserved--;

            return (Node)pActiveHead;
        }


        /********************
        * 
        * AddToEnd
        * 
        * Add node from Reserved to Active list at EOL
        * 
        */
        public Node AddToEnd(Node.Name name, int val)
        {
            //Add to reserve if we need it of given amount
            if (pReserveHead == null)
            {
                AddToReserve(mDeltaGrow);
            }

            //Step 1 remove node from reserve
            DLink tempReserveDLink = pReserveHead;
            Node tempNode = (Node) pReserveHead;

            if (pReserveHead.pNext != null)
            {
                pReserveHead.pNext.pPrev = null;
            }

            pReserveHead = pReserveHead.pNext;
            tempNode.pNext = null;
            tempNode.name = name;
            tempNode.x = val;

            //Step 2 set removed node to active list head
            if (pActiveHead == null)
            {
                pActiveHead = tempNode;
            }
            else
            {
                //Get to EOL
                Node tempActiveHead = (Node)pActiveHead;
                while(tempActiveHead.pNext != null)
				{
                    tempActiveHead = (Node)tempActiveHead.pNext;
				}

                tempActiveHead.pNext = tempNode;
                tempNode.pPrev = tempActiveHead;
            }

            //Update counters
            mNumActive++;
            mNumReserved--;

            return tempNode;
        }

        /********************
        * 
        * Find
        * 
        * Find a node off of the name
        * 
        */
        public Node Find(Node.Name name)
        {
            DLink searchDLink = pActiveHead;
            Node searchNode = (Node)searchDLink;
            Node foundNode = null;
            while(searchNode.name != name && searchDLink.pNext != null)
			{
                searchDLink = searchDLink.pNext;
                searchNode = (Node)searchDLink;
			}

            if(searchNode.name == name)
			{
                foundNode = searchNode;
			}

            return foundNode;
        }

        /********************
         * 
         * Remove
         * 
         * Remove node from active and move it to  front of reserve list
         * 
         */
        public void Remove(Node pNode)
        {
            DLink ptempActive = pActiveHead;
            while((Node)ptempActive != pNode)
			{
                ptempActive = ptempActive.pNext;
			}

            //Fix pointers
            if(ptempActive == pActiveHead)
			{
                if(pActiveHead.pNext != null)
				{
                    pActiveHead = pActiveHead.pNext;
                }
                if(pActiveHead.pPrev != null)
				{
                    pActiveHead.pPrev = null;
                }
			}
			else
			{
                if (ptempActive.pPrev != null)
                {
                    ptempActive.pPrev.pNext = ptempActive.pNext;
                }
                if (ptempActive.pNext != null)
                {
                    ptempActive.pNext.pPrev = ptempActive.pPrev;
                }
            }

            Node foundNode = (Node)ptempActive;

            //Clear data
            foundNode.name = Node.Name.Unitialized;
            foundNode.x = 0;
            foundNode.pNext = null;
            foundNode.pPrev = null;

            pReserveHead.pPrev = foundNode;
            foundNode.pNext = pReserveHead;
            pReserveHead = foundNode;

            mNumActive--;
            mNumReserved++;

            //If we cleared out active list, null it out
            if(mNumActive == 0)
			{
                pActiveHead = null;
			}

        }

        /********************
        * 
        * AddToReserve
        * 
        * Add the given amount of nodes to the reseve list at EOL
        * 
        */
        public void AddToReserve(int amountToAdd)
		{
            while (amountToAdd != 0)
            {
                Node newNode = new Node();
                newNode.name = Node.Name.Unitialized;
                newNode.pNext = null;
                newNode.pPrev = null;

                DLink newDLink = (DLink) newNode;

                //Update reseve DLink list
                if (pReserveHead == null)
                {
                    pReserveHead = newDLink;     
                }
                else
                {
                    //Add to EOL
                    //while(pTmpReserveHead.pNext != null)
                    //{
                    //    pTmpReserveHead = pTmpReserveHead.pNext;
                    //}
                    //Update pointers before storing
                    newDLink.pNext = pReserveHead;
                    pReserveHead.pPrev = newDLink;
                    pReserveHead = newDLink;    
                }
                mTotalNumNodes++;
                mNumReserved++;
                amountToAdd--;
            }
		}

// ---------------------------------------
// Data:
//       Required fields...
//       add more data if you want
// ---------------------------------------
        public int mDeltaGrow;
        public int mTotalNumNodes;
        public int mNumReserved;
        public int mNumActive;

        DLink pActiveHead;
        DLink pReserveHead;
	}

}

// --- End of File ---
