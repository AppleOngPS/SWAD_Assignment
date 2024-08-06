
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
List<Vehicle> vehicleList = InitVehicleList();
int option;
while (true)
{
    DisplayMenu();
    option = Convert.ToInt32(Console.ReadLine());
    if (option == 1)
    {

        //InitTimeList(sList);
        //Console.WriteLine("Choose a available datetime.");
        //foreach (var booking in sList)
        //{
        //    Console.WriteLine($"Booking ID: {booking.Id},Start Date: {booking.StartDate},Start Time: {booking.StartTime},End Date: {booking.EndDate},End Time: {booking.EndTime}");

        //    Console.WriteLine(); // For better readability
        //}
        InitTimeList(sList);

        DisplayAvailableVehicles(vehicleList);
        Console.WriteLine("Choose an available Vehicle by ID: ");
        int selectedVehicleId = Convert.ToInt32(Console.ReadLine());
        Vehicle selectedVehicle = vehicleList.Find(v => v.Id == selectedVehicleId);

        if (selectedVehicle != null)
        {
            Console.WriteLine($"You selected: {selectedVehicle.Make} {selectedVehicle.Model}");

            DisplayAvailableBookings(sList);
            Console.WriteLine("Choose an available booking by ID: ");
            int selectedBookingId = Convert.ToInt32(Console.ReadLine());
            Booking selectedBooking = sList.Find(b => b.Id == selectedBookingId);

            if (selectedBooking != null)
            {
                Console.WriteLine($"You selected: Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate}, Start Time: {selectedBooking.StartTime}, End Date: {selectedBooking.EndDate}, End Time: {selectedBooking.EndTime}");
                selectedVehicle.Booking = selectedBooking;
                Console.WriteLine("Booking confirmed!");
            }
            else
            {
                Console.WriteLine("Invalid booking ID selected.");
            }
        }
        else
        {
            Console.WriteLine("Invalid vehicle ID selected.");
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

static List<Vehicle> InitVehicleList()
{
    return new List<Vehicle>
        {
            new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Mileage = 12000, Photo = "url1", Price = 20000, Availability = true, Brand = "Toyota", Type = "Sedan" },
            new Vehicle { Id = 2, Make = "Honda", Model = "Civic", Mileage = 15000, Photo = "url2", Price = 22000, Availability = true, Brand = "Honda", Type = "Sedan" },
            new Vehicle { Id = 3, Make = "Ford", Model = "Focus", Mileage = 18000, Photo = "url3", Price = 18000, Availability = true, Brand = "Ford", Type = "Hatchback" },
            new Vehicle { Id = 4, Make = "Chevrolet", Model = "Malibu", Mileage = 20000, Photo = "url4", Price = 25000, Availability = true, Brand = "Chevrolet", Type = "Sedan" },
            new Vehicle { Id = 5, Make = "Nissan", Model = "Altima", Mileage = 22000, Photo = "url5", Price = 23000, Availability = true, Brand = "Nissan", Type = "Sedan" }
        };
}

static void DisplayAvailableVehicles(List<Vehicle> vehicles)
{
    Console.WriteLine("Available Vehicles:");
    foreach (var vehicle in vehicles)
    {
        Console.WriteLine($"ID: {vehicle.Id}, Make: {vehicle.Make}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage}, Price: {vehicle.Price}");
    }
}

static void InitTimeList(List<Booking> sList)
{
    DateOnly date1 = new DateOnly(2024, 8, 15);
    TimeOnly startTime1 = new TimeOnly(10, 0);
    DateOnly date2 = new DateOnly(2024, 8, 16);
    TimeOnly endTime1 = new TimeOnly(11, 0);

    DateOnly date3 = new DateOnly(2024, 8, 16);
    TimeOnly startTime2 = new TimeOnly(9, 30);
    DateOnly date4 = new DateOnly(2024, 8, 16);
    TimeOnly endTime2 = new TimeOnly(10, 30);

    DateOnly date5 = new DateOnly(2024, 8, 17);
    TimeOnly startTime3 = new TimeOnly(14, 0);
    DateOnly date6 = new DateOnly(2024, 8, 17);
    TimeOnly endTime3 = new TimeOnly(15, 0);

    DateOnly date7 = new DateOnly(2024, 8, 18);
    TimeOnly startTime4 = new TimeOnly(8, 45);
    DateOnly date8 = new DateOnly(2024, 8, 18);
    TimeOnly endTime4 = new TimeOnly(9, 45);

    DateOnly date9 = new DateOnly(2024, 8, 19);
    TimeOnly startTime5 = new TimeOnly(12, 0);
    DateOnly date10 = new DateOnly(2024, 8, 19);
    TimeOnly endTime5 = new TimeOnly(13, 0);

    Booking time1 = new Booking(1, date1, startTime1, date2, endTime1);
    Booking time2 = new Booking(2, date3, startTime2, date4, endTime2);
    Booking time3 = new Booking(3, date5, startTime3, date6, endTime3);
    Booking time4 = new Booking(4, date7, startTime4, date8, endTime4);
    Booking time5 = new Booking(5, date9, startTime5, date10, endTime5);

    sList.Add(time1);
    sList.Add(time2);
    sList.Add(time3);
    sList.Add(time4);
    sList.Add(time5);
}

static void DisplayAvailableBookings(List<Booking> sList)
{
    Console.WriteLine("Available Bookings:");
    foreach (var booking in sList)
    {
        Console.WriteLine($"Booking ID: {booking.Id}, Start Date: {booking.StartDate}, Start Time: {booking.StartTime}, End Date: {booking.EndDate}, End Time: {booking.EndTime}");
        Console.WriteLine(); // For better readability
    }
}