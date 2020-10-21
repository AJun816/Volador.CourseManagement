using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Volador.CourseManagement.Common;
using Volador.CourseManagement.DataAccess;
using Volador.CourseManagement.Model;

namespace Volador.CourseManagement.ViewModel
{
    public class LoginViewModel : NotifyBase
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set {
                _errorMessage = value;
                this.RaisePropertyChanged("ErrorMessage");
            }
        }

        private Visibility _showProgress = Visibility.Collapsed;

        public Visibility ShowProgress
        {
            get { return _showProgress; }
            set {
                _showProgress = value;
                this.RaisePropertyChanged("ShowProgress");
                LoginCommand.RaiseCanExecuteChanged();
            }
        }


        public CommandBase ColseWindowCommand => new CommandBase(
            new Action<object>(obj =>
            {
                (obj as Window).Close();
            }),
            new Func<object, bool>(obj =>
            {
                return true;
            }));


        public CommandBase LoginCommand => new CommandBase(
            new Action<object>(DoLogin),
            new Func<object, bool>(obj =>
            {
                return ShowProgress == Visibility.Collapsed;
            }));
        private void DoLogin(object o)
        {
            this.ShowProgress = Visibility.Visible;
            this.ErrorMessage = "";
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名！";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMessage = "请输入密码！";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.ValidationCode))
            {
                this.ErrorMessage = "请输入验证码！";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }
            //if (LoginModel.ValidationCode.ToLower()!="etu4")
            //{
            //    this.ErrorMessage = "验证码输入不正确！";
            //    this.ShowProgress = Visibility.Collapsed;
            //    return;
            //}

            Task.Run(new Action(() =>
            {                
                try
                {
                    var user = LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.Password);
                    if (user == null)
                    {
                        throw new Exception("登录失败！用户名或密码错误！");
                    }

                    GlobalValues.UserInfo = user;

                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        (o as Window).DialogResult = true;
                    }));
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                }
                finally
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        this.ShowProgress = Visibility.Collapsed;
                    }));
                }
            }));
        }


        public LoginViewModel()
        {

        }
    }
}
