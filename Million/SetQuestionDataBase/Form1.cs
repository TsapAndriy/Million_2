using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine;

namespace SetQuestionDataBase
{
    public partial class QuestionForm : Form
    {
        //string _fileName = "222.xml";
        private QuestionsBase _qbase;
        private List<Question> _questions;

        public QuestionForm()
        {
            InitializeComponent();
            SetComboBoxItems();
            _qbase = new QuestionsBase();
            _questions = new List<Question>();
        }

        private void SetComboBoxItems()
        {
            //cbxPrice.Items.Add(Convert.ToInt32(QuestionPrice.Price1));
            //cbxPrice.Items.Add(Convert.ToInt32(QuestionPrice.Price2));
            //cbxPrice.Items.Add(Convert.ToInt32(QuestionPrice.Price3));

            cbxPrice.Items.Add(QuestionPrice.Price1);
            cbxPrice.Items.Add(QuestionPrice.Price2);
            cbxPrice.Items.Add(QuestionPrice.Price3);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = tbxQuestionName.Text;
            //Dictionary<string, bool> answers = new Dictionary<string, bool>();
            //answers.Add(txbAnswer1.Text, chbxTrue1.Checked);
            //answers.Add(txbAnswer2.Text, chbxTrue2.Checked);
            //answers.Add(txbAnswer3.Text, chbxTrue3.Checked);
            //answers.Add(txbAnswer4.Text, chbxTrue4.Checked);

            List<Answer> answers = new List<Answer>();
            answers.Add(new Answer(txbAnswer1.Text, chbxTrue1.Checked));
            answers.Add(new Answer(txbAnswer2.Text, chbxTrue2.Checked));
            answers.Add(new Answer(txbAnswer3.Text, chbxTrue3.Checked));
            answers.Add(new Answer(txbAnswer4.Text, chbxTrue4.Checked));
            QuestionPrice price = (QuestionPrice)cbxPrice.SelectedItem; // .ValueMember;

            int id = 0;//qbase.LastId;
            Question question = new Question(id, name, answers, price);

            lblId.Text = id.ToString();

            //qbase = new QuestionsBase();
            //_qbase.Add(question);
            _questions.Add(question);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _qbase.Save(_questions);
        }
    }
}
