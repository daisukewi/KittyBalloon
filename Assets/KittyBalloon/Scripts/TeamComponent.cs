using UnityEngine;
using System.Collections;

public class TeamComponent : MonoBehaviour {

    public int Team = 0;

    public int GetTeam()
    {
        return Team;
    }
}

//It is common to create a class to contain all of your
//extension methods. This class must be static.
public static class TeamComponentExtensionMethods
{
    public static int GetTeam(this GameObject Go)
    {
        TeamComponent team = Go.GetComponent<TeamComponent>();
        if (team)
        {
            return team.Team;
        }
        else
        {
            if (Go.transform.parent)
            {
                return Go.transform.parent.gameObject.GetTeam();
            }
        }

        return -1;
    }
}
