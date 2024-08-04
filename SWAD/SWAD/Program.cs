// See https://aka.ms/new-console-template for more information
void DisplayMenu()
{
    Console.WriteLine("[1] Reserve Car");
    Console.WriteLine("[2] option 2");
    Console.WriteLine("[3] option 3");
    Console.WriteLine("[0] Exit");
    Console.WriteLine("Enter Your option: ");
}

int option;
while (true)
{
    DisplayMenu();
    option = Convert.ToInt32(Console.ReadLine());
    if (option == 1)
    {
        Console.WriteLine();
    }

    else if (option == 2)
    {
        Console.WriteLine();
    }
    else if (option == 3)
    {
        Console.WriteLine();
    }
    else if (option == 0)
    {

    Console.WriteLine("Bye");
        break;
    }

    else 
    {
        Console.WriteLine("You have enter invalid option!");
        
    }
}


