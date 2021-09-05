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

        public Boolean login(String username, String password)
        {
            Boolean loginSuccess = false;

            if (username.Equals("admin") && password.Equals(passwordAdmin))
                return true;

            string[] lines = this.fileManager.getLines(this.fileStoreCredentials);
            for (int index = 0; index < lines.Length; index++)
            {

                string[] credentials = lines[index].Split(':');

                if (credentials.Length > 1)
                {
                    if (loginSuccess)
                        break;

                    if (credentials[0].Equals(username) && credentials[1].Replace("\r", "").Equals(password))
                    {

                        loginSuccess = true;
                    }
                    else
                    {

                        loginSuccess = false;
                    }

                }



            }
            return loginSuccess;
        }

        public void addCredential(String username, String password)
        {
            fileManager.writeFile(username + ":" + password, fileStoreCredentials);
        }


        public void addTextFile(String text, String fileName)
        {

            fileManager.writeFile(text, fileName);
        }


        public void deleteFile(String fileName)
        {
            fileManager.deleteFile(fileName);
        }

        public void newFile(String fileName)
        {
            fileManager.createFile(fileName);
        }

        public String readFile(String fileName)
        {
            return fileManager.readFile(fileName);
        }


    }
}
