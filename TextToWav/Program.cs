using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TextToWav
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("解析程序初始化");
            Console.WriteLine("当前程序运行路径" + System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Text\Text.txt");

            string folderPath ="";

            try
            {
                folderPath = ReadData(args[0]);
            }
            catch
            {
                Console.WriteLine("无法通过配置文件获取。。。尝试从当前路径获取配置文件。。。");
                try
                {
                    Console.WriteLine("正在尝试从当前路径获取配置文件。。。");
                    folderPath = ReadData(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Text\Text.txt");
                }
                catch
                {
                    Console.WriteLine("当前路径配置文件获取失败。。。");
                    Console.WriteLine("自动修复程序启动。。。");
                    folderPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Text";
                    if (false == System.IO.Directory.Exists(folderPath))
                    {
                        //创建文件夹
                        Directory.CreateDirectory(folderPath);
                    }
                    if (Directory.Exists(folderPath))
                    {
                        Console.WriteLine("自动修复程序执行中 。。。 50% --> Text 文件夹成功创建");
                    }
                    else
                    {
                        Console.WriteLine("自动修复程序执行出现致命错误 Text 文件夹创建失败");
                    }
                    folderPath = folderPath + @"\Text.txt";
                    if (!System.IO.File.Exists(folderPath))
                    {
                        //没有则创建这个文件
                        FileStream fs1 = new FileStream(folderPath, FileMode.Create, FileAccess.Write);
                        System.IO.File.SetAttributes(folderPath, FileAttributes.Normal);
                        StreamWriter sw = new StreamWriter(fs1);
                        sw.Close();
                        fs1.Close();
                    }
                    if (!System.IO.File.Exists(folderPath))
                    {
                        Console.WriteLine("自动修复程序执行出现致命错误 Text 文件夹创建失败");
                        Console.WriteLine("自动修复程序意外停止，请检查运行环境以及路径配置");
                    }
                    else
                    {
                        Console.WriteLine("自动修复程序执行中 。。。 100% --> Text.txt 文件成功创建");
                        Console.WriteLine("请将需要生成的语音按格式写入TXT文件，写入后重启程序生成，TXT文件路径位于工程文件夹下 Text/Text.txt");
                    }
                    Console.WriteLine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Text\Text.txt");

                    Console.WriteLine("System Close ...");

                    Console.WriteLine("Enter a key to continue ...");
                    Console.ReadLine();
                    return;
                }
            }

            try
            {
                if (folderPath.Length <= 0)
                {
                    Console.WriteLine("操作字符串空错误。。。");
                }
                TextToWavToolClass tool = new TextToWavToolClass(folderPath);
            }
            catch(Exception e)
            {
                Console.WriteLine("文件生成失败。。。");
                Console.WriteLine("失败信息：" + e);
            }
    Console.ReadLine();
        }

        public static string ReadData(string txtPath)
        {
            //C#读取TXT文件之建立  FileStream 的对象,说白了告诉程序,   
            //文件在那里,对文件如何 处理,对文件内容采取的处理方式   
            StreamReader sr=null;
            FileStream fs=null;
            try
            {
                fs = new FileStream(txtPath, FileMode.Open, FileAccess.Read);
                //仅 对文本 执行  读写操作   
                sr = new StreamReader(fs, Encoding.Default);
            }
            catch
            {

            }
            //定位操作点,begin 是一个参考点   
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            //读一下，看看文件内有没有内容，为下一步循环 提供判断依据   
            //sr.ReadLine() 这里是 StreamReader的要领  可不是 console 中的~    
            string str = sr.ReadToEnd();//假如  文件有内容    
            //while (str != null)
            //{
            //    //输出字符串，str 在上面已经定义了 读入一行字符    
            //    Console.WriteLine("{0}", str);
            //    //这里我的理会是 当输出一行后，指针移动到下一行~   
            //    //下面这句话就是 判断 指针所指这行能无法 有内容~   
            //    str = sr.ReadLine();
            //}
            ////C#读取TXT文件之关上文件，留心顺序，先对文件内部执行 关上，然后才是文件~   
            sr.Close();
            fs.Close();
            return str;
        }   
        
        
    }
}
