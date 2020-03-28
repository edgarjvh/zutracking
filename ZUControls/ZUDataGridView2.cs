using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace ZUControls
{
    public class ZUDataGridView2 : DataGridView
    {
        public ZUDataGridView2()
        {
            this.DoubleBuffered = true;
            this.CellPainting += new DataGridViewCellPaintingEventHandler(this.DataGridView_CellPainting);
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.Gray;
            this.BackgroundColor = Color.FromKnownColor(KnownColor.Control);
            //this.BackgroundHeaderStyle = backgroundHeaderStyle.Style1;
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Segoe UI"), (float)7, FontStyle.Bold);
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.ColumnHeadersHeight = 17;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DefaultCellStyle.BackColor = Color.Silver;
            this.DefaultCellStyle.Font = new Font(new FontFamily("Segoe UI"), (float)7, FontStyle.Bold);
            this.DefaultCellStyle.ForeColor = Color.Black;
            this.DefaultCellStyle.SelectionBackColor = Color.Gold;
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.GridColor = Color.FromKnownColor(KnownColor.Control);
            this.HeaderForeColor = Color.White;
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta < 0)
                SendKeys.Send("{DOWN}");
            else
                SendKeys.Send("{UP}");
        }

        #region "Datagridview Painting"

        public static ContentAlignment anyRight = (ContentAlignment.BottomRight | (ContentAlignment.MiddleRight | ContentAlignment.TopRight));

        public static ContentAlignment anyTop = (ContentAlignment.TopRight | (ContentAlignment.TopCenter | ContentAlignment.TopLeft));

        public static ContentAlignment anyBottom = (ContentAlignment.BottomRight | (ContentAlignment.BottomCenter | ContentAlignment.BottomLeft));

        public static ContentAlignment anyCenter = (ContentAlignment.BottomCenter | (ContentAlignment.MiddleCenter | ContentAlignment.TopCenter));

        public static ContentAlignment anyMiddle = (ContentAlignment.MiddleRight | (ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft));

        private void TekenAchtergrond(Graphics g, Image obj, Rectangle r, int index)
        {
            if ((obj == null))
            {
                return;
            }
            int oWidth = obj.Width;
            Rectangle lr = Rectangle.FromLTRB(0, 0, 0, 0);
            Rectangle r2 = default(Rectangle);
            Rectangle r1 = default(Rectangle);
            int x = ((index - 1) * oWidth);
            int y = 0;
            int x1 = r.Left;
            int y1 = r.Top;
            if (((r.Height > obj.Height) && (r.Width <= oWidth)))
            {
                r1 = new Rectangle(x, y, oWidth, lr.Top);
                r2 = new Rectangle(x1, y1, r.Width, lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                r1 = new Rectangle(x, (y + lr.Top), oWidth, (obj.Height - (lr.Top - lr.Bottom)));
                r2 = new Rectangle(x1, (y1 + lr.Top), r.Width, (r.Height - (lr.Top - lr.Bottom)));
                if (((lr.Top + lr.Bottom) == 0))
                {
                    r1.Height = (r1.Height - 1);
                }
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                r1 = new Rectangle(x, (y + (obj.Height - lr.Bottom)), oWidth, lr.Bottom);
                r2 = new Rectangle(x1, (y1 + (r.Height - lr.Bottom)), r.Width, lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
            }
            else if (((r.Height <= obj.Height) && (r.Width > oWidth)))
            {
                r1 = new Rectangle(x, y, lr.Left, obj.Height);
                r2 = new Rectangle(x1, y1, lr.Left, r.Height);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                r1 = new Rectangle((x + lr.Left), y, (oWidth - (lr.Left - lr.Right)), obj.Height);
                r2 = new Rectangle((x1 + lr.Left), y1, (r.Width - (lr.Left - lr.Right)), r.Height);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                r1 = new Rectangle((x + (oWidth - lr.Right)), y, lr.Right, obj.Height);
                r2 = new Rectangle((x1 + (r.Width - lr.Right)), y1, lr.Right, r.Height);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
            }
            else if (((r.Height <= obj.Height) && (r.Width <= oWidth)))
            {
                r1 = new Rectangle(((index - 1) * oWidth), 0, oWidth, (obj.Height - 1));

                g.DrawImage(obj, new Rectangle(x1, y1, r.Width, r.Height), r1, GraphicsUnit.Pixel);
            }
            else if (((r.Height > obj.Height) && (r.Width > oWidth)))
            {
                //top-left
                r1 = new Rectangle(x, y, lr.Left, lr.Top);
                r2 = new Rectangle(x1, y1, lr.Left, lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //top-bottom
                r1 = new Rectangle(x, (y + (obj.Height - lr.Bottom)), lr.Left, lr.Bottom);
                r2 = new Rectangle(x1, (y1 + (r.Height - lr.Bottom)), lr.Left, lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //left
                r1 = new Rectangle(x, (y + lr.Top), lr.Left, (obj.Height - (lr.Top - lr.Bottom)));
                r2 = new Rectangle(x1, (y1 + lr.Top), lr.Left, (r.Height - (lr.Top - lr.Bottom)));
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //top
                r1 = new Rectangle((x + lr.Left), y, (oWidth - (lr.Left - lr.Right)), lr.Top);
                r2 = new Rectangle((x1 + lr.Left), y1, (r.Width - (lr.Left - lr.Right)), lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //right-top
                r1 = new Rectangle((x + (oWidth - lr.Right)), y, lr.Right, lr.Top);
                r2 = new Rectangle((x1 + (r.Width - lr.Right)), y1, lr.Right, lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //Right
                r1 = new Rectangle((x + (oWidth - lr.Right)), (y + lr.Top), lr.Right, (obj.Height - (lr.Top - lr.Bottom)));
                r2 = new Rectangle((x1 + (r.Width - lr.Right)), (y1 + lr.Top), lr.Right, (r.Height - (lr.Top - lr.Bottom)));
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //right-bottom
                r1 = new Rectangle((x + (oWidth - lr.Right)), (y + (obj.Height - lr.Bottom)), lr.Right, lr.Bottom);
                r2 = new Rectangle((x1 + (r.Width - lr.Right)), (y1 + (r.Height - lr.Bottom)), lr.Right, lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //bottom
                r1 = new Rectangle((x + lr.Left), (y + (obj.Height - lr.Bottom)), (oWidth - (lr.Left - lr.Right)), lr.Bottom);
                r2 = new Rectangle((x1 + lr.Left), (y1 + (r.Height - lr.Bottom)), (r.Width - (lr.Left - lr.Right)), lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                //Center
                r1 = new Rectangle((x + lr.Left), (y + lr.Top), (oWidth - (lr.Left - lr.Right)), (obj.Height - (lr.Top - lr.Bottom)));
                r2 = new Rectangle((x1 + lr.Left), (y1 + lr.Top), (r.Width - (lr.Left - lr.Right)), (r.Height - (lr.Top - lr.Bottom)));
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
            }
        }

        private Rectangle HAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
        {
            if (((align & anyRight) != (ContentAlignment)0))
            {
                withinThis.X = (withinThis.X + (withinThis.Width - alignThis.Width));
            }
            else if (((align & anyCenter) != (ContentAlignment)0))
            {
                withinThis.X = (withinThis.X + (((withinThis.Width - alignThis.Width) + 1) / 2));
            }
            withinThis.Width = alignThis.Width;
            return withinThis;
        }

        private Rectangle VAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
        {
            if (((align & anyBottom) != (ContentAlignment)0))
            {
                withinThis.Y = (withinThis.Y + (withinThis.Height - alignThis.Height));
            }
            else if (((align & anyMiddle) != (ContentAlignment)0))
            {
                withinThis.Y = (withinThis.Y + (((withinThis.Height - alignThis.Height) + 1) / 2));
            }
            withinThis.Height = alignThis.Height;
            return withinThis;
        }
        #endregion

        public enum backgroundHeaderStyle
        {
            Style1,
            Style2,
            Style3,
            Style4,
            Style5,
            Style6,
            Style7,
            Style8
        }

        private Image header = Properties.Resources.backgroundHeader3;

        public Image BackgroundHeader
        {
            get { return header; }
            set
            {
                header = value;
                this.Refresh();
            }
        }

        private backgroundHeaderStyle _backgroundHeaderStyle = backgroundHeaderStyle.Style3;
        //public backgroundHeaderStyle BackgroundHeaderStyle
        //{
        //    get { return _backgroundHeaderStyle; }
        //    set
        //    {
        //        _backgroundHeaderStyle = value;

        //        switch (_backgroundHeaderStyle)
        //        {
        //            case backgroundHeaderStyle.Style1:
        //                BackgroundHeader = Properties.Resources.backgroundHeader1;
        //                break;
        //            case backgroundHeaderStyle.Style2:
        //                BackgroundHeader = Properties.Resources.backgroundHeader2;
        //                break;
        //            case backgroundHeaderStyle.Style3:
        //                BackgroundHeader = Properties.Resources.backgroundHeader3;
        //                break;
        //            case backgroundHeaderStyle.Style4:
        //                BackgroundHeader = Properties.Resources.backgroundHeader4;
        //                break;
        //            case backgroundHeaderStyle.Style5:
        //                BackgroundHeader = Properties.Resources.backgroundHeader5;
        //                break;
        //            case backgroundHeaderStyle.Style6:
        //                BackgroundHeader = Properties.Resources.backgroundHeader6;
        //                break;
        //            case backgroundHeaderStyle.Style7:
        //                BackgroundHeader = Properties.Resources.backgroundHeader7;
        //                break;
        //            case backgroundHeaderStyle.Style8:
        //                BackgroundHeader = Properties.Resources.backgroundHeader8;
        //                break;
        //        }
        //    }
        //}
        
        private Color color = Color.Black;

        [Description("Color del texto de los encabezados de columnas")]
        public Color HeaderForeColor
        {
            get { return color; }
            set { color = value; this.Refresh(); }
        }

        private float size = 7.0F;

        [Description("Tamaño del texto de los encabezados de columnas")]
        public float HeaderFontSize
        {
            get { return size; }
            set { size = value; this.Refresh(); }
        }
               
        private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= -1)
            {
                Image img = default(Image);
                img = BackgroundHeader;
                TekenAchtergrond(e.Graphics, img, e.CellBounds, 1);

                Rectangle recBorder = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1);
                e.Graphics.DrawRectangle(Pens.Gray, recBorder);
                
                e.Handled = true;
            }

            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {                
                string text = e.Value.ToString();
                Font font = new Font(this.Font.FontFamily,size, this.Font.Style);
                
                SizeF sizef = new SizeF(e.CellBounds.Width, e.CellBounds.Height);
                StringFormat format1 = default(StringFormat);
                format1 = new StringFormat();
                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                SizeF ef1 = e.Graphics.MeasureString(text, font, sizef, format1);

                Size txts = default(Size);
                txts = System.Drawing.Size.Empty;

                txts = System.Drawing.Size.Ceiling(ef1);
                e.CellBounds.Inflate(-16, -16);

                Rectangle txtr = e.CellBounds;
                txtr = HAlignWithin(txts, txtr, ContentAlignment.MiddleCenter);
                txtr = VAlignWithin(txts, txtr, ContentAlignment.MiddleCenter);
                Brush brush2 = default(Brush);
                format1 = new StringFormat();
                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                brush2 = new SolidBrush(color);

                e.Graphics.DrawString(e.Value.ToString(), font, brush2, (RectangleF)txtr, format1);
                brush2.Dispose();

                e.Handled = true;
            }
        }        
    }
}
