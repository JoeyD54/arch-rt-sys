//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    //-----------------------------------------
    // Reverse Iterator
    //    Start at the last node...
    //    Iterator to the first node
    //-----------------------------------------
    public class Car_ReverseIterator : Car_BaseIterator
    {
        public Car_ReverseIterator(Garage pGarage)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            pLocalGarage = pGarage;
            pCurrCar = (Car)pGarage.poHead;
            
            if(pCurrCar == null)
			{
                isDone = true;
			}
            else
			{
                isDone = false;
			}

            //Get to EOL
            if(pCurrCar != null)
			{
                while (pCurrCar.pNext != null)
                {
                    pCurrCar = (Car)pCurrCar.pNext;
                }
            }
            

            pLastCar = pCurrCar;

            //pCurrCar is now set to EOL, We'll now step backward
        }
        override public Car Next()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (pCurrCar != null)
            {
                pCurrCar = (Car)pCurrCar.pPrev;
            }

            if (pCurrCar == null || pCurrCar.pPrev == null)
            {
                isDone = true;
            }

            return pCurrCar;
        }
        override public bool IsDone()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return isDone;
        }
        override public Car First()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return pLastCar;
        }
        override public Car Current()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return pCurrCar;
        }

        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------
        private Garage pLocalGarage;
        private Car pCurrCar;
        private Car pLastCar;
        private bool isDone;
    }
}

// --- End of File ---

