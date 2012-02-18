using System;
using System.Collections.Generic;
using Hackernator.Models;

namespace Hackernator.HNAPI
{
    public class HackerNewsParser
    {
        public IEnumerable<Link> GetLinksFromRaw(string content)
        {
            List<Link> links = new List<Link>();

            string titleFlag = "<td class=\"title\">";
            string closingFlag = "</td>";

            string dataToManipulate = content;

            int titleLocation = dataToManipulate.IndexOf(titleFlag);

            while (titleLocation != -1)
            {
                Link hLink = new Link();

                dataToManipulate = dataToManipulate.Remove(0, titleLocation);
                int closingIndex = dataToManipulate.IndexOf(closingFlag);

                string XMLitem = dataToManipulate.Substring(0, closingIndex + closingFlag.Length);
                dataToManipulate = dataToManipulate.Replace(XMLitem, string.Empty);

                int index = XMLitem.IndexOf("href");
                if (index != -1)
                {
                    XMLitem = XMLitem.Remove(0, index);
                    index = XMLitem.IndexOf("\">");

                    hLink.Url = XMLitem.Substring(6, index - 6);

                    XMLitem = XMLitem.Remove(0, index + 2);
                    index = XMLitem.IndexOf("</");
                    hLink.Title = XMLitem.Substring(0, index);

                    if (hLink.Title != "More")
                    {
                        XMLitem = XMLitem.Remove(0, index);
                        index = XMLitem.IndexOf("(");
                        if (index != -1)
                            hLink.Domain = XMLitem.Substring(index, XMLitem.IndexOf(")") - index + 1);
                        else
                            hLink.Domain = "HackerNews";

                        index = dataToManipulate.IndexOf("<td class=\"subtext\">");
                        if (index != -1)
                        {
                            dataToManipulate = dataToManipulate.Remove(0, index);
                            index = dataToManipulate.IndexOf(closingFlag);

                            XMLitem = dataToManipulate.Substring(0, index + closingFlag.Length);
                            dataToManipulate = dataToManipulate.Replace(XMLitem, string.Empty);

                            index = XMLitem.IndexOf("score_");
                            if (index != -1)
                            {
                                XMLitem = XMLitem.Remove(0, index);

                                index = XMLitem.IndexOf(">");
                                hLink.ID = XMLitem.Substring(6, index - 6);

                                XMLitem = XMLitem.Remove(0, index + 1);
                            }

                            index = XMLitem.IndexOf("points");
                            if (index != -1)
                            {
                                hLink.Points = Convert.ToInt32(XMLitem.Substring(0, index));

                                index = XMLitem.IndexOf("\">");
                                XMLitem = XMLitem.Remove(0, index + 2);

                                index = XMLitem.IndexOf("<");
                                hLink.Author = XMLitem.Substring(0, index);

                                XMLitem = XMLitem.Remove(0, index);
                                index = XMLitem.IndexOf("\">");
                                XMLitem = XMLitem.Remove(0, index + 2);
                            }
                            else
                                hLink.Points = 0;

                            index = XMLitem.IndexOf("comments");
                            if (index != -1)
                                hLink.Comments = Convert.ToInt32(XMLitem.Substring(0, index));
                            else
                                hLink.Comments = 0;

                            links.Add(hLink);
                        }
                    }
                }
                titleLocation = dataToManipulate.IndexOf(titleFlag);
            }

            return links;
        }
    }
}
