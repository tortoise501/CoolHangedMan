class Line : ILine
{
  public int layer { get; set; }
  public string line { get; set; }
  public int x { get; set; }
  public int y { get; set; }
  public int width { get; set; }
  public int height { get; set; }
  public Palette ColorPalette { get; set; }
  public Line(int x, int y, string line, Palette palette = Palette.Primary, int layer = 0)
  {
    this.layer = layer;
    ColorPalette = palette;
    this.line = line;
    this.x = x;
    this.y = y;
  }

  public RenderData[,] GetRenderData()
  {
    RenderData[,] res = new RenderData[line.Length, 1];
    for (int i = 0; i < line.Length; i++)
    {
      if (line[i] != ' ')
      {
        res[i, 0] = new RenderData(line[i], ColorPalette);
      }
    }
    return res;
  }
}