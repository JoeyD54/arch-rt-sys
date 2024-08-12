using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMoveRight : ShipMoveState
    {

        public override void MoveRight(Ship pShip)
        {
            pShip.x += pShip.shipSpeed;
            pShip.SetState(ShipMan.MoveState.MoveBoth);
        }
        public override void MoveLeft(Ship pShip)
        {

        }

    }
}