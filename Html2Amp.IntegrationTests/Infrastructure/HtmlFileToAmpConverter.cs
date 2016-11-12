namespace Html2Amp.IntegrationTests.Infrastructure
{
	public static class HtmlTestFileToAmpConverter
	{
		public static string ConvertToString(string testName)
		{
			return Convert(testName).AmpHtml;
		}

		public static ConvertionResult Convert(string testName)
		{
			var html = TestDataProvider.GetInFile(testName);

			return new HtmlToAmpConverter().ConvertFromHtml(html);
		}

		public static string ConvertToString(RunConfiguration configuration, string testName)
		{
			return Convert(configuration, testName).AmpHtml;
		}

		public static ConvertionResult Convert(RunConfiguration configuration, string testName)
		{
			var html = TestDataProvider.GetInFile(testName);

			return new HtmlToAmpConverter()
				.WithConfiguration(configuration)
				.ConvertFromHtml(html);
		}
	}
}