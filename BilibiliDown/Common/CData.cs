using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BilibiliDown.Common
{
	public class CData : IXmlSerializable
	{
		private string m_Value;

		public string Value => m_Value;

		public CData()
		{
		}

		public CData(string p_Value)
		{
			m_Value = p_Value;
		}

		public void ReadXml(XmlReader reader)
		{
			m_Value = reader.ReadElementContentAsString();
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteCData(m_Value);
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public override string ToString()
		{
			return m_Value;
		}

		public static implicit operator string(CData element)
		{
			return element?.m_Value;
		}

		public static implicit operator CData(string text)
		{
			return new CData(text);
		}
	}
}
