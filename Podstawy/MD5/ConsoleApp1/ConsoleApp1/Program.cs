using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Get the current directory.
                string path = Directory.GetCurrentDirectory();
                string target = path + "\\Container";
                Console.WriteLine("The current directory is {0}", target);
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }

                // Change the current directory.
                Environment.CurrentDirectory = (target);
                if (target.Equals(Directory.GetCurrentDirectory()))
                {
                    Console.WriteLine("You are in the temp directory.");
                }
                else
                {
                    Console.WriteLine("You are not in the temp directory.");
                }

                Console.WriteLine("The current directory is {0}", target);

                string[] files = Directory.GetFiles(target);


                List<Results> resultRows = new List<Results>();
                int autoIncrement = 0;
                foreach (string item in files)
                {
                    autoIncrement++;
                    var justFilename = Path.GetFileName(item);
                    Console.WriteLine("Files in current directory are {0}", justFilename);
                    string hashFile = CalculateMD5(item);
                    Console.WriteLine("Calculate MD5: {0}", hashFile);
                    resultRows.Add(new Results { ID = autoIncrement, FileName = justFilename, FileMD5 = hashFile });
                }

                string json = JsonConvert.SerializeObject(resultRows);

                System.Console.WriteLine(json);

                string[] lines = { "First line", "Second line", "Third line" };

                // Set a variable to the My Documents path.
                //string mydocpath =
                //    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "WriteJson.txt")))
                {
                        outputFile.WriteLine(json);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            //string path = Directory.GetCurrentDirectory();



            string source = "Hello World!";
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);

                Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

                Console.WriteLine("Verifying the hash...");

                if (VerifyMd5Hash(md5Hash, source, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }
            }



        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
