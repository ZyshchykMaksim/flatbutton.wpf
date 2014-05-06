using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FlatUIWPF
{
	public class FlatButton : Button
	{
		private Storyboard _mouseOver;
		private Storyboard _mousePress;

		private bool _isHover = true;
		private bool _isPress = true;

		public FlatButton()
		{
			this.MouseEnter += OnMouseEnter;
			this.MouseLeave += OnMouseLeave;
			this.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
			this.PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;
		}

		private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			if (_isPress && _mousePress != null)
			{
				_mousePress.Stop(this);
			}
		}

		private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			if (_isPress && _mousePress != null)
			{
				_mousePress.Begin(this, Template, true);
			}
		}

		private void OnMouseLeave(object sender, MouseEventArgs mouseEventArgs)
		{
			if (_isHover && _mouseOver != null)
			{
				_mouseOver.Stop(this);
			}
		}

		private void OnMouseEnter(object sender, MouseEventArgs mouseEventArgs)
		{
			if (_isHover & _mouseOver != null)
			{
				_mouseOver.Begin(this, Template, true);
			}
		}

		public static readonly DependencyProperty AwesomeIconProperty = DependencyProperty.Register("AwesomeIcon", typeof(AwesomeIcon), typeof(FlatButton), new UIPropertyMetadata(AwesomeIcon.none));

		public AwesomeIcon AwesomeIcon
		{
			get { return (AwesomeIcon)GetValue(AwesomeIconProperty); }
			set { SetValue(AwesomeIconProperty, value); }
		}

        public static readonly DependencyProperty IconColorProperty = DependencyProperty.Register("IconColor", typeof(Brush), typeof(FlatButton), new UIPropertyMetadata(Brushes.Black));

        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

		public static readonly DependencyProperty BorderRadiusProperty = DependencyProperty.Register("BorderRadius", typeof(double), typeof(FlatButton), new UIPropertyMetadata(0.0));

		public double BorderRadius
		{
			get { return (double)GetValue(BorderRadiusProperty); }
			set { SetValue(BorderRadiusProperty, value); }
		}

		public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush), typeof(FlatButton), new UIPropertyMetadata(Brushes.Black));

		public Brush BorderColor
		{
			get { return (Brush)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public bool IsHover
		{
			get { return _isHover; }
			set { _isHover = value; }
		}

		public bool IsPress
		{
			get { return _isPress; }
			set { _isPress = value; }
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			_mouseOver = this.Template.Resources["MouseOver"] as Storyboard;
			_mousePress = this.Template.Resources["Press"] as Storyboard;
		}
	}
}
