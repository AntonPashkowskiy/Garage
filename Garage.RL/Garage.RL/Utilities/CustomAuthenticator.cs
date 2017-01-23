using Garage.RL.Constants;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Garage.RL.Utilities
{
    public class CustomAuthenticator: FormAuthenticator
    {
        #region Ctor

        public CustomAuthenticator()
        {
            AddDefaultFormFields();
        }

        #endregion

        #region Public Methods

        public override Task<Account> SignInAsync(CancellationToken token)
        {
            return new TaskFactory<Account>().StartNew(() => GetAccount());
        }

        #endregion

        #region Private Methods

        private Account GetAccount()
        {
            var username = GetFieldValue(AccountConstants.LoginKey);
            var properties = new Dictionary<string, string>
            {
                { AccountConstants.LoginKey, GetFieldValue(AccountConstants.LoginKey) },
                { AccountConstants.EmailKey, GetFieldValue(AccountConstants.EmailKey) },
                { AccountConstants.PasswordKey, GetFieldValue(AccountConstants.PasswordKey) }
            };
            return new Account(username, properties);
        }

        private void AddDefaultFormFields()
        {
            Fields.Add(GetEmailField());
            Fields.Add(GetLoginField());
            Fields.Add(GetPasswordField());
        }

        private FormAuthenticatorField GetPasswordField()
        {
            return new FormAuthenticatorField
            {
                FieldType = FormAuthenticatorFieldType.Password,
                Key = AccountConstants.PasswordKey,
                Placeholder = "Password",
                Title = "Password"
            };
        }

        private FormAuthenticatorField GetLoginField()
        {
            return new FormAuthenticatorField
            {
                FieldType = FormAuthenticatorFieldType.PlainText,
                Key = AccountConstants.LoginKey,
                Placeholder = "Login",
                Title = "Login"
            };
        }

        private FormAuthenticatorField GetEmailField()
        {
            return new FormAuthenticatorField
            {
                FieldType = FormAuthenticatorFieldType.Email,
                Key = AccountConstants.EmailKey,
                Placeholder = "Email",
                Title = "Email",
            };
        }


        #endregion
    }
}
