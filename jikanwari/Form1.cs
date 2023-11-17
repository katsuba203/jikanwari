using System.Configuration;
using System.Data;

namespace jikanwari
{
    public partial class Form1 : Form
    {
        Label[,] jLabels = new Label[4, 5];
        Label[,] kLabels = new Label[4, 5];

        public Form1()
        {
            InitializeComponent();
            setLabels();

        }
        private void setLabels()
        {
            //éˆã∆ñºÉâÉxÉã
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
            //çuétñºÉâÉxÉã
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
            //èâä˙âª
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    jLabels[i, j].Text = "ñ¢äÑìñ";
                    kLabels[i, j].Text = "ñ¢äÑìñ";
                }
            }

        }

        private void viewLabels(JyugyouData jyugyouData, JikanwariData jikanwariData)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int id = jikanwariData.jikanwari[i,j];
                    jLabels[i, j].Text = "NULL";
                     kLabels[i, j].Text = "NULL";
                    DataRow[] jdrs = jyugyouData.jTable.Select("Id="+id);
                    if (jdrs != null)
                    {
                        jLabels[i, j].Text = jdrs[0]["jyugyouName"].ToString();
                        int kId= (int)jdrs[0]["kousiID"];
                        DataRow[] kdrs = jyugyouData.kTable.Select("kousiID=" + id);
                        //if (kdrs[0] != null)
                        //{
                             kLabels[i, j].Text = kdrs[0]["kousiName"].ToString();
                        //}


                    }
                        
                   
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
            JyugyouData jyugyouData = new JyugyouData();
            jyugyouData.SetJyugyouData();
            CreateJikanwari createJikanwari = new CreateJikanwari(jyugyouData);
            viewLabels(jyugyouData, createJikanwari.jikanwariData);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] num = { 1, 2, 3, };
            int[] num2 = num;
            num2[0] = 0;
        }


    }
}