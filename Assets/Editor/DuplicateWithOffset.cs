using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class DuplicateWithOffset : EditorWindow
{
    private Vector3 offset = new Vector3(2, 0, 0);
    private int copies = 1;
    
    [MenuItem("Tools/Duplicate With Offset")]
    public static void ShowWindow()
    {
        GetWindow<DuplicateWithOffset>("Duplicate With Offset");
    }
    
    void OnGUI()
    {
        GUILayout.Label("Duplicate Settings", EditorStyles.boldLabel);
        
        offset = EditorGUILayout.Vector3Field("Offset", offset);
        copies = EditorGUILayout.IntField("Number of Copies", copies);
        
        GUILayout.Space(10);
        
        if (GUILayout.Button("Duplicate Selected Objects"))
        {
            DuplicateSelectedObjects();
        }
        
        if (GUILayout.Button("Duplicate As Child"))
        {
            DuplicateAsChild();
        }
    }
    
    private void DuplicateSelectedObjects()
    {
        if (Selection.gameObjects.Length == 0)
        {
            Debug.LogWarning("No objects selected!");
            return;
        }
        
        List<GameObject> newObjects = new List<GameObject>();
        
        foreach (GameObject selected in Selection.gameObjects)
        {
            for (int i = 0; i < copies; i++)
            {
                GameObject newObject = Instantiate(selected);
                newObject.name = selected.name + " (Copy)";
                
                // Устанавливаем позицию со смещением
                Vector3 newPosition = selected.transform.position + offset * (i + 1);
                newObject.transform.position = newPosition;
                
                // Устанавливаем тот же родитель
                newObject.transform.SetParent(selected.transform.parent);
                
                newObjects.Add(newObject);
            }
        }
        
        // Выделяем новые объекты
        Selection.objects = newObjects.ToArray();
        
        Debug.Log($"Duplicated {Selection.gameObjects.Length} objects with offset");
    }
    
    private void DuplicateAsChild()
    {
        if (Selection.gameObjects.Length == 0)
        {
            Debug.LogWarning("No objects selected!");
            return;
        }
        
        List<GameObject> newObjects = new List<GameObject>();
        
        foreach (GameObject selected in Selection.gameObjects)
        {
            for (int i = 0; i < copies; i++)
            {
                GameObject newObject = Instantiate(selected);
                newObject.name = selected.name + " (Child Copy)";
                
                // Устанавливаем родителем исходный объект
                newObject.transform.SetParent(selected.transform);
                
                // Устанавливаем локальную позицию со смещением
                Vector3 localOffset = offset * (i + 1);
                newObject.transform.localPosition = localOffset;
                newObject.transform.localRotation = Quaternion.identity;
                newObject.transform.localScale = Vector3.one;
                
                newObjects.Add(newObject);
            }
        }
        
        Selection.objects = newObjects.ToArray();
        
        Debug.Log($"Duplicated {Selection.gameObjects.Length} objects as children with offset");
    }
    
    // Добавляем пункт в контекстное меню
    [MenuItem("GameObject/Duplicate With Offset", false, 0)]
    static void DuplicateWithOffsetContextMenu()
    {
        ShowWindow();
    }
}