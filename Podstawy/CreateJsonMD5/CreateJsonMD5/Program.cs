using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CreateJsonMD5
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Program creates a JSON with a filenames and a MD5 hashes used in the database.");
            System.Console.WriteLine("The files stored in the Container directory will be calculated and the result ");
            System.Console.WriteLine("will be thrown to the WriteJson.txt file in a main directory.\n");
            try
            {
                // Get the current directory.
                string path = Directory.GetCurrentDirectory();
                string target = path + "\\Container";
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }

                // Change the current directory.
                Environment.CurrentDirectory = (target);

                Console.WriteLine("The current directory is: \n{0}", target);

                string[] files = Directory.GetFiles(target);


                List<Results> resultRows = new List<Results>();
                int autoIncrement = 0;
                System.Console.WriteLine("Files in current directory are");
                foreach (string item in files)
                {
                    autoIncrement++;
                    Console.WriteLine("ID: {0}", autoIncrement);
                    var justFilename = Path.GetFileName(item);
                    Console.WriteLine("FileName: {0}", justFilename);
                    string hashFile = CalculateMD5(item);
                    Console.WriteLine("FileMD5: {0}\n", hashFile);
                    resultRows.Add(new Results { ID = autoIncrement, FileName = justFilename, FileMD5 = hashFile });
                }

                string json = JsonConvert.SerializeObject(resultRows);
                System.Console.WriteLine("\nResult:");
                System.Console.WriteLine(json);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "WriteJson.txt")))
                {
                    outputFile.WriteLine(json);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            System.Console.WriteLine("\nResult is stored in WriteJson.txt file, please press any key to finish.");
            System.Console.ReadKey();
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
