using FindShaulsTreasure.Models;
using FindShaulsTreasure.Quests;
using System.Xml.Serialization;

namespace FindShaulsTreasure.Pages;

public partial class QuestHolder : ContentPage
{
	int teamId = 5;

	BaseQuestView? currentQuest;
	Queue<BaseQuestView> quests = new Queue<BaseQuestView>();

    public QuestHolder()
	{
		InitializeComponent();

        quests.Enqueue(new Quests.Group_00.Quest_00(teamId));

		for (int i = 0; i < teamId % quests.Count; i++)
		{
			quests.Enqueue(quests.Dequeue());
		}

		LoadNext();
	}

	private void SetQuest(BaseQuestView quest)
	{
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
				LoadNext();
            }
            else
            {
                await DisplayAlert("Wait", "Quest tasks not finished.", "OK");
            }
        }
	}
}