using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[InitializeOnLoad]
public class Test2 {

    private static bool isSubscribed = false;
    private static bool debug = false;
    private static bool Run = true;

    static Test2() {
        printDebug("Test2 Constructor");
        RemoveSubscription();
        Run = false;
        if (Run) {
            AddSubscription();
        }
    }
    private static void AddSubscription() {
        printDebug("Test2 SubAdded");
        isSubscribed = true;
        EditorApplication.update += TestUpdate;
        SceneView.onSceneGUIDelegate += EditorGUIUpdate;
    }
    private static void RemoveSubscription() {
        printDebug("Test2 SubRemvd");
        isSubscribed = false;
        EditorApplication.update -= TestUpdate;
        SceneView.onSceneGUIDelegate -= EditorGUIUpdate;
    }

    private static void TestUpdate() {
        if (EditorApplication.isCompiling && isSubscribed) {
            printDebug("It was compiling");
            RemoveSubscription();
        }
        Debug.Log("Test2 Update");
    }

    private static void EditorGUIUpdate(SceneView sceneView) {
        Debug.Log("Test2 GUIUpdate");
        Handles.BeginGUI();
        EditorGUI.DrawRect(new Rect(5, 5, 5, 5), Color.cyan);
        Handles.EndGUI();
    }


    private static void printDebug(string _msg) {
        if (debug) {
            Debug.Log(_msg);
        }
    }
}
