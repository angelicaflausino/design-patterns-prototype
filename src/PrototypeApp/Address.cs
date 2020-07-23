using System;

namespace PrototypeApp
{
    [Serializable]
    public class Address /*ICloneable IPrototype<Address>*/
    {
        public Address()
        {
            
        }
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if(streetName == null)
             throw new ArgumentNullException(paramName: nameof(streetName));

            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString() =>
            $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";

        public object Clone() => new Address(StreetName, HouseNumber);

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        //IPrototype
        //public Address DeepCopy() => new Address(StreetName, HouseNumber);
    }
}