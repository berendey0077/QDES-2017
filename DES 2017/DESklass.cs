using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace DES_2017
{
    class DESklass
    {
        public static string[] Read_from_file(string FileName)
        {
            string[] lines = File.ReadAllLines(FileName, Encoding.GetEncoding(1251));

            return lines;
        }
        public static string[] Read_from_file_ASCII(string FileName)
        {
            string[] lines = File.ReadAllLines(FileName, Encoding.ASCII);

            return lines;
        }

        ///////////////////////////
        public static string Read_from_file_string(string FileName)
        {
            string lines = File.ReadAllText(FileName, Encoding.GetEncoding(1251));

            return lines;
        }
        public static string Read_from_file_ASCII_string(string FileName)
        {
            string lines = File.ReadAllText(FileName, Encoding.ASCII);

            return lines;
        }
        //////////////////////
        
        public static void Write_to_file(string fileName, string[] lines)
        {
           
            File.WriteAllLines(fileName, lines, Encoding.GetEncoding(1251));
        }
        public static void Write_to_file_ASCII(string fileName, string[] lines)
        {

            File.WriteAllLines(fileName, lines, Encoding.ASCII);
        }


        //////////////////////////////////
        public static void Write_to_file(string fileName, string lines)
        {

            File.WriteAllText(fileName, lines, Encoding.GetEncoding(1251));
        }
        public static void Write_to_file_ASCII(string fileName, string lines)
        {

            File.WriteAllText(fileName, lines, Encoding.ASCII);
        }

        //////////////////////////////////
        public static string Text_to_ascii(string[] Text)
        {
            Encoding ascii = Encoding.ASCII;
            string _show = "";
            string finalLine = "";
            for (int i = 0; i <= Text.Length - 1; i++)
            {
                finalLine = finalLine + Text[i];
            }
            {
                Byte[] Bytes = ascii.GetBytes(finalLine);

                foreach (var b in Bytes)
                {
                    _show += Convert.ToString(b, 16) + "     ";

                }
            }
                       
            return _show;
        }

        //строка как строку ascii
        public static string Text_to_ascii(string Text)
        {
            Encoding ascii = Encoding.ASCII;
            string _show = "";         
            
            
                Byte[] Bytes = ascii.GetBytes(Text);

                foreach (var b in Bytes)
                {
                    _show += Convert.ToString(b, 16) + "     ";

                }
            

            return _show;
        }



        //шифровка массива строк
        public static void EncryptTextToFile(String[] Data, String FileName, byte[] Key, byte[] IV)
        {


                       
            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);
                
                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    DESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Create a StreamWriter using the CryptoStream.
                StreamWriter sWriter = new StreamWriter(cStream);

                // Write the data to the stream 
                // to encrypt it.

                

               // sWriter.WriteLine(Data);
                
                //сюда надо добавить запись множества строк в файл
               /**/ foreach (string str in Data)
                {
                    sWriter.WriteLine(str);// +'\n');
                }
               
                // Close the streams and
                // close the file.
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
            }

        }

        //шифровка одной строки
        public static void EncryptTextToFile(String Data, String FileName, byte[] Key, byte[] IV)
        {



            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    DESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Create a StreamWriter using the CryptoStream.
                StreamWriter sWriter = new StreamWriter(cStream);

                // Write the data to the stream 
                // to encrypt it.



                 sWriter.WriteLine(Data);

                //сюда надо добавить запись множества строк в файл
                /*
                foreach (string str in Data)
                {
                    sWriter.WriteLine(str);// +'\n');
                }
                */
                // Close the streams and
                // close the file.
                sWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
            }

        }

        //расшифровка в массив строк
        public static string[] DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                // Create or open the specified file. 
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    DESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create a StreamReader using the CryptoStream.
                StreamReader sReader = new StreamReader(cStream);

                // Read the data from the stream 
                // to decrypt it.
                //для одной
               // string val = sReader.ReadLine();
                
                //для множества строк
                string[] val = sReader.ReadToEnd().Split('\n');

                // Close the streams and
                // close the file.
                sReader.Close();
                cStream.Close();
                fStream.Close();

                // Return the string.
                
                return val;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
        }

        //расшифровка в одну строку
        public static string DecryptTextFromFile_string(String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                // Create or open the specified file. 
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a new DES object.
                DES DESalg = DES.Create();

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    DESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create a StreamReader using the CryptoStream.
                StreamReader sReader = new StreamReader(cStream);

                // Read the data from the stream 
                // to decrypt it.
                //для одной
                 string val = sReader.ReadLine();

                //для множества строк
                //string[] val = sReader.ReadToEnd().Split('\n');

                // Close the streams and
                // close the file.
                sReader.Close();
                cStream.Close();
                fStream.Close();

                // Return the string.

                return val;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
        }


    }
}
