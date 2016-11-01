using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour
{

    public TextAsset TextFile;
    private string[] TextLines;

	// Use this for initialization
	void Start () {
        // Making sure the text file is assigned in the editor.
	    if (TextFile != null)
	    {
            // Assigns TextLines to each line in the text file. \n represents a newline character
            // so we are creating a collection of text split up by each newline.
	        TextLines = TextFile.text.Split('\n');
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(Controls.ActionKey))
	    {
	        
	    }
	}
}
