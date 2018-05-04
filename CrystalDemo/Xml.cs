using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Crystal
{
    static public class Xml
    {
        static public XmlNode AddNode(XmlDocument _doc, XmlNode _parentNode, string _nodeName)
        {
            XmlNode addingNode = _doc.CreateElement(_nodeName);
            if (_parentNode == null)
            {
                _doc.AppendChild(addingNode);
            }
            else
            {
                _parentNode.AppendChild(addingNode);
            }

            return addingNode;
        }

        static public XmlNode AddNode(XmlDocument _doc, XmlNode _parentNode, string _nodeName, string _innerText)
        {
            XmlNode addingNode = _doc.CreateElement(_nodeName);
            addingNode.InnerText = _innerText;
            if (_parentNode == null)
            {
                _doc.AppendChild(addingNode);
            }
            else
            {
                _parentNode.AppendChild(addingNode); 
            }

            return addingNode;
        }

        static public XmlNode AddNode(XmlDocument _doc, XmlNode _parentNode, string _nodeName, string[] _attributesName, string[]_attributeValues)
        {
            XmlNode addingNode = _doc.CreateElement(_nodeName);
            foreach (var attribute in _attributesName.Zip(_attributeValues, Tuple.Create))
            {
                XmlAttribute addingAttribute = _doc.CreateAttribute(attribute.Item1);
                addingAttribute.Value = attribute.Item2;
                addingNode.Attributes.Append(addingAttribute);
            }
            if (_parentNode == null)
            {
                _doc.AppendChild(addingNode);
            }
            else
            {
                _parentNode.AppendChild(addingNode);
            }

            return addingNode;
        }
    }
}
