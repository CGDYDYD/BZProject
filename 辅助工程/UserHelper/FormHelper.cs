using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace UserHelper
{
    public partial class FormHelper
    {
        /// <summary>
        /// 根据Text查找控件并返回完整路径
        /// </summary>
        public static string GetFullNameByText(Control container, string text, StringComparison comparison = StringComparison.Ordinal)
        {
            var control = FindControlByText(container, text, comparison);
            return GetFullName(control);
        }

        /// <summary>
        /// 对控件截图
        /// </summary>
        public static void PrintControl(Control ctl, string filepath)
        {
            Bitmap bmp = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bmp, ctl.ClientRectangle);
            bmp.Save(filepath);
        }

        /// <summary>
        /// 对屏幕截图
        /// </summary>
        public static bool PrintScreen(string path)
        {
            try
            {
                ImageFormat pictureFormat = ImageFormat.Jpeg;
                Image myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);
                Graphics g = Graphics.FromImage(myImage);
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                g.Save();
                myImage.Save(path, pictureFormat);
                return true;
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex);
                return false;
            }
        }
    }

    public partial class FormHelper
    {
        private static string GetFullName(Control control)
        {
            if (control == null)
            {
                return null;
            }

            var names = new Stack<string>();
            var current = control;

            while (current != null)
            {
                if (!string.IsNullOrEmpty(current.Name))
                {
                    names.Push(current.Name);
                }
                current = current.Parent;
            }

            return names.Count > 0 ? string.Join(".", names) : control.Name;
        }

        private static Control FindControlByText(Control container, string text, StringComparison comparison)
        {
            foreach (Control control in container.Controls)
            {
                if (control.Text != null && control.Text.Equals(text, comparison))
                {
                    return control;
                }

                if (control.HasChildren)
                {
                    var result = FindControlByText(control, text, comparison);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
    }
}