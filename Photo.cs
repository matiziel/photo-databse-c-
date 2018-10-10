using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace photodatabase
{
    //Represent single photo
    class Photo
    {
        //Pola
        private FileInfo data_;
        private Dictionary<string, int> categories_;
               
        //Konstruktor 
        public Photo(string path)
        {
            data_ = new FileInfo(path);
            categories_ = new Dictionary<string, int>();
        }

        //Konstruktor z argumentami, pozwoli szybciej dodawać zdjęcie
        public Photo(string path, Dictionary<string, int> categories)
        {
            data_ = new FileInfo(path);
            categories_ = new Dictionary<string, int>(categories);
        }
        //Zwaraca nazwę pliku
        public string Name
        {
            get { return data_.Name; }
        }
        //Zwaraca nazwę ścieżkę do pliku
        public string FullName
        {
            get { return data_.FullName; }
        }

        //Metoda sprawdzająca czy dane zdjęcie należy do danej kategorii
        public bool ChechCategory(string category)
        {
            return categories_.ContainsKey(category);
        }

        //Przeciążony operator ==
        public static bool operator ==(Photo left, Photo right)
        {
            if (left.FullName == right.FullName)
                return true;
            else
                return false;
        }
        //Przeciążony operator !=
        public static bool operator !=(Photo left, Photo right)
        {
            if (left.FullName != right.FullName)
                return true;
            else
                return false;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void DisplayPhoto()
        {
            Console.WriteLine("Nazwa zdjęcia: " + Name);
            Console.WriteLine("Ścieżka do zdjęcia: " + FullName);
            Console.WriteLine("Kategorie: ");
            foreach (var item in categories_)
            {
                Console.WriteLine(item.Key + " z wagą " + item.Value);
            }
        }


        //************************************************************
        //************************************************************
        //Metody prywatne

      
    }
}
