using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Volador.CourseManagement.View;

namespace Volador.CourseManagement
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //如果登录成功，打开主窗体
            if (new LoginView().ShowDialog() == true)
            {
                new MainView().ShowDialog();
            }
            Application.Current.Shutdown();
        }
    }
}
