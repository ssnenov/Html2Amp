using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Html2Amp.Sanitization;
using Html2Amp.Sanitization.Implementation;
using System.Collections.Generic;

namespace Html2Amp
{
	public class HtmlToAmpConverter
	{
		private HashSet<ISanitizer> sanitizers { get; set; }

		private RunConfiguration configuration;

		private volatile bool isInitialized = false;

		private object initializationLock = new object();

		public HtmlToAmpConverter()
		{
			this.configuration = new RunConfiguration();
			this.sanitizers = new HashSet<ISanitizer>();

			// Initialize a default collection of sanitizers
			this.sanitizers.Add(new ImageSanitizer());
			this.sanitizers.Add(new TargetAttributeSanitizer());
			this.sanitizers.Add(new HrefJavaScriptSanitizer());
			this.sanitizers.Add(new StyleAttributeSanitizer());
            this.sanitizers.Add(new XmlAttributeSanitizer());
            this.sanitizers.Add(new JavaScriptRelatedAttributeSanitizer());
            this.sanitizers.Add(new YouTubeVideoSanitizer());
            this.sanitizers.Add(new IFrameSanitizer());
		}

		public HtmlToAmpConverter WithSanitizers(HashSet<ISanitizer> sanitizers)
		{
			this.sanitizers = sanitizers;

			return this;
		}

		public HtmlToAmpConverter WithConfiguration(RunConfiguration configuration)
		{
			this.configuration = configuration;

			return this;
		}

		public string ConvertFromHtml(string htmlSource)
		{
			if (string.IsNullOrEmpty(htmlSource))
			{
				return string.Empty;
			}

			IHtmlDocument document = new HtmlParser().Parse(htmlSource);
			IHtmlHtmlElement htmlElement = (IHtmlHtmlElement)document.DocumentElement;

			this.EnsureInitilized();

			ConvertFromHtmlElement(document, document.Body);

			return document.Body.InnerHtml;
		}

		private void EnsureInitilized()
		{
			if (!isInitialized)
			{
				lock (this.initializationLock)
				{
					if (!isInitialized)
					{
						this.Initialize();
						this.isInitialized = true;
					}
				}
			}
		}

		private void Initialize()
		{
			foreach (var sanitizer in this.sanitizers)
			{
				sanitizer.Configure(this.configuration);
			}
		}

		private void ConvertFromHtmlElement(IDocument document, IElement htmlElement)
		{
			foreach (var sanitizer in sanitizers)
			{
				if (sanitizer.CanSanitize(htmlElement))
				{
					htmlElement = sanitizer.Sanitize(document, htmlElement);
				}
			}

			foreach (var childElement in htmlElement.Children)
			{
				ConvertFromHtmlElement(document, childElement);
			}
		}
	}
}