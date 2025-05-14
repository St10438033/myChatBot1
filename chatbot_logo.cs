using System.Drawing;
using System.IO;
using System;

namespace myChatBot1
{
    public class chatbot_logo //display logo class
    {
        public void logo()
        {

            //retrieves project path {getter}
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            string newPath = path_project.Replace("bin\\Debug\\", "");

            //replaced and combining project with Logo
            string full_path = Path.Combine(newPath, "Pro Chat LOGO 2.jpg");

            //pixel data
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(110, 110));


            //Nest loop to run & print logo height & width
            //& Convert to ASCII ART
            for (int height = 0; height < image.Height; height++)
            {

                for (int width = 0; width < image.Width; width++)
                {
                    //color
                    Color pc = image.GetPixel(width, height);
                    int color = (pc.R + pc.B + pc.G) / 3;

                    //adding chars to use for printing logo
                    char asciiArt = color > 200 ? '.' : color > 150 ? '*' : color > 50 ? '#' : '@';
                    Console.Write(asciiArt);

                }

                Console.WriteLine();
            }

        }
    }//end of display logo class
}