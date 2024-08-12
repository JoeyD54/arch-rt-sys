//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class GlobalMan : GlobalMan_Base
    {
        // ------------------------------------------------------------------
        // Rules:
        //   1) ADD additional method and/or data to this Class
        //   2) Leave the supplied signatures
        //         of the constructor and methods - alone
        // ------------------------------------------------------------------

        // ------------------------------------------------------------------
        // Note: default constructor needs to be private
        //       initialized x to 5, y to 6
        // ------------------------------------------------------------------
        private GlobalMan() : base(5, 6)
        {
            // ---------------------------------------------------------
            // Do not change signature (leave this contructor alone)
            // ---------------------------------------------------------
        }
        static public void Create()
		{
            if (pInstance == null)
            {
                pInstance = new GlobalMan();
            }

		}

        static public void Add(int _x, int _y)
        {
			// ------------------------------
			// Add CODE/REFACTOR here
			// ------------------------------
            if(pInstance == null)
			{
                Create(); 
			}

            pInstance.proAdd(_x, _y);

        }
        static public void Sub(int _x, int _y)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (pInstance == null)
            {
                Create();
            }

            pInstance.proSub(_x, _y);
        }

        static public int GetX()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (pInstance == null)
            {
                Create();
            }

            return pInstance.proGetX();

        }
        static public int GetY()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if (pInstance == null)
            {
                Create();
            }

            return pInstance.proGetY();

        }

        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------
        private static GlobalMan pInstance = null;
	}
}

// --- End of File ---

