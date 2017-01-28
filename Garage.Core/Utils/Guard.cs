using Garage.Core.Exceptions;
using System;
using System.Linq.Expressions;

namespace Garage.Core.Utils
{
    public static class Guard
    {
        #region Public Methods

        public static void ExpectArgumentIsNotNull(Expression<Func<object>> expression)
        {
            Action onErrorAction = () =>
            {
                throw new ArgumentNullException("Argument of function is null");
            };
            ExpectIsNotNull(expression, onErrorAction);
        }

        public static void ExpectValueIsNotNull(Expression<Func<object>> expression)
        {
            Action onErrorAction = () =>
            {
                throw new UnexpectedNullException("Value is null");
            };
            ExpectIsNotNull(expression, onErrorAction);
        }

        #endregion

        #region Private Methods

        private static void ExpectIsNotNull(Expression<Func<object>> expression, Action onError)
        {
            if (expression.Compile()() == null)
            {
                onError();
            }
        }

        #endregion
    }
}
