﻿using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {
	public static Color orange = new Color(1F, 0.5F, 0F);
	
	public static void DrawRigidbodyRay(Rigidbody rigidBody, Vector3 v1, Vector3 v2){
		Debug.DrawRay (v1 + rigidBody.velocity * Time.fixedDeltaTime, v2);
	}
		
	public static Vector3 RigidBodyPosition(Rigidbody rigidBody){
		return rigidBody.transform.position + rigidBody.velocity * Time.fixedDeltaTime;
	}

	public static void DrawRigidbodyRay(Rigidbody rigidBody, Vector3 start, Vector3 dir, Color color){
		Debug.DrawRay (start + rigidBody.velocity * Time.fixedDeltaTime, dir, color);
	}

	public static float SignedVectorAngle(Vector3 referenceVector, Vector3 otherVector, Vector3 normal) {
		Vector3 perpVector;
		float angle;

		//Use the geometry object normal and one of the input vectors to calculate the perpendicular vector
		perpVector = Vector3.Cross(normal, referenceVector);

		//Now calculate the dot product between the perpendicular vector (perpVector) and the other input vector
		angle = Vector3.Angle(referenceVector, otherVector);
		angle *= Mathf.Sign(Vector3.Dot(perpVector, otherVector));

		return angle;
	}

	private IEnumerable WaitForAnimation(Animation animation){
		do {
			yield return null;
		} while(animation.isPlaying);
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
		Vector3 direction = point - pivot; //get direction relative to pivot
		direction = Quaternion.Euler (angles) * direction; // rotate
		return direction + pivot; // calculate rotated point
	}

	public static float GetAxis(string axis){
		return TeamUtility.IO.InputManager.GetAxis (axis);
	}
	public static bool GetButton(string button){
		bool pressed = TeamUtility.IO.InputManager.GetButton(button);
        if (!pressed)
        {
            pressed = TeamUtility.IO.InputManager.GetAxis(button) != 0;
        }
        return pressed;
    }
	public static bool GetButtonDown(string button){
		return TeamUtility.IO.InputManager.GetButtonDown (button);
	}
	public static bool GetButtonUp(string button){
		return TeamUtility.IO.InputManager.GetButtonUp (button);
	}

	public static bool InLayerMask(int layer, LayerMask layermask) {
		return layermask == (layermask | (1 << layer));
	}

    public static float ConvertScale(float oldMin, float oldMax, float newMin, float newMax, float value)
    {
        value = Mathf.Clamp(value, oldMin, oldMax);
        return (((value - oldMin) * (newMax - newMin)) / (oldMax - oldMin)) + newMin;
    }

    public static bool CanSpawn(Vector3 position, float radius, float height, LayerMask layer)
    {
        Collider[] colliders = Physics.OverlapCapsule(position - Vector3.up * height, position + Vector3.up * height, radius, layer);
        return colliders.Length == 0;
    }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
}
