using Garage.RL.Models.Authentication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.RL.Tests.Models.Authentication
{
    [TestFixture]
    public class SignInViewModelTests
    {
        #region MapToModel

        [Test]
        public void MapToModel_ViewModelIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SignUpViewModel.MapToModel(null));
        }

        #endregion
    }
}
