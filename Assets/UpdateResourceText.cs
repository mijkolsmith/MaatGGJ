using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateResourceText : MonoBehaviour
{
	private TextMeshProUGUI text;
	public string amountNeeded;

	private void Awake()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		text.text = GameManager.Instance.rm.Resources.ToString() + amountNeeded;
	}
}