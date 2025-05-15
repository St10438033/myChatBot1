using System.Collections.Generic;
using System.IO;
using System;

namespace myChatBot1
{
    public class memory_storage
    {
        private string user_question;
        private string user_name;



        // Constructor to initialize user_name and user_question
        public memory_storage()
        {
                       
            Console.WriteLine("|| Chatbot : Please enter your ANY value below to start PRO CYBER SECURITY CHATBOT : ||");
            user_name = Console.ReadLine();

            new memory_storage().show_history();
        }

        // Method to save user input to memory
        public void safe_to_memory()
        {
            try
            {
                // Get full path of the project
                string full_path = AppDomain.CurrentDomain.BaseDirectory;
                // Replace the bin\\Debug\\
                string new_path = full_path.Replace("bin\\Debug\\", "");
                // Combine path
                string path = Path.Combine(new_path, "memoryStore.txt");
                var memory_loaded = memory_load(path);

                // Check if memory loaded
                foreach (var check in memory_loaded)
                {
                    Console.WriteLine(check);
                }
                // User data to memory
                memory_loaded.Add(user_name + "," + user_question);
                // Store to memory recall
                File.WriteAllLines(path, memory_loaded);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving to memory: " + ex.Message);
            }
        } // end of method
          // Method to show history of the current user
        public void show_history()
        {
            try
            {
                // Get full path of the project
                string full_path = AppDomain.CurrentDomain.BaseDirectory;
                // Replace the bin\\Debug\\
                string new_path = full_path.Replace("bin\\Debug\\", "");
                // Combine path
                string path = Path.Combine(new_path, "memoryStore.txt");

                // Load existing memory
                var memory_loaded = memory_load(path);
                string history = "";
                foreach (string check in memory_loaded)
                {
                    if (check.Contains(user_name))
                    {
                        history += check + "\n";
                    }
                }
                if (string.IsNullOrEmpty(history))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|| Chatbot: No history found. ||");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|| Chatbot: Here is your history:\n" + history + " ||");
                    Console.ResetColor();
                }

                
            }

            catch (Exception ex)
            {

                Console.WriteLine("Error showing history: " + ex.Message);
            }

        }

        // Method to load memory when it runs
        private List<string> memory_load(string path)
        {
            try
            {
                // Checking if the file exists before
                if (File.Exists(path))
                {
                    // Then return the List of memory_load
                    return new List<string>(File.ReadAllLines(path));
                }
                else
                {
                    // Create the file if not found
                    File.CreateText(path).Close();
                    return new List<string>();
                } // end of else
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading memory: " + ex.Message);
                return new List<string>();

            } // end of memory load method
        } // end of class
    }
}














