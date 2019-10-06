public abstract class State
{
	protected  CharacterStats chara;

	public void SetChara(CharacterStats chara) {
		this.chara = chara;
	}

	public abstract string GetState();
}
