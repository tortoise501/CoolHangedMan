
class Circle : ICircle
{
  public int radius { get; set; }
  public int diametr;
  private int _x;
  private int _y;
  public int x { get => _x - xOffset; set { _x = value; } }
  public int y { get => _y - yOffset; set { _y = value; } }
  public int xOffset;
  public int yOffset;
  public int width { get; set; }
  public int height { get; set; }
  public Palette ColorPalette { get; set; }

  /// <summary>
  /// Warning d = r*2 + 1
  /// width = d
  /// height = d / charRatio(1.65)
  /// </summary>
  public Circle(int r, int x, int y, Palette palette = Palette.Primary)
  {
    ColorPalette = palette;
    radius = r;
    this.x = x;
    this.y = y;
    diametr = radius * 2 + 1;
    width = diametr;
    height = diametr;
    xOffset = radius;
    yOffset = radius;
  }
  RenderData[,]? cashedRenderData = null;
  public RenderData[,] GetRenderData()
  {
    if (cashedRenderData != null) return cashedRenderData;
    RenderData[,] res = new RenderData[width, height];
    //return new RenderData[,] { { new RenderData('#', Palette.WhiteOnBlack), new RenderData('#', Palette.WhiteOnBlack), new RenderData('#', Palette.WhiteOnBlack), null, null, null, new RenderData('#', Palette.WhiteOnBlack), new RenderData('#', Palette.WhiteOnBlack), new RenderData('#', Palette.WhiteOnBlack) }, { null, null, null, new RenderData('#', Palette.WhiteOnBlack), new RenderData('#', Palette.WhiteOnBlack), new RenderData('#', Palette.WhiteOnBlack), null, null, null } };
    double r = Convert.ToDouble(radius);
    for (double xi = -r; xi <= r; xi++)
    {
      for (double yi = -r; yi <= r; yi++)
      {
        double d = Math.Pow(xi / r, 2) + Math.Pow(yi / (r / RenderData.CharRatio), 2);
        if (d > 0.90 && d < 1.20)
        {
          res[(int)xi + radius, (int)yi + radius] = new RenderData('#', ColorPalette);
        }
      }
    }
    cashedRenderData = res;
    return res;
  }
}