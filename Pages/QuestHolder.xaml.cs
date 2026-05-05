using FindShaulsTreasure.Models;
using FindShaulsTreasure.Quests;
using System.Xml.Serialization;

namespace FindShaulsTreasure.Pages;



public partial class QuestHolder : ContentPage
{
	int currentTeamId = 5;

	BaseQuestView? currentQuest;

	public QuestHolder()
	{
		InitializeComponent();

		SetQuest(new Quests.Group_00.Quest_00(currentTeamId));
	}

	private void SetQuest(BaseQuestView quest)
	{
		currentQuest= quest;
		cvCurrentQuest = quest;

		QuestInfo data = currentQuest.Data;
		lQuestName.Text= data.QuestName;

        bool isManual = data.QuestType == Models.QuestType.Manual;
        gManual.IsVisible = isManual;
        gAuto.IsVisible = !isManual;

        if (isManual) eAnswer.Text = "";
    }

	private async void bSubmit_Clicked(object sender, EventArgs e)
	{
		if (currentQuest == null) return;

		QuestInfo data = currentQuest.Data;

		if (data.QuestType == Models.QuestType.Manual)
		{
			if (eAnswer.Text.Trim() == data.QuestAnswer.Trim())
			{
                await DisplayAlert("Success", "Correct answer!", "OK");
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
                await DisplayAlert("Success", "Quest complete!", "OK");
            }
            else
            {
                await DisplayAlert("Wait", "Quest tasks not finished.", "OK");
            }
        }
	}
}