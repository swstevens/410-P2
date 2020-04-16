using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {

	public Transform player;
	public GameEnding gameEnding;
	public float cutoff;

	bool m_IsPlayerInRange;

	void OnTriggerEnter(Collider other) {

		if(other.transform == player) {

			m_IsPlayerInRange = true;
		}
	}

	void OnTriggerExit(Collider other) {

		if(other.transform == player) {

			m_IsPlayerInRange = false;
		}
	}

	void Update() {

		if(m_IsPlayerInRange) {

			Vector3 direction = player.position - transform.position + Vector3.up;
			
			Ray ray = new Ray (transform.position, direction); 
			RaycastHit raycastHit;

			if(Physics.Raycast(ray, out raycastHit)) {

				if(raycastHit.collider.transform == player) {

					gameEnding.CaughtPlayer();
				}
			}
		}
		// ghost looks at the player if it has LOS and the player is in front of it
		float cosAngle = Vector3.Dot((player.position - this.transform.position).normalized, this.transform.forward);
		float angle = Mathf.Acos(cosAngle) * Mathf.Rad2Deg;
		if (angle < cutoff) 
		{
			Vector3 direction = player.position - transform.position + Vector3.up;
			
			Ray ray = new Ray (transform.position, direction); 
			RaycastHit raycastHit;

			if(Physics.Raycast(ray, out raycastHit)) {

				if(raycastHit.collider.transform == player) {

					this.transform.parent.LookAt(player);
					this.transform.LookAt(player);
				}
			}
		}
	}
}
