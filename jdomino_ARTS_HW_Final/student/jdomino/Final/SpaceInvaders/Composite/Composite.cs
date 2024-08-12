using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Composite : GameObject
    {
        public Composite()
            : base(Component.Container.Composite,
                  GameObject.Name.Null_Object,
                  Sprite.Name.Null_Object)
        {
            this.poDLinkMan = new DLinkMan();
        }

        public Composite(GameObject.Name name, Sprite.Name spriteName)
        : base(Component.Container.Composite,
               name,
               spriteName)
        {
            this.poDLinkMan = new DLinkMan();
        }
        public override void Resurrect()
        {
            // check the DLinkMan
            Debug.Assert(this.poDLinkMan.poHead == null);

            base.Resurrect();
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.AddToFront(pComponent);

            pComponent.pParent = this;

            //GameObjectNodeMan.Attach((GameObject)pComponent);
        }
        public Component GetHead()
        {
            Debug.Assert(this.poDLinkMan != null);
            Component pHead = (GameObject)this.poDLinkMan.poHead;
            return pHead;
        }
        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            Debug.Assert(this.poDLinkMan != null);
            this.poDLinkMan.Remove(pComponent);
        }

        public override int GetNumChildren()
        {
            int count = 0;

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            GameObject pNode = (GameObject)pIt.First();

            // Walk through the nodes
            while (!pIt.IsDone())
            {
                count++;

                pNode = (GameObject)pIt.Next();
            }

            return count;
        }

        override public void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Composite: {0}", this);

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            GameObject pNode = (GameObject)pIt.First();

            // Walk through the nodes
            while (!pIt.IsDone())
            {
                // Update the node
                Debug.Assert(pNode != null);

                pNode.Print();

                pNode = (GameObject)pIt.Next();
            }
        }
        override public void DumpNode()
        {
            if (IteratorForwardComposite.GetParent(this) != null)
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:{1} <---- Composite", this.GetHashCode(), IteratorForwardComposite.GetParent(this).GetHashCode());
            }
            else
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:null <---- Composite", this.GetHashCode());
            }
        }
        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }


        public DLinkMan poDLinkMan;
    }
}
