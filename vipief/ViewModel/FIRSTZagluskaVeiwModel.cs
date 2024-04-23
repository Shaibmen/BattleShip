using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using vipief.View;
using vipief.ViewModel.Helpers;

namespace vipief.ViewModel
{

    internal class FIRSTZagluskaVeiwModel : BindingHelper
    {
        #region

        public BindableCommand NextWindow { get; set; }

        #endregion

        public FIRSTZagluskaVeiwModel() 
        {
            NextWindow = new BindableCommand(_ => Next());
        }

        public void Next()
        {

            foreach (Window window in Application.Current.Windows)
            {
                if (window is FIRSTZAGLUSKA)
                {
                    SECONDZAGLUSHKA sECONDZAGLUSHKA = new SECONDZAGLUSHKA();
                    sECONDZAGLUSHKA.Show();
                    foreach (Window window1 in Application.Current.Windows)
                    {
                        if (window1 is FIRSTZAGLUSKA)
                        {
                            window.Close();
                            break;
                        }
                    }
                }
                else if (window is SECONDZAGLUSHKA)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    foreach (Window window1 in Application.Current.Windows)
                    {
                        if (window1 is SECONDZAGLUSHKA)
                        {
                            window.Close();
                            break;
                        }
                    }
                }
            }
        }
    }
}
