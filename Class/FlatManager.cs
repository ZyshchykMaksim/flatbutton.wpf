using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Res = FlatUIWPF.Properties.Resources;

namespace FlatUIWPF
{
    public static class FlatManager
    {
        public static Dictionary<AwesomeIcon, string> GetIcon()
        {
            try
            {
                Dictionary<AwesomeIcon, string> icons = new Dictionary<AwesomeIcon, string>();
                XDocument document = XDocument.Parse(Res.Icons);
                foreach (var icon in document.Descendants("Icons").Elements("Icon"))
                {
                    var key = icon.Attribute("key");
                    var value = icon.Attribute("value");
                    if (key != null && value != null)
                    {
                        AwesomeIcon awesomeIcon;
                        if (Enum.TryParse(key.Value.ToLowerInvariant(), out awesomeIcon))
                        {
                            if (!icons.ContainsKey(awesomeIcon))
                                icons.Add(awesomeIcon, value.Value);
                        }
                    }
                }
                return icons;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
