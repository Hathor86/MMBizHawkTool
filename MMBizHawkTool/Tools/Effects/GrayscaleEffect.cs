/*
	MMBizHawkTool, a BizHawk plugin specific to The Legend of Zelda: Majora's Mask
    Copyright (C) 2015  François Guiot

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License along
    with this program; if not, write to the Free Software Foundation, Inc.,
    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/
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
	public class GrayscaleEffect : ShaderEffect
	{
		private static PixelShader _pixelShader = new PixelShader() { UriSource = new Uri(@"pack://application:,,,/MMBizHawkTool;component/Tools/Effects/GrayscaleEffect.ps") };
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0);
		public static readonly DependencyProperty DesaturationFactorProperty = DependencyProperty.Register("DesaturationFactor", typeof(double), typeof(GrayscaleEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), CoerceDesaturationFactor));

		public GrayscaleEffect()
		{
			PixelShader = _pixelShader;

			UpdateShaderValue(InputProperty);
			UpdateShaderValue(DesaturationFactorProperty);
		}
		
		public Brush Input
		{
			get { return (Brush)GetValue(InputProperty); }
			set { SetValue(InputProperty, value); }
		}

		
		public double DesaturationFactor
		{
			get { return (double)GetValue(DesaturationFactorProperty); }
			set { SetValue(DesaturationFactorProperty, value); }
		}

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
	}
}