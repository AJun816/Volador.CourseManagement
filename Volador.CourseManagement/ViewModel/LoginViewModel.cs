using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Volador.CourseManagement.Common;
using Volador.CourseManagement.Model;

namespace Volador.CourseManagement.ViewModel
{
    public class LoginViewModel
    {
        public LoginModel LoginModel { get; set; }
        public CommandBase ColseWindowCommand => new CommandBase(
            new Action<object>(obj => 
            {
                (obj as Window).Close();
            }),
            new Func<object, bool>(obj => 
            {
                return true;
            }));

        public LoginViewModel()
        {
            this.LoginModel = new LoginModel();
            this.LoginModel.UserName = "Volador";
            this.LoginModel.Password = "123456";
        }
    }
}
