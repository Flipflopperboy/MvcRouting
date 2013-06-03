using System.Text;

namespace Flip.Web.Routing
{
	public sealed class UrlComposer : IUrlComposer
	{
		public void Initialize(int length)
		{
			_builder = new StringBuilder(length);
		}

		public void AppendText(string text)
		{
			_builder.Append(text);
		}

		public void AppendParameterName(string parameterName)
		{
			_builder.Append(parameterName);
		}

		public void AppendParameterValue(string parameterValue)
		{
			_builder.Append(parameterValue);
		}

		public override string ToString()
		{
			return _builder.ToString();
		}

		private StringBuilder _builder;
	}
}