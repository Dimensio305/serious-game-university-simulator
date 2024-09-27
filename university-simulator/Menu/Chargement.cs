using Godot;
using System;

public partial class Chargement : ColorRect
{
	[Export] private float loadingSpeed = 30f; // Vitesse de chargement par seconde
	private ProgressBar progressBar;
	private Timer startTimer;
	private bool isLoading = false; // Indique si le chargement a commencé

	public override void _Ready()
{
	// Vérifie l'existence des nœuds
	var marginContainerNode = GetNodeOrNull<MarginContainer>("MarginContainer");
	var vBoxContainerNode = marginContainerNode.GetNodeOrNull<VBoxContainer>("VBoxContainer");
	progressBar = vBoxContainerNode.GetNodeOrNull<ProgressBar>("ProgressBar");
	if (progressBar == null)
	{
		GD.PrintErr("Je trouve pas la progressbar!");
		return;
	}

	// Récupère et démarre le Timer
	startTimer = GetNodeOrNull<Timer>("/root/i_progressbar/StartTimer");
	if (startTimer == null)
	{
		GD.PrintErr("Je trouve pas le Timer!");
		return;
	}

	// Connecte le signal du Timer
	startTimer.Connect("timeout", new Callable(this, nameof(OnStartTimerTimeout)));

	// Démarre le Timer
	startTimer.Start();
	GD.Print("Debut du timer");
}


	private void OnStartTimerTimeout()
{
	GD.Print("Timer fini debut chargement");
	isLoading = true;
}

public override void _Process(double delta)
{
	if (!isLoading)
	{
		return;
	}


	if (progressBar.Value < progressBar.MaxValue)
	{
		progressBar.Value += loadingSpeed * (float)delta;
	}
	else
	{
		GD.Print("Progressbar pleine");
		GoToMenu();
	}
}

	private void GoToMenu()
	{
		GD.Print("On change de scene pour le menu");
		GetTree().ChangeSceneToFile("res://Menu/i_menu.tscn"); // Assure-toi que ce chemin est correct
	}
}
