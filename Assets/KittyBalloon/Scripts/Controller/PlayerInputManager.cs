using UnityEngine;
using System;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

    public struct InputTable {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Jump { get; set; }

        public bool Equals (InputTable other) {
            return this.Left.Equals(other.Left)
                && this.Right.Equals(other.Right)
                && this.Jump.Equals(other.Jump);
        }
    }

    private enum TInputType
    {
        Left,
        Right,
        Jump
    }

    public Action<InputTable> OnInputChanged;

    private InputTable _inputTable = new InputTable();

    private static TInputType GetInputType(Vector2 position)
    {
        Debug.Log((new Vector2(position.x / (float)Screen.width, position.y / (float)Screen.height)).ToString());
        if ((position.y / (float)Screen.height) < 0.2f)
        {
            if ((position.x / (float)Screen.width) < 0.125f)
            {
                return TInputType.Left;
            }
            else if ((position.x / (float)Screen.width) < 0.25f)
            {
                return TInputType.Right;
            }
        }
        return TInputType.Jump;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        InputTable newInput = new InputTable();

        foreach (Touch touch in Input.touches)
        {
            switch (GetInputType(touch.position))
            {
                case TInputType.Left:
                    newInput.Left = touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled;
                    break;
                case TInputType.Right:
                    newInput.Right = touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled;
                    break;
                case TInputType.Jump:
                    newInput.Jump |= touch.phase == TouchPhase.Began;
                    break;
            }
        }

        if (!newInput.Equals(_inputTable))
        {
            _inputTable = newInput;
            if (OnInputChanged != null)
                OnInputChanged(newInput);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
