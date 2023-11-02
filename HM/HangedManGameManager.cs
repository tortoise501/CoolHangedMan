class HangedManGameManager
{
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
  int screenWidth;// = table[0].Length;
  int screenHeight;// = table.Length;
  int screenXStart;// = 1;
  int screenXEnd;// = screenWidth - 2;
  int screenYStart;// = 1;
  int screenYEnd;// = screenHeight - 2;
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

  ConsoleGameRenderer Renderer;


  int lastSelected;// = 0;
  int selectorPos;// = 0;
  string correctWord;// = words[Random.Shared.Next(words.Length)];
  string guessingWord;// = string.Join("", correctWord.Select(c => "_").ToArray());
  int score;// = 0;

  int countdown = 60;
  bool isTimeOut = false;

  IRenderable[] RenderObjects;

  Line scoreCounter;
  Line countdownCounter;
  Line CorrectWordDebug;
  Line GuessingWordDebug;
  LinesBlock Canvas;
  Letter[] alphabetLetters;

  public HangedManGameManager()
  {
    //screen s
    screenWidth = table[0].Length;
    screenHeight = table.Length;
    screenXStart = 1;
    screenXEnd = screenWidth - 2;
    screenYStart = 1;
    screenYEnd = screenHeight - 2;
    //screen f

    Renderer = new ConsoleGameRenderer(screenWidth, screenHeight);


    lastSelected = 0;
    selectorPos = 0;
    correctWord = words[Random.Shared.Next(words.Length)];
    guessingWord = string.Join("", correctWord.Select(c => "_").ToArray());
    score = 0;

    countdownCounter = new Line(screenXStart + 2, screenYEnd - 2, $"Time Left: {countdown}s", Palette.Primary, 1);
    Renderer.AddObjectToRender(countdownCounter);

    CorrectWordDebug = new Line(screenXEnd - correctWord.Length * 2, screenYStart + 5, correctWord, Palette.Primary, 1);
    Renderer.AddObjectToRender(CorrectWordDebug);

    GuessingWordDebug = new Line(screenXEnd - guessingWord.Length * 2, screenYStart + 3, string.Join(" ", guessingWord.ToCharArray()), Palette.Primary, 1);
    Renderer.AddObjectToRender(GuessingWordDebug);

    Canvas = new LinesBlock(0, 0, table, Palette.Primary, 0);
    Renderer.AddObjectToRender(Canvas);


    int alphabetXOffset = 3;
    int alphabetYOffset = 1;
    alphabetLetters = alphabet.Select((letter, i) => new Letter(alphabetXOffset + i, alphabetYOffset, letter, Palette.Primary, 1)).ToArray();
    foreach (Letter letter in alphabetLetters)
    {
      Renderer.AddObjectToRender(letter);
    }
    SelectLetter(selectorPos);
  }
  public void StartRender()
  {
    while (true)
    {
      Render();
      Thread.Sleep(1);
    }
  }
  public void Render()
  {
    countdownCounter.line = $"Time Left: {countdown}s";
    Renderer.RefreshRenderData();
    Renderer.FastRender();
  }
  public void StartCountdown()
  {
    while (true)
    {
      Thread.Sleep(1000);
      countdown--;
      if (countdown <= 0)
      {
        isTimeOut = true;
        return;
      }
    }
  }
  public void HandleInput()
  {
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
    if (score != 0)
    {
      countdown += score;
      score = 0;
    }
  }
  public void DrawAndInput()
  {
    Thread RenderThread = new Thread(StartRender);
    RenderThread.Start();
    Thread CountdownThread = new Thread(StartCountdown);
    CountdownThread.Start();
    while (true)
    {
      HandleInput();
    }
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
}