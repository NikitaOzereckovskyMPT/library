using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp
{
    internal class SerializeDeserialize
    {
        //Обощенный метод по сериализаци данных
        public void serialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream("userSerialize.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    serializer.Serialize(fs, obj);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        //Обощенный метод по десериализаци данных
        public T deserialize<T>()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream("userSerialize.xml", FileMode.Open))
            {
                try
                {
                    return (T)serializer.Deserialize(fs);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                    throw;
                }
            }
        }
    }
}
