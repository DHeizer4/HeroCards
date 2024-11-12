namespace Cards_Games.InputOutput
{
    using System;
    using System.IO;

    public class FileHandler
    {

        public static bool ConfirmFileExists(string filePath)
        {
            bool exists = false;

            if (FileHandler.ConfirmFileExists(filePath))
            {
                exists = true;
            }

            return exists;
        } 

        public static void WriteToFile(string filePath, string content)
        {
            try
            {
                // Create a file and write to it
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(content);
                }
                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }

        public static void AppendToFile(string filePath, string content)
        {
            try
            {
                // Append content to an existing file
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(content);
                }
                Console.WriteLine("Content appended to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error appending to file: " + ex.Message);
            }
        }

        public static string ReadFromFile(string filePath)
        {
            try
            {
                // Read the contents of the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from file: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
