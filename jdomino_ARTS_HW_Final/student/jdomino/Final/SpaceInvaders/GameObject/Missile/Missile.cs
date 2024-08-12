using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class Missile : MissileCategory
	{
        public Missile(Sprite.Name spriteName, float posX, float posY)
            :base(GameObject.Name.Missile, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;

            this.enable = false;
            this.delta = 6.0f;
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 6.0f;
            this.poColObject.pColSprite.SetColor(1, 1, 0);

              base.Resurrect();
        }

        public override void Update()
        {
            base.Update();
            this.y += delta;
        }

        ~Missile()
        {

        }


        public override void Remove()
        {
            // Keenan(delete.E)
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObject.poColRect.Set(0, 0, 0, 0);
            this.x = 0.0f;
            this.y = 0.0f;

            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

		public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction            
            other.VisitMissile(this);
        }

		public override void VisitBombRoot(BombRoot b)
		{
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
		}

		public override void VisitBomb(Bomb b)
		{
            // Crab vs Missile
            Debug.WriteLine("         collide:  {0} <-> {1}", b.name, this.name);

            // Missile vs Squid
            Debug.WriteLine("-------> Done  <--------");

            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }
    

		public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public void SetActive(bool state)
        {
            this.enable = state;
        }

        // Data -------------------------------------
        private bool enable;
        public float delta;


    }
}
