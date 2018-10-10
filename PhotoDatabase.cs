using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace photodatabase
{
    class PhotoDatabase
    {
        private List<Photo> allPhotos_;
        private HashSet<string> allCategories_;

        //Konstruktor
        public PhotoDatabase()
        {
            allPhotos_ = new List<Photo>();
            allCategories_ = new HashSet<string>();
        }

        //Metoda dodająca zdjęcie
        public void AddPhoto(FileInfo[] photos)
        {
            //TODO dopisać metode dodajaca zdjecia
            Console.WriteLine("Wpisz numer zdjęcia które chcesz dodać. Lista zdjęć.");
            for (int i = 0; i < photos.Length; ++i)
            { Console.WriteLine(i + ". " + photos[i].FullName); }
            int index;
            do
            {
                try
                { index = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception)
                {
                    Console.WriteLine("Zły format danej.");
                    continue;
                }
                if (index < photos.Length)
                {
                    if (Contains(photos[index].FullName) == true)
                        Console.WriteLine("Element juz istnieje");
                    else break;
                }
                else Console.WriteLine("Nie ma takiego zdjęcia.");
            } while (true);
            allPhotos_.Add(new Photo(photos[index].FullName, getCategories()));
        }
        //Metoda usuwająca zdjęcie
        public void RemovePhoto()
        {
            Console.WriteLine("Wpisz nazwę zdjęcia które chcesz usunąć: ");
            foreach (var item in allPhotos_) { Console.WriteLine(item.Name); }
            string name = Console.ReadLine();
            foreach (var item in allPhotos_)
            {
                if (name == item.Name)
                {
                    allPhotos_.Remove(item);
                    return;
                }
            }
            Console.WriteLine("Nie ma takiego zdjęcia");
        }
        //Metoda wyświetlająca nazwy zdjęć danej kategorii
        public void DisplayPhotoByCategory(string category)
        {
            Console.WriteLine("***************************************************");
            IEnumerable<Photo> fileQuery =
                from file in allPhotos_
                where file.ChechCategory(category) == true
                orderby file.Name
                select file;
            Console.WriteLine("Zdjęcia kategorii " + category + " :");
            foreach (var item in fileQuery)
            {
                Console.WriteLine(item.Name);
            }
        }
        //Metoda wyświetlająca wszystkie zdjęcia
        public void DisplayAllPhotos()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("Wszystkie zdjęcia: ");
            foreach (var item in allPhotos_)
            {
                item.DisplayPhoto();
                Console.WriteLine();
            }
        }
        //Metoda wyświetlająca wszystkie kategorie
        public void DisplayAllCategories()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("Wszystkie kategorie: ");
            foreach (var item in allCategories_)
            {
                Console.WriteLine(item);
            }
        }

        //************************************************************
        //************************************************************
        //Metody prywatne

        //Pobiera kategorie do danego zdjecia, zwraca Dictionary par kategoria + waga
        private Dictionary<string, int> getCategories()
        {
            Dictionary<string, int> categories = new Dictionary<string, int>();
            string line;
            int value = 1;
            do
            {
                try
                {
                    Console.WriteLine("Podaj kategorię:");
                    line = Console.ReadLine();
                    Console.WriteLine("Podaj wagę:");
                    value = Convert.ToInt32(Console.ReadLine());
                    categories.Add(line, value);
                    allCategories_.Add(line);
                    Console.WriteLine("Czy chcesz kontynuować?\nJeżeli tak wybierz dowolny przycisk, jeżeli nie wciśnij zero.");
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Kategoria już istnieje.");
                }
                catch (Exception)
                {
                    value = 1;
                }
            } while (value != 0);
            return categories;
        }

        //Sprawdza obecność zdjecia o danej ścieżce w bazie
        private bool Contains(string path)
        {
            foreach (var item in allPhotos_)
            {
                if (item.FullName == path)
                    return true;
            }
            return false;
        }
    }
}
