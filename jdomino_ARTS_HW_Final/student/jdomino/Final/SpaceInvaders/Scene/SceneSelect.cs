using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneSelect : SceneState
    {
        public SceneSelect()
        {
            this.Initialize();
        }
        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poFontMan = new FontMan(3, 1);
            FontMan.SetActive(this.poFontMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatchMan.Add(SpriteBatch.Name.MainMenuAliens);
            SpriteBatchMan.Add(SpriteBatch.Name.UI);

            alienUFOProxy = new SpriteProxy();
            alienUFOProxy.Set(Sprite.Name.AlienUFO);
            alienUFOProxy.x = 300;
            alienUFOProxy.y = 550;
            alienUFOProxy.pSprite.SwapColor(0.9f, 0.9f, 0.9f);

            SpriteProxy alienSquidProxy = new SpriteProxy();
            alienSquidProxy.Set(Sprite.Name.AlienSquid);
            alienSquidProxy.x = 305;
            alienSquidProxy.y = 500;
            alienSquidProxy.pSprite.SwapColor(0.9f, 0.9f, 0.9f);          

            SpriteProxy alienCrabProxy = new SpriteProxy();
            alienCrabProxy.Set(Sprite.Name.AlienCrab);
            alienCrabProxy.x = 300;
            alienCrabProxy.y = 450;
            alienCrabProxy.pSprite.SwapColor(0.9f, 0.9f, 0.9f);

            SpriteProxy alienOctopusProxy = new SpriteProxy();
            alienOctopusProxy.Set(Sprite.Name.AlienOctopus);
            alienOctopusProxy.x = 300;
            alienOctopusProxy.y = 400;
            alienOctopusProxy.pSprite.SwapColor(0.2f, 0.8f, 0.2f);


            SpriteBatch pAlienBatch = SpriteBatchMan.Add(SpriteBatch.Name.Aliens);
            pAlienBatch.Attach(alienSquidProxy);
            pAlienBatch.Attach(alienCrabProxy);
            pAlienBatch.Attach(alienOctopusProxy);
            pAlienBatch.Attach(alienUFOProxy);

            Texture pTexture = TextureMan.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            SpriteBatch pSB_UI = SpriteBatchMan.Add(SpriteBatch.Name.UI);
            FontMan.Add(Font.Name.Scoreboard, SpriteBatch.Name.Texts, "SCORE < 1 >   HIGH-SCORE   SCORE < 2 >", Glyph.Name.Consolas36pt, 90, 1000);
            FontMan.Add(Font.Name.Player1Score, SpriteBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 690, 960);


            FontMan.Add(Font.Name.TestOneOff, SpriteBatch.Name.Texts, "CREDIT 01", Glyph.Name.Consolas36pt, 600, 22);         

            UpdateScoreCommand Score = new UpdateScoreCommand(0);
            TimerEventMan.Add(TimerEvent.Name.UpdateScoreCommand, Score, 0);


            UpdateScoreCommand score = new UpdateScoreCommand(0);
            TimerEventMan.Add(TimerEvent.Name.UpdateScoreCommand, score, 0);
        }

        private void LoadOnEntry()
        {


            TimerEventMan.RemoveAll();

            SpriteProxy octopus = SpriteProxyMan.Find(Sprite.Name.AlienOctopus);
            octopus.pSprite.SwapColor(0.2f, 0.8f, 0.2f);

            TimedCharacterFactory.Install("PLAY", 2.0f, 0.10f, 380, 800, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("SPACE  INVADERS", 4.0f, 0.10f, 280, 700, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("*SCORE ADVANCE TABLE*", 6.0f, 0.10f, 200, 600, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= ? MYSTERY", 10.0f, 0.10f, 360, 550, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 30 POINTS", 12.0f, 0.10f, 360, 500, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 20 POINTS", 14.0f, 0.10f, 360, 450, 0.9f, 0.9f, 0.9f);
            TimedCharacterFactory.Install("= 10 POINTS", 16.0f, 0.10f, 360, 400, 0.2f, 0.8f, 0.2f);

            //What button to press to go to game
            TimedCharacterFactory.Install("Press 2 to Play", 18.0f, 0.10f, 265, 250, 0.9f, 0.9f, 0.9f);


        }

        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputMan.Update();

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Fire off the timer events
                TimerEventMan.Update(Simulation.GetTotalTime());

                // Do the collision checks
                ColPairMan.Process();

                // walk through all objects and push to flyweight
                GameObjectNodeMan.Update();

                // Delete any objects here...
                DelayedObjectMan.Process();
            }
        }

        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }

        public override void Entering()
        {
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);

            ScenePlay scenePlay = (ScenePlay)SceneContext.poScenePlay;
            Score = scenePlay.Score;
            new UpdateScoreCommand(Score);

            alienUFOProxy.pSprite.SwapColor(0.9f, 0.9f, 0.9f);

            //  FontMan.Dump();
            //  TimerEventMan.Dump();

            // FontMan.RemoveAll();

            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);


            this.LoadOnEntry();
        }
        public override void Leaving()
        {
            this.TimeAtPause = TimerEventMan.GetCurrTime();

            //Clear the events
            TimerEventMan.RemoveAll();

            // FontMan.RemoveAll();

            // FontMan.Dump();
            //  TimerEventMan.Dump();

        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;
        public int Score;

        SpriteProxy alienUFOProxy;

    }
}