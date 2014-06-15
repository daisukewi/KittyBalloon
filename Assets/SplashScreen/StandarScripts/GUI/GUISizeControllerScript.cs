using UnityEngine;
using System.Collections;

[ExecuteInEditMode()] 
public class GUISizeControllerScript : MonoBehaviour {
	
	public float width  	= 0.1f;
	public float height 	= 0.1f;
	
	private float realWidth 	= 0;
	private float realHeight 	= 0;
	private float realPixelInsetX 	= 0;
	private float realPixelInsetY 	= 0;
	
	public bool relativePixelInset = false;
	public float PixelInsetX  	= 0.0f;
	public float PixelInsetY 	= 0.0f;
	
	public bool useRelativeGUITextPosition = true;
	public bool useRelativeGUITextFontsize = true;
	public float TextRelativePixelOffsetX  	= 0.0f;
	public float TextRelativePixelOffsetY 	= 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		
		realWidth	 	= Screen.width * width;
		realHeight 		= Screen.height * height;
		
		realPixelInsetX	= Screen.width * PixelInsetX;
		realPixelInsetY	= Screen.height * PixelInsetY;
		
		//realWidth = Screen.width * transform.position.x;
		//realHeight = Screen.height * transform.position.y;
		if(relativePixelInset)
		{
			guiTexture.pixelInset = new Rect(realPixelInsetX,realPixelInsetY,realWidth,realHeight);
		}else
		{
			guiTexture.pixelInset = new Rect(guiTexture.pixelInset.x,guiTexture.pixelInset.y,realWidth,realHeight);
		}
		
		if(guiText)
		{
			if(useRelativeGUITextPosition)
			{
				guiText.pixelOffset = new Vector2(Screen.width * TextRelativePixelOffsetX,Screen.height * TextRelativePixelOffsetY);
			}
			if(useRelativeGUITextFontsize)
			{
				guiText.fontSize = (Screen.width / 400)  * 15;
			}
		}
	}
}
