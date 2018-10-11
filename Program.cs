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
            database.Read();
            int choice;
            Console.WriteLine("\t\tWitaj");
            Console.WriteLine("Program sluzy do obslugi kolekcji zdjec.");
            do
            {
                Console.WriteLine("\nDostepne mozliwosci: \n"
                    + "1. Pokaz wszystkie kategorie.\n"
                    + "2. Pokaz zdjecia z danej kategorii.\n"
                    + "3. Pokaz wszystkie zdjecia.\n"
                    + "4. Dodaj zdjecie.\n"
                    + "5. Usun zdjecie.\n"
                    + "6. Usun dane calej bazy.\n"
                    + "0. Wyjscie.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = 9;
                }
                switch (choice)
                {
                    case 0:
                        choice = 0;
                        break;
                    case 1:
                        database.DisplayAllCategories();
                        break;
                    case 2:
                        string tmp;
                        database.DisplayAllCategories();
                        Console.WriteLine("Podaj kategorię: ");
                        tmp = Console.ReadLine();
                        database.DisplayPhotoByCategory(tmp);
                        break;
                    case 3:
                        database.DisplayAllPhotos();  
                        break;
                    case 4:
                        database.AddPhoto(photos);
                        database.Save();
                        break;
                    case 5:
                        database.RemovePhoto();
                        database.Save();
                        break;
                    case 6:
                        database.RemoveAllPhotos();
                        database.Save();
                        break;
                    default:
                        Console.WriteLine("Zostala podana zla wartosc, sproboj jeszcze raz");
                        break;
                }
            } while (choice != 0);
        }
    }
}
