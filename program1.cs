using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameFilesInFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirpath = @"C:\Users\spyros.magripis\Pictures\LOS_rainbow";
            string backupDir = dirpath + @"\backup";
            int incrementValue = 2;
            Directory.CreateDirectory(backupDir);
            int exitValue = 9; // make room before this picture
            DirectoryInfo d = new DirectoryInfo(dirpath);
            FileInfo[] infos = d.GetFiles();
            string[] backupList = Directory.GetFiles(dirpath); // make a back up list
            int fCount = Directory.GetFiles(dirpath, "*", SearchOption.TopDirectoryOnly).Length; //get number of files FIX IT TO GET THE LARGEST NAME OF THE FILE
            int flag = 0;
            // copy the pic files    
            foreach (string f in backupList)
            {
                // Remove Path from the file name.
                string fName = f.Substring(dirpath.Length + 1);
               File.Copy(Path.Combine(dirpath,fName),Path.Combine(backupDir,fName),true);
            }
            foreach (FileInfo f in infos.Reverse())          
            {
                File.Move(f.FullName, f.FullName.ToString().Replace((fCount - flag).ToString(), (fCount - flag + incrementValue).ToString()));
                flag += 1;
                if (fCount-flag==exitValue-2)
                {
                    break;
                }
            }

        }
    }
}
