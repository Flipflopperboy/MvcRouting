namespace Flip.Web.Routing
{
	public interface IUrlComposer
	{
		void Initialize(int length);
		void AppendText(string p);
		void AppendParameterName(string parameterName);
		void AppendParameterValue(string parameterValue);
	}
}