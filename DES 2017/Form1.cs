using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using Quantum.Bell;


namespace DES_2017
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Кодирование Информации \n Сделали Наконечный К.В и Прищеп Н.А");



        }
        
        //List<string> message = new List<string>();
        DES DESalg = DES.Create();
        int key_lenght = 8;
       






        private void button1_Click(object sender, EventArgs e)
        {
            Encoding ascii = Encoding.ASCII;
            // надо сделать ввод с формы
            string dest_encrypt = "enkr.txt";
            
           // string[] Text = DESklass.Read_from_file("tekst1.txt");            
           // byte[] KEY = File.ReadAllBytes("file.encr");

           // с одной строкой
            string Text = DESklass.Read_from_file_string("tekst1.txt");            
            byte[] KEY = File.ReadAllBytes("key.encr");

            // шифрование
            DESklass.EncryptTextToFile(Text, dest_encrypt, KEY, DESalg.IV);
            

          //  string[] enkrText = DESklass.Read_from_file(dest_encrypt);
          // с одной строкой
            string enkrText = DESklass.Read_from_file_string(dest_encrypt);


           // richTextBox1.Lines = Text;
            // с одной строкой
             richTextBox1.Text = Text;

            richTextBox2.Text = DESklass.Text_to_ascii(Text);
            
            //richTextBox3.Lines = enkrText;
            // с одной строкой
            richTextBox3.Text = enkrText;

            richTextBox4.Text = DESklass.Text_to_ascii(enkrText); 

            // запись в файл
            File.WriteAllText("Text_ascii", DESklass.Text_to_ascii(Text), Encoding.GetEncoding(1251));            
            
            File.WriteAllText("DECRText_ascii", DESklass.Text_to_ascii(enkrText), Encoding.GetEncoding(1251));

           

          

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            Encoding ascii = Encoding.ASCII;
            string dest_encrypt = "enkr.txt";
            string dest_decrypt = "dekr.txt";


            //string[] enkrText = DESklass.Read_from_file("enkr.txt");
            // с одной строкой
            string enkrText = DESklass.Read_from_file_string("enkr.txt");

            byte[] KEY = File.ReadAllBytes("key.encr");
            
            
            //string[] dekrText = DESklass.DecryptTextFromFile(dest_encrypt, KEY, DESalg.IV);
            // с одной строкой
            string dekrText = DESklass.DecryptTextFromFile_string(dest_encrypt, KEY, DESalg.IV);





            //richTextBox5.Lines = dekrText;
            // с одной строкой
            richTextBox5.Text = dekrText;         
            
            richTextBox6.Text = DESklass.Text_to_ascii(dekrText);
           
           
            File.WriteAllText("DEKRText_ascii",DESklass.Text_to_ascii(enkrText), Encoding.GetEncoding(1251));
            DESklass.Write_to_file(dest_decrypt, dekrText);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DES DESalg = DES.Create();              
            

            
            byte[] KEY = DESalg.Key;
            
            //подгонка длины ключа          
            switch (key_lenght)
            {
                case 8:
                   for(int i= 1; i<8;i++)
                    { KEY[i] = 0; }
                    break;
                case 16:
                    for (int i = 2; i < 8; i++)
                    { KEY[i] = 0; }
                    break;                    
                case 32:
                    for (int i = 4; i < 8; i++)
                    { KEY[i] = 0; }
                    break;
                case 64:
                    break;
            }



            //вывод ключа
            string Key_show ="" ;          
            foreach (var b in KEY)
            {
                Key_show  += Convert.ToString(b, 2).PadLeft(8,'0') + " \n";                
            }           
            
            richTextBox7.Text = Key_show;

            File.WriteAllBytes("key.encr",KEY);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            key_lenght = 8;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            key_lenght = 16;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            key_lenght = 32;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            key_lenght = 64;
        }

        private  void button4_Click(object sender, EventArgs e)
        {
            //string[] K_L = new string[] { Convert.ToString(key_lenght) };

            //var bell = new Driver();
            // bell.run(K_L);
            byte[] KEY = File.ReadAllBytes(Path.Combine("C:/DESK/key.encr"));
            byte[] KEY_F = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < KEY.Length; i++)
            { KEY_F[i] = KEY[i]; }
            string Key_show = "";
            foreach (var b in KEY_F)
            {
                Key_show += Convert.ToString(b, 2).PadLeft(8, '0') + " \n";
            }
            richTextBox7.Text = Key_show;

            File.WriteAllBytes("key.encr", KEY);


        }
    }
}
