using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using ComboRox.Core.Utilities.SimpleGuard;
using Html2Amp.Models;
using System;
using System.Collections.Concurrent;

namespace Html2Amp
{
	public class RunContext
	{
		public RunConfiguration Configuration { get; private set; }

		public Uri RelativeUrlsHostAsUri { get; private set; }

		public IElement IFramesPlaceholderElement { get; private set; }

		internal ConcurrentDictionary<string, ImageSize> ImagesCache { get; private set; }

		public RunContext(RunConfiguration configuration)
		{
			Guard.Requires(configuration, "configuration").IsNotNull();

			this.Configuration = configuration;
			this.ImagesCache = new ConcurrentDictionary<string, ImageSize>(StringComparer.Ordinal);

			this.Initialize();
		}

		private void Initialize()
		{
			if (!string.IsNullOrEmpty(this.Configuration.RelativeUrlsHost))
			{
				this.RelativeUrlsHostAsUri = new Uri(this.Configuration.RelativeUrlsHost);
			}

			// TODO: Think if this part of code should be moved to HtmlToAmpConverter, Initialize method
			var parser = new HtmlParser(AngleSharp.Configuration.Default.WithCss());
			var document = parser.Parse(this.Configuration.IFramesPlaceholder);
			this.IFramesPlaceholderElement = document.Body.FirstElementChild;
		}
	}
}