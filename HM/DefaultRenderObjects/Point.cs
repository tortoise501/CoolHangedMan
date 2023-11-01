class Point : IRenderable
{
  public int layer { get; set; }
  public int x { get; set; }
  public int y { get; set; }
  public int width { get; set; }
  public int height { get; set; }
  public Palette ColorPalette { get; set; }

  public Point(int x, int y, Palette palette = Palette.Primary, int layer = 0)
  {
    this.layer = layer;
    ColorPalette = palette;
    this.x = x;
    this.y = y;
  }

  public virtual RenderData[,] GetRenderData()
  {
    return new RenderData[,] { { new RenderData('#', ColorPalette) } };
  }
}