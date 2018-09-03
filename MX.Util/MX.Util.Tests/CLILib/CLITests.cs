using Microsoft.VisualStudio.TestTools.UnitTesting;
using MX.Util.CLILib;
using MX.Util.CLILib.Commands;
using MX.Util.CLILib.UIOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MX.Util.Tests.CLILib
{
    [TestClass]
    public class CLITests
    {

        [TestMethod]
        public void CommandSimpleParse()
        {
            string commandString = "foobar";
            var  command = new CLICommand(commandString);

            Assert.AreEqual(commandString, command.Command);

        }

        [TestMethod]
        public void CommandParameterParse()
        {
            string commandString = "foobar";
            string[] parameterStrings = new [] {"one", "two", "three"};
            string commandFullString = String.Format($"{commandString} " + String.Join(" ", parameterStrings));
            
            var command = new CLICommand(commandFullString);

            Assert.AreEqual(commandString, command.Command);
            Assert.AreEqual(parameterStrings.Count(), command.Parameters.Count());

            for (int i = 0; i < parameterStrings.Length; ++i)
                Assert.AreEqual(parameterStrings[i].Replace("\"", ""), command.GetParameter(i).Value);
        }

        [TestMethod]
        public void CommandJoinedParameterParse()
        {
            string commandString = "foobar";
            string[] parameterStrings = new[] { "one", "\"two two two two\"", "three", "\"four\"", "five" };
            string commandFullString = String.Format($"{commandString} " + String.Join(" ", parameterStrings));

            var command = new CLICommand(commandFullString);

            Assert.AreEqual(commandString, command.Command);
            Assert.AreEqual(parameterStrings.Count(), command.Parameters.Count());

            for (int i = 0; i < parameterStrings.Length; ++i)
                Assert.AreEqual(parameterStrings[i].Replace("\"", ""), command.GetParameter(i).Value);
        }

        /// <summary>
        /// Ensures no issues with empty options
        /// </summary>
        [TestMethod]
        public void NoCommandToFind ()
        {
            var processor = new CLIProcessor();
            processor.OptionCollection = new UIOptionCollection();
            //
            IUIOption option = processor.FindOption(new CLICommand("foobar"));
            Assert.AreEqual(null, option);


        }  

        /// Ensures no issues with empty options
        /// </summary>
        [TestMethod]
        public void CommandFoundNoEvents()
        {
            var processor = new CLIProcessor();
            
            processor.OptionCollection = UIOptionCollection.ToCollection(new UIOption("foobar", c=>{ }));

            IUIOption option = processor.FindOption(new CLICommand("foobar"));
            Assert.AreNotEqual(null, option);


        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionIfNoOptions()
        {
            var processor = new CLIProcessor();

            IUIOption option = processor.FindOption(new CLICommand("foobar"));
            //Asert exception


        }


    }
}
