//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Vehicle 
    {
        public void Attach(Element pElement)
        {
            Debug.Assert(pElement != null);

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if(poHead == null)
			{
                poHead = pElement;
                poHead.pNext = null;
            }
            else
			{
                pElement.pNext = poHead;
                poHead = pElement;
			}
            
        }

        public void Detach(Element pElement)
        {
            Debug.Assert(pElement != null);

            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Element pCurr = poHead;

            //Is it the head?
            if(poHead == pElement)
			{
                poHead = (Element)poHead.pNext;
                pElement.pNext = null;
			}

            while (pCurr != null)
			{
                //We found the element
                if(pCurr.pNext == pElement)
				{
                    pCurr.pNext = pElement.pNext;
                    pElement.pNext = null;
                    break;
				}

                pCurr = (Element)pCurr.pNext;
			}
        }

        public void Accept(Visitor visitor)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Element pCurr = poHead;

            while(pCurr != null)
			{
                pCurr.Accept(visitor);
                pCurr = (Element)pCurr.pNext;
			}
        }



        // Holds the Elements with a Single Linked list
        // Add to the front of the list O(1)
        public Element poHead;
    }
}

// --- End of File ---

