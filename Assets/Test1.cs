using UnityEngine;
using System.Collections;

public class Test1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI() {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos.y = Screen.height - pos.y;
        Vector2 siz = new Vector2(100, 20);
        GUI.Label(new Rect(pos, siz), "Hello World!");
        pos.y += 50;
        GUI.TextField(new Rect(pos, siz), "ASLKDJASKLJ");
    }
}
