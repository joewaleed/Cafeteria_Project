namespace Cafeteria_Managment_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConnectionFunction confunc = new ConnectionFunction();
            string Query = "select count(isAdmin) from Users where isAdmin = 1";
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (int.Parse(confunc.GetData(Query).Rows[0][0].ToString()) == 0) Application.Run(new Welcome());
            else Application.Run(new Login());
        }
    }
}