using System;
using System.Windows;

namespace Holistic
{
    public partial class App : Application
    {
        public App()
        {
            this.Activated += StartElmish;
        }

        private void StartElmish(object sender, EventArgs e)
        {
            this.Activated -= StartElmish;
            Holistic.Models.Program.main(MainWindow);
        }
    }
}
