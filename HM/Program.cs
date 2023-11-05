Console.CursorVisible = false;
Console.WriteLine("Press N to start the game or any other button to stop the game");
if (Console.ReadKey().Key != ConsoleKey.N) Environment.Exit(0);
while (true)
{
  HangedManGameManager HG = new HangedManGameManager();
  bool isGameWon = HG.DrawAndInput();
  Thread.Sleep(1000);
  Console.Clear();
  if (isGameWon)
  {
    Console.WriteLine("----------------------------- YOU WON!!! -----------------------------\n\n\nPress N to start new game or Esc to exit the game");
  }
  else
  {
    Console.WriteLine($"----------------------------- YOU LOST!!! -----------------------------\nThe word was \"{HG.correctWord}\"\n\nPress N to start new game or Esc to exit the game");
  }
  ConsoleKey inputKey;
  while (true)
  {
    inputKey = Console.ReadKey().Key;
    if (inputKey == ConsoleKey.N || inputKey == ConsoleKey.Escape)
    {
      break;
    }
  }
  if (inputKey == ConsoleKey.Escape)
  {
    Console.WriteLine("Thanks for playing my game Ü");
    break;
  }
}