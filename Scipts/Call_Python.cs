using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注意  一定要引用下面这个命名空间
using System.Diagnostics;

public class Call_Python : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.Debug.Log("test");
            string[] arr = new string[2];
            arr[0] = "10";
            arr[1] = "20";
            RunPythonScript(arr);
        }
    }
    private static void RunPythonScript(string[] argvs)
    {
        Process p = new Process();
        string path = @"D:\Unity-worksave\DeepLearning\Assets\Scipts\unity.py";
        foreach (string temp in argvs)
        {
            path += " " + temp;
        }
        p.StartInfo.FileName = @"D:\Users\User\anaconda3\envs\fordemo\python.exe";

        p.StartInfo.UseShellExecute = false;
        p.StartInfo.Arguments = path;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.CreateNoWindow = true;

        p.Start();
        p.BeginOutputReadLine();
        p.OutputDataReceived += new DataReceivedEventHandler(Get_data);
        p.WaitForExit();
    }
    private static void Get_data(object sender, DataReceivedEventArgs eventArgs)
    {
        if (!string.IsNullOrEmpty(eventArgs.Data))
        {
            print(eventArgs.Data);
        }
    }
}