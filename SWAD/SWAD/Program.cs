
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
List<Vehicle> vehicleList = listOfAvailableVehicle();
int option;
while (true)
{
    DisplayMenu();
    option = Convert.ToInt32(Console.ReadLine());
    if (option == 1)
    {
        displayAvailableDateTime(sList);
        displayListAvailableVehicles(vehicleList);
        Console.Write("Choose an available Vehicle by ID: ");
        if (!int.TryParse(Console.ReadLine(), out int selectedVehicleId))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }

        Vehicle selectedVehicle = vehicleList.Find(v => v.Id == selectedVehicleId);

        if (selectedVehicle != null)
        {
            Console.WriteLine($"You selected: {selectedVehicle.Make} {selectedVehicle.Model}");
            DisplayAvailableBookings(sList);
            Console.Write("Choose an available booking by ID: ");
            if (!int.TryParse(Console.ReadLine(), out int selectedBookingId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            Booking selectedBooking = sList.Find(b => b.Id == selectedBookingId);

            if (selectedBooking != null)
            {
                Console.WriteLine($"You selected: Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate}, Start Time: {selectedBooking.StartTime}, End Date: {selectedBooking.EndDate}, End Time: {selectedBooking.EndTime}");
                selectedVehicle.Booking = selectedBooking;

                HandlePickupAndReturn();
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

static List<Vehicle> listOfAvailableVehicle()
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
static List<IcarStation> listOfIcarStation()
{
    return new List<IcarStation>
    {
        new IcarStation { Id = 1, Location = "Clementi Branch" },
        new IcarStation { Id = 2, Location = "Jurong Branch" },
        new IcarStation { Id = 3, Location = "Tampines Branch" }
    };
}
static void displayListOfIcarStation(List<IcarStation> branches)
{
    Console.WriteLine("Available Branches:");
    foreach (var branch in branches)
    {
        Console.WriteLine($"ID: {branch.Id}, Name: {branch.Location}");
    }
}
static void displayListAvailableVehicles(List<Vehicle> vehicles)
{
    Console.WriteLine("Available Vehicles:");
    foreach (var vehicle in vehicles)
    {
        Console.WriteLine($"ID: {vehicle.Id}, Make: {vehicle.Make}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage}, Price: {vehicle.Price}");
    }
}

static void displayAvailableDateTime(List<Booking> sList)
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

//wait
static void DisplayAvailableBookings(List<Booking> sList)
{
    Console.WriteLine("Available Bookings:");
    foreach (var booking in sList)
    {
        Console.WriteLine($"Booking ID: {booking.Id}, Start Date: {booking.StartDate}, Start Time: {booking.StartTime}, End Date: {booking.EndDate}, End Time: {booking.EndTime}");
        Console.WriteLine(); // For better readability
    }
}



//select delivery
static void HandlePickupAndReturn()
{
    while (true)
    {
        Console.WriteLine("Choose pickup or delivery option for pickup:");
        Console.WriteLine("[1] Pickup");
        Console.WriteLine("[2] Delivery");
        Console.Write("Enter Your option: ");
        if (!int.TryParse(Console.ReadLine(), out int pickupOption))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }

        if (pickupOption == 1)
        {
            Console.WriteLine("Pickup selected.");
            displayListOfIcarStation(listOfIcarStation());
            Console.Write("Choose a branch by ID: ");
            if (!int.TryParse(Console.ReadLine(), out int validIcarStationId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            IcarStation validIcarStation = listOfIcarStation().Find(b => b.Id == validIcarStationId);

            if (validIcarStation != null)
            {
                Console.WriteLine($"Pickup branch selected: {validIcarStation.Id}, Address: {validIcarStation.Location}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid branch ID selected.");
                continue;
            }
        }
        else if (pickupOption == 2)
        {
            Console.WriteLine("Delivery selected.");
            selectDelivery();
            break;
        }
        else
        {
            Console.WriteLine("Invalid option selected for pickup. Please choose either pickup or delivery.");
            continue;
        }
    }

    while (true)
    {
        Console.WriteLine("Choose return option:");
        Console.WriteLine("[1] Return Pickup");
        Console.WriteLine("[2] Return Delivery");
        Console.Write("Enter Your option: ");
        if (!int.TryParse(Console.ReadLine(), out int returnOption))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }

        if (returnOption == 1)
        {
            Console.WriteLine("Return Pickup selected.");
            displayListOfIcarStation(listOfIcarStation());
            Console.Write("Choose a branch by ID: ");
            if (!int.TryParse(Console.ReadLine(), out int selectedBranchId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            IcarStation selectedBranch = listOfIcarStation().Find(b => b.Id == selectedBranchId);

            if (selectedBranch != null)
            {
                Console.WriteLine($"Return branch selected: {selectedBranch.Id}, Address: {selectedBranch.Location}");
                break;
            }
            else
            {
                Console.WriteLine("Invalid branch ID selected.");
                continue;
            }
        }
        else if (returnOption == 2)
        {
            Console.WriteLine("Return Delivery selected.");
            selectDelivery();
            break;
        }
        else
        {
            Console.WriteLine("Invalid option selected for return. Please choose either return pickup or return delivery.");
            continue;
        }
    }
}

static void selectDelivery()
{
    while (true)
    {
        Console.WriteLine("Please enter the delivery address details:");

        string street = enterDeliveryForm("Street:");
        string block = enterDeliveryForm("Block:");
        string road = enterDeliveryForm("Road:");
        string city = enterDeliveryForm("City:");
        string postalCode = enterDeliveryForm("Postal Code:");

        string fullAddress = $"Street: {street}, Block: {block}, Road: {road}, City: {city}, Postal Code: {postalCode}";

        if (ValidAddress(street, block, road, city, postalCode))
        {
            Console.WriteLine($"Delivery address confirmed: {fullAddress}");
            break;
        }
        else
        {
            Console.WriteLine("Invalid delivery address. Please try again.");
        }
    }
}

static string enterDeliveryForm(string prompt)
{
    Console.Write($"{prompt} ");
    return Console.ReadLine()?.Trim() ?? string.Empty;
}

static bool ValidAddress(string street, string block, string road, string city, string postalCode)
{
    return !string.IsNullOrWhiteSpace(street) &&
           !string.IsNullOrWhiteSpace(block) &&
           !string.IsNullOrWhiteSpace(road) &&
           !string.IsNullOrWhiteSpace(city) &&
           !string.IsNullOrWhiteSpace(postalCode) &&
           postalCode.Length >= 5;
}
