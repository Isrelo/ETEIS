using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Xml;
using System.Windows.Markup;
using System.Diagnostics;
using DragAndDrop.Models;

namespace DragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DragAndDropManager DragAndDropManager_m;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize Drag and Drop
            DragAndDropManager_m = new DragAndDropManager(DragablePiece_dp);
            this.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(DragAndDropManager_m.DragDrop_PreviewMouseMove);
            this.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(DragAndDropManager_m.DragDrop_PreviewMouseUp);
        }

        private void LogMouseCords(Point new_location_p)
        {
            MouseCordX_txtb.Text = DragAndDropManager_m.CurrentPosition.X.ToString();
            MouseCordY_txtb.Text = DragAndDropManager_m.CurrentPosition.Y.ToString();
        }

        private void SquareDropTarget_Drop(object sender, DragEventArgs e)
        {
            if (DragAndDropManager_m.IsDraggingObject)
            {
                SquareDropTarget.Fill = Brushes.Red;

                DragAndDropManager_m.IsDraggingObject = false;
                DragAndDropManager_m.RemoveAdorner();
            }
        }
    }
}
