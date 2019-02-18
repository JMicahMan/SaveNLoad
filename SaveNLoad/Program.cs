using System;
using System.Xml.Serialization;
using System.IO;


namespace SaveNLoad
{
    public class Test
    {
        public int member1;
        public string member2;

        [XmlIgnore]
        public double member3;
        private string member4;

        public Test()
        {
            member1 = 45;
            member2 = "arg";
            member3 = 9.999;
            member4 = "arg matey";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            TextWriter writer = new StreamWriter("output.xml");

            Test obj = new Test();
            serializer.Serialize(writer, obj);
            writer.Close();

            Console.WriteLine("Data Saved");

            
        }
    }
    class Loader
    {
        static void Load(string[] args)
        {
            Stream stream = File.Open("output.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            Test obj2 = null;
            obj2 = (Test)serializer.Deserialize(stream);
            stream.Close();
        }
    }


}
