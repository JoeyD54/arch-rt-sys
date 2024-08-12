//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using UnitTest;

// ----------------------------------
// ---     DO NOT MODIFY FILE     ---
// ----------------------------------

namespace PA
{
    public class Singleton_Tests : UnitTestBase
    {
        public void Singleton_GetInstance_Public()
        {
            if (Singleton_Tests_Flags.Singleton_GetInstance_Public_Enable)
            {
                Singleton pSingleton = Singleton.GetInstance();
                CHECK(pSingleton != null);

                // ------------------------------------

                CHECK(pSingleton.GetX() == 5);
                CHECK(pSingleton.GetY() == 6);

                // -----------------------------------

                pSingleton.Add(10, 30);
                CHECK(pSingleton.GetX() == 15);
                CHECK(pSingleton.GetY() == 36);

                // -----------------------------------

                pSingleton.Sub(5, 6);
                CHECK(pSingleton.GetX() == 10);
                CHECK(pSingleton.GetY() == 30);

            }
            else
            {
                IGNORE();
            }
        }

        public void Singleton_InternalInstance_Public()
        {
            if (Singleton_Tests_Flags.Singleton_InternalInstance_Enable)
            {
                int x;
                int y;

                x = GlobalMan.GetX();
                y = GlobalMan.GetY();
 
                CHECK(x == 5);
                CHECK(y == 6);

                // -----------------------------------

                GlobalMan.Add(10, 30);
                CHECK(GlobalMan.GetX() == 15);
                CHECK(GlobalMan.GetY() == 36);

                // -----------------------------------

                GlobalMan.Sub(5, 6);
                CHECK(GlobalMan.GetX() == 10);
                CHECK(GlobalMan.GetY() == 30);

            }
            else
            {
                IGNORE();
            }
        }

    }

}

// --- End of File ---

