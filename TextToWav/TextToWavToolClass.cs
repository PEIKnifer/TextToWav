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

        string folderName = "OutPut";

        string baseFolderName;

        private string _aFileNameStr;

        private bool _haveFileName;

        private string nPath;

        private string lFName = ".wav";

        //private List<string> _textList;

        public TextToWavToolClass(string toolText)
        {
            _haveFileName = false;
            _aFileNameStr = "";
            //_textList = new List<string>();
            baseFolderName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
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
            Console.WriteLine("开始检查违规反斜杠字符");
            toolText= CheckSelfString(toolText,'\n');
            Console.WriteLine("违规检测玩步骤完成。。。");
            for (int i = 0; i < toolText.Length; i++)
            {
                if (toolText[i] == '\n' || toolText[i] == '\r' || i == toolText.Length - 1)
                {
                    if (i == toolText.Length - 1)
                    {
                        toolString += toolText[toolText.Length - 1];
                    }
                    if (toolString.Trim().Length == 0)
                    {
                        Console.WriteLine("发现空内容无法生成!");
                        Console.WriteLine("当前位置 --> " + i);
                        Console.WriteLine("文本总内容 --> ");
                        Console.WriteLine(toolText);
                        toolString = ",";
                        //return;
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

            int OpNum = 0;
            if (operationText.Count >= 4)
            {
                if (operationText[operationText.Count - 4][0] == '/')
                {
                    OpNum++;
                    lFName = operationText[operationText.Count - 4].Substring(1, operationText[operationText.Count - 4].Length - 1);
                    while (lFName[lFName.Length - 1] == '\r' || lFName[lFName.Length - 1] == '\n')
                    {
                        lFName = lFName.Substring(0, lFName.Length - 1);
                    }
                    Console.WriteLine("检测到自定义音频格式，执行自定义音频格式配置");

                    if (lFName == ".mp3" || lFName == ".MP3" || lFName == ".Mp3")
                    {
                        lFName = ".mp3";
                    }
                    else if (lFName == ".wav" || lFName == ".WAV" || lFName == ".Wav")
                    {
                        lFName = ".wav";
                    }
                    else
                    {
                        lFName = ".wav";
                        Console.WriteLine("无法从配置表内获取标准自定义音频格式，执行默认音频格式配置");
                        Console.WriteLine("本程序仅支持Mp3与Wav格式音频输出");
                    }

                    Console.WriteLine("当前自定义音频格式 --> " + lFName);
                    operationText.RemoveAt(operationText.Count - 4);
                }
                else
                {
                    Console.WriteLine("无法从配置表内获取自定义音频格式，执行默认音频格式配置");
                }

                if (operationText[operationText.Count - 3][0] == '/')
                {
                    OpNum++;
                    baseFolderName = operationText[operationText.Count - 3].Substring(1, operationText[operationText.Count - 3].Length - 1);
                    while (baseFolderName[baseFolderName.Length - 1] == '\r' || baseFolderName[baseFolderName.Length - 1] == '\n')
                    {
                        baseFolderName = baseFolderName.Substring(0, baseFolderName.Length - 1);
                    }
                    Console.WriteLine("检测到自定义路径，执行自定义配置路径");
                    Console.WriteLine("路径位置 --> " + baseFolderName);
                    operationText.RemoveAt(operationText.Count - 3);
                }
                else
                {
                    Console.WriteLine("无法从配置表内获取路径配置规则，执行默认路径配置");
                }



                if (operationText[operationText.Count - 2][0] == '/')
                {
                    OpNum++;
                    _haveFileName = true;
                    if (operationText[operationText.Count - 2].Length > 1)
                    {
                        _aFileNameStr = operationText[operationText.Count - 2].Substring(1, operationText[operationText.Count - 2].Length - 1);
                        _aFileNameStr = _aFileNameStr.Substring(0, _aFileNameStr.Length - 1);
                    }
                    else
                        _aFileNameStr = "";
                    Console.WriteLine("检测到自定义名称，执行自定义名称配置");
                    Console.WriteLine("自定义名称 --> " + _aFileNameStr);
                    operationText.RemoveAt(operationText.Count - 2);
                }
                else
                {
                    Console.WriteLine("无法从配置表内获取名称配置规则，执行默认命名");
                }



                if (operationText[operationText.Count - 1][0] == '/')
                {
                    OpNum++;
                    if (operationText[operationText.Count - 1].Length > 1)
                    {
                        folderName = operationText[operationText.Count - 1].Substring(1, operationText[operationText.Count - 1].Length - 1);
                        //folderName = folderName.Substring(0, folderName.Length - 1);
                    }
                    else
                        folderName = "";

                    Console.WriteLine("检测到自定义文件夹名称，执行自定义文件夹配置");
                    Console.WriteLine("自定义文件夹名称 --> " + folderName);
                    operationText.RemoveAt(operationText.Count - 1);
                }
                else
                {
                    Console.WriteLine("无法从配置表内获取文件夹配置规则，执行默认文件夹配置");
                }

            }
            else
            {
                Console.WriteLine("无法从配置表内获取配置规则，执行默认配置");
                Console.WriteLine("操作配置数组长度 --> " + operationText.Count);
            }
            if (OpNum > 0)
            {
                Console.WriteLine(" 开始执行自定义配置特殊字符识别。。。 ");
                for (int i = 0; i < operationText.Count - 4; i++)
                {
                    Console.WriteLine(" 当前处理位置 --> " + i + " --> " + operationText[i]);
                    operationText[i] = operationText[i].Replace('_', ',');
                    Console.WriteLine(" 单句处理完成 --> " + operationText[i]);
                }
                Console.WriteLine(" 自定义配置特殊字符配置完成，自定义配置未处理。。。 ");
            }
            else
            {
                Console.WriteLine(" 开始执行一般特殊字符识别。。。 ");
                for (int i = 0; i < operationText.Count; i++)
                {
                    Console.WriteLine(" 当前处理位置 --> " + i + " --> " + operationText[i]);
                    operationText[i] = operationText[i].Replace('_', ',');
                    Console.WriteLine(" 单句处理完成 --> " + operationText[i]);
                }
                Console.WriteLine(" 一般特殊字符配置完成。。。 ");
            }

            Console.WriteLine("正在检测文件夹路径合法性。。。");
            nPath = System.IO.Path.Combine(baseFolderName, folderName);
            Console.WriteLine("文件夹路径 --> " + nPath);

            if (!Directory.Exists(nPath))
            {
                Directory.CreateDirectory(nPath);
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

                if (_haveFileName)
                {
                    fileNameStr = _aFileNameStr;
                    filePath = nPath + @"\" + i.ToString("D3") + fileNameStr + lFName;
                }
                else
                {
                    filePath = nPath + @"\" + "ID" + i + "_" + fileNameStr + lFName;
                }

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
                Console.WriteLine("File Build Complete %" + (int)((100 / (float)text.Count) * (i + 1)) + "...");
            }
        }
        private string CheckSelfString(string toolStr,char keyWord)
        {
            Console.WriteLine("检测函数开始检测违规字符");
            string rStr=null;
            int num = 0;
            for (int i = 0; i < toolStr.Length; i++)
            {
                if (toolStr[i] != keyWord)
                    rStr += toolStr[i];
                else
                    num++;
            }
            Console.WriteLine("函数运行完成，共有"+num+"处违规字符");
            return rStr;
        }
    }
}
