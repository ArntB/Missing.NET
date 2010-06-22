using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Missing.Drawing
{
    public class GradientImage
    {
        private readonly Color[] colors;
        private float[] positions = new[] { 0.0f, 0.4f, 0.4f, 1.0f };
        private float angle = 90f;

        public GradientImage(Color[] colors)
        {
            this.colors = colors;
        }

        public Bitmap PaintImage(Rectangle ClientRectangle)
        {
            Size size = ClientRectangle.Size;
            Bitmap image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(image);

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Colors = colors;
            colorBlend.Positions = positions;

            angle = 90f;
            using (LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, colors.First(), colors.Last(), angle))
            {
                lgb.InterpolationColors = colorBlend;
                g.FillRectangle(lgb, ClientRectangle);
            }
            return image;
        }        
    }
}