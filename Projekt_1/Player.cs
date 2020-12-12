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
using System.Windows.Forms;

namespace Projekt_1
{
    public class Player
    {

        private MainView view;
        private List<Songs> songs;
        public Boolean isPaused = false, isSliding = false, reset = false;
        public double time;

        public Player(MainView view)
        {
            this.view = view;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        public void setSongs(List<Songs> songs)
        {
            this.songs = songs;
            reset = true;
        }

        public void threadPlay()
        {
            while (true)
            {
                play();
                Thread.Sleep(100);
            }
        }

        public void play()
        {
            if (songs == null)
                return;

            foreach (Songs s in songs)
            {
                using (Stream ms = new MemoryStream())
                {
                    using (Stream stream = WebRequest.Create(s.Song)
                        .GetResponse().GetResponseStream())
                    {
                        byte[] buffer = new byte[32768];
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                    }

                    ms.Position = 0;
                    using (WaveStream blockAlignedStream =
                        new BlockAlignReductionStream(
                            WaveFormatConversionStream.CreatePcmStream(
                                new Mp3FileReader(ms))))
                    {
                        using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                        {
                            view.Dispatcher.Invoke(() =>
                            {
                                view.timeSlider.Maximum = blockAlignedStream.TotalTime.TotalSeconds;
                                view.timeSlider.Value = 0;
                                view.maxTime.Content = blockAlignedStream.TotalTime.ToString().Substring(3, 5);
                            });
                            waveOut.Init(blockAlignedStream);
                            waveOut.Play();
                            while (waveOut.PlaybackState == PlaybackState.Playing)
                            {
                                while (isPaused)
                                {
                                    if (waveOut.PlaybackState == PlaybackState.Playing)
                                        waveOut.Pause();
                                    if (isSliding == true)
                                    {
                                        blockAlignedStream.CurrentTime = TimeSpan.FromSeconds(time);
                                        view.Dispatcher.Invoke(() =>
                                        {
                                            view.currentTime.Content = blockAlignedStream.CurrentTime.ToString().Substring(3, 5);
                                        });
                                    }
                                    if (reset == true)
                                    {
                                        reset = false;
                                        return;
                                    }
                                    System.Threading.Thread.Sleep(100);
                                }
                                if (waveOut.PlaybackState == PlaybackState.Paused)
                                    waveOut.Play();
                                view.Dispatcher.Invoke(() => {
                                    view.timeSlider.Value = blockAlignedStream.CurrentTime.TotalSeconds;
                                    view.currentTime.Content = blockAlignedStream.CurrentTime.ToString().Substring(3, 5);
                                });
                                if (reset == true)
                                {
                                    reset = false;
                                    return;
                                }
                                System.Threading.Thread.Sleep(100);
                            }
                        }
                    }
                }
            }
            isPaused = true;
        }

    }
}
