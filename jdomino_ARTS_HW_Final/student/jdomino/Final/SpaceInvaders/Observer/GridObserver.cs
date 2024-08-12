using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GridObserver : ColObserver
    {
        public GridObserver()
        {

        }
        public override void Notify()
        {
            
            Debug.WriteLine("Grid_Observer: {0} {1}", this.pSubject.pGameObjA, this.pSubject.pGameObjB);

            // OK do some magic
            AlienGrid pGrid = (AlienGrid)this.pSubject.pGameObjA;

            WallCategory pWall = (WallCategory)this.pSubject.pGameObjB;
            if (pWall.GetCategoryType() == WallCategory.Type.Right)
            {
                pGrid.SetDelta(-10.0f);
                moveDownRight = true;
                moveDownLeft = false;
            }
            else if (pWall.GetCategoryType() == WallCategory.Type.Left)
            {
                pGrid.SetDelta(10.0f);
                moveDownLeft = true;
                moveDownRight = false;
            }
            else if( pWall.GetCategoryType() == WallCategory.Type.Bottom)
			{
                if(alreadyHitBottom == false)
				{
                    TimerEventMan.RemoveAll();
                    TimerEventMan.Add(TimerEvent.Name.GameOverEvent, new GameOverEvent(), 0);
                    alreadyHitBottom = true;
                }   
                
			}
            else
            {
                Debug.Assert(false);
            }

            //We hit the left wall. move down ONCE
            if(!moveDownRight && moveDownLeft && !alreadyMovedDownLeft)
			{
                //pGrid.MoveGridDown();
                alreadyMovedDownLeft = true;
                alreadyMovedDownRight = false;
                pGrid.moveDown = true;
			}
            //We hit the right wall. move down ONCE
            else if(moveDownRight && !moveDownLeft && !alreadyMovedDownRight)
			{
                //pGrid.MoveGridDown();
                alreadyMovedDownRight = true;
                alreadyMovedDownLeft = false;
                pGrid.moveDown = true;
            }
            else if (!moveDownLeft && !moveDownRight)
			{
                pGrid.moveDown = false;
                alreadyMovedDownLeft = false;
                alreadyMovedDownRight = false;
			}

        }
        private bool moveDownRight = false;
        private bool moveDownLeft = false;
        private bool alreadyMovedDownRight = false;
        private bool alreadyMovedDownLeft = false;
        private bool alreadyHitBottom = false;
    }
}