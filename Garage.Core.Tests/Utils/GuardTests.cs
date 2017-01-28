using Garage.Core.Exceptions;
using Garage.Core.Utils;
using NUnit.Framework;
using System;

namespace Garage.Core.Tests.Utils
{
    [TestFixture]
    public class GuardTests
    {
        #region ExpectArgumentIsNotNull

        [Test]
        public void ExpectArgumentIsNotNull_CompilationResultIsNull_ThrowsArgumentNullException()
        {
            int? argument = null;
            Assert.Throws<ArgumentNullException>(() => Guard.ExpectArgumentIsNotNull(() => argument));
        }

        [Test]
        public void ExpectArgumentIsNotNull_CompilationResultIsNull_ExceptionMessageIsNotEmpty()
        {
            try
            {
                int? argument = null;
                Guard.ExpectArgumentIsNotNull(() => argument);
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(!string.IsNullOrWhiteSpace(ex.Message));
            }
        }

        [Test]
        [TestCase(100)]
        [TestCase("string")]
        [TestCase("")]
        public void ExpectArgumentIsNotNull_CompilationResultIsNotNull_NotThrowsArgumentNullException(object argument)
        {
            Assert.DoesNotThrow(() => Guard.ExpectArgumentIsNotNull(() => argument));
        }

        #endregion

        #region ExpectValueIsNotNull

        [Test]
        public void ExpectValueIsNotNull_CompilationResultIsNull_ThrowsUnexpectedNullException()
        {
            int? argument = null;
            Assert.Throws<UnexpectedNullException>(() => Guard.ExpectValueIsNotNull(() => argument));
        }

        [Test]
        public void ExpectValueIsNotNull_CompilationResultIsNull_ExceptionMessageIsNotEmpty()
        {
            try
            {
                int? argument = null;
                Guard.ExpectValueIsNotNull(() => argument);
            }
            catch (UnexpectedNullException ex)
            {
                Assert.IsTrue(!string.IsNullOrWhiteSpace(ex.Message));
            }
        }

        [Test]
        [TestCase(100)]
        [TestCase("string")]
        [TestCase("")]
        public void ExpectValueIsNotNull_CompilationResultIsNotNull_NotThrowsUnexpectedNullException(object argument)
        {
            Assert.DoesNotThrow(() => Guard.ExpectValueIsNotNull(() => argument));
        }

        #endregion
    }
}
