using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;

namespace FileSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays of fileTypes and their extensions
            var picturesExtensions = new string[] {".jpeg", ".jpg", ".png"};
            var videoExtensions = new string[] {".mkv", "mp4", ".avi", ".mov"};
            var musicExtensions = new string[] {".mp3", ".wav"};
            var compressedExtensions = new string[] {".zip", ".rar"};
            var pdfExtensions = new string[] {".pdf"};
            var executableExtensions = new string[] {".exe"};
            var textExtensions = new string[] {".txt"};

            Dictionary<string, string[]> fileTypes = new Dictionary<string, string[]>();
            fileTypes.Add("Pictures", picturesExtensions);
            fileTypes.Add("Videos", videoExtensions);
            fileTypes.Add("Music", musicExtensions);
            fileTypes.Add("Compressed", compressedExtensions);
            fileTypes.Add("PDF", pdfExtensions);
            fileTypes.Add("Executable", executableExtensions);
            fileTypes.Add("Text", textExtensions);

            // Loading the Files
            var pathToSort = @"C:\Users\user\Downloads\";
            var destinationPath = @"C:\Users\user\Downloads\SortedFiles";
            string[] filesToSort = Directory.GetFiles(pathToSort, "*", SearchOption.TopDirectoryOnly);

            
            
            foreach (string file in filesToSort)
            {
                FileInfo sourceFile = new FileInfo(file);
                foreach (var type in fileTypes)
                {
                    if (type.Value.Contains(sourceFile.Extension))
                    {
                        string destinationOfFile = destinationPath + @"\"+  type.Key + @"\" + sourceFile.Name;
                        Console.WriteLine($"File : {sourceFile.Name}");
                        Console.WriteLine($"Will be moved to : {destinationOfFile}");
                        new FileInfo(destinationOfFile).Directory.Create();
                        File.Move(sourceFile.FullName, destinationOfFile);
                    }
                }
            }
        }
    }
}
