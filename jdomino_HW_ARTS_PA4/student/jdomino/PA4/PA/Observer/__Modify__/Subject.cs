using System;
using System.Diagnostics;

namespace PA
{
    public class Subject
    {
        public Subject()
		{
            poHead = null;
		}
        public void Notify()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Observer pCurr = poHead;

            while (pCurr != null)
            {
                pCurr.Notify();
                pCurr = (Observer)pCurr.pNext;
            }
        }

        public void Detach(Observer pObserver)
        {
            Debug.Assert(pObserver != null);
            Debug.Assert(this.poHead != null);
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if(poHead == pObserver)
			{
                poHead = (Observer)poHead.pNext;
                pObserver.pNext = null;
			}
            else
			{
                Observer pCurr = poHead;

                while(pCurr != null)
				{
                    if(pCurr.pNext == pObserver)
					{
                        pCurr.pNext = pObserver.pNext;
                        pObserver.pNext = null;
					}
                    pCurr = (Observer)pCurr.pNext;
				}
			}
        }

        public void Attach(Observer pObserver)
        {
            Debug.Assert(pObserver != null);
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (poHead == null)
            {
                poHead = pObserver;
                poHead.pNext = null;
            }
            else
            {
                pObserver.pNext = poHead;
                poHead = pObserver;
            }

            poHead.SetSubject(this);
        }

        // Holds the observers with a Single Linked list
        // Add to the front of the list O(1)
        private Observer poHead;
    }
}

// --- End of File ---

