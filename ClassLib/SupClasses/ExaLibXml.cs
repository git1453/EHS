using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLib
{
    public class ExaLibXml : XmlHelper
    {
        public ExaLibXml(string path) : base(path)
        {

        }    
        
        /// <summary>
        /// 批量添加试题
        /// </summary>
        /// <param name="exaQuests"></param>
        /// <param name="LibName"></param>
        /// <param name="Sec"></param>
        public void AddQuests(List<ExaQuestModel> exaQuests, string LibName, int Sec)
        {
            foreach (ExaQuestModel exaQuest in exaQuests)
            {
                AddQuestWithoutSave(exaQuest, LibName, Sec);
            }
            Save();
        }

        /// <summary>
        /// 添加单个试题并保存
        /// </summary>
        /// <param name="exaQuest"></param>
        /// <param name="LibName"></param>
        /// <param name="Sec"></param>
        public void AddQuestWithSave(ExaQuestModel exaQuest, string LibName, int Sec)
        {
            AddQuestWithoutSave(exaQuest, LibName, Sec);
            Save();
        }

        /// <summary>
        /// 保存 
        /// </summary>
        public void Save()
        {
            XML.Save(PATH);
        }

        /// <summary>
        /// 添加单个试题不保存
        /// </summary>
        /// <param name="exaQuest"></param>
        /// <param name="LibName"></param>
        /// <param name="Sec"></param>
        public void AddQuestWithoutSave(ExaQuestModel exaQuest, string LibName, int Sec)
        {

            XmlNode root = XML.SelectSingleNode("/ExaLib");
            string libname = ((XmlElement)root).GetAttribute("name");
            if (libname == null || !libname.Equals(LibName))
            {
                return;
            }
            foreach (XmlNode Section in root.ChildNodes)
            {
                if (Section.Name.Equals("Section") && Convert.ToInt32(((XmlElement)Section).GetAttribute("id")).Equals(Sec))
                {
                    int id = 1;
                    if (Section.HasChildNodes)
                    {
                        foreach (XmlNode HadQuest in Section.ChildNodes)
                        {
                            foreach(XmlNode prop in HadQuest.ChildNodes)
                            {
                                if(prop.Name.Equals("Question")&&prop.InnerText.Equals(exaQuest.question))
                                {
                                    return;
                                }
                            }
                            id = Convert.ToInt32(((XmlElement)HadQuest).GetAttribute("Qid")) > id ? Convert.ToInt32(((XmlElement)HadQuest).GetAttribute("Qid")) : id;
                        };
                    }
                    XmlNode quest = GenerateNode(exaQuest, id + 1);
                    Section.AppendChild(quest);
                    return;
                }
            }
            XmlNode newSec = XML.CreateElement("Section");
            ((XmlElement)newSec).SetAttribute("id", Sec.ToString());
            newSec.AppendChild(GenerateNode(exaQuest, 1));
            root.AppendChild(newSec);


        }

        /// <summary>
        /// 删除节点并保存
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="LibName"></param>
        /// <param name="Sec"></param>
        public void DeleteQuest(int Index,string LibName,int Sec)
        {
            XmlNode root = XML.SelectSingleNode("/ExaLib");
            string libname = ((XmlElement)root).GetAttribute("name");
            if (libname == null || !libname.Equals(LibName))
            {
                return;
            }
            foreach (XmlNode Section in root.ChildNodes)
            {
                if (Section.Name.Equals("Section") && Convert.ToInt32(((XmlElement)Section).GetAttribute("id")).Equals(Sec))
                {
                    if (Section.HasChildNodes)
                    {
                        foreach (XmlNode HadQuest in Section.ChildNodes)
                        {
                            if (Convert.ToInt32(((XmlElement)HadQuest).GetAttribute("Qid")).Equals(Index))
                            {
                                HadQuest.ParentNode.RemoveChild(HadQuest);
                                Save();
                                return;
                            }
                        };
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        #region 节点转换
        /// <summary>
        /// 生成节点
        /// </summary>
        /// <param name="exaQuest"></param>
        /// <returns></returns>
        private XmlNode GenerateNode(ExaQuestModel exaQuest, int id)
        {

            XmlNode quest = XML.CreateElement("Quest");
            ((XmlElement)quest).SetAttribute("Qid", id.ToString());
            ((XmlElement)quest).SetAttribute("Type", exaQuest.type);
            ((XmlElement)quest).SetAttribute("Level", exaQuest.level);

            XmlNode question = XML.CreateElement("Question");
            question.InnerText = exaQuest.question;
            quest.AppendChild(question);

            XmlNode switches = XML.CreateElement("Switch");
            switches.InnerText = exaQuest.switches;
            quest.AppendChild(switches);

            XmlNode answer = XML.CreateElement("Answer");
            answer.InnerText = exaQuest.answer;
            quest.AppendChild(answer);

            XmlNode summery = XML.CreateElement("Summery");
            summery.InnerText = exaQuest.summary;
            quest.AppendChild(summery);

            return quest;
        }

        private ExaQuestModel GenerateQuest(XmlNode questNode, string libname, XmlElement sec)
        {
            ExaQuestModel exaQuest = new ExaQuestModel();
            exaQuest.belongtolib = libname;
            exaQuest.belongtosection = sec.GetAttribute("name");
            exaQuest.num = Convert.ToInt32(((XmlElement)questNode).GetAttribute("Qid"));
            foreach (XmlNode propertyNode in questNode.ChildNodes)
            {
                switch (propertyNode.Name)
                {
                    case "Type":
                        exaQuest.type = propertyNode.InnerText.Trim();
                        break;
                    case "Question":
                        exaQuest.question = propertyNode.InnerText.Trim();
                        break;
                    case "Switch":
                        exaQuest.switches = propertyNode.InnerText.Trim();
                        break;
                    case "Answer":
                        exaQuest.answer = propertyNode.InnerText.Trim();
                        break;
                    case "Summary":
                        exaQuest.summary = propertyNode.InnerText.Trim();
                        break;
                    case "Level":
                        exaQuest.level = propertyNode.InnerText.Trim();
                        break;
                }
            }
            return exaQuest;
        }
        #endregion

 

        /// <summary>
        /// 获取所有的试题
        /// </summary>
        /// <param name="LibName"></param>
        /// <param name="Sec"></param>
        /// <returns></returns>
        public List<ExaQuestModel> GetExaQuests(string LibName, int Sec)
        {
            XmlNode root = XML.SelectSingleNode("/ExaLib");
            string libname = ((XmlElement)root).GetAttribute("name");
            if (libname == null || !libname.Equals(LibName))
            {
                return null;
            }
            XmlNodeList nodelist = root.ChildNodes;
            foreach (XmlNode sectonNode in nodelist)
            {
                XmlElement sec = (XmlElement)sectonNode;
                if (sectonNode.Name.Equals("Section") && Convert.ToInt32(sec.GetAttribute("id")).Equals(Sec))
                {
                    List<ExaQuestModel> quests = new();
                    foreach (XmlNode questNode in sectonNode.ChildNodes)
                    {
                        if (questNode.Name.Equals("Quest"))
                        {
                            quests.Add(GenerateQuest(questNode, libname, sec));
                        }
                    }
                    return quests;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取为字典
        /// </summary>
        /// <param name="LibName"></param>
        /// <param name="Sec"></param>
        /// <returns></returns>
        public Dictionary<int, ExaQuestModel> GetQuestDic(string LibName, int Sec)
        {
            Dictionary<int, ExaQuestModel> keyValues = new();
            if (GetExaQuests(LibName, Sec) == null)
            {
                return null;
            }
            else
            {
                GetExaQuests(LibName, Sec).ForEach(x => keyValues.Add(x.num, x));
                return keyValues;
            }

        }

    }
}
 