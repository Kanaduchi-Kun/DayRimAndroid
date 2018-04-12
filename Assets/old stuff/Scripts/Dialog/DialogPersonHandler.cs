using UnityEngine;
using System.Collections;

public class DialogPersonHandler : MonoBehaviour {


	// Character Sprites
	public Sprite Feli;
	public Sprite Felix;
	public Sprite Popa;
	public Sprite Mero;
	public Sprite Syrx;
	public Sprite Luise;
	public Sprite Moehre;
	public Sprite Tardos;

	// Character Voices
	public AudioClip FeliSound1;
	public AudioClip FeliSound2;
	public AudioClip FeliSound3;

	public AudioClip FelixSound1;
	public AudioClip FelixSound2;
	public AudioClip FelixSound3;

	public AudioClip PopaSound1;
	public AudioClip PopaSound2;
	public AudioClip PopaSound3;

	public AudioClip MeroSound1;
	public AudioClip MeroSound2;
	public AudioClip MeroSound3;

	public AudioClip SyrxSound1;
	public AudioClip SyrxSound2;
	public AudioClip SyrxSound3;

	public AudioClip LuiseSound1;
	public AudioClip LuiseSound2;
	public AudioClip LuiseSound3;

	public AudioClip MoehreSound1;
	public AudioClip MoehreSound2;
	public AudioClip MoehreSound3;

	//Matze
	public AudioClip TardosSound1;
	public AudioClip TardosSound2;
	public AudioClip TardosSound3;


	// Charakter Dialog Profiles
	private DialogPerson FeliProfil;
	private DialogPerson FelixProfil;
	private DialogPerson PopaProfil;
	private DialogPerson MeroProfil;
	private DialogPerson SyrxProfil;
	private DialogPerson LuiseProfil;
	private DialogPerson TardosProfil;
	private DialogPerson MoehreProfil;


	// Use this for initialization
	void Start () {

		//SFX chari 2
		DialogAudio FelixAudio = new DialogAudio (0.5f, 0.7f);
		FelixAudio.addSoundClip(FelixSound1);
		FelixAudio.addSoundClip(FelixSound2);
		FelixAudio.addSoundClip(FelixSound3);

		//SFX chari 1
		DialogAudio FeliAudio = new DialogAudio (1.1f, 1.3f);
		FeliAudio.addSoundClip(FeliSound1);
		FeliAudio.addSoundClip(FeliSound2);
		FeliAudio.addSoundClip(FeliSound3);

		//SFX chari 6
		DialogAudio PopaAudio = new DialogAudio (0.95f, 1.3f);
		PopaAudio.addSoundClip(PopaSound1);
		PopaAudio.addSoundClip(PopaSound2);
		PopaAudio.addSoundClip(PopaSound3);

		//SFX chari 4
		DialogAudio MeroAudio = new DialogAudio (0.8f, 1.0f);
		MeroAudio.addSoundClip(MeroSound1);
		MeroAudio.addSoundClip(MeroSound2);
		MeroAudio.addSoundClip(MeroSound3);

		//SFX bayer
		DialogAudio SyrxAudio = new DialogAudio (0.9f, 1.2f);
		SyrxAudio.addSoundClip(SyrxSound1);
		SyrxAudio.addSoundClip(SyrxSound2);
		SyrxAudio.addSoundClip(SyrxSound3);

		//SFX chari 9
		DialogAudio LuiseAudio = new DialogAudio (0.7f, 1.0f);
		LuiseAudio.addSoundClip(LuiseSound1);
		LuiseAudio.addSoundClip(LuiseSound2);
		LuiseAudio.addSoundClip(LuiseSound3);

		//SFX chari 8
		DialogAudio MoehreAudio = new DialogAudio (1.1f, 1.3f);
		MoehreAudio.addSoundClip(MoehreSound1);
		MoehreAudio.addSoundClip(MoehreSound2);
		MoehreAudio.addSoundClip(MoehreSound3);

		//Matze

		//SFX tardos
		DialogAudio TardosAudio = new DialogAudio (1.0f, 1.0f);
		TardosAudio.addSoundClip(TardosSound1);
		TardosAudio.addSoundClip(TardosSound2);
		TardosAudio.addSoundClip(TardosSound3);

		FelixProfil = new DialogPerson("Felix", FelixAudio, Felix);
		FeliProfil =  new DialogPerson("Feli", FeliAudio, Feli);
		PopaProfil =  new DialogPerson("Popa", PopaAudio, Popa);
		MeroProfil =  new DialogPerson("Mero", MeroAudio, Mero);
		SyrxProfil =  new DialogPerson("Syrx", SyrxAudio, Syrx);
		LuiseProfil =  new DialogPerson("Luise", LuiseAudio, Luise);
		MoehreProfil =  new DialogPerson("Möhre", MoehreAudio, Moehre);
		//Matze
		TardosProfil = new DialogPerson("Tardos", TardosAudio, Tardos);
		//FeliProfil =  new DialogPerson("Feli", FeliAudio, );



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public DialogPerson getPerson(string name)
	{
		DialogPerson tmp = null;

        Debug.Log("Der übergebene Name ist " + name);

        switch (name) 
		{
		case "Feli": 
			tmp = FeliProfil;
			break;

		case "Felix": 
			tmp = FelixProfil;
			break;

		case "Popa": 
			tmp = PopaProfil;
			break;

		case "Mero": 
			tmp = MeroProfil;
			break;

		case "Syrx": 
			tmp = SyrxProfil;
			break;

		case "Luise": 
			tmp = LuiseProfil;
			break;

		case "Möhre": 
			tmp = MoehreProfil;
			break;

			//Matze
		case "Tardos": 
			tmp = TardosProfil;
			break;

		default:
                
                break;
		}

		return tmp;
	}
}
