//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    //-----------------------------------------
    // Forward Iterator
    //    Start at the first node...
    //    Iterator to the Last node
    //-----------------------------------------
    public class Car_ForwardIterator : Car_BaseIterator
    {
        public Car_ForwardIterator(Garage pGarage)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            pLocalGarage = pGarage;
            pCurrCar = (Car)pGarage.poHead;

            if (pCurrCar == null)
            {
                isDone = true;
            }
            else
            {
                isDone = false;
            }
        }
        override public Car Next()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if(pCurrCar != null)
			{
                pCurrCar = (Car)pCurrCar.pNext;
            }
            
            if(pCurrCar == null || pCurrCar.pNext == null)
			{
                isDone = true;
			}

            //pCurrCar = (Car)pCurrCar.pNext;

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
            return (Car)pLocalGarage.poHead;
        }
        override public Car Current()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return (Car)pCurrCar;
        }

        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------
        private Garage pLocalGarage;
        private Car pCurrCar;
        private bool isDone;

    }
}

// --- End of File ---

