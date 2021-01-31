using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
	private static Dictionary<AudioType, System.Action> audioDictionary = new Dictionary<AudioType, System.Action>();

	public static void AddListener(AudioType type, System.Action function)
	{
		if (!audioDictionary.ContainsKey(type))
		{
			audioDictionary.Add(type, null);
		}
		audioDictionary[type] += function;
	}

	public static void RemoveListener(AudioType type, System.Action function)
	{
		if (audioDictionary.ContainsKey(type) & audioDictionary[type] != null)
		{
			audioDictionary[type] -= function;
		}
	}

	public static void RaiseEvent(AudioType type)
	{
		audioDictionary[type]?.Invoke();
	}
}
