using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveMissileObserver : ColObserver
    {
        public RemoveMissileObserver()
        {
            this.pMissile = null;
        }
        public RemoveMissileObserver(RemoveMissileObserver m)
        {
            this.pMissile = m.pMissile;
        }
        public override void Notify()
        {
            // Delete missile
            Debug.WriteLine("RemoveMissileObserver: {0} {1}", this.pSubject.pGameObjA, this.pSubject.pGameObjB);

            if(pSubject.pGameObjA.name == GameObject.Name.Missile)
			{
                this.pMissile = (Missile)this.pSubject.pGameObjA;
            }
            else
			{
                this.pMissile = (Missile)this.pSubject.pGameObjB;
            }
            
            Debug.Assert(this.pMissile != null);

            if (pMissile.bMarkForDeath == false)
            {
                pMissile.bMarkForDeath = true;
                //   Delay
                RemoveMissileObserver pObserver = new RemoveMissileObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 
            //SpriteProxy splat = new SpriteProxy();
            //splat.Set(Sprite.Name.MissileExplosion);
            //splat.x = pMissile.x;
            //splat.y = pMissile.y;

            this.pMissile.Remove();

            //SpriteBatch pSpriteBatch = SpriteBatchMan.AddByPriority(SpriteBatch.Name.BigBoomBooms, 10);
            //pSpriteBatch.Attach(splat);

            //TimerEventMan.Add(TimerEvent.Name.RemoveExplosionCommand, new RemoveExplosionCommand(splat), 0.25f);
        }

        // --------------------------------------
        // data:
        // --------------------------------------

        private GameObject pMissile;
    }
}
