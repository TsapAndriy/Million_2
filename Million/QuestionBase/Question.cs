using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;

namespace GameEngine
{
    //[Serializable]
    [DataContract]
    public class Question
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Id { get; set; }

        //[DataMember]
        //public Dictionary<string, bool> Answers { get; set; }

        [DataMember]
        public List<Answer> Answers { get; set; }

        [DataMember]
        public QuestionPrice Price { get; set; }

        //public Question(int id, string name, Dictionary<string, bool> answers, QuestionPrice price)
        //{
        //    this.Name = name;
        //    this.Id = id;
        //    this.Answers = answers;
        //    this.Price = price;
        //}
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

        public void Save(string fileName)
        {
            //using (Stream fStream = new FileStream(fileName, FileMode.Create))
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(Question));
            //    serializer.Serialize(fStream, this);
            //}

            //using (StreamWriter writer = new StreamWriter(fileName))
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(Question));
            //    serializer.Serialize(writer, this);
            //}

            using (XmlTextWriter xw = new XmlTextWriter(fileName, Encoding.UTF8)) //, FileMode.Append, FileAccess.Read))
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

        //[DataContract]
        //public class QuestionsBase
        //{
        //    [DataMember]
        //    public List<Question> Questions { get; set; }

        //    public QuestionsBase(string fileName)
        //    {
        //        GetQuestionsFromFile(fileName);
        //    }

        //    public void Add(Question question)
        //    {
        //        this.Questions.Add(question);
        //    }

        //    public void Save(string fileName)
        //    {
        //        using (XmlTextWriter xw = new XmlTextWriter(fileName, Encoding.UTF8)) //, FileMode.Append, FileAccess.Read))
        //        {
        //            xw.Formatting = Formatting.Indented;
        //            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xw);
        //            DataContractSerializer ser = new DataContractSerializer(typeof(QuestionsBase));
        //            ser.WriteObject(writer, this);
        //            writer.Close();
        //            xw.Close();
        //        }
        //    }

        //    public void GetQuestionsFromFile(string fileName)
        //    {
        //        this.Questions = new List<Question>();

        //        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        //        {
        //            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
        //            DataContractSerializer ser = new DataContractSerializer(typeof(QuestionsBase));
        //            this.Questions = ((QuestionsBase)ser.ReadObject(reader)).Questions;
        //        }

        //    }
        //}

    }





