using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMissileReady : ShipMissileState
    {

        public override void ShootMissile(Ship pShip)
        {
            SoundManager.PlaySound("shoot.wav");
            Missile pMissile = ShipMan.ActivateMissile();
            pMissile.SetPos(pShip.x, pShip.y + 20);

            pShip.SetState(ShipMan.MissileState.Flying);
        }

    }
}