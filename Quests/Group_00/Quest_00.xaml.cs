using FindShaulsTreasure.Pages;

namespace FindShaulsTreasure.Quests.Group_00;

public partial class Quest_00 : BaseQuestView
{
	public Quest_00(int teamId, QuestHolder holder) : base(teamId, holder)
	{
		Data = new Models.QuestInfo("Example Quest", "Example Hint", Models.QuestType.Automatic, "Example Answer");

		InitializeComponent();

		lTeam.Text = "Current Team: " + TeamNumber.ToString();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		SetSuccess();
    }
}