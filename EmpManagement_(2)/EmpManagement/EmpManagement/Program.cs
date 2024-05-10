namespace EmpManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()  //Void používate ako návratový typ metódy (alebo lokálnej funkcie), aby ste určili, že metóda nevracia hodnotu.
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1()); // metóda ktorá spustí sa štandardná slučka správ aplikácie v aktuálnom vlákne.
        }
    }
}
