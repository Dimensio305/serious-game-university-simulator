using Godot;
using System.Collections.Generic;

/// <summary>
/// Script lié à la scène FinduJeu
/// Elle s'occupe de gérer les différentes fins possibles
/// </summary>
public partial class FinduJeu : Node2D
{
	//Noeud enfant de FinduJeu
	private RichTextLabel _endMessage;
	private TextureRect _fond;

	//Liste regroupant les chemins des différents écrans de fin
	private List<string> _listeFond = new List<string>{
			"res://fond_et_titre/Designer (3).jpeg",
			"res://fond_et_titre/Designer (6).jpeg"
		};

	/// <summary>
	/// Methode Ready :Lors du premier chargement de la scène  prends la valeur de chaques jauges
	/// Si il l'une d'elle est à 0 le joueur a perdu et l'on charge l'écran de game over associé
	/// Sinon c'est l'écran de victoire qui est affiché
	/// </summary>
	public override void _Ready()
	{
		_endMessage = GetNode<RichTextLabel>("EndMessage");
		_fond = GetNode<TextureRect>("Fond");
		List<int> jauges = new List<int>
		{
			JaugeManager.GetJaugeValue("Jauge1"),
			JaugeManager.GetJaugeValue("Jauge2"),
			JaugeManager.GetJaugeValue("Jauge3"),
			JaugeManager.GetJaugeValue("Jauge4")
		};
		JaugeManager.UpdateJour();
		_endMessage.Text = "[center][color=orange][b]VOUS AVEZ GAGNEZ[/b]\n Vous avez su gérer et maintenir les formation d'une main de maître\nScore finale : " + JaugeManager.GetScore() + "[/color][/center]";
		_fond.Texture = GD.Load<Texture2D>(_listeFond[0]);
		int i = 1;
		foreach (int jauge in jauges)
		{
			if (jauge == 0)
			{
				switch (i)
				{
					case 1:
						_endMessage.Text = "[center][color=orange][b]VOUS AVEZ PERDU[/b]\n Vous ne savez pas gérer vos finances\nScore finale : " + JaugeManager.GetScore() + "[/color][/center]";
						break;
					case 2:
						_endMessage.Text = "[center][color=orange][b]VOUS AVEZ PERDU[/b]\n Vous ne savez pas gérer la satisfaction de vos professeur\nScore finale : " + JaugeManager.GetScore() + "[/color][/center]";
						break;
					case 3:
						_endMessage.Text = "[center][color=orange][b]VOUS AVEZ PERDU[/b]\n Vous ne savez pas gérer le taux d'insertion de vos élèves\nScore finale : " + JaugeManager.GetScore() + "[/color][/center]";
						break;
					case 4:
						_endMessage.Text = "[center][color=orange][b]VOUS AVEZ PERDU[/b]\n Vous ne savez pas gérer le taux de réussite de vos élèves\nScore finale : " + JaugeManager.GetScore() + "[/color][/center]";
						break;
					default:
						break;
				}
				_fond.Texture = GD.Load<Texture2D>(_listeFond[1]);
			}
			i++;
		}
	}
}
