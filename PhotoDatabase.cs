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
        private Dictionary<string, Photo> allPhotos_;
        private HashSet<string> allCategories_;

        public PhotoDatabase()
        {
            allPhotos_ = new Dictionary<string, Photo>();
            allCategories_ = new HashSet<string>();
        }

        public void AddPhoto(FileInfo[] photos)
        {

        }

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
    }
}
