using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
	public class SoundManager
	{
        public SoundManager()
        {
            //plays music and instantiates a sound engine
            //sndEngine = null;
            //music = null;         

            //this.music = sndEngine.Play2D("blight_trailer_11.15.mp3");
            //this.music.Volume = 0.1f;
            //this.music.Looped = true;

        }

        public static void Create()
        {
            if (pInstance == null)
            {
                sndEngine = new IrrKlang.ISoundEngine();
                pInstance = new SoundManager();

            }
        }

        public static SoundManager GetSoundManager()
		{
            return pInstance;
		}
        
        public static void PlaySound(string soundEffectString)
		{
            sndEngine.Play2D(soundEffectString);
		}

  //      public static void PlayLoopingSound(string soundStringToLoop)
		//{
            
		//}




        public static SoundManager pInstance;
        public static IrrKlang.ISoundEngine sndEngine;
        //IrrKlang.ISound music;

    }
}
