using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MX.Util.Serialization;

namespace MX.Util.Tests.Serialization
{
    [TestClass]
    public class SeriaizationTest
    {
        [TestMethod]
        public void SerializeSimpleType()
        {
            const string filename = "unittest_1.txt";
            string original = "hello world";
            var serializer = new BinarySerializer<string>();

            serializer.SaveToFile(original, filename);
            var deserialized = serializer.LoadFromFile(filename);

            Assert.AreEqual(original, deserialized);
        }

        [Serializable]
        private class ComplexType
        {
            public string Foo {  get; set; } = "Hello";
            public int Bar {  get; set; } = 42;
            public decimal Dec { get; set; } = 1337.010101m;

        }

        [TestMethod]
        public void SerializeComplexType()
        {
            const string filename = "unittest_2.txt";
            ComplexType original = new ComplexType();
            var serializer = new BinarySerializer<ComplexType>();

            serializer.SaveToFile(original, filename);
            var deserialized = serializer.LoadFromFile(filename);

            Assert.IsTrue(AllPropertiesAreTheSame(original, deserialized));
        }

        [Serializable]
        private class VeryComplexType
        {
            public static VeryComplexType Create() => new VeryComplexType(42);

            private VeryComplexType() { }
            private VeryComplexType(int x) 
            { 
                _bar2 = x;
                CT = new ComplexType();
                _cts = new List<ComplexType>() {  new ComplexType(), new ComplexType(), new ComplexType()};
            }

            public string Foo { get; private set; } = "Hello";
            public int Bar { get; set; } = 42;
            private readonly int _bar2;
            public int Bar2 => _bar2;
            protected decimal Dec { get; set; } = 1337.010101m;

            public ComplexType CT {  get; private set; } 

            private List<ComplexType> _cts;
            public IEnumerable<ComplexType> CTs => _cts;

        }

        [TestMethod]
        public void SerializeVeryComplexType()
        {
            const string filename = "unittest_3.txt";
            VeryComplexType original = VeryComplexType.Create();
            var serializer = new BinarySerializer<VeryComplexType>();

            serializer.SaveToFile(original, filename);
            var deserialized = serializer.LoadFromFile(filename);

            Assert.IsTrue(AllPropertiesAreTheSame(original, deserialized));
        }

        private bool AllPropertiesAreTheSame<T>(T t1, T t2)
        {
            foreach(var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic))
            {
                if(prop.GetValue(t1)?.ToString() != prop.GetValue(t2)?.ToString() )
                    return false;
            }

            return true;
        }
    }
}
