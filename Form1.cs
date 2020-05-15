using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sasa05141519117
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scoringresultLabel.Text = "  ";
            resultLabel.Text = "  ";
            errorresultLabel.Text = "  ";
            errorattendLabel.Text = "  ";
            errortaskLabel.Text = "  ";
            errortestLabel.Text = "  ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double valueAttend = 9999;    //出席率用の整数型の変換
            double valueTask = 9999;      //課題提出率用の整数型の変換
            double valueTest = 9999;      //テスト結果用の整数型の変換

            inputCheck(attendtextBox.Text, out valueAttend);    //出席率の整数変換
            inputCheck(tasktextBox.Text, out valueTask);        //課題提出率の整数変換
            inputCheck(testtextBox.Text, out valueTest);        //テスト結果の整数変換

            //採点結果のエラー判別
            if(valueAttend < 1000 && valueTask < 1000 && valueTest < 1000)
            {
                //初期化
                errorresultLabel.Text = "  ";
                errorattendLabel.Text = "  ";
                errortaskLabel.Text = "  ";
                errortestLabel.Text = "  ";
                resultLabel.Text = "　　あなたの成績は　　　　　　　です";
                if (valueAttend < 60.0|| valueTask < 80.0 || valueTest < 60)
                {
                    scoringresultLabel.Text = "不可";
                }else if(valueTask == 100 && valueTest >= 80)
                {
                    scoringresultLabel.Text = "優";
                }else if(valueTest >= 70 && valueTask >= 90)
                {
                    scoringresultLabel.Text = "良";
                }
                else
                {
                    scoringresultLabel.Text = "可";
                }

            }
            else
            {
                resultLabel.Text = " ";
                scoringresultLabel.Text = " ";
                errorresultLabel.Text = "入力値にエラーがあります";
                errorattendLabel.Text = "出席率" + errorCheck(valueAttend);
                errortaskLabel.Text = "課題提出率"+errorCheck(valueTask);
                errortestLabel.Text = "テストの点数" + errorCheck(valueTask);
            }
        }

        private double inputCheck(string textValue, out double value)
        {
            if(double.TryParse(textValue, out value) == true)
            {
                value = double.Parse(textValue);
                if (value < 0 || value > 100)
                {
                    value = 4444;
                }
            }
            else
            {
                value = 9999;
            }
            return value;
        }

        private string errorCheck(double value)
        {
            string valueText;
            if(value == 9999)
            {
                valueText = "に数値データに入力してください。";
            }else if(value == 4444)
            {
                valueText = "に正常な値(0.0～100.0)を入力してください。";
            }
            else
            {
                valueText = "の入力値は正常です。";
            }
            return valueText;
        }
    }
}
