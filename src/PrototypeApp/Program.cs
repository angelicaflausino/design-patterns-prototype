using System;

namespace PrototypeApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Wrong Way
            var john = new Person(new string[]{"John", "Smith"},
            new Address("London Road", 123));

            Console.WriteLine(john);

            //Cópia da referencia o que pode causar que o nome do John seja modificado para os dois objetos, 
            //ou seja os dois locais estão sendo alterados
            var jane = john;
            jane.Names[0] = "Jane";

            Console.WriteLine(jane);

            //IClonable

            var janeClone = (Person)john.Clone();
            janeClone.Address.HouseNumber = 321;
            Console.WriteLine(janeClone);

            //Copia de Construtor
            var janeCtor = new Person(john);
            janeCtor.Address.HouseNumber = 313;
            Console.WriteLine(janeCtor);

            //IPrototype
            //var janePrototype = john.DeepCopy();
            //Console.WriteLine(janePrototype);

            //ExtensionMethods DeepCopy 
            var janeSerialized = john.DeepCopy();
            janeSerialized.Names[0] = "Jane";
            janeSerialized.Names[1] = "Serialized";
            Console.WriteLine(janeSerialized);

            //ExtensionMethos DeepCopyXml
            var janeXmlSerialized = john.DeepCopyXml();
            janeXmlSerialized.Names[0] = "Jane";
            janeXmlSerialized.Names[1] = "XML";
            Console.WriteLine(janeXmlSerialized);
        }
    }
}
