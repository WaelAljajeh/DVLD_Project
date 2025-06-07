using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Markup;
namespace DVLD_Project.GlobalClasses
{
    public class clsUtil
    {
        public static string GenrateNewGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public static string ReplacementFileWithGuid(string SourcePath)
        {
            string ext;
            FileInfo fileInfo = new FileInfo(SourcePath);
            ext = fileInfo.Extension;
            return GenrateNewGuid() + ext;
        }
        public static bool CreateFolderIfNotExist(string Path) {
            if (!Directory.Exists(Path))
            {
                try
                {
                    Directory.CreateDirectory(Path);
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        
            return true;
                
        }
        
        public static bool CopyImagetoFile(ref string SourceImageFile)
        {
            
            string DestinationFolder = @"c:\\DVLD-HHH-Images\\"; 
            if(!CreateFolderIfNotExist(DestinationFolder))
            {
                return false;
            }
            string DestinationImage = DestinationFolder + ReplacementFileWithGuid(SourceImageFile);
            try
            {
                File.Copy(SourceImageFile, DestinationImage, true);
            }
            catch(IOException)
            {
                return false;
            }
            SourceImageFile = DestinationImage;
            return true;
        }
    }
}
