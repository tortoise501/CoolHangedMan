enum Palette
{
  Primary,
  PrimaryBordered,

  Secondary,
  SecondaryBordered,

  Accent,
  AccentBordered,

  Accent2,
  Accent2Bordered,
}
static class ColorPicker
{
  public static Dictionary<Palette, Brush> PaletteBrush = new Dictionary<Palette, Brush>() {
    { Palette.Primary, new Brush(ConsoleColor.White, ConsoleColor.Black) },
    { Palette.PrimaryBordered, new Brush(ConsoleColor.Black, ConsoleColor.White) },

    { Palette.Secondary, new Brush(ConsoleColor.Blue, ConsoleColor.Black) },
    { Palette.SecondaryBordered, new Brush(ConsoleColor.Black, ConsoleColor.Blue) },

    { Palette.Accent, new Brush(ConsoleColor.Yellow, ConsoleColor.Black) },
    { Palette.AccentBordered, new Brush(ConsoleColor.Black, ConsoleColor.Yellow) },

    { Palette.Accent2, new Brush(ConsoleColor.Red, ConsoleColor.Black) },
    { Palette.Accent2Bordered, new Brush(ConsoleColor.Black, ConsoleColor.Red) },
  };
}


class Brush
{
  public ConsoleColor TextColor;
  public ConsoleColor BackgroundColor;
  public Brush(ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
  {
    TextColor = textColor;
    BackgroundColor = backgroundColor;
  }
}