using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveBombObserver : ColObserver
    {
        public RemoveBombObserver()
        {
            this.pBomb = null;
        }
        public RemoveBombObserver(RemoveBombObserver b)
        {
            this.pBomb = b.pBomb;
        }
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveBombObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.pBomb = (Bomb)this.pSubject.pGameObjA;
            Debug.Assert(this.pBomb != null);

            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                //   Delay
                RemoveBombObserver pObserver = new RemoveBombObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 
            SpriteProxy splat = new SpriteProxy();
            splat.Set(Sprite.Name.BombExplosion);
            splat.x = pBomb.x;
            splat.y = pBomb.y;


            TimerEvent eventToRemove = TimerEventMan.Find(TimerEvent.Name.BombAnimation);            
            
            if(eventToRemove != null)
			{
                TimerEventMan.Remove(eventToRemove);
			}

            this.pBomb.Remove();

            //pBomb.Resurrect();

            SpriteBatch pSpriteBatch = SpriteBatchMan.AddByPriority(SpriteBatch.Name.BigBoomBooms, 6);
            pSpriteBatch.Attach(splat);

            TimerEventMan.Add(TimerEvent.Name.RemoveExplosionCommand, new RemoveExplosionCommand(splat), 0.15f);
            
        }

        // --------------------------------------
        // data:
        // --------------------------------------

        private GameObject pBomb;
    }
}
