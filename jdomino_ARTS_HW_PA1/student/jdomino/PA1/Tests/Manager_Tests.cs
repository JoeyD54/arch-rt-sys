//-----------------------------------------------------------------------------
// Copyright 2022, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;
using UnitTest;

namespace UnitTest_Sample
{
    public class Manager_Tests_Flags
    {
        // Enable/Disable unit test here:
        static public bool Simple_CreateMan_Enable = true;
        static public bool Simple_AddToFront_1_Enable = true;
        static public bool Simple_AddToFront_2_Enable = true;
        static public bool Simple_AddToFront_3_Enable = true;
        static public bool Simple_AddToFront_4_Enable = true;
        static public bool Simple_AddToEnd_1_Enable = true;
        static public bool Simple_AddToEnd_2_Enable = true;
        static public bool Simple_AddToEnd_3_Enable = true;
        static public bool Simple_AddToEnd_4_Enable = true;
        static public bool Simple_Remove_Enable = true;
        static public bool Simple_Memory_Pooling_Enable = true;
        static public bool Simple_Find_Enable = true;
    }

    public class Manager_Tests : UnitTestBase
    {
        public void Simple_CreateMan()
        {
            if (Manager_Tests_Flags.Simple_CreateMan_Enable)
            {
                Manager pMan = new Manager(0, 2);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 2);             
                CHECK(pMan.mTotalNumNodes == 0); 
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);
            }
            else
            {
                IGNORE();
            }
        }

        public void Simple_AddToFront_1()
        {
            if (Manager_Tests_Flags.Simple_AddToFront_1_Enable)
            {
                Manager pMan = new Manager(0, 1);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToFront(Node.Name.Bird, 55);
                CHECK(pBird != null);

                CHECK(pMan.mDeltaGrow == 1);    
                CHECK(pMan.mTotalNumNodes == 1);  
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 1);
           
                CHECK(pMan.GetActive() == pBird);
                CHECK(pMan.GetReserve() == null);

                Node pTmp;
                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);
            }
            else
            {
                IGNORE();
            }
        }

        public void Simple_AddToFront_2()
        {
            if (Manager_Tests_Flags.Simple_AddToFront_2_Enable)
            {
                Manager pMan = new Manager(0, 1);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToFront(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pDog = pMan.AddToFront(Node.Name.Dog, 66);
                CHECK(pDog != null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 2);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 2);

                CHECK(pMan.GetActive() == pDog);
                CHECK(pMan.GetReserve() == null);

                Node pTmp;
                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pDog);
                CHECK(pTmp.name == Node.Name.Dog);
                CHECK(pTmp.x == 66);
                CHECK(pTmp.GetNext() == pBird);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pDog);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

            }
            else
            {
                IGNORE();
            }
        }
        public void Simple_AddToFront_3()
        {
            if (Manager_Tests_Flags.Simple_AddToFront_3_Enable)
            {
                Manager pMan = new Manager(0, 1);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                // Add one to the front
                Node pBird = pMan.AddToFront(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pDog = pMan.AddToFront(Node.Name.Dog, 66);
                CHECK(pDog != null);

                Node pFish = pMan.AddToFront(Node.Name.Fish, 77);
                CHECK(pFish != null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 3);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 3);

                CHECK(pMan.GetActive() == pFish);
                CHECK(pMan.GetReserve() == null);

                Node pTmp;
                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pFish);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.x == 77);
                CHECK(pTmp.GetNext() == pDog);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pDog);
                CHECK(pTmp.name == Node.Name.Dog);
                CHECK(pTmp.x == 66);
                CHECK(pTmp.GetNext() == pBird);
                CHECK(pTmp.GetPrev() == pFish);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pDog);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);
            }
            else
            {
                IGNORE();
            }
        }

        public void Simple_AddToFront_4()
        {
            if (Manager_Tests_Flags.Simple_AddToFront_4_Enable)
            {
                Manager pMan = new Manager(0, 1);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToFront(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pDog = pMan.AddToFront(Node.Name.Dog, 66);
                CHECK(pDog != null);

                Node pFish = pMan.AddToFront(Node.Name.Fish, 77);
                CHECK(pFish != null);

                Node pCat = pMan.AddToFront(Node.Name.Cat, 88);
                CHECK(pCat != null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 4);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 4);

                CHECK(pMan.GetActive() == pCat);
                CHECK(pMan.GetReserve() == null);

                Node pTmp;
                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pCat);
                CHECK(pTmp.name == Node.Name.Cat);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.GetNext() == pFish);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pFish);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.x == 77);
                CHECK(pTmp.GetNext() == pDog);
                CHECK(pTmp.GetPrev() == pCat);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pDog);
                CHECK(pTmp.name == Node.Name.Dog);
                CHECK(pTmp.x == 66);
                CHECK(pTmp.GetNext() == pBird);
                CHECK(pTmp.GetPrev() == pFish);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pDog);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);

            }
            else
            {
                IGNORE();
            }
        }


        public void Simple_AddToEnd_4()
        {
            if (Manager_Tests_Flags.Simple_AddToEnd_4_Enable)
            {
                Manager pMan = new Manager(0, 1);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToEnd(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pDog = pMan.AddToEnd(Node.Name.Dog, 66);
                CHECK(pDog != null);

                Node pFish = pMan.AddToEnd(Node.Name.Fish, 77);
                CHECK(pFish != null);

                Node pCat = pMan.AddToEnd(Node.Name.Cat, 88);
                CHECK(pCat != null);

                CHECK(pMan.mDeltaGrow == 1);
                CHECK(pMan.mTotalNumNodes == 4);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 4);

                CHECK(pMan.GetActive() == pBird);
                CHECK(pMan.GetReserve() == null);

                Node pTmp;
                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == pDog);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pDog);
                CHECK(pTmp.name == Node.Name.Dog);
                CHECK(pTmp.x == 66);
                CHECK(pTmp.GetNext() == pFish);
                CHECK(pTmp.GetPrev() == pBird);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pFish);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.x == 77);
                CHECK(pTmp.GetNext() == pCat);
                CHECK(pTmp.GetPrev() == pDog);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pCat);
                CHECK(pTmp.name == Node.Name.Cat);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pFish);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);
            }
            else
            {
                IGNORE();
            }
        }
        public void Simple_AddToEnd_3()
        {
            if (Manager_Tests_Flags.Simple_AddToEnd_3_Enable)
            {
                Manager pMan = new Manager(0, 2);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToEnd(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pDog = pMan.AddToEnd(Node.Name.Dog, 66);
                CHECK(pDog != null);

                Node pFish = pMan.AddToEnd(Node.Name.Fish, 77);
                CHECK(pFish != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 4);
                CHECK(pMan.mNumReserved == 1);
                CHECK(pMan.mNumActive == 3);

                CHECK(pMan.GetActive() == pBird);
                CHECK(pMan.GetReserve() != null);

                Node pTmp;
                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == pDog);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pDog);
                CHECK(pTmp.name == Node.Name.Dog);
                CHECK(pTmp.x == 66);
                CHECK(pTmp.GetNext() == pFish);
                CHECK(pTmp.GetPrev() == pBird);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pFish);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.x == 77);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pDog);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);
            }
            else
            {
                IGNORE();
            }
        }
        public void Simple_AddToEnd_2()
        {
            if (Manager_Tests_Flags.Simple_AddToEnd_2_Enable)
            {
                Manager pMan = new Manager(0, 2);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToEnd(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pDog = pMan.AddToEnd(Node.Name.Dog, 66);
                CHECK(pDog != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 2);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 2);

                CHECK(pMan.GetActive() == pBird);
                CHECK(pMan.GetReserve() == null);

                Node pTmp;

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == pDog);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp != null);

                CHECK(pTmp == pDog);
                CHECK(pTmp.name == Node.Name.Dog);
                CHECK(pTmp.x == 66);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == pBird);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);
            }
            else
            {
                IGNORE();
            }
        }
        public void Simple_AddToEnd_1()
        {
            if (Manager_Tests_Flags.Simple_AddToEnd_1_Enable)
            {
                Manager pMan = new Manager(0, 2);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToEnd(Node.Name.Bird, 55);
                CHECK(pBird != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 2);
                CHECK(pMan.mNumReserved == 1);
                CHECK(pMan.mNumActive == 1);

                CHECK(pMan.GetActive() == pBird);
                CHECK(pMan.GetReserve() != null);

                Node pTmp;
                pTmp = pMan.GetReserve();
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetNext() == null);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pBird);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pTmp.GetNext();
                CHECK(pTmp == null);
            }
            else
            {
                IGNORE();
            }
        }
        public void Simple_Remove()
        {
            if (Manager_Tests_Flags.Simple_Remove_Enable)
            {
                Manager pMan = new Manager(0, 3);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 3);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                Node pBird = pMan.AddToFront(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pCat = pMan.AddToFront(Node.Name.Cat, 66);
                CHECK(pCat != null);

                Node pDog = pMan.AddToFront(Node.Name.Dog, 77);
                CHECK(pDog != null);

                Node pFish = pMan.AddToFront(Node.Name.Fish, 88);
                CHECK(pFish != null);

                CHECK(pMan.mDeltaGrow == 3);
                CHECK(pMan.mTotalNumNodes == 6);
                CHECK(pMan.mNumReserved == 2);
                CHECK(pMan.mNumActive == 4);

                CHECK(pMan.GetActive() == pFish);
                CHECK(pMan.GetReserve() != null);

                Node pTmp;
                Node pTmp1;
                Node pTmp2;
                Node pTmp3;
                Node pTmp4;
                Node pTmp5;

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pFish);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.GetNext() == pDog);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1 == pDog);
                CHECK(pTmp1.name == Node.Name.Dog);
                CHECK(pTmp1.x == 77);
                CHECK(pTmp1.GetNext() == pCat);
                CHECK(pTmp1.GetPrev() == pFish);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 != pTmp1);
                CHECK(pTmp2 == pCat);
                CHECK(pTmp2.name == Node.Name.Cat);
                CHECK(pTmp2.x == 66);
                CHECK(pTmp2.GetNext() == pBird);
                CHECK(pTmp2.GetPrev() == pDog);

                pTmp3 = pTmp2.GetNext();
                CHECK(pTmp3 != null);
                CHECK(pTmp3 != pTmp2);
                CHECK(pTmp3 == pBird);
                CHECK(pTmp3.name == Node.Name.Bird);
                CHECK(pTmp3.x == 55);
                CHECK(pTmp3.GetNext() == null);
                CHECK(pTmp3.GetPrev() == pCat);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetNext() != null);

                pTmp2 = pTmp.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp != pTmp2);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pTmp);

                // -------------------------------
                // --   Remove middle: Dog      --
                // -------------------------------

                pMan.Remove(pDog); 

                CHECK(pMan.mDeltaGrow == 3);
                CHECK(pMan.mTotalNumNodes == 6);
                CHECK(pMan.mNumReserved == 3);
                CHECK(pMan.mNumActive == 3);

                CHECK(pMan.GetActive() == pFish);
                CHECK(pMan.GetReserve() != null);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pFish);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.GetNext() == pCat);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1 == pCat);
                CHECK(pTmp1.name == Node.Name.Cat);
                CHECK(pTmp1.x == 66);
                CHECK(pTmp1.GetNext() == pBird);
                CHECK(pTmp1.GetPrev() == pFish);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 != pTmp1);
                CHECK(pTmp2 == pBird);
                CHECK(pTmp2.name == Node.Name.Bird);
                CHECK(pTmp2.x == 55);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pCat);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp == pDog);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetNext() != null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 != pTmp1);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pTmp1);

                // ------------------------------
                // --   Remove end: Bird       --
                // ------------------------------
                pMan.Remove(pBird);

                CHECK(pMan.mDeltaGrow == 3);
                CHECK(pMan.mTotalNumNodes == 6);
                CHECK(pMan.mNumReserved == 4);
                CHECK(pMan.mNumActive == 2);

                CHECK(pMan.GetActive() == pFish);
                CHECK(pMan.GetReserve() != null);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pFish);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.GetNext() == pCat);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1 == pCat);
                CHECK(pTmp1.name == Node.Name.Cat);
                CHECK(pTmp1.x == 66);
                CHECK(pTmp1.GetNext() == null);
                CHECK(pTmp1.GetPrev() == pFish);

                pTmp = pMan.GetReserve();
                CHECK(pTmp == pBird);
                CHECK(pTmp != null);
                CHECK(pTmp.GetPrev() == null);
                CHECK(pTmp.GetNext() != null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 == pDog);
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 != pTmp1);
                CHECK(pTmp2.GetNext() != null);
                CHECK(pTmp2.GetPrev() == pTmp1);

                pTmp3 = pTmp2.GetNext();
                CHECK(pTmp3 != null);
                CHECK(pTmp3 != pTmp2);
                CHECK(pTmp3.GetNext() == null);
                CHECK(pTmp3.GetPrev() == pTmp2);

                // ------------------------------
                // --   Remove first: Fish     --
                // ------------------------------
                pMan.Remove(pFish);

                CHECK(pMan.mDeltaGrow == 3);
                CHECK(pMan.mTotalNumNodes == 6);
                CHECK(pMan.mNumReserved == 5);
                CHECK(pMan.mNumActive == 1);

                CHECK(pMan.GetActive() == pCat);
                CHECK(pMan.GetReserve() != null);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pCat);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp == pFish);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1 == pBird);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pFish);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 == pDog);
                CHECK(pTmp2 != pTmp1);
                CHECK(pTmp2 != null);
                CHECK(pTmp2.GetNext() != pBird);
                CHECK(pTmp2.GetPrev() != null);

                pTmp3 = pTmp2.GetNext();
                CHECK(pTmp3 != null);
                CHECK(pTmp3 != pTmp2);
                CHECK(pTmp3.GetNext() != null);
                CHECK(pTmp3.GetPrev() == pTmp2);

                pTmp4 = pTmp3.GetNext();
                CHECK(pTmp4 != null);
                CHECK(pTmp4 != pTmp3);
                CHECK(pTmp4.GetNext() == null);
                CHECK(pTmp4.GetPrev() == pTmp3);

                // ------------------------------
                // --   Remove Only: Cat     --
                // ------------------------------
                pMan.Remove(pCat);

                CHECK(pMan.mDeltaGrow == 3);
                CHECK(pMan.mTotalNumNodes == 6);
                CHECK(pMan.mNumReserved == 6);
                CHECK(pMan.mNumActive == 0);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() != null);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp == pCat);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1 == pFish);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pCat);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 != pTmp1);
                CHECK(pTmp2 == pBird);
                CHECK(pTmp2.GetNext() != null);
                CHECK(pTmp2.GetPrev() == pFish);

                pTmp3 = pTmp2.GetNext();
                CHECK(pTmp3 == pDog);
                CHECK(pTmp3 != pTmp2);
                CHECK(pTmp3 != null);
                CHECK(pTmp3.GetNext() != null);
                CHECK(pTmp3.GetPrev() == pBird);

                pTmp4 = pTmp3.GetNext();
                CHECK(pTmp4 != null);
                CHECK(pTmp4 != pTmp3);
                CHECK(pTmp4.GetNext() != null);
                CHECK(pTmp4.GetPrev() == pDog);

                pTmp5 = pTmp4.GetNext();
                CHECK(pTmp5 != null);
                CHECK(pTmp5 != pTmp4);
                CHECK(pTmp5.GetNext() == null);
                CHECK(pTmp5.GetPrev() == pTmp4);

            }
            else
            {
                IGNORE();
            }
        }

        public void Simple_Memory_Pooling()
        {
            if (Manager_Tests_Flags.Simple_Memory_Pooling_Enable)
            {
                Manager pMan = new Manager(3, 2);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 3);
                CHECK(pMan.mNumReserved == 3);
                CHECK(pMan.mNumActive == 0);

                Node pTmp;
                Node pTmp1;
                Node pTmp2;
                Node pTmp3;

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 != pTmp);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pTmp1);

                // ----------------------------
                //     Add 1st node 
                // ----------------------------
                Node pBird = pMan.AddToFront(Node.Name.Bird, 55);
                CHECK(pBird != null);

                CHECK(pMan.GetActive() != null);
                CHECK(pMan.GetReserve() != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 3);
                CHECK(pMan.mNumReserved == 2);
                CHECK(pMan.mNumActive == 1);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);
                CHECK(pTmp == pBird);
                CHECK(pTmp.x == 55);
                CHECK(pTmp.name == Node.Name.Bird);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1.GetNext() == null);
                CHECK(pTmp1.GetPrev() == pTmp);

                // -----------------------------
                //    Add 2nd node 
                // -----------------------------
 
                Node pCat = pMan.AddToFront(Node.Name.Cat, 66);
                CHECK(pCat != null);

                CHECK(pMan.GetActive() != null);
                CHECK(pMan.GetReserve() != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 3);
                CHECK(pMan.mNumReserved == 1);
                CHECK(pMan.mNumActive == 2);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);
                CHECK(pTmp == pCat);
                CHECK(pTmp.x == 66);
                CHECK(pTmp.name == Node.Name.Cat);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 == pBird);
                CHECK(pTmp1.GetNext() == null);
                CHECK(pTmp1.GetPrev() == pTmp);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);

                // --------------------------------
                //    Add 3rd node 
                // --------------------------------
       
                Node pDog = pMan.AddToFront(Node.Name.Dog, 77);
                CHECK(pDog != null);

                CHECK(pMan.GetActive() != null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 3);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 3);

                pTmp = pMan.GetActive();

                CHECK(pTmp != null);
                CHECK(pTmp == pDog);
                CHECK(pTmp.x == 77);
                CHECK(pTmp.name == Node.Name.Dog);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 == pCat);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 == pBird);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pTmp1);

                // ----------------------------
                //     Add 4th node 
                // ----------------------------
    
                Node pFish = pMan.AddToFront(Node.Name.Fish, 88);
                CHECK(pFish != null);

                CHECK(pMan.GetActive() != null);
                CHECK(pMan.GetReserve() != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 5);
                CHECK(pMan.mNumReserved == 1);
                CHECK(pMan.mNumActive == 4);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);
                CHECK(pTmp == pFish);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 == pDog);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 == pCat);
                CHECK(pTmp2.GetNext() != null);
                CHECK(pTmp2.GetPrev() == pTmp1);

                pTmp3 = pTmp2.GetNext();
                CHECK(pTmp3 != null);
                CHECK(pTmp3 == pBird);
                CHECK(pTmp3.GetNext() == null);
                CHECK(pTmp3.GetPrev() == pTmp2);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp.x == 0);
                CHECK(pTmp.name == Node.Name.Unitialized);
                CHECK(pTmp.GetNext() == null);
                CHECK(pTmp.GetPrev() == null);

                // ----------------------------
                //    Remove node 
                // ----------------------------

                pMan.Remove(pCat);

                CHECK(pMan.GetActive() != null);
                CHECK(pMan.GetReserve() != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 5);
                CHECK(pMan.mNumReserved == 2);
                CHECK(pMan.mNumActive == 3);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);
                CHECK(pTmp == pFish);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 == pDog);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);
                CHECK(pTmp.GetNext() == pTmp1);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 == pBird);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pTmp1);
                CHECK(pTmp1.GetNext() == pTmp2);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp == pCat);
                CHECK(pTmp.x == 0);
                CHECK(pTmp.name == Node.Name.Unitialized);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1.x == 0);
                CHECK(pTmp1.name == Node.Name.Unitialized);
                CHECK(pTmp1.GetNext() == null);
                CHECK(pTmp1.GetPrev() == pTmp);
                CHECK(pTmp.GetNext() == pTmp1);

                // ------------------------
                //    Remove node 
                // ------------------------
                pMan.Remove(pBird);

                CHECK(pMan.GetActive() != null);
                CHECK(pMan.GetReserve() != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 5);
                CHECK(pMan.mNumReserved == 3);
                CHECK(pMan.mNumActive == 2);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);
                CHECK(pTmp == pFish);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.name == Node.Name.Fish);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 == pDog);
                CHECK(pTmp1.GetNext() == null);
                CHECK(pTmp1.GetPrev() == pTmp);
                CHECK(pTmp.GetNext() == pTmp1);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp == pBird);
                CHECK(pTmp.x == 0);
                CHECK(pTmp.name == Node.Name.Unitialized);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 == pCat);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);
                CHECK(pTmp.GetNext() == pTmp1);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pTmp1);
                CHECK(pTmp1.GetNext() == pTmp2);

                // -------------------------
                //    add node 
                // -------------------------

                Node pWorm = pMan.AddToFront(Node.Name.Worm, 123);
                CHECK(pWorm != null);

                CHECK(pMan.GetActive() != null);
                CHECK(pMan.GetReserve() != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 5);
                CHECK(pMan.mNumReserved == 2);
                CHECK(pMan.mNumActive == 3);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);
                CHECK(pTmp == pWorm);
                CHECK(pTmp == pBird);
                CHECK(pTmp.x == 123);
                CHECK(pTmp.name == Node.Name.Worm);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 == pFish);
                CHECK(pTmp1.GetNext() != null);
                CHECK(pTmp1.GetPrev() == pTmp);
                CHECK(pTmp.GetNext() == pTmp1);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);
                CHECK(pTmp2 == pDog);
                CHECK(pTmp2.GetNext() == null);
                CHECK(pTmp2.GetPrev() == pTmp1);
                CHECK(pTmp1.GetNext() == pTmp2);

                pTmp = pMan.GetReserve();
                CHECK(pTmp != null);
                CHECK(pTmp == pCat);
                CHECK(pTmp.GetNext() != null);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);
                CHECK(pTmp1 != pTmp);
                CHECK(pTmp1.GetNext() == null);
                CHECK(pTmp1.GetPrev() == pTmp);
                CHECK(pTmp.GetNext() == pTmp1);

            }
            else
            {
                IGNORE();
            }
        }

        public void Simple_Find()
        {
            if (Manager_Tests_Flags.Simple_Find_Enable)
            {
                Manager pMan = new Manager(0, 2);
                CHECK(pMan != null);

                CHECK(pMan.GetActive() == null);
                CHECK(pMan.GetReserve() == null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 0);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 0);

                // -----------------------------
                //    original 
                // -----------------------------
                Node pTmp;
                Node pTmp1;
                Node pTmp2;
                Node pTmp3;

                Node pBird = pMan.AddToFront(Node.Name.Bird, 55);
                CHECK(pBird != null);

                Node pDog = pMan.AddToFront(Node.Name.Dog, 66);
                CHECK(pDog != null);

                Node pFish = pMan.AddToFront(Node.Name.Fish, 77);
                CHECK(pFish != null);

                Node pCat = pMan.AddToFront(Node.Name.Cat, 88);
                CHECK(pCat != null);

                CHECK(pMan.mDeltaGrow == 2);
                CHECK(pMan.mTotalNumNodes == 4);
                CHECK(pMan.mNumReserved == 0);
                CHECK(pMan.mNumActive == 4);

                CHECK(pMan.GetActive() == pCat);
                CHECK(pMan.GetReserve() == null);

                pTmp = pMan.GetActive();
                CHECK(pTmp != null);

                CHECK(pTmp == pCat);
                CHECK(pTmp.name == Node.Name.Cat);
                CHECK(pTmp.x == 88);
                CHECK(pTmp.GetNext() == pFish);
                CHECK(pTmp.GetPrev() == null);

                pTmp1 = pTmp.GetNext();
                CHECK(pTmp1 != null);

                CHECK(pTmp1 == pFish);
                CHECK(pTmp1.name == Node.Name.Fish);
                CHECK(pTmp1.x == 77);
                CHECK(pTmp1.GetNext() == pDog);
                CHECK(pTmp1.GetPrev() == pCat);

                pTmp2 = pTmp1.GetNext();
                CHECK(pTmp2 != null);

                CHECK(pTmp2 == pDog);
                CHECK(pTmp2.name == Node.Name.Dog);
                CHECK(pTmp2.x == 66);
                CHECK(pTmp2.GetNext() == pBird);
                CHECK(pTmp2.GetPrev() == pFish);

                pTmp3 = pTmp2.GetNext();
                CHECK(pTmp3 != null);

                CHECK(pTmp3 == pBird);
                CHECK(pTmp3.name == Node.Name.Bird);
                CHECK(pTmp3.x == 55);
                CHECK(pTmp3.GetNext() == null);
                CHECK(pTmp3.GetPrev() == pDog);

                // ------------------------------
                //    Find (Dog)
                // ------------------------------

                Node pNode;
                pNode = pMan.Find(Node.Name.Dog);
                CHECK(pNode != null);

                CHECK(pNode == pDog);

                // ------------------------------
                //    Find (Fish) 
                // ------------------------------

                pNode = pMan.Find(Node.Name.Fish);
                CHECK(pNode != null);

                CHECK(pNode == pFish);

                // -------------------------------
                //    Find (Worm) 
                // -------------------------------

                pNode = pMan.Find(Node.Name.Worm);
                CHECK(pNode == null);

            }
            else
            {
                IGNORE();
            }
        }
    }

}

// --- End of File ---

