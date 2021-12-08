using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FolderCreatowWizard : ScriptableWizard
{
    public bool createFolder;
    public string folderName;

    [MenuItem("Szpadel Gamedev/Folder Creator")]
    public static void OpenWizard()
    {
        DisplayWizard<FolderCreatowWizard>("Folder Creator", "Create");
    }

    private void OnWizardCreate()
    {
        if (!createFolder) return;

        if (EditorUtility.DisplayDialog("Confirm", "Are you sure that you want to create this folder?", "Yes", "No"))

        AssetDatabase.CreateFolder("Assets", folderName);
    }
}
