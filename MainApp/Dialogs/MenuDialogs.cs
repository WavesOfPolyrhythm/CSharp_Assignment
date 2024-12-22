namespace MainApp.Dialogs;

public class MenuDialogs
{
    public void ShowMenu()
    {
       bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("----Contact List----");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Quit Program");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Adding contact..");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Viewing contacts...");
                    Console.ReadKey();
                    break;

                case "3":
                    isRunning = false;
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    Console.ReadKey();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Try again!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
