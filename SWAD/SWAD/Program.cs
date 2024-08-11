
using SWAD;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

internal class Program
{
    public static int Id { get; set; }
    public static Renter renter { get; set; }
    public static CarOwner carOwner { get; set; }
    public static Vehicle vehicle{ get; set; }
    public static int vehicleid { get; set; }
    public static int bookingId { get; set; }
    public static DateTime startdate { get; set; }
    public static DateTime enddate { get; set; }
    public static DateTime starttime { get; set; }
    public static DateTime endtime { get; set; }
    public static Booking BookingSlot { get; set; }
    public static int pickupOption { get; set; }
    public static double fee { get; set; }
    public static string name { get; set; }
   public static Booking selectedBooking { get; set; }
    public static string cvv { get; set; }
    public static string cardNo { get; set; }
    public static string expiryDate {  get; set; }
    public static string location { get; set; }
    public static string location2 { get; set; }
    public static string fulladdress { get; set; }  
    public static int returnOption { get; set; }
    public static List<IcarStation> stations { get; set; }
    private static void Main(string[] args)
    {
        void DisplayMenu()
        {
            Console.WriteLine("Enter Your Option: ");
            Console.WriteLine("[1] Reserve Vehicle");
            Console.WriteLine("[2] Manage Booking");
            Console.WriteLine("[3] TrackUpComingBooking");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("Enter Your option: ");
        }
        List<Booking> sList = new List<Booking>();
       List<Vehicle>listofvehicle = new List<Vehicle>();
        carOwner = startInterface();
        //List<Vehicle> listOfAvailableVehicles = getAvailableVehicle();
        stations = getAvailableIcarStation();
        renter = startbokingprocess();
        int data = 0;
        int option;
        string icar;
        while (true)
        {
            DisplayMenu();
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                List<Vehicle> listOfAvailableVehicles = getAvailableVehicle();

                //displayAvailableDateTime(vehicleList);
                displayListAvailableVehicles(listOfAvailableVehicles);
                // Prompt for vehicle selection
                /*
                Console.Write("Enter the ID of the vehicle you want to select: ");
                if (!int.TryParse(Console.ReadLine(), out int vehicleId))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }*/
                selectAvailableVehicle(out int vehicleid);

                getAvailableDateTime(bookingId);
                selectAvailableDateTime(bookingId);
                // selectPickUp()


                // Find the CarOwner that has the selected vehicle
                foreach (Vehicle vehicle in carOwner.Vehiclelist) {
                    if (vehicle.Id == vehicleid)
                    {

                        
                            // Find the selected vehicle within the selected owner
                            
                            if (vehicle != null)
                            {
                               /* Console.WriteLine($"You selected: {vehicle.Make} {vehicle.Model}");

                                // Display available date and time
                                // displayAvailableDateTime(listOfAvailableVehicles, selectedOwner.Id);

                                // Display available bookings
                                DisplayAvailableBookings(carOwner.Bookinglist);

                                // Prompt user to choose a booking
                                Console.Write("Choose an available booking by ID: ");

                                if (!int.TryParse(Console.ReadLine(), out int bookingId))
                                {
                                    Console.WriteLine("Invalid input. Please enter a number.");
                                    return;
                                }*/

                                // Find the selected booking
                                 selectedBooking = carOwner.BookingSlotList.Find(b => b.Id == bookingId);

                                if (selectedBooking != null)
                                {
                                    Console.WriteLine($"You selected: Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate:dd/MM/yyyy}, Start Time: {selectedBooking.StartTime:HH:mm}, End Date: {selectedBooking.EndDate:dd/MM/yyyy}, End Time: {selectedBooking.EndTime:HH:mm}");
                                      Program.bookingId = selectedBooking.Id;
                                    // Add the booking to the selected vehicle's list
                                    vehicle.Booking = selectedBooking; // Assuming each vehicle has one booking

                                    // Handle pickup and return
                                    selectPickUpOption(vehicle, out int pickupOption);
                                   Program.pickupOption = pickupOption;
                                   // displayOptionforreturn();
                                    selectReturnOption(vehicle, pickupOption);
                                     
                                    // Review booking details
                                    reviewBooking(vehicle, selectedBooking); // Ensure this method is defined

                                    // Display payment options
                                    selectPayment(vehicle, selectedBooking); // Ensure this method is defined
                                    createbooking(vehicle, selectedBooking, renter);

                                    bookingConfirmationAlert();
                                

                                

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
                       
                    
                }
            }




            else if (option == 2)
            {
                //ManageBooking();
                
                startInterface();
                getListOfVehicle();
                promptVehicle();
                selectVehicle(out int vehicleid);
               Program.vehicleid = vehicleid;
                //findVehicle(vehicleid);
                //promptDateTime();
                enterDateTime(startdate,starttime,enddate,endtime);
                promptRentalfee();
                enterRentalfee(fee);
                



            }
            else if (option == 3)
            {
                selectTrackUpComingBooking();
                getlistofUpComingBooking(bookingId);
                modifyUpcomingBooking();
                selectModificationChoice(out string yesorNo);
                if (yesorNo == "no")
                {
                    noModification();
                }
                if (yesorNo == "yes") 
                {
                    selectPickupOrReturnLocation();
                    //modifyPickupLocation();
                    //modifyReturnLocation();
                    getModificationCost();
                    displayModifyCost();
                    confirmModifyCost();
                    //modificationUpdatedAlert();
                    
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

        static List<Vehicle> getAvailableVehicle()
        {
            Vehicle vehicle = new Vehicle();

           return vehicle.getetAvailableVehicle();
                 
        }



        static List<IcarStation> getAvailableIcarStation()
        {
            IcarStation icarStation = new IcarStation();
           return icarStation.getAvailableIcarStation();
    
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
           
                Console.WriteLine($"Vehicle owner: {carOwner.Name}");
                Console.WriteLine("Vehicles details:");

                // Iterate through each vehicle in the owner's list
                foreach (Vehicle vehicle in carOwner.Vehiclelist)
                {
                    Console.WriteLine($"ID: {vehicle.Id}, Make: {vehicle.Make}, Model: {vehicle.Model}, Mileage: {vehicle.Mileage}, Price: {vehicle.Price}");
                }

                Console.WriteLine();
            
        }
        static void getAvailableDateTime(int boookingId)
        {
           Vehicle vehicle = new Vehicle();
            vehicle.getAvailableDateTime(boookingId);
            displayAvailableDateTime(vehicle.Booking);
        }
        static void selectAvailableDateTime(int boookingId)
        {
            Console.Write("Choose an available booking by ID: ");

            if (!int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

        }

        static void displayAvailableDateTime(Booking booking)
        {
            
                Console.WriteLine($"Booking ID: {booking.Id}");

                Console.WriteLine($"Start Date: {booking.StartDate:dd/MM/yyyy}");
                Console.WriteLine($"Start Time: {booking.StartTime:HH:mm}");
                Console.WriteLine($"End Date: {booking.EndDate:dd/MM/yyyy}");
                Console.WriteLine($"End Time: {booking.EndTime:HH:mm}");
                Console.WriteLine();
            
            




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
        static void selectAvailableVehicle(out int v)
        {
            Console.Write("Enter the ID of the vehicle you want to select: ");
            v =Convert.ToInt32(Console.ReadLine());
        }

        static void displaypickUpOption()
        {
            Console.WriteLine("Choose pickup or delivery option for pickup:");
            Console.WriteLine("[1] Pickup");
            Console.WriteLine("[2] Delivery");
            Console.Write("Enter Your option: ");
        }
       static void selectPickUp()
        {
            Console.WriteLine("Pickup selected.");
            displayListOfIcarStation(stations);
            Console.Write("Choose a branch by ID: ");
          
        }
        //select delivery
        static void selectPickUpOption(Vehicle selectedVehicle, out int pickupOption)
        {
            //icarStation = string.Empty;
            while (true)
            {
                displaypickUpOption();
                if (!int.TryParse(Console.ReadLine(), out pickupOption))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (pickupOption == 1)
                {
                    selectPickUp();
                    if (!int.TryParse(Console.ReadLine(), out int validIcarStationId))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    IcarStation validIcarStation = selectIcarStation(stations, validIcarStationId);

                    if (validIcarStation != null)
                    {
                        // Here you can store or use the valid IcarStation
                        // Example: icarStation = validIcarStation.Location;
                        location=validIcarStation.Location;
                        selectedBooking.selecticarstation();

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

        static IcarStation selectIcarStation(List<IcarStation> stations, int validIcarStationId)
        {
            IcarStation validIcarStation = stations.Find(b => b.Id == validIcarStationId);

            if (validIcarStation != null)
            {
                Console.WriteLine($"Pickup branch selected: {validIcarStation.Id}, Address: {validIcarStation.Location}");
            }
            else
            {
                Console.WriteLine("Invalid branch ID selected.");
            }

            return validIcarStation;
        }
        static void displayReturnOption()
        {
            Console.WriteLine("Choose return option:");
            Console.WriteLine("[1] Return Pickup");
            Console.WriteLine("[2] Return Delivery");
            Console.Write("Enter Your option: ");
        }
       
            static IcarStation selectReturnIcarStation(List<IcarStation> stations, int selectedBranchId)
            {
                IcarStation selectedBranch = stations.Find(b => b.Id == selectedBranchId);

                if (selectedBranch != null)
                {
                    Console.WriteLine($"Return branch selected: {selectedBranch.Id}, Address: {selectedBranch.Location}");
                }
                else
                {
                    Console.WriteLine("Invalid branch ID selected.");
                }

                return selectedBranch;
            }
        
        static void selectReturnOption(Vehicle selectedVehicle, int pickupOption)
        {
            while (true)
            {
                displayReturnOption();
                if (!int.TryParse(Console.ReadLine(), out int returnOption))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                Program.returnOption=returnOption;
                if (returnOption == 1)
                {
                    Console.WriteLine("Return Pickup selected.");
                    displayListOfIcarStation(stations);
                    Console.Write("Choose a branch by ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int selectedBranchId))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    IcarStation selectedBranch = selectReturnIcarStation(stations, selectedBranchId);

                    if (selectedBranch != null)
                    {
                        // Store or use the selectedBranch as needed
                        location2 = selectedBranch.Location;
                        selectedBooking.selecticarstation();
                        break;
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

                string street = printDeliveryForm("Street:");
                string block = printDeliveryForm("Block:");
                string road = printDeliveryForm("Road:");
                string city = printDeliveryForm("City:");
                string postalCode = printDeliveryForm("Postal Code:");

                string fullAddress = $"Street: {street}, Block: {block}, Road: {road}, City: {city}, Postal Code: {postalCode}";

                if (validate(street, block, road, city, postalCode))
                {
                    Console.WriteLine($"Delivery address confirmed: {fullAddress}");
                    addAddress(street, block, road, city, postalCode);
                    fulladdress = fullAddress;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid delivery address. Please try again.");
                }
            }
        }
        static void enterDeliveryForm()
        {

        }
        static void displayOptionforreturn()
        {
            Console.WriteLine("Choose pickup or delivery option for return:");
            Console.WriteLine("[1] Pickup");
            Console.WriteLine("[2] Delivery");
            Console.Write("Enter Your option: ");
            Console.ReadLine();

        }
        static void addAddress(string street, string block, string road, string city, string postalCode)
        {

            selectedBooking.addAddress(street,block,road,city,postalCode);
        }
        static string printDeliveryForm(string prompt)
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


        static void selectPayment(Vehicle selectedVehicle, Booking selectedBooking)
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
        static void DisplaycardDetailsForm()
        {
            Console.WriteLine("Name:");
            Console.WriteLine();
            
            Console.WriteLine("Card Number (16 digits):");
            Console.WriteLine();
      
            Console.WriteLine("CVV (3 digits):");
            Console.WriteLine();
            
            Console.WriteLine("Expiry Date (MM/YY):");
            Console.WriteLine();
            
            //Payment payment=new Payment();
            //payment.validate(name, cardNo,cvv,expiryDate);
            /*Program.name = name;
            Program.cardNo = cardNo;
            Program.cvv = cvv;
            Program.expiryDate = expiryDate;*/
        }
        static void enterCardDetails(string name, string cardNo, string cvv, string expiryDate)
        {
            name = Console.ReadLine();
            cardNo = Console.ReadLine();
            cvv = Console.ReadLine();
            expiryDate = Console.ReadLine();
            Program.name = name;
            Program.cardNo = cardNo;
            Program.cvv = cvv;
            Program.expiryDate = expiryDate;
            Payment payment = new Payment();
            //payment.validate(name, cardNo, cvv, expiryDate);
        }
     

        static void selectCreditCard(Vehicle selectedVehicle, Booking selectedBooking)
        {

            //renter entering credit card details
            //string name = enterPaymentForm("Name:");
            //string cardNo = enterPaymentForm("Card Number (16 digits):");
            //string cvv = enterPaymentForm("CVV (3 digits):");
            //string expiryDate = enterPaymentForm("Expiry Date (MM/YY):");
            //Console.WriteLine("");
            DisplaycardDetailsForm();
            enterCardDetails( name,  cardNo,  cvv, expiryDate);

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

            //renter entering credit card details
            //string name = enterPaymentForm("Name:");
            //string cardNo = enterPaymentForm("Card Number (16 digits):");
            //string cvv = enterPaymentForm("CVV (3 digits):");
            //string expiryDate = enterPaymentForm("Expiry Date (MM/YY):");
            //Console.WriteLine("");
            DisplaycardDetailsForm();
            enterCardDetails(name, cardNo, cvv, expiryDate);

            // Validate the entered credit card details
            if (ValidCardDetails(name, cardNo, cvv, expiryDate))
            {
                Console.WriteLine("Debit card details confirmed.");
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
        static void selectDigitalWallet(Vehicle selectedVehicle, Booking selectedBooking)
        {

            //renter entering credit card details
            //string name = enterPaymentForm("Name:");
            //string cardNo = enterPaymentForm("Card Number (16 digits):");
            //string cvv = enterPaymentForm("CVV (3 digits):");
            //string expiryDate = enterPaymentForm("Expiry Date (MM/YY):");
            //Console.WriteLine("");
            DisplaycardDetailsForm();
            enterCardDetails(name, cardNo, cvv, expiryDate);

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
                Console.WriteLine("Invalid digital wallet details. Please try again.");
            }
        }
        // Placeholder methods to simulate user input and validation
        //static string enterPaymentForm(string prompt)
        //{
        //    Console.Write(prompt);
        //    return Console.ReadLine();
        //}

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


        static void bookingConfirmationAlert()
        {
            vehicle = new Vehicle();
            vehicle.bookingConfirmationAlert();
            carOwner.bookingConfirmationAlert();
            renter.bookingConfirmationAlert();
        }


        static void DisplayConfirmation(Vehicle selectedVehicle, Booking selectedBooking)
        {
            Console.WriteLine("Booking and Payment Confirmation:");
            Console.WriteLine($"Vehicle: {selectedVehicle.Make} {selectedVehicle.Model}");
            Console.WriteLine($"Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate:dd/MM/yyyy}, Start Time: {selectedBooking.StartTime:HH:mm}, End Date: {selectedBooking.EndDate:dd/MM/yyyy}, End Time: {selectedBooking.EndTime:HH:mm}");
            Console.WriteLine("Thank you for your reservation!");
        }

        static void reviewBooking(Vehicle selectedVehicle, Booking selectedBooking)
        {
            Console.WriteLine();
            Console.WriteLine("Booking details:");
            Console.WriteLine($"Vehicle: {selectedVehicle.Make}, {selectedVehicle.Model} ({selectedVehicle.Type}), Mileage:{selectedVehicle.Mileage}, Price:${selectedVehicle.Price}");
            Console.WriteLine($"Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate:dd/MM/yyyy}, Start Time: {selectedBooking.StartTime:HH:mm}, End Date: {selectedBooking.EndDate:dd/MM/yyyy}, End Time: {selectedBooking.EndTime:HH:mm}");
            Console.WriteLine("-----------------Proceed to payment-----------------");
            Console.WriteLine();
        }

        static void createbooking(Vehicle selectedVehicle, Booking selectedBooking, Renter r)
        {
            
            // Assign pickup and return locations
            selectedBooking.IcarStationPickup = new IcarStation();
            selectedBooking.IcarStationReturn = new IcarStation();
            selectedBooking.Deliverypickup = new Delivery();
            selectedBooking.DeliveryReturn = new Delivery();
            selectedBooking.IcarStationPickup.Location = Program.location;
            selectedBooking.IcarStationReturn.Location = Program.location2;
            selectedBooking.Deliverypickup.Location = Program.fulladdress;
            selectedBooking.DeliveryReturn.Location = Program.fulladdress;

            // Assign the selected vehicle to the booking
            selectedBooking.Vehicle = selectedVehicle;

            // Add the booking to the renter's upcoming rentals
            r.TrackUpComingBooking.Add(selectedBooking);
            r.BookingHistory.Add(selectedBooking);
        }

        static Renter startbokingprocess()
        {
            Renter renter = new Renter(1,"Jayden", 87654321, Convert.ToDateTime("07/08/2005"),"2B",true);
            return renter;
        }


        static CarOwner startInterface()
        {
            CarOwner carOwner = new CarOwner(1, "Jayden", 87654321, Convert.ToDateTime("07/08/2005"));
            carOwner.Vehiclelist.Add(new Vehicle(1, "Toyota", "Corolla", 12000, "url1", 0, true, "Toyota", "Sedan"));
            carOwner.Vehiclelist.Add(new Vehicle(2, "Honda", "Civic", 15000, "url2", 0, true, "Honda", "Sedan"));
            carOwner.Vehiclelist.Add(new Vehicle(3, "Ford", "Focus", 13000, "url3", 0, true, "Ford", "Hatchback"));
            carOwner.Vehiclelist.Add(new Vehicle(4, "Chevrolet", "Malibu", 11000, "url4", 0, true, "Chevrolet", "Sedan"));
            carOwner.Vehiclelist.Add(new Vehicle(5, "Nissan", "Altima", 14000, "url5", 0, true, "Nissan", "Sedan"));
            return carOwner;
        }
        static void getListOfVehicle()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.getListOfVehicle();
        }
        static void displayVehicle(List<Vehicle> listofVechicle)
        {
            foreach (Vehicle vehicle in listofVechicle)
            {
                Console.WriteLine($"Id: {vehicle.Id} - {vehicle.Make} {vehicle.Model} - Mileage: {vehicle.Mileage} - Price: {vehicle.Price}");
            }
        }
        static void promptVehicle()
        {
            Console.Write("Please enter the number corresponding to your vehicle choice: ");
            
        }
        static void selectVehicle(out int vehicleid)
        {
             vehicleid = Convert.ToInt32(Console.ReadLine());
            Vehicle vehicle = new Vehicle();
            vehicle.getVehicle(vehicleid);
            
        }
      

       static void promptDateTime()
        {
            Console.Write("Enter the schedule start date (dd/MM/YYYY): ");
         // DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter the schedule end date (dd/MM/YYYY): ");
          // DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter the schedule start time (HH:mm): ");
           // DateTime startTime = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter the schedule end time (HH:mm): ");
           //DateTime endTime = Convert.ToDateTime(Console.ReadLine());
           
            
        }
       static void enterDateTime(DateTime startDate,DateTime startTime,DateTime endDate,DateTime endTime)
        {
            bool conflictFound;

            do
            {
                conflictFound = false;

                Console.Write("Enter the start date (dd/MM/YYYY): ");
                while (!DateTime.TryParse(Console.ReadLine(), out startDate) || startDate < DateTime.Today)
                {
                    Console.WriteLine("Invalid start date. Please enter a valid date.");
                }

                Console.Write("Enter the start time (HH:mm): ");
                while (!DateTime.TryParse(Console.ReadLine(), out startTime))
                {
                    Console.WriteLine("Invalid start time. Please enter a valid time.");
                }

                Console.Write("Enter the end date (dd/MM/YYYY): ");
                while (!DateTime.TryParse(Console.ReadLine(), out endDate) || endDate < startDate)
                {
                    Console.WriteLine("Invalid end date. Please enter a valid date after the start date.");
                }

                Console.Write("Enter the end time (HH:mm): ");
                while (!DateTime.TryParse(Console.ReadLine(), out endTime) || endTime <= startTime)
                {
                    Console.WriteLine("Invalid end time. Please enter a valid time after the start time.");
                }

                foreach (Vehicle vehicle in carOwner.Vehiclelist)
                {
                    if (vehicle.Id == vehicleid)
                    {
                        DateTime bookedStart = vehicle.Booking.StartDate.Add(vehicle.Booking.StartTime.TimeOfDay);
                        DateTime bookedEnd = vehicle.Booking.EndDate.Add(vehicle.Booking.EndTime.TimeOfDay);

                        DateTime newStart = startDate.Add(startTime.TimeOfDay);
                        DateTime newEnd = endDate.Add(endTime.TimeOfDay);

                        // Check for overlap
                        if ((newStart < bookedEnd && newEnd > bookedStart) || (newStart >= bookedStart && newStart < bookedEnd))
                        {
                            Console.WriteLine("The selected date and time overlap with an existing booking. Please enter a different time slot.");
                            conflictFound = true;
                            break;
                        }



                        if (conflictFound)
                            break;
                    }
                }

            } while (conflictFound);

            BookingSlot.createBookingSlot();
            BookingSlot.setDateTime(startDate, startTime, endDate, endTime);
            
        }
        static void promptRentalfee()
        {
            Console.Write("Enter the rental fee ($60-$106): ");
            //double fee = Convert.ToDouble(Console.ReadLine());
            //BookingSlot.setRentalfee(fee);
           // BookingSlot.addtoListOfBookingSlot(BookingSlot);
        }
        static void enterRentalfee(double fee)
        {
           
            //fee = Convert.ToDouble(Console.ReadLine());
            while (!double.TryParse(Console.ReadLine(), out fee) || fee < 60 || fee > 106)
            {
                Console.WriteLine("Invalid fee. Please enter a value between $60 and $106.");
                displayErrorMessage();
            }
            BookingSlot.setRentalfee(fee);
            BookingSlot.addtoListOfBookingSlot(BookingSlot);
            displaySuccessfulMeaasge();
        }
        static void displaySuccessfulMeaasge()
        {
            Console.WriteLine("Booking scheduled successfully.");
            Console.WriteLine("A confirmation email will be sent to you shortly.");
        }
        static void displayErrorMessage()
        {
            Console.WriteLine("Please try again");
        }
        /*
        static void ManageBooking(List<CarOwner> vlist)
        {
            try
            {
                // Display car owners
                foreach (CarOwner owner in vlist)
                {
                    Console.WriteLine($"Id: {owner.Id,-5} Name: {owner.Name,-10} Contact Number: {owner.ContactNumber,-15} Date of Birth: {owner.DateofBirth:dd/MM/yyyy}");
                }
                 Id =Convert.ToInt32( Console.ReadLine());
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
                        if (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, DateTimeStyles.None, out DateTime startTime))
                        {
                            Console.WriteLine("Error: Invalid start time format.");
                            return;
                        }

                        Console.Write("Enter the schedule end time (HH:mm): ");
                        if (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, DateTimeStyles.None, out DateTime endTime))
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
                                   inputStartDateTime < bookingEndDateTime && inputEndDateTime > bookingStartDateTime;
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
                            int bookingIndex = selectedOwner.Bookinglist.Count - 1; // Index of the new booking

                            // newBooking.setDate(id, bookingIndex, startDate, endDate);
                            //newBooking.setTime(id, bookingIndex, startTime, endTime);
                            //newBooking.setRentalfee( selectedOwner.Vehiclelist.IndexOf(selectedVehicle), fee);

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
        }*/


        static void selectTrackUpComingBooking()
        {
            foreach (Booking selectedBooking in renter.TrackUpComingBooking)
            {
                Console.WriteLine($"Booking ID: {selectedBooking.Id}, Start Date: {selectedBooking.StartDate:dd/MM/yyyy}, Start Time: {selectedBooking.StartTime.TimeOfDay}, End Date: {selectedBooking.EndDate:dd/MM/yyyy}, End Time: {selectedBooking.EndTime.TimeOfDay}");
                if (string.IsNullOrEmpty(selectedBooking.IcarStationPickup.Location))
                {

                }
                else
                {
                    Console.WriteLine($"IcarStationPickup:{selectedBooking.IcarStationPickup.Location}");
                }
                if (string.IsNullOrEmpty(selectedBooking.IcarStationReturn.Location))
                {

                }
                else
                {
                    Console.WriteLine($"IcarStationReturn:{selectedBooking.IcarStationReturn.Location}");
                }
                if (string.IsNullOrEmpty(selectedBooking.Deliverypickup.Location))
                {

                }
                else
                {
                    Console.WriteLine($"Deliverypickup:{selectedBooking.Deliverypickup.Location}");
                }
                if (string.IsNullOrEmpty(selectedBooking.DeliveryReturn.Location))
                {

                }
                else
                {
                    Console.WriteLine($"DeliveryReturn:{selectedBooking.DeliveryReturn.Location}");
                }
               

            }
        }

        static void getlistofUpComingBooking(int bookingid)
        {
            Console.WriteLine("select Booking Id:");
            bookingid=Convert.ToInt32(Console.ReadLine());
            
            renter.getlistofUpComingBooking(bookingid);
            
        }

        static void modifyUpcomingBooking()
        {
           
            
        }

        static void selectModificationChoice(out string option)
        {
            Console.WriteLine("do you want to modify pickup/return location (yes/no)");
             option = Console.ReadLine();
            
        }

        static void noModification()
        {
            foreach(Booking booking in Program.renter.TrackUpComingBooking)
            {
                foreach(Booking BookingHistory in Program.renter.BookingHistory)
                {
                    if (booking == BookingHistory)
                    {
                        Console.WriteLine("No Modification");
                        break;
                    }
                }
            }
        }

        
        static void selectPickupOrReturnLocation()
        {
            Console.WriteLine("Select a Location: ");
            Console.WriteLine("[1] Pickup Location: ");
            Console.WriteLine("[2] Return Location: ");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                modifyPickupLocation();
            }
            else if (input == "2")
            {
                modifyReturnLocation();
            }
            else
            {
                Console.WriteLine("Invalid option. Please select 1 or 2.");
            }
        }


        static void modifyPickupLocation()
        {
            // Display current pickup location from the selected booking
            Console.WriteLine($"Current Pickup Location: {Program.renter.TrackUpComingBooking[Program.bookingId].Deliverypickup.Location}");

            // Ask if the user wants to modify the pickup location to a delivery option
            Console.WriteLine("Would you like to change the pickup location to a delivery option? (Yes/No)");
            string changeLocation = Console.ReadLine();

            if (changeLocation.ToLower() == "yes")
            {
                Console.Write("Enter the new Pickup Location: ");
                string newPickupLocation = Console.ReadLine();

                // Update the pickup location
                Program.renter.TrackUpComingBooking[Program.bookingId].Deliverypickup.Location = newPickupLocation;
                Program.renter.TrackUpComingBooking[Program.bookingId].IcarStationPickup.Location = "";
                Console.WriteLine($"Pickup Location Updated: {newPickupLocation}");
            }
            else
            {
                Console.WriteLine("Pickup Location remains the same.");
            }

           /* getModificationCost();
            displayModifyCost();
            confirmModifyCost();*/
        }



        static void modifyReturnLocation()
        {
            // Display current return location from the selected booking
            Console.WriteLine($"Current Return Location: {Program.renter.TrackUpComingBooking[Program.bookingId].DeliveryReturn.Location}");

            // Ask if the user wants to modify the return location to a delivery option
            Console.WriteLine("Would you like to change the return location to a delivery option? (Yes/No)");
            string changeLocation = Console.ReadLine();

            if (changeLocation.ToLower() == "yes")
            {
                Console.Write("Enter the new Return Location: ");
                string newReturnLocation = Console.ReadLine();

                // Update the return location
                Program.renter.TrackUpComingBooking[Program.bookingId].DeliveryReturn.Location = newReturnLocation;
                Program.renter.TrackUpComingBooking[Program.bookingId].IcarStationReturn.Location = "";
                Console.WriteLine($"Return Location Updated: {newReturnLocation}");
            }
            else
            {
                Console.WriteLine("Return Location remains the same.");
            }

          /*  getModificationCost();
            displayModifyCost();
            confirmModifyCost();*/
        }



        static double getModificationCost()
        {
            // set cost to 50 dollars
            double modificationCost = 50.0;
            return modificationCost;
        }

        static void displayModifyCost()
        {
            Console.WriteLine($"Modification Cost: {getModificationCost()}");  // display value of getModificationCost
        }

        static void confirmModifyCost()
        {
            // a confirmation button and link to payment method
            Console.WriteLine("Do you want to confirm the modification? (Yes/No)");
            string confirm = Console.ReadLine().ToLower();

            if (confirm == "yes")
            {
                Console.WriteLine("Modification confirmed. Proceeding to payment.");
                // Now you can use selectVehicle and selectedBooking to call the payment methods
                selectPayment(vehicle,selectedBooking);
                modificationUpdatedAlert();
            }
            else
            {
                Console.WriteLine("Modification cancelled.");
            }
        }

      
        static void modificationUpdatedAlert()
        {
            // Print a message to confirm that the modification has been successfully updated
            Console.WriteLine("Modification has been updated successfully. Thank you for your patience.");
        }
    }
}
