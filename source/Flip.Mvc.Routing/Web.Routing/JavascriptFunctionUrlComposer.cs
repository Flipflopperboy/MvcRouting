using System.Text;

namespace Flip.Web.Routing
{
	public sealed class JavascriptFunctionUrlComposer : IUrlComposer
	{
		public void Initialize(int length)
		{
			_argumentListBuilder = new StringBuilder(length);
			_bodyBuilder = new StringBuilder(length*2);
		}

		public void AppendText(string text)
		{
			AssureOpen();
			_bodyBuilder.Append(text);
		}

		public void AppendParameterName(string parameterName)
		{
			AppendParameterNameToArgumentList(parameterName);
			AppendParameterNameToBody(parameterName);
		}

		public void AppendParameterValue(string parameterValue)
		{
			AppendText(parameterValue);
		}

		private void AssureOpen()
		{
			if (_open)
			{
				return;
			}
			_bodyBuilder.Append(_bodyBuilder.Length > 0 ? "+ '" : "'");
			_open = true;
		}

		public override string ToString()
		{
			if (_bodyBuilder.Length == 0)
			{
				return "function(){return '';}";
			}
			AssureClosed();
			return string.Format("function({0}){{return {1};}}", _argumentListBuilder, _bodyBuilder);
		}

		private void AppendParameterNameToBody(string parameterName)
		{
			AssureClosed();
			if (_bodyBuilder.Length > 0)
			{
				_bodyBuilder.Append(" + ");
			}
			_bodyBuilder.Append("encodeURIComponent(");
			_bodyBuilder.Append(parameterName);
			_bodyBuilder.Append(")");
		}

		private void AssureClosed()
		{
			if (_open)
			{
				_bodyBuilder.Append("'");
				_open = false;
			}
		}

		private void AppendParameterNameToArgumentList(string parameterName)
		{
			if (_argumentListBuilder.Length > 0)
			{
				_argumentListBuilder.Append(" ,");
			}
			_argumentListBuilder.Append(parameterName);
		}

		private StringBuilder _argumentListBuilder;
		private StringBuilder _bodyBuilder; //:)
		private bool _open;
	}
}