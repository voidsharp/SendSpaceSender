using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SendSpaceGui.FileArchiver
{
    class ArchiverEncryptor
    {
        private string RarPath;



        public void SetRarPath(string pathToRarExe)
        {
            RarPath = pathToRarExe;
        }
        public string PackAndEncryptFiles(FileStream fileForPassword, string destination, string[] fileNamesToPack)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var s = new byte[15];
            var hash = MD5.Create();

            rnd.NextBytes(s);
            var generatedPassword = GetMd5Hash(hash, Encoding.ASCII.GetString(s));

            var rarProc = new Process
            {
                StartInfo =
                {
                    UseShellExecute = true,
                    FileName = $"{RarPath}",
                    Arguments = $"a -m5 -ep1 -y -hp{generatedPassword} {destination} {fileNamesToPack}"
                }
                /*a -m5 -ep1 -hp1111 -y*/
            };
            rarProc.Start();
            var passAsBytes = Encoding.ASCII.GetBytes(generatedPassword);
            fileForPassword.Write(passAsBytes, 0, passAsBytes.Length);
            //Clipboard.SetText(password);
            return generatedPassword;
        }
        public string ArchiveAndEncryptFileList(string[] inputFiles, string outputFileName = "out.rar", string passwordFileName = "password.txt")
        {
            if (inputFiles == null || inputFiles.Length < 1)
                throw new ArgumentException(nameof(inputFiles));
            var nonExistantFile = GetNonExistFileNameFromList(inputFiles);
            if (nonExistantFile != null)
                throw new FileNotFoundException(nonExistantFile);

            var outputFileDir = Path.GetDirectoryName(inputFiles.FirstOrDefault());
            var outputFilePath = Path.Combine(outputFileDir, outputFileName);
            var passwordFilePath = Path.Combine(outputFileDir, passwordFileName);

            if (File.Exists(passwordFilePath))
                File.Delete(passwordFilePath);
            if (File.Exists(outputFilePath))
                File.Delete(outputFilePath);

            var passwordFile = File.Open(Path.Combine(outputFileDir, passwordFileName), FileMode.OpenOrCreate);
            var passwordAsString = PackAndEncryptFiles(passwordFile, outputFilePath, inputFiles);
            //Console.WriteLine($"Pass file name {passwordFileName}");
            return passwordAsString;
        }

        string GetNonExistFileNameFromList(IEnumerable<string> fileList)
        {
            foreach (var file in fileList)
            {
                if (!File.Exists(file))
                {
                    return file;
                }
            }
            return null;
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
    }




}
