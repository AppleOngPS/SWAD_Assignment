
using SWAD;
using System.Globalization;
using System.Text.RegularExpressions;

void DisplayMenu()
{
    Console.WriteLine("Enter Your Option: ");
    Console.WriteLine("[1] Reserve Vehicle");
    Console.WriteLine("[2] Manage Booking");
    Console.WriteLine("[3] option 3");
    Console.WriteLine("[0] Exit");
    Console.WriteLine("Enter Your option: ");
}
List<Booking> sList = new List<Booking>();
List<CarOwner> listOfAvailableVehicles = getAvailableVehicle();
Renter renter = new Renter();
int data = 0;
int option;
string icar;
while (true)
{
    DisplayMenu();
    option = Convert.ToInt32(Console.ReadLine());
    if (option == 1)
    {
        //displayAvailableDateTime(vehicleList);
        displayListAvailableVehicles(listOfAvailableVehicles);
        // Prompt for vehicle selection
        Console.Write("Enter the ID of the vehicle you want to select: ");
        if (!int.TryParse(Console.ReadLine(), out int vehicleId))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        // Find the CarOwner that has the selected vehicle
        CarOwner selectedOwner = listOfAvailableVehicles.Find(owner => owner.Vehiclelist.Exists(v => v.Id == vehicleId));

        if (selectedOwner != null)
        {
            // Find the selected vehicle within the selected owner
            Vehicle selectedVehicle = selectedOwner.Vehiclelist.Find(v => v.Id == vehicleId);
            if (selectedVehicle != null)
            {
                Console.WriteLine($"You selected: {selectedVehicle.Make} {selectedVehicle.Model}");

                // Display available date and time
                displayAvailableDateTime(listOfAvailableVehicles, selectedOwner.Id);

                // Display available bookings
                DisplayAvailableBookings(selectedOwner.Bookinglist);

                // Prompt user to choose a booking
                Console.Write("Choose an available booking by ID: ");

                if (!int.TryParse(Console.ReadLine(), out int bookingId))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }

                // Find the selected booking
                Booking selectedBooking = selectedOwner.Bookinglist.Find(b => b.Id == bookingId);

                if (selectedBooking != null)
                {
                    Console.WriteLine($"You selected: Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate:dd/MM/yyyy}, Start Time: {selectedBooking.StartTime:HH:mm}, End Date: {selectedBooking.EndDate:dd/MM/yyyy}, End Time: {selectedBooking.EndTime:HH:mm}");

                    // Add the booking to the selected vehicle's list
                    selectedVehicle.Booking = selectedBooking; // Assuming each vehicle has one booking

                    // Handle pickup and return
                    selectPickUp(selectedVehicle, out int pickupOption,out icar);
                    selectReturn(selectedVehicle, pickupOption);

                    // Review booking details
                    reviewBooking(selectedVehicle, selectedBooking); // Ensure this method is defined
                    
                    // Display payment options
                    DisplayPaymentOptions(selectedVehicle, selectedBooking); // Ensure this method is defined
                    createbooking(selectedVehicle, selectedBooking,renter,icar);
                }
                else
                {
                    Console.WriteLine("Invalid booking ID selected.");
                }
            }
            else
            {
                Console.WriteLine("Vehicle not found under the selected owner.");
            }
        }
        else
        {
            Console.WriteLine("Invalid vehicle ID selected.");
        }

    }




    else if (option == 2)
    {
        ManageBooking(listOfAvailableVehicles);

        




    }
        else if (option == 3)
    {
        Console.WriteLine();
        foreach (Booking selectedBooking in renter.TrackUpComingRental)
        {
            Console.WriteLine($"Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate}, Start Time: {selectedBooking.StartTime}, End Date: {selectedBooking.EndDate}, End Time: {selectedBooking.EndTime}");
            Console.WriteLine($"pickup:{selectedBooking.IcarStationPickup.Location}");

        }

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

static List<CarOwner>getAvailableVehicle()
{
    // List of CarOwner objects
    return new List<CarOwner>
            {
                new CarOwner(1, "Jayden", 87654321, Convert.ToDateTime("07/08/2005"))
                {
                    Vehiclelist = new List<Vehicle>
                    {
                        new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Mileage = 12000, Photo = "url1", Price = 0, Availability = true, Brand = "Toyota", Type = "Sedan" }
                    }
                },
                new CarOwner(2, "Emily", 98765432, DateTime.ParseExact("12/05/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    Vehiclelist = new List<Vehicle>
                    {
                        new Vehicle { Id = 2, Make = "Honda", Model = "Civic", Mileage = 15000, Photo = "url2", Price = 0, Availability = true, Brand = "Honda", Type = "Sedan" }
                    }
                },
                new CarOwner(3, "Michael", 87654322, DateTime.ParseExact("20/09/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    Vehiclelist = new List<Vehicle>
                    {
                        new Vehicle { Id = 3, Make = "Ford", Model = "Focus", Mileage = 18000, Photo = "url3", Price = 0, Availability = true, Brand = "Ford", Type = "Hatchback" }
                    }
                },
                new CarOwner(4, "Olivia", 98765433, DateTime.ParseExact("15/11/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    Vehiclelist = new List<Vehicle>
                    {
                        new Vehicle { Id = 4, Make = "Chevrolet", Model = "Malibu", Mileage = 20000, Photo = "url4", Price = 0, Availability = true, Brand = "Chevrolet", Type = "Sedan" }
                    }
                },
                new CarOwner(5, "Daniel", 87654323, DateTime.ParseExact("03/07/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    Vehiclelist = new List<Vehicle>
                    {
                        new Vehicle { Id = 5, Make = "Nissan", Model = "Altima", Mileage = 22000, Photo = "url5", Price = 0, Availability = true, Brand = "Nissan", Type = "Sedan" }
                    }
                }
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
static void displayListAvailableVehicles(List<CarOwner> vehicles)
{
    Console.WriteLine("Available Vehicles:");
    foreach (CarOwner owner in vehicles)
    {
        Console.WriteLine($"Vehicle owner: {owner.Name}");
        Console.WriteLine("Vehicles details:");

        // Iterate through each vehicle in the owner's list
        foreach (Vehicle vehicle in owner.Vehiclelist)
        {
            Console.WriteLine($"ID: {vehicle.Id}, Make: {vehicle.Make}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage}, Price: {vehicle.Price}");
        }

        Console.WriteLine();
    }
}

static void displayAvailableDateTime(List<CarOwner> sList,int id)
{
    foreach (CarOwner owner in sList)
    {
        if (owner.Id == id)
        {
            // Iterate through each booking in the owner's list
            foreach (Booking booking in owner.Bookinglist)
            {

                Console.WriteLine($"Booking ID: {booking.Id}");
               
                Console.WriteLine($"Start Date: {booking.StartDate:dd/MM/yyyy}");
                Console.WriteLine($"Start Time: {booking.StartTime:HH:mm}");
                Console.WriteLine($"End Date: {booking.EndDate:dd/MM/yyyy}");
                Console.WriteLine($"End Time: {booking.EndTime:HH:mm}");
                Console.WriteLine();

            }
        }
    }

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
static void selectPickUp(Vehicle selectedVehicle, out int pickupOption,out string icarStation)
{
    icarStation=string.Empty;
    while (true)
    {
        Console.WriteLine("Choose pickup or delivery option for pickup:");
        Console.WriteLine("[1] Pickup");
        Console.WriteLine("[2] Delivery");
        Console.Write("Enter Your option: ");
        if (!int.TryParse(Console.ReadLine(), out pickupOption))
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
                icarStation = validIcarStation.Location;
                Console.WriteLine($"qqqqqqqqqqqqqqq{icarStation}");
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
}

static void selectReturn(Vehicle selectedVehicle, int pickupOption)
{
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

            // Calculate the price based on pickup and return options
            if (pickupOption == 2 && returnOption == 2)
            {
                Console.WriteLine($"Total Price: ${selectedVehicle.Price + 100}");
            }
            else if (returnOption == 2)
            {
                Console.WriteLine($"Total Price: ${selectedVehicle.Price + 50}");
            }
            else if (pickupOption == 2)
            {
                Console.WriteLine($"Total Price: ${selectedVehicle.Price + 50}");
            }
            else
            {
                Console.WriteLine($"Total Price: ${selectedVehicle.Price}");
            }
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

            if (validate(street, block, road, city, postalCode))
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

    static bool validate(string street, string block, string road, string city, string postalCode)
    {
        return !string.IsNullOrWhiteSpace(street) &&
               !string.IsNullOrWhiteSpace(block) &&
               !string.IsNullOrWhiteSpace(road) &&
               !string.IsNullOrWhiteSpace(city) &&
               !string.IsNullOrWhiteSpace(postalCode) &&
               postalCode.Length >= 5;
    }

   
    static void DisplayPaymentOptions(Vehicle selectedVehicle, Booking selectedBooking)
    {
        while (true)
        {
            Console.WriteLine("Choose a payment method:");
            Console.WriteLine("[1] Credit Card");
            Console.WriteLine("[2] Debit Card");
            Console.WriteLine("[3] Digital Wallet");
            Console.Write("Enter Your option: ");
            if (!int.TryParse(Console.ReadLine(), out int paymentOption))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (paymentOption)
            {
                case 1:
                    Console.WriteLine("Credit Card selected.");
                    selectCreditCard(selectedVehicle, selectedBooking);
                    break;
                case 2:
                    Console.WriteLine("Debit Card selected.");
               
                selectDebitCard(selectedVehicle, selectedBooking);
                    break;
                case 3:
                    Console.WriteLine("Digital Wallet selected.");
                
                selectDigitalWallet(selectedVehicle, selectedBooking);
                    break;
                default:
                    Console.WriteLine("Invalid payment option selected.");
                    continue;
            }
            break;
        }
    }


static void selectCreditCard(Vehicle selectedVehicle, Booking selectedBooking)
{
    
    //renter entering credit card details
    string name = enterPaymentForm("Name:");
    string cardNo = enterPaymentForm("Card Number (16 digits):");
    string cvv = enterPaymentForm("CVV (3 digits):");
    string expiryDate = enterPaymentForm("Expiry Date (MM/YY):");
    Console.WriteLine("");

    // Validate the entered credit card details
    if (ValidCardDetails(name, cardNo, cvv, expiryDate))
    {
        Console.WriteLine("Credit card details confirmed.");
        Console.WriteLine("Payment Successful.");
        Console.WriteLine("");

        // Display the booking confirmation
        DisplayConfirmation(selectedVehicle, selectedBooking);
    }
    else
    {
        Console.WriteLine("Invalid credit card details. Please try again.");
    }
}

static void selectDebitCard(Vehicle selectedVehicle, Booking selectedBooking)
{
    Console.WriteLine("Processing Debit Card Payment...");
    //renter entering credit card details
    string name = enterPaymentForm("Name:");
    string cardNo = enterPaymentForm("Card Number (16 digits):");
    string cvv = enterPaymentForm("CVV (3 digits):");
    string expiryDate = enterPaymentForm("Expiry Date (MM/YY):");
    Console.WriteLine("");

    // Validate the entered credit card details
    if (ValidCardDetails(name, cardNo, cvv, expiryDate))
    {
        Console.WriteLine("Credit card details confirmed.");
        Console.WriteLine("Payment Successful.");
        Console.WriteLine("");

        // Display the booking confirmation
        DisplayConfirmation(selectedVehicle, selectedBooking);
    }
    else
    {
        Console.WriteLine("Invalid debit card details. Please try again.");
    }
}

static void selectDigitalWallet(Vehicle selectedVehicle, Booking selectedBooking)
{
    //renter entering credit card details
    string name = enterPaymentForm("Name:");
    string cardNo = enterPaymentForm("Card Number (16 digits):");
    string cvv = enterPaymentForm("CVV (3 digits):");
    string expiryDate = enterPaymentForm("Expiry Date (MM/YY):");
    Console.WriteLine("");

    // Validate the entered credit card details
    if (ValidCardDetails(name, cardNo, cvv, expiryDate))
    {
        Console.WriteLine("Credit card details confirmed.");
        Console.WriteLine("Payment Successful.");
        Console.WriteLine("");
        // Display the booking confirmation
        DisplayConfirmation(selectedVehicle, selectedBooking);
    }
    else
    {
        Console.WriteLine("Invalid credit card details. Please try again.");
    }
}

// Placeholder methods to simulate user input and validation
static string enterPaymentForm(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine();
}

static bool ValidCardDetails(string name, string cardNo, string cvv, string expiryDate)
{
    // Check if any field is empty
    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(cardNo) ||
        string.IsNullOrEmpty(cvv) || string.IsNullOrEmpty(expiryDate))
    {
        return false;
    }

    // Validate card number (16 digits)
    if (!Regex.IsMatch(cardNo, @"^\d{16}$"))
    {
        Console.WriteLine("Card number must be 16 digits.");
        return false;
    }

    // Validate CVV (3 digits)
    if (!Regex.IsMatch(cvv, @"^\d{3}$"))
    {
        Console.WriteLine("CVV must be 3 digits.");
        return false;
    }

    // Validate expiry date (not later than today)
    if (!DateTime.TryParseExact(expiryDate, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expDate))
    {
        Console.WriteLine("Expiry date format is invalid.");
        return false;
    }

    DateTime today = DateTime.Today;
    DateTime lastDayOfExpMonth = new DateTime(expDate.Year, expDate.Month, DateTime.DaysInMonth(expDate.Year, expDate.Month));

    if (lastDayOfExpMonth < today)
    {
        Console.WriteLine("Expiry date must not be earlier than today.");
        return false;
    }

    return true;
}





    static void DisplayConfirmation(Vehicle selectedVehicle, Booking selectedBooking)
    {
        Console.WriteLine("Booking and Payment Confirmation:");
        Console.WriteLine($"Vehicle: {selectedVehicle.Make} {selectedVehicle.Model}");
        Console.WriteLine($"Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate}, Start Time: {selectedBooking.StartTime}, End Date: {selectedBooking.EndDate}, End Time: {selectedBooking.EndTime}");
        Console.WriteLine("Thank you for your reservation!");
    }

static void reviewBooking(Vehicle selectedVehicle, Booking selectedBooking)
{
    Console.WriteLine();
    Console.WriteLine("Booking details:");
    Console.WriteLine($"Vehicle: {selectedVehicle.Make}, {selectedVehicle.Model} ({selectedVehicle.Type}), Mileage:{selectedVehicle.Mileage}, Price:${selectedVehicle.Price}");
    Console.WriteLine($"Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate}, Start Time: {selectedBooking.StartTime}, End Date: {selectedBooking.EndDate}, End Time: {selectedBooking.EndTime}");
    Console.WriteLine("-----------------Proceed to payment-----------------");
    Console.WriteLine();
}

static void createbooking(Vehicle selectedVehicle, Booking selectedBooking,Renter r,string i)
{
    Console.WriteLine($"wwwwwwwwwwwwwwwww{i}");
    // Assign pickup and return locations
    selectedBooking.IcarStationPickup = new IcarStation();
    selectedBooking.IcarStationPickup.Location = i;

    // Assign the selected vehicle to the booking
    selectedBooking.Vehicle = selectedVehicle;

    // Add the booking to the renter's upcoming rentals
    r.TrackUpComingRental.Add(selectedBooking);
}
static void ManageBooking(List<CarOwner> vlist)
{
    try
    {
        // Display car owners
        foreach (CarOwner owner in vlist)
        {
            Console.WriteLine($"Id: {owner.Id,-5} Name: {owner.Name,-10} Contact Number: {owner.ContactNumber,-15} Date of Birth: {owner.DateofBirth:dd/MM/yyyy}");
        }

        // Prompt for user ID
        Console.Write("Enter your ID to proceed: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Error: Invalid ID format.");
            return;
        }

        // Find the CarOwner with the given ID
        CarOwner selectedOwner = vlist.FirstOrDefault(owner => owner.Id == id);

        if (selectedOwner != null)
        {
            Console.WriteLine("Vehicle Details:");

            // Display vehicles and prompt for choice
            foreach (Vehicle vehicle in selectedOwner.Vehiclelist)
            {
                Console.WriteLine($"Id: {vehicle.Id} - {vehicle.Make} {vehicle.Model} - Mileage: {vehicle.Mileage} - Price: {vehicle.Price}");
            }

            Console.Write("Please enter the number corresponding to your vehicle choice: ");
            if (!int.TryParse(Console.ReadLine(), out int vehicleChoiceInput))
            {
                Console.WriteLine("Error: Invalid vehicle choice format.");
                return;
            }

            // Find the selected vehicle
            Vehicle selectedVehicle = selectedOwner.Vehiclelist.FirstOrDefault(v => v.Id == vehicleChoiceInput);

            if (selectedVehicle != null)
            {
                Console.Write("Enter the schedule start date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                {
                    Console.WriteLine("Error: Invalid start date format.");
                    return;
                }

                Console.Write("Enter the schedule end date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                {
                    Console.WriteLine("Error: Invalid end date format.");
                    return;
                }

                Console.Write("Enter the schedule start time (HH:mm): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime startTime))
                {
                    Console.WriteLine("Error: Invalid start time format.");
                    return;
                }

                Console.Write("Enter the schedule end time (HH:mm): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime endTime))
                {
                    Console.WriteLine("Error: Invalid end time format.");
                    return;
                }

                // Combine date and time
                DateTime inputStartDateTime = startDate.Date.Add(startTime.TimeOfDay);
                DateTime inputEndDateTime = endDate.Date.Add(endTime.TimeOfDay);

                // Check for conflicts with existing bookings
                bool conflict = selectedOwner.Bookinglist.Any(booking =>
                {
                    DateTime bookingStartDateTime = booking.StartDate.Date.Add(booking.StartTime.TimeOfDay);
                    DateTime bookingEndDateTime = booking.EndDate.Date.Add(booking.EndTime.TimeOfDay);
                    return booking.Vehicle.Id == selectedVehicle.Id &&
                           (inputStartDateTime < bookingEndDateTime && inputEndDateTime > bookingStartDateTime);
                });

                if (conflict)
                {
                    Console.WriteLine("Conflict with existing bookings.");
                }
                else
                {
                    Console.Write("Enter the rental fee ($60-$106): ");
                    if (!double.TryParse(Console.ReadLine(), out double fee) || fee < 60 || fee > 106)
                    {
                        Console.WriteLine("Error: Invalid fee. Must be between $60 and $106.");
                        return;
                    }

                    selectedVehicle.Price = fee;
                    int bookingId = selectedOwner.Bookinglist.Count + 1;
                    Booking newBooking = new Booking(bookingId, startDate, startTime, endDate, endTime)
                    {
                        Vehicle = selectedVehicle,
                        CarOwner = selectedOwner
                    };

                    selectedOwner.Bookinglist.Add(newBooking);

                    // Use Booking class methods to set date, time, and rental fee
                    int bookingIndex = selectedOwner.Bookinglist.Count-1; // Index of the new booking

                    newBooking.setDate(id, bookingIndex, startDate, endDate);
                    newBooking.setTime(id, bookingIndex, startTime, endTime);
                    newBooking.setRentalfee(id, selectedOwner.Vehiclelist.IndexOf(selectedVehicle), fee);

                    Console.WriteLine("Booking scheduled successfully.");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid vehicle choice.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Account");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
}



