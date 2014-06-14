using UnityEngine;
using System.Collections;

public class StateBaseEnemy : StateBase
{

    override protected void InitState()
    {
        base.InitState();
        HPScript myHPScript = GetComponent<HPScript>();
        if(myHPScript)
        {
            myHPScript.OnHPChanged += OnHPChanged;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnHPChanged(float newHP)
    {
        if(newHP == 1)
        {
            if(CanGoToState("Falling"))
            {
                GoToState("Falling");
            }
        }
    }
}
