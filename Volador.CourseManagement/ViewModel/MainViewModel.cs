using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Volador.CourseManagement.Common;
using Volador.CourseManagement.Model;

namespace Volador.CourseManagement.ViewModel
{
    public class MainViewModel:NotifyBase
    {
        public UserModel UserInfo { get; set; } = new UserModel();

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set {
                _searchText = value;
                this.RaisePropertyChanged("SearchText");
            }
        }

        private FrameworkElement _mainContent;

        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set {
                _mainContent = value;
                this.RaisePropertyChanged("MainContent");
            }
        }


        public CommandBase NavChangedCommand => new CommandBase(
            new Action<object>(DoNavChanged),
            new Func<object, bool>((o)=> true)
            );

        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType("Volador.CourseManagement.View."+obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);
        }

        public MainViewModel()
        {
            DoNavChanged("FishPageView");
        }
    }
}
