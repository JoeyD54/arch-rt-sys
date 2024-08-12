using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpaceInvaders : Azul.Game
    {

		//TODO - Create a sound Manager
		//IrrKlang.ISoundEngine sndEngine = null;
		//IrrKlang.ISound music = null;
		//IrrKlang.ISoundSource sndVader0 = null;
		//IrrKlang.ISoundSource sndVader1 = null;
		//IrrKlang.ISoundSource sndVader2 = null;
		//IrrKlang.ISoundSource sndVader3 = null;

		SceneContext pSceneContext = null;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------

        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Space Invaders");
            this.SetWidthHeight(896, 1024);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

		//-----------------------------------------------------------------------------
		// Game::LoadContent()
		//		Allows you to load all content needed for your engine,
		//	    such as objects, graphics, etc.
		//-----------------------------------------------------------------------------
		public override void LoadContent()
		{
			//-------------------------------------------------------------------------
			// Managers
			//-------------------------------------------------------------------------

			//All managers are singletons AND are LTN's
			//The manager's will be constantly running during the game

			SoundManager.Create();

			Simulation.Create();
			TimerEventMan.Create(1, 1);
			TextureMan.Create(0, 1);
			ImageMan.Create();
			SpriteMan.Create();
			SpriteBatchMan.Create();
			SpriteBoxMan.Create(1, 1);
			SpriteProxyMan.Create(1, 1);
			GameObjectNodeMan.Create();
			ColPairMan.Create(1, 1);
			GlyphMan.Create(1, 1);
			FontMan.Create();
			GhostMan.Create(1, 1);

			pSceneContext = new SceneContext();


			//pSceneContext.SetState(SceneContext.Scene.Select);
		}

		//-----------------------------------------------------------------------------
		// Game::Update()
		//      Called once per frame, update data, tranformations, etc
		//      Use this function to control process order
		//      Input, AI, Physics, Animation, and Graphics
		//-----------------------------------------------------------------------------
		public override void Update()
		{
			GlobalTimer.Update(this.GetTime());

			//  stuff called every update no matter the scene here... 
			//  example: like audio update
			SoundManager.sndEngine.Update();
			
			// Hack to proof of concept... 
			if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
			{
				SceneContext.SetState(SceneContext.Scene.Select);
			}

			if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true)
			{
				SceneContext.SetState(SceneContext.Scene.Play);
			}

			if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_3) == true)
			{
				SceneContext.SetState(SceneContext.Scene.Over);
			}			

			// Update the scene
			SceneContext.GetState().Update(this.GetTime());


			if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_T) == true)
			{
				SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
				Debug.Assert(pSB != null);
				pSB.SetDrawEnable(false);
			}

			if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_Y) == true)
			{
				SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
				Debug.Assert(pSB != null);
				pSB.SetDrawEnable(true);
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
			// draw scene
			SceneContext.GetState().Draw();

		}

		//-----------------------------------------------------------------------------
		// Game::UnLoadContent()
		//       unload content (resources loaded above)
		//       unload all content that was loaded before the Engine Loop started
		//-----------------------------------------------------------------------------
		public override void UnLoadContent()
        {

        }
    }
}
