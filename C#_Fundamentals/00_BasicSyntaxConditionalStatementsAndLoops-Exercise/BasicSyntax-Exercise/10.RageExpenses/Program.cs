int countLostGames = int.Parse(Console.ReadLine());
double priceHeadset = double.Parse(Console.ReadLine());
double priceMouse = double.Parse(Console.ReadLine());
double priceKeyboard = double.Parse(Console.ReadLine());
double priceDisplay = double.Parse(Console.ReadLine());

int timesHeadsetTrashed = countLostGames / 2;
int timesMouseTrashed = countLostGames / 3;
int timesKeyboardTrashed = countLostGames / 6;
int timesDisplayTrashed = countLostGames / 12;

double expenses = (timesHeadsetTrashed * priceHeadset) + (timesMouseTrashed * priceMouse) + (timesKeyboardTrashed * priceKeyboard) + (timesDisplayTrashed * priceDisplay);

Console.WriteLine($"Rage expenses: {expenses:F2} lv.");