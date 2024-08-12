using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipRemoveMissileObserver : ColObserver
    {
        public ShipRemoveMissileObserver()
        {
            this.pMissile = null;
        }

        public ShipRemoveMissileObserver(ShipRemoveMissileObserver m)
        {
            Debug.Assert(m.pMissile != null);
            this.pMissile = m.pMissile;
        }

        public override void Notify()
        {
            // Delete missile
            // Debug.WriteLine("ShipRemoveMissileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            // At this point we have two game objects
            // Actually we can control the objects in the visitor
            // Alphabetical ordering... A is missile,  B is wall

            // This cast will throw an exception if I'm wrong
            Missile pMissile = (Missile)this.pSubject.pGameObjA;

            // Debug.WriteLine("MissileRemoveObserver: --> delete missile {0}", pMissile);

            if (pMissile.bMarkForDeath == false)
            {
                pMissile.bMarkForDeath = true;

                this.pMissile = pMissile;

                // Delay - remove object later
                // TODO - reduce the new functions
                ShipRemoveMissileObserver pObserver = new ShipRemoveMissileObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }

        }

        public override void Execute()
        {
            // Let the gameObject deal with this...             
            SpriteProxy splat = new SpriteProxy();
            splat.Set(Sprite.Name.MissileExplosion);
            splat.x = pMissile.x;
            splat.y = pMissile.y;
            splat.pSprite.SwapColor(1, 0, 0);
            

            this.pMissile.Remove();

            SpriteBatch pSpriteBatch = SpriteBatchMan.AddByPriority(SpriteBatch.Name.BigBoomBooms, 2);
            pSpriteBatch.Attach(splat);

            TimerEventMan.Add(TimerEvent.Name.RemoveExplosionCommand, new RemoveExplosionCommand(splat), 0.15f);
        }

        // data
        private GameObject pMissile;


    }
}