using Microsoft.AspNetCore.Http;
using System;
using System.IO;


namespace Demo.prestentaionlayer.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFiles(IFormFile file, string FolderName) 
        {
            //1. Get Located Folder Path
            //string FolderPath = "C:\\Users\\Ahmed\\source\\repos\\Demo.Solution\\Demo.prestentaionlayer\\wwwroot\\Files\\"
            //string FolderPath = Directory.GetCurrentDirectory() + "\\wwwroot\\Files\\" + FolderName;
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);

            //2. Get file Name And Make It Uniqe
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            //3.Get File Path

            string filePath = Path.Combine(folderPath, fileName);

            //4. Save File as Streams : [Data Per Time]
            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return fileName;
        }

        public static void DeleteFile( string fileName,string folderName) 
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

    }
}
