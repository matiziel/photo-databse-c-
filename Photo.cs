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
        public int CountCategories
        {
            get { return categories_.Count; }
        }
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
        //Wyswietlanie zdjęcia
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
        //Zapisywanie zdjęcia do pliku
        public void SavePhoto(StreamWriter sw)
        {
            sw.WriteLine(FullName);
            sw.WriteLine(categories_.Count);
            foreach (var item in categories_)
            {
                sw.WriteLine(item.Key);
                sw.WriteLine(item.Value);
            }
        }
        //Zwracanie tablicy kategorii
        public string[] GetPhotoCategories()
        {
            string[] tmp = new string[categories_.Count];
            int i = 0;
            foreach (var item in categories_)
            {
                tmp[i] = item.Key;
                ++i;
            }
            return tmp;
        }
        //************************************************************
        //************************************************************
        //Pola i Metody prywatne
        private FileInfo data_;
        private Dictionary<string, int> categories_;

    }
}
