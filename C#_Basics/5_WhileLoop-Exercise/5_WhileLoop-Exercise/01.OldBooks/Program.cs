string favouriteBook = Console.ReadLine();

bool isFavouriteBookFound = false;
int counter = 0;

while (true)
{
    string currentBook = Console.ReadLine();

    if (currentBook == favouriteBook)
    {
        isFavouriteBookFound = true;
        break;
    }

    if (currentBook == "No More Books")
    {
        break;
    }
    counter++;
}

if (isFavouriteBookFound == false)
{
    Console.WriteLine($"The book you search is not here!");
    Console.WriteLine($"You checked {counter} books.");
} else
{
    Console.WriteLine($"You checked {counter} books and found it.");
}