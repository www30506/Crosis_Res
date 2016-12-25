using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof (EventTrigger))]
[AddComponentMenu("UI/Other/CButton")]
public class CButton : MonoBehaviour {
	private bool isMouseDown =false;
	private EventTrigger eventTrigger;
	[SerializeField]private Text text;
	[SerializeField]private Color pressColor = new Color(0,0,0,1);
	[SerializeField]private Color unPressColor= new Color(1,1,1,1);

	void Start () {
		AddListener ();
	}

	private void AddListener(){
		eventTrigger = this.GetComponent<EventTrigger> ();

		AddEventTrigger(OnMouseDown, EventTriggerType.PointerDown);
		AddEventTrigger(OnMouseUp, EventTriggerType.PointerUp);
		AddEventTrigger(OnMouseEnter, EventTriggerType.PointerEnter);
		AddEventTrigger(OnMouseExit, EventTriggerType.PointerExit);
	}


	private void AddEventTrigger(UnityAction action, EventTriggerType triggerType)
	{
		// Create a nee TriggerEvent and add a listener
		EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
		trigger.AddListener((eventData) => action()); // you can capture and pass the event data to the listener

		// Create and initialise EventTrigger.Entry using the created TriggerEvent
		EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };

		// Add the EventTrigger.Entry to delegates list on the EventTrigger
		eventTrigger.triggers.Add(entry);
	}

	private void AddEventTrigger(UnityAction<BaseEventData> action, EventTriggerType triggerType)
	{
		// Create a nee TriggerEvent and add a listener
		EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
		trigger.AddListener((eventData) => action(eventData)); // you can capture and pass the event data to the listener

		// Create and initialise EventTrigger.Entry using the created TriggerEvent
		EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };

		// Add the EventTrigger.Entry to delegates list on the EventTrigger
		eventTrigger.triggers.Add(entry);
	}

	void Update () {
	
	}

	public void OnMouseDown(){
		isMouseDown = true;
		text.color = pressColor;
	}

	public void OnMouseUp(){
		isMouseDown = false;
		text.color = unPressColor;
	}

	public void OnMouseEnter(){
		if (isMouseDown) {
			text.color = pressColor;
		}
	}

	public void OnMouseExit(){
		if (isMouseDown) {
			text.color = unPressColor;
		}
	}
}
