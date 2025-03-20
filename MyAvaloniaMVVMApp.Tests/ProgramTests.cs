using System;
using Xunit;

namespace MyAvaloniaMVVMApp.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_ApplicationStartsWithoutExceptions()
        {
            // Act & Assert
            var exception = Record.Exception(() => Program.Main(new string[0]));
            Assert.Null(exception);
        }
    }
}
