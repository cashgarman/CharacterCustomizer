using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
	private List<Bone> _children;

	// Children of the bone using LINQ
	public List<Bone> Children => _children ??= GetChildren();

	private List<Bone> GetChildren()
	{
		var children = new List<Bone>();
		for (var i = 0; i < transform.childCount; i++)
		{
			var child = transform.GetChild(i).GetComponent<Bone>();
			if (child != null)
			{
				children.Add(child);
			}
		}

		return children;
	}

	private void OnDrawGizmos()
	{
		// Draw a sphere at the bone's position
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 0.05f);
		
		// Draw lines to children
		foreach (var child in Children)
		{
			Gizmos.color = Color.white;
			Gizmos.DrawLine(transform.position, child.transform.position);
		}
	}
}