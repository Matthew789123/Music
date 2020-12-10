using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Projekt_1.Views;
namespace Projekt_1
{
    public class Player
    {
        private WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
        private AudioFileReader audioOut;
        private MainView view;
        private bool isPlaying = false;
        private bool isPaused = false;
        private bool isLooped = true;
        private bool nextSong = false;
        private bool previousSong = false;
        private int counter = 0;
        private double sliderTime;
        private TimeSpan time;
        private bool slide = false;
        string uri;

       public Player(MainView view)
        {
            this.view = view;
            
        }

        public void setSong(string uri)
        {
            this.uri = uri;
        }

        public void setPlayingFlag()
        {
            isPlaying = !isPlaying;
        }

        public void setSliderFlag()
        {
            slide = !slide;
        }

        public void setPauseFlag()
        {
            isPaused = !isPaused;
        }


        public void setSliderTime( double value)
        {
            sliderTime = value;
        }

        public TimeSpan getSliderTime()
        {
            return TimeSpan.FromSeconds(sliderTime);
        }
        public void  setTime(TimeSpan span)
        {
            time = span;
        }

        public string sliderTimeValueToString()
        {
            return Convert.ToString(TimeSpan.FromSeconds(sliderTime)).Substring(3);
        }

        public bool getPlayingFlag()
        {
            return isPlaying;
        }



        public void threadPlay()
        {
            while(true)
            {
                play();
                Thread.Sleep(100);
            }
        }



        private void initialize(Stream ms)
        {
            using (Stream stream = WebRequest.Create(uri)
                       .GetResponse().GetResponseStream())
            {
                byte[] buffer = new byte[32768];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
            }
        }
        public void play()
        {
            if (uri != null)
            {
                using (Stream ms = new MemoryStream())
                {
                    initialize(ms);

                    long c = ms.Length;
                    ms.Position = 0;


                    using (WaveStream blockAlignedStream =
                       new BlockAlignReductionStream(
                           WaveFormatConversionStream.CreatePcmStream(
                               new Mp3FileReader(ms))))
                    {
                        
                        if (!isPlaying)
                        {
                            isPlaying = true;
                            view.Dispatcher.Invoke(() =>
                                {
                                    view.currentTime.Content = blockAlignedStream.CurrentTime.ToString().Substring(3, 5);
                                    view.timeSlider.Value = blockAlignedStream.CurrentTime.TotalSeconds;

                                });
                            view.Dispatcher.Invoke(() =>
                            {
                                view.maxTime.Content = blockAlignedStream.TotalTime.ToString().Substring(3, 5);
                                view.timeSlider.Value = 0;
                                view.timeSlider.Maximum = blockAlignedStream.TotalTime.TotalSeconds;

                            });
                            waveOut.Init(blockAlignedStream);
                            waveOut.Play();

                        }

                        while (waveOut.PlaybackState == PlaybackState.Playing || waveOut.PlaybackState == PlaybackState.Paused)
                        {
                            if (slide)
                            {

                                view.Dispatcher.Invoke(() =>
                                {
                                    blockAlignedStream.CurrentTime = time;

                                });

                            }

                            if (nextSong)
                            {
                                nextSong = false;
                                waveOut.Stop();
                                isPlaying = false;
                                //podac nowy linkdp inicjalizacji
                                play();
                            }
                            if (isLooped)
                            {
                                if (ms.Position >= ms.Length)
                                {
                                    ms.Position = 0;
                                }
                            }
                            if (!isPaused)
                            {
                                waveOut.Play();
                                view.Dispatcher.Invoke(() =>
                                {
                                    view.currentTime.Content = blockAlignedStream.CurrentTime.ToString().Substring(3, 5);
                                    view.timeSlider.Value = blockAlignedStream.CurrentTime.TotalSeconds;

                                });

                            }
                            else
                                waveOut.Pause();

                            Thread.Sleep(100);
                        }
                    }

                }
            }




        }

    }

}
