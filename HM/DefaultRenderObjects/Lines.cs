class LinesBlock : IBox
{
  public int layer { get; set; }
  public int x { get; set; }
  public int y { get; set; }
  public int width { get; set; }
  public int height { get; set; }
  public Palette ColorPalette { get; set; }
  string[] lines;
  public LinesBlock(int x, int y, string[] lines, Palette palette, int layer = 0)
  {
    this.layer = layer;
    ColorPalette = palette;
    this.lines = lines;
    width = lines.MaxBy(str => str.Length).Length;
    height = lines.Length;
    this.x = x;
    this.y = y;
  }

  public RenderData[,] GetRenderData()
  {
    RenderData[,] res = new RenderData[width, height];
    for (int yi = 0; yi < height; yi++)
    {
      for (int xi = 0; xi < lines[yi].Length; xi++)
      {
        res[xi, yi] = new RenderData(lines[yi][xi], ColorPalette);
      }
    }
    return res;
  }
}