using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volador.CourseManagement.Common;

namespace Volador.CourseManagement.Model
{
    public class LoginModel:NotifyBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set {
                _password = value;
                this.RaisePropertyChanged("Password");
            }
        }

        private string _validationCode;

        public string ValidationCode
        {
            get { return _validationCode; }
            set {
                _validationCode = value;
                this.RaisePropertyChanged("ValidationCode");
            }
        }


    }
}
