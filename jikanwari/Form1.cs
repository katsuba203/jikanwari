using System.Configuration;
using System.Data;

namespace jikanwari
{
    public partial class Form1 : Form
    {
        Label[,] jLabels = new Label[4, 5];
        Label[,] kLabels = new Label[4, 5];
        Control Control = new Control();


        public Form1()
        {
            InitializeComponent();
            setLabels();
            
            string[] item = Control.jyugyouData.GetClass();
            comboBox1.Items.AddRange(item);


        }
        private void setLabels()
        {
            //授業名ラベル
            jLabels[0, 0] = jMon1;
            jLabels[1, 0] = jMon2;
            jLabels[2, 0] = jMon3;
            jLabels[3, 0] = jMon4;

            jLabels[0, 1] = jTue1;
            jLabels[1, 1] = jTue2;
            jLabels[2, 1] = jTue3;
            jLabels[3, 1] = jTue4;

            jLabels[0, 2] = jWed1;
            jLabels[1, 2] = jWed2;
            jLabels[2, 2] = jWed3;
            jLabels[3, 2] = jWed4;

            jLabels[0, 3] = jThu1;
            jLabels[1, 3] = jThu2;
            jLabels[2, 3] = jThu3;
            jLabels[3, 3] = jThu4;

            jLabels[0, 4] = jFri1;
            jLabels[1, 4] = jFri2;
            jLabels[2, 4] = jFri3;
            jLabels[3, 4] = jFri4;
            //講師名ラベル
            kLabels[0, 0] = kMon1;
            kLabels[1, 0] = kMon2;
            kLabels[2, 0] = kMon3;
            kLabels[3, 0] = kMon4;

            kLabels[0, 1] = kTue1;
            kLabels[1, 1] = kTue2;
            kLabels[2, 1] = kTue3;
            kLabels[3, 1] = kTue4;

            kLabels[0, 2] = kWed1;
            kLabels[1, 2] = kWed2;
            kLabels[2, 2] = kWed3;
            kLabels[3, 2] = kWed4;

            kLabels[0, 3] = kThu1;
            kLabels[1, 3] = kThu2;
            kLabels[2, 3] = kThu3;
            kLabels[3, 3] = kThu4;

            kLabels[0, 4] = kFri1;
            kLabels[1, 4] = kFri2;
            kLabels[2, 4] = kFri3;
            kLabels[3, 4] = kFri4;
            //初期化
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    jLabels[i, j].Text = "未割当";
                    kLabels[i, j].Text = "未割当";
                }
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            JyugyouData jyugyouData = new JyugyouData();
            jyugyouData.SetJyugyouData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control.CreateJikanwari(jLabels, kLabels);

            //viewLabels(jyugyouData, createJikanwari.jikanwariData);

        }

        private void button3_Click(object sender, EventArgs e)
        {


            Form2 form2 = new Form2();
            this.Visible = false;
            form2.ShowDialog();

        }


    }
}