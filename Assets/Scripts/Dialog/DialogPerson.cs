using UnityEngine;
using System.Collections;

public class DialogPerson
{
	private string name;
	private DialogAudio voice;
	private Sprite sprite;

	public DialogPerson(string n, DialogAudio v, Sprite s)
	{
		name = n;
		voice = v;
		sprite = s;
	}

	public string getName()
	{
		return name;
	}

	public DialogAudio getVoice()
	{
		return voice;
	}

	public Sprite getSprite()
	{
		return sprite;
	}

}
