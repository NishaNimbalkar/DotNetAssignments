using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Car
    {

        public int carId;
        public string carBrannd;
        public string carModel;
        public int carYear;
        public double carPrice;

        public int GetCarId()
        {
            return carId;
        }
        public void setCarId(int idValue)
        {
            carId = idValue;

        }
        public string GetBrand()
        {
            return carBrannd;
        }
        public void setBrand(string carBrandValue)
        {

            carBrannd = carBrandValue;
        }
        public string getModel()
        {
            return carModel;
        }
        public void setModel(string carModelValue)
        {
            carModel = carModelValue;
        }
        public int getYear()
        {
            return carYear;
        }
        public void setYear(int carYearValue)
        {
            carYear = carYearValue;
        }
        public double GetPrice()
        {
            return carPrice;
        }
        public void setPrice(double carPriceValue)
        {
            carPrice = carPriceValue;
        }
        public void AcceptCarDetails()
        {
            Console.WriteLine("Receiving Car Information");

            Console.Write("Enter Car ID: ");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Car Brand: ");
            carBrannd = Console.ReadLine();

            Console.Write("Enter Car Model: ");
            carModel = Console.ReadLine();

            Console.Write("Enter Car Manufacturing Year: ");
            carYear = int.Parse(Console.ReadLine());

            Console.Write("Enter Car Price: ");
            carPrice = double.Parse(Console.ReadLine());
        }
        public void DisplayCarDetails()
        {
            Console.WriteLine("Presenting Car Information");
            Console.WriteLine($"Car ID: {carId}");
            Console.WriteLine($"Brand: {carBrannd}");
            Console.WriteLine($"Model: {carModel}");
            Console.WriteLine($"Year: {carYear}");
            Console.WriteLine($"Price: ${carPrice}");
        }
        public Car()
        {
            carId = 1102;
            carBrannd = "Mahindra";
            carModel = "Bolero";
            carYear = 2017;
            carPrice = 2000000;
        }

        public Car(int carId, string carBrand, string carModel, int carYear, double carPrice)
        {
            Console.WriteLine("Paramerizes construcor");
            this.carId = carId; // 'this' is used to refer to the instance variable
            this.carBrannd = carBrand;
            this.carModel = carModel;
            this.carYear = carYear;
            this.carPrice = carPrice;
        }
    }

}


