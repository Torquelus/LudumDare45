[System.Serializable]
public class CharacterStats
{
	// Declare the variables
	public string name = "Citizen";     // Character name
	public string stateName;			// Character's State
	public int energy = 10;				// Character's Energy
	public int health = 10;				// Holds Characters health
	public int? hunger = null;			// HUman Hunger (Pending)

	public State charaState;			// State of character (i.e. Human, Zombie, etc.)

	// Init Character State
	public void InitCharacter() {
		charaState = new SkeletonState();
		charaState.SetChara(this);
		stateName = charaState.GetState();
	}

	// Change Character State
	public void ChangeState() {
		switch (charaState.GetState()) {
			case "Skeleton":
				charaState = new FleshGolemState();
				charaState.SetChara(this);
				stateName = charaState.GetState();
				break;

			case "Flesh Golem":
				charaState = new ZombieState();
				charaState.SetChara(this);
				stateName = charaState.GetState();
				break;

			case "Zombie":
				charaState = new HumanState();
				charaState.SetChara(this);
				stateName = charaState.GetState();
				hunger = 10;
				break;
		}
	}
}
