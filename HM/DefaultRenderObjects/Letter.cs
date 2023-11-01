class Letter : Point
{
  public int layer { get; set; }
  public char c;
  public Letter(int x, int y, char c, Palette palette = Palette.Primary, int layer = 0) : base(x, y, palette, layer)
  {
    this.c = c;
  }
  public override RenderData[,] GetRenderData()
  {
    return new RenderData[,] { { new RenderData(c, ColorPalette) } };
  }
}