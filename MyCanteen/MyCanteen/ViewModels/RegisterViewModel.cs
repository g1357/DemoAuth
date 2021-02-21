using MyCanteen.Models;
using MyCanteen.Services;
using MyCanteen.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyCanteen.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IUsersService usersService;

        private readonly RegisterPage page;

        #region First Name Property
        private string firstName;

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        private bool isFirstNameInvalid;

        public bool IsFirstNameInvalid
        {
            get => isFirstNameInvalid;
            set => SetProperty(ref isFirstNameInvalid, value);
        }

        public Command ValidateFirstNameCommand { get; }

        private void ValidateFirstName(object obj)
        {
            IsFirstNameInvalid = string.IsNullOrEmpty(FirstName);
            RegisterCommand.ChangeCanExecute();
        }
        #endregion First Name Property

        #region Middle Name Property
        private string middleName;

        public string MiddleName
        {
            get => middleName;
            set => SetProperty(ref middleName, value);
        }

        private bool isMiddleNameInvalid;

        public bool IsMiddleNameInvalid
        {
            get => isMiddleNameInvalid;
            set => SetProperty(ref isMiddleNameInvalid, value);
        }

        public Command ValidateMiddleNameCommand { get; }

        private void ValidateMiddleName(object obj)
        {
            IsMiddleNameInvalid = string.IsNullOrEmpty(MiddleName);
            RegisterCommand.ChangeCanExecute();
        }
        #endregion Middle Name Property

        #region Last Name Property
        private string lastName;

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        private bool isLastNameInvalid;

        public bool IsLastNameInvalid
        {
            get => isLastNameInvalid;
            set => SetProperty(ref isLastNameInvalid, value);
        }

        public Command ValidateLastNameCommand { get; }

        private void ValidateLastName(object obj)
        {
            IsLastNameInvalid = string.IsNullOrEmpty(LastName);
            RegisterCommand.ChangeCanExecute();
        }
        #endregion Last Name Property

        #region Email Property
        private string email;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private bool isEmailInvalid;

        public bool IsEmailInvalid
        {
            get => isEmailInvalid;
            set => SetProperty(ref isEmailInvalid, value);
        }

        public Command ValidateEmailCommand { get; }

        private void ValidateEmail(object obj)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);

            IsEmailInvalid = !match.Success;
            RegisterCommand.ChangeCanExecute();
        }
        #endregion Email Property

        #region Password Property
        private string password;

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private bool isPasswordInvalid;

        public bool IsPasswordInvalid
        {
            get => isPasswordInvalid;
            set => SetProperty(ref isPasswordInvalid, value);
        }

        public Command ValidatePasswordCommand { get; }

        private void ValidatePassword(object obj)
        {
            IsPasswordInvalid = string.IsNullOrEmpty(Password);
            RegisterCommand.ChangeCanExecute();
        }
        #endregion Password Property

        #region Mobile Number Property
        private string mobileNumber;

        public string MobileNumber
        {
            get => mobileNumber;
            set => SetProperty(ref mobileNumber, value);
        }

        private bool isMobileNumberInvalid;

        public bool IsMobileNumberInvalid
        {
            get => isMobileNumberInvalid;
            set => SetProperty(ref isMobileNumberInvalid, value);
        }

        public Command ValidateMobileNumberCommand { get; }

        private void ValidateMobileNumber(object obj)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(MobileNumber);

            IsMobileNumberInvalid = !match.Success;
            RegisterCommand.ChangeCanExecute();
        }
        #endregion Mobile Numbere Property


        public Command RegisterCommand { get; }


        public RegisterViewModel(IUsersService usersService, RegisterPage page)
        {
            this.usersService = usersService;
            this.page = page;

            RegisterCommand = new Command(Register, CanExecuteRegister);
            ValidateFirstNameCommand = new Command(ValidateFirstName,
                a => FirstName != null);
            ValidateMiddleNameCommand = new Command(ValidateMiddleName,
                a => MiddleName != null);
            ValidateLastNameCommand = new Command(ValidateLastName,
                a => LastName != null);
            ValidateEmailCommand = new Command(ValidateEmail,
                a => Email != null);
            ValidatePasswordCommand = new Command(ValidatePassword,
                a => Password != null);
            ValidateMobileNumberCommand = new Command(ValidateMobileNumber,
                a => MobileNumber != null);
        }

        private async void Register(object obj)
        {
            var user = new UserModel
            {
                FirstName = FirstName,
                MiddleName =MiddleName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                MobileNumber = MobileNumber
            };

            var id = await usersService.Register(user);
        }

        private bool CanExecuteRegister(object arg)
        {
            return !IsFirstNameInvalid && !IsMiddleNameInvalid
                && !IsLastNameInvalid && !IsEmailInvalid
                && !IsPasswordInvalid && !IsMobileNumberInvalid;
        }
    }
}
