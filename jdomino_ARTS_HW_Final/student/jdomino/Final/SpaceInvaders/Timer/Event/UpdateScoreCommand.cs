using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UpdateScoreCommand : CommandBase
    {


        public UpdateScoreCommand(int _num)
        {
            this.numToAdd = _num;
        }

        override public void Execute(float _timeTotrigger)
        {
            ScenePlay scenePlay = (ScenePlay)SceneContext.GetState();
            score = scenePlay.Score;
            highScore = scenePlay.highScore;

            if(numToAdd == 0)
			{
                score = numToAdd;
			}
			else
			{
                score += numToAdd;
            }
             

            if (score > highScore)
            {
                highScore = score;
            }

            //get rid of old score
            if (FontMan.Find(Font.Name.Player1Score) != null)
            {
                FontMan.Remove(FontMan.Find(Font.Name.Player1Score));
            }

            Font pFont;
            //add new timernum            

            pFont = FontMan.Add(Font.Name.Player1Score, SpriteBatch.Name.Texts, score.ToString("D4"), Glyph.Name.Consolas36pt, 180, 960);            
            pFont.SetColor(1.00f, 1.00f, 1.00f);


            //get rid of old highScore
            if (FontMan.Find(Font.Name.HighScore) != null)
            {
                FontMan.Remove(FontMan.Find(Font.Name.HighScore));
            }

           
           pFont = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, highScore.ToString("D4"), Glyph.Name.Consolas36pt, 400, 960);
            
            pFont.SetColor(1.00f, 1.00f, 1.00f);

            
            scenePlay.Score = score;
            scenePlay.highScore = highScore;
        }

        public int score = 0;
        public int numToAdd;
        public int highScore = 0;

    }
}