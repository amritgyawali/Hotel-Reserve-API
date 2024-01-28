## Welcome to Hotel-Reserve: Your Ultimate Hotel Booking API 🏨✨

Welcome to Hotely, your go-to solution for seamless hotel booking experiences! Developed with the latest technologies in C# and ASP.NET Core, Hotel Reserve offers a robust and intuitive RESTful API that empowers you to effortlessly manage hotel bookings with ease.

### Preparing Your Environment

Before diving into the world of Hotel Reserve, let's ensure your environment is set up correctly. Here's what you'll need:

1. **C# and ASP.NET Core SDK**:
   Ensure you have the .NET SDK version 8.0.101 and Runtime version 8.0.1 installed on your system. Don't worry, we'll guide you through the process!

   ```sh
   sudo pacman -S dotnet-sdk
   sudo pacman -S dotnet-runtime
   dotnet tool install --global dotnet-ef
   ```

### Getting Started with Hotelify

Let's get you started with Hotelify in just a few simple steps:

1. **Clone the Repository**:
   Begin by cloning the Hotel Reserve repository to your local machine. Simply run the following command:

   ```sh
   git clone https://github.com/PublisherName/Hotel-Reserve-API.git
   ```

2. **Navigate to the Project Directory**:
   Once the repository is cloned, navigate to the project directory using your terminal:

   ```sh
   cd HotelReserveAPI
   ```

3. **Configure Your Database Connection**:
   Open the `appsettings.json` file and update it with your database connection string. We've provided a placeholder connection string as a reference. Replace it with your actual database details:

   ```json
   {
      "Logging": {
          "LogLevel": {
              "Default": "Information",
              "Microsoft.AspNetCore": "Warning"
          }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
          "DefaultConnection": "server=<mysql_server>;database=<data_basename>;user=<username>;password=<password>"
      },
      "SecretKey": "<secret_key>"
   }
   ```

4. **Install Dependencies**:
   Before running Hotel-Reserve, let's make sure we have all the necessary dependencies. Run the following command to restore NuGet packages:

   ```sh
   dotnet restore
   ```

5. **Build the Project**:
   Once the dependencies are installed, build the project with the following command:

   ```sh
   dotnet build
   ```

6. **Run Hotelify**:
   It's time to launch Hotel-Reserve! Run the following command to start the API:

   ```sh
   dotnet run
   ```

7. **Explore Hotelify in Your Browser**:
   Hotel-Reserve is now up and running! Access the API documentation and explore its features in your favorite browser:

   ```sh
   https://localhost:5293/swagger/index.html
   ```

## Database Migration Made Easy

Managing your database with Hotel-Reserve is a breeze. Follow these simple steps to perform database migration:

1. **Add Migration**:
   Generate an initial migration for your database with the following command:

   ```sh
   dotnet ef migrations add InitialCreate
   ```

2. **Update Database**:
   Apply the migration to your database to update its schema:

   ```sh
   dotnet ef database update
   ```
