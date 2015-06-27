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
    public class QuestionsBase
    {
        private string _fileName;

        [DataMember]
        public List<Question> Questions { get; set; }

        public QuestionsBase(string fileName)
        {
            this.Questions = new List<Question>();
            this._fileName = fileName;
        }

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
            XmlSerializer ser = new XmlSerializer(typeof(List<Question>));
            StreamWriter sw = new StreamWriter(_fileName, true);
            ser.Serialize(sw, questions);
            sw.Close();
        }

        public void GetQuestionsFromFile()
        {
            this.Questions = new List<Question>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_fileName);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                foreach (XmlNode childnodes in xnode.ChildNodes)
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
                       where (q.Price == price) 
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
