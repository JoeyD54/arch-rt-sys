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
    public class Composite_Tests : UnitTestBase
    {
        public void Composite_Shakeout()
        {
            if (Composite_Tests_Flags.Shakeout_Enable)
            {
                Composite pGrid = new Composite("Grid");
                Composite pCol0 = new Composite("Col0");
                Composite pCol1 = new Composite("Col1");

                CHECK(pGrid != null);
                CHECK(pGrid.name == "Grid");
                CHECK(pGrid.GetType().Name == "Composite");
                CHECK(pCol0 != null);
                CHECK(pCol0.name == "Col0");
                CHECK(pCol0.GetType().Name == "Composite");
                CHECK(pCol1 != null);
                CHECK(pCol1.name == "Col1");
                CHECK(pCol1.GetType().Name == "Composite");

                pGrid.AddLeaf(pCol0);
                pGrid.AddLeaf(pCol1);

                Leaf pAlien_0 = new Leaf("Alien_0");
                Leaf pAlien_1 = new Leaf("Alien_1");
                Leaf pAlien_2 = new Leaf("Alien_2");

                CHECK(pAlien_0 != null);
                CHECK(pAlien_0.name == "Alien_0");
                CHECK(pAlien_0.GetType().Name == "Leaf");
                CHECK(pAlien_1 != null);
                CHECK(pAlien_1.name == "Alien_1");
                CHECK(pAlien_1.GetType().Name == "Leaf");
                CHECK(pAlien_2 != null);
                CHECK(pAlien_2.name == "Alien_2");
                CHECK(pAlien_2.GetType().Name == "Leaf");

                pCol0.AddLeaf(pAlien_0);
                pCol0.AddLeaf(pAlien_1);
                pCol0.AddLeaf(pAlien_2);

                Leaf pAlien_A = new Leaf("Alien_A");
                Leaf pAlien_B = new Leaf("Alien_B");
                Leaf pAlien_C = new Leaf("Alien_C");

                CHECK(pAlien_A != null);
                CHECK(pAlien_A.name == "Alien_A");
                CHECK(pAlien_A.GetType().Name == "Leaf");
                CHECK(pAlien_B != null);
                CHECK(pAlien_B.name == "Alien_B");
                CHECK(pAlien_B.GetType().Name == "Leaf");
                CHECK(pAlien_C != null);
                CHECK(pAlien_C.name == "Alien_C");
                CHECK(pAlien_C.GetType().Name == "Leaf");

                pCol1.AddLeaf(pAlien_A);
                pCol1.AddLeaf(pAlien_B);
                pCol1.AddLeaf(pAlien_C);

                // --------------------------------

                Component pTmp = pGrid.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pCol0);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pCol1);

                pTmp = pTmp.GetNext();

                CHECK(pTmp == null);

                // --------------------------------

                pTmp = pCol0.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_0);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_1);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_2);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

                // --------------------------------

                pTmp = pCol1.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_A);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_B);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_C);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

            }
            else
            {
                IGNORE();
            }
        }


        public void Composite_DeleteNode()
        {
            if (Composite_Tests_Flags.DeleteNode_Enable)
            {
                Composite pGrid = new Composite("Grid");
                Composite pCol0 = new Composite("Col0");
                Composite pCol1 = new Composite("Col1");

                CHECK(pGrid != null);
                CHECK(pGrid.name == "Grid");
                CHECK(pGrid.GetType().Name == "Composite");
                CHECK(pCol0 != null);
                CHECK(pCol0.name == "Col0");
                CHECK(pCol0.GetType().Name == "Composite");
                CHECK(pCol1 != null);
                CHECK(pCol1.name == "Col1");
                CHECK(pCol1.GetType().Name == "Composite");

                pGrid.AddLeaf(pCol0);
                pGrid.AddLeaf(pCol1);

                Leaf pAlien_0 = new Leaf("Alien_0");
                Leaf pAlien_1 = new Leaf("Alien_1");
                Leaf pAlien_2 = new Leaf("Alien_2");

                CHECK(pAlien_0 != null);
                CHECK(pAlien_0.name == "Alien_0");
                CHECK(pAlien_0.GetType().Name == "Leaf");
                CHECK(pAlien_1 != null);
                CHECK(pAlien_1.name == "Alien_1");
                CHECK(pAlien_1.GetType().Name == "Leaf");
                CHECK(pAlien_2 != null);
                CHECK(pAlien_2.name == "Alien_2");
                CHECK(pAlien_2.GetType().Name == "Leaf");

                pCol0.AddLeaf(pAlien_0);
                pCol0.AddLeaf(pAlien_1);
                pCol0.AddLeaf(pAlien_2);

                Leaf pAlien_A = new Leaf("Alien_A");
                Leaf pAlien_B = new Leaf("Alien_B");
                Leaf pAlien_C = new Leaf("Alien_C");

                CHECK(pAlien_A != null);
                CHECK(pAlien_A.name == "Alien_A");
                CHECK(pAlien_A.GetType().Name == "Leaf");
                CHECK(pAlien_B != null);
                CHECK(pAlien_B.name == "Alien_B");
                CHECK(pAlien_B.GetType().Name == "Leaf");
                CHECK(pAlien_C != null);
                CHECK(pAlien_C.name == "Alien_C");
                CHECK(pAlien_C.GetType().Name == "Leaf");

                pCol1.AddLeaf(pAlien_A);
                pCol1.AddLeaf(pAlien_B);
                pCol1.AddLeaf(pAlien_C);

                // --------------------------------

                Component pTmp = pGrid.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pCol0);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pCol1);

                pTmp = pTmp.GetNext();

                CHECK(pTmp == null);

                // --------------------------------

                pTmp = pCol0.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_0);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_1);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_2);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

                // --------------------------------

                pTmp = pCol1.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_A);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_B);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_C);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pAlien_2);

                pTmp = pCol0.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_0);

                pTmp = pTmp.GetNext();

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_1);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pAlien_B);

                pTmp = pCol1.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_A);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_C);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pAlien_A);

                pTmp = pCol1.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_C);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pAlien_C);

                pTmp = pCol1.pHead;

                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pAlien_1);

                pTmp = pCol0.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pAlien_0);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pAlien_0);

                pTmp = pCol0.pHead;

                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pCol0);

                pTmp = pGrid.pHead;

                CHECK(pTmp != null);
                CHECK(pTmp == pCol1);

                pTmp = pTmp.GetNext();

                CHECK(pTmp == null);

                // -----------------------------

                pGrid.RemoveLeaf(pCol1);

                pTmp = pGrid.pHead;

                CHECK(pTmp == null);

            }
            else
            {
                IGNORE();
            }
        }
    }
}

// --- End of File ---

