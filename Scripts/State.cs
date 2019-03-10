using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//allows access/creation of scriptable objects in the inspector/assest area (via menu)
[CreateAssetMenu(menuName = "State")]

//replace MonoBehaviour with ScriptableObject when making a scriptable object
//scriptable objects do not need to be attached to a game object in unity
public class State : ScriptableObject
{
    //TextArea - first number = min. size in inspector of text field; second = amount of line before scrolling
    [TextArea(10,14)]  [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    
    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

}
