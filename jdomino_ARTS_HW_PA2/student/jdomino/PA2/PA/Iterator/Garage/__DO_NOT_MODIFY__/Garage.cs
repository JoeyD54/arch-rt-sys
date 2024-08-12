//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Garage
    {
        public Garage()
        {
            this.poHead = null;
        }

        public void Add(Car pCar)
        {
            Debug.Assert(pCar != null);

            // Add to Front
            if(this.poHead == null)
            {
                this.poHead = pCar;
                pCar.pNext = null;
                pCar.pPrev = null;
            }
            else
            {
                Car pTmp = this.poHead;
                this.poHead = pCar;
                pCar.pPrev = null;
                pCar.pNext = pTmp;
                pTmp.pPrev = pCar;
            }
        }

        // -----------------------------------------------------------------
        // Data:
        //       Do NOT add or change data
        // -----------------------------------------------------------------
        // Yes - it would be easy to add data (make unit test easier)
        //       But that's not the problem
        // -----------------------------------------------------------------

        public Car poHead;
    }
}

// --- End of File ---
