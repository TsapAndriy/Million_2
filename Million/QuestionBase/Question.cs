using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;

namespace Million.GameEngine
{
    [DataContract]
    public class Question
    {
        #region Properties
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public List<Answer> Answers { get; set; }

        [DataMember]
        public QuestionPrice Price { get; set; }

        #endregion

        #region Constructors

        public Question(int id, string name, List<Answer> answers, QuestionPrice price)
        {
            this.Name = name;
            this.Id = id;
            this.Answers = answers;
            this.Price = price;
        }

        public Question()
        {

        }

        #endregion

        public void Save(string fileName)
        {
            using (XmlTextWriter xw = new XmlTextWriter(fileName, Encoding.UTF8)) 
            {
                xw.Formatting = Formatting.Indented;
                XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xw);
                DataContractSerializer ser = new DataContractSerializer(typeof(Question));
                ser.WriteObject(writer, this);
                writer.Close();
                xw.Close();
            }
        }

        public string GetTrueAnswer()
        {
            string trueanswer = string.Empty;
            foreach (Answer answer in Answers)
            {
                if (answer.IsTrue)
                {
                    trueanswer = answer.Name;
                }
            }
            return trueanswer;
        }
    }

}





