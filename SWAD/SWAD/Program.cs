// See https://aka.ms/new-console-template for more information
using SWAD;

void DisplayMenu()
{
    Console.WriteLine("Enter Your Option: ");
    Console.WriteLine("[1] Reserve Car");
    Console.WriteLine("[2] option 2");
    Console.WriteLine("[3] option 3");
    Console.WriteLine("[0] Exit");
    Console.WriteLine("Enter Your option: ");
}
List<Booking> sList = new List<Booking>();
int option;
while (true)
{
    DisplayMenu();
    option = Convert.ToInt32(Console.ReadLine());
    if (option == 1)
    {
        InitTimeList(sList);
        Console.WriteLine("Bookings Initialized.");
        foreach (var booking in sList)
        {
            Console.WriteLine($"Booking ID: {booking.Id}");
            Console.WriteLine($"Start Date: {booking.StartDate}");
            Console.WriteLine($"Start Time: {booking.StartTime}");
            Console.WriteLine($"End Date: {booking.EndDate}");
            Console.WriteLine($"End Time: {booking.EndTime}");
            Console.WriteLine(); // For better readability
        }
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

static void InitTimeList(List<Booking> sList)
{
    // Sample date and time for initialization
    DateOnly date1 = new DateOnly(2024, 8, 5);
    TimeOnly startTime1 = new TimeOnly(10, 0);
    DateOnly date2 = new DateOnly(2024, 8, 6);
    TimeOnly endTime1 = new TimeOnly(11, 0);

    Booking time1 = new Booking(1, date1, startTime1, date2, endTime1);
    Booking time2 = new Booking(2, date1, startTime1, date2, endTime1);
    Booking time3 = new Booking(3, date1, startTime1, date2, endTime1);
    Booking time4 = new Booking(4, date1, startTime1, date2, endTime1);
    Booking time5 = new Booking(5, date1, startTime1, date2, endTime1);
    Booking time6 = new Booking(6, date1, startTime1, date2, endTime1);

    sList.Add(time1);
    sList.Add(time2);
    sList.Add(time3);
    sList.Add(time4);
    sList.Add(time5);
    sList.Add(time6);
}