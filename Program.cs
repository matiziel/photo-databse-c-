using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace photodatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu(getAllPhotos(), new PhotoDatabase());
        }

        //Metoda zwracająca tablice zdjęć z folderu startFolder
        static FileInfo[] getAllPhotos()
        {
            string startFolder = @"D:\Zdjęcia\base";
            DirectoryInfo dir = new DirectoryInfo(startFolder);

            IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

            //Create the query  
            IEnumerable<FileInfo> fileQuery =
                from file in fileList
                where file.Extension == ".jpg"
                orderby file.Name
                select file;
            FileInfo[] allFiles = new FileInfo[fileQuery.Count()];
            int i = 0;
            foreach (var item in fileQuery) { allFiles[i] = item; ++i; }
            return allFiles;
        }


        static void Menu(FileInfo[] photos, PhotoDatabase database)
        {
            database.AddPhoto(photos);
            database.AddPhoto(photos);
            database.DisplayAllPhotos();
            database.DisplayAllCategories();
            database.RemovePhoto();
            database.DisplayAllPhotos();
        }
    }
}
