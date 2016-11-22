using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[InitializeOnLoad]
public class Test2 {

    private static bool isSubscribed = false;
    private static bool debug = true;

    static Test2() {
        printDebug("Test2 Constructor");
        RemoveSubscription();
        AddSubscription();
    }

    private static void TestUpdate() {
        if (EditorApplication.isCompiling && isSubscribed) {
            Debug.Log("It was compiling");
            RemoveSubscription();
        }
        Debug.Log("Test2 Update");
    }

    private static void AddSubscription() {
        printDebug("Test2 SubAdded");
        isSubscribed = true;
        EditorApplication.update += TestUpdate;
    }
    private static void RemoveSubscription() {
        printDebug("Test2 SubRemvd");
        isSubscribed = false;
        EditorApplication.update -= TestUpdate;
    }

    private static void printDebug(string _msg) {
        if (debug) {
            Debug.Log(_msg);
        }
    }
}
