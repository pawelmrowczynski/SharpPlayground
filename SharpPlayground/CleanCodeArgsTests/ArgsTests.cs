using CleanCodeArgs;
using System;
using Xunit;

namespace CleanCodeArgsTests
{
    public class ArgsTests
    {
        [Fact]
        public void SettingBoolFlagWorksCorrectly()
        {
            var arguments = new string[] { "-l" };
            var args = new Args("l", arguments);
            bool logging = args.getBoolean('l');
            Assert.True(logging);
        }

        [Fact]
        public void IfNoArgumentsProvided_FlagSetToFalse()
        {
            var arguments = new string[] { "" };
            var args = new Args("l", arguments);
            bool logging = args.getBoolean('l');
            Assert.False(logging);
        }

        [Fact]
        public void IfDifferentArgumentsProvided_FlagSetToFalse()
        {
            var arguments = new string[] { "-k" };
            var args = new Args("l", arguments);
            bool logging = args.getBoolean('l');
            Assert.False(logging);
        }
    }
}
