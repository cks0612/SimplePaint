namespace SimplePaint
{

    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public partial class form1 : Form
    {

        enum ToolType { Line, Rectangle, Circle }

        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;

        private bool isDrawing = false;

        private Point startPoint;
        private Point endPoint;

        private ToolType currentTool = ToolType.Line;

        private Color currentColor = Color.Black;

        private int currentLineWidth = 2;

        private float zoom = 1.0f;

        

        private bool isPanning = false;
        private Point panStartMouse;
        private Point panStartScroll;

        private bool isDraggingImage = false;
        private Point dragStart;
        private Point imageOffset = new Point(0, 0);



        public form1()
        {
            InitializeComponent();

            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);

            //picCanvas.Image = canvasBitmap;

            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;

            picCanvas.Paint += PicCanvas_Paint;

            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;

            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 10;
            trbLineWidth.Value = 5;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;

            btnSaveFile.Click += BtnSaveFile_Click;

            btnOpenFile.Click += BtnOpenFile_Click;

            panelCanvas.MouseWheel += PanelCanvas_MouseWheel;
            panelCanvas.MouseDown += PanelCanvas_MouseDown;
            panelCanvas.MouseMove += PanelCanvas_MouseMove;
            panelCanvas.MouseUp += PanelCanvas_MouseUp;

            // 포커스 안 잡히면 휠 안 먹음
            panelCanvas.Focus();
            panelCanvas.MouseEnter += (s, e) => panelCanvas.Focus();

        }

        private Point GetScaledPoint(Point p)
        {
            return new Point(
                (int)((p.X - imageOffset.X) / zoom),
                (int)((p.Y - imageOffset.Y) / zoom)
            );
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                isDraggingImage = true;
                dragStart = e.Location;
                picCanvas.Cursor = Cursors.Hand;
                return;
            }

            isDrawing = true;
            startPoint = GetScaledPoint(e.Location);
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDraggingImage)
            {
                int dx = e.X - dragStart.X;
                int dy = e.Y - dragStart.Y;

                imageOffset.X += dx;
                imageOffset.Y += dy;

                dragStart = e.Location;

                picCanvas.Invalidate();
                return;
            }

            if (!isDrawing) return;
            endPoint = GetScaledPoint(e.Location);

            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {

            if (isDraggingImage)
            {
                isDraggingImage = false;
                picCanvas.Cursor = Cursors.Default;
                return;
            }

            if (!isDrawing) return;

            isDrawing = false;
            endPoint = GetScaledPoint(e.Location);



            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }
            picCanvas.Invalidate(); 
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(imageOffset.X, imageOffset.Y);
            e.Graphics.ScaleTransform(zoom, zoom);

            if (canvasBitmap != null)
            {
                e.Graphics.DrawImage(canvasBitmap, 0, 0);
            }

            if (!isDrawing) return;
            
            using (Pen previewPen = new Pen(currentColor, currentLineWidth))
            {
                previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);
            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
            Math.Min(p1.X, p2.X),
            Math.Min(p1.Y, p2.Y),
            Math.Abs(p1.X - p2.X),
            Math.Abs(p1.Y - p2.Y)
            );
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: 
                    currentColor = Color.Black;
                    break;
                case 1: 
                    currentColor = Color.Red;
                    break;
                case 2: 
                    currentColor = Color.Blue;
                    break;
                case 3: 
                    currentColor = Color.Green;
                    break;
                default:
                    currentColor = Color.Black;
                    break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp";
                sfd.Title = "이미지 저장";
                sfd.DefaultExt = "png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Png;

                    switch (System.IO.Path.GetExtension(sfd.FileName).ToLower())
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;

                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;

                        case ".png":
                        default:
                            format = ImageFormat.Png;
                            break;
                    }

                    canvasBitmap.Save(sfd.FileName, format);
                }
            }
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(ofd.FileName);

                    canvasBitmap = new Bitmap(img);
                    canvasGraphics = Graphics.FromImage(canvasBitmap);

                    //picCanvas.Image = canvasBitmap;

                    ResizeCanvasToImage();
                }
            }
        }

        private void ResizeCanvasToImage()
        {
            picCanvas.Width = canvasBitmap.Width;
            picCanvas.Height = canvasBitmap.Height;
        }

        private void PanelCanvas_MouseWheel(object sender, MouseEventArgs e)
        {

            if ((ModifierKeys & Keys.Control) != Keys.Control)
                return;

            float oldZoom = zoom;

            if (e.Delta > 0)
                zoom += 0.1f;
            else
                zoom -= 0.1f;

            if (zoom < 0.1f) zoom = 0.1f;
            if (zoom > 5.0f) zoom = 5.0f;

            // 마우스 기준 좌표 유지
            var mousePos = e.Location;

            panelCanvas.AutoScrollPosition = new Point(
                (int)((mousePos.X + panelCanvas.AutoScrollPosition.X) * (zoom / oldZoom) - mousePos.X),
                (int)((mousePos.Y + panelCanvas.AutoScrollPosition.Y) * (zoom / oldZoom) - mousePos.Y)
            );

            picCanvas.Invalidate();
        }

        private void PanelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right)
            {
                isPanning = true;
                panStartMouse = e.Location;
                panStartScroll = panelCanvas.AutoScrollPosition;
                panelCanvas.Cursor = Cursors.Hand;
            }
        }

        private void PanelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isPanning) return;

            int dx = e.X - panStartMouse.X;
            int dy = e.Y - panStartMouse.Y;

            panelCanvas.AutoScrollPosition = new Point(
                -(panStartScroll.X + dx),
                -(panStartScroll.Y + dy)
            );
        }

        private void PanelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isPanning = false;
            panelCanvas.Cursor = Cursors.Default;
        }

        

    }



}
