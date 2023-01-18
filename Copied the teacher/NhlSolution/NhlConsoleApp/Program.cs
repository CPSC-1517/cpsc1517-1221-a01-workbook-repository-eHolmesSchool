// See https://aka.ms/new-console-template for more information

using NhlSystemClassLibrary;

// Prompt and read in the team name
//Console.Write("Enter the team name: ");
//string teamName = Console.ReadLine();
try
{
    // Create a new Team instance
    Team oilers = new Team("Oilers","Edmonton","Rogers Place", Conference.Western, Division.Pacific);
    // Print the Team Name
    //Console.WriteLine($"Team Name: {currentTeam.Name}");
    Console.WriteLine(oilers);
    //Console.WriteLine($"Name: {oilers.Name}, City: {oilers.City}, Arena: {oilers.Arena}");
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);  
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch
{
    Console.WriteLine("Incorrect exception thrown");
}

