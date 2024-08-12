using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class InputSubject
    {
        public InputSubject()
        {
            this.poSLinkMan = new SLinkMan();
            Debug.Assert(this.poSLinkMan != null);
        }

        public void Attach(InputObserver pObserver)
        {
            // protection
            Debug.Assert(pObserver != null);

            pObserver.pSubject = this;

            // Attach it to the Animation Sprite ( Push to front )
            this.poSLinkMan.AddToFront(pObserver);
        }


        public void Notify()
        {
            Iterator pIt = this.poSLinkMan.GetIterator();

            InputObserver pObserver = (InputObserver)pIt.Curr();

            while (!pIt.IsDone())
            {
                // Fire off listener
                pObserver.Notify();

                pObserver = (InputObserver)pIt.Next();
            }

        }

        public void Detach()
        {
        }


        // Data: ------------------------
        private SLinkMan poSLinkMan;



    }
}