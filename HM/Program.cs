
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
ConsoleGameRenderer Renderer = new ConsoleGameRenderer(table[0].Length, table.Length);
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

LinesBlock Canvas = new LinesBlock(0, 0, table, Palette.Primary);
Renderer.AddObjectToRender(Canvas);
int alphabetXOffset = 3;
int alphabetYOffset = 1;
Letter[] alphabetLetters = alphabet.Select((letter, i) => new Letter(alphabetXOffset + i, alphabetYOffset, letter)).ToArray();
foreach (Letter letter in alphabetLetters)
{
  Renderer.AddObjectToRender(letter);
}
int selectorPos = 0;
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
  }
  SelectLetter(selectorPos);
}
void SelectLetter(int i)
{
  alphabetLetters[lastSelected].ColorPalette = Palette.Primary;
  alphabetLetters[i].ColorPalette = Palette.Secondary;
  lastSelected = i;
}
// Line alphabetLineTest = new Line(3, 1, alphabet, Palette.Primary);
// Renderer.AddObjectToRender(alphabetLineTest);
