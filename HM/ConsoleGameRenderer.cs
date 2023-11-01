using System.Text;
using System.Linq;

class ConsoleGameRenderer
{
  readonly int ConsoleWidth;
  readonly int ConsoleHeight;
  private RenderData[,] renderData = new RenderData[0, 0];
  private List<IRenderable> objectsToRender = new List<IRenderable>();

  public ConsoleGameRenderer(int consoleWidth = 100, int consoleHeight = 20)
  {
    ConsoleWidth = consoleWidth;
    ConsoleHeight = consoleHeight;
    renderData = new RenderData[ConsoleWidth, ConsoleHeight];
  }
  public void RefreshRenderData()
  {
    renderData = new RenderData[ConsoleWidth, ConsoleHeight];
    UpdateRenderData();
  }
  public void UpdateRenderData()
  {
    for (int i = 0; i < objectsToRender.Count(); i++)
    {
      InsertRenderData(objectsToRender[i], objectsToRender[i].x, objectsToRender[i].y);
    }
  }
  private void InsertRenderData(IRenderable objectRenderI, int xOffset = 0, int yOffset = 0)
  {
    RenderData[,] objectRenderData = objectRenderI.GetRenderData();
    for (int y = 0; y < objectRenderData.GetLength(1); y++)
    {
      for (int x = 0; x < objectRenderData.GetLength(0); x++)
      {
        if (y + yOffset < renderData.GetLength(1) && x + xOffset < renderData.GetLength(0))
        {
          renderData[x + xOffset, y + yOffset] = objectRenderData[x, y];
        }
      }
    }
  }



  public void FastRender()
  {
    Console.Clear();
    for (int y = 0; y < renderData.GetLength(1); y++)
    {
      StringBuilder sb = new StringBuilder();
      Palette currentPalette = Palette.Primary;
      for (int x = 0; x < renderData.GetLength(0); x++)
      {

        //handling null render data as background 
        if (renderData[x, y] == null)
        {
          if (currentPalette == Palette.Primary)
          {
            sb.Append(" ");
          }
          else
          {
            RenderStrip(sb.ToString(), currentPalette);
            sb.Clear();
            currentPalette = Palette.Primary;
            sb.Append(" ");
          }
          continue;
        }

        if (currentPalette == renderData[x, y].Palette)
        {
          sb.Append(renderData[x, y]);
        }
        else
        {
          RenderStrip(sb.ToString(), currentPalette);
          sb.Clear();
          currentPalette = renderData[x, y].Palette;
          sb.Append(renderData[x, y]);
        }
      }
      if (sb.Length > 0)
      {
        RenderStrip(sb.ToString(), currentPalette);
      }
      Console.WriteLine();
    }
  }
  private void RenderStrip(string strip, Palette palette)
  {
    Brush brush = ColorPicker.PaletteBrush[palette];
    Console.ForegroundColor = brush.TextColor;
    Console.BackgroundColor = brush.BackgroundColor;
    Console.Write(strip);
  }
  public void AddObjectToRender(IRenderable objectToRender)
  {
    objectsToRender.Add(objectToRender);
    objectsToRender = objectsToRender.OrderBy(obj => obj.layer).ToList();
    IOrderedEnumerable<IRenderable> orderedList = objectsToRender.OrderBy(obj => obj.layer);
    IOrderedEnumerable<IRenderable> orderedDesList = objectsToRender.OrderByDescending(obj => obj.layer);
    Console.WriteLine("k");

  }
}