using System;
using System.Diagnostics;
using System.Xml;

namespace SpaceInvaders
{
	public class GlyphMan : ManBase
	{
        /**********************
		* 
		* Constructor and Enum
		* 
		**********************/
        private GlyphMan(int reserveNum = 3, int reserveGrow = 1)
        : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            this.poNodeCompare = new Glyph();
        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new GlyphMan(reserveNum, reserveGrow);
            }
        }

        /**********************
		* 
		* Public Methods
		* 
		**********************/


        public static void Destroy()
        {
        }

        public static Glyph Add(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphMan pMan = GlyphMan.privGetInstance();

            Glyph pNode = (Glyph)pMan.baseAddToFront();
            Debug.Assert(pNode != null);

            pNode.Set(name, key, textName, x, y, width, height);
            return pNode;
        }
        public static void AddXml(Glyph.Name glyphName, string assetName, Texture.Name textName)
        {
            // STN - only used to load the XML once invoked in the game load content
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            // I'm sure there is a better way to do this... but this works for now
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {
                            // have all the data... so now create a glyph
                            Debug.WriteLine("key:{0} x:{1} y:{2} w:{3} h:{4}", key, x, y, width, height);
                            GlyphMan.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }

            // Debug.Write("\n");
        }

        public static Glyph Find(Glyph.Name name, int key)
        {
            GlyphMan pMan = GlyphMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.name = name;
            pMan.poNodeCompare.key = key;

            Glyph pData = (Glyph)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(Glyph pImage)
        {
            Debug.Assert(pImage != null);

            GlyphMan pMan = GlyphMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseRemove(pImage);
        }
        public static void Dump()
        {
            GlyphMan pMan = GlyphMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        /**********************
		* 
		* Private Methods
		* 
		**********************/

        private static GlyphMan privGetInstance()
		{
			// Safety - this forces users to call Create() first before using class
			Debug.Assert(pInstance != null);

			return pInstance;
		}

		/**********************
		* 
		* Override Methods
		* 
		**********************/

		override protected NodeBase DerivedCreateNode()
		{
			NodeBase pNodeBase = new Glyph();
			Debug.Assert(pNodeBase != null);

			return pNodeBase;
		}

		/**********************
		* 
		* Local Variables
		* 
		**********************/
		private readonly Glyph poNodeCompare;
		private static GlyphMan pInstance = null;
	}
}
