using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    //Bütün alternatiflerin interface i 
    public interface ICacheManager
    {
        T Get<T>(string key); //Generic method
        object Get(string key); //diğer alternatif fakat bunda tip dönüşümü yazmak gerekebilir. 
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //Cache'de var mı yok mu diye bakıyoruz
        void Remove(string key); //Cache'den silme.
        void RemoveByPattern(string pattern); //içinde pattern geçen cache'leri sil metodu.
    }
}
