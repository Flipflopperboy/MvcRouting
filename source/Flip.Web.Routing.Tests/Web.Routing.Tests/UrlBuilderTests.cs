using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flip.Web.Routing.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void CanBuildEmptyUrl()
		{
			Assert.AreEqual("", Build(""));
		}

		[TestMethod]
		public void CanBuildExpandedUrl()
		{
			Assert.AreEqual("/Stockholm/Products", Build("/{store}/Products"));
		}

		private string Build(string url)
		{
			return new UrlBuilder(new UrlComposer(), url).Build(Values);
		}

		private static readonly Dictionary<string, object> Values = new Dictionary<string, object>
			                                                            {
				                                                            {"store", "Stockholm"}
			                                                            };
	}
}