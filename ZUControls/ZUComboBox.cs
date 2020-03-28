using System;
using System.Windows.Forms;
using System.Drawing;

namespace ZUControls
{
    public class ZUComboBox : ComboBox
    {
        private Font oldFont = null;
        private Boolean hintTextEnabled = false;
        private Boolean _hinttextenabled = false;
        private Color _hintTextColor = Color.Gray;
        private string _hintText = "Hint Text";
        private Color oFocusBackColor = Color.Gold;
        private Color oLeaveBackColor = Color.White;

        public ZUComboBox()
        {
            this.Enabled = true;
            this.DoubleBuffered = true;

            this.GotFocus += new System.EventHandler(this.ZUComboBox_GotFocus);
            this.LostFocus += new System.EventHandler(this.ZUComboBox_LostFocus);

            this.TextChanged += new System.EventHandler(this.HintText_Switch);
            this.FontChanged += new System.EventHandler(this.HintText_FontChanged);
        }


        #region Propiedades
        public bool HintTextEnabled
        {
            get { return _hinttextenabled; }
            set
            {
                _hinttextenabled = value;

                EnableHintText();
            }
        }

        public Color HintTextColor
        {
            get { return _hintTextColor; }
            set
            {
                _hintTextColor = value; Invalidate();
            }
        }

        public string HintText
        {
            get { return _hintText; }
            set { _hintText = value; Invalidate(); }
        }

        public Color OnFocusBackColor
        {
            get { return oFocusBackColor; }
            set { oFocusBackColor = value; }
        }

        public Color OnLeaveBackColor
        {
            get { return oLeaveBackColor; }
            set { oLeaveBackColor = value; }
        }
        #endregion

        #region "Eventos"
        private void HintText_FontChanged(object sender, EventArgs args)
        {
            if (hintTextEnabled)
            {
                oldFont = new Font(Font.FontFamily, Font.Size, Font.Style,
                    Font.Unit);
                Refresh();
            }
        }

        private void ZUComboBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = OnFocusBackColor;
        }

        private void ZUComboBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = OnLeaveBackColor;

            HintTextSwitch();
        }
        
        private void HintText_Switch(object sender, EventArgs args)
        {
            HintTextSwitch();
        }
        #endregion

        //Override OnCreateControl
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            HintText_Switch(null, null);
        }

        //Override OnPaint
        protected override void OnPaint(PaintEventArgs args)
        {
            // Use the same font that was defined in base class
            System.Drawing.Font drawFont = new System.Drawing.Font(Font.FontFamily,
                Font.Size, Font.Style, Font.Unit);
            //Create new brush with gray color or 
            SolidBrush drawBrush = new SolidBrush(HintTextColor);//use Water mark color
            //Draw Text or WaterMark
            args.Graphics.DrawString((hintTextEnabled ? HintText : Text),
                drawFont, drawBrush, new PointF(0.0F, 0.0F));
            base.OnPaint(args);
        }

        private void HintTextSwitch()
        {
            if (this.Text.Length <= 0)
                EnableHintText();
            else
                DisableHintText();
        }

        private void EnableHintText()
        {
            if (HintTextEnabled)
            {
                //Save current font until returning the UserPaint style to false (NOTE:
                //It is a try and error advice)
                oldFont = new Font(Font.FontFamily, Font.Size, Font.Style,
                   Font.Unit);
                //Enable OnPaint event handler
                this.SetStyle(ControlStyles.UserPaint, true);
                this.hintTextEnabled = true;
                //Triger OnPaint immediatly
                Refresh();

            }
            else
            {
                DisableHintText();
            }
        }

        private void DisableHintText()
        {
            //Disbale OnPaint event handler
            this.hintTextEnabled = false;
            this.SetStyle(ControlStyles.UserPaint, false);
            //Return back oldFont if existed
            if (oldFont != null)
            {
                this.Font = new Font(oldFont.FontFamily, oldFont.Size, oldFont.Style, oldFont.Unit);
            }

            Refresh();
        }
    }
}
