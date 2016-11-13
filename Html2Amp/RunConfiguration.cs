using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using AngleSharp;
using AngleSharp.Parser.Html;

namespace Html2Amp
{
	// Consider using GetConfigurationValueCore() method for getting configuration values instead of
	// using generic method GetConfigurationValue<T>(). The reason is that the generic method uses Convert.ChangeType()
	// in order to perform casting to the actul type of T.
	public class RunConfiguration : DynamicObject
	{
		const string IFramesPlaceholderValue = "<span>This part of the page will be loaded later.</span>";

		private readonly Dictionary<string, object> configuration = new Dictionary<string, object>();

		private string relativeUrlsHost;
		private bool shouldDownloadImages;

		public const string Html2AmpConfigurationKeyPrefix = "Html2Amp:";

		/// <summary>
		/// Gets or sets the host used for resolving relative URLs.
		/// </summary>
		/// <example>http://localhost</example>
		/// <example>https://mydomain.com</example>
		/// <example>mydomain.com</example>
		/// <example>mydomain.com/blogs</example>
		public string RelativeUrlsHost
		{
			get { return (string)this.GetConfigurationValueCore("RelativeUrlsHost", relativeUrlsHost); }
			set { relativeUrlsHost = value; }
		}

		/// <summary>
		/// Gets or sets a flag used to determine shoud to download images. Downloading images
		/// is used to set width and/or height of an image (if they aren't specified) in order to 
		/// present the image responsively.
		/// </summary>
		public bool ShouldDownloadImages
		{
			get { return (bool)this.GetConfigurationValueCore("ShouldDownloadImages", shouldDownloadImages); }
			set { this.shouldDownloadImages = value; }
		}

		/// <summary>
		/// Gets or sets the element used as placeholder for iframes.
		/// By default, the value is: <span>This part of the page will be loaded later.</span>
		/// </summary>
		/// <example><p class="custom-class">This source will be available soon.</p></example>
		public string IFramesPlaceholder { get; set; }

		public RunConfiguration()
		{
			this.ShouldDownloadImages = true;
			this.IFramesPlaceholder = IFramesPlaceholderValue;

			this.InitializeApplicationConfigValues();
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = this.GetConfigurationValueCore(binder.Name, null);

			return result == null ? false : true;
		}

		public T GetConfigurationValue<T>(string key, T defaultValue = default(T))
		{
			object value = this.GetConfigurationValueCore(key, defaultValue);
			return (T)Convert.ChangeType(value, typeof(T));
		}

		protected virtual object GetConfigurationValueCore(string key, object defaultValue)
		{
			object value = null;
			if (!this.configuration.TryGetValue(key, out value))
			{
				value = defaultValue;
			}

			return value;
		}

		private void InitializeApplicationConfigValues()
		{
			foreach (string key in ConfigurationManager.AppSettings.AllKeys)
			{
				var isHtml2AmpConfiguration = key.IndexOf(Html2AmpConfigurationKeyPrefix, StringComparison.Ordinal);
				if (isHtml2AmpConfiguration == 0)
				{
					var configurationKey = key.Substring(Html2AmpConfigurationKeyPrefix.Length);
					this.configuration[configurationKey] = ConfigurationManager.AppSettings[key];
				}
			}
		}
	}
}