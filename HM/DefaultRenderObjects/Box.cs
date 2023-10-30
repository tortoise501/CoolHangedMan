class Box : IBox
{
  public int x { get; set; }
  public int y { get; set; }
  public int width { get; set; }
  public int height { get; set; }
  public Palette ColorPalette { get; set; }

  public Box(int x, int y, int height, int width, Palette palette = Palette.Primary)
  {
    ColorPalette = palette;
    this.y = y;
    this.x = x;
    this.width = width;
    this.height = height;
  }
  public RenderData[,]? cashedRenderData = null;
  public RenderData[,] GetRenderData()
  {
    if (cashedRenderData != null) return cashedRenderData;

    RenderData[,] res = new RenderData[width, height];
    for (int y = 0; y < height; y++)
    {
      res[0, y] = new RenderData('#', ColorPalette);
      res[width - 1, y] = new RenderData('#', ColorPalette);
      bool c1 = y != 0;
      bool c2 = y != height - 1;
      bool c3 = width <= 2;
      if (!((y == 0 || y == height - 1) && width > 2)) continue;
      for (int x = 1; x < width - 1; x++)
      {
        res[x, y] = new RenderData('#', ColorPalette);
      }
    }
    return res;
  }
}