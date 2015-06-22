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
    [DataContract]
    public class QuestionsBase
    {
        public static string fileName = "333.xml";

        [DataMember]
        public List<Question> Questions { get; set; }

        //[DataMember]
        //public int LastId { get; private set; }

        public QuestionsBase()
        {
           this.Questions = new List<Question>();
           //GetQuestionsFromFile();
        }

        //public void Add(Question question)
        //{
        //    this.Questions.Add(question);
        //    //this.LastId++;
        //}

        public void Remove(Question question)
        {
            int index = 0;
            foreach (var quiz in Questions)
            {
                if (question.Name == quiz.Name)
                {
                    this.Questions.RemoveAt(index);
                    break;
                }
                index++;
            }
            //this.Questions.Remove(question);
        }

        public void Save(List<Question> questions)
        {
            //using (XmlTextWriter xw = new XmlTextWriter(fileName, Encoding.UTF8)) //, FileMode.Append, FileAccess.Read))
            //{
            //    xw.Formatting = Formatting.Indented;
            //    XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xw);
            //    DataContractSerializer ser = new DataContractSerializer(typeof(QuestionsBase));
            //    ser.WriteObject(writer, this);
            //    writer.Close();
            //    xw.Close();
            //}


            //XmlSerializer ser = new XmlSerializer(typeof(QuestionsBase));
            //StreamWriter sw = new StreamWriter(fileName, true);
            //ser.Serialize(sw, this);
            //sw.Close();

            XmlSerializer ser = new XmlSerializer(typeof(List<Question>));
            StreamWriter sw = new StreamWriter(fileName, true);
            ser.Serialize(sw, questions);
            sw.Close();
        }

        public void GetQuestionsFromFile()
        {
            this.Questions = new List<Question>();

            //using (FileStream fs = new FileStream(fileName, FileMode.Open))
            //{
            //    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
            //    DataContractSerializer ser = new DataContractSerializer(typeof(QuestionsBase));
            //    this.Questions = ((QuestionsBase)ser.ReadObject(reader)).Questions;
            //}


            //XmlSerializer ser = new XmlSerializer(typeof(QuestionsBase));
            //StreamReader sr = new StreamReader(fileName, true);
            //ser.Deserialize(sr);
            //sr.Close();


            //XmlSerializer serializer = new XmlSerializer(typeof(QuestionsBase));
            //using (FileStream fs = new FileStream(fileName, FileMode.Open))
            //{
            //    XmlReader reader = XmlReader.Create(fs);
            //    this.Questions = ((QuestionsBase)serializer.Deserialize(reader)).Questions;
            //    fs.Close();
            //    reader.Close();                
            //}

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                //Question quiz = new Question();
                //XmlNode xnodeQuest = xnode.FirstChild;
                foreach (XmlNode childnodes in xnode.ChildNodes)//xnodeQuest.ChildNodes)
                {
                    Question quiz = new Question();
                    foreach (XmlNode childnode in childnodes)
                    {
                        if (childnode.Name == "Name")
                            quiz.Name = childnode.InnerText;

                        if (childnode.Name == "Price")
                            quiz.Price = (QuestionPrice)Enum.Parse(typeof(QuestionPrice), childnode.InnerText);

                        if (childnode.Name == "Id")
                            quiz.Id = Convert.ToInt32(childnode.InnerText);

                        if (childnode.Name == "Answers")
                        {
                            List<Answer> answers = new List<Answer>();
                            foreach (XmlNode chAnswer in childnode.ChildNodes)
                            {
                                Answer answ = new Answer();
                                foreach (XmlNode answerElm in chAnswer)
                                {
                                    if (answerElm.Name == "Name")
                                        answ.Name = answerElm.InnerText;
                                    if (answerElm.Name == "IsTrue")
                                        answ.IsTrue = Convert.ToBoolean(answerElm.InnerText);
                                }
                                answers.Add(answ);
                            }
                            quiz.Answers = answers;
                        }
                    }
                    this.Questions.Add(quiz);
                }
            }
        }

        public Question GetQuestionByPrice (QuestionPrice price) 
        {
            var question = from q in Questions
                       where (q.Price == price) // && !answeredQuestionsId.Contains(q.Id))
                       select q;

            Random r = new Random();
            int rnd = r.Next(question.Count());

            return question.ElementAt(rnd);
        }

        public bool IsPossibleId (int id)
        {
            bool b = true;
            foreach (var question in Questions)
            {
                if (question.Id == id)
                {
                    b = false;
                    return b;
                }
            }
            return b;
        }
    }
}
