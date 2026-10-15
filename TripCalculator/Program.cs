/*
 * Name:    Andy Gomez
 * Course:  CSCI 1250, Section 001
 * Assignment:  Lab 04, The Group Trip
 * Date:    October 7, 2026
 * Description: Rebuilds the trip calculator with methods and arrays so it reports on a whole group instead of one person
*/


using System.Numerics;

const double taxrate = .18;
const int pizzaslices = 8;

//Inputs
Console.WriteLine ("=== Part 1: The Trip ===");

Console.Write("How many miles did you travel? ");
int miles = Convert.ToInt32(Console.ReadLine());

Console.Write("What is the mile per gallon for the car you travel on? ");
double milePerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write("What was the average price per gallon you paid? ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

Console.Write ("How many pizzas? ");
int pizzaboxes = Convert.ToInt32(Console.ReadLine());

Console.Write ("Price per pizza? ");
double pizzacost = Convert.ToDouble(Console.ReadLine());

/*
Part 1
*/

double pizzatotal = pizzaboxes * pizzacost;


double tTotal = fuelcost(miles, milePerGallon, pricePerGallon) + pizzatotal; 


Console.WriteLine("Fuel Cost: " + fuelcost(miles, milePerGallon, pricePerGallon).ToString("C"));
Console.WriteLine("Pizza cost: " + pizzatotal.ToString("C"));
Console.WriteLine("Trip Total: " + tTotal.ToString("C"));


/*
Part 2
*/

Console.WriteLine ("=== Part 2: The Group ===");

string[] names = { "Ada", "Grace", "Alan", "Katherine"};
double[] hoursWorked = {22, 15, 30, 18};
double[] hourlyRates = {13.50, 16.00, 11.20, 14.80};

int totalslices = pizzaboxes * pizzaslices;
int slicesPer = totalslices / names.Length;

decimal costPer = Convert.ToDecimal(tTotal / names.Length);

Console.WriteLine("People Going: " + names.Length);
Console.WriteLine("Slices each: " + slicesPer);
Console.WriteLine("Cost Per Person: " + costPer.ToString("C"));



/*
Part 3: Who Works How Long
*/

Console.WriteLine ("=== Part 3: Who Works How Long ===");

double totalHours = 0;
double longest = 0;
double totalpay = 0;

for (int i = 0; i < names.Length; i++)
{
    takehomepay(hoursWorked[i], hourlyRates[i], taxrate);
    double pay = takehomepay(hoursWorked[i], hourlyRates[i], taxrate);

    double takehomeper = pay / hoursWorked[i];

    HoursToCover(Convert.ToDouble(costPer), takehomeper);
    double hoursNeeded = HoursToCover(Convert.ToDouble(costPer), takehomeper);

    totalHours = totalHours + hoursWorked[i];
    totalpay = totalpay + pay;

    longest = Math.Max(longest, hoursNeeded);

    Console.WriteLine(names[i] +": takes home " + pay.ToString("C") + " for " + hoursWorked[i] + " hours, " + takehomeper.ToString("C") + " per hour, must work " + hoursNeeded.ToString("F2") + " hours");

}

    Console.WriteLine("Total Hours worked: " + totalHours);
    Console.WriteLine("Total take home pay: " + totalpay.ToString("C"));
    Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));



// Hands back fuel cost by dividing and multiplying the user's inputs
static double fuelcost(double miles, double milePerGallon, double pricePerGallon)
{
    double gallons = miles / milePerGallon;
    return gallons * pricePerGallon;
}

//Hands back Take Home Pays by multiplying inputted Hours and Hourly rate, along side a constant tax rate and grosspay
static double takehomepay (double hours, double hourlyRate, double taxrate)
{
    double grosspay = hours * hourlyRate;

    double withheld =   grosspay * taxrate;

    return withheld = grosspay - withheld;
}

//Hands back Hours Needed by dividing amountowed and hourly rate
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed / takeHomePerHour;
}