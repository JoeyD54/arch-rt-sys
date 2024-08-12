//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    //-----------------------------------------
    // First Iterator
    //    Start at the first Box...
    //    Iterator to the Last Box
    //-----------------------------------------
    public class Box_ForwardIterator : Box_BaseIterator
    {
        public Box_ForwardIterator(Amazon pAmazon)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Debug.Assert(pAmazon != null);

            pLocalTruck = pAmazon.poHead;
            boxCount = 0;

            if(pLocalTruck != null)
			{
                pFirstBox = pLocalTruck.pBoxes[boxCount];
                isDone = false;
			}
            else
			{
                pFirstBox = null;
                isDone = true;
			}

            pCurrBox = pFirstBox;
        }


        //if current box is empty, go to next one till it's not
        private void CheckEmpty()
		{
            while(pLocalTruck != null)
			{
                //We are outside the bounds of the truck.
                //Leave. We need to more to next truck.
                if(boxCount == 4)
				{
                    break;
				}


                if(pLocalTruck.pBoxes[boxCount].name != Box.Name.Empty)
				{
                    break;
				}
				else
				{
                    boxCount++;
				}
			}

		}

        override public Box Next()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            
            //Go to next box in truck
            //If we reach 4th (box[3]) box
            //Go to next truck and start at box[0]

            boxCount++;

            CheckEmpty();

            //Still in same truck
            if (boxCount < 4 && !isDone)
            {
                pCurrBox = pLocalTruck.pBoxes[boxCount];

                //We have looked at last box. Make sure there's another truck
                if(boxCount == 3)
				{
                    if(pLocalTruck.pNext == null)
					{
                        isDone = true;
					}
				}
			}
            //Checked all boxes. Next Truck
            else
			{
                //There are more trucks
                if(pLocalTruck != null && pLocalTruck.pNext != null)
				{
                    pLocalTruck = (Truck)pLocalTruck.pNext;
                    boxCount = 0;
                    CheckEmpty();
                    pCurrBox = pLocalTruck.pBoxes[boxCount];
                }
                //No more trucks. We're done
                else
				{
                    isDone = true;
                    pCurrBox = null;
				}
			}


            return pCurrBox;
        }
        override public bool IsDone()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return isDone;
        }
        override public Box First()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return pFirstBox;
        }
        override public Box Current()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            return pCurrBox;
        }

        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------
        private Truck pLocalTruck;
        private Box pCurrBox;
        private Box pFirstBox;
        private int boxCount;
        private bool isDone;


    }
}

// --- End of File ---

