using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Million.GameEngine
{
    public class Answer
    {
        public string Name { get; set; }
        public bool IsTrue { get; set; }

        public Answer(string name, bool isTrue)
        {
            this.Name = name;
            this.IsTrue = isTrue;
        }

        public Answer ()
        {

        }

        public void Hide()
        {
            this.Name = string.Empty;
        }
    }
}
