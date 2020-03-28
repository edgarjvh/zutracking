using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace ZUControls
{
    public class ZUDatePicker : DateTimePicker
    {
        public ZUDatePicker() : base()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dd/MM/yyyy";
            DateTime now = DateTime.Now;
            this.Value = new DateTime(now.Year, now.Month, 1);
            this.Height = 21;
            this.ShowUpDown = false;
            this.MinDate = DateTime.Parse("01/01/2011");
            this.MaxDate = now;          
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x204e)
            {
                NMHDR hdr = (NMHDR)m.GetLParam(typeof(NMHDR));
                if (hdr.code == -759)
                {
                    NMDATETIMECHANGE dt = (NMDATETIMECHANGE)m.GetLParam(typeof(NMDATETIMECHANGE));
                    this.Value = new DateTime(dt.st.wYear, dt.st.wMonth, 1);
                    return;
                }
            }

            base.WndProc(ref m);            
        }

        [StructLayout(LayoutKind.Sequential)]
	
        private struct NMHDR
	    {
		    public IntPtr hWnd;
		    public IntPtr id;
		    public int code;
	    }

	    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	    private class NMDATETIMECHANGE
	    {
		    public NMHDR nmhdr;
		    public int dwFlags;
		    public SYSTEMTIME st;
	    }

	    [StructLayout(LayoutKind.Sequential)]
	    private class SYSTEMTIME
	    {
		    public short wYear;
		    public short wMonth;
		    public short wDayOfWeek;
		    public short wDay;
		    public short wHour;
		    public short wMinute;
		    public short wSecond;
		    public short wMilliseconds;
	    }        
    }
}
