using NAudio.Wave;
using System.Runtime.Versioning;

namespace Core
{
    public static class MediaSystem
    {
        public static void PlaySound(string name)
        {
            WaveStream stream = new AudioFileReader(name);
            WaveOutEvent player = new WaveOutEvent();

            stream.CurrentTime = new TimeSpan(0L);
            player.Init(stream);
            player.Play();
        }
    }
}
