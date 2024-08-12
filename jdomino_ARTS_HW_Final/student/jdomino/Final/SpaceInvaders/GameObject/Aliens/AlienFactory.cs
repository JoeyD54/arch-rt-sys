using System;
using System.Diagnostics;

namespace SpaceInvaders
{
	class AlienFactory
	{
		public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
		{
			pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
			Debug.Assert(pSpriteBatch != null);

			pSpriteBoxBatch = SpriteBatchMan.Find(boxSpriteBatchName);
			Debug.Assert(pSpriteBoxBatch != null);		
		}

		public GameObject Create(AlienBase.Type type, float posX = 0.0f, float posY = 0.0f, GameObject.Name _gameObjName = GameObject.Name.Uninitialized)
		{
			bool gridFound = false;
			GameObject pGameObject = null;
			AlienGrid pGrid = (AlienGrid)GameObjectNodeMan.Find(GameObject.Name.AlienGrid);

			//Grid was not found. Make a new
			if(pGrid != null)
			{
				gridFound = true;
			}
			
			GameObjectNode pGameObjNode = GhostMan.Find(_gameObjName);

			//We found a dead alien column/grid/alien
			if (pGameObjNode != null && gridFound)
			{
				pGameObject = pGameObjNode.pGameObject;
				GhostMan.Remove(pGameObjNode);

				Debug.WriteLine("Alien Object {0} Exists", pGameObject.name);
				switch (type)
				{					

					case AlienBase.Type.Column:
						((AlienColumn)pGameObject).Resurrect();
						break;
					case AlienBase.Type.Squid:
						((AlienSquid)pGameObject).Resurrect(posX, posY);						
						break;
					case AlienBase.Type.Crab:
						((AlienCrab)pGameObject).Resurrect(posX, posY);
						break;
					case AlienBase.Type.Octopus:
						((AlienOctopus)pGameObject).Resurrect(posX, posY);
						break;
					case AlienBase.Type.UFO:
						((AlienUFO)pGameObject).Resurrect(posX, posY);
						break;

				}
			}
			//No dead object found, make a new one.
			else
			{				
				switch (type)
				{
					case AlienBase.Type.Grid:
						//LTN - GameObjectNodeManager
						pGameObject = new AlienGrid();
						break;
					case AlienBase.Type.UFOGrid:
						//LTN - GameObjectNodeManager
						pGameObject = new UFOGrid();
						break;
					case AlienBase.Type.Column:
						//LTN - GameObjectNodeManager
						pGameObject = new AlienColumn();
						break;
					case AlienBase.Type.Crab:
						//LTN's - GameObjectNodeManager
						pGameObject = new AlienCrab(Sprite.Name.AlienCrab, posX, posY);
						break;
					case AlienBase.Type.Squid:
						//LTN's - GameObjectNodeManager
						pGameObject = new AlienSquid(Sprite.Name.AlienSquid, posX, posY);
						break;
					case AlienBase.Type.Octopus:
						//LTN's - GameObjectNodeManager
						pGameObject = new AlienOctopus(Sprite.Name.AlienOctopus, posX, posY);
						break;
					case AlienBase.Type.UFO:
						pGameObject = new AlienUFO(Sprite.Name.AlienUFO, posX, posY);
						break;
					default:
						//Things screwed up
						Debug.Assert(false);
						break;
				}
				Debug.WriteLine("Making new {0} Object", pGameObject.name);
			}

			//pSpriteBatch.Attach(pGameObject);

			pGameObject.ActivateSprite(pSpriteBatch);
			pGameObject.ActivateCollisionSprite(pSpriteBoxBatch);

			return pGameObject;
		}

		public AlienColumn CreateAlienColumn(float inStartX, float inStartY, float xSpaceBetween, float ySpaceBetween, GameObject.Name _gameObjName = GameObject.Name.Uninitialized)
		{
			AlienColumn pColumn = (AlienColumn)Create(AlienBase.Type.Column, 0, 0, GameObject.Name.AlienColumn);

			float squidStartX = inStartX + 2.5f;
			float crabStartX = inStartX;
			float octopusStartX = inStartX;

			float squidY = inStartY;
			float crab1Y = squidY - ySpaceBetween;
			float crab2Y = crab1Y - ySpaceBetween;
			float octo1Y = crab2Y - ySpaceBetween;
			float octo2Y = octo1Y - ySpaceBetween;

			GameObject colsquidGO = Create(AlienBase.Type.Squid, squidStartX + xSpaceBetween, squidY, GameObject.Name.SquidAlien);
			GameObject col1crabGO = Create(AlienBase.Type.Crab, crabStartX + xSpaceBetween, crab1Y, GameObject.Name.CrabAlien);
			GameObject col2crabGO = Create(AlienBase.Type.Crab, crabStartX + xSpaceBetween, crab2Y, GameObject.Name.CrabAlien);
			GameObject col1octoGO = Create(AlienBase.Type.Octopus, octopusStartX + xSpaceBetween, octo1Y, GameObject.Name.OctopusAlien);
			GameObject col2octoGO = Create(AlienBase.Type.Octopus, octopusStartX + xSpaceBetween, octo2Y, GameObject.Name.OctopusAlien);
			
            pColumn.Add(colsquidGO);
            pColumn.Add(col1crabGO);
            pColumn.Add(col2crabGO);
            pColumn.Add(col1octoGO);
            pColumn.Add(col2octoGO);

			return pColumn;
		}

		public void ClearGrid()
		{
			//Mission:
			/*
			 * grab the grid
			 * go down to columns
			 *	go through each one
			 *	Remove each alien in column
			 *	Remove Column
			 * 
			 * 
			 */

			AlienGrid pAlienGrid = (AlienGrid)GameObjectNodeMan.Find(GameObject.Name.AlienGrid);
			AlienColumn pAlienColumn = (AlienColumn)IteratorForwardComposite.GetChild(pAlienGrid);

			while (pAlienColumn != null)
			{
				GameObject pAlien = (GameObject)IteratorForwardComposite.GetChild(pAlienColumn);
				while(pAlien != null)
				{
					//Get alien
					GameObject pAlienToRemove = pAlien;

					//Go next so we can continue
					pAlien = (GameObject)pAlien.pNext;

					//Kill that bastard
					pAlienToRemove.Remove();
				}
				AlienColumn pColumnToRemove = pAlienColumn;

				//Go to next column
				pAlienColumn = (AlienColumn)pAlienColumn.pNext;

				//Clear emptied olumn
				pColumnToRemove.Remove();
			}
			

		}

		//Data:		

		private readonly SpriteBatch pSpriteBatch;
		private readonly SpriteBatch pSpriteBoxBatch;
	}
}
