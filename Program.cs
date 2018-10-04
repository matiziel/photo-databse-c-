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
            Dictionary<string, int> categories = PhotoDatabase.getCategories();
            foreach (var item in categories)
            {
                Console.WriteLine(item.Key+"\t"+item.Value);
            }
           // Menu(getAllPhotos(), new PhotoDatabase());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        //Metoda zwracająca tablice zdjęć z folderu startFolder
        static IEnumerable<FileInfo> getAllPhotos()
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
            return fileQuery;
        }

        static void Menu(IEnumerable<FileInfo> photos, PhotoDatabase database)
        {

        }
    }
}
