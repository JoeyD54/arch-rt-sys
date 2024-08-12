using System;

namespace SpaceInvaders
{
    public class SceneContext
    {
        public enum Scene
        {
            Select,
            Play,
            Over
        }
        public SceneContext()
        {
            // reserve the states
            poScenePlay = new ScenePlay();
            poSceneSelect = new SceneSelect();            
            poSceneOver = new SceneOver();

            // initialize to the select state
            pSceneState = poSceneSelect;
            pSceneState.Entering();
        }

        public static SceneState GetState()
        {
            return pSceneState;
        }
        public static void SetState(Scene eScene)
        {
            switch (eScene)
            {
                case Scene.Select:
                    pSceneState.Leaving();
                    pSceneState = poSceneSelect;
                    pSceneState.Entering();
                    break;

                case Scene.Play:
                    pSceneState.Leaving();                 
                    pSceneState = poScenePlay;
                    pSceneState.Entering();
                    break;

                case Scene.Over:
                    pSceneState.Leaving();
                    pSceneState = poSceneOver;
                    pSceneState.Entering();
                    break;
            }
        }

        // ----------------------------------------------------
        // Data: 
        // -------------------------------------------o---------
        public static SceneState pSceneState;
        public static SceneSelect poSceneSelect;
        public static SceneOver poSceneOver;
        public static ScenePlay poScenePlay;

    }
}