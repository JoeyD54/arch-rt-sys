using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMoveObserver : ColObserver
    {
        public override void Notify()
        {
            Ship pShip = ShipMan.GetShip();

            BumperCategory pBumper = (BumperCategory)this.pSubject.pGameObjA;
            if (pBumper.GetCategoryType() == BumperCategory.Type.Left)
            {
                pShip.SetState(ShipMan.MoveState.MoveRight);
            }
            else if (pBumper.GetCategoryType() == BumperCategory.Type.Right)
            {
                pShip.SetState(ShipMan.MoveState.MoveLeft);
            }
        }
    }

    // data
}
