using System;
using System.Runtime.InteropServices;

namespace PrototypeApp
{
    [Serializable]
    public class Person /*ICloneable IPrototype<Person>*/
    {
        public Person()
        {
            
        }
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if(names == null)
                throw new ArgumentNullException(paramName: nameof(names));

            if(address == null)
             throw new ArgumentNullException(paramName: nameof(address));

             Names = names;
             Address = address;
        }

        public override string ToString() =>
            $"{nameof(Names)}: {string.Join(", ", Names)}, {nameof(Address)}: {Address}";

        //Ainda dessa maneira não soluciona o problema pois estará fazendo uma cópia superficial, pois 
        // copiamos também a referência de Names e Address, ou seja tudo que altera no objeto clone altera no objeto clonado.
        //public object Clone() => new Person(Names, Address);

        //Para que a propriedade Address não seja copiada a referencia é necessário implementar IClonable
        //E então..
        //Como Clone() retorna um objeto é necessário lembrar de fazer o Cast para a classe Address
        //A abordagem de Clone ainda não é a melhor porque você está transformando a classe em um objeto
        public object Clone() => new Person(Names, (Address)Address.Clone());

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        //public Person DeepCopy() => new Person(Names, Address.DeepCopy());
    }
}