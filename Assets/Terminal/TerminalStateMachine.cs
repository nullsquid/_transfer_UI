using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalStateMachine : MonoBehaviour {

	public enum TerminalState{
		IDLE,
		CONNECT,
		SCAN,
		RUN,
		SLEEP
	}
}
