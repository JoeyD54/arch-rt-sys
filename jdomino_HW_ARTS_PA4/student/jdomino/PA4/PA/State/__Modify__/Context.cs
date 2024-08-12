//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Context
    {

        public Context()
        {
            this.currName = State.Name.Uninitialized;
            this.pState = null;
            this.poHead = null;
        }

        public void Sit()
        {
            this.pState.Sit();
        }

        public void Stand()
        {
            this.pState.Stand();
        }

        public void Walk()
        {
            this.pState.Walk();
        }

        public void Stop()
        {
            this.pState.Stop();
        }

        public State.Name GetState()
        {
            return this.currName;
        }

        public void Detach(State pState)
        {
            Debug.Assert(pState != null);
            Debug.Assert(this.poHead != null);

            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
            if (poHead == pState)
            {
                poHead = (State)poHead.pNext;
                pState.pNext = null;
            }
            else
            {
                State pCurr = poHead;

                while (pCurr != null)
                {
                    if (pCurr.pNext == pState)
                    {
                        pCurr.pNext = pState.pNext;
                        pState.pNext = null;
                    }
                    pCurr = (State)pCurr.pNext;
                }
            }
        }

        public void Attach(State pState)
        {
            Debug.Assert(pState != null);

            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
            if (poHead == null)
            {
                poHead = pState;
                poHead.pNext = null;
            }
            else
            {
                pState.pNext = poHead;
                poHead = pState;
            }

            poHead.SetContext(this);
            this.pState = pState;
            this.currName = pState.name;
        }

        public void SetState( State.Name name)
        {
            // --------------------------
            // Add CODE/REFACTOR here
            // --------------------------
            //MailBox_StateMethod.Register((MailBox_StateMethod.Status) name);
            currName = name;
			State pCurr = poHead;

			if (poHead.name == name)
			{
                pState = poHead;
			}
			else
			{
				while (pCurr != null)
				{
					//We found the state
					if (pCurr.name == name)
					{
                        pState = pCurr;
					}
					pCurr = (State)pCurr.pNext;
				}
			}
		}



        // -------------------------------
        //   DO NOT change data members
        // -------------------------------
        private State       pState;
        private State       poHead;
        private State.Name  currName;
    }
}

// --- End of File ---
