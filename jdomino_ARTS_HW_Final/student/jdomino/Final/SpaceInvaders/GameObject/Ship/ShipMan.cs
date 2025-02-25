﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMan
    {
        public enum MissileState
        {
            Ready,
            Dead,
            Flying
        }

        public enum MoveState
        {
            MoveRight,
            MoveLeft,
            MoveBoth,
            Dead
        }

        private ShipMan()
        {
            // Store the states
            this.pStateMissileReady = new ShipMissileReady();
            this.pStateMissileFlying = new ShipMissileFlying();
            this.pStateMissileDead = new ShipMissileDead();

            this.pStateMoveBoth = new ShipMoveBoth();
            this.pStateMoveRight = new ShipMoveRight();
            this.pStateMoveLeft = new ShipMoveLeft();
            this.pStateMoveDead = new ShipMoveDead();

            // set active
            this.pShip = null;
            this.pMissile = null;
        }

        public static void Create()
        {
            // make sure its the first time
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new ShipMan();
            }

            Debug.Assert(instance != null);

            // Stuff to initialize after the instance was created
            instance.pShip = ActivateShip();
            instance.pShip.SetState(ShipMan.MoveState.MoveBoth);
            instance.pShip.SetState(ShipMan.MissileState.Ready);

        }

        private static ShipMan privInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static Ship GetShip()
        {
            ShipMan pShipMan = ShipMan.privInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }

        public static ShipMissileState GetState(MissileState state)
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            ShipMissileState pShipState = null;

            switch (state)
            {
                case ShipMan.MissileState.Ready:
                    pShipState = pShipMan.pStateMissileReady;
                    break;

                case ShipMan.MissileState.Flying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;
                case ShipMan.MissileState.Dead:
                    pShipState = pShipMan.pStateMissileDead;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }
        public static ShipMoveState GetState(MoveState state)
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            ShipMoveState pShipState = null;

            switch (state)
            {
                case ShipMan.MoveState.MoveBoth:
                    pShipState = pShipMan.pStateMoveBoth;
                    break;

                case ShipMan.MoveState.MoveLeft:
                    pShipState = pShipMan.pStateMoveLeft;
                    break;

                case ShipMan.MoveState.MoveRight:
                    pShipState = pShipMan.pStateMoveRight;
                    break;
                case ShipMan.MoveState.Dead:
                    pShipState = pShipMan.pStateMoveDead;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static Missile GetMissile()
        {
            ShipMan pShipMan = ShipMan.privInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }

        public static Missile ActivateMissile()
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            // No need to re-calling new()
            Missile pMissile = null;
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.Missile);
            if (pGameObjNode == null)
            {
                pMissile = new Missile(Sprite.Name.Missile, 400, 100);
            }
            else
            {
                // Recycle it.
                pMissile = (Missile)pGameObjNode.pGameObject;
                GhostMan.Remove(pGameObjNode);
                // GhostMan.Dump();
                pMissile.Resurrect(400, 100);
            }

            pShipMan.pMissile = pMissile;

            // Attached to SpriteBatches
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

            pMissile.ActivateCollisionSprite(pSB_Boxes);
            pMissile.ActivateSprite(pSB_Aliens);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectNodeMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pShipMan.pMissile);

            return pShipMan.pMissile;
        }


        public static Ship ActivateShip()
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            // LTN - owned by ShipMan.. but needs some cleanup
            Ship pShip = null;
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.Ship);
            if (pGameObjNode == null)
            {
                pShip = new Ship(GameObject.Name.Ship, Sprite.Name.Ship, 400, 100);
                pShip.ActivateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));
                pShipMan.pShip = pShip;
            }
            else
            {
                // Recycle it.
                pShip = (Ship)pGameObjNode.pGameObject;
                GhostMan.Remove(pGameObjNode);
                // GhostMan.Dump();
                pShip.Resurrect();
                pShip.ActivateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));
                pShipMan.pShip = pShip;
            }
            

            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            pSB_Aliens.Attach(pShip);

            // Attach the missile to the missile root
            GameObject pShipRoot = GameObjectNodeMan.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pShipRoot.Add(pShipMan.pShip);

            return pShipMan.pShip;
        }

        // Data: ----------------------------------------------
        private static ShipMan instance = null;

        // Active
        private Ship pShip;
        private Missile pMissile;

        // Reference
        private ShipMissileReady pStateMissileReady;
        private ShipMissileFlying pStateMissileFlying;
        private ShipMissileDead pStateMissileDead;

        private ShipMoveBoth pStateMoveBoth;
        private ShipMoveRight pStateMoveRight;
        private ShipMoveLeft pStateMoveLeft;
        private ShipMoveDead pStateMoveDead;


    }
}