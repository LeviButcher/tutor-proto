using System;
using Xunit;

namespace ProtoTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {         
            Assert.False(false);
        }
        [Fact]
        public void Test2()
        {
            Assert.True(true);
        }
        [Fact]
        public void Test3()
        {
            Assert.True(true);
        }
    }
}