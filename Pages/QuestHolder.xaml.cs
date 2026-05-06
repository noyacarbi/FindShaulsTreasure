using FindShaulsTreasure.Models;
using FindShaulsTreasure.Quests;
using FindShaulsTreasure.Services;

namespace FindShaulsTreasure.Pages;

public partial class QuestHolder : ContentPage
{
	BaseQuestView? currentQuest;
	Queue<BaseQuestView> quests = new Queue<BaseQuestView>();

    public QuestHolder()
	{
		InitializeComponent();

        quests.Enqueue(new Quests.Group_00.Quest_00(GameState.TeamId));

        for (int i = 0; i < GameState.TeamId % quests.Count; i++)
		{
			quests.Enqueue(quests.Dequeue());
		}

		for (int i = 0; i < GameState.QuestIndex; i++)
		{
            if (quests.Count > 0) quests.Dequeue();
        }

		LoadNext();
	}

	private void SetQuest(BaseQuestView quest)
	{
		lScore.Text = $"Score: {GameState.Score}";

		currentQuest= quest;
		cvCurrentQuest.Content = quest;

		QuestInfo data = currentQuest.Data;
		lQuestName.Text= data.QuestName;

        bool isManual = data.QuestType == Models.QuestType.Manual;
        gManual.IsVisible = isManual;
        gAuto.IsVisible = !isManual;

        if (isManual) eAnswer.Text = "";
    }

	private void LoadNext()
	{
		if (quests.Count > 0)
		{
			SetQuest(quests.Dequeue());
		}
		else
		{
			// End Game Logic
		}
	}

	private async void bSubmit_Clicked(object sender, EventArgs e)
	{
		if (currentQuest == null) return;

		QuestInfo data = currentQuest.Data;

		if (data.QuestType == Models.QuestType.Manual)
		{
			if (eAnswer.Text.Trim() == data.QuestAnswer.Trim())
			{
				GameState.Score += (int)(GameState.QuestScore * (data.ScorePercent / 100.0));
                GameState.QuestIndex++;
                LoadNext();
            }
			else
			{
                await DisplayAlert("Wrong", "Try again.", "OK");
            }
		}
		else
		{
            if (data.QuestSuccess)
            {
                GameState.Score += (int)(GameState.QuestScore * (data.ScorePercent / 100.0));
                GameState.QuestIndex++;
                LoadNext();
            }
            else
            {
                await DisplayAlert("Wait", "Quest not finished.", "OK");
            }
        }
	}
}