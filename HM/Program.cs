
string[] words = new string[]{
  "weather",
  "sun",
  "rain",
  "snow",
  "blizzard",
  "hurricane",
  "lightning",
  "storm",
  "cloud",
  "thunder"
};
int lastSelected = 0;
// Renderer.AddObjectToRender(new LinesBlock(10, 10, new string[] { "awdaw", "wadwa", "wdpiajwdiajwod" }, Palette.SecondaryBordered));
string alphabet = "abcdefghijklmnopqrstuvwxyz";
string[] table = new string[]{
  "+----------------------------------------------------------------------+",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "|                                                                      |",
  "+----------------------------------------------------------------------+"
};
int screenWidth = table[0].Length;
int screenHeight = table.Length;
int screenXStart = 1;
int screenXEnd = screenWidth - 2;
int screenYStart = 1;
int screenYEnd = screenHeight - 2;
ConsoleGameRenderer Renderer = new ConsoleGameRenderer(screenWidth, screenHeight);
string[][] hangedMans = new string[][]{//7 levels of hanged man
  new string[]{
    @"          -----------",
    @"             |     \|",
    @"             |      |",
    @"             0      |",
    @"            -|-     |",
    @"            / \     |",
    @"                    |",
    @"                    |",
  },
  new string[]{
    @"          -----------",
    @"             |     \|",
    @"             |      |",
    @"             0      |",
    @"            -|-     |",
    @"            / \     |",
    @"            ---     |",
    @"            | |     |",
  },
  new string[]{
    @"          -----------",
    @"             |     \|",
    @"             |      |",
    @"             O      |",
    @"                    |",
    @"                    |",
    @"            ---     |",
    @"            | |     |",
  },
  new string[]{
    @"          -----------",
    @"             |     \|",
    @"             |      |",
    @"                    |",
    @"                    |",
    @"                    |",
    @"            ---     |",
    @"            | |     |",
  },
  new string[]{
    @"          -----------",
    @"                   \|",
    @"                    |",
    @"                    |",
    @"                    |",
    @"                    |",
    @"            ---     |",
    @"            | |     |",
  },
  new string[]{
    @"          -----------",
    @"                   \|",
    @"                    |",
    @"                    |",
    @"                    |",
    @"                    |",
    @"                    |",
    @"                    |",
  },
new string[]{
    @"                     ",
    @"                     ",
    @"                     ",
    @"                     ",
    @"                     ",
    @"                     ",
    @"                     ",
    @"                     ",
  },
};





int selectorPos = 0;
string correctWord = words[Random.Shared.Next(words.Length)];
string guessingWord = string.Join("", correctWord.Select(c => "_").ToArray());
int score = 0;

Line scoreCounter = new Line(screenXEnd - 12, screenYStart + 1, $"Score: {score}", Palette.Primary, 1);
Renderer.AddObjectToRender(scoreCounter);

Line CorrectWordDebug = new Line(screenXEnd - 12, screenYStart + 3, correctWord, Palette.Primary, 1);
Renderer.AddObjectToRender(CorrectWordDebug);

Line GuessingWordDebug = new Line(screenXEnd - 12, screenYStart + 3, string.Join(" ", guessingWord.ToCharArray()), Palette.Primary, 1);
Renderer.AddObjectToRender(GuessingWordDebug);

LinesBlock Canvas = new LinesBlock(0, 0, table, Palette.Primary, 0);
Renderer.AddObjectToRender(Canvas);

int alphabetXOffset = 3;
int alphabetYOffset = 1;
Letter[] alphabetLetters = alphabet.Select((letter, i) => new Letter(alphabetXOffset + i, alphabetYOffset, letter, Palette.Primary, 1)).ToArray();
foreach (Letter letter in alphabetLetters)
{
  Renderer.AddObjectToRender(letter);
}
SelectLetter(selectorPos);

while (true)
{
  Renderer.RefreshRenderData();
  Renderer.FastRender();
  ConsoleKey inputKey = Console.ReadKey().Key;
  switch (inputKey)
  {
    case ConsoleKey.LeftArrow:
      {
        selectorPos--;
        selectorPos = Math.Max(0, selectorPos);
        break;
      }
    case ConsoleKey.RightArrow:
      {
        selectorPos++;
        selectorPos = Math.Min(alphabetLetters.Length - 1, selectorPos);
        break;
      }
    case ConsoleKey.Enter:
      {
        OnLetterPressed();
        break;
      }
  }
  SelectLetter(selectorPos);
  scoreCounter.line = $"Score: {score}";
}




void SelectLetter(int i)
{
  alphabetLetters[lastSelected].ColorPalette = Palette.Primary;
  alphabetLetters[i].ColorPalette = Palette.Secondary;
  lastSelected = i;
}
void OnLetterPressed()
{
  char selectedLetter = alphabetLetters[selectorPos].c;
  if (IsInCorrectWord(selectedLetter))
  {
    if (IsAlreadyFilled(selectedLetter))
    {
      OnFilledLetter();
    }
    else
    {
      FillCorrectLetter(selectedLetter);
    }
  }
  else
  {
    OnMistake();
  }
}



void FillCorrectLetter(char correctChar)
{
  score += 5;
  guessingWord = string.Join("", guessingWord.Select((c, i) => correctWord[i] == correctChar ? correctWord[i] : guessingWord[i]).ToArray());
  GuessingWordDebug.line = string.Join(" ", guessingWord.ToCharArray());
}
void OnFilledLetter()
{
  score--;
}
void OnMistake()
{
  score -= 3;
}
bool IsAlreadyFilled(char c) => guessingWord.Contains(c);
bool IsInCorrectWord(char c) => correctWord.Contains(c);
// Line alphabetLineTest = new Line(3, 1, alphabet, Palette.Primary);
// Renderer.AddObjectToRender(alphabetLineTest);





