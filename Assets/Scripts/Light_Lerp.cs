using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Lerp : MonoBehaviour {

	public Transform m_Target;
	public Transform m_Target_2;

	public float speed;

	Vector3 starting_pos;
	Vector3 target_pos;

	private float startTime;
	private float journeyLength;
	
    void Start() {

    	target_pos = m_Target.position;
    	starting_pos = m_Target_2.position;

        startTime = Time.time;

        journeyLength = Vector3.Distance(m_Target_2.position, m_Target.position);

    }

    void Update() {

    	float distCovered = (Time.time - startTime) * speed;
    	float fractionOfJourney = distCovered / journeyLength;

    	transform.position = Vector3.Lerp(starting_pos, target_pos, fractionOfJourney);

        if (transform.position == target_pos) {

        	if (target_pos == m_Target.position) {

        		target_pos = m_Target_2.position;
        		starting_pos = m_Target.position;

        	} else {

        		target_pos = m_Target.position;
        		starting_pos = m_Target_2.position;

        	}

        	startTime = Time.time;
        } 
    }
}
