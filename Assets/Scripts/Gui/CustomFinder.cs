using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class CustomFinder : EditorWindow
{
    string searchQuery = "";
    string previousQuery = "";
    int index = 0;
    GameObject[] searchedObjects;


    [MenuItem("Window/CustomFinder")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CustomFinder));
    }

    void FindNewObjectsTypeOf(string type)
    {
        Type textType = null;
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            textType = assembly.GetType(type);
            if (textType != null)
                break;
        }
        searchedObjects = FindObjectsOfType(textType) as GameObject[];
        index = 0;
    }

    void SelectNextObjectInHierarchy()
    {
        if (searchedObjects == null)
            return;
        if (searchedObjects.Length == 0)
            return;
        if (index >= searchedObjects.Length)
            index = 0;
        index++;
        Selection.activeObject = searchedObjects[index];
    }


    void OnGUI()
    {
        GUILayout.Label("Enter the type you want to find on the stage.", EditorStyles.boldLabel);
        searchQuery = EditorGUILayout.TextField("Search Query", searchQuery);
        if (GUILayout.Button("Find Next"))
        {
            try
            {
                if (previousQuery != searchQuery)
                {
                    previousQuery = searchQuery;
                    FindNewObjectsTypeOf(searchQuery);
                }
                SelectNextObjectInHierarchy();
            }
            catch (TypeLoadException e)
            {
                Debug.Log(e.Message);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

}
