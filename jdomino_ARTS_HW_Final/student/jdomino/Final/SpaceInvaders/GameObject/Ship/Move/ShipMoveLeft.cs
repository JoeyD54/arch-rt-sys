using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMoveLeft : ShipMoveState
    {

        public override void MoveRight(Ship pShip)
        {

        }
        public override void MoveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;
            pShip.SetState(ShipMan.MoveState.MoveBoth);
        }

    }
}