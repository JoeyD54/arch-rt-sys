﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputMan
    {
        private InputMan()
        {
            this.poSubjectArrowLeft = new InputSubject();
            this.poSubjectArrowRight = new InputSubject();
            this.poSubjectSpace = new InputSubject();

            this.privSpaceKeyPrev = false;
        }

        private static InputMan privGetInstance()
        {
            if (pInstance == null)
            {
                pInstance = new InputMan();
            }
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static InputSubject GetArrowRightSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            return pMan.poSubjectArrowRight;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            return pMan.poSubjectArrowLeft;
        }

        public static InputSubject GetSpaceSubject()
        {
            InputMan pMan = InputMan.privGetInstance();
            return pMan.poSubjectSpace;
        }

        public static void Update()
        {
            InputMan pMan = InputMan.privGetInstance();


            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.poSubjectArrowLeft.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.poSubjectArrowRight.Notify();
            }

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            if (spaceKeyCurr == true && pMan.privSpaceKeyPrev == false)
            {
                pMan.poSubjectSpace.Notify();
            }

            pMan.privSpaceKeyPrev = spaceKeyCurr;                    
        }

        // Data: ----------------------------------------------
        private static InputMan pInstance = null;
        private bool privSpaceKeyPrev;

        private InputSubject poSubjectArrowRight;
        private InputSubject poSubjectArrowLeft;
        private InputSubject poSubjectSpace;
    }
}