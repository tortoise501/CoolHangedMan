class RenderData
{
  public char character { get; private set; } = '\u259E';
  public Palette Palette;
  public RenderData(char character = '\u259E', Palette palette = Palette.Primary)
  {
    Palette = palette;
    this.character = character;
  }
  public override string ToString()
  {
    return character.ToString();
  }
  public static float CharRatio = 1.65f;
}