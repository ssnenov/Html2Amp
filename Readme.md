**Html2Amp** is a simple converter from HTML code to "AMP Html".

### Build status ###
| Branch | Build | Nightly Build |
|:---|------:|--------:|
Master | [![Build status](https://ci.appveyor.com/api/projects/status/y7lhe4iuu19juwjp/branch/master?svg=true)](https://ci.appveyor.com/project/SimeonNenov/html2amp/branch/master) | TODO
Development | TODO | TODO

# Getting started #
## 1. Install Html2Amp##
With the first official release Html2Amp will be available as a nuget package. Until then you can reference Html2Amp.dll to your project.

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
Html2Amp is built using "HTML sanitizers" which are the main extensibility point. You can add your custom sanitizers or extend the existing ones. Using ``WithSanitizers(HashSet<ISanitizer>)`` method you can configure the collection of sanitizers which will be used for the conversion:
```csharp
var htmlToAmpConverter = new HtmlToAmpConverter();
htmlToAmpConverter.WithSanitizers(
	new HashSet<ISanitizer>
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

#### Next versions ####
- Implement Html helper for asp.net mvc framework
- Exporting all third party dependencies used after conversion. Also Html helper should be implemented to add dependencies into "scripts" section. Examples:
	<script async custom-element="amp-facebook" src="https://cdn.ampproject.org/v0/amp-facebook-0.1.js"></script>
	<script async custom-element="amp-youtube" src="https://cdn.ampproject.org/v0/amp-youtube-0.1.js"></script>
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
- Minifiy "AMP HTML"

#### Contributing ####
Todo

#### FAQ ####
Todo

#### Resources ####
[https://www.ampproject.org/docs/get_started/technical_overview.html](Link URL)

[https://www.ampproject.org/docs/reference/spec.html#ancr](Link URL)

[http://searchengineland.com/get-started-accelerated-mobile-pages-amp-240688](Link URL)

[https://www.ampproject.org/docs/reference/extended.html](Link URL)

[https://github.com/ampproject/amphtml/blob/master/spec/amp-html-format.md](Link URL)