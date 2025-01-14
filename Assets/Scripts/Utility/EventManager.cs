using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventName
{
    
}

public static class EventManager
{
    public delegate void EventReceiver(params object[] parameter);

    static Dictionary<string, EventReceiver> _events = new Dictionary<string, EventReceiver>();

    public static void Subscribe(string eventType, EventReceiver method)
    {
        if (!_events.ContainsKey(eventType))
            _events.Add(eventType, method);
        else
            _events[eventType] += method;
    }
    
    public static void Subscribe(EventName eventType, EventReceiver method)
    {
        var eventName = eventType.ToString();
        
        if (!_events.ContainsKey(eventName))
            _events.Add(eventName, method);
        else
            _events[eventName] += method;
    }

    public static void UnSubscribe(string eventType, EventReceiver method)
    {
        if (_events.ContainsKey(eventType))
        {
            _events[eventType] -= method;

            if (_events[eventType] == null)
                _events.Remove(eventType);
        }
    }

    public static void Trigger(string eventType, params object[] parameters)
    {
        if (_events.ContainsKey(eventType))
            _events[eventType](parameters);
    }
    
    public static void Trigger(EventName eventType, params object[] parameters)
    {
        var name = eventType.ToString();
        
        if (_events.ContainsKey(name))
            _events[name](parameters);
    }

    public static void ResetEventDictionary()
    {
        _events = new Dictionary<string, EventReceiver>();
    }
}