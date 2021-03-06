﻿//
// Bindings for SKSurface
//
// Author:
//   Miguel de Icaza
//
// Copyright 2016 Xamarin Inc
//

using System;

namespace SkiaSharp
{
	public class SKSurface : SKObject
	{
		public static SKSurface Create (int width, int height, SKColorType colorType, SKAlphaType alphaType) => Create (new SKImageInfo (width, height, colorType, alphaType));
		public static SKSurface Create (int width, int height, SKColorType colorType, SKAlphaType alphaType, SKSurfaceProps props) => Create (new SKImageInfo (width, height, colorType, alphaType), props);
		public static SKSurface Create (int width, int height, SKColorType colorType, SKAlphaType alphaType, IntPtr pixels, int rowBytes) => Create (new SKImageInfo (width, height, colorType, alphaType), pixels, rowBytes);
		public static SKSurface Create (int width, int height, SKColorType colorType, SKAlphaType alphaType, IntPtr pixels, int rowBytes, SKSurfaceProps props) => Create (new SKImageInfo (width, height, colorType, alphaType), pixels, rowBytes, props);

		[Preserve]
		internal SKSurface (IntPtr h)
			: base (h)
		{
		}
		
		public static SKSurface Create (SKImageInfo info)
		{
			return GetObject<SKSurface> (SkiaApi.sk_surface_new_raster (ref info, IntPtr.Zero));
		}

		public static SKSurface Create (SKImageInfo info, SKSurfaceProps props)
		{
			return GetObject<SKSurface> (SkiaApi.sk_surface_new_raster (ref info, ref props));
		}

		public static SKSurface Create (SKImageInfo info, IntPtr pixels, int rowBytes)
		{
			return GetObject<SKSurface> (SkiaApi.sk_surface_new_raster_direct (ref info, pixels, (IntPtr)rowBytes, IntPtr.Zero));
		}

		public static SKSurface Create (SKImageInfo info, IntPtr pixels, int rowBytes, SKSurfaceProps props)
		{
			return GetObject<SKSurface> (SkiaApi.sk_surface_new_raster_direct (ref info, pixels, (IntPtr)rowBytes, ref props));
		}
		
		protected override void Dispose (bool disposing)
		{
			if (Handle != IntPtr.Zero) {
				SkiaApi.sk_surface_unref (Handle);
			}

			base.Dispose (disposing);
		}
		
		public SKCanvas Canvas {
			get {
				return GetObject<SKCanvas> (SkiaApi.sk_surface_get_canvas (Handle));
			}
		}

		public SKImage Snapshot ()
		{
			return GetObject<SKImage> (SkiaApi.sk_surface_new_image_snapshot (Handle));
		}
	}
}

