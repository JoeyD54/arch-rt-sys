using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombSpawnEvent : CommandBase
    {
        public BombSpawnEvent(Random pRandom)
        {
            this.pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            Debug.Assert(this.pSB_Aliens != null);

            this.pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.pRandom = pRandom;
        }

        override public void Execute(float deltaTime)
        {
            //We got the alien grid
            AlienGrid pGrid = (AlienGrid)GameObjectNodeMan.Find(GameObject.Name.AlienGrid);

            int alienCount = pGrid.GetAlienCount();

            //Only spawn bombs if we have aliens to spawn from
            if (alienCount > 0)
            {
                //got first column
                AlienColumn pColumn = (AlienColumn)IteratorForwardComposite.GetChild(pGrid);

                int randomCol = pRandom.Next(0, pGrid.GetNumChildren());

                for (int i = 0; i < pGrid.GetNumChildren(); i++)
                {
                    //Ladies and genltemen, we got him.
                    if (i == randomCol)
                    {
                        break;
                    }

                    //Go to next column in list
                    pColumn = (AlienColumn)pColumn.pNext;
                }

                GameObject pAlien = (GameObject)IteratorForwardComposite.GetChild(pColumn);

                // Create Bomb
                float xLoc = pAlien.x;
                float yLoc = pAlien.y - 40;

                float spawnNum = pRandom.Next(1, 4);

                Bomb pBomb;
                BombAnimCommand pBombAnim;

                switch (spawnNum)
                {
                    case 1:
                        pBomb = new Bomb(GameObject.Name.Bomb, Sprite.Name.BombStraight, new FallStraight(), xLoc, yLoc);

                        // --- BombStraight --- //

                        pBombAnim = new BombAnimCommand(Sprite.Name.BombStraight);
                        pBombAnim.Attach(Image.Name.BombStraight);
                        pBombAnim.Attach(Image.Name.BombStraight1);
                        pBombAnim.Attach(Image.Name.BombStraight2);
                        pBombAnim.Attach(Image.Name.BombStraight3);



                        break;
                    case 2:
                        pBomb = new Bomb(GameObject.Name.Bomb, Sprite.Name.BombDagger, new FallDagger(), xLoc, yLoc);
                        // --- BombDagger --- //

                        pBombAnim = new BombAnimCommand(Sprite.Name.BombDagger);
                        pBombAnim.Attach(Image.Name.BombDagger1);
                        pBombAnim.Attach(Image.Name.BombDagger2);
                        pBombAnim.Attach(Image.Name.BombDagger3);
                        pBombAnim.Attach(Image.Name.BombDagger);

                        break;
                    case 3:
                        pBomb = new Bomb(GameObject.Name.Bomb, Sprite.Name.BombZigZag, new FallZigZag(), xLoc, yLoc);


                        //--- BombZigZag --- //

                        pBombAnim = new BombAnimCommand(Sprite.Name.BombZigZag);
                        pBombAnim.Attach(Image.Name.BombZigZag1);
                        pBombAnim.Attach(Image.Name.BombZigZag2);
                        pBombAnim.Attach(Image.Name.BombZigZag3);
                        pBombAnim.Attach(Image.Name.BombZigZag);

                        break;
                    default:
                        pBomb = new Bomb(GameObject.Name.Bomb, Sprite.Name.BombStraight, new FallStraight(), xLoc, yLoc);

                        // --- BombStraight --- //

                        pBombAnim = new BombAnimCommand(Sprite.Name.BombStraight);
                        pBombAnim.Attach(Image.Name.BombStraight1);
                        pBombAnim.Attach(Image.Name.BombStraight2);
                        pBombAnim.Attach(Image.Name.BombStraight3);
                        pBombAnim.Attach(Image.Name.BombStraight);

                        break;
                }

                // Attach the missile to the Bomb root
                GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
                Debug.Assert(pBombRoot != null);

                // Add to GameObject Tree - {update and collisions}
                pBombRoot.Add(pBomb);

                pBomb.ActivateCollisionSprite(pSB_Boxes);
                pBomb.ActivateSprite(pSB_Aliens);

                TimerEventMan.Add(TimerEvent.Name.BombAnimation, pBombAnim, 0.1f);

                spawnNum = pRandom.Next(1, 2);
                //spawnNum *= 0.8f;
                TimerEventMan.Add(TimerEvent.Name.BombSpawnEvent, this, spawnNum);
            }

        }

        GameObject pBombRoot;
        SpriteBatch pSB_Aliens;
        SpriteBatch pSB_Boxes;
        Random pRandom;
    }
}
