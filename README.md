# Garage Management System

## Overview

The **Garage Management System** is a C# console application that allows you to manage a garage by adding, removing, displaying, and searching for vehicles. The application supports multiple types of vehicles, including motorcycles, cars, and buses. It also allows you to display vehicle types, search for vehicles based on different criteria, and manage the garage's capacity.

## Features

- **Add Vehicle**: Park a motorcycle, car, or bus in the garage.
- **Remove Vehicle**: Remove a parked vehicle from the garage using its registration number.
- **Display Vehicle List**: View all parked vehicles along with their details.
- **Display Vehicle Types**: See the count and details of different vehicle types (Motorcycle, Car, Bus).
- **Search Vehicles**: Search for vehicles based on color, number of wheels, or type.
- **Create a New Garage**: Set a new capacity and create a garage from scratch.
- **Exit**: Safely exit the application.

## Technologies Used

- **C#**: Main programming language.
- **.NET Framework**: Application runs on the .NET platform.
- **OOP (Object-Oriented Programming)**: Core design methodology with inheritance, interfaces, and encapsulation.

## Class Overview

### 1. **Garage\<T>**

The `Garage` class represents the garage itself, where vehicles are stored. It supports basic operations such as adding, removing, displaying, and searching for vehicles.

#### Methods:
- `AddVehicle(T vehicle)`: Adds a vehicle to the garage.
- `RemoveVehicle(string registrationNumber)`: Removes a vehicle by its registration number.
- `DisplayVehicles()`: Displays a list of all vehicles in the garage.
- `DisplayVehicleType()`: Displays the count of each vehicle type (Motorcycle, Car, Bus).
- `SearchVehicle()`: Allows the user to search for vehicles based on specific criteria.
- `CreateGarage(int capacity)`: Creates a new garage with the specified capacity.

### 2. **GarageHandler**

The `GarageHandler` class is responsible for handling user inputs and menu options. It processes user interactions to perform operations on the garage, such as adding or removing vehicles.

#### Methods:
- `HandleMenuInput()`: Displays the main menu and processes user inputs.
- `HandleAddVehicle()`: Manages the process of adding a new vehicle to the garage.
- `HandleRemoveVehicle()`: Manages the process of removing a vehicle.
- `HandleCreateGarage()`: Manages the process of creating a new garage.

### 3. **UI**

The `UI` class is responsible for the user interface and interacts with the user to display menus and exit the application.

#### Methods:
- `DisplayMenu()`: Displays the main menu options.
- `ExitApplication()`: Exits the application.

### 4. **Vehicle (Base Class)**

The `Vehicle` class is the base class representing a vehicle. It holds common properties for all vehicles, such as registration number, color, and the number of wheels.

### 5. **Motorcycle, Car, and Bus (Derived Classes)**

These classes inherit from the `Vehicle` class and represent specific types of vehicles with additional properties.

- **Motorcycle**: Adds `CylinderVolume`.
- **Car**: Adds `FuelType`.
- **Bus**: Adds `NumberOfSeats`.

## How to Run the Application

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/garage-management-system.git
   ```
2. **Open the project** in your preferred C# IDE (e.g., Visual Studio).
3. **Build and Run** the project.
4. Follow the on-screen instructions to manage the garage using the menu options.

## Sample Usage

1. **Start the Application**: The main menu will be displayed.
2. **Choose an Option**:
   - Press `1` to add a new vehicle.
   - Press `2` to display all vehicles in the garage.
   - Press `3` to display the types and counts of vehicles.
   - Press `4` to remove a vehicle using its registration number.
   - Press `5` to search for a vehicle based on various criteria.
   - Press `6` to create a new garage with a specified capacity.
   - Press `7` to exit the application.

## Input Validation

- **Registration Number**: Must be between 4 and 8 alphanumeric characters.
- **Color**: Must contain only alphabetical characters.
- **Vehicle Type**: Valid input options are `1 (Motorcycle)`, `2 (Car)`, and `3 (Bus)`.

## Future Enhancements

- Add more vehicle types (e.g., Trucks, Bicycles).
- Implement persistent data storage (e.g., save and load the garage state from a file).
- Provide a more detailed user interface or graphical interface.
----