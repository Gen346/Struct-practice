using System;

struct NOTE
{
    public string LastName;
    public string FirstName;
    public string PhoneNumber;
    public int[] BirthDate;

    public NOTE(string lastName, string firstName, string phoneNumber, int[] birthDate)
    {
        LastName = lastName;
        FirstName = firstName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }
}

class Program
{
    static void Main(string[] args)
    {
        NOTE[] notes = new NOTE[2];
        for (int i = 0; i < notes.Length; i++)
        {
            Console.WriteLine($"Input data for record {i + 1}:");
            Console.WriteLine("Input last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Input first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Input phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Input birthday (dd mm yy): ");
            string[] birthDateInput = Console.ReadLine().Split(' ');
            int[] birthDate = Array.ConvertAll(birthDateInput, int.Parse);
            notes[i] = new NOTE(lastName, firstName, phoneNumber, birthDate);
        }

        Array.Sort(notes, (x, y) => x.BirthDate[2].CompareTo(y.BirthDate[2]));

        Console.WriteLine("Sorted data of array:");
        foreach (var note in notes)
        {
            Console.WriteLine($"Last name, first name: {note.LastName}, {note.FirstName}");
            Console.WriteLine($"Phone number: {note.PhoneNumber}");
            Console.WriteLine($"Birthday: {note.BirthDate[0]}, {note.BirthDate[1]}, {note.BirthDate[2]}");
            Console.WriteLine();
        }

        Console.WriteLine("Input phone number to find a person: ");
        string phoneFind = Console.ReadLine();
        bool found = false;
        foreach (var note in notes)
        {
            if (note.PhoneNumber == phoneFind)
            {
                Console.WriteLine($"App found a record for this phone number: {phoneFind}");
                Console.WriteLine($"Last name, first name: {note.LastName}, {note.FirstName}");
                Console.WriteLine($"Birthday: {note.BirthDate[0]}, {note.BirthDate[1]}, {note.BirthDate[2]}");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Record for {phoneFind} was not found.");
        }
    }
}
