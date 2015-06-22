using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class Game
    {
        public static int[] Money = { 0, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 1000000 };

        public static  Question CurrentQuestion { get; private set; }
         
        public static int WinMoney
        {
            get
            {
                return Money[_countOfTrueAswers];
            }
        }

        public static int OwnMoney ()
        {
            return (int)CurrentQuestion.Price;
        }       


        private static QuestionsBase _questionsBase;
        
        private static QuestionPrice _currentPrice;

        private static int _countOfTrueAswers;

        static Game()
        {
            _questionsBase = new QuestionsBase();
            _questionsBase.GetQuestionsFromFile();
            //_answeredQuestionsId = new List<int>();
            _currentPrice = QuestionPrice.Price1;
            CurrentQuestion = _questionsBase.GetQuestionByPrice(_currentPrice); //, _answeredQuestionsId);
        }

        public static void RunGame(string answer)
        {
            //if (CurrentQuestion.Answers[answer])
            //{
            //    CurrentQuestion = _questionsBase.GetQuestionByPrice(_currentPrice); //, _answeredQuestionsId);
            //    _questionsBase.Remove(CurrentQuestion);
            //    IncreasePrice();
            //}
            //else
            //{
            //    CurrentQuestion = null;
            //}

            if (CurrentQuestion.GetTrueAnswer() == answer)
            {
                _questionsBase.Remove(CurrentQuestion);
                CurrentQuestion = _questionsBase.GetQuestionByPrice(_currentPrice);                
                IncreasePrice();
            }
            else
            {
                CurrentQuestion = null;
                _countOfTrueAswers = OwnMoney();
            }
        }
        
        private static void IncreasePrice()
        {
            _countOfTrueAswers++;
            if (_countOfTrueAswers <= (int)QuestionPrice.Price1)
            {
                _currentPrice = QuestionPrice.Price1;
            }
            else if (_countOfTrueAswers <= (int)QuestionPrice.Price2)
            {
                _currentPrice = QuestionPrice.Price2;
            }
            else if (_countOfTrueAswers <= (int)QuestionPrice.Price3)
            {
                _currentPrice = QuestionPrice.Price3;
            }
        }

        public static void FifityFifty()
        {
            //Question question = new Question();
            //int fifty = 2;
            //while (fifty != 0)
            //{
            //    if (!CurrentQuestion.)
            //    {
            //        CurrentQuestion.Answers.ElementAt(fifty - 2).Key = string.Empty;
            //    }
            //}

            List<Answer> answers = new List<Answer>();
            int countOfHiden = 0;
            foreach (var answer in CurrentQuestion.Answers)
            {
                if (!answer.IsTrue && countOfHiden != 2)
                {
                    answer.Hide();
                    countOfHiden++;
                }
                answers.Add(answer);
            }

            CurrentQuestion = new Question(CurrentQuestion.Id, CurrentQuestion.Name, answers, CurrentQuestion.Price);
        }

        public static void StartGame()
        {
            _countOfTrueAswers = 0;
            _questionsBase = new QuestionsBase();
            _questionsBase.GetQuestionsFromFile();
            _currentPrice = QuestionPrice.Price1;
            CurrentQuestion = _questionsBase.GetQuestionByPrice(_currentPrice);
        }

    }
}
