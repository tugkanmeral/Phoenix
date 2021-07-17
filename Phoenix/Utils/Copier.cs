using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Phoenix.Utils
{
    [Serializable]
    public class Copier<T> where T : class
    {
        public T ShallowCopy()
        {
            return (T)this.MemberwiseClone();
        }
        public T DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
