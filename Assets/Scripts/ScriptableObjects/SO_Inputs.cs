using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inputs", fileName = "SO_NewInput")]
public class SO_Inputs : ScriptableObject
{
    public ControllerName ControllerName;
    
    [Serializable]
    public struct InputInfo
    {
        public InputType InputType;
        public EventName EventName;
    }
    
    [SerializedDictionary("Input Name", "Input Info")]
    public SerializedDictionary<InputName, InputInfo> inputs;
}
