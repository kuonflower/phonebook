using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> phoneBook;
        public Form1()
        {
            InitializeComponent();

            //電話帳に名前を登録する

            this.phoneBook = new Dictionary<string, string>();

            //ファイルからデータを読み込む
            ReadFromFile();


            this.phoneBook.Add("山田一郎", "xxx-1234-1111");
            this.phoneBook.Add("山田二郎", "xxx-1234-2222");
            this.phoneBook.Add("山田三郎", "xxx-1234-3333");
            this.phoneBook.Add("山田四郎", "xxx-1234-4444");

            foreach(KeyValuePair<string,string> data in phoneBook)
            {
                this.nameList.Items.Add(data.Key);
            }
        }

        private void ReadFromFile()
        {
            using(System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\data.txt"))
            {
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    string[] data = line.Split(',');
                    this.phoneBook.Add(data[0], data[1]);
                }
            }

        }

        private void nameSelected(object sender, EventArgs e)
        {
            string name = this.nameList.Text;
            this.phoneNumber.Text = this.phoneBook[name];
        }
    }
}
