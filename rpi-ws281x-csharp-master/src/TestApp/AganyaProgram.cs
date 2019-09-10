using rpi_ws281x;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class AganyaProgram : IAnimation
    {
        public void Execute(AbortRequest request)
        {
            Console.Clear();
            Console.Write("How many LEDs to you want to use: ");

            var ledCount = Int32.Parse(Console.ReadLine());

            //The default settings uses a frequency of 800000 Hz and the DMA channel 10.
            var settings = Settings.CreateDefaultSettings();

            //Set brightness to maximum (255)
            //Use Unknown as strip type. Then the type will be set in the native assembly.
            settings.Channels[0] = new Channel(ledCount, 18, 255, false, StripType.WS2812_STRIP);

            var controller = new WS281x(settings);

            //int ledIndex = 0;
            //int rad = 0;
            //int green = 0;
            //int blue = 0;
            while (!request.IsAbortRequested)
            {
                //Console.Write("rad,green,blue");//"ledIndex,rad,green,blue");
                //string input = Console.ReadLine();
                //string[] split = input.Split(',');

                ////ledIndex = Convert.ToInt16(split[0]);
                //rad = Convert.ToInt16(split[0]);
                //green = Convert.ToInt16(split[1]);
                //blue = Convert.ToInt16(split[2]);

                int maxBrigtness = 100;
                bool flg = false;
                for (int blue = 0; blue < maxBrigtness; blue++)
                {
                    for (int green = 0; green < maxBrigtness; green++)
                    {
                        for (int rad = 0; rad < maxBrigtness; rad++)
                        {
                            for (int i = 0; i < ledCount; i++)
                            {
                                controller.SetLEDColor(0, i, Color.FromArgb(rad, green, blue));
                            }
                            controller.Render();
                            System.Threading.Thread.Sleep(10);
                            if (!request.IsAbortRequested)
                                break;
                        }

                        for (int rad = maxBrigtness; rad > 0; rad--)
                        {
                            for (int i = 0; i < ledCount; i++)
                            {
                                controller.SetLEDColor(0, i, Color.FromArgb(rad, green, blue));
                            }
                            controller.Render();
                            System.Threading.Thread.Sleep(10);
                            if (!request.IsAbortRequested)
                                break;
                        }

                        if (flg)
                            break;
                    }

                    for (int green = maxBrigtness; green > 0; green--)
                    {
                        for (int rad = 0; rad < 100; rad++)
                        {
                            for (int i = 0; i < ledCount; i++)
                            {
                                controller.SetLEDColor(0, i, Color.FromArgb(rad, green, blue));
                            }
                            controller.Render();
                            System.Threading.Thread.Sleep(10);
                            if (!request.IsAbortRequested)
                                break;
                        }

                        for (int rad = 100; rad > 0; rad--)
                        {
                            for (int i = 0; i < ledCount; i++)
                            {
                                controller.SetLEDColor(0, i, Color.FromArgb(rad, green, blue));
                            }
                            controller.Render();
                            System.Threading.Thread.Sleep(10);
                            if (!request.IsAbortRequested)
                                break;
                        }

                        if (flg)
                            break;
                    }
                    if (flg)
                        break;
                }


            }
            

        }
    }
}
