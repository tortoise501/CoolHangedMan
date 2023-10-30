class StickMan : IRenderable
{
  public int x { get; set; }
  public int y { get; set; }
  public int width { get; set; }
  public int height { get; set; }
  public Palette ColorPalette { get; set; }

  public Circle Head;
  public Point[] Eyes;

  public StickMan(int X, int Y, int R, Palette palette = Palette.Primary)
  {
    ColorPalette = palette;
    x = X - R;
    y = Y - R;
    Head = new Circle(R, 0, 0);
    Eyes = new Point[] { new Point(-1, 0), new Point(1, 0) };

  }

  public RenderData[,] GetRenderData()
  {
    RenderData[,] res = Head.GetRenderData();
    foreach (IRenderable eye in Eyes)
    {

      res[eye.x + Head.radius, eye.y + Head.radius] = eye.GetRenderData()[0, 0];
    }
    return res;
  }
}