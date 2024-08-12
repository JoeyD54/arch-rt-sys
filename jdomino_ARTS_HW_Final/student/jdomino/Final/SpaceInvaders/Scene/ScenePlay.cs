using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ScenePlay : SceneState
    {
        public ScenePlay()
        {
            this.Initialize();
        }

        //---------------------------------------------------------------------------------------------------------
        // Load the Textures
        //---------------------------------------------------------------------------------------------------------
        public override void Initialize()
        {
            timesWon = 0;
            //bGameOver = false;
            pRandom = new Random();

            TextureMan.Add(Texture.Name.Aliens, "Aliens.tga");
            TextureMan.Add(Texture.Name.Shields, "SpaceInvaders.tga");
            TextureMan.Add(Texture.Name.Bombs, "SpaceInvaders.tga");
            TextureMan.Add(Texture.Name.Ship, "SpaceInvaders.tga");

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------

            // --- Aliens --- //

            ImageMan.Add(Image.Name.AlienUFO, Texture.Name.Bombs, 99, 4, 16, 7);
            ImageMan.Add(Image.Name.AlienUFODead, Texture.Name.Bombs, 118, 3, 21, 8);
            ImageMan.Add(Image.Name.AlienSquid, Texture.Name.Aliens, 460, 58, 84, 72);
            ImageMan.Add(Image.Name.AlienSquid2, Texture.Name.Aliens, 365, 58, 84, 72);
            ImageMan.Add(Image.Name.AlienCrabUp, Texture.Name.Aliens, 245, 61, 96, 72);
            ImageMan.Add(Image.Name.AlienCrabDown, Texture.Name.Aliens, 130, 61, 96, 72);
            ImageMan.Add(Image.Name.AlienOctopusClosed, Texture.Name.Aliens, 550, 57, 106, 77);
            ImageMan.Add(Image.Name.AlienOctopusOpen, Texture.Name.Aliens, 22, 194, 106, 77);
            ImageMan.Add(Image.Name.AlienDead, Texture.Name.Aliens, 490, 488, 74, 47);

            // --- Missile and Ship --- //

            ImageMan.Add(Image.Name.Missile, Texture.Name.Ship, 3, 29, 1, 4);
            ImageMan.Add(Image.Name.MissileExplosion, Texture.Name.Ship, 7, 25, 8, 8);
            ImageMan.Add(Image.Name.Ship, Texture.Name.Aliens, 240, 490, 61, 45);
            ImageMan.Add(Image.Name.ShipDead1, Texture.Name.Ship, 20, 14, 16, 8);
            ImageMan.Add(Image.Name.ShipDead2, Texture.Name.Ship, 38, 14 , 16, 8);

            // --- Bombs --- //            

            ImageMan.Add(Image.Name.BombStraight, Texture.Name.Bombs, 65, 26, 3, 7);
            ImageMan.Add(Image.Name.BombStraight1,Texture.Name.Bombs, 70, 26, 3, 7);
            ImageMan.Add(Image.Name.BombStraight2, Texture.Name.Bombs, 75, 26, 3, 7);
            ImageMan.Add(Image.Name.BombStraight3, Texture.Name.Bombs, 80, 26, 3, 7);

            ImageMan.Add(Image.Name.BombZigZag, Texture.Name.Bombs, 18, 26, 3, 7);
            ImageMan.Add(Image.Name.BombZigZag1, Texture.Name.Bombs, 24, 26, 3, 7);
            ImageMan.Add(Image.Name.BombZigZag2, Texture.Name.Bombs, 30, 26, 3, 7);
            ImageMan.Add(Image.Name.BombZigZag3, Texture.Name.Bombs, 36, 26, 3, 7);

            ImageMan.Add(Image.Name.BombDagger, Texture.Name.Bombs, 42, 27, 3, 6);
            ImageMan.Add(Image.Name.BombDagger1, Texture.Name.Bombs, 48, 27, 3, 6);
            ImageMan.Add(Image.Name.BombDagger2, Texture.Name.Bombs, 54, 27, 3, 6);
            ImageMan.Add(Image.Name.BombDagger3, Texture.Name.Bombs, 60, 27, 3, 6);

            ImageMan.Add(Image.Name.BombExplosion, Texture.Name.Bombs, 86, 25, 6, 8);            

            // --- Bricks --- //

            ImageMan.Add(Image.Name.BrickLeft_Top0, Texture.Name.Shields, 116, 31, 2, 2);
            ImageMan.Add(Image.Name.BrickLeft_Top1, Texture.Name.Shields, 114, 33, 2, 2);
            ImageMan.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Shields, 120, 43, 2, 2);
            ImageMan.Add(Image.Name.BrickLeft_BottomHalfVert, Texture.Name.Shields, 118, 45, 2, 2);
            ImageMan.Add(Image.Name.BrickRight_Top0, Texture.Name.Shields, 132, 31, 2, 2);
            ImageMan.Add(Image.Name.BrickRight_Top1, Texture.Name.Shields, 134, 33, 2, 2);
            ImageMan.Add(Image.Name.BrickRight_Bottom, Texture.Name.Shields, 127, 43, 2, 2);
            ImageMan.Add(Image.Name.BrickRight_BottomHalfVert, Texture.Name.Shields, 129, 45, 2, 2);
            ImageMan.Add(Image.Name.Brick, Texture.Name.Shields, 114, 35, 2, 2);

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------         

            // --- Custom Colors --- //

            Azul.Color Green = new Azul.Color(0.2f, 0.8f, 0.2f);

            // --- Aliens --- //

            SpriteMan.Add(Sprite.Name.AlienSquid, Image.Name.AlienSquid, 50, 500, 45, 35);
            SpriteMan.Add(Sprite.Name.AlienCrab, Image.Name.AlienCrabDown, 300, 400, 50, 35);
            SpriteMan.Add(Sprite.Name.AlienOctopus, Image.Name.AlienOctopusClosed, 600, 300, 50, 35);
            SpriteMan.Add(Sprite.Name.AlienDead, Image.Name.AlienDead, 300, 400, 50, 35);

            // --- UFO --- //

            SpriteMan.Add(Sprite.Name.AlienUFO, Image.Name.AlienUFO, 300, 400, 80, 30);
            SpriteMan.Add(Sprite.Name.AlienUFODead, Image.Name.AlienUFODead, 300, 400, 80, 30);

            // --- Ship and Missile --- //

            SpriteMan.Add(Sprite.Name.Missile, Image.Name.Missile, 0, 0, 5, 40);
            SpriteMan.Add(Sprite.Name.MissileExplosion, Image.Name.MissileExplosion, 0, 0, 30, 30);
            SpriteMan.Add(Sprite.Name.Ship, Image.Name.Ship, 500, 100, 80, 28, Green);
            //SpriteMan.Add(Sprite.Name.Wall, Image.Name.Wall, 448, 900, 850, 30);

            // --- Bombs --- //

            SpriteMan.Add(Sprite.Name.BombStraight, Image.Name.BombStraight, 100, 100, 10, 30);
            SpriteMan.Add(Sprite.Name.BombZigZag, Image.Name.BombZigZag, 200, 200, 10, 30);
            SpriteMan.Add(Sprite.Name.BombDagger, Image.Name.BombDagger, 100, 100, 10, 30);
            SpriteMan.Add(Sprite.Name.BombExplosion, Image.Name.BombExplosion, 100, 100, 15, 20);

            // --- Bricks for shield --- // 

            SpriteMan.Add(Sprite.Name.Brick, Image.Name.Brick, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_LeftBottomHalfVert, Image.Name.BrickLeft_BottomHalfVert, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 25, 18, 20, 10, Green);
            SpriteMan.Add(Sprite.Name.Brick_RightBottomHalfVert, Image.Name.BrickRight_BottomHalfVert, 25, 18, 20, 10, Green);

            //---------------------------------------------------------------------------------------------------------
            // Create BoxSprites
            //---------------------------------------------------------------------------------------------------------

            //SpriteBoxMan.Add(SpriteBox.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            //SpriteBoxMan.Add(SpriteBox.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            //---------------------------------------------------------------------------------------------------------
            // Create SpriteBatch
            //---------------------------------------------------------------------------------------------------------

            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);         
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poFontMan = new FontMan(3, 1);
            FontMan.SetActive(this.poFontMan);

            

            SpriteBatch pSB_Aliens = SpriteBatchMan.AddByPriority(SpriteBatch.Name.Aliens, 10);
            SpriteBatch pSB_Shields = SpriteBatchMan.AddByPriority(SpriteBatch.Name.Shields, 8);
            SpriteBatch pSB_Box = SpriteBatchMan.AddByPriority(SpriteBatch.Name.Boxes, 5);

            SpriteBatch livesBatch = SpriteBatchMan.Add(SpriteBatch.Name.Player1);
            livesBatch.Attach(SpriteMan.Add(Sprite.Name.ShipLife1, Image.Name.Ship, 120, 40, 80, 38, Green));
            livesBatch.Attach(SpriteMan.Add(Sprite.Name.ShipLife2, Image.Name.Ship, 220, 40, 80, 38, Green));            

            //SpriteBatch livesBatch2 = SpriteBatchMan.Add(SpriteBatch.Name.Player2);
            //livesBatch2.Attach(SpriteMan.Add(Sprite.Name.ShipLife1, Image.Name.Ship, 120, 40, 80, 38, Green));
            //livesBatch2.Attach(SpriteMan.Add(Sprite.Name.ShipLife2, Image.Name.Ship, 220, 40, 80, 38, Green));

            //livesBatch2.SetDrawEnable(false);

            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------

            InputSubject pInputSubject;
            pInputSubject = InputMan.GetArrowRightSubject();
            pInputSubject.Attach(new MoveRightObserver());

            pInputSubject = InputMan.GetArrowLeftSubject();
            pInputSubject.Attach(new MoveLeftObserver());

            pInputSubject = InputMan.GetSpaceSubject();
            pInputSubject.Attach(new ShootObserver());

            Simulation.SetState(Simulation.State.Realtime);


            //---------------------------------------------------------------------------------------------------------
            // Bomb
            //---------------------------------------------------------------------------------------------------------
            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, Sprite.Name.Null_Object, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(pSB_Box);

            GameObjectNodeMan.Attach(pBombRoot);

            //---------------------------------------------------------------------------------------------------------
            // Walls
            //---------------------------------------------------------------------------------------------------------

            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, Sprite.Name.Null_Object, 600.0f, 0.0f);
            pWallGroup.ActivateSprite(pSB_Aliens);
            pWallGroup.ActivateCollisionSprite(pSB_Box);
            //pWallGroup.ActivateCollisionSprite(pSB_Birds);

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, Sprite.Name.Null_Object, 400, 1000, 1000, 110);
            pWallTop.ActivateCollisionSprite(pSB_Box);

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, Sprite.Name.Null_Object, 400, 40, 1000, 30);
            pWallBottom.ActivateCollisionSprite(pSB_Box);
            //pWallBottom.ActivateSprite(pSB_Aliens);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, Sprite.Name.Null_Object, 5, 560, 4, 1000);
            pWallLeft.ActivateCollisionSprite(pSB_Box);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, Sprite.Name.Null_Object, 910, 560, 30, 1000);
            pWallRight.ActivateCollisionSprite(pSB_Box);


            // Add to the composite the children
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);
            pWallGroup.Add(pWallLeft);
            pWallGroup.Add(pWallRight);

            GameObjectNodeMan.Attach(pWallGroup);

			//---------------------------------------------------------------------------------------------------------
			// Bumper
			//---------------------------------------------------------------------------------------------------------

			BumperRoot pBumperRoot = new BumperRoot(GameObject.Name.BumperRoot, Sprite.Name.Null_Object, 0.0f, 0.0f);
			pWallGroup.ActivateSprite(pSB_Box);

			BumperRight pBumperRight = new BumperRight(GameObject.Name.BumperRight, Sprite.Name.Null_Object, 900, 100, 50, 100);
			pBumperRight.ActivateCollisionSprite(pSB_Box);

			BumperLeft pBumperLeft = new BumperLeft(GameObject.Name.BumperLeft, Sprite.Name.Null_Object, 5, 100, 50, 100);
			pBumperLeft.ActivateCollisionSprite(pSB_Box);

			// Add to the composite the children
			pBumperRoot.Add(pBumperRight);
			pBumperRoot.Add(pBumperLeft);

			GameObjectNodeMan.Attach(pBumperRoot);

            //---------------------------------------------------------------------------------------------------------
            // Missile
            //---------------------------------------------------------------------------------------------------------

            MissileGroup pMissileGroup = new MissileGroup();
            pMissileGroup.ActivateSprite(pSB_Aliens);
            pMissileGroup.ActivateCollisionSprite(pSB_Box);

            GameObjectNodeMan.Attach(pMissileGroup);

            //---------------------------------------------------------------------------------------------------------
            // Ship
            //---------------------------------------------------------------------------------------------------------

            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, Sprite.Name.Null_Object, 0.0f, 0.0f);
            GameObjectNodeMan.Attach(pShipRoot);

            ShipMan.Create();

			//---------------------------------------------------------------------------------------------------------
			// Shield 
			//---------------------------------------------------------------------------------------------------------

			GameObject pShieldRoot = ShieldFactory.CreateSingleShield(100, 200, true, GameObject.Name.ShieldGrid);
			ShieldFactory.CreateSingleShield(295, 200, true, GameObject.Name.ShieldGrid1);
			ShieldFactory.CreateSingleShield(485, 200, true, GameObject.Name.ShieldGrid2);
			ShieldFactory.CreateSingleShield(680, 200, true, GameObject.Name.ShieldGrid3);

			GameObjectNodeMan.Attach(pShieldRoot);			
			//GameObjectNodeMan.Attach(pShieldRoot3);
			//GameObjectNodeMan.Attach(pShieldRoot4);

			//---------------------------------------------------------------------------------------------------------
			// Create Animation Commands
			//---------------------------------------------------------------------------------------------------------

			// --- Squids --- //

			//LTN - TimerEventManager
			pSquidAnim = new AnimCommand(Sprite.Name.AlienSquid, timesWon);
            pSquidAnim.Attach(Image.Name.AlienSquid);
            pSquidAnim.Attach(Image.Name.AlienSquid2);

            //--- Crabs --- //

            //LTN - TimerEventManager
            pCrabAnim = new AnimCommand(Sprite.Name.AlienCrab, timesWon);
            pCrabAnim.Attach(Image.Name.AlienCrabDown);
            pCrabAnim.Attach(Image.Name.AlienCrabUp);

            // --- Octopus --- //

            //LTN - TimerEventManager
            pOctoAnim = new AnimCommand(Sprite.Name.AlienOctopus, timesWon);
            pOctoAnim.Attach(Image.Name.AlienOctopusClosed);
            pOctoAnim.Attach(Image.Name.AlienOctopusOpen);

            // --- Ship Killed --- //
            pShipDeadAnim = new AnimCommand(Sprite.Name.Ship, timesWon);
			pShipDeadAnim.Attach(Image.Name.ShipDead2);
			pShipDeadAnim.Attach(Image.Name.ShipDead1);

            // --- UFO Spawn --- //
            //pUFOSpawnCmd = new TimedUFOSpawn();

			//---------------------------------------------------------------------------------------------------------
			// Create Factory
			//---------------------------------------------------------------------------------------------------------

			//STN - Alien factory is only used here to build the grid
			AlienFactory AlienFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);

            //---------------------------------------------------------------------------------------------------------
            // Create Alien Grid and Columns
            //---------------------------------------------------------------------------------------------------------

            //LTN - GameObjectNodeManager
            pAlienGrid = (AlienGrid)AlienFactory.Create(AlienBase.Type.Grid);
            GameObjectNodeMan.Attach((GameObject)pAlienGrid);

            //---------------------------------------------------------------------------------------------------------
            // Create Alien Grid
            //---------------------------------------------------------------------------------------------------------
            
            float xStatic = 66.0f;
            float xSpaceBetween = 0.0f;
            float ySpaceBetween = 66.0f;

			for (int i = 0; i < 11; i++)
			{
				xSpaceBetween = xStatic * i;

				AlienColumn pAlienColumn = AlienFactory.CreateAlienColumn(60.0f, 825.0f, xSpaceBetween, ySpaceBetween);


				pAlienGrid.Add(pAlienColumn);
			}



			//---------------------------------------------------------------------------------------------------------
			// Add grid movement to TimerEventManager
			//---------------------------------------------------------------------------------------------------------

			//LTN - TimerEventManager
			pAlienGridMoveCmd = new MoveCommand(timesWon);


            pBombSpawnEvent = new BombSpawnEvent(pRandom);


            //---------------------------------------------------------------------------------------------------------
            // ColPair
            //---------------------------------------------------------------------------------------------------------
            ColPair pColPair;

            //Missile Vs WallGroup (Will only hit top)
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallGroup);
            pColPair.Attach(new ShipRemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());

            //Missile Vs Alien
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Missile, pMissileGroup, pAlienGrid);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());
            pColPair.Attach(new RemoveAlienObserver());

            //AlienGrid vs ShieldRoot
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Shield, pAlienGrid, pShieldRoot);
            pColPair.Attach(new RemoveBrickObserver());

            //Grid vs Wall
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Wall, pWallGroup, pAlienGrid);
            pColPair.Attach(new GridObserver());

            //Grid vs Shield
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Shield, pAlienGrid, pShieldRoot);
            pColPair.Attach(new RemoveBrickObserver());

			//Bomb vs Bottom
			pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
			pColPair.Attach(new RemoveBombObserver());

			// Bomb vs Shield
			pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
			pColPair.Attach(new RemoveBombObserver());
			pColPair.Attach(new RemoveBrickObserver());

			// Missile vs Shield
			pColPair = ColPairMan.Add(ColPair.Name.Missile_Shield, pMissileGroup, pShieldRoot);
			pColPair.Attach(new RemoveMissileObserver());
			pColPair.Attach(new RemoveBrickObserver());
			pColPair.Attach(new ShipReadyObserver());

			// Bumper vs Ship
			pColPair = ColPairMan.Add(ColPair.Name.Bumper_Ship, pBumperRoot, pShipRoot);
			pColPair.Attach(new ShipMoveObserver());

            // Bomb vs Ship
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Ship, pBombRoot, pShipRoot);
            pColPair.Attach(new RemoveShipObserver());
            pColPair.Attach(new RemoveBombObserver());

			// Bomb vs Missile
			pColPair = ColPairMan.Add(ColPair.Name.Bomb_Missile, pBombRoot, pMissileGroup);
			pColPair.Attach(new RemoveMissileObserver());
			pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new ShipReadyObserver());

            pColPair = ColPairMan.Add(ColPair.Name.Alien_Ship, pAlienGrid, pShipRoot);
            pColPair.Attach(new RemoveShipObserver());
            pColPair.Attach(new ShipReadyObserver());


			//---------------------------------------------------------------------------------------------------------
			// Add Anims to Timer Event Manger List
			//---------------------------------------------------------------------------------------------------------
			SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);
			FontMan.Add(Font.Name.Scoreboard, SpriteBatch.Name.Texts, "SCORE < 1 >   HIGH-SCORE   SCORE < 2 >", Glyph.Name.Consolas36pt, 90, 1000);
			FontMan.Add(Font.Name.Player1Score, SpriteBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 690, 960);


			FontMan.Add(Font.Name.TestOneOff, SpriteBatch.Name.Texts, "CREDIT 01", Glyph.Name.Consolas36pt, 600, 22);

			FontMan.Add(Font.Name.LifeCount, SpriteBatch.Name.Texts, "3", Glyph.Name.Consolas36pt, 10, 35);

			UpdateScoreCommand Score = new UpdateScoreCommand(0);
			TimerEventMan.Add(TimerEvent.Name.UpdateScoreCommand, Score, 0);


			//UpdateScoreCommand score = new UpdateScoreCommand(0);
			//TimerEventMan.Add(TimerEvent.Name.UpdateScoreCommand, score, 0);




			//---------------------------------------------------------------------------------------------------------
			// Dump Grid
			//---------------------------------------------------------------------------------------------------------

			Debug.WriteLine("\n");
            Debug.WriteLine("Iterator...\n");

            //STN - This is just to display grid information before running
            IteratorForwardComposite pIterator = new IteratorForwardComposite(pAlienGrid);

            Component pNode = pIterator.First();

            while (!pIterator.IsDone())
            {
                pNode.Dump();
                pNode = pIterator.Next();
            }

            SpriteBoxMan.Dump();


            //TURNED OFF BOXES ON BOOT
            SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            pSB.SetDrawEnable(false);
        }
    

//-----------------------------------------------------------------------------
// Game::Update()
//      Called once per frame, update data, tranformations, etc
//      Use this function to control process order
//      Input, AI, Physics, Animation, and Graphics
//-----------------------------------------------------------------------------

        public override void Update(float systemTime)
        {

            //TODO test pausing and resetting lives on death.
            //TODO test pausing and setting 2nd level on win
            //TODO test pausing and playing game over scene on last life death
            //TODO after x time, go back to scene select screen
            //  Reset player score, keep high score
            //  reset level to level 1
            
            
            Simulation.Update(systemTime);

            SoundManager.sndEngine.Update();


            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_R) == true)
            {
                GhostMan.Dump();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_C) == true)
            {
                //ShieldFactory.CreateSingleShield(100, 200, false, GameObject.Name.ShieldGrid);
                //ShieldFactory.CreateSingleShield(295, 200, false, GameObject.Name.ShieldGrid1);
                //ShieldFactory.CreateSingleShield(485, 200, false, GameObject.Name.ShieldGrid2);
                //ShieldFactory.CreateSingleShield(680, 200, false, GameObject.Name.ShieldGrid3);

                //TimerEventMan.RemoveAll();

                //AlienFactory pFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
                //pFactory.ClearGrid();

                //float xStatic = 66.0f;
                //float xSpaceBetween = 0.0f;
                //float ySpaceBetween = 66.0f;

                //for (int i = 0; i < 11; i++)
                //{
                //    xSpaceBetween = xStatic * i;

                //    AlienColumn pAlienColumn = pFactory.CreateAlienColumn(60.0f, 825.0f, xSpaceBetween, ySpaceBetween);

                //    pAlienGrid.Add(pAlienColumn);
                //}
            }

            InputMan.Update();
          
            if (Simulation.GetTimeStep() > 0.0f)
            {

                TimerEventMan.Update(Simulation.GetTotalTime());
            
                ColPairMan.Process();

                //Go through every object and update positions
                GameObjectNodeMan.Update();

                DelayedObjectMan.Process();
            } 
        }

//-----------------------------------------------------------------------------
// Game::Draw()
//		This function is called once per frame
//	    Use this for draw graphics to the screen.
//      Only do rendering here
//-----------------------------------------------------------------------------
        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();

        }

        public override void Entering()
        {
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);

            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;

            Score = 0;
            TimerEventMan.Add(TimerEvent.Name.UpdateScoreCommand, new UpdateScoreCommand(0), 0);



            Sprite ufoSprite = SpriteMan.Find(Sprite.Name.AlienUFO);

            ufoSprite.SwapColor(1, 0, 0);


            TimerEventMan.PauseUpdate(delta);

            this.LoadOnEntry();
        }

        //TODO Maybe put functionality in DieCommand instead.
        public static void GameOver()
		{
            //TODO PUT GAME OVER ON SCREEN
            //AFTER X SECONDS, GO TO MAIN SCREEN
            //RESET PLAYER SCORE, KEEP HIGH SCORE
            Font pFont = FontMan.Add(Font.Name.GameOver, SpriteBatch.Name.Texts, "GAME OVER", Glyph.Name.Consolas36pt, 350, 900);
            pFont.SetColor(1, 0, 0);            

            TimerEventMan.Add(TimerEvent.Name.LoadNextSceneCommand, new LoadNextSceneCommand(SceneContext.Scene.Select), 10f);            

		}      

        public void LoadOnEntry()
		{
            new UpdateScoreCommand(Score);

            SpriteProxy octopus = SpriteProxyMan.Find(Sprite.Name.AlienOctopus);
            octopus.pSprite.SwapColor(1, 1, 1);
            
            TimerEventMan.Add(TimerEvent.Name.Animation, pSquidAnim, 1.0f);
            TimerEventMan.Add(TimerEvent.Name.Animation, pCrabAnim, 1.0f);
            TimerEventMan.Add(TimerEvent.Name.Animation, pOctoAnim, 1.0f);
            TimerEventMan.Add(TimerEvent.Name.MoveGrid, pAlienGridMoveCmd, 1.0f);
            //TimerEventMan.Add(TimerEvent.Name.RandomUFOSpawn, pUFOSpawnCmd, 2);

            TimerEventMan.Add(TimerEvent.Name.BombSpawnEvent, pBombSpawnEvent, 1);         

            if(ShipMan.GetShip().shipLives == 0)
			{
                pAlienGrid.SetDelta(10.0f);
                TimerEventMan.Add(TimerEvent.Name.ResetShip, new ResetShipLives(), 0);
            }

            Ship ship = ShipMan.GetShip();
            ship.SetState(ShipMan.MoveState.MoveBoth);
            ship.SetState(ShipMan.MissileState.Ready);

            
            
        }

        public override void Leaving()
        {
            // Need a better way to do this
            this.TimeAtPause = GlobalTimer.GetTime();

            TimerEventMan.RemoveAll();
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------    
        //private bool bGameOver;

        public AlienGrid pAlienGrid;
        public float timesWon;
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;

        public int Score;
        public int highScore;

        private Random pRandom;

        private AnimCommand pCrabAnim;
        private AnimCommand pOctoAnim;
        private AnimCommand pSquidAnim;
        private AnimCommand pShipDeadAnim;
        //private TimedUFOSpawn pUFOSpawnCmd;
        private MoveCommand pAlienGridMoveCmd;

        private BombSpawnEvent pBombSpawnEvent;
    }
}
