using UnityEngine;
using System.Collections;


public class Item : MonoBehaviour
{
	public string name;
	//könnte zu einem string array gemacht werden um mehrere sprachen zu bedienen
	public string beschreibung;

	//damit könnte abgefragt werden ob dieses Item mit einem Objekt oder ereignis des Richtigen Codes verwendet werden kann!?
	public short verwendungsCode;

	public Sprite aussehen;

    public Item(string n, string b, short code, Sprite s)
	{
		name = n;
		beschreibung = b;
		verwendungsCode = code;

		aussehen = s;
	}

	public string getName()
	{
		return name;
	}

    public short getCode()
    {
        return verwendungsCode;
    }

    public string getBeschreibung()
	{
		return beschreibung;
	}

	public Sprite getSprite()
	{
		return aussehen;
	}

}
