using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KazNuclide.Views
{
    public class MiniLoadFormHelper
    {
        MiniLoadingForm loadingForm;
        Thread loadthread;
        public void Show()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcessEx));
            loadthread.Start();
        }

        public void Show(UserControl parent)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcessEx));
            loadthread.Start(parent);
        }
        public void Close()
        {
            if (loadingForm != null)
            {
                loadingForm.BeginInvoke(new System.Threading.ThreadStart(loadingForm.CloseLoadingForm));
                loadingForm = null;
                loadthread = null;
            }
        }
        private void LoadingProcessEx()
        {
            loadingForm = new MiniLoadingForm();
            loadingForm.ShowDialog();
        }
        private void LoadingProcessEx(object parent)
        {
            loadingForm = new MiniLoadingForm();
            loadingForm.ShowDialog();
        }
    }
}
