// Copyright (c) 2016-2017 DirectX_Renderer - DoxCode - https://github.com/DoxCode
//
//  Used as a test.
//  
// Update the images captured for Screen_capture in a PictureBox to show the average fps and ms that took.
//


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectX_Renderer.Screen_Stream
{
    public partial class Screen_Stream : Form
    {
        private Screen_capture screen_capture = null;

        public Screen_Stream()
        {
            InitializeComponent();
        }

        private bool isStreaming = false;
        private void btn_stream_Click(object sender, EventArgs e)
        {
            if(isStreaming)
            {
                btn_stream.Text = "Stream Desktop";

                if (screen_capture != null)
                {
                    screen_capture.Stop();
                    screen_capture = null;
                }
            }
              else
            {
                if (screen_capture != null)
                    return;

                btn_stream.Text = "Stop Stream";

                screen_capture = new Screen_capture(this);
                screen_capture.ScreenRefreshed += (_sender, data) =>
                {
                    UpdateFrame(data);
                };
                screen_capture.Start();

                Thread thread = new Thread(() => calculate_average());
                thread.SetApartmentState(ApartmentState.STA); 
                thread.Start();

            }
            isStreaming = !isStreaming;
        }

        public List<long> last_times = new List<long>();
        private void UpdateFrame(Bitmap data)
        {
            //Ofc, is not optimised.
            //Could generate OperationException.
            stream_box.Image = data;
        }

        /// <summary>
        /// Calculate the time wasted creating a Bitmap and the number of frames per second.
        /// </summary>
       private void calculate_average()
        {
            Thread.Sleep(100);
            while (isStreaming)
            {
                Thread.Sleep(500);
                try
                {
                    long val = 0;
                    foreach (long l in last_times)
                    {
                        val += l;
                    }

                    val = val / last_times.Count;
                    long fps = (long)(1000/val) ;

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        _average_label.Text = val.ToString() + " ms";
                        _fps_label.Text = fps + " fps";
                    });

                    if (last_times.Count > 300)
                    {
                        int range = last_times.Count - 300;
                        last_times.RemoveRange(0, range);
                    }
                }
                catch(Exception e)
                { }
            }
        }


        private void Screen_Stream_FormClosing(object sender, FormClosingEventArgs e)
        {
            isStreaming = false;
            if (screen_capture != null)
            {
                screen_capture.Stop();
                screen_capture = null;
            }
        }
    }
}
