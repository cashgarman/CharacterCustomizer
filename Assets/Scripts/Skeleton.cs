using UnityEngine;

public enum ValueType
{
	// Define your value types here
	Height,
	Girth
}

public class Skeleton : MonoBehaviour
{
	private Bone _root;
	private Bone _pelvis;
	private Bone _head;
	private Bone _leftUpperArm;
	private Bone _leftLowerArm;
	private Bone _leftHand;
	private Bone _rightUpperArm;
	private Bone _rightLowerArm;
	private Bone _rightHand;
	private Bone _leftUpperLeg;
	private Bone _leftLowerLeg;
	private Bone _rightUpperLeg;
	private Bone _rightLowerLeg;
	private Bone _leftFoot;
	private Bone _rightFoot;

	private float _heightScale = 1.0f; // Height scale factor, default to 1.0
	private float _girthScale = 1.0f; // Girth scale factor, default to 1.0
	private float _initialGirthScale;
	private float _initialHeightScale;

	[SerializeField] private Bone _bonePrefab;

	private void Start()
	{
		InitializeSkeleton();

		// Store the initial height and girth scales for each bone
		_initialHeightScale = _root.transform.localScale.y;
		_initialGirthScale = _root.transform.localScale.x;
	}

	private void Update()
	{
		// Apply scales to bones based on initial proportions
		ApplyBoneScales(_root, _heightScale, _girthScale);
	}

	public void UpdateHeight(float heightScale)
	{
		Debug.Log($"Height scale: {heightScale}");
		_heightScale = heightScale;
		_root.transform.localScale = new Vector3(_root.transform.localScale.x, heightScale * _initialHeightScale, _root.transform.localScale.z);
	}

	public void UpdateGirth(float girthScale)
	{
		Debug.Log($"Girth scale: {girthScale}");
		_girthScale = girthScale;
		_root.transform.localScale = new Vector3(girthScale * _initialGirthScale, _root.transform.localScale.y, _root.transform.localScale.z);
	}

	private void InitializeSkeleton()
	{
		if (_root == null)
		{
			// Create root (torso)
			_root = CreateBone("Torso", transform.position, Quaternion.identity);

			// Create pelvis
			_pelvis = CreateBone("Pelvis", new Vector3(0, -0.3f, 0), Quaternion.identity, _root);

			// Create head
			_head = CreateBone("Head", new Vector3(0, 0.5f, 0), Quaternion.identity, _root);

			// Create left arm bones
			_leftUpperArm = CreateBone("LeftUpperArm", new Vector3(-0.5f, 0, 0), Quaternion.identity, _root);
			_leftLowerArm = CreateBone("LeftLowerArm", new Vector3(-0.5f, -0.3f, 0), Quaternion.identity, _leftUpperArm);
			_leftHand = CreateBone("LeftHand", new Vector3(-0.5f, -0.6f, 0), Quaternion.identity, _leftLowerArm);

			// Create right arm
			_rightUpperArm = CreateBone("RightUpperArm", new Vector3(0.5f, 0, 0), Quaternion.identity, _root);
			_rightLowerArm = CreateBone("RightLowerArm", new Vector3(0.5f, -0.3f, 0), Quaternion.identity, _rightUpperArm);
			_rightHand = CreateBone("RightHand", new Vector3(0.5f, -0.6f, 0), Quaternion.identity, _rightLowerArm);

			// Create left leg
			_leftUpperLeg = CreateBone("LeftUpperLeg", new Vector3(-0.2f, -0.8f, 0), Quaternion.identity, _pelvis);
			_leftLowerLeg = CreateBone("LeftLowerLeg", new Vector3(-0.2f, -1.3f, 0), Quaternion.identity, _leftUpperLeg);
			_leftFoot = CreateBone("LeftFoot", new Vector3(-0.2f, -1.6f, 0), Quaternion.identity, _leftLowerLeg);

			// Create right leg
			_rightUpperLeg = CreateBone("RightUpperLeg", new Vector3(0.2f, -0.8f, 0), Quaternion.identity, _pelvis);
			_rightLowerLeg = CreateBone("RightLowerLeg", new Vector3(0.2f, -1.3f, 0), Quaternion.identity, _rightUpperLeg);
			_rightFoot = CreateBone("RightFoot", new Vector3(0.2f, -1.6f, 0), Quaternion.identity, _rightLowerLeg);

			Debug.Log($"Root bone: {_root.name}");
			_initialHeightScale = _root.transform.localScale.y;
			_initialGirthScale = _root.transform.localScale.x;
		}
	}

	private Bone CreateBone(string name, Vector3 position, Quaternion rotation, Bone parentBone = null)
	{
		var bone = Instantiate(_bonePrefab, position, rotation, parentBone != null ? parentBone.transform : transform);
		bone.name = name;
		return bone.GetComponent<Bone>();
	}

	private void ApplyBoneScales(Bone bone, float heightScale, float girthScale)
	{
		bone.transform.localScale = new Vector3(girthScale * _initialGirthScale, heightScale * _initialHeightScale, bone.transform.localScale.z);

		foreach (var child in bone.Children)
			ApplyBoneScales(child, heightScale, girthScale);
	}

	public void UpdateValue(ValueType valueType, float value)
	{
		switch (valueType)
		{
			case ValueType.Height:
				UpdateHeight(value);
				break;
			case ValueType.Girth:
				UpdateGirth(value);
				break;
		}
	}
}