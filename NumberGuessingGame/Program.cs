Random random = new Random();
bool PlayAgain = true;
int min = 1;
int max = 100;
int guess;
int number;
int guesses;
String response;

while (PlayAgain)
{
    guess = 0;
    guesses = 0;
    response = "";
    number = random.Next(min, max + 1);
    Console.WriteLine($"Guess a number between {min} - {max} :");
    while (guess != number)
    {
        guess = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Guess : {guess}");
        if (guess < number)
        {
            Console.WriteLine($"{guess} is to low!");
        }
        else if (guess > number)
        {
            Console.WriteLine($"{guess} is to high!");
        }
        guesses++;
    }
    Console.WriteLine($"Number : {number}");
    Console.WriteLine("You Win!");
    Console.WriteLine("Would you play again (Y/N) :");
    response = Console.ReadLine();
    response = response.ToUpper();
    if (response == "Y")
    {
        PlayAgain = true;
    }
    else if (response == "N")
    {
        PlayAgain = false;
    }
}
Console.WriteLine("Thanks for playing! ... I guess");