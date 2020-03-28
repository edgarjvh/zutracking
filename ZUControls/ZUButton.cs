using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace ZUControls
{
    public class ZUButton : Button
    {
        public ZUButton(){
            this.DoubleBuffered = true;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
            this.EnabledChanged += new System.EventHandler(this.ZUButton_EnabledChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZUButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ZUButton_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ZUButton_MouseMove);
            this.MouseLeave += new System.EventHandler(this.ZUButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZUButton_MouseUp);
        }

        public enum styleType
        {
            Native,
            Custom
        }

        private styleType oStyleType = styleType.Native;
        public styleType BackgroundStyle
        {
            get { return oStyleType; }
            set 
            {
                oStyleType = value;

                if (oStyleType == styleType.Native)
                {
                    switch (buttonStyle)
                    {
                        case buttonStyles.StyleOrange:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                            break;
                        case buttonStyles.StyleBlue:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                            break;
                        case buttonStyles.StyleGreen:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                            break;
                        case buttonStyles.StyleRed:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                            break;
                    }
                }
                else
                {
                    try
                    {
                        this.BackgroundImage = imageNormal;
                    }
                    catch
                    {
                        this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                    }
                }
            }
        }

        public enum buttonStyles
        {
            StyleOrange,
            StyleBlue,
            StyleGreen,
            StyleRed
        }

        private Image imageNormal = Properties.Resources.backgroundButtonNormal1;
        private Image imageClicked = Properties.Resources.backgroundButtonClicked1;
        private Image imageHover = Properties.Resources.backgroundButtonHover1;
        private Image imageDisabled = Properties.Resources.backgroundButtonDisabled;

        public Image BackgroundOnNormal
        {
            get { return imageNormal; }
            set 
            {
                imageNormal = value;

                if (oStyleType == styleType.Custom)
                {
                    this.BackgroundImage = imageNormal;
                }
            }
        }

        public Image BackgroundOnClick
        {
            get { return imageClicked; }
            set
            {
                imageClicked = value;
            }
        }

        public Image BackgroundOnHover
        {
            get { return imageHover; }
            set
            {
                imageHover = value;
            }
        }

        public Image BackgroundOnDisabled
        {
            get { return imageDisabled; }
            set
            {
                imageDisabled = value;
            }
        }
        
        private buttonStyles buttonStyle = buttonStyles.StyleOrange;

        public buttonStyles ButtonStyle
        {
            get { return buttonStyle; }
            set 
            { 
                buttonStyle = value;

                if (oStyleType == styleType.Native)
                {
                    switch (buttonStyle)
                    {
                        case buttonStyles.StyleOrange:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                            break;
                        case buttonStyles.StyleBlue:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                            break;
                        case buttonStyles.StyleGreen:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                            break;
                        case buttonStyles.StyleRed:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                            break;
                    }
                }
            }
        }
        private void ZUButton_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                if (oStyleType == styleType.Native)
                {
                    switch (buttonStyle)
                    {
                        case buttonStyles.StyleOrange:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                            break;
                        case buttonStyles.StyleBlue:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                            break;
                        case buttonStyles.StyleGreen:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                            break;
                        case buttonStyles.StyleRed:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                            break;
                    }
                }
                else
                {
                    try
                    {
                        this.BackgroundImage = imageNormal;
                    }
                    catch
                    {
                        switch (buttonStyle)
                        {
                            case buttonStyles.StyleOrange:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                                break;
                            case buttonStyles.StyleBlue:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                                break;
                            case buttonStyles.StyleGreen:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                                break;
                            case buttonStyles.StyleRed:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                                break;
                        }
                    }
                }
            }
            else
            {
                if (oStyleType == styleType.Native)
                {
                    this.BackgroundImage = Properties.Resources.backgroundButtonDisabled;
                }
                else
                {
                    try
                    {
                        this.BackgroundImage = imageDisabled;
                    }
                    catch
                    {
                        this.BackgroundImage = Properties.Resources.backgroundButtonDisabled;
                    }
                }
            }
        }

        private void ZUButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Enabled == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (oStyleType == styleType.Native)
                    {
                        switch (buttonStyle)
                        {
                            case buttonStyles.StyleOrange:
                                this.BackgroundImage = Properties.Resources.backgroundButtonClicked1;
                                break;
                            case buttonStyles.StyleBlue:
                                this.BackgroundImage = Properties.Resources.backgroundButtonClicked2;
                                break;
                            case buttonStyles.StyleGreen:
                                this.BackgroundImage = Properties.Resources.backgroundButtonClicked3;
                                break;
                            case buttonStyles.StyleRed:
                                this.BackgroundImage = Properties.Resources.backgroundButtonClicked4;
                                break;
                        }
                    }
                    else
                    {
                        try
                        {
                            this.BackgroundImage = imageClicked;
                        }
                        catch
                        {
                            switch (buttonStyle)
                            {
                                case buttonStyles.StyleOrange:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonClicked1;
                                    break;
                                case buttonStyles.StyleBlue:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonClicked2;
                                    break;
                                case buttonStyles.StyleGreen:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonClicked3;
                                    break;
                                case buttonStyles.StyleRed:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonClicked4;
                                    break;
                            }
                        }
                    }
                    
                }                
            }
        }

        private void ZUButton_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                if (oStyleType == styleType.Native)
                {
                    switch (buttonStyle)
                    {
                        case buttonStyles.StyleOrange:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover1;
                            break;
                        case buttonStyles.StyleBlue:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover2;
                            break;
                        case buttonStyles.StyleGreen:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover3;
                            break;
                        case buttonStyles.StyleRed:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover4;
                            break;
                    }
                }
                else
                {
                    try
                    {
                        this.BackgroundImage = imageHover;
                    }
                    catch
                    {
                        switch (buttonStyle)
                        {
                            case buttonStyles.StyleOrange:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover1;
                                break;
                            case buttonStyles.StyleBlue:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover2;
                                break;
                            case buttonStyles.StyleGreen:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover3;
                                break;
                            case buttonStyles.StyleRed:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover4;
                                break;
                        }
                    }
                }
            }
        }

        private void ZUButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Enabled == true)
            {
                if (oStyleType == styleType.Native)
                {
                    switch (buttonStyle)
                    {
                        case buttonStyles.StyleOrange:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover1;
                            break;
                        case buttonStyles.StyleBlue:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover2;
                            break;
                        case buttonStyles.StyleGreen:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover3;
                            break;
                        case buttonStyles.StyleRed:
                            this.BackgroundImage = Properties.Resources.backgroundButtonHover4;
                            break;
                    }
                }
                else
                {
                    try
                    {
                        this.BackgroundImage = imageHover;
                    }
                    catch
                    {
                        switch (buttonStyle)
                        {
                            case buttonStyles.StyleOrange:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover1;
                                break;
                            case buttonStyles.StyleBlue:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover2;
                                break;
                            case buttonStyles.StyleGreen:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover3;
                                break;
                            case buttonStyles.StyleRed:
                                this.BackgroundImage = Properties.Resources.backgroundButtonHover4;
                                break;
                        }
                    }
                }
            }
        }

        private void ZUButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                if (oStyleType == styleType.Native)
                {
                    switch (buttonStyle)
                    {
                        case buttonStyles.StyleOrange:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                            break;
                        case buttonStyles.StyleBlue:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                            break;
                        case buttonStyles.StyleGreen:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                            break;
                        case buttonStyles.StyleRed:
                            this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                            break;
                    }
                }
                else
                {
                    try
                    {
                        this.BackgroundImage = imageNormal;
                    }
                    catch
                    {
                        switch (buttonStyle)
                        {
                            case buttonStyles.StyleOrange:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                                break;
                            case buttonStyles.StyleBlue:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                                break;
                            case buttonStyles.StyleGreen:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                                break;
                            case buttonStyles.StyleRed:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                                break;
                        }
                    }
                }
            }
        }

        private void ZUButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Enabled == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (oStyleType == styleType.Native)
                    {
                        switch (buttonStyle)
                        {
                            case buttonStyles.StyleOrange:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                                break;
                            case buttonStyles.StyleBlue:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                                break;
                            case buttonStyles.StyleGreen:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                                break;
                            case buttonStyles.StyleRed:
                                this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                                break;
                        }
                    }
                    else
                    {
                        try
                        {
                            this.BackgroundImage = imageNormal;
                        }
                        catch
                        {
                            switch (buttonStyle)
                            {
                                case buttonStyles.StyleOrange:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonNormal1;
                                    break;
                                case buttonStyles.StyleBlue:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonNormal2;
                                    break;
                                case buttonStyles.StyleGreen:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonNormal3;
                                    break;
                                case buttonStyles.StyleRed:
                                    this.BackgroundImage = Properties.Resources.backgroundButtonNormal4;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
