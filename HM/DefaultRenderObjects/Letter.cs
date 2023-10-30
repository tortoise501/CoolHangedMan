class Letter : Point
{
  public char c;
  public Letter(int x, int y, char c, Palette palette = Palette.Primary) : base(x, y, palette)
  {
    this.c = c;
  }
  public override RenderData[,] GetRenderData()
  {
    return new RenderData[,] { { new RenderData(c, ColorPalette) } };
  }
}