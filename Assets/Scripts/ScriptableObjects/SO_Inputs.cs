using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Serialization;

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
    
    [SerializedDictionary("Input Type", "Event To Trigger")]
    public SerializedDictionary<InputName, InputInfo> inputs;
}
