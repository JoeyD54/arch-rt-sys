
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SceneState
    {
        public SceneState()
        {
            this.TimeAtPause = TimerEventMan.GetCurrTime();
        }
        public abstract void Initialize();
        public abstract void Update(float systemTime);
        public abstract void Draw();
        public abstract void Entering();
        public abstract void Leaving();
        //public abstract void Transition();

        public float TimeAtPause;
        //public SceneContext pSceneContext;

    }
}