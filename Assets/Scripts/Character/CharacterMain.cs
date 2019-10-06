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

	public void SetName(string newName) {
		charaStat.name = newName;
	}

	public void SetModel() {

	}

	public void IncStats(int stat, int amt) {
		switch (stat) {
			// Energy
			case 0:
				charaStat.energy += amt;
				break;

			// Health
			case 1:
				charaStat.health += amt;
				break;

			// Hunger
			case 2:
				charaStat.hunger += amt;
				break;
		}

	}

	public void DecStats(int stat, int amt) {
		switch (stat) {
			// Energy
			case 0:
				if (charaStat.energy > amt) {
					charaStat.energy -= amt;
				}
				else {
					charaStat.energy = 0;
				}

				break;

			// Health
			case 1:
				if (charaStat.health > amt) {
					charaStat.health -= amt;
				}
				else {
					charaStat.health = 0;
				}
				break;

			// Hunger
			case 2:
				if (charaStat.hunger> amt) {
					charaStat.hunger -= amt;
				}
				else {
					charaStat.hunger = 0;
				}
				break;
		}
	}
}
