using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Documents;

namespace DragAndDrop
{
    public class ControlAdorner : Adorner
    {
        double LeftOffset_m;
        double TopOffset_m;
        Rectangle Child_m;

        public double LeftOffset
        {
            get { return LeftOffset_m; }
            set
            {
                LeftOffset_m = value;
                UpdatePosition();
            }
        }

        public double TopOffset
        {
            get { return TopOffset_m; }
            set
            {
                TopOffset_m = value;
                UpdatePosition();
            }
        }

        public ControlAdorner(UIElement adorned_element_p) 
            : base(adorned_element_p)
        {
            VisualBrush visual_brush = new VisualBrush(adorned_element_p);
            visual_brush.Opacity = .7;

            Child_m = new Rectangle();
            Child_m.Width = adorned_element_p.RenderSize.Width;
            Child_m.Height = adorned_element_p.RenderSize.Height;
            Child_m.Fill = visual_brush;
        }

        private void UpdatePosition()
        {
            AdornerLayer adorner_layer = this.Parent as AdornerLayer;
            if(adorner_layer != null)
            {
                adorner_layer.Update(AdornedElement);
            }
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup general_transform_group = new GeneralTransformGroup();
            general_transform_group.Children.Add(base.GetDesiredTransform(transform));
            general_transform_group.Children.Add(new TranslateTransform(LeftOffset, TopOffset));
            return general_transform_group;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Child_m.Measure(constraint);
            return Child_m.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Child_m.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return Child_m;
        }

        protected override int VisualChildrenCount => 1;
    }
}
