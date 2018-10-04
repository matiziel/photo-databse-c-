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

        //Konstruktor bezargumentowy
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

        //Przeciążony operator ==
        public static bool operator ==(Photo left, Photo right)
        {
            if (left.data_.FullName == right.data_.FullName)
                return true;
            else
                return false;
        }
        //Przeciążony operator !=
        public static bool operator !=(Photo left, Photo right)
        {
            if (left.data_.FullName != right.data_.FullName)
                return true;
            else
                return false;
        }



    }
}
