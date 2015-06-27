using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.GameEngine
{
    public class Game
    {
        #region Constructors

        public Game()
        {
            Money = new int[] { 0, 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000,
                                64000, 125000, 250000, 500000, 1000000 };
        }
        #endregion

        #region Private Fields

        private QuestionsBase _questionsBase;

        private QuestionPrice _currentPrice;

        private int _countOfTrueAswers;

        #endregion

        #region Properties

        public static string Name { get; set; }
        public int[] Money { get; private set; }

        public Question CurrentQuestion { get; private set; }

        public bool CurrentQuestionAnswer { get; private set; }

        public int WinMoney
        {
            get
            {
                return Money[_countOfTrueAswers];
            }
        }

        #endregion

        #region Methods

        public bool IsEndGame()
        {
            return _countOfTrueAswers == Money.Length - 1;
        }

        public int OwnMoney ()
        {
            return (int)CurrentQuestion.Price;
        }       

        public void RunGame(string answer)
        {            
            if (CurrentQuestion.GetTrueAnswer() == answer)
            {
                CurrentQuestionAnswer = true;
                _countOfTrueAswers++;
                if (!IsEndGame())
                {
                    _questionsBase.Remove(CurrentQuestion);
                    CurrentQuestion = _questionsBase.GetQuestionByPrice(_currentPrice);
                    IncreasePrice();
                }
            }
            else
            {                
                //_countOfTrueAswers = OwnMoney();
                CurrentQuestionAnswer = false;
            }
        }
        
        private void IncreasePrice()
        {
            if (!IsEndGame())
            {
                //_countOfTrueAswers++;
                if (WinMoney < (int)QuestionPrice.Price2)
                {
                    _currentPrice = QuestionPrice.Price1;
                }
                else if (WinMoney < (int)QuestionPrice.Price3)
                {
                    _currentPrice = QuestionPrice.Price2;
                }
                else if (WinMoney >= (int)QuestionPrice.Price3)
                {
                    _currentPrice = QuestionPrice.Price3;
                }
            }
        }

        public void FifityFifty()
        {
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

        public void StartGame(string fileName)
        {
            _countOfTrueAswers = 0;
            _questionsBase = new QuestionsBase(fileName);
            _questionsBase.GetQuestionsFromFile();
            _currentPrice = QuestionPrice.Price1;
            CurrentQuestion = _questionsBase.GetQuestionByPrice(_currentPrice);
        }

         #endregion

    }
}
