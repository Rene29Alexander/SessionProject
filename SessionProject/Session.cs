using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SessionProject
{
    class FileManager
    {
        String pathDirectory = "";
        public FileManager()
        {

            DirectoryInfo directoryInfo = System.IO.Directory.CreateDirectory(".\\store");
            pathDirectory = directoryInfo.FullName;

        }

        public String readFile(String fileName)
        {
            fileName = System.IO.Path.Combine(pathDirectory, fileName);
            string text = System.IO.File.ReadAllText(fileName);
            return text;
        }

        public String[] getLines(String file)
        {
            return this.readFile(file).Split('\n');
        }

        public async void writeFile(String text, String fileName)
        {
            fileName = System.IO.Path.Combine(pathDirectory, fileName);
            using StreamWriter fileStream = new StreamWriter(fileName, append: true);
            await fileStream.WriteLineAsync(text);
            fileStream.Close();
        }


        public void createFile(String fileName)
        {
            fileName = System.IO.Path.Combine(pathDirectory, fileName);
            System.IO.File.Create(fileName).Close();


        }

        public void deleteFile(String fileName)
        {

            fileName = System.IO.Path.Combine(pathDirectory, fileName);
            System.IO.File.Delete(fileName);

        }

        public Boolean existsFile(String fileName)
        {
            fileName = System.IO.Path.Combine(pathDirectory, fileName);

            return System.IO.File.Exists(fileName);

        }



        public async void deleteLine(int line, String fileName)
        {
            fileName = System.IO.Path.Combine(pathDirectory, fileName);
            string text = this.readFile(fileName);
            string[] lines = text.Split('\n');


            await File.WriteAllLinesAsync(fileName, lines);
        }
    }

    class Session
    {

        String fileStoreCredentials = "storecredentials.txt";
        FileManager fileManager = null;
        const string passwordAdmin = "123";
        public Session()
        {
            this.fileManager = new FileManager();
            if (!fileManager.existsFile(fileStoreCredentials))
            {
                fileManager.createFile(fileStoreCredentials);
                fileManager.writeFile("admin:123", fileStoreCredentials);
            }
        }