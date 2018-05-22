using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Input;
using System.Windows.Documents;

namespace DragAndDrop
{
    public class DragAndDropManager
    {
        // Variables
        private AdornerLayer AdornerLayer_m;
        private ControlAdorner ControlAdorner_m;
        private UIElement ItemToDrag_m;

        // Properties
        public bool IsDraggingObject { get; set; }
        public Point StartingPosition { get; set; }
        public Point CurrentPosition { get; set; }

        public DragAndDropManager(UIElement item_to_drag_p)
        {
            ItemToDrag_m = item_to_drag_p;

            // Wire up the start drag drop mouse down event;
            item_to_drag_p.GiveFeedback += DragDrop_GiveFeedback;
            item_to_drag_p.PreviewMouseDown += DragDrop_PreviewMouseDown;
        }

        private void DragDrop_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            CurrentPosition = Utilites.Win32GetCursorPos();

            if (ControlAdorner_m != null)
            {
                ControlAdorner_m.LeftOffset = CurrentPosition.X - StartingPosition.X;
                ControlAdorner_m.TopOffset = CurrentPosition.Y - StartingPosition.Y;
            }
        }

        private void DragDrop_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the starting position of the mouse.
            StartingPosition = Utilites.Win32GetCursorPos();

            if (ControlAdorner_m == null)
            {
                ControlAdorner_m = new ControlAdorner(ItemToDrag_m);
                ControlAdorner_m.LeftOffset = StartingPosition.X;
                ControlAdorner_m.TopOffset = StartingPosition.Y;

                AdornerLayer_m = AdornerLayer.GetAdornerLayer(ItemToDrag_m);
                AdornerLayer_m.Add(ControlAdorner_m);
            }
        }

        public void DragDrop_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            IsDraggingObject = IsUserDraggingObject(sender, e);
            if(IsDraggingObject)
            {
                DependencyObject dragSource = ItemToDrag_m;
                var data = new DataObject(this);
                DragDrop.DoDragDrop(dragSource, data, DragDropEffects.Copy);
            }
        }

        public void DragDrop_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDraggingObject = false;
            RemoveAdorner();
        }

        public void RemoveAdorner()
        {
            if (ControlAdorner_m != null)
            {
                AdornerLayer.GetAdornerLayer(ControlAdorner_m.AdornedElement).Remove(ControlAdorner_m);
                ControlAdorner_m = null;
            }
        }

        private bool IsUserDraggingObject(object sender, MouseEventArgs e)
        {
            CurrentPosition = Utilites.Win32GetCursorPos();

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (Math.Abs(CurrentPosition.X - StartingPosition.X) > SystemParameters.MinimumHorizontalDragDistance || 
                    Math.Abs(CurrentPosition.Y - StartingPosition.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    if (ControlAdorner_m != null)
                    {
                        ControlAdorner_m.LeftOffset = CurrentPosition.X - StartingPosition.X;
                        ControlAdorner_m.TopOffset = CurrentPosition.Y - StartingPosition.Y;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
