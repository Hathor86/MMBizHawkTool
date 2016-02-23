using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MMBizHawkTool.Controls.Components
{
	/// <summary>
	/// This class holds logic for a <see cref="TextBox"/> that can have a mask
	/// </summary>
	public class MaskedTextBox:TextBox
	{
		#region Fields

		private static readonly DependencyProperty MaskProperty = DependencyProperty.Register("Mask", typeof(string), typeof(MaskedTextBox), new PropertyMetadata(string.Empty, OnMaskChange));

		private MaskedTextProvider maskProvider;
		private bool isInsertKeyEnable = false;
		private bool isTextOK = true;

		#endregion

		#region cTor(s)
		#endregion

		#region Methods

		/// <summary>
		/// Raised when the mask is changed
		/// </summary>
		/// <param name="source">Control who raised the event</param>
		/// <param name="e">Event Argument (containts data)</param>
		private static void OnMaskChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			((MaskedTextBox)source).maskProvider = new MaskedTextProvider((string)e.NewValue);
			((MaskedTextBox)source).Text = ((MaskedTextBox)source).maskProvider.ToDisplayString();
		}

		protected override void OnGotFocus(RoutedEventArgs e)
		{
			base.OnGotFocus(e);
			if(!isInsertKeyEnable)
			{
				Presskey(Key.Insert);
				isInsertKeyEnable = true;
			}
		}

		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			if(SelectionLength > 1)
			{
				SelectionLength = 0;
				e.Handled = true;
			}
			if(e.Key == Key.Insert
				|| e.Key == Key.Delete
				|| e.Key == Key.Back
				|| e.Key == Key.Space)
			{
				e.Handled = true;
			}
			base.OnPreviewKeyDown(e);
		}

		protected override void OnPreviewTextInput(TextCompositionEventArgs e)
		{
			isTextOK = maskProvider.VerifyString(e.Text);
			base.OnPreviewTextInput(e);
		}

		protected override void OnTextInput(TextCompositionEventArgs e)
		{			
			if (isTextOK)
			{
				base.OnTextInput(e);
				while (!maskProvider.IsEditPosition(CaretIndex) && CaretIndex < maskProvider.Length)
				{
					CaretIndex++;
				}
			}
			else
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// Simulate the specific <see cref="Key"/> press by code
		/// </summary>
		/// <param name="key">Key to Press</param>
		private void Presskey(Key key)
		{
			KeyEventArgs keyArg = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key);
			keyArg.RoutedEvent = KeyDownEvent;
			InputManager.Current.ProcessInput(keyArg);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets Textbox's mask
		/// </summary>
		public string Mask
		{
			get
			{
				return ((MaskedTextProvider)GetValue(MaskProperty)).Mask;
			}
			set
			{
				SetValue(MaskProperty, value);
			}
		}

		#endregion
	}
}
