using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToWav
{
    public class Test
    { }
        /*
    /// <summary>
    /// Unity 设置参考类
    /// </summary>
    class UnityTTWSet
    {
        ////private static ExcelCC excel;
        ////点击导出音频的文本
        //[MenuItem("Assets/Export Audio Text", false, 0)]
        //public static void ExportAudioText()
        //{
        //    if (Selection.objects != null)
        //    {
        //        string path = "";
        //        //string savePath = EditorUtility.SaveFolderPanel("audio text", Application.dataPath, "");
        //        //if (string.IsNullOrEmpty(savePath))
        //        //    return;

        //        bool isExport = false;

        //        foreach (var item in Selection.objects)
        //        {
        //            path = AssetDatabase.GetAssetPath(item);
        //            if (Path.GetExtension(path).Equals(".txt"))
        //            {
        //                TextAsset asset = item as TextAsset;
        //                if (asset == null)
        //                    return;
        //                IDataTable<DtStep> data = GetDtStep(asset, path);
        //                if (data == null)
        //                {
        //                    Debug.LogError("不是步骤内容的文本!!!" + path);
        //                    return;
        //                }

        //                //保存语音文本
        //                SaveAuidoTextWT(data, Path.GetFileNameWithoutExtension(path), System.IO.Path.GetFileNameWithoutExtension(path));

        //                Debug.Log("ASDLKJASLDKJALSKDJ" + Application.dataPath.Substring(0, Application.dataPath.Length - 7) + @"\Tools\config\" + System.IO.Path.GetFileNameWithoutExtension(path));

        //                //excel = new ExcelCC(Application.dataPath.Substring(0, Application.dataPath.Length - 7) + @"\Tools\config\" + System.IO.Path.GetFileNameWithoutExtension(path));
        //                //有成功导出
        //                isExport = true;
        //            }
        //        }
        //        string dirPath = Application.dataPath.Substring(0, Application.dataPath.Length - 7) + @"\Tools\TestTextTool";
        //        //打开文件夹
        //        //if(isExport)
        //        // EditorUtility.OpenWithDefaultApp(dirPath);
        //        Debug.Log(path + "语音生成完毕");
        //    }
        //}

        ////获取文本步骤内容
        //private static IDataTable<DtStep> GetDtStep(TextAsset asset, string path)
        //{
        //    DataTableManager dataTable = VrCoreSystemEntity.GetModule<DataTableManager>();
        //    IDataTable<DtStep> data = null;

        //    if (dataTable.LoadDataTable<DtStep>(asset.text, path))
        //    {
        //        data = dataTable.GetDataTable<DtStep>(path);
        //    }

        //    return data;
        //}

        ////保存声音文本
        //private static void SaveAuidoText(IDataTable<DtStep> data, string savePath, string assetName)
        //{
        //    string dirPath = Path.Combine(savePath, assetName);
        //    if (!Directory.Exists(dirPath))
        //        Directory.CreateDirectory(dirPath);

        //    string assetPath = "";
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        assetPath = Path.Combine(dirPath, i.ToString("D3") + ".txt");
        //        File.WriteAllText(assetPath, data[i].TipText);
        //    }
        //}
        //private static void SaveAuidoTextWT(IDataTable<DtStep> data, string assetName, string folderName)
        //{
        //    string dirPath = Application.dataPath.Substring(0, Application.dataPath.Length - 7) + "/Tools/TestTextTool/Text/Text.txt";
        //    Debug.Log(dirPath);
        //    //         if (!Directory.Exists(dirPath))
        //    //         {
        //    //             Directory.CreateDirectory(dirPath);
        //    //         }

        //    string assetPath = null;
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        assetPath += data[i].TipText + "\r";
        //    }
        //    assetPath += ("/" + ".mp3" + "\r" + "/" + Application.dataPath + @"\VrCoreEntity\Audio" + "\r" + "/" + "\r" + "/" + folderName);
        //    while (assetPath[0] == '\r' || assetPath[0] == '\n')
        //    {
        //        assetPath = assetPath.Substring(1, assetPath.Length - 1);
        //    }
        //    File.WriteAllText(dirPath, assetPath);
        //    OpenTTWEXE("TextToWav.exe", Application.dataPath.Substring(0, Application.dataPath.Length - 7) + @"\Tools\TestTextTool");
        //    Debug.Log("Open EXE In " + Application.dataPath.Substring(0, Application.dataPath.Length - 7) + @"\Tools\TestTextTool");
        //}
        //private static void OpenTTWEXE(string name, string path)
        //{
        //    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
        //    info.FileName = name;
        //    info.Arguments = path;
        //    info.WorkingDirectory = path;
        //    System.Diagnostics.Process pro;
        //    try
        //    {
        //        pro = System.Diagnostics.Process.Start(info);
        //    }
        //    catch
        //    {
        //        Debug.Log("遇到环境错误，自动修复驱动运行，执行绝对路径尝试修复环境");
        //        Debug.Log("EATE Try To Open EXE In --> " + path + "\\" + name);
        //        try
        //        {
        //            pro = System.Diagnostics.Process.Start(path + "\\" + name);
        //        }
        //        catch (System.ComponentModel.Win32Exception ex)
        //        {
        //            Debug.Log("程序遇到致命错误 --> " + ex);
        //        }
        //        return;
        //    }
        //    Debug.Log("外部程序启动时间：" + pro.StartTime);
        //    pro.WaitForExit(30000);
        //    if (pro.HasExited == false)
        //    {
        //        Debug.Log("有主程序强行终止外部程序运行！");
        //        pro.Kill();
        //    }
        //    else
        //    {
        //        Debug.Log("由程序正常退出");
        //        Debug.Log("外部程序结束运行时间为:" + pro.ExitTime);
        //        Debug.Log("外部程序结束返回值为:" + pro.ExitCode);
        //    }
        //}*/
}
