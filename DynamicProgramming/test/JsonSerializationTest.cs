using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class SerializationTest
    {
        [DataContract]
        class Person
        {
            [DataMember]
            internal string name = string.Empty;

            [DataMember]
            internal int age = 0;
        }
        static void Serialization()
        {
            Person p = new Person();
            //Set up Person object...
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
            ser.WriteObject(stream1, p);
        }
    }
}
