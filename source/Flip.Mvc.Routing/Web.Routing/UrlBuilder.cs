using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Routing;

namespace Flip.Web.Routing
{
	public sealed class UrlBuilder
	{
		public UrlBuilder(IUrlComposer composer, Route route)
			: this(composer, route.Url)
		{
		}

		public UrlBuilder(IUrlComposer composer, string url)
		{
			_url = url;
			_composer = composer;
		}

		public string Build()
		{
			return null;
		}

		public string Build(IDictionary<string, object> routeValues)
		{
			_composer.Initialize(_url.Length);

			int position = 0;
			foreach (Match match in ParameterMatcher.Matches(_url))
			{
				_composer.AppendText(_url.Substring(position, match.Index - position));

				string parameterName = match.Groups[ParameterName].Value;
				var parameterValue = routeValues[parameterName] as string;
				if (parameterValue == null)
				{
					_composer.AppendParameterName(parameterName);
				}
				else
				{
					_composer.AppendParameterValue(parameterValue);
				}
				position = match.Index + match.Length;
			}
			if (position < _url.Length)
			{
				_composer.AppendText(_url.Substring(position));
			}
			return _composer.ToString();
		}

		private const string ParameterName = "parameter";

		private static readonly Regex ParameterMatcher = new Regex(@"{(?<" + ParameterName + @">[\w]*)}",
		                                                           RegexOptions.Compiled);

		private readonly IUrlComposer _composer;
		private readonly string _url;
	}
}