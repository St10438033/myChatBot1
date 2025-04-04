using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;
using System.IO;
using System.Threading;

namespace myChatBot1
{
    public class chatbot //entry class
    {
        static void Main(string[] args)
        {

            //instances
            chatbot_backend backend = new chatbot_backend();

            chatbot_logo logo = new chatbot_logo();

            chatbot_Sound sound = new chatbot_Sound();

            // Display the logo
            logo.logo();

            // Play the sound
            sound.play_sound();

            // Start chatbot interaction
            backend.chatbot_frontend();
        }

    }

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


    public class chatbot_backend //logic & user interaction class
    {

        //Arrays for storing backend responses and not-respond-to questions
        private ArrayList response = new ArrayList();
        private ArrayList not_respond = new ArrayList();

        public chatbot_backend()
        {
            //Constructors that hold/store/add responses and not-respond-to questions/topics and answers
            chatbot_Not_Respond();
            chatbot_Response();
        }

        private void chatbot_Response() //upload possible responses
        {

            response.Add("Phishing is a type of cyber attack where attackers impersonate legitimate organizations or individuals to deceive victims into providing sensitive information, such as passwords, credit card numbers, or personal details.");
            response.Add("If you suspect a phishing attempt, do not click on any links or download attachments. Take a moment to assess the situation.");
            response.Add("Safe browsing involves taking precautions while navigating the internet to protect personal information and avoid cyber threats like malware and phishing. To ensure security, use updated browsers, enable security features, avoid suspicious links, and regularly check for website authenticity.");
            response.Add("A cyber attack is an intentional attempt to breach the security of a computer system or network, often to steal, alter, or destroy data. Five common types of cyber attacks include malware, phishing, denial-of-service (DoS) attacks, man-in-the-middle attacks, and SQL injection.");
            response.Add("Avoid reusing passwords across different accounts to minimize the risk of multiple accounts being compromised if one password is leaked.");
            response.Add("Change your passwords periodically and immediately update them if you suspect any compromise. This helps to mitigate risks associated with potential breaches.");

        }
        private void chatbot_Not_Respond() //upload possible !responses
        {
            not_respond.Add("");
            not_respond.Add("");
            not_respond.Add("");
            not_respond.Add("");
            not_respond.Add("");
            not_respond.Add("");
        }

        public void chatbot_frontend() //interaction method
        {

            //variables
            String user_name;
            String user_question;


            //This si the console/chatbot frontend experience
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|| ================================================================================= ||");

            Thread.Sleep(2000); //control for response time
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|| Chatbot : Hello, Welcome to ProCyber Security ChatBot ||");

            Thread.Sleep(3000); //control for response time
            Console.WriteLine("|| This Chatbot will assist and advice you on Safe browsing and other Cyber Security related challenges ||");

            Console.WriteLine("|| =================================================================================================================== ||");

            Thread.Sleep(3000); //control for response time
            Console.WriteLine("|| Chatbot : What is your name ? ||" + "\n");

            Console.ForegroundColor = ConsoleColor.Green;
            user_name = Console.ReadLine();

            Console.WriteLine("|| =============================================================================================== ||" + "\n");

            Thread.Sleep(2500); //control for response time
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|| Chatbot : " + user_name + ", Welcome to ProCyber Security ChatBot." + "\n");

            Console.WriteLine("|| =============================================================================================== ||" + "\n");

            Thread.Sleep(3000); //control for response time
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|| Chatbot : " + user_name + ", How can we help you today? Search below ...");

            Console.WriteLine("|| =============================================================================================== ||" + "\n");

            Console.ForegroundColor = ConsoleColor.Green;
            user_question = Console.ReadLine();

            Console.WriteLine("|| =============================================================================================== ||" + "\n");


            String[] words = user_question.Split(' ');
            ArrayList other_words = new ArrayList();


            //Start filter for loop
            for (int index = 0; index < words.Length; index++)
            {

                //ignore and store
                if (!not_respond.Contains(words[index]))
                {


                    //hold value to filter
                    other_words.Add(words[index]);
                }

                //Console.WriteLine(other_words[index]);

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Boolean found = false;
            string report = string.Empty;

            for (int index = 0; index < other_words.Count; index++)
            {

                //loop to find possible respond
                for (int index2 = 0; index2 < response.Count; index2++)
                {

                    //Check to response
                    if (response[index2].ToString().Contains(other_words[index].ToString()))
                    {

                        found = true;
                        report = response[index2].ToString();
                        Console.WriteLine("|| Chatbot : " + response[index2].ToString() + " ||");
                        break;
                    }
                }
            }           

                    if (found)
                    {
                        Thread.Sleep(3000); //control for response time
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("|| Chatbot : " + response + " ||" + "\n");

                        Console.ForegroundColor= ConsoleColor.Blue;

                        Console.WriteLine("|| Chatbot : " + user_name + " For any further question.. Exit & Run Pro CyberSecurity Chatbot again. ||");

                        Console.WriteLine("|| ============================================================================================================================================================================================== ||" + "\n");


                    }
                    else
                    {
                        Thread.Sleep(3000); //control for response time
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|| Chatbot : " + user_name + ", Please search something related to Cyber Security e.g Password Safety, Phishing or Safe Browsing.");
                        Console.WriteLine("|| =============================================================================================== ||" + "\n");

                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine("|| Chatbot : " + user_name + " For any further question.. Exit & Run Pro CyberSecurity Chatbot again. ||");

                        Console.WriteLine("|| ============================================================================================================================================================================================== ||" + "\n");

            }

            Console.ResetColor();

                

        }
    }
}
