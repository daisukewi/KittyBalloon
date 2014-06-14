using System;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour {
    
    public Action OnActivateTrigger = null;

	/// When to execute the action
    public ActivationData.UseMode ExectuteMode = ActivationData.UseMode.OnTriggerEnter;
	
	/// The action to accomplish
    public ActivationData.Mode action = ActivationData.Mode.Activate;
	
	//Tags that can activate this
	public string[] ActivableByTags;
	
	// Message to send
	public string Message ="";
	// Axis to be pressed
	public string KeyPressed ="";
	
	/// The game object to affect. If none, the trigger work on this game object
	public UnityEngine.Object target;
	public GameObject source;
	public int triggerCount = 1;///
	public bool repeatTrigger = false;

    //public ActivationData[] ActivationsList;

	void DoActivateTrigger () {
		triggerCount--;

		if (triggerCount == 0 || repeatTrigger) {
            UnityEngine.Object currentTarget = target != null ? target : gameObject;
			Behaviour targetBehaviour = currentTarget as Behaviour;
			GameObject targetGameObject = currentTarget as GameObject;
			if (targetBehaviour != null)
				targetGameObject = targetBehaviour.gameObject;
		
			switch (action) {
                case ActivationData.Mode.Trigger:
					targetGameObject.BroadcastMessage ("DoActivateTrigger");
					break;
                case ActivationData.Mode.Replace:
					if (source != null) {
                        UnityEngine.Object.Instantiate(source, targetGameObject.transform.position, targetGameObject.transform.rotation);
						DestroyObject (targetGameObject);
					}
					break;
                case ActivationData.Mode.Activate:
					targetGameObject.SetActive(true);
					break;
                case ActivationData.Mode.Enable:
					if (targetBehaviour != null)
						targetBehaviour.enabled = true;
					break;
                case ActivationData.Mode.Animate:
					targetGameObject.animation.Play ();
					break;
                case ActivationData.Mode.Deactivate:
					targetGameObject.SetActive(false);
					break;
                case ActivationData.Mode.SendMessage:
					targetGameObject.BroadcastMessage(Message);
					break;
				
			}

            if (OnActivateTrigger != null)
            {
                OnActivateTrigger();
            }
		}
	}

	void OnTriggerEnter (Collider other) {
		bool found = (ActivableByTags.Length>0)? false:true;
		
		foreach (string AbT in ActivableByTags)
		{
			if(other.CompareTag(AbT))
			{
				found = true;
			}
		}
		
		
		if(!found){
			return;
		}

        if (ExectuteMode == ActivationData.UseMode.OnTriggerEnter)
		{
			DoActivateTrigger();
		}
	}
	
	void OnTriggerExit (Collider other) {
		bool found = (ActivableByTags.Length>0)? false:true;
		
		foreach (string AbT in ActivableByTags)
		{
			if(other.CompareTag(AbT))
			{
				found = true;
			}
		}
		
		
		if(!found){
			return;
		}

        if (ExectuteMode == ActivationData.UseMode.OnTriggerExit)
		{
			DoActivateTrigger();
		}
	}
	
	void OnTriggerStay (Collider other) {
		bool found = (ActivableByTags.Length>0)? false:true;
		
		foreach (string AbT in ActivableByTags)
		{
			if(other.CompareTag(AbT))
			{
				found = true;
			}
		}
		
		
		if(!found){
			return;
		}

        if (ExectuteMode == ActivationData.UseMode.OnTriggerStay)
		{
			DoActivateTrigger();
		}

        if (ExectuteMode == ActivationData.UseMode.OnTriggerStayPressKey)
		{
			if(Input.GetButtonDown(KeyPressed))
			{
				DoActivateTrigger();
			}
		}
	}
}

[System.Serializable]
public class ActivationData
{
    public enum Mode
    {
        None,
        Trigger,        // Just broadcast the action on to the target
        Replace,        // replace target with source
        Activate,       // Activate the target GameObject
        Enable,         // Enable a component
        Animate,        // Start animation on target
        Deactivate,     // Decativate target GameObject
        SendMessage,    // Send a message to the target
    }

    public enum UseMode
    {
        None,
        OnTriggerEnter,         // Activate the Trigger on enter
        OnTriggerExit,          // Activate the Trigger on exit
        OnTriggerStay,          // Activate the Trigger everytime he stays
        OnTriggerStayPressKey,  // Enable a component
    }

    /// When to execute the action
    public UseMode ExectuteMode = UseMode.OnTriggerEnter;

    /// The action to accomplish
    public Mode action = Mode.Activate;

    //Tags that can activate this
    public string[] ActivableByTags;

    // Message to send
    public string Message = "";
    // Axis to be pressed
    public string KeyPressed = "";

    /// The game object to affect. If none, the trigger work on this game object
    public UnityEngine.Object target;
    public GameObject source;
    public int triggerCount = 1;///
    public bool repeatTrigger = false;

}