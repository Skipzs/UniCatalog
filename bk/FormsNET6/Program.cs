namespace FormsNET6
{
    internal static class Program
    {
        static void Main()
        {

            // Pornește aplicația Windows Forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            // Oprirea backend-ului nu este necesară, deoarece aplicația va ieși când formularul este închis
        }
    }
}