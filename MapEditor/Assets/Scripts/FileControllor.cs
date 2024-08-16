using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Common;
public class FileControllor : MonoBehaviour 
{
    public string filepath;
public void OpenProject()
    {
        OpenFileDlg pth = new OpenFileDlg();
pth.structSize = System.Runtime.InteropServices.Marshal.SizeOf(pth);
//pth.filter = "json (*.json)";
pth.file = new string(new char[256]);
pth.maxFile = pth.file.Length;
pth.fileTitle = new string(new char[64]);
pth.maxFileTitle = pth.fileTitle.Length;

        pth.initialDir = Application.dataPath;  // default path  

        pth.title = "OpenJson";
pth.defExt = "json";
pth.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;
if (OpenFileDialog.GetOpenFileName(pth))
        {
            //


            filepath = pth.file;//select path
Debug.Log(filepath);
        }
    }
public void SaveProject()
    {
        SaveFileDlg pth = new SaveFileDlg();
pth.structSize = System.Runtime.InteropServices.Marshal.SizeOf(pth);
pth.filter = "json (*.json)";
pth.file = new string(new char[256]);
pth.maxFile = pth.file.Length;
pth.fileTitle = new string(new char[64]);
pth.maxFileTitle = pth.fileTitle.Length;
        pth.initialDir = Application.dataPath;  // default path  
        pth.title = "SaveJson"; 
pth.defExt = "json";
pth.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;
if (SaveFileDialog.GetSaveFileName(pth))
        {
            //
            Debug.Log("c");
            Debug.Log(Application.dataPath); 

             filepath = pth.file;//select path  
Debug.Log(filepath);
        }
    }
}
