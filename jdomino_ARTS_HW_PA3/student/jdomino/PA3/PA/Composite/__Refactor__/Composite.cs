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
    public class Composite : Component
    {
        public Composite(string _name) : base()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            base.name = _name;
            isLeaf = false;
        }

        public override void RemoveLeaf(Component pComponent)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Component pCurrComponent = this.pHead;

            
            while(pCurrComponent != null)
			{
                //We're sorting through a composite
                //Remove the child leaf
                if(!pCurrComponent.isLeaf)
				{
                    pCurrComponent.RemoveLeaf(pComponent);

                    //We removed the child, do not remove the composite too!
                    //break;
				}

                if(pComponent == pHead)
				{
                    pHead = (Component)pCurrComponent.pNext;
				}
                //Make sure prev node points beyond node to remove
                if(pCurrComponent.pNext == pComponent)
				{
                    pCurrComponent.pNext = pComponent.pNext;
                    pComponent.pNext = null;
				}
                pCurrComponent = (Component)pCurrComponent.pNext;
			}
        }

        public void AddLeaf(Component pComponent)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            //Add to EOL

            Component pCurrComponent = pHead;

            //Go to last node
            if(pHead == null)
			{
                pHead = pComponent;
			}
            else
			{
                while (pCurrComponent.pNext != null)
                {
                    pCurrComponent = (Component)pCurrComponent.pNext;
                }

                //Update next pointers
                pCurrComponent.pNext = pComponent;
                pComponent.pNext = null;
            }
        }

        // ----------------------------------------------------------
        // Public for Unit Testing purposes
        // ----------------------------------------------------------
        public Component pHead;
    }
}

// --- End of File ---
