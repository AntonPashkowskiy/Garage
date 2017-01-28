using System;
using System.Threading.Tasks;

namespace Garage.Core.Utils
{
    public class AssertAsyncUtil
    {
        public static async Task<TException> ThrowsAsync<TException>(Func<Task> action, bool allowDerivedTypes = true) where TException : Exception
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                if (allowDerivedTypes && !(ex is TException))
                {
                    string exceptionMessageTemplate = "Delegate threw exception of type {0}, but {1} or a deriver type was expected.";
                    string exceptionMessage = string.Format(exceptionMessageTemplate, ex.GetType().Name, typeof(TException).Name);
                    throw new Exception(exceptionMessage, ex);
                }
                    
                if (!allowDerivedTypes && ex.GetType() != typeof(TException))
                {
                    string exceptionMessageTemplate = "Delegate threw exception of type {0}, but {1} was expected.";
                    string message = string.Format(exceptionMessageTemplate, ex.GetType().Name, typeof(TException).Name);
                    throw new Exception(message, ex);
                }
                return (TException)ex;
            }
            return null;
        }

        public static Task<Exception> ThrowsAsync(Func<Task> action)
        {
            return ThrowsAsync<Exception>(action, true);
        }
    }
}
