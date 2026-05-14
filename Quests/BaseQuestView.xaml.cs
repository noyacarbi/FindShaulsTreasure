using FindShaulsTreasure.Pages;

namespace FindShaulsTreasure.Quests;

public partial class BaseQuestView : ContentView
{
    public Models.QuestInfo Data { get; protected set; } = null!;
    public int TeamNumber { get; private set; }

    readonly QuestHolder holder;

    public BaseQuestView(int teadId, QuestHolder holder)
	{
        this.holder = holder;
		this.TeamNumber = teadId;
	}

    protected void SetSuccess()
    {
        this.Data.QuestSuccess = true;
        holder.EnableContiue();
    }
}