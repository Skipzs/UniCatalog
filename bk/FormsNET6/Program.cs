namespace FormsNET6
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            // Pornește aplicația Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }
    }
}