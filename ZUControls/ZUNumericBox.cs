using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace ZUControls
{ 
    public class ZUNumericBox : TextBox
    {
        private Font oldFont = null;
        private Boolean hintTextEnabled = false;
        private Boolean _hinttextenabled = false;
        private Color _hintTextColor = Color.Gray;
        private string _hintText = "Hint Text";
        private bool _decimales = false;
        private Color oFocusBackColor = Color.Gold;        
        private Color oLeaveBackColor = Color.White;
        private EnterKeyPressed onEnterKeyPressed = EnterKeyPressed.doNothing;

        public ZUNumericBox()
        {
            this.DoubleBuffered = true;

            this.GotFocus += new System.EventHandler(this.ZUNumericBox_GotFocus);
            this.LostFocus += new System.EventHandler(this.ZUNumericBox_LostFocus);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZUNumericBox_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ZUNumericBox_KeyPress);
            this.TextChanged += new System.EventHandler(this.HintText_Switch);
            this.FontChanged += new System.EventHandler(this.HintText_FontChanged);
        }

        public enum EnterKeyPressed
        {
            doNothing,
            nextControl
        }

        #region Propiedades
        public EnterKeyPressed OnEnterKeyPressed
        {
            get { return onEnterKeyPressed; }
            set
            {
                onEnterKeyPressed = value;
            }
        }

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

        [Description("Activa o desactiva la opción de poder escribir el símbolo decimal")]
        public bool CaracterDecimal
        {
            get { return _decimales; }
            set
            {
                _decimales = value;

                if (value == false)
                {
                    this.Text = this.Text.Replace(",", "");
                }
            }
        }

        [Description("El color del fondo del componente cuando se tiene el foco sobre él")]
        public Color OnFocusBackColor
        {
            get { return oFocusBackColor; }
            set { oFocusBackColor = value; }
        }

        [Description("El color del fondo del componente cuando ya no se tiene el foco sobre él")]
        public Color OnLeaveBackColor
        {
            get { return oLeaveBackColor; }
            set { oLeaveBackColor = value; }
        }

        #endregion


        #region "eventos"
        private void HintText_FontChanged(object sender, EventArgs args)
        {
            if (hintTextEnabled)
            {
                oldFont = new Font(Font.FontFamily, Font.Size, Font.Style,
                    Font.Unit);
                Refresh();
            }
        }

        private void HintText_Switch(object sender, EventArgs args)
        {
            HintTextSwitch();
        }
        
        private void ZUNumericBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = OnFocusBackColor;
        }

        private void ZUNumericBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (onEnterKeyPressed == EnterKeyPressed.nextControl)
                {
                    this.Parent.SelectNextControl(this, true, true, true, true);
                }

                e.SuppressKeyPress = true;
            }
        }

        private void ZUNumericBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CaracterDecimal == true)
            {
                if (e.KeyChar.Equals('.'))
                {
                    e.KeyChar = ',';
                }

                if (e.KeyChar.Equals(','))
                {
                    TextBox txt = (TextBox)sender;
                    if (txt.Text.Contains(","))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
                else if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ZUNumericBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = OnLeaveBackColor;
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
                6.0F, Font.Style, Font.Unit);
            //Create new brush with gray color or 
            SolidBrush drawBrush = new SolidBrush(HintTextColor);//use Water mark color
            //Draw Text or WaterMark
            args.Graphics.DrawString((hintTextEnabled ? HintText : Text),
                drawFont, drawBrush, new PointF(0F, 0F));
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
