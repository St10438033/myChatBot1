using System.IO;
using System.Media;
using System;

namespace myChatBot1
{
    public class chatbot_Sound //play greeting sound class
    {

        public void play_sound()
        {

            //retrieve the app location
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(full_location);


            //replace the folders
            string new_location = full_location.Replace("bin\\Debug\\", "");

            Console.WriteLine(new_location);


            //combine both the new location and audio file
            string full_path = Path.Combine(new_location, "Pro Chat greet 2.wav");


            //try play or catch & display error w/o crashing, error handling
            try
            {
                using (SoundPlayer sound = new SoundPlayer(full_path))
                {

                    sound.Play(); //play function to play obj sound
                }
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);

            } //end of try&catch
        }

    }   //end of greeting sound class
}