using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipMoveState
    {
        public abstract void MoveRight(Ship pShip);
        public abstract void MoveLeft(Ship pShip);
    }
}