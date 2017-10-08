using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

public class DialogPanel : MonoBehaviour {


	public Canvas dialogCanvas;
	public Image dialog_panel;


	public static DialogPanel s_instance = null;
	public Image image;

	public static DialogTree root;

	private string ausgabeNachricht;

	public bool isTyping = true;
	private float letterPause = 0.07f;
	private short newAudioAfterLetters = 7;

	public Text textField;
	public Text nameField;

	public Button answer1;
	public Button answer2;
	public Button answer3;

	public Button answer4;
	public Button answer5;
	public Button answer6;

	public short pushedButton;
	public bool buttonWasPushed = false;

	public bool textFinished = false;
	// prevents touch chaining
	private bool clickControl = false;

	public DialogPersonHandler personen;
	public AudioSource audio;

	private DialogPerson currentPerson;
	private DialogAudio currentAudio;


	void Awake()
	{
		// singleton
		if (s_instance == null)
			s_instance = this;
		else if (s_instance != this)
			Destroy(gameObject);


		answer1.onClick.AddListener ( () => {selectButton(0);});
		answer2.onClick.AddListener ( () => {selectButton(1);});
		answer3.onClick.AddListener ( () => {selectButton(2);});

		answer4.onClick.AddListener ( () => {selectButton(3);});
		answer5.onClick.AddListener ( () => {selectButton(4);});
		answer6.onClick.AddListener ( () => {selectButton(5);});

		//alle buttens vorerst disabled!
		answer1.gameObject.SetActive(false);
		answer2.gameObject.SetActive(false);
		answer3.gameObject.SetActive(false);

		answer4.gameObject.SetActive(false);
		answer5.gameObject.SetActive(false);
		answer6.gameObject.SetActive(false);

		//nameField = transform.GetChild (1);
		//textField = transform.GetChild (2);


		Assert.IsNotNull<Text>(textField);
		//m_audioThis = GetComponent<AudioSource>();
		//Assert.IsNotNull<AudioSource>(m_audioThis);
		//m_imgThis = GetComponent<Image>();
		//Assert.IsNotNull<Image>(m_imgThis);

		//currentPerson = personen.getPerson (root.getName ());
		//currentAudio = currentPerson.getVoice ();

		//updatePanel ();
	}

	// Use this for initialization
	void Start () {

		dialog_panel.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

        if (audio.volume != BackgroundMusicContinuation.soundVolume)
            audio.volume = BackgroundMusicContinuation.soundVolume;

        if (this.gameObject.activeSelf) {


			//if (Input.GetKeyDown (KeyCode.Space) && isTyping) {
			if (Input.anyKey && isTyping) {	
				Skip ();
				clickControl = true;
			}
		// falls einfach nur monologtext läuft
		//else if (Input.GetKeyDown (KeyCode.Space) && !root.isQuestion ()) {
		else if (Input.anyKey && !root.isQuestion () && clickControl == false) {
				
				if (root.hasNext ()) {
					setRoot (root.getSubTree (0));

					//test
					updatePanel ();

					answer1.gameObject.SetActive (false);
					answer2.gameObject.SetActive (false);
					answer3.gameObject.SetActive (false);

					answer4.gameObject.SetActive (false);
					answer5.gameObject.SetActive (false);
					answer6.gameObject.SetActive (false);

					textFinished = false;
					//isTyping = false;

				} else {
					//.gameObject.SetActive (false);
					showCanvas (false);
					// TEST!!!!
					//textFinished = false;
				}
			}
		//falls eine Frage ansteht
		else if (root.isQuestion () && !buttonWasPushed && clickControl == false) {

				updatePanel ();

				answer1.gameObject.SetActive (true);
				Text a1 = answer1.GetComponentInChildren<Text> ();
				a1.text = root.getAnswerText (0);

				//textFinished = false;

				if (root.getAnswerTrees ().Count > 1) {
					answer2.gameObject.SetActive (true);
					Text a2 = answer2.GetComponentInChildren<Text> ();
					a2.text = root.getAnswerText (1);
				}

				if (root.getAnswerTrees ().Count > 2) {
					answer3.gameObject.SetActive (true);
					Text a3 = answer3.GetComponentInChildren<Text> ();
					a3.text = root.getAnswerText (2);
				}

				if (root.getAnswerTrees ().Count > 3) {
					answer4.gameObject.SetActive (true);
					Text a4 = answer4.GetComponentInChildren<Text> ();
					a4.text = root.getAnswerText (3);
				}

				if (root.getAnswerTrees ().Count > 4) {
					answer5.gameObject.SetActive (true);
					Text a5 = answer5.GetComponentInChildren<Text> ();
					a5.text = root.getAnswerText (4);
				}

				if (root.getAnswerTrees ().Count > 5) {
					answer6.gameObject.SetActive (true);
					Text a6 = answer6.GetComponentInChildren<Text> ();
					a6.text = root.getAnswerText (5);
				}

				// TEST!!!!
				//textFinished = false;

				//answer3.name = root.getAnswerText (2);
			} else if (root.isQuestion () && buttonWasPushed && clickControl == false) {
				setRoot (root.getSubTree (pushedButton));

				updatePanel ();

				answer1.gameObject.SetActive (false);
				answer2.gameObject.SetActive (false);
				answer3.gameObject.SetActive (false);

				answer4.gameObject.SetActive (false);
				answer5.gameObject.SetActive (false);
				answer6.gameObject.SetActive (false);

				buttonWasPushed = false;

				textFinished = false;
				//isTyping = false;
			}

			nameField.text = root.name;
			
			if (isTyping)
				return;
		
			if (!textFinished)
				StartCoroutine (TypeText ());


			if (!Input.anyKey)
				clickControl = false;

		}
	}
	/*
	public void showText(DialogTree dialog) 
	{
		nameField.text = dialog.name;
		textField.text = dialog.monologText;

	}
*/
	public void setRoot (DialogTree tree)
	{
		root = tree;
	}
		
	public void selectButton(short b)
	{
		pushedButton = b;
		buttonWasPushed = true;
		//Debug.Log (pushedButton);

	}

	IEnumerator TypeText()
	{

		textField.text = "";
		isTyping = true;
		bool newWord = true;

		textFinished = false;

		int i = 0;
		short letterCount = 0;

		foreach (char letter in root.getMonologText().ToCharArray()) 
		{
			

			if (!letter.Equals ('\\')) {
				//print one character
				textField.text += letter;

				//todo: play sound here if new word
				if (newWord) {
					//currentPerson = personen.getPerson (root.getName ());
					//currentAudio = currentPerson.getVoice ();

					letterCount = 0;

					//if (letterCount == 0 || (letterCount % newAudioAfterLetters) == 0) {
					//	updatePanel ();
					//	RandomPitch (currentAudio);
					//	audio.PlayOneShot (currentAudio.soundClip);
					//}

					updatePanel ();
					RandomPitch (currentAudio);
					//audio.PlayOneShot (currentAudio.soundClip);
					audio.PlayOneShot(currentAudio.getRandomClip());

					newWord = false;
				} else if (!newWord && (letterCount % newAudioAfterLetters) == 0)
				{
					
					updatePanel ();
					RandomPitch (currentAudio);
					//audio.PlayOneShot (currentAudio.soundClip);
					audio.PlayOneShot(currentAudio.getRandomClip());

				}


				if (letter.Equals (' '))
				{
					newWord = true;
				}

			



			}
			else
				textField.text += "\n";

			letterCount++;

			yield return StartCoroutine (CoroutineUtilities.WaitForRealTime (letterPause));
			i++;
		}

		//wiederholt sich ständig
		isTyping = false;

		textFinished = true;
	}

	public void Skip()
	{
		if (isTyping) {
			StopAllCoroutines ();
			textField.text = root.monologText;

			isTyping = false;
			//textFinished = false;
			textFinished = true;

		}
		
	}

	void RandomPitch(DialogAudio a)
	{
		float pitch = Random.Range (a.minPitch, a.maxPitch);
		audio.pitch = pitch;
	}

	/*void RandomAudio()
	{
		//currentAudio  = 
	}*/

	public void updatePanel()
	{
		currentPerson = personen.getPerson (root.getName ());
		currentAudio = currentPerson.getVoice ();

		//Debug.Log (currentPerson.getSprite().name);

		image.sprite = currentPerson.getSprite();

		//TEST!!!!!
		//textField.text = root.getMonologText ();

		//Debug.Log (currentPerson.getSprite().name);


	}

	public void showCanvas(bool tmp)
	{
		//if(!tmp)
		//	textFinished = false;

		dialog_panel.gameObject.SetActive (tmp);
		//watchiteminfo.gameObject.SetActive(tmp);
	}

    public void killDialog()
    {
        showCanvas(false);
    }

	public void setTextFinished(bool tmp)
	{
		textFinished = tmp;
	}
}
