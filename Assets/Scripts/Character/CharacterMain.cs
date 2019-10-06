using UnityEngine;

[System.Serializable]
public class CharacterMain : MonoBehaviour {

	[Header("Character Stats")]
	public CharacterStats charaStat;

	public void Start() {
		charaStat.InitCharacter();
	}

	public void Update() {
	}
}
