using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TutorPrototype.Utility;
using Xunit;

namespace ProtoTest
{
    public class CSVFileCreationTest
    {
        [Fact]
        public void CanCreateCSVFile()
        {
            List<string> sampleData = new List<string>
            {
                "Jack","Jane","Jill","Ally"
            };

            CSVFileUtil.CreateCSVFile("test", sampleData);

            Assert.True(File.Exists
                (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                "CSV", "test.csv")));
        }

        [Fact]
        public void CanReturnAnArray()
        {
            List<string> sampleData = new List<string>
            {
                "Jack","Jane","Jill","Ally"
            };

            byte[] array = CSVFileUtil.CreateCSVFile("test", sampleData);

            Assert.NotNull(array);

            Assert.NotEmpty(array);
        }

        [Fact]
        public void CanDecodeArray()
        {

            string proper = "Jack,Jane,Jill,Ally";

            byte[] bytes = Encoding.ASCII.GetBytes(proper);

            string test = CSVFileUtil.GetStringFromBytes(bytes);

            Assert.Equal(proper, test);
        }
    }
}
