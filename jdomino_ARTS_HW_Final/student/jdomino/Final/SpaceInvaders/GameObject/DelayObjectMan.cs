using System.Diagnostics;

namespace SpaceInvaders
{
    class DelayedObjectMan
    {
        static public void Attach(ColObserver pObserver)
        {
            Debug.Assert(pObserver != null);
            DelayedObjectMan pDelayMan = DelayedObjectMan.privGetInstance();

            pDelayMan.poSLinkMan.AddToFront(pObserver);
        }

        static public void Process()
        {
            DelayedObjectMan pDelayMan = DelayedObjectMan.privGetInstance();
            Iterator pIt = pDelayMan.poSLinkMan.GetIterator();
            ColObserver pNode = (ColObserver)pIt.First();

            while (!pIt.IsDone())
            {
                // Fire off listener
                pNode.Execute();

                pNode = (ColObserver)pIt.Next();
            }


            // remove
            ColObserver pTmp = null;

            pIt = pDelayMan.poSLinkMan.GetIterator();
            pNode = (ColObserver)pIt.First();

            while (!pIt.IsDone())
            {
                pTmp = pNode;
                pNode = (ColObserver)pIt.Next();

                // remove
                pDelayMan.poSLinkMan.Remove(pTmp);
            }
        }
        private DelayedObjectMan()
        {
            this.poSLinkMan = new SLinkMan();
            Debug.Assert(this.poSLinkMan != null);
        }

        private static DelayedObjectMan privGetInstance()
        {
            // Do the initialization
            if (instance == null)
            {
                instance = new DelayedObjectMan();
            }

            // Safety - this forces users to call create first
            Debug.Assert(instance != null);

            return instance;
        }

        // -------------------------------------------
        // Data: 
        // -------------------------------------------

        private SLinkMan poSLinkMan;
        private static DelayedObjectMan instance = null;
    }
}