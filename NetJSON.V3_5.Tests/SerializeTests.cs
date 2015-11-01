using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetJSON.V3_5.Tests {
    [TestClass]
    public class SerializeTests {
        [TestMethod]
        public void CanSerializeSimpleObject() {
            NetJSON.GenerateAssembly = true;
            NetJSON.DateFormat = NetJSONDateFormat.ISO;
            var simple = new SimpleObject { MyInt = 1000, MyString = "Hello World", Timestamp = DateTime.UtcNow };

            var json = NetJSON.Serialize(simple);
            var simple2 = NetJSON.Deserialize<SimpleObject>(json);

            Assert.AreEqual<int>(simple.MyInt, simple2.MyInt);
            Assert.AreEqual<string>(simple.MyString, simple2.MyString);
            Assert.AreEqual<DateTime>(simple.Timestamp, simple2.Timestamp);
        }
    }

    public class SimpleObject {
        public string MyString { get; set; }
        public int MyInt { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
