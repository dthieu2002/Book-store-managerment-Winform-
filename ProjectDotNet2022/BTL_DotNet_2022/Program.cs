using BTL_DotNet_2022.Models;
using BTL_DotNet_2022.FrmMaster;

namespace BTL_DotNet_2022
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginFrm());

        }
    }
}