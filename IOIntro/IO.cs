// referenced: https://stackoverflow.com/questions/14877237/getting-all-file-names-from-a-folder-using-c-sharp
// https://stackoverflow.com/questions/7569904/easiest-way-to-read-from-and-write-to-files/7569938#7569938

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOIntro
{
    internal class IO
    {
        string dir = Path.Combine(Directory.GetCurrentDirectory(), "files");

        public IO()
        {
            Process();
        }

        private void Process()
        {
            // make sure dir isn't null
            if (Directory.Exists(dir))
            {
                readFiles(dir);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private void readFiles(string dirPath)
        {
            // get all the files in the dir
            string[] files = Directory.GetFiles(dirPath);

            foreach (var file in files)
            {
                // make sure all chars count as the same char
                string text = File.ReadAllText(file).ToLower();

                // remove spaces
                text = text.Replace(" ", "");

                // dictionary for chars & their counts
                Dictionary<char, int> charCount = new Dictionary<char, int>();

                foreach (char ch in text)
                {
                        // check if char exists in dictionary, add if it doesnt
                        if (!charCount.ContainsKey(ch))
                        {
                            charCount[ch] = 1;
                        }
                        else
                        {
                            // increment if it exists
                            charCount[ch]++;
                        }
                }

                // writes name & count
                Console.WriteLine($"File: {Path.GetFileName(file)}");
                foreach (var kvp in charCount)
                {
                    Console.WriteLine($"{kvp.Key} {kvp.Value}");
                }

            
                Console.WriteLine();
            }
        }

    }
    //it's printing 1 1 at the end here i don't know why it's doing that
}

