// Copyright (c) 2016-2017 DirectX_Renderer - DoxCode - https://github.com/DoxCode
//
// Screen_capture capture the screen using DirectX technology, this program can render ~70 photos per second (fps) with native quality.
//
// Very useful for example to processing data stream in the screen, 
// searching patterns, automation, pixelHacking etc... or for desktop recorder programs (I don't recommend this last, I'm sure exist best alternatives).
//
// Using:
// SharpDX, SharpDX.Direct3D11, SharpDX.DXGI
//
// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN

using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace DirectX_Renderer.Screen_Stream
{
    public class Screen_capture
    {
           // private byte[] _previousScreen; // Used to save the last Screen. Not used for now.
            private bool _run, _init;

        public static Bitmap bm;

            public int Size { get; private set; }


            //Form only used to give a reference to calculate the average time.
            // You can remove this references if you want.
            private Screen_Stream form;
            public Screen_capture(Screen_Stream form)
            {
                this.form = form;
            }

            public void Start()
            {
                _run = true;
                var factory = new Factory1();
                var adapter = factory.GetAdapter1(0);
                var device = new SharpDX.Direct3D11.Device(adapter);
                //Get front buffer of the adapter
                var output = adapter.GetOutput(0);
                var output1 = output.QueryInterface<Output1>();

                // Screen resolution
                int width = output.Description.DesktopBounds.Right;
                int height = output.Description.DesktopBounds.Bottom;

                // Create Staging texture CPU - accessible
               var textureDesc = new Texture2DDescription
                {
                    CpuAccessFlags = CpuAccessFlags.Read,
                    BindFlags = BindFlags.None,
                    Format = Format.B8G8R8A8_UNorm,
                    Width = width,
                    Height = height,
                    OptionFlags = ResourceOptionFlags.None,
                    MipLevels = 1,
                    ArraySize = 1,
                    SampleDescription = { Count = 1, Quality = 0 },
                    Usage = ResourceUsage.Staging
                };
                var screenTexture = new Texture2D(device, textureDesc);

                Task.Factory.StartNew(() =>
                {
                    using (var copy_Output = output1.DuplicateOutput(device))
                    {
                        Stopwatch time; // Time counter, you can remove it.
                        while (_run)
                        {
                             time = System.Diagnostics.Stopwatch.StartNew();
                            try
                            {
                                SharpDX.DXGI.Resource screenResource;
                                OutputDuplicateFrameInformation copy_FrameInformation;

                                copy_Output.AcquireNextFrame(5, out copy_FrameInformation, out screenResource);

                                using (var screenTexture2D = screenResource.QueryInterface<Texture2D>())
                                    device.ImmediateContext.CopyResource(screenTexture2D, screenTexture);

                                var mapSource = device.ImmediateContext.MapSubresource(screenTexture, 0, MapMode.Read, SharpDX.Direct3D11.MapFlags.None);

                                var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                               
                                var boundsRect = new System.Drawing.Rectangle(0, 0, width, height);
                                var mapDest = bitmap.LockBits(boundsRect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                                var sourcePtr = mapSource.DataPointer;
                                var destPtr = mapDest.Scan0;

                                for (int y = 0; y < height; y++)
                                {
                                    SharpDX.Utilities.CopyMemory(destPtr, sourcePtr, width * 4);
                                    sourcePtr = IntPtr.Add(sourcePtr, mapSource.RowPitch);
                                    destPtr = IntPtr.Add(destPtr, mapDest.Stride);
                                }

                                // Release source and dest locks
                                bitmap.UnlockBits(mapDest);
                                device.ImmediateContext.UnmapSubresource(screenTexture, 0);

                                using (var ms = new MemoryStream())
                                {
                                    bitmap.Save(ms, ImageFormat.Bmp);
                                    ScreenRefreshed?.Invoke(this, bitmap);
                                    //ScreenRefreshed?.Invoke(this, ms.ToArray()); //To send the image array
                                    _init = true;
                                }
                                
                                screenResource.Dispose();
                                copy_Output.ReleaseFrame();
                            }
                            catch (SharpDXException e)
                            {
                                // Some graphics cards could spam warnings for this.
                                if (e.ResultCode.Code != SharpDX.DXGI.ResultCode.WaitTimeout.Result.Code)
                                {
                                    Trace.TraceError(e.Message);
                                    Trace.TraceError(e.StackTrace);
                                }
                            }

                            // Time, you can remove too. 
                            // Just add to a List the value of the time wasted to calculate the averrage.
                            time.Stop();
                            form.last_times.Add(time.ElapsedMilliseconds);

                        }
                    }
                });
                while (!_init) ;
            }

            public void Stop()
            {
                _run = false;
            }

            public EventHandler<Bitmap> ScreenRefreshed;        
    }
}
