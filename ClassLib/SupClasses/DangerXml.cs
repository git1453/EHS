using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLib
{
    public class DangerXml :XmlHelper
    {
        public DangerXml(string path): base(path)
        {
        }
        public string GetPATH()
        {
            return PATH;
        }

        
        #region 危险告知操作
        /// <summary>
        /// 删除危险信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDanger(int id)
        {
            XmlNodeList comment = XML.SelectNodes("//Info");
            foreach (XmlNode x in comment)
            {
                XmlElement e = (XmlElement)x;
                if (Convert.ToInt32(e.GetAttribute("id").ToString().Trim()).Equals(id))
                {
                    x.ParentNode.RemoveChild(e);
                    XML.Save(PATH);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 修改危险信息
        /// </summary>
        /// <param name="dangerInfo"></param>
        /// <returns></returns>
        public bool ChangeDanger(DangerInfoModel dangerInfo)
        {
            XmlNode root = XML.SelectSingleNode("/Danger");
            XmlNodeList infos = XML.SelectNodes("//Info");
            foreach (XmlNode x in infos)
            {
                XmlElement e = (XmlElement)x;
                if (Convert.ToInt32(e.GetAttribute("id").ToString().Trim()).Equals(dangerInfo.id))
                {
                    x.ParentNode.RemoveChild(e);
                    XmlElement info = XML.CreateElement("Info");
                    info.SetAttribute("id", dangerInfo.id.ToString());
                    XmlElement dep = XML.CreateElement("Department");
                    dep.InnerText = dangerInfo.department;
                    info.AppendChild(dep);
                    XmlElement reg = XML.CreateElement("Region");
                    reg.InnerText = dangerInfo.region;
                    info.AppendChild(reg);
                    XmlElement ocp = XML.CreateElement("Occupation");
                    ocp.InnerText = dangerInfo.occupation;
                    info.AppendChild(ocp);
                    XmlElement cau = XML.CreateElement("Cause");
                    cau.InnerText = dangerInfo.cause;
                    info.AppendChild(cau);
                    XmlElement efc = XML.CreateElement("Effect");
                    efc.InnerText = dangerInfo.effect;
                    info.AppendChild(efc);
                    XmlElement symps = XML.CreateElement("Symptoms");
                    if (dangerInfo.symptom != null)
                    {
                        foreach (string s in dangerInfo.symptom)
                        {
                            XmlElement ee = XML.CreateElement("Symptom");
                            ee.InnerText = s;
                            symps.AppendChild(ee);
                        }
                    }
                    info.AppendChild(symps);
                    XmlElement prots = XML.CreateElement("Protections");
                    if (dangerInfo.protection != null)
                    {
                        foreach (string p in dangerInfo.protection)
                        {
                            XmlElement ee = XML.CreateElement("Protection");
                            ee.InnerText = p;
                            prots.AppendChild(ee);
                        }
                    }
                    info.AppendChild(prots);

                    root.AppendChild(info);

                    XML.Save(PATH);
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 添加危险信息 
        /// </summary>
        /// <param name="dangerInfo"></param>
        /// <returns></returns>
        public bool AddDanger(DangerInfoModel dangerInfo)
        {
            XmlNode root = XML.SelectSingleNode("/Danger");
            XmlNodeList nodelist = root.ChildNodes;
            XmlNodeList comment = XML.SelectNodes("//Info");
            int i = 1;
            foreach (XmlNode x in comment)
            {
                XmlElement e = (XmlElement)x;
                if (Convert.ToInt32(e.GetAttribute("id").ToString().Trim()) > i)
                {
                    i = Convert.ToInt32(e.GetAttribute("id").ToString().Trim());
                }
            }
            XmlElement info = XML.CreateElement("Info");
            info.SetAttribute("id", (i + 1).ToString());
            XmlElement dep = XML.CreateElement("Department");
            dep.InnerText = dangerInfo.department;
            info.AppendChild(dep);
            XmlElement reg = XML.CreateElement("Region");
            reg.InnerText = dangerInfo.region;
            info.AppendChild(reg);
            XmlElement ocp = XML.CreateElement("Occupation");
            ocp.InnerText = dangerInfo.occupation;
            info.AppendChild(ocp);
            XmlElement cau = XML.CreateElement("Cause");
            cau.InnerText = dangerInfo.cause;
            info.AppendChild(cau);
            XmlElement efc = XML.CreateElement("Effect");
            efc.InnerText = dangerInfo.effect;
            info.AppendChild(efc);
            XmlElement symps = XML.CreateElement("Symptoms");
            if (dangerInfo.symptom != null)
            {
                foreach (string s in dangerInfo.symptom)
                {
                    XmlElement ee = XML.CreateElement("Symptom");
                    ee.InnerText = s;
                    symps.AppendChild(ee);
                }
            }
            info.AppendChild(symps);
            XmlElement prots = XML.CreateElement("Protections");
            if (dangerInfo.protection != null)
            {
                foreach (string p in dangerInfo.protection)
                {
                    XmlElement ee = XML.CreateElement("Protection");
                    ee.InnerText = p;
                    prots.AppendChild(ee);
                }
            }
            info.AppendChild(prots);

            root.AppendChild(info);

            XML.Save(PATH);
            return true;
        }

        /// <summary>
        /// 获取所有的信息
        /// </summary>
        /// <returns></returns>
        public List<DangerInfoModel> GetDangers()
        {
            List<DangerInfoModel> Dangers = new();
            XmlNode root = XML.SelectSingleNode("/Danger");
            XmlNodeList nodelist = root.ChildNodes;
            foreach (XmlNode n in nodelist)
            {
                XmlElement e = (XmlElement)n;
                if (n.Name.Equals("Info"))
                {
                    DangerInfoModel com = new DangerInfoModel();
                    XmlNodeList xmlNodeList = n.ChildNodes;
                    com.id = Convert.ToInt32(e.GetAttribute("id").Trim());
                    foreach (XmlNode x in xmlNodeList)
                    {
                        switch (x.Name)
                        {
                            case "Department":
                                com.department = x.InnerText.Trim();
                                break;
                            case "Region":
                                com.region = x.InnerText.Trim();
                                break;
                            case "Occupation":
                                com.occupation = x.InnerText.Trim();
                                break;
                            case "Cause":
                                com.cause = x.InnerText.Trim();
                                break;
                            case "Symptoms":
                                if (x.HasChildNodes)
                                {
                                    com.symptom = new List<string>();
                                    foreach (XmlNode nn in x.ChildNodes)
                                    {
                                        if (nn.Name.Equals("Symptom"))
                                        {
                                            com.symptom.Add(nn.InnerText.Trim());
                                        }
                                    }
                                }
                                break;
                            case "Effect":
                                com.effect = x.InnerText.Trim();
                                break;
                            case "Protections":
                                if (x.HasChildNodes)
                                {
                                    com.protection = new List<string>();
                                    foreach (XmlNode nn in x.ChildNodes)
                                    {
                                        if (nn.Name.Equals("Protection"))
                                        {
                                            com.protection.Add(nn.InnerText.Trim());
                                        }
                                    }
                                }
                                break;
                        }

                    }
                    Dangers.Add(com);
                }
            }
            return Dangers;
        }
        #endregion

    }
}
