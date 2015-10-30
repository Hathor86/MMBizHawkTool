using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace MMBizHawkTool.Tools.Effects
{
	/// <summary>
	/// A shader effect that convert a brush into a grayscale
	/// Desaturation can be specified
	/// </summary>
	public class GrayscaleEffect : ShaderEffect
	{
		#region Fields

		private static PixelShader _pixelShader = new PixelShader() { UriSource = new Uri(@"pack://application:,,,/MMBizHawkTool;component/Tools/Effects/GrayscaleEffect.ps") };
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0);
		public static readonly DependencyProperty DesaturationFactorProperty = DependencyProperty.Register("DesaturationFactor", typeof(double), typeof(GrayscaleEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), CoerceDesaturationFactor));

		#endregion

		#region cTor(s)

		/// <summary>
		/// A shader effect that convert a brush into a grayscale
		/// Desaturation can be specified
		/// </summary>
		public GrayscaleEffect()
		{
			PixelShader = _pixelShader;

			UpdateShaderValue(InputProperty);
			UpdateShaderValue(DesaturationFactorProperty);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Parse the desaturation factor propery and make sure the value is correct
		/// </summary>
		/// <param name="d">The dependency property</param>
		/// <param name="value">Value set to the property</param>
		/// <returns>New value for desaturation factor if between 0 and 1, otherwise current value</returns>
		private static object CoerceDesaturationFactor(DependencyObject d, object value)
		{
			GrayscaleEffect effect = (GrayscaleEffect)d;
			double newFactor = (double)value;

			if (newFactor < 0.0 || newFactor > 1.0)
			{
				return effect.DesaturationFactor;
			}

			return newFactor;
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
		/// Get or set the desaturation factor
		/// </summary>
		public double DesaturationFactor
		{
			get
			{
				return (double)GetValue(DesaturationFactorProperty);
			}
			set
			{
				SetValue(DesaturationFactorProperty, value);
			}
		}

		#endregion
	}
}