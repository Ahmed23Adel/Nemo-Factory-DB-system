using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Nemo
{
    class MakeSound
    {
        private static MediaPlayer mplayerClick;
        private static MediaPlayer mplayerSent;
        private static MediaPlayer mplayerLoged;
        private static MediaPlayer mplayerWrongUserPass;

        private static MakeSound instance;
        private MakeSound()
        {
            mplayerClick = new MediaPlayer();
            mplayerSent = new MediaPlayer();
            mplayerLoged = new MediaPlayer();
            mplayerWrongUserPass = new MediaPlayer();
            mplayerClick.Open(new Uri(@"../../SoundEffects/click.mp3", UriKind.Relative));
            mplayerSent.Open(new Uri(@"../../SoundEffects/sent.mp3", UriKind.Relative));
            mplayerLoged.Open(new Uri(@"../../SoundEffects/done.mp3", UriKind.Relative));
            mplayerWrongUserPass.Open(new Uri(@"../../SoundEffects/sad.mp3", UriKind.Relative));
        }
        public static MakeSound GetInstance()
        {
            if (instance == null)
                instance = new MakeSound();
            return instance;
        }

        public static void MakeClick()
        {
            mplayerClick.Position = new TimeSpan(0);
            mplayerClick.Play();
        }
        
        public static void MakeSent()
        {
            mplayerSent.Position = new TimeSpan(0);
            mplayerSent.Play();
        }
        
        public static void MakeLoged()
        {
            mplayerLoged.Position = new TimeSpan(0);
            mplayerLoged.Play();
        }
        
        public static void MakeWrongUserPass()
        {
            mplayerWrongUserPass.Position = new TimeSpan(0);
            mplayerWrongUserPass.Play();
        }


    }

}
