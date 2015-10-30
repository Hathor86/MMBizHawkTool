using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;

namespace MMBizHawkTool.Tools.Effects
{
	/// <summary>
	/// A shader effect that can manipulate the hue, saturation and brightness of an input brush
	/// </summary>
	public class HSVEffect : ShaderEffect
	{
		#region Fields

		private static PixelShader _pixelShader = new PixelShader() { UriSource = new Uri(@"pack://application:,,,/MMBizHawkTool;component/Tools/Effects/HSVEffect.ps") };
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(HSVEffect), 0);
		public static readonly DependencyProperty HueProperty = DependencyProperty.Register("Hue", typeof(double), typeof(HSVEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), CoerceHue));
		public static readonly DependencyProperty BrightnessProperty = DependencyProperty.Register("BrightnessProperty", typeof(double), typeof(HSVEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(1), CoerceBrightness));
		public static readonly DependencyProperty SaturationProperty = DependencyProperty.Register("SaturationProperty", typeof(double), typeof(HSVEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(2), CoerceSaturation));
		public static readonly DependencyProperty ContrastProperty = DependencyProperty.Register("ContrastProperty", typeof(double), typeof(HSVEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(3), CoerceContrast));

		#endregion

		#region cTor(s)

		/// <summary>
		/// A shader effect that can manipulate the hue, saturation and brightness of an input brush
		/// </summary>
		public HSVEffect()
		{
			PixelShader = _pixelShader;

			UpdateShaderValue(InputProperty);
			UpdateShaderValue(HueProperty);
			UpdateShaderValue(BrightnessProperty);
			UpdateShaderValue(SaturationProperty);
			UpdateShaderValue(ContrastProperty);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Parse the hue propery and make sure the value is correct
		/// </summary>
		/// <param name="d">The dependency property</param>
		/// <param name="value">Value set to the property</param>
		/// <returns>New value for hue if between 0 and 360, otherwise current value</returns>
		private static object CoerceHue(DependencyObject d, object value)
		{
			HSVEffect effect = (HSVEffect)d;
			double newValue = (double)value;

			if(newValue < 0 || newValue > 360)
			{
				return effect.Hue;
			}
						
			return newValue;
		}

		/// <summary>
		/// Parse the brightness propery and make sure the value is correct
		/// </summary>
		/// <param name="d">The dependency property</param>
		/// <param name="value">Value set to the property</param>
		/// <returns>New value for brightness if between -100 and 100, otherwise current value</returns>
		private static object CoerceBrightness(DependencyObject d, object value)
		{
			HSVEffect effect = (HSVEffect)d;
			double newValue = (double)value;

			if (newValue < -100 || newValue > 100)
			{
				return effect.Brightness;
			}

			return newValue;
		}

		/// <summary>
		/// Parse the saturation propery and make sure the value is correct
		/// </summary>
		/// <param name="d">The dependency property</param>
		/// <param name="value">Value set to the property</param>
		/// <returns>New value for saturation if between 0 and 100, otherwise current value</returns>
		private static object CoerceSaturation(DependencyObject d, object value)
		{
			HSVEffect effect = (HSVEffect)d;
			double newValue = (double)value;

			if (newValue < 0 || newValue > 100)
			{
				return effect.Saturation;
			}

			return newValue;
		}

		/// <summary>
		/// Parse the saturation propery and make sure the value is correct
		/// </summary>
		/// <param name="d">The dependency property</param>
		/// <param name="value">Value set to the property</param>
		/// <returns>New value for saturation if between 0 and 100, otherwise current value</returns>
		private static object CoerceContrast(DependencyObject d, object value)
		{
			HSVEffect effect = (HSVEffect)d;
			double newValue = (double)value;

			if (newValue < -127 || newValue > 127)
			{
				return effect.Contrast;
			}

			return newValue;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get or set the input
		/// </summary>
		public Brush Input
		{
			get
			{
				return (Brush)GetValue(InputProperty);
			}
			set
			{
				SetValue(InputProperty, value);
			}
		}

		/// <summary>
		/// Get or set hue
		/// </summary>
		public double Hue
		{
			get
			{
				return (double)GetValue(HueProperty);
			}
			set
			{
				SetValue(HueProperty, value);
			}
		}

		/// <summary>
		/// Get or set brightness
		/// </summary>
		public double Brightness
		{
			get
			{
				return (double)GetValue(BrightnessProperty);
			}
			set
			{
				SetValue(BrightnessProperty, value);
			}
		}

		/// <summary>
		/// Get or set saturation
		/// </summary>
		public double Saturation
		{
			get
			{
				return (double)GetValue(SaturationProperty);
			}
			set
			{
				SetValue(SaturationProperty, value);
			}
		}

		/// <summary>
		/// Get or set Contrast
		/// </summary>
		public double Contrast
		{
			get
			{
				return (double)GetValue(ContrastProperty);
			}
			set
			{
				SetValue(ContrastProperty, value);
			}
		}

		#endregion
	}
}
