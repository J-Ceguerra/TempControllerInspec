using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[InitializeOnLoad]
public class Test2 {

    static Test2() {
        Debug.Log("Test2 Constructor");
        EditorApplication.update += TestUpdate;
    }

    private static void TestUpdate() {
        Debug.Log("Test2 Update");
    }

    private static void RemoveSubscription() {
        
    }
}
