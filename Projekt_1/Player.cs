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
using Projekt_1.Models;

namespace Projekt_1
{
    public class Player
    {
        private WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback());
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
        private int currnetSong=0;
        private List<Songs> songs=new List<Songs>();
        private Songs song = null;


        string uri="";


       public Player(MainView view)
        {
            this.view = view;
            
        }

        public void setSong(Songs song)
        {
            if(isPlaying==true)
            {
                waveOut.Stop();
                isPlaying = false;
            }
            this.song = song;
        }


        public void setPlaylist(List<Songs> songs)
        {
            this.songs = songs;
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

        public void setLoopFlag()
        {
            isLooped = !isLooped;
        }

        public TimeSpan getSliderTime()
        {
            return TimeSpan.FromSeconds(sliderTime);
        }
        public void  setTime(TimeSpan span)
        {
            time = span;
        }


        public void emptyPlaylist()
        {
            songs.Clear();
        }
        public string sliderTimeValueToString()
        {
            return Convert.ToString(TimeSpan.FromSeconds(sliderTime)).Substring(3);
        }

        public bool getPlayingFlag()
        {
            return isPlaying;
        }


        public void setNextSongFlag()
        {
           
            nextSong = !nextSong;
        }

        public void setPreviousSongFlag()
        {
            previousSong = !previousSong;
        }


        public void setCurrentSong(Songs s)
        {
            if (songs.Contains(s))
            {
                currnetSong = songs.IndexOf(s);
                song = s;
            }
                
            
        }


        public void setVolume(float value)
        {
            waveOut.Volume = value;
        }


        public void threadPlay()
        {
            waveOut.Volume = 0.50f;
            view.Dispatcher.Invoke(() =>
            {
                view.volumeSlider.Value = waveOut.Volume;

            });
            while (true)
            {
                play();
                Thread.Sleep(100);
            }
        }

        private void initialize(Stream ms)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            
            using (Stream stream = WebRequest.Create(song.Song)
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
            if (song!=null)
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
                        view.Dispatcher.Invoke(() =>
                        {
                            view.currentlyPlayingLabel.Content = song.Title;
                           
                        });

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
                                if (songs != null && songs.Count!=0)
                                {
                                    currnetSong = (currnetSong + 1) % songs.Count;
                                    nextSong = false;
                                    waveOut.Stop(); 
                                    isPlaying = false;
                                    song = songs[currnetSong];
                                    play();
                                }
                            }

                            if (previousSong)
                            {
                                if (songs != null && songs.Count != 0)
                                {
                                    currnetSong = currnetSong - 1;
                                    if (currnetSong < 0)
                                        currnetSong = songs.Count-1;
                                    previousSong = false;
                                    waveOut.Stop();
                                    isPlaying = false;
                                    song = songs[currnetSong];
                                    play();
                                }

                            }

                            if (isLooped)
                            {
                                if (ms.Position >= ms.Length)
                                {
                                    ms.Position = 0;
                                    blockAlignedStream.CurrentTime = TimeSpan.Zero;
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
