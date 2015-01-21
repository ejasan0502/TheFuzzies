using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject dragObject;
	private RectTransform canvasRectTransform;

	void Start(){
		canvasRectTransform = transform.parent as RectTransform;
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		dragObject = gameObject;
	}

	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		dragObject = null;
		if ( !RectTransformUtility.RectangleContainsScreenPoint(canvasRectTransform,Input.mousePosition,eventData.pressEventCamera) ){
			Player p = GameObject.FindWithTag("Player").GetComponent<Player>();
			
			GameObject o = Instantiate(Resources.Load ("Prefabs/Loot"),p.transform.position+p.transform.right,Quaternion.identity) as GameObject;
			o.name = "Loot";
			
			Loot l = o.GetComponent<Loot>();
			l.item = p.inventory.slots[int.Parse(name)].item;
			
			p.inventory.RemoveItem(int.Parse(name));
			
			Destroy (gameObject);
		}
	}

	#endregion
}

