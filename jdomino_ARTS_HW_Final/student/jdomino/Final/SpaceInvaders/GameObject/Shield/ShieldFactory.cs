using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        private ShieldFactory()
        {
            this.pSpriteBatch = null;
            this.pCollisionSpriteBatch = null;
            this.pTree = null;
        }
        private void privSet(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionSpriteBatch, Composite pTree)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteBatchMan.Find(collisionSpriteBatch);
            Debug.Assert(this.pCollisionSpriteBatch != null);

            Debug.Assert(pTree != null);
            this.pTree = pTree;
        }
        private void privSetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }
        ~ShieldFactory()
        {
        }
        private GameObject privCreate(ShieldCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f, bool newCreate = false, ShieldGrid.Name _gridName = ShieldGrid.Name.ShieldGrid)
        {
            bool objectExists = false;
            GameObject pShield = null;                        
            GameObjectNode pGameObjNode = GhostMan.Find(gameName);
            GameObject shieldRoot = GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);

            GameObject shieldGrid = (GameObject)IteratorForwardComposite.GetChild(shieldRoot);

            if (gameName != _gridName)
            {
                while (shieldGrid.name != _gridName)
                {
                    shieldGrid = (ShieldGrid)shieldGrid.pNext;
                }
            }
            

            //Only check existing if we have a root
            if (shieldRoot != null)
            {
                //First, see if the item already exists
                if (shieldRoot.name == gameName)
                {
                    pShield = shieldRoot;
                    objectExists = true;
                }
                //Root isn't what we want. We must go deeper
                //We need to check this even if we found a ghost object.
                else if (shieldRoot.name != gameName && shieldRoot != null)
                {
                    //Check if the item exists at the x,y coordinate
                    switch (type)
                    {
                        case ShieldCategory.Type.Brick:
                        case ShieldCategory.Type.LeftTop1:
                        case ShieldCategory.Type.LeftTop0:
                        case ShieldCategory.Type.LeftBottom:
                        case ShieldCategory.Type.RightTop1:
                        case ShieldCategory.Type.RightTop0:
                        case ShieldCategory.Type.RightBottom:
                        case ShieldCategory.Type.RightBottomHalfVert:
                        case ShieldCategory.Type.LeftBottomHalfVert:
                            if (!newCreate)
                            {
                                //Step through all columns and chekc their bricks
                                GameObject brickColumn = (GameObject)IteratorForwardComposite.GetChild(shieldGrid);
                                while (brickColumn != null)
                                {
                                    GameObject brickObject = (GameObject)IteratorForwardComposite.GetChild(brickColumn);
                                    while (brickObject != null)
                                    {
                                        if (brickObject != null)
                                        {
                                            //We already have a brick here
                                            if (brickObject.x == posX && brickObject.y == posY)
                                            {
                                                ShieldBrick shieldBrick = (ShieldBrick)brickObject;
                                                Debug.WriteLine("Brick {0} Exists", shieldBrick.GetCategoryType());
                                                objectExists = true;
                                                pShield = brickObject;
                                                break;
                                            }
                                        }
                                        brickObject = (ShieldBrick)brickObject.pNext;
                                    }
                                    brickColumn = (ShieldColumn)brickColumn.pNext;
                                }
                            }

                            break;
                        case ShieldCategory.Type.Root:
                            Debug.Assert(false);
                            break;

                        case ShieldCategory.Type.Grid:
                            if (!newCreate)
                            {
                                while (shieldGrid != null)
                                {
                                    if (shieldGrid != null && shieldGrid.name == gameName)
                                    {
                                        Debug.WriteLine("ShieldGrid {0} Exists", shieldGrid);
                                        pShield = shieldGrid;
                                        objectExists = true;
                                        break;
                                    }
                                    shieldGrid = (ShieldGrid)shieldGrid.pNext;
                                }
                            }                        
                            break;
                        case ShieldCategory.Type.Column:
                            if (!newCreate)
                            {
                                GameObject shieldColumn = (GameObject)IteratorForwardComposite.GetChild(shieldGrid);
                                while (shieldColumn != null)
                                {
                                    if (shieldColumn.name == gameName)
                                    {
                                        Debug.WriteLine("ShieldColumn {0} Exists", shieldColumn);
                                        pShield = shieldColumn;
                                        objectExists = true;
                                        break;
                                    }

                                    shieldColumn = (ShieldColumn)shieldColumn.pNext;
                                }
                                shieldGrid = (ShieldGrid)shieldGrid.pNext;

                            }
                            break;

                        default:
                            // something is wrong
                            Debug.Assert(false);
                            break;
                    }
                }
            }

            //It doesn't exist on screen, check our ghosts
            if (objectExists == false)
            {
                if (pGameObjNode != null)
                {
                    pShield = pGameObjNode.pGameObject;
                    GhostMan.Remove(pGameObjNode);

                    //GhostMan.Dump();

                    Debug.WriteLine("Resurrecting {0}", type);
                    switch (type)
                    {
                        case ShieldCategory.Type.Brick:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.LeftTop1:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.LeftTop0:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.LeftBottom:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.RightTop1:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.RightTop0:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.RightBottom:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.RightBottomHalfVert:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;
                        case ShieldCategory.Type.LeftBottomHalfVert:
                            ((ShieldBrick)pShield).Resurrect(posX, posY);
                            break;

                        case ShieldCategory.Type.Root:
                            Debug.Assert(false);
                            break;

                        case ShieldCategory.Type.Grid:
                            ((ShieldGrid)pShield).Resurrect(posX, posY);
                            break;

                        case ShieldCategory.Type.Column:
                            ((ShieldColumn)pShield).Resurrect(posX, posY); ;
                            break;

                        default:
                            // something is wrong
                            Debug.Assert(false);
                            break;
                    }
                }

                //It doesn't exist. Make a new one
                else
                {
                    Debug.WriteLine("Creating new {0}", type);
                    switch (type)
                    {
                        
                        case ShieldCategory.Type.Brick:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick, posX, posY);
                            break;

                        case ShieldCategory.Type.LeftTop1:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_LeftTop1, posX, posY);
                            break;

                        case ShieldCategory.Type.LeftTop0:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_LeftTop0, posX, posY);
                            break;

                        case ShieldCategory.Type.LeftBottom:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_LeftBottom, posX, posY);
                            break;
                        case ShieldCategory.Type.LeftBottomHalfVert:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_LeftBottomHalfVert, posX, posY);
                            break;

                        case ShieldCategory.Type.RightTop1:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_RightTop1, posX, posY);
                            break;

                        case ShieldCategory.Type.RightTop0:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_RightTop0, posX, posY);
                            break;

                        case ShieldCategory.Type.RightBottom:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_RightBottom, posX, posY);
                            break;
                        case ShieldCategory.Type.RightBottomHalfVert:
                            pShield = new ShieldBrick(gameName, Sprite.Name.Brick_RightBottomHalfVert, posX, posY);
                            break;

                        case ShieldCategory.Type.Root:
                            pShield = new ShieldRoot(gameName, Sprite.Name.Null_Object, posX, posY);
                            pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                            Debug.Assert(false);
                            break;

                        case ShieldCategory.Type.Grid:
                            pShield = new ShieldGrid(gameName, Sprite.Name.Null_Object, posX, posY);
                            pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                            break;

                        case ShieldCategory.Type.Column:
                            pShield = new ShieldColumn(gameName, Sprite.Name.Null_Object, posX, posY);
                            pShield.SetCollisionColor(1.0f, 0.0f, 0.0f);
                            break;

                        default:
                            // something is wrong
                            Debug.Assert(false);
                            break;
                    }
                }
                

                // add to the tree
                this.pTree.Add(pShield);

                // Attached to Group
                pShield.ActivateSprite(this.pSpriteBatch);
                pShield.ActivateCollisionSprite(this.pCollisionSpriteBatch);
            }

            return pShield;
        }

        //FULL SHIELD REQUIRES 11 COLUMNS of 8 2x2 SQUARES
        //2 corner pieces for top left and right each
        //half square for bottom left right

        public static GameObject CreateSingleShield(float inStartX, float inStartY, bool _newCreate = false, GameObject.Name _gameObjName = GameObject.Name.Uninitialized)
        {

            bool newCreate = _newCreate;
            ShieldFactory pFactory = ShieldFactory.privInstance();

            // Find the ShieldRoot... its not in Ghost since its a root and isn't deleted
            ShieldRoot pShieldRoot = (ShieldRoot)GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);

            if (pShieldRoot == null)
            {
                pShieldRoot = new ShieldRoot(GameObject.Name.ShieldRoot, Sprite.Name.Null_Object, 0.0f, 0.0f);
                GameObjectNodeMan.Attach(pShieldRoot);                
            }

            pFactory.privSet(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, pShieldRoot);

            int j = 0;

            GameObject pColumn;
            GameObject pGrid;

            pFactory.privSetParent(pShieldRoot);

            if (_gameObjName != GameObject.Name.Uninitialized)
			{
                pGrid = pFactory.privCreate(ShieldCategory.Type.Grid, _gameObjName, inStartX, inStartY, newCreate, _gameObjName);
            }
			else
			{
                pGrid = pFactory.privCreate(ShieldCategory.Type.Grid, GameObject.Name.ShieldGrid, inStartX, inStartY, newCreate);
            }

            


            pFactory.privSetParent(pGrid);

            pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

            pFactory.privSetParent(pColumn);

            float start_x = inStartX;
            float start_y = inStartY;
            float off_x = 0;
            float brickWidth = 20.0f;
            float brickHeight = 10.0f;

            //Column 0. All bricks, but 7th row has only one spot on bot right. 8th row blank

            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrickLeftTop1, start_x, start_y + 6 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Unitialized, GameObject.Name.ShieldBrick, start_x, start_y + 7 * brickHeight);


            //pFactory.privSetParent(pGrid);

            //pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

            //pFactory.privSetParent(pColumn);

            //Column 1. All bricks, but 8th row has only one spot on bot right

			off_x += brickWidth;           

			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight, newCreate, pGrid.name);        
            pFactory.privCreate(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrickLeftTop1, start_x + off_x, start_y + 7 * brickHeight, newCreate, pGrid.name);         

            pFactory.privSetParent(pGrid);

			pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

			pFactory.privSetParent(pColumn);

            //Column 2. Left side of half circle base

			//off_x += brickWidth;

   //         //FIRST ONE IS A HALF FILL ON LEFT SIDE. TODO GRAB THAT IMAGE

   //         pFactory.privCreate(ShieldCategory.Type.LeftBottomHalfVert, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
   //         pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
   //         pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
   //         pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
   //         pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
   //         pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
   //         pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
   //         pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);          

   //         pFactory.privSetParent(pGrid);

   //         pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_3 + j++);

   //         pFactory.privSetParent(pColumn);

            //Column 3. Ignore bottom row. Should be blank

            off_x += brickWidth;

            //FIRST ROW BLANK

            pFactory.privCreate(ShieldCategory.Type.LeftBottomHalfVert, GameObject.Name.ShieldBrickLeftBottomHalfVert, start_x + off_x, start_y, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight, newCreate, pGrid.name);

            pFactory.privSetParent(pGrid);

			pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

			pFactory.privSetParent(pColumn);

            //Column 4. Ignore bottom 2 rows. Rest are bricks

            off_x += brickWidth;

            //pFactory.privCreate(ShieldCategory.Type.Unitialized, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
            pFactory.privCreate(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrickLeftBottom, start_x + off_x, start_y + brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight, newCreate, pGrid.name);

            pFactory.privSetParent(pGrid);

            pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

            pFactory.privSetParent(pColumn);

            //Column 5. Ignore bottom 2 rows. Rest are bricks

            //off_x += brickWidth;

            ////pFactory.privCreate(ShieldCategory.Type.Unitialized, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
            ////pFactory.privCreate(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);

            //pFactory.privSetParent(pGrid);

            //pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_6 + j++);

            //pFactory.privSetParent(pColumn);

            //Column 6. Ignore bottom 2 rows. Rest are bricks

            //off_x += brickWidth;

            ////pFactory.privCreate(ShieldCategory.Type.Unitialized, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
            ////pFactory.privCreate(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);

            //pFactory.privSetParent(pGrid);

            //pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_7 + j++);

            //pFactory.privSetParent(pColumn);

            //Column 7. Bottom Row blank. 2nd row has one block on top right

            //Ignoring for now

            off_x += brickWidth;

            //pFactory.privCreate(ShieldCategory.Type.Unitialized, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
            pFactory.privCreate(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrickRightBottom, start_x + off_x, start_y + brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight, newCreate, pGrid.name);

            pFactory.privSetParent(pGrid);

            pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

            pFactory.privSetParent(pColumn);

			//Column 8. ALL BRICKS

			off_x += brickWidth;

			pFactory.privCreate(ShieldCategory.Type.RightBottomHalfVert, GameObject.Name.ShieldBrickRightBottomHalfVert, start_x + off_x, start_y, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight, newCreate, pGrid.name);
			pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight, newCreate, pGrid.name);

			pFactory.privSetParent(pGrid);

			pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

			pFactory.privSetParent(pColumn);

			//Column 9. All bricks. Top brick has one brick on bottom left

			off_x += brickWidth;

            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight, newCreate, pGrid.name);
            pFactory.privCreate(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrickRightTop0, start_x + off_x, start_y + 7 * brickHeight, newCreate, pGrid.name);

            pFactory.privSetParent(pGrid);

            //pColumn = pFactory.privCreate(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++, 0, 0, newCreate, pGrid.name);

            //pFactory.privSetParent(pColumn);

            ////Column 10. 6 rows bricks. 7th one brick on bot left. 8th row blank

            //off_x += brickWidth;

            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrickRightTop0, start_x + off_x, start_y + 6 * brickHeight, newCreate, pGrid.name);
            //pFactory.privCreate(ShieldCategory.Type.Unitialized, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);

            //pFactory.privSetParent(pGrid);

            return pShieldRoot;
        }

        private static ShieldFactory privInstance()
        {
            if (pInstance == null)
            {
                ShieldFactory.pInstance = new ShieldFactory();
            }

            Debug.Assert(pInstance != null);

            return pInstance;
        }

        // Data: ---------------------
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pCollisionSpriteBatch;
        private Composite pTree;

        private static ShieldFactory pInstance = null;
    }
}