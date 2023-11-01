interface IRenderable
{
  RenderData[,] GetRenderData();
  int x { get; set; }
  int y { get; set; }
  int width { get; set; }
  int height { get; set; }
  Palette ColorPalette { get; set; }
  int layer { get; set; }
}




///       x
///       
///       |
///       \/
///
/// y --> +----------------+
///       |                |
///       |                |
///       |                |
///       |                |
///       |                |
///       |                |
///       |                |
///       +----------------+
///
///
///
///
///
///
///
///