using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PrototypeApp
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            //Armazena na memório o objeto
            var stream = new MemoryStream();
            
            //Formatador de binários que irá fazer a serialização
            var formatter = new BinaryFormatter();
           
            //O formatador serealiza o objeto no fluxo da memória
            //Então agora é inicializado o fluxo de memória serializada do objeto
            //Para obter é necessário "rebobinar" o fluxo de volta ao início 
            //utilizando a busca Seek()
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);

            //Faz uma cópia do objeto igual ao serializado
            object copy = formatter.Deserialize(stream);
            
            //Fecha o fluxo
            stream.Close();

            //Retorna o objeto do Tipo T
            return (T)copy;
        }

        //Uma das necessidades dessa abordagem é ter um ctor vazio para a classe
        public static T DeepCopyXml<T>(this T self)
        {
            using(var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;

                return (T)s.Deserialize(ms);
            }
        }
    }
}