using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TextToWav
{
    public class TextToWavToolClass
    {

        /// <summary>
        /// 音量
        /// </summary>
        private int value = 100;
        /// <summary>
        /// 语速
        /// </summary>
        private int rate;

        FileStream file;

        string filePath;

        List<string> operationText;

        SpeechSynthesizer synth;

        string folderName="OutPut";

        string baseFolderName;

        public TextToWavToolClass(string toolText)
        {
            baseFolderName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!Directory.Exists(baseFolderName + folderName))
            {
                Directory.CreateDirectory(baseFolderName + folderName);
            }
            operationText = new List<string>();
            string toolString = "";
            try
            {
                synth = new SpeechSynthesizer();   //创建语音实例
                synth.Rate = -1; //设置语速,[-10,10]
                synth.Volume = 100; //设置音量,[0,100]
                while (operationText.Count > 0)
                {
                    operationText.RemoveAt(0);
                }
            }
            catch
            {
                Console.WriteLine("语音处理类初始化失败!!");
            }
            for (int i = 0; i < toolText.Length; i++)
            {
                if (toolText[i] == '\n' || i == toolText.Length - 1)
                {
                    if (i == toolText.Length - 1)
                    {
                        toolString += toolText[toolText.Length - 1];
                    }
                    if (toolString.Trim().Length == 0)
                    {
                        Console.WriteLine("空内容无法生成!", "错误提示");
                        return;
                    }
                    operationText.Add(toolString);
                    toolString = "";
                }
                else
                {
                    //if (textBox1.Text[i] == 'n')
                    //{

                    //}
                    //else
                    toolString += toolText[i];
                }
            }

            SaveFile(operationText);
            Console.WriteLine("工具处理结束");
        }

        /// <summary>
        /// 生成语音文件的方法
        /// </summary>
        /// <param name="text"></param>
        private void SaveFile(List<string> text)
        {
            synth = new SpeechSynthesizer();

            for (int i = 0; i < text.Count; i++)
            {
                StringBuilder titleBuilder = new StringBuilder(text[i]);
                foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
                    titleBuilder = titleBuilder.Replace(rInvalidChar.ToString(), string.Empty);

                string fileNameStr = "";
                if (titleBuilder.ToString().Length > 4)
                {
                    for (int t = 0; t < 4; t++)
                    {
                        fileNameStr += titleBuilder.ToString()[t];
                    }
                }
                else
                {
                    for (int t = 0; t < titleBuilder.ToString().Length; t++)
                    {
                        fileNameStr += titleBuilder.ToString()[t];
                    }
                }

                filePath = baseFolderName + folderName+@"\" +"ID"+i+"_"+ fileNameStr + ".wav";
                //filePath=Application.LocalUserAppDataPath + text[i] + ".wav";

                Console.WriteLine("在以下路径准备创建  " + filePath);
                file = File.Create(filePath);
                file.Close();

                synth.SetOutputToWaveFile(filePath);
                synth.Volume = value;
                synth.Rate = rate;

                synth.Speak(operationText[i]);
                synth.SetOutputToNull();


                Console.WriteLine("生成成功!在" + filePath + "路径中！", "提示");
                Console.WriteLine("File Build Complete %"+(int)((100/(float)text.Count)* (i+1) )+ "...");
            }
        }
    }
}
