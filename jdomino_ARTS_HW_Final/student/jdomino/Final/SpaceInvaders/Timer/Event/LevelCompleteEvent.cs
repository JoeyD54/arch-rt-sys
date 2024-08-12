using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	public class LevelCompleteEvent : CommandBase
	{
		public LevelCompleteEvent()
		{

		}

        public override void Execute(float deltaTime)
        {
            //Reset the grid
            //Increase grid speed by small margin
            //Fix my speed increase in moveCommand
            //Reset shields
            //Reset ship position?
            AlienGrid pAlienGrid = (AlienGrid)GameObjectNodeMan.Find(GameObject.Name.AlienGrid);

            ShieldFactory.CreateSingleShield(100, 200, false, GameObject.Name.ShieldGrid);
            ShieldFactory.CreateSingleShield(295, 200, false, GameObject.Name.ShieldGrid1);
            ShieldFactory.CreateSingleShield(485, 200, false, GameObject.Name.ShieldGrid2);
            ShieldFactory.CreateSingleShield(680, 200, false, GameObject.Name.ShieldGrid3);

            TimerEventMan.RemoveAll();

            AlienFactory pFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
            pFactory.ClearGrid();

            float xStatic = 66.0f;
            float xSpaceBetween = 0.0f;
            float ySpaceBetween = 66.0f;

            for (int i = 0; i < 11; i++)
            {
                xSpaceBetween = xStatic * i;

                AlienColumn pAlienColumn = pFactory.CreateAlienColumn(60.0f, 825.0f, xSpaceBetween, ySpaceBetween);

                pAlienGrid.Add(pAlienColumn);
            }

            Ship ship = ShipMan.GetShip();
            ship.SetState(ShipMan.MissileState.Dead);
            ship.SetState(ShipMan.MoveState.Dead);
            

            ScenePlay scenePlay = (ScenePlay)SceneContext.GetState();
            scenePlay.timesWon++;
            float timesWon = scenePlay.timesWon;

            AnimCommand pSquidAnim = new AnimCommand(Sprite.Name.AlienSquid, timesWon);
            pSquidAnim.Attach(Image.Name.AlienSquid);
            pSquidAnim.Attach(Image.Name.AlienSquid2);

            TimerEventMan.Add(TimerEvent.Name.Animation, pSquidAnim, 1.0f);

            //Remove the splats
            SpriteBatch pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.BigBoomBooms);
            while (pSpriteBatch != null)
            {
                SpriteBatchMan.Remove(pSpriteBatch);
                pSpriteBatch = SpriteBatchMan.Find(SpriteBatch.Name.BigBoomBooms);
            }

            scenePlay.LoadOnEntry();            
        }
	}
}
