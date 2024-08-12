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
    public class Iterator_Tests : UnitTestBase
    {
        public void Garage_Forward_Empty_Iterator()
        {
            if (Iterator_Tests_Flags.Garage_Forward_Iterator_Empty_Enable)
            {
                Garage pGarage = new Garage();
                CHECK(pGarage != null);

                // ------------------------------------

                // iterator test
                Car_ForwardIterator pIt = new Car_ForwardIterator(pGarage);
                CHECK(pIt != null);

                // -----------------------------------

                Car pTmp = pIt.First();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                bool flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.Next();
                CHECK(pTmp == null);

            }
            else
            {
                IGNORE();
            }
        }
        public void Garage_Forward_Iterator()
        {
            if (Iterator_Tests_Flags.Garage_Forward_Iterator_Enable)
            {
                Garage pGarage = new Garage();
                CHECK(pGarage != null);

                Car pE = new Car(Car.Name.Panda, 77);
                CHECK(pE != null);

                Car pD = new Car(Car.Name.Kona, 33);
                CHECK(pD != null);

                Car pC = new Car(Car.Name.Jetta, 88);
                CHECK(pC != null);

                Car pB = new Car(Car.Name.Civic, 22);
                CHECK(pB != null);

                Car pA = new Car(Car.Name.Nexon, 99);
                CHECK(pA != null);

                pGarage.Add(pE);
                pGarage.Add(pD);
                pGarage.Add(pC);
                pGarage.Add(pB);
                pGarage.Add(pA);
                
                // ------------------------------------

                // iterator test
                Car_ForwardIterator pIt = new Car_ForwardIterator(pGarage);
                CHECK(pIt != null);

                // -----------------------------------

                Car pTmp = pIt.First();
                CHECK(pTmp == pA);

                pTmp = pIt.Current();
                CHECK(pTmp == pA);

                bool flag = pIt.IsDone();
                CHECK(flag == false);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pB);

                pTmp = pIt.Current();
                CHECK(pTmp == pB);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pA);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pC);

                pTmp = pIt.Current();
                CHECK(pTmp == pC);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pA);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pD);

                pTmp = pIt.Current();
                CHECK(pTmp == pD);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pA);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pE);

                pTmp = pIt.Current();
                CHECK(pTmp == pE);

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.First();
                CHECK(pTmp == pA);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.First();
                CHECK(pTmp == pA);

            }
            else
            {
                IGNORE();
            }
        }
        public void Garage_Reverse_Empty_Iterator()
        {
            if (Iterator_Tests_Flags.Garage_Reverse_Iterator_Empty_Enable)
            {
                Garage pGarage = new Garage();
                CHECK(pGarage != null);

                // ------------------------------------

                // iterator test
                Car_ReverseIterator pIt = new Car_ReverseIterator(pGarage);
                CHECK(pIt != null);

                // -----------------------------------

                Car pTmp = pIt.First();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                bool flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.Next();
                CHECK(pTmp == null);

            }
            else
            {
                IGNORE();
            }
        }
        public void Garage_Reverse_Iterator()
        {
            if (Iterator_Tests_Flags.Garage_Reverse_Iterator_Enable)
            {
                Garage pGarage = new Garage();
                CHECK(pGarage != null);

                Car pE = new Car(Car.Name.Panda, 77);
                CHECK(pE != null);

                Car pD = new Car(Car.Name.Kona, 33);
                CHECK(pD != null);

                Car pC = new Car(Car.Name.Jetta, 88);
                CHECK(pC != null);

                Car pB = new Car(Car.Name.Civic, 22);
                CHECK(pB != null);

                Car pA = new Car(Car.Name.Nexon, 99);
                CHECK(pA != null);

                pGarage.Add(pE);
                pGarage.Add(pD);
                pGarage.Add(pC);
                pGarage.Add(pB);
                pGarage.Add(pA);

                // ------------------------------------

                // iterator test
                Car_ReverseIterator pIt = new Car_ReverseIterator(pGarage);
                CHECK(pIt != null);

                // -----------------------------------

                Car pTmp = pIt.First();
                CHECK(pTmp == pE);

                pTmp = pIt.Current();
                CHECK(pTmp == pE);

                bool flag = pIt.IsDone();
                CHECK(flag == false);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pD);

                pTmp = pIt.Current();
                CHECK(pTmp == pD);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pE);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pC);

                pTmp = pIt.Current();
                CHECK(pTmp == pC);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pE);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pB);

                pTmp = pIt.Current();
                CHECK(pTmp == pB);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pE);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pA);

                pTmp = pIt.Current();
                CHECK(pTmp == pA);

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.First();
                CHECK(pTmp == pE);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.First();
                CHECK(pTmp == pE);

            }
            else
            {
                IGNORE();
            }
        }

        public void Amazon_Forward_Iterator()
        {
            if (Iterator_Tests_Flags.Amazon_Forward_Iterator_Enable)
            {
                Amazon pAmazon = new Amazon();
                CHECK(pAmazon != null);

                Box pA = pAmazon.Add(Box.Name.WineGlass, 11);
                CHECK(pA != null);
                Box pB = pAmazon.Add(Box.Name.Parachute, 22);
                CHECK(pB != null);
                Box pC = pAmazon.Add(Box.Name.Vitamins, 33);
                CHECK(pC != null);
                Box pD = pAmazon.Add(Box.Name.Coffee, 44);
                CHECK(pD != null);

                Box pE = pAmazon.Add(Box.Name.Book, 55);
                CHECK(pE != null);
                Box pF = pAmazon.Add(Box.Name.BirdSeed, 66);
                CHECK(pF != null);
                Box pG = pAmazon.Add(Box.Name.AcientAlienPoster, 77);
                CHECK(pG != null);
                Box pH = pAmazon.Add(Box.Name.BirdSeed, 88);
                CHECK(pH != null);

                Box pI = pAmazon.Add(Box.Name.Corkscrew, 99);
                CHECK(pI != null);
                Box pJ = pAmazon.Add(Box.Name.Masks, 111);
                CHECK(pJ != null);
                Box pK = pAmazon.Add(Box.Name.Dogfood, 222);
                CHECK(pK != null);

                // Deliveries
                pF.Delivered();
                pA.Delivered();

                // ------------------------------------

                // iterator test
                Box_ForwardIterator pIt = new Box_ForwardIterator(pAmazon);
                CHECK(pIt != null);

                // -----------------------------------

                Box pTmp = pIt.First();
                CHECK(pTmp == pI);

                pTmp = pIt.Current();
                CHECK(pTmp == pI);

                bool flag = pIt.IsDone();
                CHECK(flag == false);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pJ);

                pTmp = pIt.Current();
                CHECK(pTmp == pJ);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pK);

                pTmp = pIt.Current();
                CHECK(pTmp == pK);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pE);

                pTmp = pIt.Current();
                CHECK(pTmp == pE);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pG);

                pTmp = pIt.Current();
                CHECK(pTmp == pG);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pH);

                pTmp = pIt.Current();
                CHECK(pTmp == pH);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pB);

                pTmp = pIt.Current();
                CHECK(pTmp == pB);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pI);


                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pC);

                pTmp = pIt.Current();
                CHECK(pTmp == pC);

                flag = pIt.IsDone();
                CHECK(flag == false);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == pD);

                pTmp = pIt.Current();
                CHECK(pTmp == pD);

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

                // -----------------------------------

                pTmp = pIt.Next();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.First();
                CHECK(pTmp == pI);

            }
                else
            {
                IGNORE();
            }
        }

        public void Amazon_Forward_Empty_Iterator()
        {
            if (Iterator_Tests_Flags.Amazon_Forward_Iterator_Empty_Enable)
            {
                Amazon pAmazon = new Amazon();
                CHECK(pAmazon != null);

                // ------------------------------------

                // iterator test
                Box_ForwardIterator pIt = new Box_ForwardIterator(pAmazon);
                CHECK(pIt != null);

                // -----------------------------------

                Box pTmp = pIt.First();
                CHECK(pTmp == null);

                pTmp = pIt.Current();
                CHECK(pTmp == null);

                bool flag = pIt.IsDone();
                CHECK(flag == true);

                pTmp = pIt.Next();
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

