using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flip.Web.Routing.Tests
{
	[TestClass]
	public class UrlBuilderTests
	{
		[TestMethod]
		public void CanBuildEmptyUrl()
		{
			AssertAreEqual("", BuildUrl(""));
		}

		[TestMethod]
		public void CanBuildEmptyJavascriptFunction()
		{
			AssertAreEqual("function(){return '';}", BuildJavascriptFunction(""));
		}

		[TestMethod]
		public void CanBuildUrlNotInNeedOfExpansion()
		{
			AssertAreEqual("/Stockholm/Products", BuildUrl("/Stockholm/Products"));
		}

		[TestMethod]
		public void CanBuildFullyExpandedUrl()
		{
			AssertAreEqual("/Stockholm/Products", BuildUrl("/{store}/Products"));
		}

		[TestMethod]
		public void CanBuildJavascriptFunctionNotInNeedOfExpansion()
		{
			AssertAreEqual("function(){return '/Stockholm/Products';}", BuildJavascriptFunction("/Stockholm/Products"));
		}

		[TestMethod]
		public void CanBuildFullExpandedJavascriptFunction()
		{
			AssertAreEqual("function(){return '/Stockholm/Products';}", BuildJavascriptFunction("/{store}/Products"));
		}

		private void AssertAreEqual(string expected, string actual)
		{
			string normalizedExpected = Regex.Replace(actual, @"\s", "");
			string normalizedActual = Regex.Replace(actual, @"\s", "");
			Assert.AreEqual(normalizedExpected, normalizedActual);
		}

		private string BuildUrl(string url)
		{
			return new UrlBuilder(new UrlComposer(), url).Build(Values);
		}

		private string BuildJavascriptFunction(string url)
		{
			return new UrlBuilder(new JavascriptFunctionUrlComposer(), url).Build(Values);
		}

		private static readonly Dictionary<string, object> Values = new Dictionary<string, object>
			                                                            {
				                                                            {"store", "Stockholm"}
			                                                            };
	}
}