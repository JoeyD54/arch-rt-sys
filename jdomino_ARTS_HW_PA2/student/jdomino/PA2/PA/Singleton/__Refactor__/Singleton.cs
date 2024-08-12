//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace PA
{
    public class Singleton : Singleton_Base
    {
        // -------------------------------------------------------------------
        // GetInstance() - responsible for creating its class
        //         Return unique instance 
        //         Create if first time... Create Instance
        // -------------------------------------------------------------------
        static public Singleton GetInstance()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            if(pInstance == null)
			{
                pInstance = new Singleton();
			}

            return pInstance;
        }

        // ------------------------------------------------------------------
        // Note: default constructor needs to be private
        //       initialized x to 5, y to 6
        // ------------------------------------------------------------------
        private Singleton() : base(5,6)
        {
           
        }

        // --------------------------------------------------
        // Add data/methods to this class if you wish <hint>
        // --------------------------------------------------
        private static Singleton pInstance = null;

    }
}

// --- End of File ---

