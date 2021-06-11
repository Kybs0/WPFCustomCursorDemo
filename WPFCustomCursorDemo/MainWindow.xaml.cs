using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Pen = System.Drawing.Pen;
using Rectangle = System.Drawing.Rectangle;

namespace WPFCustomCursorDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
    public MainWindow()
    {
        InitializeComponent();
        MouseEnter += (s, e) =>
        {
            ShowMouseCursor(e);
        };
        MouseMove += (s, e) =>
        {
            ShowMouseCursor(e);
        };
        StylusMove += (s, e) =>
        {
            ShowNoneCursor();
        };
    }

    private void ShowNoneCursor()
    {
        if (Cursor == Cursors.None)
        {
            return;
        }
        Cursor = Cursors.None;
        Mouse.UpdateCursor();
    }
    private void ShowMouseCursor(MouseEventArgs e)
    {
        if (e.StylusDevice != null && e.StylusDevice.Id > -1)
        {
            return;
        }
        if (Cursor == GetFillCursor())
        {
            return;
        }
        Cursor = GetFillCursor();
        Mouse.UpdateCursor();
    }
    private Cursor _fillCursor = null;
    private Cursor GetFillCursor()
    {
        return _fillCursor ?? (_fillCursor = CursorHelper.CreateFillCursor());
    }
    }
}
