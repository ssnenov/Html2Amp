**Html2Amp** is a simple converter from HTML code to "AMP Html".

# Getting started #
## 1. Install Html2Amp##
With first official release Html2Amp will be available as a nuget package. Until then you can reference Html2Amp.dll to your project.

## 2. Writing code ##
### 2.1 Simple usage ###
```charp
var converter = new HtmlToAmpConverter();
string ampHtml = converter.ConvertFromHtml("<h1>Getting started</h1>");
```

### 2.2 Configuration ###
Using ``WithConfiguration(RunConfiguration)`` method you can configure the converter with specified settings in ``RunConfiguration`` object. The following example shows how to configure the converter to resolve relative URLs to your website:
```csharp
var htmlToAmpConverter = new HtmlToAmpConverter();
htmlToAmpConverter.WithConfiguration(
	new RunConfiguration
	{
		RelativeUrlsHost = "http://mywebsite.com"
	});
```

### 2.3 Sanitizers ###
```csharp
var htmlToAmpConverter = new HtmlToAmpConverter();
htmlToAmpConverter.WithSanitizers(
	new HashSet<Sanitization.ISanitizer>
	{
		new ImageSanitizer()
	});
```

### 2.4 Fluent ###
The library is designed to be user friendly, that's why it supports fluent configuration:
```csharp
new HtmlToAmpConverter().WithSanitizers(...).WithConfiguration(...)
```
### Roadmap: ###
- Implement handling of relative URLs in ImageSanitizer
- Href should not start with javascript: - so it should be removed.Read more about on: [https://www.ampproject.org/docs/reference/spec.html#ancr](Link URL)
- Remove all attributes starting with prefix "on" - Attribute names starting with on (such as onclick or onmouseover)
	are disallowed in AMP HTML. The attribute with the literal name on (no suffix) is allowed.
- Remove xml attributes - XML-related attributes, such as xmlns, xml:lang, xml:base, and xml:space are disallowed in AMP HTML.
- Implement iframes sanitizer
- Implement media sanitizers
	- amp-youtube
	- amp-audio
- Implement Socials media sanitizers
	- amp-facebook
	- amp-twitter
	- amp-social-share
	- Future version

#### Next versions ####
- Implement media sanitizers
	- amp-soundcloud
	- amp-dailymotion
	- amp-vine
	- amp-jwplayer
	- amp-kaltura-player
	- amp-vimeo
- Implement Socials media sanitizers
	- amp-instagram
	- amp-pinterest

#### Contributing ####
Todo

#### FAQ ####
Todo

#### Resources ####
[https://www.ampproject.org/docs/reference/spec.html#ancr](Link URL)

[http://searchengineland.com/get-started-accelerated-mobile-pages-amp-240688](Link URL)

[https://www.ampproject.org/docs/reference/extended.html](Link URL)