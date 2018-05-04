using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Interfaces;

namespace Crystal
{
    public static class Project
    {
        public static void SaveProject(string _path)
        {
            XmlDocument project = new XmlDocument();

            XmlNode xmlBook = Xml.AddNode(project, null, "book", new string[] { "name" }, new string[] { Program.book.Name });

            XmlNode settings = Xml.AddNode(project, xmlBook, "settings");
            Xml.AddNode(project, settings, "originalROM", Program.settings.OriginalROMPath);
            Xml.AddNode(project, settings, "translatedROM", Program.settings.TraslatedROMPath);

            XmlNode xmlPages = Xml.AddNode(project, xmlBook, "pages");

            foreach (Page page in Program.book.pages)
            {
                XmlNode xmlPage = Xml.AddNode(project, xmlPages, "page", new string[] { "name" }, new string[] { page.Name });

                Xml.AddNode(project, xmlPage, "isLinked", page.IsLinked.ToString());
                Xml.AddNode(project, xmlPage, "originalTable", page.OriginalTablePath);
                Xml.AddNode(project, xmlPage, "newTable", page.NewTablePath);
                Xml.AddNode(project, xmlPage, "pointerPluginName", page.PointerPluginName);
                Xml.AddNode(project, xmlPage, "pointerPluginParameters", page.PointerPluginParameters);
                Xml.AddNode(project, xmlPage, "tablePluginName", page.TablePluginName);
                Xml.AddNode(project, xmlPage, "tablePluginParameters", page.TablePluginParameters);
                Xml.AddNode(project, xmlPage, "storeMethodPluginName", page.StoreMethodPluginName);
                Xml.AddNode(project, xmlPage, "storeMethodPluginParameters", page.StoreMethodPluginParameters);

                XmlNode xmlParagraphs = Xml.AddNode(project, xmlPage, "paragraphs");

                foreach (Paragraph paragraph in page.paragraphs)
                {
                    XmlNode xmlParagraph = Xml.AddNode(project, xmlParagraphs, "paragraph", new string[] { "name" }, new string[] { paragraph.Name });

                    Xml.AddNode(project, xmlParagraph, "originalPonter", new string[] { "offset", "countBytes" }, new string[] { paragraph.originalPointer.Offset.ToString(), "2" });
                    Xml.AddNode(project, xmlParagraph, "newPointer", new string[] { "offset", "countBytes" }, new string[] { paragraph.newPointer.Offset.ToString(), "2" });
                    Xml.AddNode(project, xmlParagraph, "originalTextOffset", paragraph.OriginalTextOffset.ToString());
                    Xml.AddNode(project, xmlParagraph, "newTextOffset", paragraph.NewTextOffset.ToString());
                    Xml.AddNode(project, xmlParagraph, "newText", paragraph.NewText);
                }
            }

            project.Save(_path);
        }

        public static void OpenProject(string _path)
        {
            XmlDocument project = new XmlDocument();
            project.Load(_path);

            XmlNode xmlBook = project.SelectSingleNode("book");
            Program.book = new Book(xmlBook.Attributes.GetNamedItem("name").Value);
            Program.settings.OriginalROMPath = xmlBook.SelectSingleNode("settings/originalROM").InnerText;
            Program.settings.TraslatedROMPath = xmlBook.SelectSingleNode("settings/translatedROM").InnerText;

            foreach (XmlNode xmlPage in xmlBook.SelectNodes("pages/*"))
            {
                Page page = Program.book.AddPage(
                    xmlPage.Attributes.GetNamedItem("name").Value,
                    bool.Parse(xmlPage.SelectSingleNode("isLinked").InnerText),
                    xmlPage.SelectSingleNode("originalTable").InnerText,
                    xmlPage.SelectSingleNode("newTable").InnerText,
                    xmlPage.SelectSingleNode("pointerPluginName").InnerText,
                    xmlPage.SelectSingleNode("pointerPluginParameters").InnerText,
                    xmlPage.SelectSingleNode("tablePluginName").InnerText,
                    xmlPage.SelectSingleNode("tablePluginParameters").InnerText,
                    xmlPage.SelectSingleNode("storeMethodPluginName").InnerText,
                    xmlPage.SelectSingleNode("storeMethodPluginParameters").InnerText
                    );
                foreach (XmlNode xmlParagraph in xmlPage.SelectNodes("paragraphs/*"))
                {
                    page.AddParagraph(
                        xmlParagraph.Attributes.GetNamedItem("name").Value,
                        ToInt(xmlParagraph.SelectSingleNode("originalTextOffset").InnerText),
                        ToInt(xmlParagraph.SelectSingleNode("originalPonter").Attributes.GetNamedItem("offset").Value),
                        ToInt(xmlParagraph.SelectSingleNode("newTextOffset").InnerText),
                        ToInt(xmlParagraph.SelectSingleNode("newPointer").Attributes.GetNamedItem("offset").Value),
                        xmlParagraph.SelectSingleNode("newText").InnerText
                        );
                }
            }
        }

        public static int ToInt(string _value)
        {
            int result = 0;
            if (_value.Contains("x"))
            {
                result = Convert.ToInt32(_value, 16);
            }
            else
            {
                result = int.Parse(_value);
            }
            return result;
        }
    }
}
