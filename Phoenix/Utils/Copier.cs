using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Phoenix.Utils
{
    [Serializable]
    public class Copier<T> where T : class
    {
        public virtual T ShallowCopy()
        {
            return (T)this.MemberwiseClone();
        }
        public virtual T DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                string serializedObj = JsonSerializer.Serialize(this, typeof(T));
                return JsonSerializer.Deserialize<T>(serializedObj);
            }
        }
    }
}
