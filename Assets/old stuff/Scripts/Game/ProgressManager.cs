using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour 
{
    public enum ProgressStates { NEWGAME, FOUNDBOX, STARTMISSION, SPAWNSYRX, GOTJUNK, GOTBUILD, GOTPHONE, PAINTEDBOX, ENDPROJECT }; 
    public static ProgressStates STORYPROGRESS;

    /* ERKLÄRUNG DER VERSCHIEDENEN STORYABSCHNITTE, DIE FÜR DIALOGÄNDERUNGEN SORGEN
     * 
     * 00 NEWGAME: Neues Spiel, Abspielen der Introszene
     * 01 FOUNDBOX: Luises Kiste gefunden (Erste Dialogoption für Luise)
     * 02 STARTMISSION: Von Luise die Aufgabe bekommen sich Hilfe von den anderen zu suchen, um Muscheltelefon zu bauen (Nächste Dialogoptionen für Luise, Szenenwechsel und Betreten Wohnwagen und Kran möglich)
     * 03 SPAWNSYRX: Nachdem man den Wohnwagen das erste Mal betreten hat, erscheint Syrx auf dem Dach der Wohnwagen
     * 04 GOTJUNK: Popa gefüttert und Schrott bekommen (Neue Dialogoption für Luise und Popa, die einen daran erinnert, dass man noch zwei Leuten helfen soll)
     * 05 GOTBUILD: Syrx geholfen, noch nicht funktionales Telefon bekommen (Neue Dialogoption für Luise, Popa und Syrx)
     * 06 GOTPHONE: Funktionierendes Telefon erhalten (Neue Dialogoptionen für Luise, Popa, Syrx und Möhre) -> Malrätsel einleiten
     * 07 PAINTEDBOX: Ende des ersten Aktes (Enddialogoptionen für alle?)
     * 08 ENDPROJECT: Ende der Story, die für das Projekt vorgesehen war (Credits abspielen?)
     * 
     * GENERELL NEUE DIALOGOPTIONEN NACH JEDEM(?) SCHRITT FÜR DEN JEWEILS INAKTIVEN CHARAKTER
     */

    public void setProgress(ProgressStates storyprogress)
    {
        STORYPROGRESS = storyprogress;
    }

    public ProgressStates getProgress()
    {
        return STORYPROGRESS;
    }

	public static int getProgressInt()
	{
		int tmp = 0;

		switch (STORYPROGRESS)
		{
		case ProgressStates.NEWGAME:
			tmp = 1;
			break;
		case ProgressStates.FOUNDBOX:
			tmp = 2;
			break;
		case ProgressStates.STARTMISSION:
			tmp = 3;
			break;
		case ProgressStates.SPAWNSYRX:
			tmp = 4;
			break;
		case ProgressStates.GOTJUNK:
			tmp = 5;
			break;
		case ProgressStates.GOTBUILD:
			tmp = 6;
			break;
		case ProgressStates.GOTPHONE:
			tmp = 7;
			break;
		case ProgressStates.PAINTEDBOX:
			tmp = 8;
			break;
		case ProgressStates.ENDPROJECT:
			tmp = 9;
			break;
		
		default:
			tmp = 0;
			break;
		}

		return tmp;
	}
}
