using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipMissileState
    {
        // Transitions to correct state
        public abstract void ShootMissile(Ship pShip);
    }
}