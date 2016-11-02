using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBoxManager : MonoBehaviour {

    public GameObject DialogBox;
    public Text Dialog;

    public TextAsset TextFile;
    private string[] TextLines;

    public int CurrentLineNumber;
    public int EndAtLineNumber;

	// Use this for initialization
	void Start () {
        if (TextFile != null)
        {
            // Assigns TextLines to each line in the text file. \n represents a newline character
            // so we are creating a collection of text split up by each newline.
            TextLines = TextFile.text.Split('\n');
        }

        if (EndAtLineNumber == 0)
        {
            EndAtLineNumber = TextLines.Length;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        Dialog.text = TextLines[CurrentLineNumber];

	    if (DialogBox != null)
	    {
	        if (Input.GetKeyDown(Controls.ActionKey) &&
	            CurrentLineNumber < EndAtLineNumber)
	        {
	            CurrentLineNumber++;
	            if (CurrentLineNumber == EndAtLineNumber)
	            {
	                DialogBox.SetActive(false);
	            }
	        }
        }
    }
}
