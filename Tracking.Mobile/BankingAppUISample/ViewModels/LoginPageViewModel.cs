
using AiForms.Dialogs;
using System;
using TrackingApp.APIService;
using TrackingApp.Controls;
using TrackingApp.Helper;
using TrackingApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrackingApp.ViewModels
{
    class LoginPageViewModel : ObservableObject
    {
        private INavigation _navigation;
        public Command loginCommand { get; private set; }

        public LoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
             
            loginCommand = new Command(execLogincommand);

            bool hasSessionLogin = Preferences.ContainsKey("session_login");
            if (hasSessionLogin)
                _loginname = Preferences.Get("session_login", "");
        }

        private string _loginname;
        public string LoginName
        {
            get => _loginname;
            set
            {
                _loginname = value; 
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value; 
            }
        }

        public async void execLogincommand()
        {
            if ( String.IsNullOrEmpty(_loginname) || String.IsNullOrEmpty(_password))
            {
                Toast.Instance.Show<QAToastView>(new { Title = "無效的用戶信息", Duration = 2500 });
                return;
            }

            GlobalVariable.Access_level = 0;

            Auth_data _data = new Auth_data();
            _data.username = _loginname;
            _data.password = _password;

            Auth_result _rtn = await MainApiService.Instance.User.Login(_data);

            if (_rtn == null)
            {
                Toast.Instance.Show<QAToastView>(new { Title = "無效的用戶信息", Duration = 2500 });
                return;
            }

            if (_rtn.success == GlobalSetting.API_result.Yes)
            {
                //Login Success
                if (_loginname.ToLower() == "admin")
                {
                    Preferences.Set("session_login", _loginname);
                    GlobalVariable.Access_token = $"{ _loginname }{ DateTime.Now.ToString("ddMMyyyy") }";
                    GlobalVariable.Access_level = 3;
                }

                if (_loginname.ToLower() == "staff01")
                {
                    Preferences.Set("session_login", _loginname);
                    GlobalVariable.Access_token = $"{ _loginname }{ DateTime.Now.ToString("ddMMyyyy") }";
                    GlobalVariable.Access_level = 2;
                }

                if (_loginname.ToLower() == "client")
                {
                    Preferences.Set("session_login", _loginname.ToLower());
                    GlobalVariable.Access_token = $"{ _loginname }{ DateTime.Now.ToString("ddMMyyyy") }";
                    GlobalVariable.Access_level = 1;
                }

                //Close Form
                await _navigation.PopModalAsync();


            }
            else
            {
                Toast.Instance.Show<QAToastView>(new { Title = "無效的用戶信息", Duration = 2500 });
                _password = "";
                NotifyPropertyChanged(nameof(Password));

                return;
                //Login Failed
            }
 





        }



    }

}
